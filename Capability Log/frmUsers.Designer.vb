<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.txtTNumber = New System.Windows.Forms.TextBox
        Me.lblTNumber = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dtgProfile = New System.Windows.Forms.DataGridView
        Me.tlbProfile = New System.Windows.Forms.ToolStrip
        Me.cmdAdd = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdRemove = New System.Windows.Forms.ToolStripButton
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtgProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(406, 261)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtName)
        Me.TabPage1.Controls.Add(Me.lblName)
        Me.TabPage1.Controls.Add(Me.txtTNumber)
        Me.TabPage1.Controls.Add(Me.lblTNumber)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(398, 235)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(81, 44)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(240, 20)
        Me.txtName.TabIndex = 10
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(18, 44)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 9
        Me.lblName.Text = "Name"
        '
        'txtTNumber
        '
        Me.txtTNumber.Location = New System.Drawing.Point(81, 18)
        Me.txtTNumber.Name = "txtTNumber"
        Me.txtTNumber.Size = New System.Drawing.Size(84, 20)
        Me.txtTNumber.TabIndex = 8
        '
        'lblTNumber
        '
        Me.lblTNumber.AutoSize = True
        Me.lblTNumber.Location = New System.Drawing.Point(18, 18)
        Me.lblTNumber.Name = "lblTNumber"
        Me.lblTNumber.Size = New System.Drawing.Size(51, 13)
        Me.lblTNumber.TabIndex = 7
        Me.lblTNumber.Text = "TNumber"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtgProfile)
        Me.TabPage2.Controls.Add(Me.tlbProfile)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(398, 235)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Profiles"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtgProfile
        '
        Me.dtgProfile.AllowUserToAddRows = False
        Me.dtgProfile.AllowUserToDeleteRows = False
        Me.dtgProfile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProfile.Location = New System.Drawing.Point(5, 31)
        Me.dtgProfile.Name = "dtgProfile"
        Me.dtgProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgProfile.Size = New System.Drawing.Size(389, 198)
        Me.dtgProfile.TabIndex = 3
        '
        'tlbProfile
        '
        Me.tlbProfile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAdd, Me.ToolStripSeparator1, Me.cmdRemove})
        Me.tlbProfile.Location = New System.Drawing.Point(3, 3)
        Me.tlbProfile.Name = "tlbProfile"
        Me.tlbProfile.Size = New System.Drawing.Size(392, 25)
        Me.tlbProfile.TabIndex = 2
        Me.tlbProfile.Text = "ToolStrip1"
        '
        'cmdAdd
        '
        Me.cmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.Image = Global.Capability_Log.My.Resources.Resources.edit_add
        Me.cmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(23, 22)
        Me.cmdAdd.Text = "ToolStripButton1"
        Me.cmdAdd.ToolTipText = "Add profile"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdRemove
        '
        Me.cmdRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRemove.Enabled = False
        Me.cmdRemove.Image = Global.Capability_Log.My.Resources.Resources.view_remove
        Me.cmdRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(23, 22)
        Me.cmdRemove.Text = "ToolStripButton2"
        Me.cmdRemove.ToolTipText = "Remove profile"
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(430, 314)
        Me.Controls.Add(Me.TabControl1)
        Me.Message = ""
        Me.Name = "frmUsers"
        Me.Text = "User maintenance"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dtgProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbProfile.ResumeLayout(False)
        Me.tlbProfile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtTNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblTNumber As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dtgProfile As System.Windows.Forms.DataGridView
    Friend WithEvents tlbProfile As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdRemove As System.Windows.Forms.ToolStripButton

End Class
