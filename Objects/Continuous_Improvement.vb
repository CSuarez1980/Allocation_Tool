Namespace Continuous_Improvement
    Public Class Project
        Inherits Objects.Base
#Region "Events"
        Public Event Project_Changed()
        Public Event Project_Clear()

#End Region
#Region "Variables"
        Private _ID As Integer
        Private _Name As String
        Private _Description As String

        Private _Project_Starts As Date
        Private _Project_Ends As Date

        Private _Tasks As New List(Of Objects.Continuous_Improvement.Task)

        Private _Daily_Hours As Double
        Private _Project_FTE As Double
        Private _Days_Completed As Double
        Private _Show_Task_Deleted As Boolean

        Private _Category As New Objects.Project_Category
        Private _Value_Stream As New Objects.Value_Stream
        Private _Status As New Objects.Project_Status
        Private _Service_Line As New Objects.Service_Line
        Private _Priority As New Objects.Project_Priority
#End Region
#Region "Properties"
        Public ReadOnly Property ID() As Integer
            Get
                Return _ID
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
        Public Property Tasks() As List(Of Objects.Continuous_Improvement.Task)
            Get
                Return _Tasks
            End Get
            Set(ByVal value As List(Of Objects.Continuous_Improvement.Task))
                _Tasks = value
            End Set
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
        Public Shadows Property [Status]() As Integer
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

