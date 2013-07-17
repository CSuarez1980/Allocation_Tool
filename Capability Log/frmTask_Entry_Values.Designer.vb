<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTask_Entry_Values
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
        Me.components = New System.ComponentModel.Container
        Me.grpEntry = New System.Windows.Forms.GroupBox
        Me.dtgEntry = New System.Windows.Forms.DataGridView
        Me.tlbTools = New System.Windows.Forms.ToolStrip
        Me.cmdSave = New System.Windows.Forms.ToolStripButton
        Me.lblDate = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.BS = New System.Windows.Forms.BindingSource(Me.components)
        Me.grpEntry.SuspendLayout()
        CType(Me.dtgEntry, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbTools.SuspendLayout()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpEntry
        '
        Me.grpEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEntry.Controls.Add(Me.dtgEntry)
        Me.grpEntry.Location = New System.Drawing.Point(5, 69)
        Me.grpEntry.Name = "grpEntry"
        Me.grpEntry.Size = New System.Drawing.Size(766, 368)
        Me.grpEntry.TabIndex = 3
        Me.grpEntry.TabStop = False
        Me.grpEntry.Text = "Entry information"
        '
        'dtgEntry
        '
        Me.dtgEntry.AllowUserToAddRows = False
        Me.dtgEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgEntry.Location = New System.Drawing.Point(8, 19)
        Me.dtgEntry.Name = "dtgEntry"
        Me.dtgEntry.Size = New System.Drawing.Size(752, 343)
        Me.dtgEntry.TabIndex = 3
        '
        'tlbTools
        '
        Me.tlbTools.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tlbTools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdSave})
        Me.tlbTools.Location = New System.Drawing.Point(0, 0)
        Me.tlbTools.Name = "tlbTools"
        Me.tlbTools.Size = New System.Drawing.Size(776, 31)
        Me.tlbTools.TabIndex = 4
        Me.tlbTools.Text = "ToolStrip1"
        '
        'cmdSave
        '
        Me.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSave.Image = Global.Capability_Log.My.Resources.Resources.Save
        Me.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.Text = "Save entries"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(13, 44)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Date"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(59, 40)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(112, 20)
        Me.dtpDate.TabIndex = 6
        '
        'frmTask_Entry_Values
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(776, 462)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.tlbTools)
        Me.Controls.Add(Me.grpEntry)
        Me.Message = ""
        Me.Name = "frmTask_Entry_Values"
        Me.Text = "Task entry values"
        Me.Controls.SetChildIndex(Me.grpEntry, 0)
        Me.Controls.SetChildIndex(Me.tlbTools, 0)
        Me.Controls.SetChildIndex(Me.lblDate, 0)
        Me.Controls.SetChildIndex(Me.dtpDate, 0)
        Me.grpEntry.ResumeLayout(False)
        CType(Me.dtgEntry, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbTools.ResumeLayout(False)
        Me.tlbTools.PerformLayout()
        CType(Me.BS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpEntry As System.Windows.Forms.GroupBox
    Friend WithEvents dtgEntry As System.Windows.Forms.DataGridView
    Friend WithEvents tlbTools As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents BS As System.Windows.Forms.BindingSource
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker

End Class
