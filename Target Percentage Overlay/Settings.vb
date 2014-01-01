Public Class Settings

	' init from settings prefs
	Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		boxRefreshTimer.Text = My.Settings.refresh
	End Sub

	' save click
	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		My.Settings.refresh = boxRefreshTimer.Text
		Overlay.Timer1.Interval = boxRefreshTimer.Text

        My.Settings.Save()

		Me.Close()
	End Sub
End Class