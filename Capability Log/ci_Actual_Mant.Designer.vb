<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ci_Actual_Mant
    Inherits Capability_Log.frmMant

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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.cboTask = New System.Windows.Forms.ComboBox
        Me.cboProject = New System.Windows.Forms.ComboBox
        Me.lblProject = New System.Windows.Forms.Label
        Me.lblTask = New System.Windows.Forms.Label
        Me.lblActual_Date = New System.Windows.Forms.Label
        Me.grpActual.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpActual
        '
        Me.grpActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActual.Controls.Add(Me.DateTimePicker1)
        Me.grpActual.Controls.Add(Me.cboTask)
        Me.grpActual.Controls.Add(Me.cboProject)
        Me.grpActual.Controls.Add(Me.lblProject)
        Me.grpActual.Controls.Add(Me.lblTask)
        Me.grpActual.Controls.Add(Me.lblActual_Date)
        Me.grpActual.Location = New System.Drawing.Point(0, 28)
        Me.grpActual.Name = "grpActual"
        Me.grpActual.Size = New System.Drawing.Size(357, 185)
        Me.grpActual.TabIndex = 3
        Me.grpActual.TabStop = False
        Me.grpActual.Text = "Actual Information"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(98, 33)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(110, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'cboTask
        '
        Me.cboTask.FormattingEnabled = True
        Me.cboTask.Location = New System.Drawing.Point(98, 86)
        Me.cboTask.Name = "cboTask"
        Me.cboTask.Size = New System.Drawing.Size(198, 21)
        Me.cboTask.TabIndex = 9
        '
        'cboProject
        '
        Me.cboProject.FormattingEnabled = True
        Me.cboProject.Location = New System.Drawing.Point(98, 59)
        Me.cboProject.Name = "cboProject"
        Me.cboProject.Size = New System.Drawing.Size(198, 21)
        Me.cboProject.TabIndex = 8
        '
        'lblProject
        '
        Me.lblProject.AutoSize = True
        Me.lblProject.Location = New System.Drawing.Point(32, 63)
        Me.lblProject.Name = "lblProject"
        Me.lblProject.Size = New System.Drawing.Size(40, 13)
        Me.lblProject.TabIndex = 4
        Me.lblProject.Text = "Project"
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Location = New System.Drawing.Point(32, 90)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(31, 13)
        Me.lblTask.TabIndex = 3
        Me.lblTask.Text = "Task"
        '
        'lblActual_Date
        '
        Me.lblActual_Date.AutoSize = True
        Me.lblActual_Date.Location = New System.Drawing.Point(32, 37)
        Me.lblActual_Date.Name = "lblActual_Date"
        Me.lblActual_Date.Size = New System.Drawing.Size(61, 13)
        Me.lblActual_Date.TabIndex = 0
        Me.lblActual_Date.Text = "Actual date"
        '
        'ci_Actual_Mant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(369, 240)
        Me.Controls.Add(Me.grpActual)
        Me.Name = "ci_Actual_Mant"
        Me.Text = "New actual line"
        Me.Controls.SetChildIndex(Me.grpActual, 0)
        Me.grpActual.ResumeLayout(False)
        Me.grpActual.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpActual As System.Windows.Forms.GroupBox
    Friend WithEvents lblActual_Date As System.Windows.Forms.Label
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents lblTask As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTask As System.Windows.Forms.ComboBox
    Friend WithEvents cboProject As System.Windows.Forms.ComboBox

End Class
