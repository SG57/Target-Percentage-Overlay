Public Class Settings

	' init from settings prefs
	Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		boxRefreshTimer.Text = My.Settings.refresh
		boxFfxivProcIndex.Text = My.Settings.ffxiv_process
		comboBar.SelectedIndex = My.Settings.bar
	End Sub

	' save click
	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		My.Settings.refresh = boxRefreshTimer.Text
		Overlay.Timer1.Interval = boxRefreshTimer.Text

		My.Settings.ffxiv_process = boxFfxivProcIndex.Text ' force re-attach

		My.Settings.bar = comboBar.SelectedIndex

		' IMPORTANT
		Overlay.forceReattach()

		My.Settings.Save()
		Me.Close()
	End Sub
End Class