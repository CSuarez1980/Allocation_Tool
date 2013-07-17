﻿Public Class frmCollaborationModule
    Private WithEvents _Project As New Objects.Collaboration_Module.CM_Project

    Dim BS1 As New BindingSource ''Mapping and matching
    Dim BS2 As New BindingSource ''Transactional work
    Dim BS3 As New BindingSource ''Hypercare
    Dim BS4 As New BindingSource ''Metting
    Dim BS5 As New BindingSource ''Scope / Data
    Dim BS6 As New BindingSource ''Expertice

    Private Sub frmCollaborationModule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New Objects.Connection
        Dim Data As New DataTable

        Data = cn.GetTable("Select ID, Type_Description From clm_Project_Type")

        If Data.Rows.Count > 0 Then
            cboProject_Type.DataSource = Data
            cboProject_Type.DisplayMember = "Type_Description"
            cboProject_Type.ValueMember = "ID"
        End If

        Me.Object = _Project
        txtProjectName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtGBSPM.DataBindings.Add("Text", BS, "GBS_PM", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPSSPM.DataBindings.Add("Text", BS, "PSS_PM", True, DataSourceUpdateMode.OnPropertyChanged)
        cboProject_Type.DataBindings.Add("SelectedValue", BS, "Type", True, DataSourceUpdateMode.OnPropertyChanged)




        dtgMapingAndMatching.DataSource = BS1
        dtgTransWork.DataSource = BS2
        dtgHypercare.DataSource = BS3
        dtgMeetings.DataSource = BS4
        dtgScope.DataSource = BS5
        dtgExpertice.DataSource = BS6

        Refresh_Binding()
        Fix_DataGrids()

    End Sub

    Private Sub Fix_DataGrids()
        'Dim NewColumn As New MonthColumn
        Dim NewColumn As New CalendarColumn()

        'Mapping and matching
        With dtgMapingAndMatching
            'Dim C As New CalendarColumn(CalendarFormat.Month_Year)

            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"

            .Columns.Add(NewColumn)
            ' .Columns.Add(C)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        'Transactional work
        With dtgTransWork
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"

            Dim EventColumn As New EventsColumn
            EventColumn.DataPropertyName = "Event"

            Dim EntryTypeColumn As New EntryTypeColumn
            EntryTypeColumn.DataPropertyName = "Entry_Type"

            .Columns.Add(NewColumn)
            .Columns.Add(EventColumn)
            .Columns.Add(EntryTypeColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
            .Columns("Hours").HeaderText = "Value"

            .Columns("cboEvent").DisplayIndex = 3
            .Columns("dtpMonth").DisplayIndex = 4
            .Columns("cboEntryType").DisplayIndex = 5
        End With

        With dtgHypercare
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgMeetings
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgScope
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        With dtgExpertice
            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Month"
            .Columns.Add(NewColumn)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("MonthlyFTE").HeaderText = "Monthly FTE"
        End With

        Fix_Column_Width(dtgMapingAndMatching)
        Fix_Column_Width(dtgTransWork)
        Fix_Column_Width(dtgHypercare)
        Fix_Column_Width(dtgMeetings)
        Fix_Column_Width(dtgScope)
        Fix_Column_Width(dtgExpertice)

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
                    If Not dtgMapingAndMatching.CurrentRow Is Nothing Then
                        dtgMapingAndMatching.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 1
                    If Not dtgTransWork.CurrentRow Is Nothing Then
                        dtgTransWork.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 2
                    If Not dtgHypercare.CurrentRow Is Nothing Then
                        dtgHypercare.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 3
                    If Not dtgMeetings.CurrentRow Is Nothing Then
                        dtgMeetings.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 4
                    If Not dtgScope.CurrentRow Is Nothing Then
                        dtgScope.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
                Case 5
                    If Not dtgExpertice.CurrentRow Is Nothing Then
                        dtgExpertice.CurrentRow.Cells("Resource_Type_ID").Value = Res
                    End If
            End Select
        End If
    End Sub

    Private Sub Refresh_Binding() Handles _Project.Loaded
        BS1.DataSource = _Project.Mapping_Matching.Resources
        BS2.DataSource = _Project.Transactional.Resources
        BS3.DataSource = _Project.HyperCare.Resources
        BS4.DataSource = _Project.Meeting.Resources
        BS5.DataSource = _Project.Scope.Resources
        BS6.DataSource = _Project.Expertise.Resources

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
                If Not dtgMapingAndMatching.CurrentRow Is Nothing Then
                    _Project.Mapping_Matching.Remove_Resource(dtgMapingAndMatching.CurrentRow.Cells("ID").Value)
                End If
            Case 1
                If Not dtgTransWork.CurrentRow Is Nothing Then
                    _Project.Transactional.Remove_Resource(dtgTransWork.CurrentRow.Cells("ID").Value)
                End If
            Case 2
                If Not dtgHypercare.CurrentRow Is Nothing Then
                    _Project.HyperCare.Remove_Resource(dtgHypercare.CurrentRow.Cells("ID").Value)
                End If
            Case 3
                If Not dtgMeetings.CurrentRow Is Nothing Then
                    _Project.Meeting.Remove_Resource(dtgMeetings.CurrentRow.Cells("ID").Value)
                End If
            Case 4
                If Not dtgScope.CurrentRow Is Nothing Then
                    _Project.Scope.Remove_Resource(dtgScope.CurrentRow.Cells("ID").Value)
                End If
            Case 5
                If Not dtgExpertice.CurrentRow Is Nothing Then
                    _Project.Expertise.Remove_Resource(dtgExpertice.CurrentRow.Cells("ID").Value)
                End If
        End Select

        Refresh_Binding()
    End Sub

    Private Sub HideColumns()
        With dtgMapingAndMatching
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("Entry_Type").Visible = False
            .Columns("ID").Visible = False
        End With

        'Transactional work
        With dtgTransWork
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgHypercare
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgMeetings
            .Columns("Event").Visible = False
            .Columns("Month").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgScope
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With

        With dtgExpertice
            .Columns("Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("ID").Visible = False
            .Columns("Entry_Type").Visible = False
        End With
    End Sub

    Private Sub New_Rec() Handles cmdNew.Click
        Refresh_Binding()
    End Sub
End Class
