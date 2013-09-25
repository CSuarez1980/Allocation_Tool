<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProject
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblProjectProgress = New System.Windows.Forms.Label
        Me.pgbProject = New System.Windows.Forms.ProgressBar
        Me.txtDays_Completed = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtForecast_FTE = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDailyHours = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboValue_Stream = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboService = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPriority = New System.Windows.Forms.ComboBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.chkShow_Task_Deleted = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblTaskProgress = New System.Windows.Forms.Label
        Me.pgbTask = New System.Windows.Forms.ProgressBar
        Me.txtTaskFTEReq = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTaskDailyHours = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtgTask = New System.Windows.Forms.DataGridView
        Me.tlbTask = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdAdd = New System.Windows.Forms.ToolStripButton
        Me.cmdRemove = New System.Windows.Forms.ToolStripButton
        Me.cmdEditTask = New System.Windows.Forms.ToolStripButton
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbTask.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(653, 441)
        Me.TabControl1.TabIndex = 31
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(645, 415)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Project Detail"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lblProjectProgress)
        Me.GroupBox2.Controls.Add(Me.pgbProject)
        Me.GroupBox2.Controls.Add(Me.txtDays_Completed)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtEnd)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtStart)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtForecast_FTE)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDailyHours)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(633, 184)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Forecast time"
        '
        'lblProjectProgress
        '
        Me.lblProjectProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProjectProgress.AutoSize = True
        Me.lblProjectProgress.Location = New System.Drawing.Point(6, 146)
        Me.lblProjectProgress.Name = "lblProjectProgress"
        Me.lblProjectProgress.Size = New System.Drawing.Size(86, 13)
        Me.lblProjectProgress.TabIndex = 62
        Me.lblProjectProgress.Text = "Project progress:"
        '
        'pgbProject
        '
        Me.pgbProject.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbProject.Location = New System.Drawing.Point(3, 167)
        Me.pgbProject.Name = "pgbProject"
        Me.pgbProject.Size = New System.Drawing.Size(627, 14)
        Me.pgbProject.TabIndex = 61
        '
        'txtDays_Completed
        '
        Me.txtDays_Completed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDays_Completed.Enabled = False
        Me.txtDays_Completed.Location = New System.Drawing.Point(520, 88)
        Me.txtDays_Completed.Name = "txtDays_Completed"
        Me.txtDays_Completed.Size = New System.Drawing.Size(44, 20)
        Me.txtDays_Completed.TabIndex = 57
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(461, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 36)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Days completed"
        '
        'txtEnd
        '
        Me.txtEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEnd.Enabled = False
        Me.txtEnd.Location = New System.Drawing.Point(520, 52)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(88, 20)
        Me.txtEnd.TabIndex = 55
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(461, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "End"
        '
        'txtStart
        '
        Me.txtStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStart.Enabled = False
        Me.txtStart.Location = New System.Drawing.Point(520, 23)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(88, 20)
        Me.txtStart.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(461, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Start"
        '
        'txtForecast_FTE
        '
        Me.txtForecast_FTE.Enabled = False
        Me.txtForecast_FTE.Location = New System.Drawing.Point(99, 52)
        Me.txtForecast_FTE.Name = "txtForecast_FTE"
        Me.txtForecast_FTE.Size = New System.Drawing.Size(65, 20)
        Me.txtForecast_FTE.TabIndex = 51
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(25, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 35)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Forecast FTE required"
        '
        'txtDailyHours
        '
        Me.txtDailyHours.Enabled = False
        Me.txtDailyHours.Location = New System.Drawing.Point(99, 23)
        Me.txtDailyHours.Name = "txtDailyHours"
        Me.txtDailyHours.Size = New System.Drawing.Size(65, 20)
        Me.txtDailyHours.TabIndex = 49
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Daily hours"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboValue_Stream)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboCategory)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboService)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboPriority)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 213)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General information"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Value stream"
        '
        'cboValue_Stream
        '
        Me.cboValue_Stream.Enabled = False
        Me.cboValue_Stream.FormattingEnabled = True
        Me.cboValue_Stream.Location = New System.Drawing.Point(99, 180)
        Me.cboValue_Stream.Name = "cboValue_Stream"
        Me.cboValue_Stream.Size = New System.Drawing.Size(146, 21)
        Me.cboValue_Stream.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.Enabled = False
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(99, 153)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(146, 21)
        Me.cboCategory.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.Enabled = False
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(99, 126)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(146, 21)
        Me.cboStatus.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Service line"
        '
        'cboService
        '
        Me.cboService.Enabled = False
        Me.cboService.FormattingEnabled = True
        Me.cboService.Location = New System.Drawing.Point(99, 99)
        Me.cboService.Name = "cboService"
        Me.cboService.Size = New System.Drawing.Size(146, 21)
        Me.cboService.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Priority"
        '
        'cboPriority
        '
        Me.cboPriority.Enabled = False
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Location = New System.Drawing.Point(99, 72)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(146, 21)
        Me.cboPriority.TabIndex = 49
        '
        'txtDescription
        '
        Me.txtDescription.Enabled = False
        Me.txtDescription.Location = New System.Drawing.Point(99, 45)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(240, 20)
        Me.txtDescription.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Description"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(99, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(240, 20)
        Me.txtName.TabIndex = 46
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(25, 23)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 45
        Me.lblName.Text = "Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkShow_Task_Deleted)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.dtgTask)
        Me.TabPage2.Controls.Add(Me.tlbTask)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(645, 415)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tasks"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkShow_Task_Deleted
        '
        Me.chkShow_Task_Deleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShow_Task_Deleted.AutoSize = True
        Me.chkShow_Task_Deleted.Location = New System.Drawing.Point(3, 261)
        Me.chkShow_Task_Deleted.Name = "chkShow_Task_Deleted"
        Me.chkShow_Task_Deleted.Size = New System.Drawing.Size(119, 17)
        Me.chkShow_Task_Deleted.TabIndex = 57
        Me.chkShow_Task_Deleted.Text = "Show tasks deleted"
        Me.chkShow_Task_Deleted.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblTaskProgress)
        Me.GroupBox3.Controls.Add(Me.pgbTask)
        Me.GroupBox3.Controls.Add(Me.txtTaskFTEReq)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtTaskDailyHours)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 284)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(633, 125)
        Me.GroupBox3.TabIndex = 56
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Task detail"
        '
        'lblTaskProgress
        '
        Me.lblTaskProgress.AutoSize = True
        Me.lblTaskProgress.Location = New System.Drawing.Point(6, 91)
        Me.lblTaskProgress.Name = "lblTaskProgress"
        Me.lblTaskProgress.Size = New System.Drawing.Size(77, 13)
        Me.lblTaskProgress.TabIndex = 61
        Me.lblTaskProgress.Text = "Task progress:"
        '
        'pgbTask
        '
        Me.pgbTask.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbTask.Location = New System.Drawing.Point(3, 108)
        Me.pgbTask.Name = "pgbTask"
        Me.pgbTask.Size = New System.Drawing.Size(627, 14)
        Me.pgbTask.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pgbTask.TabIndex = 60
        '
        'txtTaskFTEReq
        '
        Me.txtTaskFTEReq.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTaskFTEReq.Enabled = False
        Me.txtTaskFTEReq.Location = New System.Drawing.Point(116, 49)
        Me.txtTaskFTEReq.Name = "txtTaskFTEReq"
        Me.txtTaskFTEReq.Size = New System.Drawing.Size(65, 20)
        Me.txtTaskFTEReq.TabIndex = 59
        Me.txtTaskFTEReq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Daily FTE required"
        '
        'txtTaskDailyHours
        '
        Me.txtTaskDailyHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTaskDailyHours.Enabled = False
        Me.txtTaskDailyHours.Location = New System.Drawing.Point(116, 23)
        Me.txtTaskDailyHours.Name = "txtTaskDailyHours"
        Me.txtTaskDailyHours.Size = New System.Drawing.Size(65, 20)
        Me.txtTaskDailyHours.TabIndex = 57
        Me.txtTaskDailyHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Daily hours"
        '
        'dtgTask
        '
        Me.dtgTask.AllowUserToAddRows = False
        Me.dtgTask.AllowUserToDeleteRows = False
        Me.dtgTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgTask.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgTask.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgTask.Location = New System.Drawing.Point(3, 32)
        Me.dtgTask.Name = "dtgTask"
        Me.dtgTask.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgTask.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgTask.Size = New System.Drawing.Size(636, 223)
        Me.dtgTask.TabIndex = 6
        '
        'tlbTask
        '
        Me.tlbTask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAdd, Me.ToolStripSeparator3, Me.cmdRemove, Me.ToolStripSeparator2, Me.cmdEditTask})
        Me.tlbTask.Location = New System.Drawing.Point(3, 3)
        Me.tlbTask.Name = "tlbTask"
        Me.tlbTask.Size = New System.Drawing.Size(639, 25)
        Me.tlbTask.TabIndex = 5
        Me.tlbTask.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.cmdAdd.ToolTipText = "Add task"
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
        Me.cmdRemove.ToolTipText = "Remove task"
        '
        'cmdEditTask
        '
        Me.cmdEditTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdEditTask.Enabled = False
        Me.cmdEditTask.Image = Global.Capability_Log.My.Resources.Resources.khexedit
        Me.cmdEditTask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEditTask.Name = "cmdEditTask"
        Me.cmdEditTask.Size = New System.Drawing.Size(23, 22)
        Me.cmdEditTask.Text = "ToolStripButton1"
        Me.cmdEditTask.ToolTipText = "Edit task"
        '
        'frmProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(673, 498)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmProject"
        Me.Text = "Project maintenance"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dtgTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbTask.ResumeLayout(False)
        Me.tlbTask.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tlbTask As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtgTask As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtForecast_FTE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDailyHours As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboValue_Stream As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboService As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtDays_Completed As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdEditTask As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTaskFTEReq As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTaskDailyHours As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pgbProject As System.Windows.Forms.ProgressBar
    Friend WithEvents pgbTask As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTaskProgress As System.Windows.Forms.Label
    Friend WithEvents lblProjectProgress As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkShow_Task_Deleted As System.Windows.Forms.CheckBox

End Class
