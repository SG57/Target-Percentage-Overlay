Public Class Settings
    ' NOTE: Just increment this for every new release. That is all.
    Public Const VERSION = 2.2

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

        My.Settings.ffxiv_process_index = ffxiv_process_index
        My.Settings.refresh_interval = refresh_interval
        My.Settings.entity = CType(comboTarget.SelectedIndex, EntityType)
        My.Settings.display = CType(comboDisplay.SelectedIndex, DisplayType)
        My.Settings.resource = CType(comboResource.SelectedIndex, ResourceType)

        My.Settings.Save()
        Me.Close()
        Overlay.SettingsChanged()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel_button.Click
        Me.Close()
    End Sub

    Public Sub OnStartup()
        My.Settings.Save()
    End Sub
End Class