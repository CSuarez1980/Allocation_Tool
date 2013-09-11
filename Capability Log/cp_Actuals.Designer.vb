<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cp_Actuals
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.grpActuals = New System.Windows.Forms.GroupBox
        Me.dtgActuals = New System.Windows.Forms.DataGridView
        Me.ToolStrip1.SuspendLayout()
        Me.grpActuals.SuspendLayout()
        CType(Me.dtgActuals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 31)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Capability_Log.My.Resources.Resources.Save
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'grpActuals
        '
        Me.grpActuals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpActuals.Controls.Add(Me.dtgActuals)
        Me.grpActuals.Location = New System.Drawing.Point(4, 34)
        Me.grpActuals.Name = "grpActuals"
        Me.grpActuals.Size = New System.Drawing.Size(843, 257)
        Me.grpActuals.TabIndex = 3
        Me.grpActuals.TabStop = False
        Me.grpActuals.Text = "Actuals"
        '
        'dtgActuals
        '
        Me.dtgActuals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgActuals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtgActuals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgActuals.Location = New System.Drawing.Point(8, 20)
        Me.dtgActuals.Name = "dtgActuals"
        Me.dtgActuals.Size = New System.Drawing.Size(828, 231)
        Me.dtgActuals.TabIndex = 0
        '
        'cp_Actuals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(852, 320)
        Me.Controls.Add(Me.grpActuals)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Message = ""
        Me.Name = "cp_Actuals"
        Me.Text = "Corporate Projects - Actual inputs"
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.grpActuals, 0)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpActuals.ResumeLayout(False)
        CType(Me.dtgActuals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents grpActuals As System.Windows.Forms.GroupBox
    Friend WithEvents dtgActuals As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
