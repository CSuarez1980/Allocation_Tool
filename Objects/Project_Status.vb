Public Class Project_Status
    Inherits Objects.Base
#Region "Variables"
    Private _ID As String
    Private _Description As String
#End Region

#Region "Properties"
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
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
#End Region

#Region "Methods"
    Public Sub New()

    End Sub

    Public Sub New(ByVal pIDFRM As String)
        If Load(pIDFRM) Then
            _ID = Data.Rows(0)("ID")
            _Description = Data.Rows(0)("Description")
        End If
    End Sub

    Public Overrides Sub Clear()
        _ID = 0
        _Description = ""
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From [Project_Status] Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Insert Into [Project_Status] (Description) Values(@Description)"
        T.Include_Parameter("@Description", _Description)

        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select ID as Code, Description as Value From [Project_Status]"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Project_Status]"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where ID = @ID"
            T.Include_Parameter("@ID", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Project_Status] Set Description = @Description Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        T.Include_Parameter("@Description", _Description)

        TG.Include_Transaction(T)
    End Function
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        MyBase.Load(Code_ID)

        If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
            _ID = Data(0)("ID").ToString
            _Description = Data(0)("Description").ToString
        End If
    End Function
#End Region
End Class
