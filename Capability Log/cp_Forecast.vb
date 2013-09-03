Public Class cp_Forecast
    Private WithEvents _Project As New Objects.Corporate_Projects.CP_Project
    Dim BS1 As New BindingSource

    Private Sub cp_Forecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New Objects.Connection
        Dim Data As New DataTable

        'Load cboProject_Type:
        cboProject_Type.DataSource = cn.GetTable("Select ID, Type_Description From clm_Project_Type")
        cboProject_Type.DisplayMember = "Type_Description"
        cboProject_Type.ValueMember = "ID"

        'Load cboStatus 
        cboStatus.DataSource = cn.GetTable("Select ID, Description From Status")
        cboStatus.DisplayMember = "Description"
        cboStatus.ValueMember = "ID"

        Me.Object = _Project
        txtProjectName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtGBSPM.DataBindings.Add("Text", BS, "GBS_PM", True, DataSourceUpdateMode.OnPropertyChanged)
        txtPSSPM.DataBindings.Add("Text", BS, "PSS_PM", True, DataSourceUpdateMode.OnPropertyChanged)
        cboProject_Type.DataBindings.Add("SelectedValue", BS, "Type", True, DataSourceUpdateMode.OnPropertyChanged)
        cboStatus.DataBindings.Add("SelectedValue", BS, "Status", True, DataSourceUpdateMode.OnPropertyChanged)

        BS1.DataSource = _Project.Tasks
        dtgResources.DataSource = BS1
        Fix_DataGrid()

    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        txtProjectName.ReadOnly = False
        txtGBSPM.ReadOnly = False
        txtPSSPM.ReadOnly = False
        cboProject_Type.Enabled = True
        cboStatus.Enabled = True
        dtgResources.ReadOnly = False

        cmdShowResources.Enabled = True
        cmdDeleteResource.Enabled = True
    End Sub
    Public Overrides Sub Lock_Gui()
        txtProjectName.ReadOnly = True
        txtGBSPM.ReadOnly = True
        txtPSSPM.ReadOnly = True
        cboProject_Type.Enabled = False
        cboStatus.Enabled = False
        dtgResources.ReadOnly = True

        cmdShowResources.Enabled = False
        cmdDeleteResource.Enabled = False
    End Sub

    Private Sub Refresh_Binding() Handles _Project.Loaded
        BS1.DataSource = _Project.Tasks
        BS.ResetBindings(False)
        BS1.ResetBindings(False)
    End Sub

    Private Sub cmdShowResources_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowResources.Click
        Dim SF As New frmSearch
        Dim Res As Object
        Res = SF.Search(New Objects.Collaboration_Module.Resource_Type)

        If Not Res Is Nothing Then
            If Not dtgResources.CurrentRow Is Nothing Then
                dtgResources.CurrentRow.Cells("Resource_Type_ID").Value = Res
            End If
        End If
    End Sub

    Private Sub cmdDeleteResource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteResource.Click
        If Not dtgResources.CurrentRow Is Nothing Then
            ' _Project.Tasks.Remove_Resource(dtgResources.CurrentRow.Cells("ID").Value)
        End If
        Refresh_Binding()
    End Sub

    Private Sub dtgResources_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgResources.UserDeletingRow
        If e.Row.Cells("ID").Value <> 0 Then
            If MsgBox("Do you really want to delete this resource?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Resource?") = MsgBoxResult.Yes Then
                _Project.Delete_Resource(e.Row.Cells("ID").Value)
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Fix_DataGrid()
        'Dim NewColumn As New MonthColumn
        Dim NewColumn As New CalendarColumn()

        'Mapping and matching
        With dtgResources
            'Dim C As New CalendarColumn(CalendarFormat.Month_Year)

            NewColumn = New CalendarColumn(CalendarFormat.Month_Year)
            NewColumn.DataPropertyName = "Task_Month"


            Dim EventColumn As New EventsColumn
            EventColumn.DataPropertyName = "Event"

            Dim EntryTypeColumn As New EntryTypeColumn
            EntryTypeColumn.DataPropertyName = "Entry_Type"

            .Columns.Add(NewColumn)
            .Columns.Add(EventColumn)
            .Columns.Add(EntryTypeColumn)
            ' .Columns.Add(C)

            .Columns("Resource_Type_ID").HeaderText = "ID"
            .Columns("Res_Type_Description").HeaderText = "Resource Type"
            .Columns("FTE").HeaderText = "Monthly FTE"

            .Columns("Resource_Type_ID").Width = 40
            .Columns("Event").Width = 150
            .Columns("Res_Type_Description").Width = 300
            .Columns("FTE").Width = 60
            .Columns("Task_Month").Width = 120
            .Columns("Value").Width = 50

            .Columns("Task_Month").Visible = False
            .Columns("Event").Visible = False
            .Columns("Entry_Type").Visible = False
            .Columns("ID").Visible = False

            .Columns("cboEvent").DisplayIndex = 3
            .Columns("dtpMonth").DisplayIndex = 7
            .Columns("cboEntryType").DisplayIndex = 9

        End With

        'HideColumns()
    End Sub
   
    
End Class
