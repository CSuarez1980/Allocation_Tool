﻿Public Class pss_Forecast
    Private WithEvents _Project As New Objects.PSS_Projects.PSS_Project
    Dim BS1 As New BindingSource ''Discover
    Dim BS2 As New BindingSource ''Design
    Dim BS3 As New BindingSource ''Qualify
    Dim BS4 As New BindingSource ''Ready
    Dim BS5 As New BindingSource ''Launch
    Dim BS6 As New BindingSource ''Documents

    Private Sub frmCollaborationModule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New Objects.Connection
        Me.Object = _Project
        txtProjectName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtGBSPM.DataBindings.Add("Text", BS, "GBS_PM", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPSSPM.DataBindings.Add("Text", BS, "PSS_PM", True, DataSourceUpdateMode.OnPropertyChanged)

        cboStatus.DataSource = cn.GetTable("Select ID, Description From Status")
        cboStatus.DisplayMember = "Description"
        cboStatus.ValueMember = "ID"

        dtgDiscover.DataSource = BS1
        dtgDesign.DataSource = BS2
        dtgQualify.DataSource = BS3
        dtgReady.DataSource = BS4
        dtgLaunch.DataSource = BS5
        dtgDocuments.DataSource = BS6

        Refresh_Binding()
        Fix_DataGrids()
    End Sub
    Private Sub Fix_DataGrids()
        Dim NewColumn As New CalendarColumn()
        With dtgDiscover
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"

            .Columns.Add(NewColumn)
            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgDesign
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"

            .Columns.Add(NewColumn)
            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgQualify
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgReady
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgLaunch
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        Fix_Column_Width(dtgDiscover)
        Fix_Column_Width(dtgDesign)
        Fix_Column_Width(dtgQualify)
        Fix_Column_Width(dtgReady)
        Fix_Column_Width(dtgLaunch)

        HideColumns()
    End Sub
    Private Sub Fix_Column_Width(ByRef Grid As DataGridView)
        With Grid
            .Columns("Resource_Type_ID").Width = 40
            .Columns("Event").Width = 150
            .Columns("Res_Type_Description").Width = 300
            .Columns("MonthlyFTE").Width = 60
            .Columns("Month").Width = 120
            .Columns("Hours").Width = 50
        End With
    End Sub
    Private Sub cmdShowResources_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowResources.Click
        Dim SF As New frmSearch
        Dim Res As Object
        Res = SF.Search(New Objects.Collaboration_Module.Resource_Type)

        If Not Res Is Nothing Then
            Select Case tabPhases.SelectedIndex
                Case 0
                    If Not dtgDiscover.CurrentRow Is Nothing Then
                        dtgDiscover.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 1
                    If Not dtgDesign.CurrentRow Is Nothing Then
                        dtgDesign.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 2
                    If Not dtgQualify.CurrentRow Is Nothing Then
                        dtgQualify.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 3
                    If Not dtgReady.CurrentRow Is Nothing Then
                        dtgReady.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 4
                    If Not dtgLaunch.CurrentRow Is Nothing Then
                        dtgLaunch.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
            End Select
        End If
    End Sub
    Private Sub Refresh_Binding() Handles _Project.Loaded
        BS1.DataSource = _Project.Discover.Resources
        BS2.DataSource = _Project.Design.Resources
        BS3.DataSource = _Project.Qualify.Resources
        BS4.DataSource = _Project.Ready.Resources
        BS5.DataSource = _Project.Launch.Resources
        BS6.DataSource = _Project.Documents

        BS.ResetBindings(False)
        BS1.ResetBindings(False)
        BS2.ResetBindings(False)
        BS3.ResetBindings(False)
        BS4.ResetBindings(False)
        BS5.ResetBindings(False)
        BS6.ResetBindings(False)

        HideColumns()
    End Sub
    Private Sub cmdDeleteResource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteResource.Click
        Select Case tabPhases.SelectedIndex
            Case 0
                If Not dtgDiscover.CurrentRow Is Nothing Then
                    _Project.Discover.Remove_Resource(dtgDiscover.CurrentRow.Cells("ID").Value)
                End If
            Case 1
                If Not dtgDesign.CurrentRow Is Nothing Then
                    _Project.Design.Remove_Resource(dtgDesign.CurrentRow.Cells("ID").Value)
                End If
            Case 2
                If Not dtgQualify.CurrentRow Is Nothing Then
                    _Project.Qualify.Remove_Resource(dtgQualify.CurrentRow.Cells("ID").Value)
                End If
            Case 3
                If Not dtgReady.CurrentRow Is Nothing Then
                    _Project.Ready.Remove_Resource(dtgReady.CurrentRow.Cells("ID").Value)
                End If
            Case 4
                If Not dtgLaunch.CurrentRow Is Nothing Then
                    _Project.Launch.Remove_Resource(dtgLaunch.CurrentRow.Cells("ID").Value)
                End If
        End Select

        Refresh_Binding()
    End Sub
    Private Sub HideColumns()
        With dtgDiscover
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("Entry_Type").Visible = False
            .Columns("ID").Visible = False
        End With

        With dtgDesign
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgQualify
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgReady
            .Columns("Event").Visible = False
            .Columns("Month").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgLaunch
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

    End Sub
    Private Sub New_Rec() Handles cmdNew.Click
        Refresh_Binding()
    End Sub
    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        txtProjectName.ReadOnly = False
        txtGBSPM.ReadOnly = False
        txtPSSPM.ReadOnly = False
        dtgDiscover.ReadOnly = False
        dtgDesign.ReadOnly = False
        dtgQualify.ReadOnly = False
        dtgReady.ReadOnly = False
        dtgLaunch.ReadOnly = False
        cboStatus.Enabled = True

        txtDesignAllocation.ReadOnly = False
        txtDesignHours.ReadOnly = False
        txtDiscoveryAllocation.ReadOnly = False
        txtDiscoveryHours.ReadOnly = False
        txtLaunchAllocation.ReadOnly = False
        txtLaunchHours.ReadOnly = False
        txtQualifyAllocation.ReadOnly = False
        txtQualifyHours.ReadOnly = False
        txtReadyAllocation.ReadOnly = False
        txtReadyHours.ReadOnly = False

        cmdShowResources.Enabled = True
        cmdDeleteResource.Enabled = True
    End Sub
    Public Overrides Sub Lock_Gui()
        txtProjectName.ReadOnly = True
        txtGBSPM.ReadOnly = True
        txtPSSPM.ReadOnly = True
        dtgDiscover.ReadOnly = True
        dtgDesign.ReadOnly = True
        dtgQualify.ReadOnly = True
        dtgReady.ReadOnly = True
        dtgLaunch.ReadOnly = True
        cboStatus.Enabled = False

        txtDesignAllocation.ReadOnly = True
        txtDesignHours.ReadOnly = True
        txtDiscoveryAllocation.ReadOnly = True
        txtDiscoveryHours.ReadOnly = True
        txtLaunchAllocation.ReadOnly = True
        txtLaunchHours.ReadOnly = True
        txtQualifyAllocation.ReadOnly = True
        txtQualifyHours.ReadOnly = True
        txtReadyAllocation.ReadOnly = True
        txtReadyHours.ReadOnly = True

        cmdShowResources.Enabled = False
        cmdDeleteResource.Enabled = False
    End Sub
    Private Sub cmdUploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadFile.Click
        fodFile.ShowDialog()
        Dim F As New Objects.PSS_Projects.PSS_Project_Files
        F.File_Name = fodFile.SafeFileName
        If F.Upload_File(fodFile.FileName, goUser.TNumber, _Project.ID) Then

            ShowMessage("File: " & sfdFile.FileName & " uploaded.", MsgType.Information)
            _Project.Documents.Add(F)
            Refresh_Binding()
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownloadFile.Click
        Dim F As New Objects.Collaboration_Module.CM_Project_Files(dtgDocuments.CurrentRow.Cells("File_ID").Value)
        sfdFile.FileName = F.File_Name
        sfdFile.Filter = "Files (*." & F.Get_Default_Ext & ")|*." & F.Get_Default_Ext
        sfdFile.DefaultExt = F.Get_Default_Ext

        If sfdFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If F.Download_File(sfdFile.FileName & "." & F.Get_Default_Ext) Then
                ShowMessage("File: " & sfdFile.FileName & " downloaded.", MsgType.Information)
            End If
        End If
        Refresh_Binding()
    End Sub
    Private Sub cmdDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteFile.Click
        Dim File As New Objects.PSS_Projects.PSS_Project_Files(dtgDocuments.CurrentRow.Cells("File_ID").Value)
        If File.Delete_File() Then
            MsgBox("File deleted.", MsgBoxStyle.Information)
            For Each D In _Project.Documents
                If (D.File_ID = File.File_ID) Then
                    _Project.Documents.Remove(D)
                    Exit For
                End If
                _Project.Documents.Remove(File)
            Next
            Me.ShowMessage("File removed from this project.", MsgType.Information)
        End If
        Refresh_Binding()
    End Sub
End Class
