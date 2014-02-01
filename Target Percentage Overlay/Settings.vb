Public Class Settings
    ' NOTE: Just increment this for every new release. That is all.
    Public Const VERSION = 2.1

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
        boxRefreshTimer.Text = My.Settings.refresh_interval
        boxFfxivProcIndex.Text = My.Settings.ffxiv_process_index
        comboTarget.SelectedIndex = 0 + My.Settings.entity
        comboDisplay.SelectedIndex = 0 + My.Settings.display
        comboResource.SelectedIndex = 0 + My.Settings.resource
        boxTargetAddress.Text = "0x" & Conversion.Hex(My.Settings.target_pointer_address)
        boxFocusAddress.Text = "0x" & Conversion.Hex(My.Settings.focus_pointer_address)
    End Sub

    ' save click
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_button.Click
        My.Settings.refresh_interval = boxRefreshTimer.Text
        My.Settings.ffxiv_process_index = boxFfxivProcIndex.Text
        My.Settings.entity = CType(comboTarget.SelectedIndex, EntityType)
        My.Settings.display = CType(comboDisplay.SelectedIndex, DisplayType)
        My.Settings.resource = CType(comboResource.SelectedIndex, ResourceType)

        If boxTargetAddress.Text.Length = 0 Then boxTargetAddress.Text = "0"
        My.Settings.target_pointer_address = Convert.ToUInt32(boxTargetAddress.Text, 16)
        If My.Settings.target_pointer_address = 0 Then My.Settings.target_pointer_address = Memory.PTR_TO_TARGET_ENTITY ' default

        If boxFocusAddress.Text.Length = 0 Then boxFocusAddress.Text = "0"
        My.Settings.focus_pointer_address = Convert.ToUInt32(boxFocusAddress.Text, 16)
        If My.Settings.focus_pointer_address = 0 Then My.Settings.focus_pointer_address = Memory.PTR_TO_FOCUS_ENTITY ' default

        My.Settings.Save()
        Me.Close()
        Overlay.SettingsChanged()
    End Sub
End Class