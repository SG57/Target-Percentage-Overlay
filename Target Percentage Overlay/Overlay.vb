Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class Overlay



	' init
	Private Sub Overlay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		MsgBox("A simple overlay that displays the percentage of a static, fill-able bar." & vbCrLf & vbCrLf & "~~Note: the overlay will not overlay properly on a fullscreen application.  If you have 2 monitors, however, you could always put the overlay on the other monitor." & vbCrLf & vbCrLf & "jordansg57@gmail.com - (C) 2013 Cord Rehn", MsgBoxStyle.Information, "Target Percentage Overlay v1.0")

		Me.Left = My.Settings.win_x
		Me.Top = My.Settings.win_y

		Me.Timer1.Interval = My.Settings.refresh

		Me.lblOverlay.Font = My.Settings.font
		Me.lblOverlay.ForeColor = My.Settings.font_color

		If My.Settings.x1 = -1 Then
			Me.lblOverlay.Text = "Setup Required"
		Else
			Me.lblOverlay.Text = "Not Started"
		End If
	End Sub



	' This all handles click-drag functionality of the overlay
	Dim drag As Boolean
	Dim mousex As Integer
	Dim mousey As Integer

	Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblOverlay.MouseDown
		drag = True	'Sets the variable drag to true.
		mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
		mousey = Windows.Forms.Cursor.Position.Y - Me.Top	'Sets variable mousey
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



	' start/stop menu option
	Private Sub menuItemStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItemStartStop.Click
		If menuItemStartStop.Text = "Start" Then
			If My.Settings.x1 < 0 Or My.Settings.x2 < 0 Or My.Settings.y1 < 0 Then	' first run / invalid stuff
				MsgBox("You must first specify the health bar dimensions.", MsgBoxStyle.Exclamation, "Da fauk... thas poolsheet!!")
				Settings.Show()
			Else
				startRunning()
			End If
		Else
			stopRunning()
		End If
	End Sub

	Private Sub startRunning()
		calcDimensions()

		Me.Timer1.Start()
		menuItemStartStop.Text = "Stop"
		lblOverlay.Text = "--%"
	End Sub

	Private Sub stopRunning()
		Me.Timer1.Stop()
		menuItemStartStop.Text = "Start"
		lblOverlay.Text = "Not Started"
	End Sub



	' this figures out how much percentage of the bar is filled and updates the overlay accordingly
	Private line_bmp As Bitmap
	Private bar_width As Integer
	Private color_intensity As Byte
	Private bar_rect As Rectangle

	Private Sub calcDimensions()
		color_intensity = My.Settings.intensity
		bar_width = My.Settings.x2 - My.Settings.x1
		bar_rect = New Rectangle(0, 0, bar_width, 1)

		If Not IsNothing(line_bmp) Then line_bmp.Dispose()

		line_bmp = New Bitmap(bar_width, 1, Imaging.PixelFormat.Format24bppRgb)	' no alpha
	End Sub

	' given bitmap data of a bar, will return the percentage filled the bar is
	Private Function binarySearchFilledPercentage(ByRef bmd As BitmapData) As Integer
		Dim low As Integer = 0
		Dim high As Integer = bmd.Width - 1
		Dim x As Integer

		Do While low < high
			x = (low + high) / 2

			Dim offset As Integer = x * 3	' 24 bpp pixel / 8-bits per byte = 3 byte intervals
			Dim red As Byte = Marshal.ReadByte(bmd.Scan0, offset + 2)
			Dim green As Byte = Marshal.ReadByte(bmd.Scan0, offset + 1)
			Dim blue As Byte = Marshal.ReadByte(bmd.Scan0, offset)

			If red < color_intensity And green < color_intensity And blue < color_intensity Then	' possibly do 3 color intensities instead, one for each channel
				high = x - 1
			Else
				low = x + 1
			End If
		Loop

		Return Math.Round(low / (bar_width - 1) * 100)
	End Function

	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		CaptureArea(line_bmp, My.Settings.x1, My.Settings.y1)

		' get bitmap's underlying data
		Dim bmd As BitmapData = line_bmp.LockBits(bar_rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, line_bmp.PixelFormat)

		Me.lblOverlay.Text = binarySearchFilledPercentage(bmd)

		line_bmp.UnlockBits(bmd)

		If Me.lblOverlay.Text = "0" Then Me.lblOverlay.Text = "--"

		Me.lblOverlay.Text += "%"
	End Sub



	' Settings menu option
	Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
		stopRunning()
		Settings.Show()
	End Sub



	' How to use it
	Private Sub ToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
		MsgBox("1. Drag the text overlay wherever you want." & vbCrLf & "2. Right-click the overlay -> Settings" & vbCrLf & "3. Click the 'Find' button next to the 0% location fields." & vbCrLf & "4. Roughly, hover over the pixel that marks 0% of the bar filled and press any key.  Triple-check the color of the pop-up dialog matches the bar to make sure you're over the bar!!" & vbCrLf & "5. Repeat step 4, but for the pixel that marks the 100% filled bar." & vbCrLf & vbCrLf & "That's it!  Save, and Right-click -> Start the overlay." & vbCrLf & vbCrLf & "If you're experiencing some glitchiness, go back and tweak the coordinates slightly and the color intensity parameter." & vbCrLf & vbCrLf & "jordansg57@gmail.com - (C) 2013 Cord Rehn", MsgBoxStyle.Information, "How To Use It")
	End Sub



	' donate button
	Private Sub ToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click
		System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=JordanSg57%40gmail%2ecom&lc=US&item_name=Freelance%20Developer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")
	End Sub



	' required modules for screen capture
	Private Declare Auto Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean
	Private Declare Auto Function GetDC Lib "user32.dll" (ByVal hWnd As IntPtr) As IntPtr
	Private Declare Auto Function ReleaseDC Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As IntPtr

	' fill 'line_bmp' with 'area' of the screen.  expects line_bmp to be setup prior. Needs manual disposal once finished with!
	Public Sub CaptureArea(ByRef bmp As Bitmap, ByRef x As Integer, ByRef y As Integer)
		Using g As Graphics = Graphics.FromImage(bmp)
			Dim srcDC As IntPtr = GetDC(IntPtr.Zero)
			Dim destDC As IntPtr = g.GetHdc()

			BitBlt(destDC, 0, 0, bmp.Width, bmp.Height, srcDC, x, y, 13369376) 'SRCCOPY = 13369376

			g.ReleaseHdc(destDC)
			ReleaseDC(IntPtr.Zero, srcDC)
		End Using
	End Sub



	' on closing
	Private Sub onClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
		line_bmp.Dispose()
	End Sub
End Class
