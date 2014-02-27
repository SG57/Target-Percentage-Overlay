<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Overlay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.context_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.context_menu_settings_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.context_menu_change_font_color_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.context_menu_change_font_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.context_menu_check_update_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.context_menu_about_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.context_menu_donate_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.context_menu_close_menu_item = New System.Windows.Forms.ToolStripMenuItem()
        Me.text_label = New System.Windows.Forms.Label()
        Me.font_dialog = New System.Windows.Forms.FontDialog()
        Me.refresh_timer = New System.Windows.Forms.Timer(Me.components)
        Me.close_timer = New System.Windows.Forms.Timer(Me.components)
        Me.context_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'context_menu
        '
        Me.context_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.context_menu_settings_menu_item, Me.ToolStripSeparator2, Me.context_menu_change_font_color_menu_item, Me.context_menu_change_font_menu_item, Me.ToolStripSeparator4, Me.context_menu_check_update_menu_item, Me.ToolStripSeparator3, Me.context_menu_about_menu_item, Me.context_menu_donate_menu_item, Me.ToolStripSeparator1, Me.context_menu_close_menu_item})
        Me.context_menu.Name = "ContextMenuStrip1"
        Me.context_menu.Size = New System.Drawing.Size(184, 204)
        '
        'context_menu_settings_menu_item
        '
        Me.context_menu_settings_menu_item.Name = "context_menu_settings_menu_item"
        Me.context_menu_settings_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_settings_menu_item.Text = "Settings..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(180, 6)
        '
        'context_menu_change_font_color_menu_item
        '
        Me.context_menu_change_font_color_menu_item.Name = "context_menu_change_font_color_menu_item"
        Me.context_menu_change_font_color_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_change_font_color_menu_item.Text = "Change Font Color..."
        '
        'context_menu_change_font_menu_item
        '
        Me.context_menu_change_font_menu_item.Name = "context_menu_change_font_menu_item"
        Me.context_menu_change_font_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_change_font_menu_item.Text = "Change Font..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(180, 6)
        '
        'context_menu_check_update_menu_item
        '
        Me.context_menu_check_update_menu_item.Name = "context_menu_check_update_menu_item"
        Me.context_menu_check_update_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_check_update_menu_item.Text = "Check for updates..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        '
        'context_menu_about_menu_item
        '
        Me.context_menu_about_menu_item.Name = "context_menu_about_menu_item"
        Me.context_menu_about_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_about_menu_item.Text = "About..."
        '
        'context_menu_donate_menu_item
        '
        Me.context_menu_donate_menu_item.Name = "context_menu_donate_menu_item"
        Me.context_menu_donate_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_donate_menu_item.Text = "Donate..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(180, 6)
        '
        'context_menu_close_menu_item
        '
        Me.context_menu_close_menu_item.Name = "context_menu_close_menu_item"
        Me.context_menu_close_menu_item.Size = New System.Drawing.Size(183, 22)
        Me.context_menu_close_menu_item.Text = "Close"
        '
        'text_label
        '
        Me.text_label.AutoSize = True
        Me.text_label.BackColor = System.Drawing.Color.Transparent
        Me.text_label.ContextMenuStrip = Me.context_menu
        Me.text_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.text_label.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text_label.ForeColor = System.Drawing.Color.White
        Me.text_label.Location = New System.Drawing.Point(0, 0)
        Me.text_label.Name = "text_label"
        Me.text_label.Size = New System.Drawing.Size(51, 42)
        Me.text_label.TabIndex = 1
        Me.text_label.Text = "..."
        Me.text_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'refresh_timer
        '
        Me.refresh_timer.Enabled = True
        Me.refresh_timer.Interval = 1
        '
        'close_timer
        '
        Me.close_timer.Interval = 1
        '
        'Overlay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(44, 41)
        Me.ContextMenuStrip = Me.context_menu
        Me.ControlBox = False
        Me.Controls.Add(Me.text_label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Overlay"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Overlay"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(1, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.context_menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents context_menu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents context_menu_change_font_color_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents text_label As System.Windows.Forms.Label
    Friend WithEvents context_menu_change_font_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents font_dialog As System.Windows.Forms.FontDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents context_menu_close_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents refresh_timer As System.Windows.Forms.Timer
    Friend WithEvents context_menu_settings_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents context_menu_donate_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents context_menu_about_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents context_menu_check_update_menu_item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents close_timer As System.Windows.Forms.Timer

End Class
