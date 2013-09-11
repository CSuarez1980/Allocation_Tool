Public Class cp_Actuals
    Private _Actuals As New List(Of Objects.Corporate_Projects.CP_Actual)

    Private Sub cp_Actuals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load actuals to be included:
        Dim Act As New DataTable
        Dim cn As New Objects.Connection

        Act = cn.GetTable("Select * From vw_CP_Open_Tasks Where Owner = '" & goUser.TNumber & "'")
        If Act.Rows.Count > 0 Then
            _Actuals.Clear()
            For Each R As DataRow In Act.Rows
                Dim NA As New Objects.Corporate_Projects.CP_Actual(R("Resource_ID"))
                _Actuals.Add(NA)
            Next
        End If

        BS.DataSource = _Actuals
        dtgActuals.DataSource = BS

        Dim NewColumn As New CalendarColumn()
        NewColumn = New CalendarColumn(CalendarFormat.Short_Date, "Actual Date")
        NewColumn.DataPropertyName = "Actual_Date"

        Dim EntryTypeColumn As New EntryTypeColumn
        EntryTypeColumn.DataPropertyName = "Entry_Type"

        Dim ResourceType As New CP_ResourceColumn
        ResourceType.DataPropertyName = "Resource_Type"

        Dim ProjectCol As New CP_ProjectColumn
        ProjectCol.DataPropertyName = "Project_ID"

        dtgActuals.Columns.Add(NewColumn)
        dtgActuals.Columns.Add(EntryTypeColumn)
        dtgActuals.Columns.Add(ResourceType)
        dtgActuals.Columns.Add(ProjectCol)

         dtgActuals.Columns("Record_Date").Visible = False
        dtgActuals.Columns("Resource_Type").Visible = False
        dtgActuals.Columns("Actual_Date").Visible = False
        dtgActuals.Columns("Project_ID").Visible = False
        dtgActuals.Columns("Entry_Type").Visible = False

        dtgActuals.Columns("Actual Date").DisplayIndex = 0
        dtgActuals.Columns("Project").DisplayIndex = 1
        dtgActuals.Columns("ResourceType").DisplayIndex = 2
        dtgActuals.Columns("Value").DisplayIndex = 3
        dtgActuals.Columns("cboEntryType").DisplayIndex = 4

    End Sub

    Private Sub dtgActuals_CellErrorTextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'MsgBox("")
    End Sub

    Private Sub dtgActuals_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgActuals.DataError
        'MsgBox("")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim TG As New Objects.Transaction_Group
        Dim cn As New Objects.Connection

        For Each A As Objects.Corporate_Projects.CP_Actual In _Actuals
            If A.Value > 0 Then
                TG.Include_Transaction(A.Get_Insert)
            End If
        Next

        If cn.Execute(TG) Then
            MsgBox("Actulas saved.", MsgBoxStyle.Information, "Records saved.")
        Else
            MsgBox("Unable to save records.", MsgBoxStyle.Exclamation, "Unable to save records")
        End If
    End Sub
End Class
