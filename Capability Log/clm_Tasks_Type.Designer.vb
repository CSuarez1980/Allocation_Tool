<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clm_Tasks_Type
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
        Me.grpTask = New System.Windows.Forms.GroupBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.grpTask.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTask
        '
        Me.grpTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTask.Controls.Add(Me.txtDescription)
        Me.grpTask.Controls.Add(Me.txtID)
        Me.grpTask.Controls.Add(Me.lblDescription)
        Me.grpTask.Controls.Add(Me.lblID)
        Me.grpTask.Location = New System.Drawing.Point(7, 28)
        Me.grpTask.Name = "grpTask"
        Me.grpTask.Size = New System.Drawing.Size(331, 104)
        Me.grpTask.TabIndex = 3
        Me.grpTask.TabStop = False
        Me.grpTask.Text = "Task information"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(75, 56)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(224, 20)
        Me.txtDescription.TabIndex = 3
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(75, 31)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(62, 20)
        Me.txtID.TabIndex = 2
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(11, 60)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Description"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(11, 35)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID"
        '
        'clm_Tasks_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(345, 161)
        Me.Controls.Add(Me.grpTask)
        Me.Name = "clm_Tasks_Type"
        Me.Text = "Task type"
        Me.Controls.SetChildIndex(Me.grpTask, 0)
        Me.grpTask.ResumeLayout(False)
        Me.grpTask.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpTask As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label

End Class
