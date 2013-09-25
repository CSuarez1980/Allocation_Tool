<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ci_New_Actual_Line
    Inherits Capability_Log.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpActual = New System.Windows.Forms.GroupBox
        Me.cboTask = New System.Windows.Forms.ComboBox
        Me.cboProject = New System.Windows.Forms.ComboBox
        Me.lblProject = New System.Windows.Forms.Label
        Me.lblTask = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.grpActual.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpActual
        '
        Me.grpActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActual.Controls.Add(Me.cboTask)
        Me.grpActual.Controls.Add(Me.cboProject)
        Me.grpActual.Controls.Add(Me.lblProject)
        Me.grpActual.Controls.Add(Me.lblTask)
        Me.grpActual.Location = New System.Drawing.Point(7, 34)
        Me.grpActual.Name = "grpActual"
        Me.grpActual.Size = New System.Drawing.Size(315, 107)
        Me.grpActual.TabIndex = 4
        Me.grpActual.TabStop = False
        Me.grpActual.Text = "Project and Task Information"
        '
        'cboTask
        '
        Me.cboTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTask.FormattingEnabled = True
        Me.cboTask.Location = New System.Drawing.Point(82, 56)
        Me.cboTask.Name = "cboTask"
        Me.cboTask.Size = New System.Drawing.Size(198, 21)
        Me.cboTask.TabIndex = 9
        '
        'cboProject
        '
        Me.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProject.FormattingEnabled = True
        Me.cboProject.Location = New System.Drawing.Point(82, 29)
        Me.cboProject.Name = "cboProject"
        Me.cboProject.Size = New System.Drawing.Size(198, 21)
        Me.cboProject.TabIndex = 8
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(16, 33)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(40, 13)
        Me.lblProject.TabIndex = 4
        Me.lblProject.Text = "Project"
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Location = New System.Drawing.Point(16, 60)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(31, 13)
        Me.lblTask.TabIndex = 3
        Me.lblTask.Text = "Task"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(328, 31)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Capability_Log.My.Resources.Resources.agt_action_success
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ci_New_Actual_Line
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(328, 166)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpActual)
        Me.MaximizeBox = False
        Me.Message = ""
        Me.MinimizeBox = False
        Me.Name = "ci_New_Actual_Line"
        Me.Text = "New Line"
        Me.Controls.SetChildIndex(Me.grpActual, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.grpActual.ResumeLayout(False)
        Me.grpActual.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpActual As System.Windows.Forms.GroupBox
    Friend WithEvents cboTask As System.Windows.Forms.ComboBox
    Friend WithEvents cboProject As System.Windows.Forms.ComboBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents lblTask As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
