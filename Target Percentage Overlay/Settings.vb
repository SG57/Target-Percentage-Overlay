Public Class Settings



	' init from settings prefs
	Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		box0_x.Text = My.Settings.x1
		box0_y.Text = My.Settings.y1
		box100_x.Text = My.Settings.x2
		boxRefreshTimer.Text = My.Settings.refresh
		boxHealthIntensity.Text = My.Settings.intensity
	End Sub



	' save click
	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		' basic boundary checks. don't care.
		If Integer.Parse(box0_x.Text) < 0 Or Integer.Parse(box100_x.Text) < 0 Or Integer.Parse(box0_y.Text) < 0 Then
			MsgBox("You must set valid coordinates!", MsgBoxStyle.Exclamation, "Grr...")
			Exit Sub
		End If

		My.Settings.x1 = box0_x.Text
		My.Settings.y1 = box0_y.Text
		My.Settings.x2 = box100_x.Text

		My.Settings.refresh = boxRefreshTimer.Text
		Overlay.Timer1.Interval = boxRefreshTimer.Text

		My.Settings.intensity = boxHealthIntensity.Text

		My.Settings.Save()

		Overlay.lblOverlay.Text = "Not Started"
		Me.Close()
	End Sub



	' find 0% loc btn click
	Private Sub btnFind0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind0.Click
		Find.Show()
		Find.find_0 = True
	End Sub



	' find 100% loc btn click
	Private Sub btnFind100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind100.Click
		Find.Show()
		Find.find_0 = False
	End Sub
End Class