#End Region
#Region "Methods"
        Public Sub New()
            Clear()
        End Sub
        Public Overrides Sub Clear()
            _ID = 0
            _Name = ""
            _Description = ""
            _Days_Completed = 0
            _Daily_Hours = 0
            _Project_FTE = 0
            _Project_Starts = Now.Date
            _Project_Ends = Now.Date

            '_Category = New Objects.Project_Category
            '_Value_Stream = New Objects.Value_Stream
            '_Status = New Objects.Project_Status
            '_Service_Line = New Objects.Service_Line
            '_Priority = New Objects.Project_Priority
            _Tasks.Clear()

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
            Dim SP As New Objects.Stored_Procedure

            SP.Stored_Procedure_Name = "sp_Get_Next_CI_Project_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)

            If SP.Execute() Then
                _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)
                T.SQL_String = "Insert Into [CI_Project] (ID,Name, Description, Category_ID, Value_Stream_ID, Status_ID, Service_Line_ID, Priority_ID) Values(@ID,@Name, @Description, @Category_ID, @Value_Stream_ID, @Status_ID, @Service_Line_ID, @Priority_ID)"
                T.Include_Parameter("@ID", _ID)
                T.Include_Parameter("@Name", _Name)
                T.Include_Parameter("@Description", _Description)
                T.Include_Parameter("@Category_ID", _Category.ID)
                T.Include_Parameter("@Value_Stream_ID", _Value_Stream.ID)
                T.Include_Parameter("@Status_ID", _Status.ID)
                T.Include_Parameter("@Service_Line_ID", _Service_Line.ID)
                T.Include_Parameter("@Priority_ID", _Priority.ID)

                TG.Include_Transaction(T)

                If _Tasks.Count > 0 Then
                    For Each TK As Objects.Continuous_Improvement.Task In _Tasks
                        TK.Set_Project_ID(_ID)
                        TG.Include_Transaction(TK.Get_Insert)
                    Next
                End If
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, Name, Description as Value From [CI_Project]"
            Return T
        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [CI_Project]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where ID = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group

            Dim T As New Transaction
            Dim TG As New Transaction_Group

            T.SQL_String = "Update [CI_Project] Set Name = @Name, Description = @Description, Category_ID = @Category_ID, Value_Stream_ID = @Value_Stream_ID, Status_ID = @Status_ID, Service_Line_ID = @Service_Line_ID, Priority_ID = @Priority_ID Where ID = @ID"
            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Name", _Name)
            T.Include_Parameter("@Description", _Description)
            T.Include_Parameter("@Category_ID", _Category.ID)
            T.Include_Parameter("@Value_Stream_ID", _Value_Stream.ID)
            T.Include_Parameter("@Status_ID", _Status.ID)
            T.Include_Parameter("@Service_Line_ID", _Service_Line.ID)
            T.Include_Parameter("@Priority_ID", _Priority.ID)
            TG.Include_Transaction(T)

            For Each TK As Objects.Continuous_Improvement.Task In _Tasks
                Select Case TK.Object_Status
                    Case Objects.SQL_Action.Insert
                        TK.Set_Project_ID(_ID)
                        TG.Include_Transaction(TK.Get_Insert())

                    Case Objects.SQL_Action.Update
                        TG.Include_Transaction(TK.Get_Update)

                End Select
            Next

            Return TG
        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _ID = Data(0)("ID").ToString
                _Name = Data(0)("Name").ToString
                _Description = Data(0)("Description").ToString

                _Category.Load(Data(0)("Category_ID"))
                _Value_Stream.Load(Data(0)("Value_Stream_ID"))
                _Status.Load(Data(0)("Status_ID"))
                _Service_Line.Load(Data(0)("Service_Line_ID"))
                _Priority.Load(Data(0)("Priority_ID"))

                Get_Project_Tasks()

                RaiseEvent Project_Changed()
            End If
        End Function
        Public Sub Add_Task(ByVal pTask As Objects.Task)
            'Dim Found As Boolean = False

            'If pTask.ID <> 0 Then
            '    For Each T As Objects.Task In _Tasks
            '        If T.ID = pTask.ID Then
            '            Found = True
            '            Exit For
            '        End If
            '    Next
            'End If

            'If Not Found Then
            '    pTask.Execute_Action = True
            '    pTask.SQL_Action = SQL_Action.Insert
            '    _Tasks.Add(pTask)
            'End If
        End Sub
        Public Sub Remove_Task(ByVal pTask As Objects.Task)
            'For Each T As Objects.Task In _Tasks
            '    If (T.ID = pTask.ID) AndAlso (T.Name = pTask.Name) Then
            '        T.Execute_Action = True
            '        T.SQL_Action = SQL_Action.Delete
            '    End If
            'Next
        End Sub
        Public Sub Get_Project_Forecast()
            '_Project_Starts = Today
            '_Project_Ends = _Project_Starts
            '_Daily_Hours = 0
            '_Project_FTE = 0
            '_Days_Completed = 0

            'For Each T As Objects.Task In _Tasks
            '    If T.Start < _Project_Starts Then
            '        _Project_Starts = T.Start
            '    End If
            '    If T.End > _Project_Ends Then
            '        _Project_Ends = T.End
            '    End If

            '    _Daily_Hours += T.Daily_Hours
            '    _Project_FTE += T.Task_Daily_FTE
            'Next

            ''_Total_Project_Days = (_Project_Ends - _Project_Starts).TotalDays
            '_Days_Completed = (Date.Today - _Project_Starts).TotalDays
        End Sub

        Public Sub Get_Project_Tasks()
            Dim cn As New Objects.Connection
            Dim _Tks As New DataTable

            _Tks = cn.GetTable("Select * From CI_Task Where Project_ID = " & _ID)

            If _Tks.Rows.Count > 0 Then
                For Each _T As DataRow In _Tks.Rows
                    _Tasks.Add(New Objects.Continuous_Improvement.Task(_T.Item("ID")))
                Next
            End If
        End Sub

        Public Sub Delete_Task(ByVal ID As Integer)
            For Each T As Objects.Continuous_Improvement.Task In _Tasks
                If T.ID = ID Then
                    T.Delete()
                    Exit Sub
                End If
            Next
        End Sub
#End Region
    End Class
    Public Class Task
        Inherits Objects.Base

