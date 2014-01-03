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
		Me.btnSave = New System.Windows.Forms.Button()
		Me.boxRefreshTimer = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.boxFfxivProcIndex = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.comboBar = New System.Windows.Forms.ComboBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnSave
		'
		Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.Location = New System.Drawing.Point(15, 137)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(315, 36)
		Me.btnSave.TabIndex = 3
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'boxRefreshTimer
		'
		Me.boxRefreshTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.boxRefreshTimer.Location = New System.Drawing.Point(224, 13)
		Me.boxRefreshTimer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.boxRefreshTimer.Name = "boxRefreshTimer"
		Me.boxRefreshTimer.Size = New System.Drawing.Size(102, 30)
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
		Me.Label5.Size = New System.Drawing.Size(190, 25)
		Me.Label5.TabIndex = 6
		Me.Label5.Text = "Refresh Timer (ms) :"
		Me.ToolTip1.SetToolTip(Me.Label5, "How often to update the health percentage reading in milliseconds.")
		'
		'ToolTip1
		'
		Me.ToolTip1.ToolTipTitle = "More Information"
		'
		'boxFfxivProcIndex
		'
		Me.boxFfxivProcIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.boxFfxivProcIndex.Location = New System.Drawing.Point(224, 52)
		Me.boxFfxivProcIndex.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.boxFfxivProcIndex.Name = "boxFfxivProcIndex"
		Me.boxFfxivProcIndex.Size = New System.Drawing.Size(102, 30)
		Me.boxFfxivProcIndex.TabIndex = 9
		Me.boxFfxivProcIndex.Text = "0"
		Me.boxFfxivProcIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.boxFfxivProcIndex.WordWrap = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(10, 54)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(209, 25)
		Me.Label1.TabIndex = 8
		Me.Label1.Text = "FFXIV Process Index :"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ToolTip1.SetToolTip(Me.Label1, "*ADVANCED*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The index (0-based) for which FFXIV process to use." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Only change th" & _
					"is if:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " - you run multiple FFXIV clients" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " - wish to have the overlay use anoth" & _
					"er 'ffxiv.exe' process")
		'
		'comboBar
		'
		Me.comboBar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.comboBar.FormattingEnabled = True
		Me.comboBar.Items.AddRange(New Object() {"Target", "Focus Target"})
		Me.comboBar.Location = New System.Drawing.Point(120, 90)
		Me.comboBar.Name = "comboBar"
		Me.comboBar.Size = New System.Drawing.Size(206, 33)
		Me.comboBar.TabIndex = 10
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(11, 93)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(53, 25)
		Me.Label2.TabIndex = 11
		Me.Label2.Text = "Bar :"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.ToolTip1.SetToolTip(Me.Label2, "Which bar to display the percentage for.")
		'
		'Settings
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.ClientSize = New System.Drawing.Size(345, 188)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.comboBar)
		Me.Controls.Add(Me.boxFfxivProcIndex)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.boxRefreshTimer)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.btnSave)
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
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents boxRefreshTimer As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents boxFfxivProcIndex As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents comboBar As System.Windows.Forms.ComboBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
