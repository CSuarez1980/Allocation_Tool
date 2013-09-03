<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTask_Entry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTask_Entry))
        Me.grpTasks = New System.Windows.Forms.GroupBox
        Me.tlbTask = New System.Windows.Forms.ToolStrip
        Me.cmdSetEntry = New System.Windows.Forms.ToolStripButton
        Me.dtgTask = New System.Windows.Forms.DataGridView
        Me.grpProjects = New System.Windows.Forms.GroupBox
        Me.dtgProjects = New System.Windows.Forms.DataGridView
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.cmd_ShowAll = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.dtg_OpenTask = New System.Windows.Forms.DataGridView
        Me.grpTasks.SuspendLayout()
        Me.tlbTask.SuspendLayout()
        CType(Me.dtgTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpProjects.SuspendLayout()
        CType(Me.dtgProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtg_OpenTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpTasks
        '
        Me.grpTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTasks.Controls.Add(Me.tlbTask)
        Me.grpTasks.Controls.Add(Me.dtgTask)
        Me.grpTasks.Location = New System.Drawing.Point(613, 112)
        Me.grpTasks.Name = "grpTasks"
        Me.grpTasks.Size = New System.Drawing.Size(69, 96)
        Me.grpTasks.TabIndex = 4
        Me.grpTasks.TabStop = False
        Me.grpTasks.Text = "Tasks"
        '
        'tlbTask
        '
        Me.tlbTask.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tlbTask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSetEntry})
        Me.tlbTask.Location = New System.Drawing.Point(3, 16)
        Me.tlbTask.Name = "tlbTask"
        Me.tlbTask.Size = New System.Drawing.Size(63, 31)
        Me.tlbTask.TabIndex = 5
        Me.tlbTask.Text = "ToolStrip1"
        '
        'cmdSetEntry
        '
        Me.cmdSetEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSetEntry.Image = Global.Capability_Log.My.Resources.Resources.todo
        Me.cmdSetEntry.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSetEntry.Name = "cmdSetEntry"
        Me.cmdSetEntry.Size = New System.Drawing.Size(28, 28)
        Me.cmdSetEntry.Text = "ToolStripButton1"
        Me.cmdSetEntry.ToolTipText = "Set task entry"
        '
        'dtgTask
        '
        Me.dtgTask.AllowUserToAddRows = False
        Me.dtgTask.AllowUserToDeleteRows = False
        Me.dtgTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTask.Location = New System.Drawing.Point(7, 50)
        Me.dtgTask.Name = "dtgTask"
        Me.dtgTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgTask.Size = New System.Drawing.Size(54, 40)
        Me.dtgTask.TabIndex = 4
        '
        'grpProjects
        '
        Me.grpProjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProjects.Controls.Add(Me.dtgProjects)
        Me.grpProjects.Location = New System.Drawing.Point(611, 34)
        Me.grpProjects.Name = "grpProjects"
        Me.grpProjects.Size = New System.Drawing.Size(71, 72)
        Me.grpProjects.TabIndex = 6
        Me.grpProjects.TabStop = False
        Me.grpProjects.Text = "Projects"
        '
        'dtgProjects
        '
        Me.dtgProjects.AllowUserToAddRows = False
        Me.dtgProjects.AllowUserToDeleteRows = False
        Me.dtgProjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgProjects.Location = New System.Drawing.Point(6, 19)
        Me.dtgProjects.Name = "dtgProjects"
        Me.dtgProjects.ReadOnly = True
        Me.dtgProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgProjects.Size = New System.Drawing.Size(59, 47)
        Me.dtgProjects.TabIndex = 4
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmd_ShowAll})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(694, 31)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'cmd_ShowAll
        '
        Me.cmd_ShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmd_ShowAll.Enabled = False
        Me.cmd_ShowAll.Image = CType(resources.GetObject("cmd_ShowAll.Image"), System.Drawing.Image)
        Me.cmd_ShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmd_ShowAll.Name = "cmd_ShowAll"
        Me.cmd_ShowAll.Size = New System.Drawing.Size(28, 28)
        Me.cmd_ShowAll.Text = "ToolStripButton2"
        Me.cmd_ShowAll.ToolTipText = "Show all actives projects"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.Controls.Add(Me.dtg_OpenTask)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 404)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tasks"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(683, 31)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Capability_Log.My.Resources.Resources.todo
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.ToolTipText = "Set task entry"
        '
        'dtg_OpenTask
        '
        Me.dtg_OpenTask.AllowUserToAddRows = False
        Me.dtg_OpenTask.AllowUserToDeleteRows = False
        Me.dtg_OpenTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtg_OpenTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtg_OpenTask.Location = New System.Drawing.Point(7, 50)
        Me.dtg_OpenTask.Name = "dtg_OpenTask"
        Me.dtg_OpenTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtg_OpenTask.Size = New System.Drawing.Size(674, 348)
        Me.dtg_OpenTask.TabIndex = 4
        '
        'frmTask_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(694, 459)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.grpProjects)
        Me.Controls.Add(Me.grpTasks)
        Me.Message = ""
        Me.Name = "frmTask_Entry"
        Me.Text = "Task input"
        Me.Controls.SetChildIndex(Me.grpTasks, 0)
        Me.Controls.SetChildIndex(Me.grpProjects, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.grpTasks.ResumeLayout(False)
        Me.grpTasks.PerformLayout()
        Me.tlbTask.ResumeLayout(False)
        Me.tlbTask.PerformLayout()
        CType(Me.dtgTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpProjects.ResumeLayout(False)
        CType(Me.dtgProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtg_OpenTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpTasks As System.Windows.Forms.GroupBox
    Friend WithEvents dtgTask As System.Windows.Forms.DataGridView
    Friend WithEvents grpProjects As System.Windows.Forms.GroupBox
    Friend WithEvents dtgProjects As System.Windows.Forms.DataGridView
    Friend WithEvents tlbTask As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdSetEntry As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmd_ShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtg_OpenTask As System.Windows.Forms.DataGridView

End Class
