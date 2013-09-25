Public Class frmProject
    Friend WithEvents _Project As New Objects.Project

    Private Sub frmProject_Category_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler cmdSave.Click, AddressOf Me.Refresh_Tasks
        AddHandler cmdCancel.Click, AddressOf Me.Refresh_Tasks

        Me.Object = _Project
        txtName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
        dtgTask.DataBindings.Add("DataSource", BS, "Task_Table", True, DataSourceUpdateMode.OnPropertyChanged)
        txtStart.DataBindings.Add("Text", BS, "Project_Starts", True, DataSourceUpdateMode.OnPropertyChanged)
        txtEnd.DataBindings.Add("Text", BS, "Project_Ends", True, DataSourceUpdateMode.OnPropertyChanged)
        txtForecast_FTE.DataBindings.Add("Text", BS, "Project_FTE", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDailyHours.DataBindings.Add("Text", BS, "Daily_Hours", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDays_Completed.DataBindings.Add("Text", BS, "Days_Completed", True, DataSourceUpdateMode.OnPropertyChanged)
        chkShow_Task_Deleted.DataBindings.Add("Checked", BS, "Show_Task_Deleted", True, DataSourceUpdateMode.OnPropertyChanged)

        cboPriority.DataBindings.Add("DataSource", BS, "Priority_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboPriority.DataBindings.Add("SelectedValue", BS, "Priority", True, DataSourceUpdateMode.OnPropertyChanged)
        cboPriority.DisplayMember = _Project.Priority_List.Columns("Value").Caption.ToString
        cboPriority.ValueMember() = _Project.Priority_List.Columns("Code").Caption.ToString

        cboService.DataBindings.Add("DataSource", BS, "Service_Line_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboService.DataBindings.Add("SelectedValue", BS, "Service_Line", True, DataSourceUpdateMode.OnPropertyChanged)
        cboService.DisplayMember = _Project.Service_Line_List.Columns("Value").Caption.ToString
        cboService.ValueMember() = _Project.Service_Line_List.Columns("Code").Caption.ToString

        cboStatus.DataBindings.Add("DataSource", BS, "Status_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboStatus.DataBindings.Add("SelectedValue", BS, "Project_Status", True, DataSourceUpdateMode.OnPropertyChanged)
        cboStatus.DisplayMember = _Project.Status_List.Columns("Value").Caption.ToString
        cboStatus.ValueMember() = _Project.Status_List.Columns("Code").Caption.ToString

        cboCategory.DataBindings.Add("DataSource", BS, "Category_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboCategory.DataBindings.Add("SelectedValue", BS, "Category", True, DataSourceUpdateMode.OnPropertyChanged)
        cboCategory.DisplayMember = _Project.Category_List.Columns("Value").Caption.ToString
        cboCategory.ValueMember() = _Project.Category_List.Columns("Code").Caption.ToString

        cboValue_Stream.DataBindings.Add("DataSource", BS, "Value_Stream_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboValue_Stream.DataBindings.Add("SelectedValue", BS, "Value_Stream", True, DataSourceUpdateMode.OnPropertyChanged)
        cboValue_Stream.DisplayMember = _Project.Value_Stream_List.Columns("Value").Caption.ToString
        cboValue_Stream.ValueMember() = _Project.Value_Stream_List.Columns("Code").Caption.ToString
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim FM As New frmTask
        Dim TK As New Objects.Task

        FM.Object = TK
        FM.cmdNew.PerformClick()
        FM.isFromTools = True
        FM.ShowDialog()

        If Not FM.User_Cancel AndAlso Not FM.Closed_By_User Then
            _Project.Add_Task(FM.Object)
            BS.ResetBindings(False)
        End If

        FM.Close()
    End Sub
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim T As New Objects.Task

        T.ID = dtgTask.CurrentRow.Cells("ID_Task").Value
        T.Name = dtgTask.CurrentRow.Cells("Name").Value
        _Project.Remove_Task(T)

    End Sub
    Public Overrides Sub Lock_GUI()
        txtDescription.Enabled = False
        txtName.Enabled = False
        cboCategory.Enabled = False
        cboPriority.Enabled = False
        cboService.Enabled = False
        cboStatus.Enabled = False
        cboValue_Stream.Enabled = False
        cmdAdd.Enabled = False
        cmdRemove.Enabled = False
        cmdEditTask.Enabled = False
    End Sub
    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        txtDescription.Enabled = True
        txtName.Enabled = True
        cboCategory.Enabled = True
        cboPriority.Enabled = True
        cboService.Enabled = True
        cboStatus.Enabled = True
        cboValue_Stream.Enabled = True
        cmdAdd.Enabled = True
        cmdRemove.Enabled = True
        cmdEditTask.Enabled = True
    End Sub
    Private Sub cmdEditTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditTask.Click
        Dim FTask As New frmTask
        Dim oTask As New Objects.Task(dtgTask.CurrentRow.Cells("ID_Task").Value)

        FTask.Object = oTask
        FTask.isFromTools = True
        FTask.cmdEdit.PerformClick()

        FTask.ShowDialog()
        If Not FTask.User_Cancel AndAlso Not FTask.Closed_By_User Then
            oTask.Allow_Action(True)
            oTask.Save()
            _Project.Get_Tasks_In_Project()
            BS.ResetBindings(False)
        End If

    End Sub
    Private Sub Refresh_Tasks()
        _Project.Get_Tasks_In_Project()
        BS.ResetBindings(False)
    End Sub
    Public Sub HideCols() Handles dtgTask.DataSourceChanged
        If dtgTask.ColumnCount > 0 Then
            dtgTask.Columns("Daily Hours").Visible = False
            dtgTask.Columns("Task FTE").Visible = False
        End If
    End Sub
    Sub FixTaskTab() Handles dtgTask.CellEnter

        txtTaskDailyHours.Text = Math.Round(dtgTask.CurrentRow.Cells("Daily hours").Value, 2)
        txtTaskFTEReq.Text = Math.Round(dtgTask.CurrentRow.Cells("Task FTE").Value, 2)

        pgbTask.Maximum = DateDiff(DateInterval.Day, dtgTask.CurrentRow.Cells("Start").Value, dtgTask.CurrentRow.Cells("End").Value)
        If pgbTask.Maximum <> 0 Then
            If dtgTask.CurrentRow.Cells("Start").Value > Now.Date Then
                pgbTask.Maximum = 100
                pgbTask.Value = 0
            Else
                Dim _pgs As Integer = DateDiff(DateInterval.Day, dtgTask.CurrentRow.Cells("Start").Value, Now.Date)
                If _pgs < pgbTask.Maximum Then
                    pgbTask.Value = _pgs
                Else
                    pgbTask.Value = pgbTask.Maximum
                End If
            End If

        Else
            pgbTask.Maximum = 1
            pgbTask.Value = 1
        End If

        lblTaskProgress.Text = "Task progress: " & Math.Round(((pgbTask.Value / pgbTask.Maximum) * 100), 2) & "%"

    End Sub
    Private Sub Load_Project_Progress() Handles _Project.Project_Changed
        Dim _PDays = DateDiff(DateInterval.Day, _Project.Project_Starts, _Project.Project_Ends)

        If _PDays <> 0 Then
            pgbProject.Maximum = _PDays
            Dim _PD = DateDiff(DateInterval.Day, _Project.Project_Starts, Now.Date)

            If _PD < pgbProject.Maximum Then
                pgbProject.Value = _PD
            Else
                pgbProject.Value = pgbProject.Maximum
            End If
        Else
            pgbProject.Maximum = 1
            pgbProject.Value = 1
        End If

        lblProjectProgress.Text = "Project progress: " & Math.Round(((pgbProject.Value / pgbProject.Maximum) * 100), 2) & "%"
    End Sub
    Private Sub Load_Tasks() Handles chkShow_Task_Deleted.CheckStateChanged
        _Project.Get_Tasks_In_Project()
        BS.ResetBindings(False)
    End Sub
    Private Sub Clear() Handles _Project.Project_Clear
        pgbProject.Value = 0
        lblProjectProgress.Text = "Project process: 0%"

        txtTaskDailyHours.Text = 0
        txtTaskFTEReq.Text = 0
        pgbTask.Value = 0

    End Sub
  
  
End Class
