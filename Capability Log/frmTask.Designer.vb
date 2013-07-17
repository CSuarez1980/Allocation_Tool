<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTask
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
        Me.grpTask = New System.Windows.Forms.GroupBox
        Me.chkDelInd = New System.Windows.Forms.CheckBox
        Me.txtOwner = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFTE = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtHours = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpTask.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpTask
        '
        Me.grpTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTask.Controls.Add(Me.chkDelInd)
        Me.grpTask.Controls.Add(Me.txtOwner)
        Me.grpTask.Controls.Add(Me.Label7)
        Me.grpTask.Controls.Add(Me.cboStatus)
        Me.grpTask.Controls.Add(Me.Label4)
        Me.grpTask.Controls.Add(Me.dtpEnd)
        Me.grpTask.Controls.Add(Me.dtpStart)
        Me.grpTask.Controls.Add(Me.Label6)
        Me.grpTask.Controls.Add(Me.Label5)
        Me.grpTask.Controls.Add(Me.txtFTE)
        Me.grpTask.Controls.Add(Me.Label3)
        Me.grpTask.Controls.Add(Me.txtHours)
        Me.grpTask.Controls.Add(Me.Label2)
        Me.grpTask.Controls.Add(Me.txtName)
        Me.grpTask.Controls.Add(Me.Label1)
        Me.grpTask.Location = New System.Drawing.Point(5, 28)
        Me.grpTask.Name = "grpTask"
        Me.grpTask.Size = New System.Drawing.Size(372, 236)
        Me.grpTask.TabIndex = 21
        Me.grpTask.TabStop = False
        Me.grpTask.Text = "Task detail"
        '
        'chkDelInd
        '
        Me.chkDelInd.AutoSize = True
        Me.chkDelInd.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDelInd.Location = New System.Drawing.Point(8, 208)
        Me.chkDelInd.Name = "chkDelInd"
        Me.chkDelInd.Size = New System.Drawing.Size(100, 17)
        Me.chkDelInd.TabIndex = 35
        Me.chkDelInd.Text = "Delete indicator"
        Me.chkDelInd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDelInd.UseVisualStyleBackColor = True
        '
        'txtOwner
        '
        Me.txtOwner.Location = New System.Drawing.Point(70, 130)
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(59, 20)
        Me.txtOwner.TabIndex = 34
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Owner"
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(70, 51)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(153, 21)
        Me.cboStatus.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Status"
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(70, 104)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(114, 20)
        Me.dtpEnd.TabIndex = 30
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(70, 78)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(114, 20)
        Me.dtpStart.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "End"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Start"
        '
        'txtFTE
        '
        Me.txtFTE.Location = New System.Drawing.Point(70, 182)
        Me.txtFTE.Name = "txtFTE"
        Me.txtFTE.Size = New System.Drawing.Size(59, 20)
        Me.txtFTE.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Task FTE"
        '
        'txtHours
        '
        Me.txtHours.Location = New System.Drawing.Point(70, 156)
        Me.txtHours.Name = "txtHours"
        Me.txtHours.Size = New System.Drawing.Size(59, 20)
        Me.txtHours.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Daily hours"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(70, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(235, 20)
        Me.txtName.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Name"
        '
        'frmTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(382, 292)
        Me.Controls.Add(Me.grpTask)
        Me.Name = "frmTask"
        Me.Text = "Task"
        Me.Controls.SetChildIndex(Me.grpTask, 0)
        Me.grpTask.ResumeLayout(False)
        Me.grpTask.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpTask As System.Windows.Forms.GroupBox
    Friend WithEvents chkDelInd As System.Windows.Forms.CheckBox
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFTE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHours As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
