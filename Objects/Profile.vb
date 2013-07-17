Public Class Profile
    Inherits Objects.Base


#Region "Events"
    Public Event Profile_Changed()
#End Region
#Region "Variables"
    Private _ID As Integer
    Private _Description As String
    Private _Forms As New List(Of Objects.Forms)
    Private _KEY As String
    Private _Forms_Table As DataTable
#End Region
#Region "Properties"
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Public ReadOnly Property Forms() As List(Of Objects.Forms)
        Get
            Return _Forms
        End Get
    End Property
    Public ReadOnly Property Forms_Table() As DataTable
        Get
            Return _Forms_Table
        End Get
    End Property

#End Region
#Region "Methods"
    Private Function GetID_By_Key(ByVal pKey As String) As Integer
        Dim T As New Transaction
        Dim ID As New DataTable

        T.SQL_String = "Select ID From Profile Where [KEY] = @KEY"
        T.Include_Parameter("@KEY", pKey)

        ID = GetTable(T)
        If ID.Rows.Count > 0 Then
            Return ID(0)(0)
        Else
            Return Nothing
        End If
    End Function
    Private Function FindDescription(ByVal pKey As String, Optional ByVal pIDPRF As Integer = 0) As Boolean
        Dim T As New Transaction
        Dim ID As New DataTable

        T.SQL_String = "Select Count(ID) From Profile Where ((Description = @Description) And (ID <> @ID))"
        T.Include_Parameter("@Description", pKey)
        T.Include_Parameter("@ID", pIDPRF)

        ID = GetTable(T)

        If ID.Rows(0)(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Overrides Sub Clear()
        _ID = 0
        _Description = ""
        _Forms.Clear()
        _KEY = Now().ToFileTimeUtc
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From Profile Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        TG.Include_Transaction(T)

        T = New Transaction
        T.SQL_String = "Delete From Profile_Form Where ID_Profile = @ID-Profile"
        T.Include_Parameter("@ID-Profile", _ID)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group
        Dim TB As New DataTable

        If Not FindDescription(_Description) Then
            _KEY = Now().ToFileTimeUtc

            T.SQL_String = "Insert Into Profile (Description, [KEY]) Values(@PRFDS, @KEYPF)"
            T.Include_Parameter("@PRFDS", _Description)
            T.Include_Parameter("@KEYPF", _KEY)

            TG.Include_Transaction(T)
            If Execute(TG) Then
                _ID = GetID_By_Key(_KEY)
                TG = New Transaction_Group

                For Each F As Objects.Forms In _Forms
                    T = New Transaction
                    T.SQL_String = "Insert Into Profile_Form(ID_Profile, ID_Form) Values(@IDPRF, @IDFRM)"
                    T.Include_Parameter("@IDFRM", F.ID)
                    T.Include_Parameter("@IDPRF", _ID)

                    TG.Include_Transaction(T)
                Next
                Return TG
            End If
        Else
            MsgBox("La descripción del perfil ya se encuentra registrada.", MsgBoxStyle.Exclamation, "Perfil encontrado")
            Return Nothing
        End If
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select ID as Code, Description as Value From Profile"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From Profile"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where ID = @ID"
            T.Include_Parameter("@ID", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        If Not FindDescription(_Description, _ID) Then
            Dim T As New Transaction
            Dim TG As New Transaction_Group

            T.SQL_String = "Update Profile Set Description = @PRFDS Where ID = @IDPRF"
            T.Include_Parameter("@IDPRF", _ID)
            T.Include_Parameter("@PRFDS", _Description)

            TG.Include_Transaction(T)

            For Each F As Objects.Forms In _Forms
                Select Case F.SQL_Action
                    Case SQL_Action.Insert
                        T = New Transaction
                        T.SQL_String = "Insert Into Profile_Form (ID_Profile, ID_Form) Values(@IDPRF, @IDFRM)"

                        T.Include_Parameter("@IDPRF", _ID)
                        T.Include_Parameter("@IDFRM", F.ID)
                        TG.Include_Transaction(T)

                    Case SQL_Action.Delete
                        T = New Transaction
                        T.SQL_String = "Delete From Profile_Form Where ((ID_Profile = @IDPRF) And (ID_Form = @IDFRM))"

                        T.Include_Parameter("@IDPRF", _ID)
                        T.Include_Parameter("@IDFRM", F.ID)
                        TG.Include_Transaction(T)
                End Select
            Next

            Return TG
        Else
            MsgBox("La descripción del perfil ya se encuentra registrada." & Chr(13) & Chr(13) & "Por favor modifique la descripción e intente de nuevo.", MsgBoxStyle.Exclamation, "Perfil encontrado")
            Return Nothing
        End If
    End Function
    Public Sub Add_Form(ByVal pForm As Objects.Forms)
        Dim Found As Boolean = False
        For Each FM As Objects.Forms In _Forms
            If FM.ID = pForm.ID Then
                Found = True
                Exit For
            End If
        Next

        If Not Found Then
            pForm.Allow_Action(True)
            pForm.SQL_Action = SQL_Action.Insert
            _Forms.Add(pForm)
            Get_Forms_In_Profile(False)
        End If

        RaiseEvent Profile_Changed()
    End Sub
    Public Sub Remove_Form(ByVal pForm As String)
        For Each P As Objects.Forms In _Forms
            If P.ID = pForm Then
                P.Allow_Action(True)
                P.SQL_Action = SQL_Action.Delete
                Get_Forms_In_Profile(False)
            End If
        Next
        RaiseEvent Profile_Changed()
    End Sub
    Public Sub Get_Forms_In_Profile(Optional ByVal Get_From_DataBase As Boolean = True)

        If Get_From_DataBase Then
            Dim DB As New Connection
            Dim TR As New Transaction

            TR.SQL_String = "Select  Profile_Form.ID_Form as [ID Form], Forms.Description From Forms INNER JOIN Profile_Form ON Forms.ID = Profile_Form.ID_FOrm Where (Profile_Form.ID_Profile = @IDPRF)"
            TR.Include_Parameter("@IDPRF", _ID)
            _Forms_Table = DB.GetTable(TR)
            If Not _Forms_Table Is Nothing Then
                For Each R As DataRow In _Forms_Table.Rows
                    _Forms.Add(New Objects.Forms(R("ID Form")))
                Next
            End If
        Else
            'If _Forms_Table Is Nothing Then
            '    _Forms_Table = New DataTable
            '    _Forms_Table.Columns.Add("ID Form")
            '    _Forms_Table.Columns.Add("Description")
            'End If

            '_Forms_Table.Clear()

            'For Each P As Objects.Forms In _Forms
            '    If Not P.SQL_Action = SQL_Action.Delete Then
            '        Dim R As DataRow
            '        R = _Forms_Table.NewRow()
            '        R("ID Form") = P.ID
            '        R("Description") = P.Description

            '        _Forms_Table.Rows.Add(R)
            '    End If
            'Next

        End If
        RaiseEvent Profile_Changed()
    End Sub
    Public Sub New()
        Clear()
    End Sub
    Public Sub New(ByVal pIDPRF As Integer)
        If Load(pIDPRF) Then
            _ID = Data(0)("ID")
            _KEY = Data(0)("KEY")
            _Description = Data(0)("Description")

            Dim FRM As New DataTable
            Dim T As New Transaction
            Dim CN As New Connection
            Dim ID As New DataTable

            T.SQL_String = "Select ID_Form From Profile_Form Where ID_Profile = @IDPRF"
            T.Include_Parameter("@IDPRF", _ID)

            FRM = CN.GetTable(T)
            If Not FRM Is Nothing Then
                For Each r As DataRow In FRM.Rows
                    Dim F As New Objects.Forms(r("ID_Form"))
                    If Not F.ID Is Nothing Then
                        _Forms.Add(F)
                    End If
                Next
            End If
        End If
    End Sub
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        If Code_ID = Nothing Then
            Code_ID = _ID
        End If

        If MyBase.Load(Code_ID) Then
            _ID = Data.Rows(0)("ID")
            _KEY = Data.Rows(0)("KEY")
            _Description = Data.Rows(0)("Description")
            Get_Forms_In_Profile()
        End If
    End Function
#End Region

End Class
