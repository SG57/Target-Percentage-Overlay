Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Find



	Public find_0 As Boolean = True

	Private pixel_rect As Rectangle = New Rectangle(0, 0, 1, 1)
	Private pixel As Bitmap = New Bitmap(1, 1, Imaging.PixelFormat.Format24bppRgb)


	' update form background color to the pixel color just beneath the mouse cursor
	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

		Overlay.CaptureArea(pixel, Windows.Forms.Cursor.Position.X, Windows.Forms.Cursor.Position.Y)

		' get bitmap's underlying data
		Dim bmd As BitmapData = pixel.LockBits(pixel_rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, pixel.PixelFormat)

		Me.BackColor = Color.FromArgb(Marshal.ReadByte(bmd.Scan0, 2), _
									 Marshal.ReadByte(bmd.Scan0, 1), _
									 Marshal.ReadByte(bmd.Scan0, 0))

		pixel.UnlockBits(bmd)
	End Sub



	' on key press, fill the respective text boxes with the mouse coordinates
	Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If find_0 Then
			Settings.box0_x.Text = Windows.Forms.Cursor.Position.X
			Settings.box0_y.Text = Windows.Forms.Cursor.Position.Y
		Else
			Settings.box100_x.Text = Windows.Forms.Cursor.Position.X
		End If

		Me.Timer1.Stop()
		Me.Close()
	End Sub



	' on closing
	Private Sub onClose(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
		pixel.Dispose()
	End Sub
End Class