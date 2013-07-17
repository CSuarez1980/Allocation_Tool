Public Class frmTask_Entry
    Private _Projects As DataTable
    Private _Task_List As New List(Of Objects.Task)
    Private _Task As DataTable

    Private Sub frmTask_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New Objects.Connection
        Dim Tr As New Objects.Transaction

        Tr.Set_SQLString("Select Distinct ID, [Project Name], [Project Description] From vw_Project_Task Where ((Owner = @Owner) And (([Start] <= @Date) And ([End] >= @Date))) ")
        Tr.Include_Parameter("@Owner", goUser.TNumber)
        Tr.Include_Parameter("@Date", Now.Date)

        _Projects = db.GetTable(Tr)
        If Not _Projects Is Nothing Then
            dtgProjects.DataSource = _Projects
        Else
            MsgBox("You don't have actives projects at this moment.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub dtgProjects_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgProjects.RowEnter
        If dtgProjects.RowCount > 0 Then
            If dtgProjects.Rows(e.RowIndex).Cells("ID").Value <> Nothing Then
                Dim db As New Objects.Connection
                Dim Tr As New Objects.Transaction

                Tr.Set_SQLString("Select Distinct CAST(0 AS bit) AS Flag, [Task ID], [Task Name] From vw_Project_Task Where ((Owner = @Owner) And (ID = @ID) And (([Start] <= @Date) And ([End] >= @Date)))")
                Tr.Include_Parameter("@ID", dtgProjects.Rows(e.RowIndex).Cells("ID").Value)
                Tr.Include_Parameter("@Date", Now.Date)
                Tr.Include_Parameter("@Owner", Environ("USERID"))
                _Task = db.GetTable(Tr)

                dtgTask.DataSource = _Task
                dtgTask.Columns("Task ID").ReadOnly = True
                dtgTask.Columns("Task Name").ReadOnly = True

            End If
        End If
    End Sub

    Private Sub cmdSetEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetEntry.Click
        dtgTask.EndEdit()
        _Task_List.Clear()

        For Each R As DataGridViewRow In dtgTask.Rows
            If R.Cells("Flag").Value Then
                Dim TE As New Objects.Task(R.Cells("Task ID").Value)
                _Task_List.Add(TE)
            End If
        Next

        If _Task_List.Count > 0 Then
            Dim frm As New frmTask_Entry_Values
            frm.Tasks = _Task_List
            frm.ShowDialog()
        End If
    End Sub

End Class
