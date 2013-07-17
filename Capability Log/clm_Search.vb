Public Class clm_Search
    Public Sub Set_Object(ByRef SearchList As List(Of Objects.Collaboration_Module.Variants.clm_Var))
        BS.Clear()
        BS.DataSource = SearchList
    End Sub
    Private Sub clm_Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgData.DataSource = BS
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        For Each R As DataGridViewRow In dtgData.Rows
            R.Cells("Selected").Value = ToolStripButton2.Checked
        Next
    End Sub

    Private Sub cmdAcept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAcept.Click
        dtgData.EndEdit()
        Me.Hide()
    End Sub
End Class