#Region "Variables"
        Private _ID As Integer = 0
        Private _Description As String = ""
        Private _Owner As New Objects.User()
        Private _Start As Date = Now.Date
        Private _End As Date = Now.Date
        Private _Hours As Double = 0
        Private _Completed As Boolean = False
        Private _Project_ID As Integer = 0
        Private _Load_Records As Boolean = False
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
        Public Property Owner() As String
            Get
                Return _Owner.TNumber
            End Get
            Set(ByVal value As String)
                If Not _Owner.Load(value) Then
                    MsgBox("Owner T-Number not found.", MsgBoxStyle.Information, "T-Number not found")
                End If
            End Set
        End Property
        Public ReadOnly Property Owner_Name() As String
            Get
                Return _Owner.Name
            End Get
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
        Public Property Hours() As Double
            Get
                Return _Hours
            End Get
            Set(ByVal value As Double)
                _Hours = value
            End Set
        End Property
        Public Property Completed() As Boolean
            Get
                Return _Completed
            End Get
            Set(ByVal value As Boolean)
                _Completed = value
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal ID As Integer)
            If Load(ID) Then
                Set_Action(Objects.SQL_Action.Update)
            End If
        End Sub

        Public Overrides Sub Clear()

        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group
            Dim T As New Transaction
            Dim TG As New Transaction_Group

            T.SQL_String = "Delete From [CI_Task] Where ID = @ID"
            T.Include_Parameter("@ID", _ID)

            TG.Include_Transaction(T)

            Return TG
        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim T As New Transaction
            Dim TG As New Transaction_Group
            Dim SP As New Objects.Stored_Procedure

            If _Description.Length > 0 Then
                SP.Stored_Procedure_Name = "sp_Get_Next_CI_Task_ID"
                SP.Include_Parameter("@ID", 0, ParameterDirection.Output)

                If SP.Execute() Then
                    _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)
                    T.SQL_String = "Insert Into [CI_Task] (ID, Description, Owner, [Start], [End], Hours, Completed, Project_ID) Values(@ID, @Description, @Owner, @Start, @End, @Hours, @Completed, @Project_ID)"
                    T.Include_Parameter("@ID", _ID)
                    T.Include_Parameter("@Description", _Description)
                    T.Include_Parameter("@Owner", _Owner.TNumber)
                    T.Include_Parameter("@Start", _Start)
                    T.Include_Parameter("@End", _End)
                    T.Include_Parameter("@Hours", _Hours)
                    T.Include_Parameter("@Completed", _Completed)
                    T.Include_Parameter("@Project_ID", _Project_ID)

                    TG.Include_Transaction(T)
                    TG.Include_Transaction(Get_Insert_Records)

                End If
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [CI_Task]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where ID = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim T As New Transaction
            Dim TG As New Transaction_Group

            T.SQL_String = "Update [CI_Task] Set Description = @Description, Owner = @Owner, [Start] = @Start, [End] = @End, Hours = @Hours, Completed = @Completed Where ID = @ID"
            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Description", _Description)
            T.Include_Parameter("@Owner", _Owner.TNumber)
            T.Include_Parameter("@Start", _Start)
            T.Include_Parameter("@End", _End)
            T.Include_Parameter("@Hours", _Hours)
            T.Include_Parameter("@Completed", _Completed)

            TG.Include_Transaction(T)

            'Update record for this task:
            T = New Transaction
            T.SQL_String = "Delete From CI_Record Where Task_ID = @Task_ID"
            T.Include_Parameter("@Task_ID", _ID)
            TG.Include_Transaction(T)

            TG.Include_Transaction(Get_Insert_Records)

            Return TG
        End Function

        Public Sub Set_Project_ID(ByVal ID As Integer)
            _Project_ID = ID
        End Sub
        Private Function Get_Insert_Records() As Objects.Transaction_Group
            Dim TG As New Transaction_Group
            Dim T As New Transaction

            Dim _StDate = _Start

            Do
                If Objects.Functions.Global_Functions.Is_Working_Date(_StDate) Then
                    T = New Transaction
                    T.SQL_String = ("Insert Into CI_Record(Date, Task_ID, Hours_Req, Owner) Values (@Date, @Task_ID, @Hours_Req, @Owner)")
                    T.Include_Parameter("@Date", _StDate)
                    T.Include_Parameter("@Task_ID", _ID)
                    T.Include_Parameter("@Hours_Req", _Hours)
                    T.Include_Parameter("@Owner", Environ("USERID"))

                    TG.Include_Transaction(T)
                End If

                _StDate = _StDate.AddDays(1)
            Loop While _StDate <= _End

            Return TG
        End Function
        Private Function Get_Update_Records() As Objects.Transaction_Group
            Dim TG As New Transaction_Group
            Dim T As New Transaction
            Dim _StDate = _Start

            T.SQL_String = "Delete From CI_Record Where Task_ID = @Task_ID"
            T.Include_Parameter("@Task_ID", _ID)

            TG.Include_Transaction(T)
            TG.Include_Transaction(Get_Insert_Records)

            Return TG
        End Function
        Public Function Delete() As Boolean
            Dim cn As New Objects.Connection
            Return cn.Execute(Get_Delete)
        End Function

        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _ID = Data(0)("ID")
                _Completed = Data(0)("Completed")
                _Description = Data(0)("Description")
                _End = Data(0)("End")
                _Hours = Data(0)("Hours")
                _Owner.Load(Data(0)("Owner"))
                _Project_ID = Data(0)("Project_ID")
                _Start = Data(0)("Start")
            End If
        End Function
