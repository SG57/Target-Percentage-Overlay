Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class Overlay
	Private Function FFXIV_NOT_RUNNING() As String
		Return "FFXIV.exe #" & My.Settings.ffxiv_process & " Not Running..."
	End Function



	' Handles the process handle grabbing shit
	Private Declare Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAcess As UInt32, ByVal bInheritHandle As Boolean, ByVal dwProcessId As Int32) As IntPtr
	Private Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
	Private Declare Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean

	Private Const FFXIV_PROCESS As String = "ffxiv"
	Private Const PROCESS_VM_READ As UInteger = 16
	Private Const PROCESS_QUERY_INFORMATION As UInteger = 1024
	Private ffxiv_proc As Process
	Private ffxiv_proc_hdl As IntPtr = IntPtr.Zero

	Public Sub forceReattach()
		If ffxiv_proc_hdl <> IntPtr.Zero Then Overlay.CloseHandle(ffxiv_proc_hdl)
		ffxiv_proc_hdl = IntPtr.Zero
	End Sub

	Private Function attachToProcess() As Boolean
		If ffxiv_proc_hdl <> IntPtr.Zero Then Return True ' attached already

		Try
			Dim procs As Process() = Process.GetProcessesByName(FFXIV_PROCESS)
			If procs.Length > 0 Then
				If Not IsNothing(procs(My.Settings.ffxiv_process)) Then
					Me.lblOverlay.Text = "Attaching to FFXIV.exe #" & My.Settings.ffxiv_process & "..."

					ffxiv_proc = procs(My.Settings.ffxiv_process)
					ffxiv_proc_hdl = OpenProcess(PROCESS_VM_READ Or PROCESS_QUERY_INFORMATION, False, ffxiv_proc.Id)

					calcPercentAddress()
				End If
			End If
		Catch ex As Exception
			Console.Out.WriteLine(ex.StackTrace & vbCrLf)

			forceReattach()
		End Try

		Return ffxiv_proc_hdl <> IntPtr.Zero
	End Function



	' Magic that will handle getting the percentage of the current focus target in ffxiv's memory
	'
	' ADD/TWEAK THE FOLLOWING MEMORY ADDRESSES AND OFFSETS SHOULD ANYTHING BREAK WITH FUTURE PATCHES!
	'
	' Bars:
	' 1: Target
	' 2: Focus Target
	Dim percent_addr As Int32
	Dim MEMORY_OFFSETS As Int32()() = {({&H1073A10, &H20, &H10, &H14, &H20, &H64}),
	 ({&H1073A10, &H20, &HC, &H24, &H20, &H190})}

	Public Function ReadInt32(ByVal addr As IntPtr) As Int32
		Dim _dataBytes(3) As Byte
		ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
		Return BitConverter.ToInt32(_dataBytes, 0)
	End Function

	Public Sub calcPercentAddress()	' one-time calculation of the offset into ffxiv's base address to read the percentage
		If ffxiv_proc_hdl <> IntPtr.Zero Then
			percent_addr = ffxiv_proc.MainModule.BaseAddress

			For i = 0 To MEMORY_OFFSETS(My.Settings.bar).Length - 1
				percent_addr = IntPtr.Add(percent_addr, MEMORY_OFFSETS(My.Settings.bar)(i))
				If i < MEMORY_OFFSETS(My.Settings.bar).Length - 1 Then percent_addr = ReadInt32(percent_addr)
			Next

			Console.Out.WriteLine(vbCrLf & "Base Address: " & ffxiv_proc.MainModule.BaseAddress.ToString("X") & vbCrLf & "Bar: " & My.Settings.bar & " --> Percent Address: " & percent_addr.ToString("X"))
		End If
	End Sub

	Public Function getCurrentPercentage() As Int32
		Try
			Return ReadInt32(percent_addr)
		Catch ex As Exception
			If ffxiv_proc_hdl <> IntPtr.Zero Then CloseHandle(ffxiv_proc_hdl)
			ffxiv_proc_hdl = IntPtr.Zero
			Return -1
		End Try
	End Function



	' init
	Private Sub Overlay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MsgBox("An overlay that displays the percentage 'health' of specific bars in FFXIV:ARR from memory, as such it is instant and reliable." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "________________________________________________" & vbCrLf & "~~Note: the overlay will not overlay in true-fullscreen mode.  If you have 2 monitors, however, you could always put the overlay on the other monitor." & vbCrLf & vbCrLf & "jordansg57@gmail.com - (C) 2013 Cord Rehn", MsgBoxStyle.Information, "Target Percentage Overlay v2.0")

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
		drag = True	'Sets the variable drag to true.
		mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
		mousey = Windows.Forms.Cursor.Position.Y - Me.Top		'Sets variable mousey
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



	' timer loop
	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		If Not attachToProcess() Then
			Me.lblOverlay.Text = FFXIV_NOT_RUNNING()

		Else ' attached to ffxiv process, read memory for percentage
			Me.lblOverlay.Text = getCurrentPercentage() & "%"
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
