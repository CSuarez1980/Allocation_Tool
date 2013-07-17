Public Class frmSearch
    Private _Code As Object = Nothing

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        BS.Filter = "Value Like '" & txtSearch.Text & "%'"
        dtgSearch.Refresh()
    End Sub
    Public Function Search(ByRef oSearch As Object) As Object
        BS.DataSource = oSearch.Search_List()
        dtgSearch.DataSource = BS
        Me.ShowDialog()
        Return _Code
    End Function
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        _Code = Nothing
        Me.Hide()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        _Code = dtgSearch.CurrentRow.Cells("Code").Value
        Me.Hide()
    End Sub

    Private Sub dtgSearch_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgSearch.CellContentDoubleClick
        _Code = dtgSearch.CurrentRow.Cells("Code").Value
        Me.Hide()
    End Sub
End Class