#End Region
    End Class
    Public Class Record
        Inherits Objects.Base

#Region "Variables"
        Private _ID As Integer
        Private _Date As Date
        Private _Task_ID As Integer
        Private _Hours_Req As Double
        Private _Hours_Worked As Double
        Private _Saved_By As String
#End Region
#Region "Properties"
        Protected Friend Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public Property [Date]() As Date
            Get
                Return _Date
            End Get
            Set(ByVal value As Date)
                _Date = value
            End Set
        End Property
        Protected Friend Property Task() As Integer
            Get
                Return _Task_ID
            End Get
            Set(ByVal value As Integer)
                _Task_ID = value
            End Set
        End Property
        Public ReadOnly Property Hours_Requiered() As Double
            Get
                Return _Hours_Req
            End Get
        End Property
        Public Property Hours_Worked() As Double
            Get
                Return _Hours_Worked
            End Get
            Set(ByVal value As Double)
                _Hours_Worked = value
            End Set
        End Property
        Protected Friend Property Saved_by() As String
            Get
                Return _Saved_By
            End Get
            Set(ByVal value As String)
                _Saved_By = value
            End Set
        End Property
#End Region
#Region "Methods"
#Region "Base Methods"
        Public Overrides Sub Clear()

        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group

        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction

        End Function
        Public Overrides Function Get_Update() As Transaction_Group

        End Function
#End Region
#End Region
    End Class
    Public Class Actual
        Inherits Objects.Base

#Region "Variables"
        Private _ID As Integer
        Private _Record_Date As Date
        Private _Actual_Date As Date

        Private _Created_By As String

        Private _Hours As Double
        Private _FTE As Double

        Private _Project_ID As Integer
        Private _Project_Name As String

        Private _Task_ID As Integer
        Private _Task_Description As String
        Private _Hours_Required As Double
        Private _Hours_Saved As Double

        Private _Task_Finished As Boolean
#End Region
#Region "Properties"
        Protected Friend Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Protected ReadOnly Property Record_Date() As Date
            Get
                Return _Record_Date
            End Get
        End Property

        Public Property Actual_Date() As Date
            Get
                Return _Actual_Date
            End Get
            Set(ByVal value As Date)
                _Actual_Date = value
            End Set
        End Property

        Protected Friend ReadOnly Property Created_By() As String
            Get
                Return _Created_By
            End Get
        End Property

        Protected Friend Property Project_ID() As Integer
            Get
                Return _Project_ID
            End Get
            Set(ByVal value As Integer)
                _Project_ID = value
            End Set
        End Property
        Public ReadOnly Property Project_Name() As String
            Get
                Return _Project_Name
            End Get
        End Property

        Protected Friend Property Task_ID() As Integer
            Get
                Return _Task_ID
            End Get
            Set(ByVal value As Integer)
                _Task_ID = value
            End Set
        End Property
        Public ReadOnly Property Task_Description() As String
            Get
                Return _Task_Description
            End Get
        End Property

        Public ReadOnly Property Hours_Requiered() As Double
            Get
                Return _Hours_Required
            End Get
        End Property

        Public ReadOnly Property Hours_Saved() As Double
            Get
                Return _Hours_Saved
            End Get
        End Property

        Public Property Hours() As Double
            Get
                Return _Hours
            End Get
            Set(ByVal value As Double)
                _Hours = value
            End Set
        End Property
        Public ReadOnly Property FTE() As Double
            Get
                Return _FTE
            End Get
        End Property

        Public Property Task_Finished() As Boolean
            Get
                Return _Task_Finished
            End Get
            Set(ByVal value As Boolean)
                _Task_Finished = value
            End Set
        End Property
