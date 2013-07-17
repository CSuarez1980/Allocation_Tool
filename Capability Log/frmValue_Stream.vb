Public Class frmValue_Stream
    Private _Value_Stream As New Objects.Value_Stream

    Private Sub frmValue_Stream_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Value_Stream
        txtID.DataBindings.Add("Text", BS, "ID", True, DataSourceUpdateMode.OnPropertyChanged)
        txtDescription.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub

    Public Overrides Sub Lock_Gui()

    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)

    End Sub

End Class
