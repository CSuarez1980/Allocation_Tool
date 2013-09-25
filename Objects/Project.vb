Public Class Project
    Inherits Objects.Base

#Region "Events"
    Public Event Project_Changed()
    Public Event Project_Clear()

#End Region
#Region "Variables"
    Private _ID As Integer
    Private _Project_Key As String
    Private _Name As String
    Private _Description As String
    Private _Total_Project_Days As Integer
    Private _Task_Table As New DataTable
    Private _Tasks As New List(Of Objects.Task)
    Private _Project_Starts As Date
    Private _Project_Ends As Date
    Private _Daily_Hours As Double
    Private _Project_FTE As Double
    Private _Days_Completed As Double
    Private _Show_Task_Deleted As Boolean

    Private _Category As New Objects.Project_Category
    Private _Value_Stream As New Objects.Value_Stream
    Private _Status As New Objects.Project_Status
    Private _Service_Line As New Objects.Service_Line
    Private _Priority As New Objects.Project_Priority

    Private _Priority_List As New DataTable
    Private _Service_Line_List As New DataTable
    Private _Status_List As New DataTable
    Private _Category_List As New DataTable
    Private _Value_Stream_List As New DataTable

#End Region
#Region "Properties"
    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property
    Public ReadOnly Property Key() As String
        Get
            Return _Project_Key
        End Get
    End Property
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
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
    Public Property Category() As Integer
        Get
            Return _Category.ID
        End Get
        Set(ByVal value As Integer)
            _Category.Load(value)
        End Set
    End Property
    Public Property Value_Stream() As Integer
        Get
            Return _Value_Stream.ID
        End Get
        Set(ByVal value As Integer)
            _Value_Stream.Load(value)
        End Set
    End Property
    Public Property Project_Status() As Integer
        Get
            Return _Status.ID
        End Get
        Set(ByVal value As Integer)
            _Status.Load(value)
        End Set
    End Property
    Public Property Service_Line() As Integer
        Get
            Return _Service_Line.ID
        End Get
        Set(ByVal value As Integer)
            _Service_Line.Load(value)
        End Set
    End Property
    Public Property Priority() As Integer
        Get
            Return _Priority.ID
        End Get
        Set(ByVal value As Integer)
            _Priority.Load(value)
        End Set
    End Property
    Public ReadOnly Property Priority_List() As DataTable
        Get
            Return _Priority_List
        End Get
    End Property
    Public ReadOnly Property Service_Line_List() As DataTable
        Get
            Return _Service_Line_List
        End Get
    End Property
    Public ReadOnly Property Status_List() As DataTable
        Get
            Return _Status_List
        End Get
    End Property
    Public ReadOnly Property Category_List() As DataTable
        Get
            Return _Category_List
        End Get
    End Property
    Public ReadOnly Property Value_Stream_List() As DataTable
        Get
            Return _Value_Stream_List
        End Get
    End Property
    Public ReadOnly Property Task_Table() As DataTable
        Get
            Return _Task_Table
        End Get
    End Property
    Public ReadOnly Property Project_Starts() As Date
        Get
            Return _Project_Starts
        End Get
    End Property
    Public ReadOnly Property Project_Ends() As Date
        Get
            Return _Project_Ends
        End Get
    End Property
    Public ReadOnly Property Daily_Hours() As Double
        Get
            Return Math.Round(_Daily_Hours, 2)
        End Get
    End Property
    Public ReadOnly Property Project_FTE() As Double
        Get
            Return Math.Round(_Project_FTE)
        End Get
    End Property
    Public ReadOnly Property Days_Completed() As Double
        Get
            Return _Days_Completed
        End Get
    End Property
    Public Property Show_Task_Deleted() As Boolean
        Get
            Return _Show_Task_Deleted
        End Get
        Set(ByVal value As Boolean)
            _Show_Task_Deleted = value
        End Set
    End Property


