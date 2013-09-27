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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.box0_y = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.box0_x = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.box100_y = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.box100_x = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.btnFind0 = New System.Windows.Forms.Button()
		Me.btnFind100 = New System.Windows.Forms.Button()
		Me.boxRefreshTimer = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.boxHealthIntensity = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.box0_y)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.box0_x)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
		Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.GroupBox1.Size = New System.Drawing.Size(356, 74)
		Me.GroupBox1.TabIndex = 1
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "0% Location"
		'
		'box0_y
		'
		Me.box0_y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.box0_y.Location = New System.Drawing.Point(238, 31)
		Me.box0_y.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.box0_y.Name = "box0_y"
		Me.box0_y.Size = New System.Drawing.Size(102, 30)
		Me.box0_y.TabIndex = 3
		Me.box0_y.Text = "0"
		Me.box0_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(202, 33)
		Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(36, 25)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Y :"
		'
		'box0_x
		'
		Me.box0_x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.box0_x.Location = New System.Drawing.Point(45, 29)
		Me.box0_x.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.box0_x.Name = "box0_x"
		Me.box0_x.Size = New System.Drawing.Size(102, 30)
		Me.box0_x.TabIndex = 1
		Me.box0_x.Text = "0"
		Me.box0_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.box0_x.WordWrap = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(9, 31)
		Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(37, 25)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "X :"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.box100_y)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.box100_x)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox2.Location = New System.Drawing.Point(18, 92)
		Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.GroupBox2.Size = New System.Drawing.Size(356, 72)
		Me.GroupBox2.TabIndex = 2
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "100% Location"
		'
		'box100_y
		'
		Me.box100_y.Enabled = False
		Me.box100_y.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.box100_y.ForeColor = System.Drawing.SystemColors.ControlDark
		Me.box100_y.Location = New System.Drawing.Point(238, 31)
		Me.box100_y.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.box100_y.Name = "box100_y"
		Me.box100_y.Size = New System.Drawing.Size(102, 30)
		Me.box100_y.TabIndex = 3
		Me.box100_y.Text = "Not yet..."
		Me.box100_y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(202, 33)
		Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(36, 25)
		Me.Label3.TabIndex = 2
		Me.Label3.Text = "Y :"
		'
		'box100_x
		'
		Me.box100_x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.box100_x.Location = New System.Drawing.Point(45, 29)
		Me.box100_x.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.box100_x.Name = "box100_x"
		Me.box100_x.Size = New System.Drawing.Size(102, 30)
		Me.box100_x.TabIndex = 1
		Me.box100_x.Text = "0"
		Me.box100_x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.box100_x.WordWrap = False
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.Location = New System.Drawing.Point(9, 31)
		Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(37, 25)
		Me.Label4.TabIndex = 0
		Me.Label4.Text = "X :"
		'
		'btnSave
		'
		Me.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.Location = New System.Drawing.Point(15, 242)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(431, 36)
		Me.btnSave.TabIndex = 3
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'btnFind0
		'
		Me.btnFind0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.btnFind0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.btnFind0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFind0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFind0.Location = New System.Drawing.Point(387, 40)
		Me.btnFind0.Name = "btnFind0"
		Me.btnFind0.Size = New System.Drawing.Size(61, 35)
		Me.btnFind0.TabIndex = 4
		Me.btnFind0.Text = "Find"
		Me.btnFind0.UseVisualStyleBackColor = True
		'
		'btnFind100
		'
		Me.btnFind100.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.btnFind100.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.btnFind100.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnFind100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFind100.Location = New System.Drawing.Point(387, 110)
		Me.btnFind100.Name = "btnFind100"
		Me.btnFind100.Size = New System.Drawing.Size(61, 35)
		Me.btnFind100.TabIndex = 5
		Me.btnFind100.Text = "Find"
		Me.btnFind100.UseVisualStyleBackColor = True
		'
		'boxRefreshTimer
		'
		Me.boxRefreshTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.boxRefreshTimer.Location = New System.Drawing.Point(216, 174)
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
		Me.Label5.Location = New System.Drawing.Point(27, 176)
		Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(190, 25)
		Me.Label5.TabIndex = 6
		Me.Label5.Text = "Refresh Timer (ms) :"
		Me.ToolTip1.SetToolTip(Me.Label5, "How often to update the health percentage reading in milliseconds." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lower the f" & _
					"aster it will update, but it will require more CPU.")
		'
		'boxHealthIntensity
		'
		Me.boxHealthIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.boxHealthIntensity.Location = New System.Drawing.Point(216, 204)
		Me.boxHealthIntensity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
		Me.boxHealthIntensity.Name = "boxHealthIntensity"
		Me.boxHealthIntensity.Size = New System.Drawing.Size(102, 30)
		Me.boxHealthIntensity.TabIndex = 9
		Me.boxHealthIntensity.Text = "0"
		Me.boxHealthIntensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.boxHealthIntensity.WordWrap = False
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(70, 204)
		Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(147, 25)
		Me.Label6.TabIndex = 8
		Me.Label6.Text = "Color Intensity :"
		Me.ToolTip1.SetToolTip(Me.Label6, resources.GetString("Label6.ToolTip"))
		'
		'ToolTip1
		'
		Me.ToolTip1.ToolTipTitle = "More Information"
		'
		'Settings
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.ClientSize = New System.Drawing.Size(461, 293)
		Me.Controls.Add(Me.boxHealthIntensity)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.boxRefreshTimer)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.btnFind100)
		Me.Controls.Add(Me.btnFind0)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
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
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents box0_x As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents box0_y As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents box100_y As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents box100_x As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnFind0 As System.Windows.Forms.Button
    Friend WithEvents btnFind100 As System.Windows.Forms.Button
    Friend WithEvents boxRefreshTimer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents boxHealthIntensity As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
