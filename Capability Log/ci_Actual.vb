Public Class ci_Actual
    Private _Actuals As New List(Of Objects.Continuous_Improvement.Actual)

    Private Sub ci_Actual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BS.DataSource = _Actuals
        dtgActuals.DataSource = BS
        LoadInfo()
    End Sub

    Private Sub LoadInfo()
        _Actuals.Clear()

        Dim Data As New DataTable
        Dim cn As New Objects.Connection

        'Load today's records:
        Data = cn.GetTable("Select * From vw_CI_Task Where (CONVERT(varchar(10), Date, 101) = CONVERT(varchar(10), {fn NOW()}, 101)) AND Owner = '" & Environ("USERID") & "'")
        If Data.Rows.Count > 0 Then
            For Each R As DataRow In Data.Rows
                _Actuals.Add(New Objects.Continuous_Improvement.Actual(R("Date"), R("Project ID"), R("Project Name"), R("Task ID"), R("Task Name"), R("Hours Required"), R("Hours Saved")))
            Next
        End If
        Reset_Bindings()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        dtgActuals.EndEdit()
        For Each A As Objects.Continuous_Improvement.Actual In _Actuals
            A.Insert()
        Next
        LoadInfo()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim F As New ci_New_Actual_Line
        Dim A As New Objects.Continuous_Improvement.New_Actual_Line

        F.Object = A
        F.ShowDialog()

        If Not F.User_Cancel Then
            _Actuals.Add(New Objects.Continuous_Improvement.Actual(Now.Date, A.Project_ID, A.Project_Name, A.Task_ID, A.Task_Name, 0, 0))
            Reset_Bindings()
        End If
    End Sub
End Class
