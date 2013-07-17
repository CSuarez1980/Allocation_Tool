Public Class Test
    Inherits Base


#Region "Variables"
    Private _Edad As Integer
    Private _TN As String
#End Region

#Region "Properties"
    Public Property Edad() As Integer
        Get
            Return _Edad
        End Get
        Set(ByVal value As Integer)
            _Edad = value
        End Set
    End Property

    Public Property TN() As String
        Get
            Return _TN
        End Get
        Set(ByVal value As String)
            _TN = value
        End Set
    End Property
#End Region



    Public Overrides Sub Clear()

    End Sub

    Public Overrides Function Get_Delete() As Transaction_Group

    End Function

    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group
        T.SQL_String = "Insert Into Test (TN, Edad) Values(@TN, @Edad)"
        T.Include_Parameter("@TN", _TN)
        T.Include_Parameter("@Edad", _Edad)

        TG.Include_Transaction(T)
        Return TG
    End Function

    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select TN as Code, [Edad] as Value From [Test]"
        Return T
    End Function

    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction

    End Function

    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update Test set Edad = @Edad Where TN = @TN"
        T.Include_Parameter("@TN", _TN)
        T.Include_Parameter("@Edad", _Edad)

        TG.Include_Transaction(T)
        Return TG
    End Function
End Class
