Public Class Task
    Inherits Objects.Base

#Region "Variables"
    Private _ID As Integer
    Private _Project_ID As Integer
    Private _Name As String
    Private _Start As Date
    Private _End As Date
    Private _Daily_Hours As Double
    Private _Task_Daily_FTE As Double
    Private _Automated_Proc As Double
    Private _Owner As New Objects.User
    Private _Task_Key As String
    Private _WorkingDays As Integer

    Private _Del_Ind As Boolean
    Private _Show_Deleted As Boolean

    Private _Status As New Objects.Project_Status
    Private _Status_List As New DataTable

    Private _Entry_List As New List(Of Objects.Task_Entry)

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
    Public Property Project_ID() As Integer
        Get
            Return _Project_ID
        End Get
        Set(ByVal value As Integer)
            _Project_ID = value
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
    Public Property Start() As Date
        Get
            Return _Start
        End Get
        Set(ByVal value As Date)
            _Start = value
        End Set
    End Property
    Public Property [End]() As Date
        Get
            Return _End
        End Get
        Set(ByVal value As Date)
            _End = value
        End Set
    End Property
    Public Property Daily_Hours() As Double
        Get
            Return _Daily_Hours
        End Get
        Set(ByVal value As Double)
            _Daily_Hours = value
            _Task_Daily_FTE = _Daily_Hours / 7
        End Set
    End Property
    Public Property Task_Daily_FTE() As Double
        Get
            Return Math.Round(_Task_Daily_FTE, 2)
        End Get
        Set(ByVal value As Double)
            _Task_Daily_FTE = value
        End Set
    End Property
    Public Property Automated_Proc() As Double
        Get
            Return _Automated_Proc
        End Get
        Set(ByVal value As Double)
            _Automated_Proc = value
        End Set
    End Property
    Public Property Task_Status() As Integer
        Get
            Return _Status.ID
        End Get
        Set(ByVal value As Integer)
            _Status.Load(value)
        End Set
    End Property
    Public ReadOnly Property Task_Status_Description() As String
        Get
            Return _Status.Description
        End Get
    End Property
    Public Property Owner() As String
        Get
            Return _Owner.TNumber
        End Get
        Set(ByVal value As String)
            _Owner.Load(value)
        End Set
    End Property
    Public ReadOnly Property Owner_Name() As String
        Get
            Return _Owner.Name
        End Get
    End Property
    Public ReadOnly Property Status_List() As DataTable
        Get
            Return _Status_List
        End Get
    End Property
    Public ReadOnly Property Working_Days() As Integer
        Get
            Return _WorkingDays
        End Get
    End Property
    Public Property Delete_Indicator() As Boolean
        Get
            Return _Del_Ind
        End Get
        Set(ByVal value As Boolean)
            _Del_Ind = value
        End Set
    End Property
    Public Property Show_Deleted() As Boolean
        Get
            Return _Show_Deleted
        End Get
        Set(ByVal value As Boolean)
            _Show_Deleted = value
        End Set
    End Property