#End Region
#Region "Methods"

        Public Sub New(ByVal [Date] As Date, ByVal Proj_ID As Integer, ByVal Proj_Name As String, ByVal TaskID As Integer, ByVal Task_Desc As String, ByVal Hours_Req As Double, ByVal Hours_Sav As Double)
            _Actual_Date = Now.Date
            _Created_By = Environ("USERID")
            _Hours = 0
            _FTE = 0
            _Project_ID = Proj_ID
            _Project_Name = Proj_Name
            _Task_ID = TaskID
            _Task_Description = Task_Desc
            _Hours_Required = Hours_Req
            _Hours_Saved = Hours_Sav
        End Sub
        Public Sub New()
            Clear()
        End Sub

        Public Overrides Sub Clear()
            _ID = 0
            _Record_Date = Now.Date
            _Actual_Date = Now.Date

            _Created_By = Environ("USERID")

            _Hours = 0
            _FTE = 0

            _Project_ID = 0
            _Project_Name = ""

            _Task_ID = 0
            _Task_Description = ""
            _Hours_Required = 0
            _Hours_Saved = 0

            _Task_Finished = False
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim TG As New Transaction_Group
            Dim T As New Transaction

            If _Hours > 0 Then
                T.SQL_String = "Insert Into CI_Actuals([Record_Date], Task_ID, Created_By, Actual_Date, Hours, FTE, ProjectID) Values(CONVERT (varchar(10), {fn now()}, 101), @Task_ID, @Created_By, @Actual_Date, @Hours, @FTE, @ProjectID)"
                T.Include_Parameter("@Task_ID", _Task_ID)
                T.Include_Parameter("@Created_By", _Created_By)
                T.Include_Parameter("@Actual_Date", _Actual_Date)
                T.Include_Parameter("@Hours", _Hours)
                T.Include_Parameter("@FTE", _FTE)
                T.Include_Parameter("@ProjectID", _Project_ID)

                TG.Include_Transaction(T)
            End If

            If _Task_Finished Then
                T = New Transaction
                T.SQL_String = "Update CI_Task Set Completed = @Completed Where ID = @IDTask"
                T.Include_Parameter("@Completed", _Task_Finished)
                T.Include_Parameter("@IDTask", _Task_ID)

                TG.Include_Transaction(T)
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction

        End Function
        Public Overrides Function Get_Update() As Transaction_Group

        End Function

        Public Sub Insert()
            Dim cn As New Objects.Connection
            cn.Execute(Get_Insert)
        End Sub
#End Region

    End Class
    Public Class New_Actual_Line
#Region "Variables"
        Private _Project_ID As Integer
        Private _Project_Name As String
        Private _Task_ID As Integer
        Private _Task_Name As String
#End Region
#Region "Properties"
        Public Property Project_ID() As Integer
            Get
                Return _Project_ID
            End Get
            Set(ByVal value As Integer)
                _Project_ID = value
            End Set
        End Property
        Public Property Project_Name() As String
            Get
                Return _Project_Name
            End Get
            Set(ByVal value As String)
                _Project_Name = value
            End Set
        End Property
        Public Property Task_ID() As Integer
            Get
                Return _Task_ID
            End Get
            Set(ByVal value As Integer)
                _Task_ID = value
            End Set
        End Property
        Public Property Task_Name() As String
            Get
                Return _Task_Name
            End Get
            Set(ByVal value As String)
                _Task_Name = value
            End Set
        End Property
#End Region
    End Class
End Namespace

