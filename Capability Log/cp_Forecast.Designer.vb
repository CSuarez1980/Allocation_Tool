<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cp_Forecast
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboProject_Type = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPSSPM = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtGBSPM = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtProjectName = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabResources = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdShowResources = New System.Windows.Forms.ToolStripButton
        Me.cmdDeleteResource = New System.Windows.Forms.ToolStripButton
        Me.dtgResources = New System.Windows.Forms.DataGridView
        Me.tabDocuments = New System.Windows.Forms.TabPage
        Me.dtgFiles = New System.Windows.Forms.DataGridView
        Me.tlbFiles = New System.Windows.Forms.ToolStrip
        Me.cmdUploadFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdDownloadFile = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdDeleteFile = New System.Windows.Forms.ToolStripButton
        Me.fodFile = New System.Windows.Forms.OpenFileDialog
        Me.sfdFile = New System.Windows.Forms.SaveFileDialog
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox7.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabResources.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDocuments.SuspendLayout()
        CType(Me.dtgFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.cboStatus)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.cboProject_Type)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.txtPSSPM)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.txtGBSPM)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.txtProjectName)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Location = New System.Drawing.Point(5, 28)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(887, 97)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Project"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(701, 42)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(180, 21)
        Me.cboStatus.TabIndex = 9
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(628, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Status"
        '
        'cboProject_Type
        '
        Me.cboProject_Type.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboProject_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProject_Type.Enabled = False
        Me.cboProject_Type.FormattingEnabled = True
        Me.cboProject_Type.Location = New System.Drawing.Point(701, 15)
        Me.cboProject_Type.Name = "cboProject_Type"
        Me.cboProject_Type.Size = New System.Drawing.Size(180, 21)
        Me.cboProject_Type.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(628, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Project Type"
        '
        'txtPSSPM
        '
        Me.txtPSSPM.Location = New System.Drawing.Point(131, 68)
        Me.txtPSSPM.Name = "txtPSSPM"
        Me.txtPSSPM.ReadOnly = True
        Me.txtPSSPM.Size = New System.Drawing.Size(176, 20)
        Me.txtPSSPM.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 71)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 13)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "PSS Delivery PM"
        '
        'txtGBSPM
        '
        Me.txtGBSPM.Location = New System.Drawing.Point(131, 43)
        Me.txtGBSPM.Name = "txtGBSPM"
        Me.txtGBSPM.ReadOnly = True
        Me.txtGBSPM.Size = New System.Drawing.Size(176, 20)
        Me.txtGBSPM.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "GBS Project manager"
        '
        'txtProjectName
        '
        Me.txtProjectName.Location = New System.Drawing.Point(93, 20)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.ReadOnly = True
        Me.txtProjectName.Size = New System.Drawing.Size(214, 20)
        Me.txtProjectName.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Project Name"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabResources)
        Me.TabControl1.Controls.Add(Me.tabDocuments)
        Me.TabControl1.Location = New System.Drawing.Point(5, 131)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(887, 432)
        Me.TabControl1.TabIndex = 12
        '
        'tabResources
        '
        Me.tabResources.Controls.Add(Me.GroupBox1)
        Me.tabResources.Location = New System.Drawing.Point(4, 22)
        Me.tabResources.Name = "tabResources"
        Me.tabResources.Padding = New System.Windows.Forms.Padding(3)
        Me.tabResources.Size = New System.Drawing.Size(879, 406)
        Me.tabResources.TabIndex = 0
        Me.tabResources.Text = "Resources"
        Me.tabResources.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Controls.Add(Me.dtgResources)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 394)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resources"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdShowResources, Me.cmdDeleteResource, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(861, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdShowResources
        '
        Me.cmdShowResources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdShowResources.Enabled = False
        Me.cmdShowResources.Image = Global.Capability_Log.My.Resources.Resources.agt_family
        Me.cmdShowResources.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdShowResources.Name = "cmdShowResources"
        Me.cmdShowResources.Size = New System.Drawing.Size(23, 22)
        Me.cmdShowResources.Text = "ToolStripButton1"
        Me.cmdShowResources.ToolTipText = "Show resources"
        '
        'cmdDeleteResource
        '
        Me.cmdDeleteResource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDeleteResource.Enabled = False
        Me.cmdDeleteResource.Image = Global.Capability_Log.My.Resources.Resources.delete_user
        Me.cmdDeleteResource.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDeleteResource.Name = "cmdDeleteResource"
        Me.cmdDeleteResource.Size = New System.Drawing.Size(23, 22)
        Me.cmdDeleteResource.Text = "ToolStripButton1"
        Me.cmdDeleteResource.ToolTipText = "Delete resource"
        '
        'dtgResources
        '
        Me.dtgResources.AllowUserToAddRows = False
        Me.dtgResources.AllowUserToDeleteRows = False
        Me.dtgResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgResources.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgResources.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgResources.Location = New System.Drawing.Point(6, 47)
        Me.dtgResources.Name = "dtgResources"
        Me.dtgResources.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgResources.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgResources.Size = New System.Drawing.Size(854, 341)
        Me.dtgResources.TabIndex = 7
        '
        'tabDocuments
        '
        Me.tabDocuments.Controls.Add(Me.dtgFiles)
        Me.tabDocuments.Controls.Add(Me.tlbFiles)
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDocuments.Size = New System.Drawing.Size(879, 406)
        Me.tabDocuments.TabIndex = 1
        Me.tabDocuments.Text = "Documents"
        Me.tabDocuments.UseVisualStyleBackColor = True
        '
        'dtgFiles
        '
        Me.dtgFiles.AllowUserToAddRows = False
        Me.dtgFiles.AllowUserToDeleteRows = False
        Me.dtgFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgFiles.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgFiles.Location = New System.Drawing.Point(7, 31)
        Me.dtgFiles.Name = "dtgFiles"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgFiles.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgFiles.Size = New System.Drawing.Size(866, 369)
        Me.dtgFiles.TabIndex = 3
        '
        'tlbFiles
        '
        Me.tlbFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdUploadFile, Me.ToolStripSeparator1, Me.cmdDownloadFile, Me.ToolStripSeparator2, Me.cmdDeleteFile})
        Me.tlbFiles.Location = New System.Drawing.Point(3, 3)
        Me.tlbFiles.Name = "tlbFiles"
        Me.tlbFiles.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tlbFiles.Size = New System.Drawing.Size(873, 25)
        Me.tlbFiles.TabIndex = 2
        Me.tlbFiles.Text = "ToolStrip2"
        '
        'cmdUploadFile
        '
        Me.cmdUploadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdUploadFile.Image = Global.Capability_Log.My.Resources.Resources.agt_uninstall_product
        Me.cmdUploadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdUploadFile.Name = "cmdUploadFile"
        Me.cmdUploadFile.Size = New System.Drawing.Size(23, 22)
        Me.cmdUploadFile.Text = "ToolStripButton1"
        Me.cmdUploadFile.ToolTipText = "Upload file"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdDownloadFile
        '
        Me.cmdDownloadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDownloadFile.Image = Global.Capability_Log.My.Resources.Resources.agt_upgrade_misc
        Me.cmdDownloadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDownloadFile.Name = "cmdDownloadFile"
        Me.cmdDownloadFile.Size = New System.Drawing.Size(23, 22)
        Me.cmdDownloadFile.Text = "ToolStripButton1"
        Me.cmdDownloadFile.ToolTipText = "download file"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdDeleteFile
        '
        Me.cmdDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDeleteFile.Image = Global.Capability_Log.My.Resources.Resources.messagebox_critical
        Me.cmdDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDeleteFile.Name = "cmdDeleteFile"
        Me.cmdDeleteFile.Size = New System.Drawing.Size(23, 22)
        Me.cmdDeleteFile.Text = "ToolStripButton2"
        Me.cmdDeleteFile.ToolTipText = "Remove file"
        '
        'fodFile
        '
        Me.fodFile.FileName = "OpenFileDialog1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cp_Forecast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(896, 588)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "cp_Forecast"
        Me.Text = "Corporate Project Forecast"
        Me.Controls.SetChildIndex(Me.GroupBox7, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabResources.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDocuments.ResumeLayout(False)
        Me.tabDocuments.PerformLayout()
        CType(Me.dtgFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbFiles.ResumeLayout(False)
        Me.tlbFiles.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboProject_Type As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPSSPM As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtGBSPM As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabResources As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdShowResources As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDeleteResource As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtgResources As System.Windows.Forms.DataGridView
    Friend WithEvents tabDocuments As System.Windows.Forms.TabPage
    Friend WithEvents dtgFiles As System.Windows.Forms.DataGridView
    Friend WithEvents tlbFiles As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdUploadFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdDownloadFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdDeleteFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents fodFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents sfdFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator

End Class
