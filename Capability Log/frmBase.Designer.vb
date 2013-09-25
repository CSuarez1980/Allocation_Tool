<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBase))
        Me.BS = New System.Windows.Forms.BindingSource(Me.components)
        Me.tlbEstado = New System.Windows.Forms.StatusStrip
        Me.ImgInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.ImgError = New System.Windows.Forms.ToolStripStatusLabel
        Me.ImgWarning = New System.Windows.Forms.ToolStripStatusLabel
        Me.txtMessage = New System.Windows.Forms.ToolStripStatusLabel
        Me.pgStatus = New System.Windows.Forms.ToolStripProgressBar
        Me.lblFormName = New System.Windows.Forms.ToolStripStatusLabel
        Me.tmrTime = New System.Windows.Forms.Timer(Me.components)
        CType(Me.BS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlbEstado
        '
        Me.tlbEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImgInfo, Me.ImgError, Me.ImgWarning, Me.txtMessage, Me.pgStatus, Me.lblFormName})
        Me.tlbEstado.Location = New System.Drawing.Point(0, 235)
        Me.tlbEstado.Name = "tlbEstado"
        Me.tlbEstado.Size = New System.Drawing.Size(426, 22)
        Me.tlbEstado.TabIndex = 1
        Me.tlbEstado.Text = "StatusStrip1"
        '
        'ImgInfo
        '
        Me.ImgInfo.Image = CType(resources.GetObject("ImgInfo.Image"), System.Drawing.Image)
        Me.ImgInfo.Name = "ImgInfo"
        Me.ImgInfo.Size = New System.Drawing.Size(16, 17)
        Me.ImgInfo.Visible = False
        '
        'ImgError
        '
        Me.ImgError.Image = CType(resources.GetObject("ImgError.Image"), System.Drawing.Image)
        Me.ImgError.Name = "ImgError"
        Me.ImgError.Size = New System.Drawing.Size(16, 17)
        Me.ImgError.Visible = False
        '
        'ImgWarning
        '
        Me.ImgWarning.Image = CType(resources.GetObject("ImgWarning.Image"), System.Drawing.Image)
        Me.ImgWarning.Name = "ImgWarning"
        Me.ImgWarning.Size = New System.Drawing.Size(16, 17)
        Me.ImgWarning.Visible = False
        '
        'txtMessage
        '
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(341, 17)
        Me.txtMessage.Spring = True
        Me.txtMessage.Text = "Form message"
        Me.txtMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgStatus
        '
        Me.pgStatus.Name = "pgStatus"
        Me.pgStatus.Size = New System.Drawing.Size(100, 16)
        Me.pgStatus.Visible = False
        '
        'lblFormName
        '
        Me.lblFormName.Name = "lblFormName"
        Me.lblFormName.Size = New System.Drawing.Size(70, 17)
        Me.lblFormName.Text = "Form Name"
        '
        'tmrTime
        '
        Me.tmrTime.Interval = 3000
        '
        'frmBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(426, 257)
        Me.Controls.Add(Me.tlbEstado)
        Me.Name = "frmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBase"
        CType(Me.BS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbEstado.ResumeLayout(False)
        Me.tlbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BS As System.Windows.Forms.BindingSource
    Friend WithEvents tlbEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents ImgInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImgError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImgWarning As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pgStatus As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblFormName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrTime As System.Windows.Forms.Timer
End Class
