Public Class frmTask
    Private _Task As New Objects.Task

    Private Sub frmTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.isFromTools Then
            Me.Object = _Task
        Else
            _Task.Show_Deleted = True
        End If

        txtFTE.DataBindings.Add("Text", BS, "Task_Daily_FTE", True, DataSourceUpdateMode.OnPropertyChanged)
        txtHours.DataBindings.Add("Text", BS, "Daily_Hours", True, DataSourceUpdateMode.OnPropertyChanged)
        txtOwner.DataBindings.Add("Text", BS, "Owner", True, DataSourceUpdateMode.OnPropertyChanged)
        txtName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpEnd.DataBindings.Add("Value", BS, "End", True, DataSourceUpdateMode.OnPropertyChanged)
        dtpStart.DataBindings.Add("Value", BS, "Start", True, DataSourceUpdateMode.OnPropertyChanged)
        chkDelInd.DataBindings.Add("Checked", BS, "Delete_Indicator", True, DataSourceUpdateMode.OnPropertyChanged)

        cboStatus.DataBindings.Add("DataSource", BS, "Status_List", True, DataSourceUpdateMode.OnPropertyChanged)
        cboStatus.DataBindings.Add("SelectedValue", BS, "Task_Status", True, DataSourceUpdateMode.OnPropertyChanged)
        cboStatus.DisplayMember = _Task.Status_List.Columns("Value").Caption.ToString
        cboStatus.ValueMember() = _Task.Status_List.Columns("Code").Caption.ToString

    End Sub

    Public Overrides Sub Lock_Gui()

    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)

    End Sub
End Class
