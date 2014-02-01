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
        Me.save_button = New System.Windows.Forms.Button()
        Me.boxRefreshTimer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.boxFfxivProcIndex = New System.Windows.Forms.TextBox()
        Me.comboTarget = New System.Windows.Forms.ComboBox()
        Me.comboDisplay = New System.Windows.Forms.ComboBox()
        Me.comboResource = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.boxTargetAddress = New System.Windows.Forms.TextBox()
        Me.boxFocusAddress = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'save_button
        '
        Me.save_button.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.save_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.save_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.save_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_button.Location = New System.Drawing.Point(15, 341)
        Me.save_button.Name = "save_button"
        Me.save_button.Size = New System.Drawing.Size(315, 36)
        Me.save_button.TabIndex = 3
        Me.save_button.Text = "Save"
        Me.save_button.UseVisualStyleBackColor = True
        '
        'boxRefreshTimer
        '
        Me.boxRefreshTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxRefreshTimer.Location = New System.Drawing.Point(224, 13)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 273)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Target (in hex) :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label8, "The address of the pointer pointing to your target's information.")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 304)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Focus (in hex) :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label9, "The address of the pointer pointing to your focus target's information.")
        '
        'boxFfxivProcIndex
        '
        Me.boxFfxivProcIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxFfxivProcIndex.Location = New System.Drawing.Point(224, 52)
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
        Me.comboTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboTarget.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboTarget.FormattingEnabled = True
        Me.comboTarget.Items.AddRange(New Object() {"Main Target", "Focus Target"})
        Me.comboTarget.Location = New System.Drawing.Point(120, 90)
        Me.comboTarget.Name = "comboTarget"
        Me.comboTarget.Size = New System.Drawing.Size(206, 28)
        Me.comboTarget.TabIndex = 10
        '
        'comboDisplay
        '
        Me.comboDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboDisplay.FormattingEnabled = True
        Me.comboDisplay.Items.AddRange(New Object() {"Current / Max", "Percentage", "Both"})
        Me.comboDisplay.Location = New System.Drawing.Point(120, 129)
        Me.comboDisplay.Name = "comboDisplay"
        Me.comboDisplay.Size = New System.Drawing.Size(206, 28)
        Me.comboDisplay.TabIndex = 14
        '
        'comboResource
        '
        Me.comboResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboResource.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comboResource.FormattingEnabled = True
        Me.comboResource.Items.AddRange(New Object() {"Health", "Mana", "TP"})
        Me.comboResource.Location = New System.Drawing.Point(120, 168)
        Me.comboResource.Name = "comboResource"
        Me.comboResource.Size = New System.Drawing.Size(206, 28)
        Me.comboResource.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Memory Addresses"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 237)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(249, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "(Leave these as 0 to use defaults)"
        '
        'boxTargetAddress
        '
        Me.boxTargetAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxTargetAddress.Location = New System.Drawing.Point(224, 267)
        Me.boxTargetAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxTargetAddress.Name = "boxTargetAddress"
        Me.boxTargetAddress.Size = New System.Drawing.Size(102, 26)
        Me.boxTargetAddress.TabIndex = 21
        Me.boxTargetAddress.Text = "0"
        Me.boxTargetAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxTargetAddress.WordWrap = False
        '
        'boxFocusAddress
        '
        Me.boxFocusAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxFocusAddress.Location = New System.Drawing.Point(224, 298)
        Me.boxFocusAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.boxFocusAddress.Name = "boxFocusAddress"
        Me.boxFocusAddress.Size = New System.Drawing.Size(102, 26)
        Me.boxFocusAddress.TabIndex = 22
        Me.boxFocusAddress.Text = "0"
        Me.boxFocusAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.boxFocusAddress.WordWrap = False
        '
        'Settings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(345, 392)
        Me.Controls.Add(Me.boxFocusAddress)
        Me.Controls.Add(Me.boxTargetAddress)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.comboResource)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.comboDisplay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.comboTarget)
        Me.Controls.Add(Me.boxFfxivProcIndex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxRefreshTimer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.save_button)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents save_button As System.Windows.Forms.Button
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents boxTargetAddress As System.Windows.Forms.TextBox
    Friend WithEvents boxFocusAddress As System.Windows.Forms.TextBox
End Class
