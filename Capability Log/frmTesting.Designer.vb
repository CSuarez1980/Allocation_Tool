<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTesting
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
        Me.T = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'T
        '
        Me.T.Location = New System.Drawing.Point(64, 56)
        Me.T.Name = "T"
        Me.T.Size = New System.Drawing.Size(348, 270)
        Me.T.TabIndex = 2
        '
        'frmTesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(482, 390)
        Me.Controls.Add(Me.T)
        Me.Message = ""
        Me.Name = "frmTesting"
        Me.Controls.SetChildIndex(Me.T, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents T As System.Windows.Forms.TreeView

End Class
