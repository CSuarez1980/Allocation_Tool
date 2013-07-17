<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMant))
        Me.tlbTools = New System.Windows.Forms.ToolStrip
        Me.cmdNew = New System.Windows.Forms.ToolStripButton
        Me.cmdEdit = New System.Windows.Forms.ToolStripButton
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdSave = New System.Windows.Forms.ToolStripButton
        Me.cmdCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdSearch = New System.Windows.Forms.ToolStripButton
        Me.tlbTools.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbTools
        '
        Me.tlbTools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdNew, Me.cmdEdit, Me.cmdDelete, Me.ToolStripSeparator1, Me.cmdSave, Me.cmdCancel, Me.ToolStripSeparator2, Me.cmdSearch})
        Me.tlbTools.Location = New System.Drawing.Point(0, 0)
        Me.tlbTools.Name = "tlbTools"
        Me.tlbTools.Size = New System.Drawing.Size(421, 25)
        Me.tlbTools.TabIndex = 2
        Me.tlbTools.Text = "ToolStrip1"
        '
        'cmdNew
        '
        Me.cmdNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdNew.Image = CType(resources.GetObject("cmdNew.Image"), System.Drawing.Image)
        Me.cmdNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(23, 22)
        Me.cmdNew.Text = "ToolStripButton1"
        Me.cmdNew.ToolTipText = "New"
        '
        'cmdEdit
        '
        Me.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(23, 22)
        Me.cmdEdit.Text = "ToolStripButton2"
        Me.cmdEdit.ToolTipText = "Edit"
        '
        'cmdDelete
        '
        Me.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
        Me.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(23, 22)
        Me.cmdDelete.Text = "ToolStripButton3"
        Me.cmdDelete.ToolTipText = "Delete"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator1.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(23, 22)
        Me.cmdSave.Text = "ToolStripButton4"
        Me.cmdSave.ToolTipText = "Save"
        Me.cmdSave.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(23, 22)
        Me.cmdCancel.Text = "ToolStripButton5"
        Me.cmdCancel.ToolTipText = "Cancel"
        Me.cmdCancel.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdSearch
        '
        Me.cmdSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSearch.Image = CType(resources.GetObject("cmdSearch.Image"), System.Drawing.Image)
        Me.cmdSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(23, 22)
        Me.cmdSearch.Text = "ToolStripButton6"
        Me.cmdSearch.ToolTipText = "Search"
        '
        'frmMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(421, 249)
        Me.Controls.Add(Me.tlbTools)
        Me.Message = ""
        Me.Name = "frmMant"
        Me.Controls.SetChildIndex(Me.tlbTools, 0)
        Me.tlbTools.ResumeLayout(False)
        Me.tlbTools.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbTools As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdSearch As System.Windows.Forms.ToolStripButton

End Class
