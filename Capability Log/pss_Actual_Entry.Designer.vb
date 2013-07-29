<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pss_Actual_Entry
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
        Me.dtgResources = New System.Windows.Forms.DataGridView
        Me.grpTaskDate = New System.Windows.Forms.GroupBox
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.cmdSave = New System.Windows.Forms.ToolStripButton
        Me.grpResources = New System.Windows.Forms.GroupBox
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTaskDate.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpResources.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dtgResources.Size = New System.Drawing.Size(731, 277)
        Me.dtgResources.TabIndex = 0
        '
        'grpTaskDate
        '
        Me.grpTaskDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTaskDate.Controls.Add(Me.dtpMonth)
        Me.grpTaskDate.Controls.Add(Me.Label1)
        Me.grpTaskDate.Location = New System.Drawing.Point(0, 34)
        Me.grpTaskDate.Name = "grpTaskDate"
        Me.grpTaskDate.Size = New System.Drawing.Size(746, 55)
        Me.grpTaskDate.TabIndex = 10
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
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(753, 31)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'grpResources
        '
        Me.grpResources.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResources.Controls.Add(Me.dtgResources)
        Me.grpResources.Location = New System.Drawing.Point(0, 95)
        Me.grpResources.Name = "grpResources"
        Me.grpResources.Size = New System.Drawing.Size(746, 303)
        Me.grpResources.TabIndex = 8
        Me.grpResources.TabStop = False
        Me.grpResources.Text = "Month tasks"
        '
        'pss_Actual_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(753, 423)
        Me.Controls.Add(Me.grpTaskDate)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpResources)
        Me.Message = ""
        Me.Name = "pss_Actual_Entry"
        Me.Text = "PSS Projects - Actuals Entry"
        Me.Controls.SetChildIndex(Me.grpResources, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.grpTaskDate, 0)
        CType(Me.dtgResources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTaskDate.ResumeLayout(False)
        Me.grpTaskDate.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpResources.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgResources As System.Windows.Forms.DataGridView
    Friend WithEvents grpTaskDate As System.Windows.Forms.GroupBox
    Friend WithEvents dtpMonth As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpResources As System.Windows.Forms.GroupBox

End Class
