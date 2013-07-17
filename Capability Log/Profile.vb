Public Class Profile
    Private WithEvents _Profile As New Objects.Profile
    Private _BSForms As New BindingSource


    Private Sub STPF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Profile
        _BSForms.DataSource = _Profile.Forms

        txtProfile.DataBindings.Add("Text", BS, "Description", True, DataSourceUpdateMode.OnPropertyChanged)
        'dtgForms.DataBindings.Add("DataSource", BS, "Forms_Table", True, DataSourceUpdateMode.OnPropertyChanged)
        dtgForms.DataSource = _BSForms
    End Sub

   
    'Private Function Check_User() As Boolean
    '    If _Profile.ID = 0 Then
    '        cmdCancel.PerformClick()
    '        Dim Msg As String = ""
    '        Msg = "No se ha seleccionado ningún perfil"

    '        MsgBox(Msg, MsgBoxStyle.Exclamation)
    '        Me.ShowMessage(Msg, MsgType.Warning)
    '    End If
    'End Function

    Private Sub cmdAddform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddForm.Click
        Dim SF As New frmSearch
        Dim NFM As String = ""
        NFM = SF.Search(New Objects.Forms)
        Dim FRM As New Objects.Forms(NFM)

        If Not FRM Is Nothing Then
            FRM.Set_Action(Objects.SQL_Action.Insert)
            FRM.Allow_Action(True)
            _Profile.Add_Form(FRM)
        End If
        BS.ResetBindings(False)
        _BSForms.ResetBindings(False)
    End Sub
    Private Sub cmdRemoveProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveForm.Click
        Dim FRM As String = (dtgForms.CurrentRow.Cells("ID Form").Value)
        _Profile.Remove_Form(FRM)
    End Sub

    Public Overrides Sub Lock_Gui()
        cmdAddForm.Enabled = False
        cmdRemoveForm.Enabled = False
    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        cmdAddForm.Enabled = True
        cmdRemoveForm.Enabled = True
    End Sub

    Private Sub Profile_Changed() Handles _Profile.Profile_Changed
        BS.ResetBindings(False)
        _BSForms.ResetBindings(False)
    End Sub
End Class
