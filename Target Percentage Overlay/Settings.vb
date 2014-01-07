Public Class Settings

	Public Const TARGET_MAIN = 0
	Public Const TARGET_FOCUS = 1

	Public Const RES_HP = 0
	Public Const RES_MP = 1
	Public Const RES_TP = 2


	' init from settings prefs
	Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		boxRefreshTimer.Text = My.Settings.refresh
		boxFfxivProcIndex.Text = My.Settings.ffxiv_process
		comboTarget.SelectedIndex = My.Settings.target
		comboDisplay.SelectedIndex = My.Settings.display
		comboResource.SelectedIndex = My.Settings.resource
	End Sub

	' save click
	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		My.Settings.refresh = boxRefreshTimer.Text
		Overlay.Timer1.Interval = boxRefreshTimer.Text

		My.Settings.ffxiv_process = boxFfxivProcIndex.Text ' force re-attach

		My.Settings.target = comboTarget.SelectedIndex

		My.Settings.display = comboDisplay.SelectedIndex

		My.Settings.resource = comboResource.SelectedIndex

		' IMPORTANT
		Overlay.forceReattach()

		My.Settings.Save()
		Me.Close()
	End Sub
End Class