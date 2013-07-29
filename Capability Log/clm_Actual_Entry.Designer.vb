<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clm_Actual_Entry
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
        Me.grpResources = New System.Windows.Forms.GroupBox
        Me.dtgResources = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.grpTaskDate = New System.Windows.Forms.GroupBox
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.ToolStripButton
        Me.grpResources.SuspendLayout()
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.grpTaskDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpResources
        '
        Me.grpResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResources.Controls.Add(Me.dtgResources)
        Me.grpResources.Location = New System.Drawing.Point(5, 96)
        Me.grpResources.Name = "grpResources"
        Me.grpResources.Size = New System.Drawing.Size(801, 244)
        Me.grpResources.TabIndex = 2
        Me.grpResources.TabStop = False
        Me.grpResources.Text = "Month tasks"
        '
        'dtgResources
        '
        Me.dtgResources.AllowUserToAddRows = False
        Me.dtgResources.AllowUserToDeleteRows = False
        Me.dtgResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgResources.Location = New System.Drawing.Point(8, 20)
        Me.dtgResources.Name = "dtgResources"
        Me.dtgResources.Size = New System.Drawing.Size(786, 218)
        Me.dtgResources.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(811, 31)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'grpTaskDate
        '
        Me.grpTaskDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTaskDate.Controls.Add(Me.dtpMonth)
        Me.grpTaskDate.Controls.Add(Me.Label1)
        Me.grpTaskDate.Location = New System.Drawing.Point(5, 35)
        Me.grpTaskDate.Name = "grpTaskDate"
        Me.grpTaskDate.Size = New System.Drawing.Size(801, 55)
        Me.grpTaskDate.TabIndex = 7
        Me.grpTaskDate.TabStop = False
        Me.grpTaskDate.Text = "Task date"
        '
        'dtpMonth
        '
        Me.dtpMonth.CustomFormat = "MMMM' 'yyyy"
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(65, 24)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.Size = New System.Drawing.Size(134, 20)
        Me.dtpMonth.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Month"
        '
        'cmdSave
        '
        Me.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSave.Image = Global.Capability_Log.My.Resources.Resources.Save
        Me.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.Text = "ToolStripButton1"
        Me.cmdSave.ToolTipText = "Save"
        '
        'clm_Actual_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(811, 365)
        Me.Controls.Add(Me.grpTaskDate)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpResources)
        Me.Message = ""
        Me.Name = "clm_Actual_Entry"
        Me.Text = "Corporate Projects - Actuals Entry"
        Me.Controls.SetChildIndex(Me.grpResources, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.grpTaskDate, 0)
        Me.grpResources.ResumeLayout(False)
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpTaskDate.ResumeLayout(False)
        Me.grpTaskDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpResources As System.Windows.Forms.GroupBox
    Friend WithEvents dtgResources As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpTaskDate As System.Windows.Forms.GroupBox
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
