Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Net

Public Class Overlay

    ' these are static (that is, they will never change)
    Const TPO_URL = "https://dl.dropboxusercontent.com/u/47118386/TPO.zip" ' contains the latest TPO archive
    Const TPO_LATEST_URL = "https://dl.dropboxusercontent.com/u/47118386/TPO_latest.txt" ' contains the latest TPO version and update information


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
                    current = memory.GetValue(My.Settings.entity, memory.EntityValueType.TP)
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

        CheckForUpdate(False) ' check for update, but don't be verbose with the results (false) so as not to annoy the user
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
               "This overlay will _not_ overlay in true-fullscreen mode!" &
               vbCrLf &
               "You could always put the overlay on another monitor if you're running a multiple monitor setup." &
               vbCrLf & vbCrLf & vbCrLf & vbCrLf &
               "(C) 2013-2014" &
               vbCrLf &
               "Cord Rehn - <jordansg57@gmail.com" &
               vbCrLf &
               "Dana Jansens - <danakj@orodu.net>",
               MsgBoxStyle.Information,
               "Target Percentage Overlay v" & My.Settings.VERSION)
    End Sub

    Private Sub CheckForUpdateMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles context_menu_check_update_menu_item.Click
        CheckForUpdate(True) ' explicitly checking if we're up to date, so we can be verbose
    End Sub

    Private Sub CheckForUpdate(ByVal verbose As Boolean)
        Try
            ' download TPO_latest.txt from dropbox URL, the contents of which are: version number (ie, 2.3) {NEWLINE} patch notes
            Dim TPO_latest() As String = New WebClient().DownloadString(TPO_LATEST_URL).Split(New String() {Environment.NewLine}, 2, StringSplitOptions.None)
            Dim TPO_latest_version As String = TPO_latest(0)

            ' If the current version doesn't match the latest, we can infer there is an update available
            If Not My.Settings.VERSION.Equals(TPO_latest_version) Then
                Dim TPO_latest_info As String = TPO_latest(1)

                If MsgBox("There is an update available for Target Percentage Overlay:" &
                       vbCrLf & vbCrLf &
                       "[" & My.Settings.VERSION & "] ---> [" & TPO_latest_version & "]" &
                       vbCrLf &
                       TPO_latest_info &
                       vbCrLf & vbCrLf &
                       "Would you like to download the update?", MsgBoxStyle.YesNo, "Target Percentage Overlay Update") = MsgBoxResult.Yes Then

                    ' ask where to save the archive containing the latest TPO
                    Dim saveFileDialog As New SaveFileDialog()
                    saveFileDialog.Filter = "ZIP File|*.zip"
                    saveFileDialog.Title = "Choose where to save the archive containing Target Percentage Overlay v" & My.Settings.VERSION & "..."
                    saveFileDialog.FileName = "Target Percentage Overlay v" & My.Settings.VERSION & ".zip"

                    If saveFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then ' else if they cancelled, just silently cancel, obviously they didn't want to download the update
                        Try
                            My.Computer.Network.DownloadFile(TPO_URL, saveFileDialog.FileName, "", "", True, 1000, True)
                            Process.Start(saveFileDialog.FileName) ' open the zip
                            Me.close_timer.Enabled = True ' we cannot use Me.Close() in the form's load() method or we get an exception, so we tell a timer to do it right after this
                        Catch ex As TimeoutException
                            MsgBox("Timed out attempting to download the latest update." &
                           vbCrLf & vbCrLf &
                           "Make sure you have internet connection and try again.", MsgBoxStyle.Critical, "Timed Out")
                        End Try
                    End If
                End If
            Else
                If verbose Then
                    MsgBox("Target Percentage Overlay is up to date at v" & My.Settings.VERSION, MsgBoxStyle.Information, "Up To Date")
                End If
            End If

        Catch ex As WebException
            If verbose Then
                MsgBox("Timed out attempting to reach the update server." &
                       vbCrLf & vbCrLf &
                       "Make sure you have an internet connection and try again.", MsgBoxStyle.Critical, "Timed Out")
            End If
        End Try
    End Sub

    Private Sub close_timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_timer.Tick
        Me.Close()
    End Sub
End Class
