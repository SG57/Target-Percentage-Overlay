Public Class Settings

    Public Enum EntityType
        TARGET = 0
        FOCUS = 1
    End Enum

    Public Enum ResourceType
        HP = 0
        MP = 1
        TP = 2
    End Enum

    Public Enum DisplayType
        VALUES = 0
        PERCENT = 1
        VALUES_AND_PERCENT = 2
    End Enum
	

    ' init from settings prefs
    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boxRefreshTimer.Text = My.Settings.refresh
        boxFfxivProcIndex.Text = My.Settings.ffxiv_process
        comboTarget.SelectedIndex = 0 + My.Settings.target
        comboDisplay.SelectedIndex = 0 + My.Settings.display
        comboResource.SelectedIndex = 0 + My.Settings.resource
    End Sub

    ' save click
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        My.Settings.refresh = boxRefreshTimer.Text
        My.Settings.ffxiv_process = boxFfxivProcIndex.Text
        My.Settings.target = CType(comboTarget.SelectedIndex, EntityType)
        My.Settings.display = CType(comboDisplay.SelectedIndex, DisplayType)
        My.Settings.resource = CType(comboResource.SelectedIndex, ResourceType)

        My.Settings.Save()
        Me.Close()

        Overlay.SettingsChanged()
    End Sub
End Class