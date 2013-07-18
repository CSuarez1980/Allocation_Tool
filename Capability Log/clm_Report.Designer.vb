<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clm_Report
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.vw_CM_Raw_DataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CapabilityLogDataSet = New Capability_Log.CapabilityLogDataSet
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.txtTask = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.txtResource = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtContact = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtProjectType = New System.Windows.Forms.TextBox
        Me.txtProjects = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.rtpReport = New Microsoft.Reporting.WinForms.ReportViewer
        Me.vw_CM_Raw_DataTableAdapter = New Capability_Log.CapabilityLogDataSetTableAdapters.vw_CM_Raw_DataTableAdapter
        CType(Me.vw_CM_Raw_DataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CapabilityLogDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'vw_CM_Raw_DataBindingSource
        '
        Me.vw_CM_Raw_DataBindingSource.DataMember = "vw_CM_Raw_Data"
        Me.vw_CM_Raw_DataBindingSource.DataSource = Me.CapabilityLogDataSet
        '
        'CapabilityLogDataSet
        '
        Me.CapabilityLogDataSet.DataSetName = "CapabilityLogDataSet"
        Me.CapabilityLogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.txtTask)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.txtResource)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.txtContact)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.txtProjectType)
        Me.GroupBox2.Controls.Add(Me.txtProjects)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpEnd)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpStart)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.rtpReport)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(884, 595)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Report parameters"
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Image = Global.Capability_Log.My.Resources.Resources.down
        Me.Button5.Location = New System.Drawing.Point(851, 29)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(23, 23)
        Me.Button5.TabIndex = 29
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtTask
        '
        Me.txtTask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTask.Location = New System.Drawing.Point(620, 30)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(226, 20)
        Me.txtTask.TabIndex = 28
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(545, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Project stages"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Image = Global.Capability_Log.My.Resources.Resources.down
        Me.Button4.Location = New System.Drawing.Point(851, 81)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 23)
        Me.Button4.TabIndex = 26
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtResource
        '
        Me.txtResource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResource.Location = New System.Drawing.Point(620, 82)
        Me.txtResource.Name = "txtResource"
        Me.txtResource.Size = New System.Drawing.Size(226, 20)
        Me.txtResource.TabIndex = 25
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.Capability_Log.My.Resources.Resources.down
        Me.Button3.Location = New System.Drawing.Point(851, 56)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(23, 23)
        Me.Button3.TabIndex = 24
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtContact
        '
        Me.txtContact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContact.Location = New System.Drawing.Point(620, 57)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(226, 20)
        Me.txtContact.TabIndex = 23
        '
        'Button2
        '
        Me.Button2.Image = Global.Capability_Log.My.Resources.Resources.down
        Me.Button2.Location = New System.Drawing.Point(323, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(23, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtProjectType
        '
        Me.txtProjectType.Location = New System.Drawing.Point(92, 82)
        Me.txtProjectType.Name = "txtProjectType"
        Me.txtProjectType.Size = New System.Drawing.Size(226, 20)
        Me.txtProjectType.TabIndex = 21
        '
        'txtProjects
        '
        Me.txtProjects.Location = New System.Drawing.Point(92, 57)
        Me.txtProjects.Name = "txtProjects"
        Me.txtProjects.Size = New System.Drawing.Size(226, 20)
        Me.txtProjects.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Image = Global.Capability_Log.My.Resources.Resources.down
        Me.Button1.Location = New System.Drawing.Point(323, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(545, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Resource"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(545, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Contact name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Project name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Project type"
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(230, 30)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(116, 20)
        Me.dtpEnd.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "To"
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(92, 30)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(116, 20)
        Me.dtpStart.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date from"
        '
        'rtpReport
        '
        Me.rtpReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "CapabilityLogDataSet_vw_CM_Raw_Data"
        ReportDataSource1.Value = Me.vw_CM_Raw_DataBindingSource
        Me.rtpReport.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rtpReport.LocalReport.ReportEmbeddedResource = "Capability_Log.clm_Allocation.rdlc"
        Me.rtpReport.Location = New System.Drawing.Point(7, 110)
        Me.rtpReport.Name = "rtpReport"
        Me.rtpReport.Size = New System.Drawing.Size(870, 479)
        Me.rtpReport.TabIndex = 6
        '
        'vw_CM_Raw_DataTableAdapter
        '
        Me.vw_CM_Raw_DataTableAdapter.ClearBeforeFill = True
        '
        'clm_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(899, 628)
        Me.Controls.Add(Me.GroupBox2)
        Me.Message = ""
        Me.Name = "clm_Report"
        Me.Text = "Allocation report"
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.vw_CM_Raw_DataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CapabilityLogDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rtpReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents vw_CM_Raw_DataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CapabilityLogDataSet As Capability_Log.CapabilityLogDataSet
    Friend WithEvents vw_CM_Raw_DataTableAdapter As Capability_Log.CapabilityLogDataSetTableAdapters.vw_CM_Raw_DataTableAdapter
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtProjects As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtProjectType As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtResource As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtTask As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
