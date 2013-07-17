Public Class clm_Tasks_Type
    Private WithEvents _Task_Type As New Objects.Collaboration_Module.Task_Type

    Private Sub clm_Tasks_Type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Task_Type
        txtID.DataBindings.Add("Text", BS, "ID", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
End Class
