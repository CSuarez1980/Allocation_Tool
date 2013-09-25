Public Enum MsgType
    [Warning] = 1
    [Error] = 2
    [Information] = 3
End Enum
Public Enum Unlock_Type
    [Create_Record] = 1
    [Edit_Record] = 2
End Enum
Public Class frmMant
    Private _Object As Object
    Private _isFromTools As Boolean = False
    Private _User_Cancel As Boolean = False
    Private _Closed_By_User As Boolean = True

#Region "Events"
    Public Event New_Record()
    Public Event Edit_Record()
    Public Event Delete_Record()
    Public Event Save_Record()
#End Region

#Region "Properties"
    Public Property isFromTools() As Boolean
        Get
            Return _isFromTools
        End Get
        Set(ByVal value As Boolean)
            _isFromTools = value
        End Set
    End Property
    Public Property Closed_By_User() As Boolean
        Get
            Return _Closed_By_User
        End Get
        Set(ByVal value As Boolean)
            _Closed_By_User = value
        End Set
    End Property
    Public Property [Object]() As Object
        Get
            Return _Object
        End Get
        Set(ByVal value As Object)
            _Object = value
            BS.DataSource = _Object
        End Set
    End Property
    Public Property User_Cancel() As Boolean
        Get
            Return _User_Cancel
        End Get
        Set(ByVal value As Boolean)
            _User_Cancel = value
        End Set
    End Property
#End Region
#Region "Methods"
    Private Sub ShowTools()
        Me.cmdNew.Visible = True
        Me.cmdEdit.Visible = True
        Me.cmdDelete.Visible = True
        Me.cmdSearch.Visible = True
        Me.cmdCancel.Visible = False
        Me.cmdSave.Visible = False
    End Sub
    Private Sub HideTools()
        Me.cmdNew.Visible = False
        Me.cmdEdit.Visible = False
        Me.cmdDelete.Visible = False
        Me.cmdSearch.Visible = False
        Me.cmdCancel.Visible = True
        Me.cmdSave.Visible = True
    End Sub
    Private Sub Get_New(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        _Object.Set_Action(Objects.SQL_Action.Insert)
        _Object.clear()
        Reset_Bindings()
        HideTools()
        Unlock_GUI(Unlock_Type.Create_Record)
        ShowMessage("Create new record.", MsgType.Information)
        RaiseEvent New_Record()
    End Sub
    Private Sub Edit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        _Object.Set_Action(Objects.SQL_Action.Update)
        HideTools()
        Unlock_GUI(Unlock_Type.Edit_Record)
        ShowMessage("Edit record.", MsgType.Information)
        RaiseEvent Edit_Record()
    End Sub
    Private Sub Delete(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If MsgBox("Do you really want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete record") = MsgBoxResult.Yes Then
            _Object.Set_Action(Objects.SQL_Action.Delete)
            _Object.Allow_Action(True)
            _Object.save()
            RaiseEvent Delete_Record()
        End If
    End Sub
    Private Sub Save(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Reset_Bindings()
        If Not _isFromTools Then
            _Object.Allow_Action(True)
            If _Object.save() Then
                ShowMessage("Record saved.", MsgType.Information)
            Else
                ShowMessage("Record couldn't be saved." & Chr(13) & Err.Description, MsgType.Error)
            End If
        Else
            _User_Cancel = False
            _Closed_By_User = False
            Me.Hide()
        End If

        ShowTools()
        Lock_Gui()
        RaiseEvent Save_Record()
    End Sub
    Private Sub Cancel(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If Not _isFromTools Then
            ShowTools()
            ShowMessage("Canceled by user.", MsgType.Information)
        Else
            _User_Cancel = True
            _Closed_By_User = False
            Me.Hide()
        End If
        Reset_Bindings()
        Lock_GUI()
    End Sub
    Private Sub Search(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim SF As New frmSearch
        Dim Res As Object

        Res = SF.Search(_Object)
        If Not Res Is Nothing Then
            _Object.load(Res)
            Reset_Bindings()
        End If
    End Sub

    Public Overridable Sub Unlock_GUI(Optional ByVal Unlock_Type As Unlock_Type = Unlock_Type.Create_Record)

    End Sub
    Public Overridable Sub Lock_Gui()

    End Sub
#End Region


End Class
