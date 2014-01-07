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
	' Memory offest indicies into the MEMORY_OFFSETS array:
	Const MEM_TARGET_HP = 0
	Const MEM_TARGET_HP_MAX = 1
	Const MEM_TARGET_MP = 2
	Const MEM_TARGET_MP_MAX = 3
	Const MEM_TARGET_TP = 4

	Dim MEMORY_OFFSETS As Int32()()() = {
	({({&H1071770, &H16A0}),
	({&H1071770, &H16A4}),
	({&H1071770, &H16A8}),
	({&H1071770, &H16AC}),
	({&H1071770, &H16B0})}),
 _
	({({&H10717B0, &H16A0}),
	({&H10717B0, &H16A4}),
	({&H10717B0, &H16A8}),
	({&H10717B0, &H16AC}),
	({&H10717B0, &H16B0})})}

	Public Function ReadInt32(ByVal addr As IntPtr) As Int32
		Dim _dataBytes(3) As Byte
		ReadProcessMemory(ffxiv_proc_hdl, addr, _dataBytes, 4, vbNull)
		Return BitConverter.ToInt32(_dataBytes, 0)
	End Function

	Public Function getMemoryAddress(ByVal index As Integer) As Int32
		Dim percent_addr As Int32 = ffxiv_proc.MainModule.BaseAddress

		For i = 0 To MEMORY_OFFSETS(My.Settings.target)(index).Length - 1
			percent_addr = IntPtr.Add(percent_addr, MEMORY_OFFSETS(My.Settings.target)(index)(i))
			If i < MEMORY_OFFSETS(My.Settings.target)(index).Length - 1 Then percent_addr = ReadInt32(percent_addr)
		Next

		'Console.Out.WriteLine(vbCrLf & "Base Address: " & ffxiv_proc.MainModule.BaseAddress.ToString("X") & vbCrLf & "Bar: " & My.Settings.bar & " --> Percent Address: " & percent_addr.ToString("X"))
		Return percent_addr
	End Function

	Public Function getOverlayText() As String
		Dim txt As String = ""

		Try
			Dim curr = 0
			Dim max = 0

			' get the numbers from memory needed
			If My.Settings.resource = Settings.RES_HP Then
				curr = ReadInt32(getMemoryAddress(MEM_TARGET_HP))
				max = ReadInt32(getMemoryAddress(MEM_TARGET_HP_MAX))
			ElseIf My.Settings.resource = Settings.RES_MP Then
				curr = ReadInt32(getMemoryAddress(MEM_TARGET_MP))
				max = ReadInt32(getMemoryAddress(MEM_TARGET_MP_MAX))
			ElseIf My.Settings.resource = Settings.RES_TP Then
				curr = ReadInt32(getMemoryAddress(MEM_TARGET_TP))
				max = 1000
			End If

			' format textually
			If max = 0 And curr = 0 Then
				txt = "--"
			Else
				If My.Settings.display = 0 Or My.Settings.display = 2 Then
					txt = curr.ToString("N0") & " / " & max.ToString("N0") & vbCrLf
				End If
				If My.Settings.display = 1 Or My.Settings.display = 2 Then
					txt = txt & (100.0 * curr / max).ToString("N1") & " %"
				End If
			End If

		Catch ex As Exception
			forceReattach()
			txt = FFXIV_NOT_RUNNING()
		End Try

		Return txt
	End Function



	' init
	Private Sub Overlay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MsgBox("An overlay that displays numerical values and percentages of various resources of targets in FFXIV:ARR as read from memory, making it instant and reliable." & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "________________________________________________" & vbCrLf & "~~Note: the overlay will not overlay in true-fullscreen mode.  If you have 2 monitors, however, you could always put the overlay on the other monitor." & vbCrLf & vbCrLf & "jordansg57@gmail.com - (C) 2013 Cord Rehn", MsgBoxStyle.Information, "Target Percentage Overlay v2.02")

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
			Me.lblOverlay.Text = getOverlayText()
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
		forceReattach()
	End Sub
End Class
