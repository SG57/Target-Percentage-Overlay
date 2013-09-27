Public Class Find



	Public find_0 As Boolean = True
	Private rect As Rectangle = New Rectangle(0, 0, 1, 1)



	' update form background color to the pixel color just beneath the mouse cursor
	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		rect.X = Windows.Forms.Cursor.Position.X
		rect.Y = Windows.Forms.Cursor.Position.Y

		Dim hover As Bitmap = Overlay.CaptureArea(rect)
		Dim c As Color = hover.GetPixel(0, 0)

		hover.Dispose()

		Me.BackColor = Color.FromArgb(c.R, c.G, c.B)
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
End Class