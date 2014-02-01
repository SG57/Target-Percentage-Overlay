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

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boxRefreshTimer.Text = My.Settings.refresh_interval
        boxFfxivProcIndex.Text = My.Settings.ffxiv_process_index
        comboTarget.SelectedIndex = 0 + My.Settings.entity
        comboDisplay.SelectedIndex = 0 + My.Settings.display
        comboResource.SelectedIndex = 0 + My.Settings.resource
        boxTargetAddress.Text = "0x" & Conversion.Hex(My.Settings.target_pointer_address)
        boxFocusAddress.Text = "0x" & Conversion.Hex(My.Settings.focus_pointer_address)
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_button.Click
        My.Settings.refresh_interval = boxRefreshTimer.Text
        My.Settings.ffxiv_process_index = boxFfxivProcIndex.Text
        My.Settings.entity = CType(comboTarget.SelectedIndex, EntityType)
        My.Settings.display = CType(comboDisplay.SelectedIndex, DisplayType)
        My.Settings.resource = CType(comboResource.SelectedIndex, ResourceType)

        If boxTargetAddress.Text.Length = 0 Then boxTargetAddress.Text = "0"
        My.Settings.target_pointer_address = Convert.ToUInt32(boxTargetAddress.Text, 16)
        If My.Settings.target_pointer_address = 0 Then My.Settings.target_pointer_address = Memory.DEFAULT_PTR_TO_TARGET_ENTITY

        If boxFocusAddress.Text.Length = 0 Then boxFocusAddress.Text = "0"
        My.Settings.focus_pointer_address = Convert.ToUInt32(boxFocusAddress.Text, 16)
        If My.Settings.focus_pointer_address = 0 Then My.Settings.focus_pointer_address = Memory.DEFAULT_PTR_TO_FOCUS_ENTITY

        My.Settings.Save()
        Me.Close()
        Overlay.SettingsChanged()
    End Sub

    Private Function CheckIfUserWantsToResetPointers() As Boolean
        Dim result As MsgBoxResult =
            MsgBox("I see you are running a newer version of Target Percentage Overlay (v" & VERSION & ")." &
                   vbCrLf & vbCrLf &
                   "This could mean the Main Target and Focus Target memory addresses may needed fixing after a recent FFXIV patch." &
                   vbCrLf & vbCrLf &
                   "Would you like to update your current settings to the new memory addresses? (RECOMMENDED)" &
                   vbCrLf &
                   "If you're not sure, click yes.",
                   MsgBoxStyle.YesNo,
                   "Target Percentage Overlay Updated - Update Addresses?")
        Return result = MsgBoxResult.Yes
    End Function

    Public Sub OnStartup()
        ' detect if we are running a later version of TPO, meaning the main target and focus target pointers may have changed
        ' as they may have been broken prior, hence the update.  Ask the user if they'd like to overwrite their current addresses.
        ' if this is their first run (version_old = 0), don't ask for input, just store the default pointers.
        Dim reset_pointers As Boolean = False
        If My.Settings.version_old = 0 Then
            reset_pointers = True
        ElseIf My.Settings.version_old < VERSION AndAlso CheckIfUserWantsToResetPointers() Then
            reset_pointers = True
        End If
        If reset_pointers Then
            My.Settings.target_pointer_address = Memory.DEFAULT_PTR_TO_TARGET_ENTITY
            My.Settings.focus_pointer_address = Memory.DEFAULT_PTR_TO_FOCUS_ENTITY
        End If

        My.Settings.version_old = Settings.VERSION
        My.Settings.Save()
    End Sub
End Class