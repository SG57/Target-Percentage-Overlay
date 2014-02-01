Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public Class Overlay
    Dim memory As Memory = New Memory

    ' These handle the click-drag functionality of the overlay.
    Dim drag_active As Boolean = False
    Dim drag_offset_x As Integer
    Dim drag_offset_y As Integer

    Private Function StringPercent(ByVal current As Integer, ByVal max As Integer) As String
        Return (100.0 * current / max).ToString("N1") & " %"
    End Function

    Private Function StringValues(ByVal current As Integer, ByVal max As Integer) As String
        Return current.ToString("N0") & " / " & max.ToString("N0")
    End Function

    Private Function GetOverlayText() As String
        Try
            If Not memory.AttachToProcess(My.Settings.ffxiv_process_index) Then
                Return "FFXIV.exe #" & My.Settings.ffxiv_process_index & " Not Running..."
            End If

            Dim current = 0
            Dim max = 0

            Select Case My.Settings.resource
                Case Settings.ResourceType.HP
                    current = memory.GetValue(My.Settings.entity, memory.EntityValueType.HP)
                    max = memory.GetValue(My.Settings.entity, memory.EntityValueType.HP_MAX)
                Case Settings.ResourceType.MP
                    current = memory.GetValue(My.Settings.entity, memory.EntityValueType.MP)
                    max = memory.GetValue(My.Settings.entity, memory.EntityValueType.MP_MAX)
                Case Settings.ResourceType.TP
                    current = memory.GetValue(My.Settings.entity, memory.EntityValueType.HP)
                    max = 1000
            End Select

            If max = 0 Then Return "--"

            Select Case My.Settings.display
                Case Settings.DisplayType.PERCENT
                    Return StringPercent(current, max)
                Case Settings.DisplayType.VALUES
                    Return StringValues(current, max)
                Case Settings.DisplayType.VALUES_AND_PERCENT
                    Return StringValues(current, max) & vbCrLf & StringPercent(current, max)
                Case Else
                    Return "--"
            End Select

        Catch ex As Exception
            memory.DetachFromProcess()
            Return "--"
        End Try
    End Function

    Private Sub RefreshText()
        text_label.Text = GetOverlayText()
    End Sub

    Public Sub SettingsChanged()
        refresh_timer.Interval = My.Settings.refresh_interval
        Left = My.Settings.win_x
        Top = My.Settings.win_y
        text_label.Font = My.Settings.font
        text_label.ForeColor = My.Settings.font_color
        RefreshText()
    End Sub

    ' init
    Private Sub Overlay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Settings.OnStartup()
        SettingsChanged()
    End Sub


    Private Sub TextLabel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles text_label.MouseDown
        drag_active = True
        drag_offset_x = Windows.Forms.Cursor.Position.X - Me.Left
        drag_offset_y = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub TextLabel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles text_label.MouseMove
        If Not drag_active Then Return
        My.Settings.win_x = Windows.Forms.Cursor.Position.X - drag_offset_x
        My.Settings.win_y = Windows.Forms.Cursor.Position.Y - drag_offset_y
        My.Settings.Save()
        SettingsChanged()
    End Sub

    Private Sub TextLabel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles text_label.MouseUp
        drag_active = False
    End Sub

    Private Sub ChangeFontColorMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_change_font_color_menu_item.Click
        Dim color_dialog As New ColorDialog()
        color_dialog.Color = Me.text_label.ForeColor

        If color_dialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

        My.Settings.font_color = color_dialog.Color
        My.Settings.Save()
        SettingsChanged()
    End Sub

    Private Sub ChangeFontMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_change_font_menu_item.Click
        font_dialog.Font = Me.text_label.Font

        If font_dialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

        My.Settings.font = font_dialog.Font
        My.Settings.Save()
        SettingsChanged()
    End Sub

    Private Sub CloseMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_close_menu_item.Click
        Close()
    End Sub

    Private Sub RefreshTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_timer.Tick
        RefreshText()
    End Sub

    Private Sub SettingsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_settings_menu_item.Click
        Settings.Show()
    End Sub

    Private Sub DonateMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_donate_menu_item.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=JordanSg57%40gmail%2ecom&lc=US&item_name=Freelance%20Developer&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted")
    End Sub

    Private Sub AboutMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_about_menu_item.Click
        MsgBox("An overlay that displays numerical values and percentages of various resources of targets in FFXIV:ARR as read from memory, making it instant and reliable." &
               vbCrLf & vbCrLf & vbCrLf & vbCrLf &
               "________________________________________________" &
               vbCrLf &
               "~~Note: the overlay will not overlay in true-fullscreen mode.  If you have 2 monitors, however, you could always put the overlay on the other monitor." &
               vbCrLf & vbCrLf &
               "jordansg57@gmail.com - (C) 2013 Cord Rehn" &
               vbCrLf &
               "danakj@orodu.net - (C) 2013 Dana Jansens",
               MsgBoxStyle.Information,
               "Target Percentage Overlay v" & Settings.VERSION.ToString("0.##"))
    End Sub
End Class