#End Region
#Region "Methods"
    Public Sub New()
        Clear()
    End Sub
    Public Sub New(ByVal pID As Integer)
        Load(pID)
    End Sub
    Public Overrides Sub Clear()
        _Automated_Proc = 0
        _Daily_Hours = 0
        _End = Date.Today
        _Start = Date.Today
        _Task_Daily_FTE = 0
        _ID = 0
        _Name = ""
        _Project_ID = 0
        _Status.Clear()
        _WorkingDays = 0
        _Del_Ind = False
        _Show_Deleted = False

        _Status = New Objects.Project_Status
        _Status_List = GetTable(_Status.Get_Search_List)

        _Entry_List.Clear()
    End Sub
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        MyBase.Load(Code_ID)
        If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
            _Daily_Hours = Data(0)("Daily_Hours").ToString
            _End = Data(0)("End").ToString
            _Task_Daily_FTE = Data(0)("Task_FTE").ToString
            _ID = Data(0)("ID").ToString
            _Name = Data(0)("Name").ToString
            _Project_ID = Data(0)("Project_ID").ToString
            _Start = Data(0)("Start").ToString
            _Owner.Load(Data(0)("Owner").ToString)
            _Status.Load(Data(0)("Status"))
            _Del_Ind = Data(0)("Del_Ind")

            _Status_List = GetTable(_Status.Get_Search_List)
            _Automated_Proc = 0

            'Dim Fns As New Objects.Functions
            _WorkingDays = Objects.Functions.Global_Functions.GetWorkingDays(_Start, _End)

            Return True
        Else
            Return False
        End If
    End Function
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Task] Set Del_Ind = 1 Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        _Task_Key = Now().ToFileTimeUtc

        T.SQL_String = "Insert Into [Task](Project_ID, Name, [Start], [End], Daily_Hours, Task_FTE, Status, Owner, [Key], Del_Ind) Values(@Project_ID, @Name, @Start, @End, @Daily_Hours, @Task_FTE, @Status, @Owner, @Key, @Del_Ind)"
        T.Include_Parameter("@Project_ID", _Project_ID)
        T.Include_Parameter("@Name", _Name)
        T.Include_Parameter("@Start", _Start)
        T.Include_Parameter("@End", _End)
        T.Include_Parameter("@Daily_Hours", _Daily_Hours)
        T.Include_Parameter("@Task_FTE", _Task_Daily_FTE)
        T.Include_Parameter("@Status", _Status.ID)
        T.Include_Parameter("@Owner", _Owner.TNumber)
        T.Include_Parameter("@Key", _Task_Key)
        T.Include_Parameter("@Del_Ind", _Del_Ind)

        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select ID as Code, Name as Value From [Task] " & IIf(_Show_Deleted, "", "Where (Del_Ind = 0)") & " order By ID"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Task]"

        If Not _Show_Deleted Then
            T.SQL_String = T.SQL_String & " Where (Del_Ind = 0)"

            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " And (ID = @ID)"
                T.Include_Parameter("@ID", Code_ID)
            End If
        Else
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where ID = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Task] Set Project_ID = @Project_ID, Name = @Name, [Start] = @Start, [End] = @End, Daily_Hours = @Daily_Hours, Task_FTE = @Task_FTE, Status = @Status, Owner = @Owner, Del_Ind = @Del_Ind Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        T.Include_Parameter("@Project_ID", _Project_ID)
        T.Include_Parameter("@Name", _Name)
        T.Include_Parameter("@Start", _Start)
        T.Include_Parameter("@End", _End)
        T.Include_Parameter("@Daily_Hours", _Daily_Hours)
        T.Include_Parameter("@Task_FTE", _Task_Daily_FTE)
        T.Include_Parameter("@Status", _Status.ID)
        T.Include_Parameter("@Owner", _Owner.TNumber)
        T.Include_Parameter("@Del_Ind", _Del_Ind)


        TG.Include_Transaction(T)
        Return TG
    End Function
    Private Function GetID_By_Key(ByVal pKey As String) As Integer
        Dim T As New Transaction
        Dim ID As New DataTable

        T.SQL_String = "Select ID From Task Where [Key] = @KEY"
        T.Include_Parameter("@KEY", pKey)

        ID = GetTable(T)
        If ID.Rows.Count > 0 Then
            Return ID(0)(0)
        Else
            Return Nothing
        End If
    End Function
    Public Sub Get_Task_ID()
        Dim T As New Transaction
        Dim D As New DataTable

        T.SQL_String = "Select ID From Task Where [Key] = @Key"
        T.Include_Parameter("@Key", _Task_Key)

        D = GetTable(T)

        If D.Rows.Count > 0 Then
            _ID = D(0)(0)
        End If
    End Sub
#End Region

End Class
