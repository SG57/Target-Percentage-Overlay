<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.boxRefreshTimer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.boxFfxivProcIndex = New System.Windows.Forms.TextBox()
        Me.comboTarget = New System.Windows.Forms.ComboBox()
        Me.comboDisplay = New System.Windows.Forms.ComboBox()
        Me.comboResource = New System.Windows.Forms.ComboBox()
        Me.boxTargetAddress = New System.Windows.Forms.TextBox()
        Me.boxFocusAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ok_button = New System.Windows.Forms.Button()
        Me.cancel_button = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'boxRefreshTimer
        '
        Me.boxRefreshTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxRefreshTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxRefreshTimer.Location = New System.Drawing.Point(230, 13)
        Me.boxRefreshTimer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxRefreshTimer.Name = "boxRefreshTimer"
        Me.boxRefreshTimer.Size = New System.Drawing.Size(102, 26)
        Me.boxRefreshTimer.TabIndex = 7
        Me.boxRefreshTimer.Text = "2000"
        Me.boxRefreshTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxRefreshTimer.WordWrap = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Refresh Timer (ms) :"
        Me.ToolTip1.SetToolTip(Me.Label5, "How often to update the health percentage reading in milliseconds.")
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "More Information"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "FFXIV Process Index :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label1, "*ADVANCED*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The index (0-based) for which FFXIV process to use." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Only change th" & _
                "is if:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " - you run multiple FFXIV clients" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " - wish to have the overlay use anoth" & _
                "er 'ffxiv.exe' process")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 93)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Target :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label2, "Which target to pull information from; main target or focus target.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 132)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Display :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label3, "What to display, either the percentage, Curr/Max ratio, or both.")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 171)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Resource :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label4, "What resource to draw the percentage from; HP, MP or TP")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 37)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 20)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Main Target :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label6, resources.GetString("Label6.ToolTip"))
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 76)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 20)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Focus Target :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
        '
        'boxFfxivProcIndex
        '
        Me.boxFfxivProcIndex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxFfxivProcIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxFfxivProcIndex.Location = New System.Drawing.Point(230, 52)
        Me.boxFfxivProcIndex.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxFfxivProcIndex.Name = "boxFfxivProcIndex"
        Me.boxFfxivProcIndex.Size = New System.Drawing.Size(102, 26)
        Me.boxFfxivProcIndex.TabIndex = 9
        Me.boxFfxivProcIndex.Text = "0"
        Me.boxFfxivProcIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxFfxivProcIndex.WordWrap = False
        '
        'comboTarget
        '
        Me.comboTarget.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboTarget.FormattingEnabled = True
        Me.comboTarget.Items.AddRange(New Object() {"Main Target", "Focus Target"})
        Me.comboTarget.Location = New System.Drawing.Point(126, 90)
        Me.comboTarget.Name = "comboTarget"
        Me.comboTarget.Size = New System.Drawing.Size(206, 28)
        Me.comboTarget.TabIndex = 10
        '
        'comboDisplay
        '
        Me.comboDisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboDisplay.FormattingEnabled = True
        Me.comboDisplay.Items.AddRange(New Object() {"Current / Max", "Percentage", "Both"})
        Me.comboDisplay.Location = New System.Drawing.Point(126, 129)
        Me.comboDisplay.Name = "comboDisplay"
        Me.comboDisplay.Size = New System.Drawing.Size(206, 28)
        Me.comboDisplay.TabIndex = 14
        '
        'comboResource
        '
        Me.comboResource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboResource.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboResource.FormattingEnabled = True
        Me.comboResource.Items.AddRange(New Object() {"Health", "Mana", "TP"})
        Me.comboResource.Location = New System.Drawing.Point(126, 168)
        Me.comboResource.Name = "comboResource"
        Me.comboResource.Size = New System.Drawing.Size(206, 28)
        Me.comboResource.TabIndex = 16
        '
        'boxTargetAddress
        '
        Me.boxTargetAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxTargetAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxTargetAddress.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxTargetAddress.Location = New System.Drawing.Point(162, 32)
        Me.boxTargetAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTargetAddress.Name = "boxTargetAddress"
        Me.boxTargetAddress.Size = New System.Drawing.Size(145, 26)
        Me.boxTargetAddress.TabIndex = 21
        Me.boxTargetAddress.Text = "0"
        Me.boxTargetAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxTargetAddress.WordWrap = False
        '
        'boxFocusAddress
        '
        Me.boxFocusAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxFocusAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxFocusAddress.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxFocusAddress.Location = New System.Drawing.Point(162, 71)
        Me.boxFocusAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxFocusAddress.Name = "boxFocusAddress"
        Me.boxFocusAddress.Size = New System.Drawing.Size(145, 26)
        Me.boxFocusAddress.TabIndex = 22
        Me.boxFocusAddress.Text = "0"
        Me.boxFocusAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxFocusAddress.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.boxFocusAddress)
        Me.GroupBox1.Controls.Add(Me.boxTargetAddress)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 108)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Memory Addresses"
        '
        'ok_button
        '
        Me.ok_button.Location = New System.Drawing.Point(126, 338)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.Size = New System.Drawing.Size(98, 35)
        Me.ok_button.TabIndex = 24
        Me.ok_button.Text = "OK"
        Me.ok_button.UseVisualStyleBackColor = True
        '
        'cancel_button
        '
        Me.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_button.Location = New System.Drawing.Point(230, 338)
        Me.cancel_button.Name = "cancel_button"
        Me.cancel_button.Size = New System.Drawing.Size(101, 35)
        Me.cancel_button.TabIndex = 25
        Me.cancel_button.Text = "Cancel"
        Me.cancel_button.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AcceptButton = Me.ok_button
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.cancel_button
        Me.ClientSize = New System.Drawing.Size(351, 391)
        Me.Controls.Add(Me.cancel_button)
        Me.Controls.Add(Me.ok_button)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.comboResource)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.comboDisplay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.comboTarget)
        Me.Controls.Add(Me.boxFfxivProcIndex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxRefreshTimer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.Padding = New System.Windows.Forms.Padding(15)
        Me.Text = "Target Percentage Overlay Settings"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxRefreshTimer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents boxFfxivProcIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboTarget As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comboDisplay As System.Windows.Forms.ComboBox
    Friend WithEvents comboResource As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents boxTargetAddress As System.Windows.Forms.TextBox
    Friend WithEvents boxFocusAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ok_button As System.Windows.Forms.Button
    Friend WithEvents cancel_button As System.Windows.Forms.Button
End Class