#End Region
#Region "Methods"
    Public Sub New()
        Clear()
    End Sub
    Public Overrides Sub Clear()
        _ID = 0
        _Project_Key = ""
        _Name = ""
        _Description = ""
        _Days_Completed = 0
        _Daily_Hours = 0
        _Project_FTE = 0
        _Project_Starts = Now.Date
        _Project_Ends = Now.Date

        _Category = New Objects.Project_Category
        _Value_Stream = New Objects.Value_Stream
        _Status = New Objects.Project_Status
        _Service_Line = New Objects.Service_Line
        _Priority = New Objects.Project_Priority
        _Task_Table = New DataTable
        _Tasks.Clear()

        _Priority_List = GetTable(_Priority.Get_Search_List)
        _Service_Line_List = GetTable(_Service_Line.Get_Search_List)
        _Status_List = GetTable(_Status.Get_Search_List)
        _Category_List = GetTable(_Category.Get_Search_List)
        _Value_Stream_List = GetTable(_Value_Stream.Get_Search_List)

        RaiseEvent Project_Clear()
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From Project Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        TG.Include_Transaction(T)

        'T = New Transaction
        'T.SQL_String = "Delete From Project_Form Where ID_Profile = @ID-Profile"
        'T.Include_Parameter("@ID-Profile", _ID)
        'TG.Include_Transaction(T)

        Return TG
    End Function
    Private Function GetID_By_Key(ByVal pKey As String) As Integer
        Dim T As New Transaction
        Dim ID As New DataTable

        T.SQL_String = "Select ID From Project Where [Project_Key] = @Project_Key"
        T.Include_Parameter("@Project_Key", pKey)

        ID = GetTable(T)
        If ID.Rows.Count > 0 Then
            Return ID(0)(0)
        Else
            Return Nothing
        End If
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        _Project_Key = Now().ToFileTimeUtc()

        T.SQL_String = "Insert Into [Project] (Project_Key, Name, Description, Category_ID, Value_Stream_ID, Status_ID, Service_Line_ID, Priority_ID) Values(@Project_Key, @Name, @Description, @Category_ID, @Value_Stream_ID, @Status_ID, @Service_Line_ID, @Priority_ID)"
        T.Include_Parameter("@Project_Key", _Project_Key)
        T.Include_Parameter("@Name", _Name)
        T.Include_Parameter("@Description", _Description)
        T.Include_Parameter("@Category_ID", _Category.ID)
        T.Include_Parameter("@Value_Stream_ID", _Value_Stream.ID)
        T.Include_Parameter("@Status_ID", _Status.ID)
        T.Include_Parameter("@Service_Line_ID", _Service_Line.ID)
        T.Include_Parameter("@Priority_ID", _Priority.ID)

        If Execute(T) Then
            _ID = GetID_By_Key(_Project_Key)
            TG = New Transaction_Group

            For Each TK As Objects.Task In _Tasks
                TK.Project_ID = _ID
                TG.Include_Transaction(TK.Get_Insert())
            Next
            Execute(TG)

            TG.Clear_Transactions()
            For Each TK As Objects.Task In _Tasks
                TK.Get_Task_ID()

                Dim T2 As New Transaction
                T2.SQL_String = "Insert Into Project_Task(ID_Project, ID_Task) Values(@Project, @Task)"
                T2.Include_Parameter("@Project", _ID)
                T2.Include_Parameter("@Task", TK.ID)

                TG.Include_Transaction(T2)
            Next

            Return TG
        End If
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select ID as Code, Name, Description as Value From [Project]"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Project]"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where ID = @ID"
            T.Include_Parameter("@ID", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update [Project] Set Name = @Name, Description = @Description, Category_ID = @Category_ID, Value_Stream_ID = @Value_Stream_ID, Status_ID = @Status_ID, Service_Line_ID = @Service_Line_ID, Priority_ID = @Priority_ID Where ID = @ID"
        T.Include_Parameter("@ID", _ID)
        T.Include_Parameter("@Name", _Name)
        T.Include_Parameter("@Description", _Description)
        T.Include_Parameter("@Category_ID", _Category.ID)
        T.Include_Parameter("@Value_Stream_ID", _Value_Stream.ID)
        T.Include_Parameter("@Status_ID", _Status.ID)
        T.Include_Parameter("@Service_Line_ID", _Service_Line.ID)
        T.Include_Parameter("@Priority_ID", _Priority.ID)
        TG.Include_Transaction(T)

        Execute(TG)
        TG = New Transaction_Group

        For Each TK As Objects.Task In _Tasks
            Select Case TK.SQL_Action
                Case Objects.SQL_Action.Insert
                    TK.Project_ID = _ID
                    TG.Include_Transaction(TK.Get_Insert())
                    Execute(TG)

                    TG.Clear_Transactions()
                    TK.Get_Task_ID()

                    Dim T2 As New Transaction
                    T2.SQL_String = "Insert Into Project_Task(ID_Project, ID_Task) Values(@Project, @Task)"
                    T2.Include_Parameter("@Project", _ID)
                    T2.Include_Parameter("@Task", TK.ID)

                    TG.Include_Transaction(T2)
                    Return TG

                Case Objects.SQL_Action.Delete
                    TG.Include_Transaction(TK.Get_Delete)
                    Dim T2 As New Transaction
                    T2.SQL_String = "Delete From Project_Task Where (ID_Project = @Project And ID_Task = @Task)"
                    T2.Include_Parameter("@Project", _ID)
                    T2.Include_Parameter("@Task", TK.ID)
            End Select
        Next

        Return TG
    End Function
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        MyBase.Load(Code_ID)
        If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
            _ID = Data(0)("ID").ToString
            _Project_Key = Data(0)("Project_Key").ToString
            _Name = Data(0)("Name").ToString
            _Description = Data(0)("Description").ToString

            _Category.Load(Data(0)("Category_ID"))
            _Value_Stream.Load(Data(0)("Value_Stream_ID"))
            _Status.Load(Data(0)("Status_ID"))
            _Service_Line.Load(Data(0)("Service_Line_ID"))
            _Priority.Load(Data(0)("Priority_ID"))

            Get_Tasks_In_Project()
            Get_Project_Forecast()

            RaiseEvent Project_Changed()
        End If
    End Function
    Public Sub Get_Tasks_In_Project(Optional ByVal Get_From_DataBase As Boolean = True)
        Dim DB As New Connection
        Dim TR As New Transaction

        If Get_From_DataBase Then
            TR.SQL_String = "SELECT Project_Task.ID_Task, Task.Name, Task.[Start], Task.[End], Project_Status.Description as [Status], Daily_Hours as [Daily Hours], Task_FTE as [Task FTE]" & _
                            "FROM Project_Task INNER JOIN Task ON Project_Task.ID_Task = Task.ID LEFT OUTER JOIN Project_Status ON Task.Status = Project_Status.ID " & _
                            "WHERE (dbo.Task.Project_ID = @ID)" & IIf(_Show_Task_Deleted, "", " AND (dbo.Task.Del_Ind = 0)")

            TR.Include_Parameter("@ID", _ID)
            _Task_Table = DB.GetTable(TR)
            If Not _Task_Table Is Nothing Then
                For Each R As DataRow In _Task_Table.Rows
                    _Tasks.Add(New Objects.Task(R("ID_Task")))
                Next
            End If
        Else
            If _Task_Table Is Nothing OrElse _Task_Table.Rows.Count = 0 Then
                TR.SQL_String = "SELECT Top 1 Project_Task.ID_Task, Task.Name, Task.[Start], Task.[End], Project_Status.Description as [Status], Daily_Hours as [Daily Hours], Task_FTE as [Task FTE]" & _
                                "FROM Project_Task INNER JOIN Task ON Project_Task.ID_Task = Task.ID LEFT OUTER JOIN Project_Status ON Task.Status = Project_Status.ID "

                _Task_Table = DB.GetTable(TR)
            End If

            If Not _Task_Table Is Nothing Then
                _Task_Table.Clear()
            End If


            For Each P As Objects.Task In _Tasks
                If Not P.SQL_Action = SQL_Action.Delete Then
                    Dim R As DataRow
                    R = _Task_Table.NewRow()
                    R("ID_Task") = P.ID
                    R("Name") = P.Name
                    R("Start") = P.Start
                    R("End") = P.End
                    R("Status") = P.Task_Status_Description
                    R("Daily Hours") = P.Daily_Hours
                    R("Task FTE") = P.Task_Daily_FTE

                    _Task_Table.Rows.Add(R)
                End If
            Next
        End If
    End Sub
    Public Sub Add_Task(ByVal pTask As Objects.Task)
        Dim Found As Boolean = False

        If pTask.ID <> 0 Then
            For Each T As Objects.Task In _Tasks
                If T.ID = pTask.ID Then
                    Found = True
                    Exit For
                End If
            Next
        End If

        If Not Found Then
            pTask.Execute_Action = True
            pTask.SQL_Action = SQL_Action.Insert
            _Tasks.Add(pTask)
            Get_Tasks_In_Project(False)
        End If
    End Sub
    Public Sub Remove_Task(ByVal pTask As Objects.Task)
        For Each T As Objects.Task In _Tasks
            If (T.ID = pTask.ID) AndAlso (T.Name = pTask.Name) Then
                T.Execute_Action = True
                T.SQL_Action = SQL_Action.Delete
                Get_Tasks_In_Project(False)
            End If
        Next
    End Sub
    Public Sub Get_Project_Forecast()
        _Project_Starts = Today
        _Project_Ends = _Project_Starts
        _Daily_Hours = 0
        _Project_FTE = 0
        _Days_Completed = 0

        For Each T As Objects.Task In _Tasks
            If T.Start < _Project_Starts Then
                _Project_Starts = T.Start
            End If
            If T.End > _Project_Ends Then
                _Project_Ends = T.End
            End If

            _Daily_Hours += T.Daily_Hours
            _Project_FTE += T.Task_Daily_FTE
        Next

        _Total_Project_Days = (_Project_Ends - _Project_Starts).TotalDays
        _Days_Completed = (Date.Today - _Project_Starts).TotalDays
    End Sub
#End Region
End Class
