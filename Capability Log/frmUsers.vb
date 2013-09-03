Public Class frmUsers
    Private _Users As New Objects.User

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Object = _Users
        txtName.DataBindings.Add("Text", BS, "Name", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTNumber.DataBindings.Add("Text", BS, "TNumber", True, DataSourceUpdateMode.OnPropertyChanged)
        dtgProfile.DataBindings.Add("DataSource", BS, "Profile_Table", True, DataSourceUpdateMode.OnPropertyChanged)

    End Sub
    Private Function Check_User() As Boolean
        If _Users.TNumber = "" Then
            cmdCancel.PerformClick()
            Dim Msg As String = ""
            Msg = "No user was selected"

            MsgBox(Msg, MsgBoxStyle.Exclamation)
            Me.ShowMessage(Msg, MsgType.Warning)
        End If
    End Function
    Private Sub cmdAddProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim SF As New frmSearch
        Dim NPF As Integer = 0
        NPF = SF.Search(New Objects.Profile)
        Dim PFL As New Objects.Profile(NPF)

        If Not PFL Is Nothing Then
            PFL.Set_Action(Objects.SQL_Action.Insert)
            PFL.Allow_Action(True)
            _Users.Add_Profile(PFL)
        End If

        BS.ResetBindings(False)

    End Sub
    Private Sub cmdRemoveProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        Dim PFL As Integer = (dtgProfile.CurrentRow.Cells("ID").Value)
        _Users.Remove_Profile(PFL)
    End Sub

    Public Overrides Sub Lock_Gui()
        cmdAdd.Enabled = False
        cmdRemove.Enabled = False

        txtTNumber.Enabled = False
        txtName.Enabled = False
    End Sub

    Public Overrides Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)
        cmdAdd.Enabled = True
        cmdRemove.Enabled = True

        txtTNumber.Enabled = True
        txtName.Enabled = True
    End Sub
End Class
