Public Enum Entry_type
    Automatic = 0
    Manual = 1
End Enum

Public Class Task_Entry
    Inherits Objects.Base

#Region "Variables"
    Private _Entry_ID As Integer
    Private _Project_ID As Integer
    Private _Project_Name As String
    Private _Task As New Objects.Task

    Private _Entry_Date As Date
    Private _Created_By As String
    Private _Entry_Type As Entry_type
    Private _Hours As Double
    Private _Hours_Average As Double
    Private _FTE As Double
#End Region
#Region "Properties"
    Public Property Entry_ID() As Integer
        Get
            Return _Entry_ID
        End Get
        Set(ByVal value As Integer)
            _Entry_ID = value
        End Set
    End Property
    Public Property Task_ID() As Integer
        Get
            Return _Task.ID
        End Get
        Set(ByVal value As Integer)
            _Task.Load(value)
        End Set
    End Property
    Public ReadOnly Property Task_Name() As String
        Get
            Return _Task.Name
        End Get
    End Property
    Public Property Entry_Date() As Date
        Get
            Return _Entry_Date
        End Get
        Set(ByVal value As Date)
            _Entry_Date = value
        End Set
    End Property
    Public Property Created_By() As String
        Get
            Return _Created_By
        End Get
        Set(ByVal value As String)
            _Created_By = value
        End Set
    End Property
    Public Property Entry_Type() As Entry_type
        Get
            Return _Entry_Type
        End Get
        Set(ByVal value As Entry_type)
            _Entry_Type = value
        End Set
    End Property
    Public Property Hours() As Double
        Get
            Return Math.Round(_Hours, 2)
        End Get
        Set(ByVal value As Double)
            _Hours = value
            _FTE = _Hours / 7
            _Hours_Average = ((value * 100) / 7)
        End Set
    End Property
    Public Property Work_Distribution() As Double
        Get
            Return Math.Round(_Hours_Average, 2)
        End Get
        Set(ByVal value As Double)
            _Hours_Average = value
            _Hours = ((7 * value) / 100)
        End Set
    End Property
    Public ReadOnly Property FTEs() As Double
        Get
            Return Math.Round(_FTE, 2)
        End Get
    End Property

