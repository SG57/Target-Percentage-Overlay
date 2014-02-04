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

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok_button.Click
        Dim ffxiv_process_index As UInteger
        Dim refresh_interval As UInteger

        If Not UInteger.TryParse(boxFfxivProcIndex.Text, ffxiv_process_index) Then
            MsgBox("Process index should be a positive whole number", MsgBoxStyle.OkOnly, "Invalid process index")
            Return
        End If
        If Not UInteger.TryParse(boxRefreshTimer.Text, refresh_interval) Then
            MsgBox("Refresh interval should be a positive whole number", MsgBoxStyle.OkOnly, "Invalid refresh interval")
            Return
        End If

        Dim target_pointer_address As UInt32 = Convert.ToUInt32(boxTargetAddress.Text, 16)
        Dim focus_pointer_address As UInt32 = Convert.ToUInt32(boxFocusAddress.Text, 16)

        If target_pointer_address = 0 Then target_pointer_address = Memory.DEFAULT_PTR_TO_TARGET_ENTITY
        If focus_pointer_address = 0 Then focus_pointer_address = Memory.DEFAULT_PTR_TO_FOCUS_ENTITY

        My.Settings.ffxiv_process_index = ffxiv_process_index
        My.Settings.refresh_interval = refresh_interval
        My.Settings.entity = CType(comboTarget.SelectedIndex, EntityType)
        My.Settings.display = CType(comboDisplay.SelectedIndex, DisplayType)
        My.Settings.resource = CType(comboResource.SelectedIndex, ResourceType)
        My.Settings.target_pointer_address = target_pointer_address
        My.Settings.focus_pointer_address = focus_pointer_address

        My.Settings.Save()
        Me.Close()
        Overlay.SettingsChanged()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_button.Click
        Me.Close()
    End Sub

    Private Function CheckIfUserWantsToResetPointers() As Boolean
        Dim result As MsgBoxResult =
            MsgBox("I see you are running a newer version of Target Percentage Overlay (v" & Settings.VERSION.ToString("0.##") & ")." &
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