Public Class User
    Inherits Base

#Region "Variables"
    Private _TNumber As String
    Private _Name As String
    Private _Profile As New List(Of Objects.Profile)
    Private _Profile_Table As DataTable
#End Region
#Region "Properties"
    Public Property TNumber() As String
        Get
            Return _TNumber
        End Get
        Set(ByVal value As String)
            _TNumber = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property
    Public ReadOnly Property Profiles() As List(Of Objects.Profile)
        Get
            Return _Profile
        End Get
    End Property
    Public ReadOnly Property Profile_Table() As DataTable
        Get
            Return _Profile_Table
        End Get
    End Property
#End Region
#Region "Methods"
    Public Sub New()
        Clear()
    End Sub
    Public Overrides Sub Clear()
        _Name = ""
        _TNumber = ""
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From [Users] Where TNumber = @TNumber"
        T.Include_Parameter("@TNumber", _TNumber)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Insert Into [Users] (TNumber, Name) Values(@TNumber, @Name)"
        T.Include_Parameter("@TNumber", _TNumber)
        T.Include_Parameter("@Name", _Name)
       
        TG.Include_Transaction(T)

        For Each P As Objects.Profile In _Profile
            Select Case P.SQL_Action
                Case Objects.SQL_Action.Insert
                    T = New Transaction
                    T.SQL_String = "Insert Into User_Profile (Profile_ID, TNumber) Values(@ID, @TNumber)"

                    T.Include_Parameter("@ID", P.ID)
                    T.Include_Parameter("@TNumber", _TNumber)
                    TG.Include_Transaction(T)

                Case Objects.SQL_Action.Delete
                    T = New Transaction
                    T.SQL_String = "Delete From User_Profile Where ((Profile_ID = @ID) And (TNumber = @TNumber))"

                    T.Include_Parameter("@ID", P.ID)
                    T.Include_Parameter("@TNumber", _TNumber)
                    TG.Include_Transaction(T)
            End Select
        Next

        Return TG
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select TNumber as Code, [Name] as Value From [Users]"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Users]"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where TNumber = @TNumber"
            T.Include_Parameter("@TNumber", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Users] Set Name = @Name Where TNumber = @TNumber"
        T.Include_Parameter("@Name", _Name)
        T.Include_Parameter("@TNumber", _TNumber)
       
        TG.Include_Transaction(T)

        For Each P As Objects.Profile In _Profile
            Select Case P.SQL_Action
                Case Objects.SQL_Action.Insert
                    T = New Transaction
                    T.SQL_String = "Insert Into User_Profile (Profile_ID, TNumber) Values(@ID, @TNumber)"

                    T.Include_Parameter("@ID", P.ID)
                    T.Include_Parameter("@TNumber", _TNumber)
                    TG.Include_Transaction(T)

                Case Objects.SQL_Action.Delete
                    T = New Transaction
                    T.SQL_String = "Delete From User_Profile Where ((Profile_ID = @ID) And (TNumber = @TNumber))"

                    T.Include_Parameter("@ID", P.ID)
                    T.Include_Parameter("@TNumber", _TNumber)
                    TG.Include_Transaction(T)
            End Select
        Next

        Return TG
    End Function
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        MyBase.Load(Code_ID)

        If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
            _TNumber = Data(0)("TNumber").ToString
            _Name = Data(0)("Name").ToString
            Get_User_Profiles()
        End If
    End Function

    Public Sub Add_Profile(ByVal pProfile As Objects.Profile)
        Dim Found As Boolean = False

        For Each PF As Objects.Profile In _Profile
            If PF.ID = pProfile.ID Then
                Found = True
                Exit For
            End If
        Next

        If Not Found Then
            pProfile.Allow_Action(True)
            pProfile.SQL_Action = Objects.SQL_Action.Insert
            _Profile.Add(pProfile)
            Get_User_Profiles(False)
        End If

    End Sub
    Public Sub Remove_Profile(ByVal pProfile As Integer)
        For Each P As Objects.Profile In _Profile
            If P.ID = pProfile Then
                P.Allow_Action(True)
                P.SQL_Action = Objects.SQL_Action.Delete
                Get_User_Profiles(False)
            End If
        Next
    End Sub

    Public Sub Get_User_Profiles(Optional ByVal Get_From_DataBase As Boolean = True)
        If Get_From_DataBase Then
            Dim DB As New Connection
            Dim TR As New Transaction

            TR.SQL_String = "Select Profile.ID AS [ID], Description From Profile Right Outer Join User_Profile ON Profile.ID = User_Profile.Profile_ID Where (User_Profile.TNumber = @TNumber)"
            TR.Include_Parameter("@TNumber", _TNumber)
            _Profile_Table = DB.GetTable(TR)
            If Not _Profile_Table Is Nothing Then
                For Each R As DataRow In _Profile_Table.Rows
                    If Not DBNull.Value.Equals((R("ID"))) Then
                        _Profile.Add(New Objects.Profile(R("ID")))
                    End If
                Next
            End If
        Else
            If _Profile_Table Is Nothing Then
                _Profile_Table = New DataTable
            End If

            _Profile_Table.Clear()
            If _Profile_Table.Columns.Count = 0 Then
                _Profile_Table.Columns.Add("ID")
                _Profile_Table.Columns.Add("Description")
            End If

            For Each P As Objects.Profile In _Profile
                If Not P.SQL_Action = Objects.SQL_Action.Delete Then
                    Dim R As DataRow
                    R = _Profile_Table.NewRow()
                    R("ID") = P.ID
                    R("Description") = P.Description
                    _Profile_Table.Rows.Add(R)
                End If
            Next

        End If
    End Sub
#End Region

End Class
