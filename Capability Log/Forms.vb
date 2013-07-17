Public Class Forms
    Private _Form As New Objects.Forms

    Private Sub frmProject_Category_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Form
        txtID.DataBindings.Add("Text", BS, "ID", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub

    Public Overrides Sub Lock_Gui()
        txtID.Enabled = False
        txtDescription.Enabled = False
    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        txtID.Enabled = False
        txtDescription.Enabled = True
    End Sub
End Class
