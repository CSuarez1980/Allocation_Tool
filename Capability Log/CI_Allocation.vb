Public Class CI_Allocation
    Private _Project As New Objects.Continuous_Improvement.Project
    Private _BS_Tasks As New BindingSource

#Region "Methods"
    Private Sub CI_Allocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Assign global objects:
        Me.Object = _Project
        _BS_Tasks.DataSource = _Project.Tasks

        'Binding properties:
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
        txtName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtStart.DataBindings.Add("Text", BS, "Project_Starts", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEnd.DataBindings.Add("Text", BS, "Project_Ends", True, DataSourceUpdateMode.OnPropertyChanged)
        txtForecast_FTE.DataBindings.Add("Text", BS, "Project_FTE", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDailyHours.DataBindings.Add("Text", BS, "Daily_Hours", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDays_Completed.DataBindings.Add("Text", BS, "Days_Completed", True, DataSourceUpdateMode.OnPropertyChanged)

        cboStatus.DataBindings.Add("SelectedValue", BS, "Status", True, DataSourceUpdateMode.OnPropertyChanged)
        cboCategory.DataBindings.Add("SelectedValue", BS, "Category", True, DataSourceUpdateMode.OnPropertyChanged)
        cboPriority.DataBindings.Add("SelectedValue", BS, "Priority", True, DataSourceUpdateMode.OnPropertyChanged)
        cboService.DataBindings.Add("SelectedValue", BS, "Service_Line", True, DataSourceUpdateMode.OnPropertyChanged)
        cboValue_Stream.DataBindings.Add("SelectedValue", BS, "Value_Stream", True, DataSourceUpdateMode.OnPropertyChanged)

        'Load combos data:
        Dim cn As New Objects.Connection

        'Status:
        With cboStatus
            .DataSource = cn.GetTable("Select [ID], [Description] From [Status]")
            .DisplayMember = "Description"
            .ValueMember = "ID"
        End With

        'Category:
        With cboCategory
            .DataSource = cn.GetTable("Select [ID], [Description] From [Project_Category]")
            .DisplayMember = "Description"
            .ValueMember = "ID"
        End With

        With cboPriority
            .DataSource = cn.GetTable("Select [ID], [Description] From [Project_Priority]")
            .DisplayMember = "Description"
            .ValueMember = "ID"
        End With

        With cboService
            .DataSource = cn.GetTable("Select [ID], [Description] From Service_Line")
            .DisplayMember = "Description"
            .ValueMember = "ID"
        End With

        With cboValue_Stream
            .DataSource = cn.GetTable("Select [ID], [Description] From Value_Stream")
            .DisplayMember = "Description"
            .ValueMember = "ID"
        End With

        dtgTasks.DataSource = _BS_Tasks
        Dim cStart As New CalendarColumn(CalendarFormat.Short_Date, "Start", "Start")
        Dim cEnd As New CalendarColumn(CalendarFormat.Short_Date, "End", "End")

        dtgTasks.Columns.Add(cStart)
        dtgTasks.Columns.Add(cEnd)
        dtgTasks.Columns("Start").Visible = False
        dtgTasks.Columns("End").Visible = False
        dtgTasks.Columns("ID").Visible = False
    End Sub

    Public Overrides Sub Reset_Bindings()
        MyBase.Reset_Bindings()
        _BS_Tasks.ResetBindings(False)
    End Sub


    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        'MyBase.Unlock_GUI(Unlock_Type)

        txtDescription.Enabled = True
        txtName.Enabled = True
        txtStart.Enabled = True
        txtEnd.Enabled = True
        txtForecast_FTE.Enabled = True
        txtDailyHours.Enabled = True
        txtDays_Completed.Enabled = True

        cboCategory.Enabled = True
        cboPriority.Enabled = True
        cboService.Enabled = True
        cboStatus.Enabled = True
        cboValue_Stream.Enabled = True

        dtgTasks.AllowUserToAddRows = True
        dtgTasks.AllowUserToDeleteRows = True
        dtgTasks.ReadOnly = False
    End Sub
    Public Overrides Sub Lock_Gui()
        'MyBase.Lock_Gui()
        txtDescription.Enabled = False
        txtName.Enabled = False
        txtStart.Enabled = False
        txtEnd.Enabled = False
        txtForecast_FTE.Enabled = False
        txtDailyHours.Enabled = False
        txtDays_Completed.Enabled = False

        cboCategory.Enabled = False
        cboPriority.Enabled = False
        cboService.Enabled = False
        cboStatus.Enabled = False
        cboValue_Stream.Enabled = False

        dtgTasks.AllowUserToAddRows = False
        dtgTasks.AllowUserToDeleteRows = False
        dtgTasks.ReadOnly = True

    End Sub

    Private Sub dtgTasks_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgTasks.UserDeletingRow
        If e.Row.Cells("ID").Value <> 0 Then
            If MsgBox("Do you really want to delete this task?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Task?") = MsgBoxResult.Yes Then
                _Project.Delete_Task(e.Row.Cells("ID").Value)
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region
End Class