#End Region
#Region "Methods"
    Public Overrides Sub Clear()
        _Entry_ID = 0
        _Entry_Date = Now.Date
        _Created_By = ""
        _Entry_Type = Objects.Entry_type.Automatic
        _Hours = 0
        _FTE = 0
        _Hours_Average = 0
        _Task.Clear()
    End Sub
    Public Overrides Function Get_Delete() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Delete From Task_Entry Where Entry_ID = @Entry_ID"
        T.Include_Parameter("@Entry_ID", _Entry_ID)
        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Insert() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Insert Into [Task_Entry] (TaskID, Entry_Date, Created_By, Entry_Type, Hours, FTE, Hours_AVG) Values(@TaskID, @Entry_Date, @Created_By, @Entry_Type, @Hours, @FTE, @Hours_AVG)"
        T.Include_Parameter("@TaskID", _Task.ID)
        T.Include_Parameter("@Entry_Date", _Entry_Date)
        T.Include_Parameter("@Created_By", _Created_By)
        T.Include_Parameter("@Entry_Type", _Entry_Type)
        T.Include_Parameter("@Hours", _Hours)
        T.Include_Parameter("@FTE", _FTE)
        T.Include_Parameter("@Hours_AVG", _Hours_Average)

        TG.Include_Transaction(T)

        Return TG
    End Function
    Public Overrides Function Get_Search_List() As Transaction
        Dim T As New Transaction
        T.SQL_String = "Select Entry_ID as Code, TaskID + ' - ' + Entry_Date as Value From [Task_Entry]"
        Return T
    End Function
    Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
        Dim T As New Transaction

        T.SQL_String = "Select * From [Task_Entry]"
        If Not Code_ID Is Nothing Then
            T.SQL_String = T.SQL_String & " Where Entry_ID = @Entry_ID"
            T.Include_Parameter("@Entry_ID", Code_ID)
        End If

        Return T
    End Function
    Public Overrides Function Get_Update() As Transaction_Group
        Dim T As New Transaction
        Dim TG As New Transaction_Group

        T.SQL_String = "Update Task_Entry Set TaskID = @TaskID, Entry_Date = @Entry_Date, Created_By = @Created_By, Entry_Type = @Entry_Type, Hours = @Hours, FTE = @FTE, Hours_AVG = @Hours_AVG Where Entry_ID = @Entry_ID"
        T.Include_Parameter("@Entry_ID", _Entry_ID)
        'T.Include_Parameter("@TaskID", _TaskID)
        T.Include_Parameter("@TaskID", _Task.ID)
        T.Include_Parameter("@Entry_Date", _Entry_Date)
        T.Include_Parameter("@Created_By", _Created_By)
        T.Include_Parameter("@Entry_Type", _Entry_Type)
        T.Include_Parameter("@Hours", _Hours)
        T.Include_Parameter("@FTE", _FTE)
        T.Include_Parameter("@Hours_AVG", _Hours_Average)

        TG.Include_Transaction(T)
        Return TG
    End Function
    Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        If MyBase.Load(Code_ID) Then
            _Entry_ID = Data(0)("Entry_ID")
            '_TaskID = Data(0)("TaskID")
            '_TaskName = Data(0)("Task")
            _Entry_Date = Data(0)("Entry_Date")
            _Created_By = Data(0)("Created_By")
            _Entry_Type = Data(0)("Entry_Type")
            _
            _Hours = Data(0)("Hours")
            _FTE = _Hours / 7
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub New()
        Clear()
    End Sub
    Public Sub New(ByVal ID As Integer)
        Clear()
        Load(ID)
    End Sub
    Public Sub New(ByVal pEntry_ID As Integer, ByVal pTaskID As Integer, ByVal pEntry_Date As Date, ByVal pCreated_By As String, ByVal pEntry_Type As Integer, ByVal pHours As Double)
        Clear()
        _Task.Load(pTaskID)

        _Entry_ID = pEntry_ID
        _Entry_Date = pEntry_Date
        _Created_By = pCreated_By
        _Entry_Type = pEntry_Type
        _Hours = pHours
        _FTE = _Hours / 7
    End Sub
    Public Sub New(ByVal Task As Integer, ByVal [Date] As Date, Optional ByVal EType As Entry_type = Objects.Entry_type.Automatic)
        Dim Entry As New DataTable
        Dim TR As New Transaction

        If _Task.Load(Task) Then
            If ([Date].ToShortDateString >= _Task.Start) And ([Date].ToShortDateString <= _Task.End) Then
                TR.SQL_String = "Select * From vw_Entry_Detail Where TaskID = @TaskID And Entry_Date = @Entry_Date"
                TR.Include_Parameter("@TaskID", Task)
                TR.Include_Parameter("@Entry_Date", [Date].Date)
                Entry = GetTable(TR)

                If Entry.Rows.Count = 0 Then
                    _Entry_Date = Now.Date
                    _Entry_Type = EType
                    SQL_Action = Objects.SQL_Action.Insert
                Else
                    _Entry_ID = Entry(0)("Entry_ID")
                    _Entry_Date = Entry(0)("Entry_Date")
                    _Created_By = Entry(0)("Created_By")
                    _Entry_Type = Entry(0)("Entry_Type")
                    _FTE = Entry(0)("FTE")
                    _Hours = Entry(0)("Hours")
                    _Hours_Average = Entry(0)("Hours_AVG")

                    SQL_Action = Objects.SQL_Action.Update
                End If
            Else
                If MsgBox("Selected date for task: " & Task & " is out of task date." & Chr(13) & Chr(13) & "Task is valid from " & _Task.Start.ToShortDateString & " to " & _Task.End.ToShortDateString & Chr(13) & Chr(13) & "Would you like to extend task Start/End dates to match this new selected date?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Invalid date:") = MsgBoxResult.Yes Then
                    Dim DB As New Objects.Connection
                    Dim T As New Transaction

                    T.SQL_String = "Update Task Set "
                    If ([Date] < _Task.Start) Then
                        T.SQL_String = T.SQL_String & "[Start] "
                    ElseIf ([Date] > _Task.End) Then
                        T.SQL_String = T.SQL_String & "[End] "
                    End If

                    T.SQL_String = T.SQL_String & "= @Date Where ID = @ID"
                    T.Include_Parameter("@Date", [Date].ToShortDateString)
                    T.Include_Parameter("@ID", Task)
                    DB.Execute(T)
                Else
                    SQL_Action = Objects.SQL_Action.Nothing
                    _Entry_Date = Now.Date
                    _Entry_Type = EType
                End If

            End If
        End If
    End Sub
#End Region
End Class


