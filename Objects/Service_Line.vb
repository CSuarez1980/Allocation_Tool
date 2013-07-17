Public Class Service_Line
    Inherits Objects.Base
#Region "Variables"
    Private _ID As Integer
    Private _Description As String
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
#End Region

#Region "Methods"
    Public Overrides Sub Clear()
        _ID = 0
        _Description = ""
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From [Service_Line] Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Insert Into [Service_Line] (Description) Values(@Description)"
        T.Include_Parameter("@Description", _Description)

        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select ID as Code, Description as Value From [Service_Line]"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Service_Line]"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where ID = @ID"
            T.Include_Parameter("@ID", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Service_Line] Set Description = @Description Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        T.Include_Parameter("@Description", _Description)

        TG.Include_Transaction(T)

        Return TG
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
