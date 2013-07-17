<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profile
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
        Me.lblProfile = New System.Windows.Forms.Label
        Me.txtProfile = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtgForms = New System.Windows.Forms.DataGridView
        Me.tlbForms = New System.Windows.Forms.ToolStrip
        Me.cmdAddForm = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdRemoveForm = New System.Windows.Forms.ToolStripButton
        Me.Panel1.SuspendLayout()
        CType(Me.dtgForms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbForms.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProfile
        '
        Me.lblProfile.AutoSize = True
        Me.lblProfile.Location = New System.Drawing.Point(8, 36)
        Me.lblProfile.Name = "lblProfile"
        Me.lblProfile.Size = New System.Drawing.Size(65, 13)
        Me.lblProfile.TabIndex = 6
        Me.lblProfile.Text = "Profile name"
        '
        'txtProfile
        '
        Me.txtProfile.Location = New System.Drawing.Point(79, 33)
        Me.txtProfile.Name = "txtProfile"
        Me.txtProfile.Size = New System.Drawing.Size(168, 20)
        Me.txtProfile.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.tlbForms)
        Me.Panel1.Controls.Add(Me.dtgForms)
        Me.Panel1.Location = New System.Drawing.Point(0, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 234)
        Me.Panel1.TabIndex = 8
        '
        'dtgForms
        '
        Me.dtgForms.AllowUserToAddRows = False
        Me.dtgForms.AllowUserToDeleteRows = False
        Me.dtgForms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgForms.Location = New System.Drawing.Point(4, 28)
        Me.dtgForms.Name = "dtgForms"
        Me.dtgForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgForms.Size = New System.Drawing.Size(484, 203)
        Me.dtgForms.TabIndex = 3
        '
        'tlbForms
        '
        Me.tlbForms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAddForm, Me.ToolStripSeparator1, Me.cmdRemoveForm})
        Me.tlbForms.Location = New System.Drawing.Point(0, 0)
        Me.tlbForms.Name = "tlbForms"
        Me.tlbForms.Size = New System.Drawing.Size(491, 25)
        Me.tlbForms.TabIndex = 4
        Me.tlbForms.Text = "ToolStrip1"
        '
        'cmdAddForm
        '
        Me.cmdAddForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddForm.Enabled = False
        Me.cmdAddForm.Image = Global.Capability_Log.My.Resources.Resources.edit_add
        Me.cmdAddForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddForm.Name = "cmdAddForm"
        Me.cmdAddForm.Size = New System.Drawing.Size(23, 22)
        Me.cmdAddForm.Text = "ToolStripButton1"
        Me.cmdAddForm.ToolTipText = "Agregar form"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdRemoveForm
        '
        Me.cmdRemoveForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRemoveForm.Enabled = False
        Me.cmdRemoveForm.Image = Global.Capability_Log.My.Resources.Resources.view_remove
        Me.cmdRemoveForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRemoveForm.Name = "cmdRemoveForm"
        Me.cmdRemoveForm.Size = New System.Drawing.Size(23, 22)
        Me.cmdRemoveForm.Text = "ToolStripButton2"
        Me.cmdRemoveForm.ToolTipText = "Eliminar form"
        '
        'Profile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(491, 321)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblProfile)
        Me.Controls.Add(Me.txtProfile)
        Me.Message = ""
        Me.Name = "Profile"
        Me.Text = "Profile maintenace"
        Me.Controls.SetChildIndex(Me.txtProfile, 0)
        Me.Controls.SetChildIndex(Me.lblProfile, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgForms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbForms.ResumeLayout(False)
        Me.tlbForms.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProfile As System.Windows.Forms.Label
    Friend WithEvents txtProfile As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtgForms As System.Windows.Forms.DataGridView
    Friend WithEvents tlbForms As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdAddForm As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRemoveForm As System.Windows.Forms.ToolStripButton

End Class
