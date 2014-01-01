Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class Overlay



    ' Handles the process handle grabbing shit
    Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
    Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean
    Private Const FFXIV_PROCESS As String = "ffxiv"
    Private Const PROCESS_VM_READ As UInteger = 16
    Private Const PROCESS_QUERY_INFORMATION As UInteger = 1024
    Private ffxiv_proc As Process
    Private ffxiv_proc_hdl As IntPtr = IntPtr.Zero
    Private Function attachToProcess() As Boolean
        If ffxiv_proc_hdl <> IntPtr.Zero Then Return True ' attached already

        Dim procs As Process() = Process.GetProcessesByName(FFXIV_PROCESS)
        If procs.Length > 0 Then
            Me.lblOverlay.Text = "Attaching..."
            ffxiv_proc = procs(0)
            ffxiv_proc_hdl = OpenProcess(PROCESS_VM_READ Or PROCESS_QUERY_INFORMATION, False, ffxiv_proc.Id)
        End If

        Return ffxiv_proc_hdl <> IntPtr.Zero
    End Function



    ' Magic that will get the percentage, rounded to the hundredth-place, of the current target in ffxiv's memory
    Private Const OFFSET1 = &H20
    Private Const OFFSET2 = &H10
    Private Const OFFSET3 = &H24
    Private Const OFFSET4 = &H20
    Private Const OFFSET5 = 8
    Private Const TARGET_OFFSET = &HF8BBE0
    Public Function ReadInt32(ByVal addr As IntPtr) As Int32
        Dim _dataBytes(3) As Byte
        ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
        Return BitConverter.ToInt32(_dataBytes, 0)
    End Function
    Private Function getTargetHealthPercentage() As Double
        Dim val As Int32 = ReadInt32(ReadInt32(ReadInt32(ReadInt32(ReadInt32(ReadInt32(ffxiv_proc.MainModule.BaseAddress + TARGET_OFFSET) + OFFSET1) + OFFSET2) + OFFSET3) + OFFSET4) + OFFSET5)
        Return Math.Round(val * 0.01, 2)
    End Function



    ' init
    Private Sub Overlay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("An overlay that displays the percentage health of the current target in FFXIV:ARR." & vbCrLf & vbCrLf & "~~Note: the overlay will not overlay in actual fullscreen mode.  If you have 2 monitors, however, you could always put the overlay on the other monitor." & vbCrLf & vbCrLf & "jordansg57@gmail.com - (C) 2013 Cord Rehn", MsgBoxStyle.Information, "Target Percentage Overlay v2.0")

        Me.Left = My.Settings.win_x
        Me.Top = My.Settings.win_y

        Me.Timer1.Interval = My.Settings.refresh

        Me.lblOverlay.Font = My.Settings.font
        Me.lblOverlay.ForeColor = My.Settings.font_color
    End Sub



    ' This all handles click-drag functionality of the overlay
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblOverlay.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top   'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblOverlay.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
            My.Settings.win_x = Me.Left
            My.Settings.win_y = Me.Top
            My.Settings.Save()
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblOverlay.MouseUp
        drag = False
    End Sub



    ' change font color menu option
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim cDialog As New ColorDialog()
        cDialog.Color = Me.lblOverlay.ForeColor

        If cDialog.ShowDialog() = DialogResult.OK Then
            Me.lblOverlay.ForeColor = cDialog.Color
            My.Settings.font_color = Me.lblOverlay.ForeColor
            My.Settings.Save()
        End If
    End Sub



    ' change font menu option
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        FontDialog1.Font = Me.lblOverlay.Font

        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Me.lblOverlay.Font = FontDialog1.Font
            My.Settings.font = Me.lblOverlay.Font
            My.Settings.Save()
        End If
    End Sub



    ' close menu option
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Timer1.Stop()
        Me.Close()
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not attachToProcess() Then
            Me.lblOverlay.Text = "FFXIV Not Running..."

        Else ' attached to ffxiv process, scrape memory for percentage
            Me.lblOverlay.Text = getTargetHealthPercentage() + "%"
        End If
    End Sub



    ' Settings menu option
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Settings.Show()
    End Sub



    ' donate button
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=JordanSg57%40gmail%2ecom&lc=US&item_name=Freelance%20Developer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")
    End Sub



    ' close
    Private Sub Overlay_FormClosed() Handles MyBase.FormClosed
        If ffxiv_proc_hdl <> IntPtr.Zero Then CloseHandle(ffxiv_proc_hdl)
    End Sub
End Class
