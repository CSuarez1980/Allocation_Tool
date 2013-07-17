<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clm_Resource_Type
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
        Me.grpResource = New System.Windows.Forms.GroupBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblID = New System.Windows.Forms.Label
        Me.grpResource.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpResource
        '
        Me.grpResource.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResource.Controls.Add(Me.txtDescription)
        Me.grpResource.Controls.Add(Me.txtID)
        Me.grpResource.Controls.Add(Me.lblDescription)
        Me.grpResource.Controls.Add(Me.lblID)
        Me.grpResource.Location = New System.Drawing.Point(4, 24)
        Me.grpResource.Name = "grpResource"
        Me.grpResource.Size = New System.Drawing.Size(350, 106)
        Me.grpResource.TabIndex = 3
        Me.grpResource.TabStop = False
        Me.grpResource.Text = "Resource information"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(82, 55)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(224, 20)
        Me.txtDescription.TabIndex = 7
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(82, 30)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(62, 20)
        Me.txtID.TabIndex = 6
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(18, 59)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Description"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(18, 34)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 4
        Me.lblID.Text = "ID"
        '
        'clm_Resource_Type
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(359, 155)
        Me.Controls.Add(Me.grpResource)
        Me.Name = "clm_Resource_Type"
        Me.Text = "Resource type"
        Me.Controls.SetChildIndex(Me.grpResource, 0)
        Me.grpResource.ResumeLayout(False)
        Me.grpResource.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpResource As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblID As System.Windows.Forms.Label

End Class
