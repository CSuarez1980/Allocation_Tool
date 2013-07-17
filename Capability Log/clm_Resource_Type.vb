Public Class clm_Resource_Type
    Private WithEvents _Resource_Type As New Objects.Collaboration_Module.Resource_Type

    Private Sub clm_Resource_Type_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Resource_Type
        txtID.DataBindings.Add("Text", BS, "ID", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub
End Class
