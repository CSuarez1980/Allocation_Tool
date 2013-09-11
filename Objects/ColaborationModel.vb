Namespace Collaboration_Module
    'Public Enum EN_CM_Tasks
    '    Mapping_And_Matching = 1
    '    Transactional_Work = 2
    '    Hypercare = 3
    '    Meeting = 4
    '    Scope_Data = 5
    '    Expertice = 6
    'End Enum
    Public Enum CM_Resource_Type
        None = 0
        PSS_Project_Manager = 1
        PMaaS = 2
        Service_Management_Contact = 3
        Service_Delivery_Contact_Direct = 4
        Service_Delivery_Contact_Indirect = 5
        Contractor = 6
        Development_Resource = 7
    End Enum
    Public Class CM_Project
        Inherits Base
#Region "Events"
        Public Event Loaded()
#End Region
#Region "Varianbles"
        Private _ID As Integer
        Private _Name As String
        Private _GBS_PM As String
        Private _PSS_PM As String
        Private _Type As Integer
        Private _Status As Integer

        Private _MappingMatching As New CM_Task("MappingMatching")
        Private _Transactional As New CM_Task("Transactional")
        Private _HyperCare As New CM_Task("HyperCare")
        Private _Meeting As New CM_Task("Meeting")
        Private _Scope As New CM_Task("Scope")
        Private _Expertise As New CM_Task("Expertise")

        Private _Documents As New List(Of CM_Project_Files)
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
        Public Property GBS_PM() As String
            Get
                Return _GBS_PM
            End Get
            Set(ByVal value As String)
                _GBS_PM = value
            End Set
        End Property
        Public Property PSS_PM() As String
            Get
                Return _PSS_PM
            End Get
            Set(ByVal value As String)
                _PSS_PM = value
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
        Public Property Type() As Integer
            Get
                Return _Type
            End Get
            Set(ByVal value As Integer)
                _Type = value
            End Set
        End Property
        Public Shadows Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal value As Integer)
                _Status = value
            End Set
        End Property
        'Public Property MM_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _MM_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _MM_List = value
        '    End Set
        'End Property
        'Public Property TR_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _TR_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _TR_List = value
        '    End Set
        'End Property
        'Public Property HY_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _HY_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _HY_List = value
        '    End Set
        'End Property
        'Public Property MT_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _MT_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _MT_List = value
        '    End Set
        'End Property
        'Public Property SP_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _SP_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _SP_List = value
        '    End Set
        'End Property
        'Public Property EX_List() As List(Of MC_Task_Resource)
        '    Get
        '        Return _EX_List
        '    End Get
        '    Set(ByVal value As List(Of MC_Task_Resource))
        '        _EX_List = value
        '    End Set
        'End Property

        Public Property Mapping_Matching() As CM_Task
            Get
                Return _MappingMatching
            End Get
            Set(ByVal value As CM_Task)
                _MappingMatching = value
            End Set
        End Property
        Public Property Transactional() As CM_Task
            Get
                Return _Transactional
            End Get
            Set(ByVal value As CM_Task)
                _Transactional = value
            End Set
        End Property
        Public Property HyperCare() As CM_Task
            Get
                Return _HyperCare
            End Get
            Set(ByVal value As CM_Task)
                _HyperCare = value
            End Set
        End Property
        Public Property Meeting() As CM_Task
            Get
                Return _Meeting
            End Get
            Set(ByVal value As CM_Task)
                _Meeting = value
            End Set
        End Property
        Public Property Scope() As CM_Task
            Get
                Return _Scope
            End Get
            Set(ByVal value As CM_Task)
                _Scope = value
            End Set
        End Property
        Public Property Expertise() As CM_Task
            Get
                Return _Expertise
            End Get
            Set(ByVal value As CM_Task)
                _Expertise = value
            End Set
        End Property

        Public ReadOnly Property Documents() As List(Of CM_Project_Files)
            Get
                Return _Documents
            End Get
        End Property
#End Region
#Region "Methods"
        Public Sub New()
            Clear()
        End Sub

        Public Overrides Sub Clear()
            _ID = 0
            _Name = ""
            _PSS_PM = ""
            _GBS_PM = ""
            _Type = 0
            _Status = 0

            _MappingMatching = New CM_Task("MappingMatching")
            _Transactional = New CM_Task("Transactional")
            _HyperCare = New CM_Task("HyperCare")
            _Meeting = New CM_Task("Meeting")
            _Scope = New CM_Task("Scope")
            _Expertise = New CM_Task("Expertise")
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim SP As New Objects.Stored_Procedure
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            SP.Stored_Procedure_Name = "sp_Get_Next_Project_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
            If SP.Execute() Then
                _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)

                T.SQL_String = "Insert Into clm_Project(ID, Name, GBS_PM, PSS_PM, Type_ID, Status) Values(@ID, @Name, @GBS_PM, @PSS_PM, @Type_ID, @Status)"
                T.Include_Parameter("@ID", _ID)
                T.Include_Parameter("@Name", _Name)
                T.Include_Parameter("@GBS_PM", _GBS_PM)
                T.Include_Parameter("@PSS_PM", _PSS_PM)
                T.Include_Parameter("@Type_ID", _Type)
                T.Include_Parameter("@Status", _Status)
                TG.Include_Transaction(T)

                TG.Include_Transaction(_MappingMatching.Get_Insert)
                TG.Include_Transaction(_Transactional.Get_Insert)
                TG.Include_Transaction(_HyperCare.Get_Insert)
                TG.Include_Transaction(_Meeting.Get_Insert)
                TG.Include_Transaction(_Scope.Get_Insert)
                TG.Include_Transaction(_Expertise.Get_Insert)

                Dim PT1 As New Objects.Transaction
                PT1.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT1.Include_Parameter("@Project_ID", _ID)
                PT1.Include_Parameter("@Task_ID", _MappingMatching.ID)
                TG.Include_Transaction(PT1)

                Dim PT2 As New Objects.Transaction
                PT2.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT2.Include_Parameter("@Project_ID", _ID)
                PT2.Include_Parameter("@Task_ID", _Transactional.ID)
                TG.Include_Transaction(PT2)

                Dim PT3 As New Objects.Transaction
                PT3.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT3.Include_Parameter("@Project_ID", _ID)
                PT3.Include_Parameter("@Task_ID", _HyperCare.ID)
                TG.Include_Transaction(PT3)

                Dim PT4 As New Objects.Transaction
                PT4.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT4.Include_Parameter("@Project_ID", _ID)
                PT4.Include_Parameter("@Task_ID", _Meeting.ID)
                TG.Include_Transaction(PT4)

                Dim PT5 As New Objects.Transaction
                PT5.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT5.Include_Parameter("@Project_ID", _ID)
                PT5.Include_Parameter("@Task_ID", _Scope.ID)
                TG.Include_Transaction(PT5)

                Dim PT6 As New Objects.Transaction
                PT6.SQL_String = "Insert Into clm_Project_Task(Project_ID, Task_ID) Values(@Project_ID, @Task_ID)"
                PT6.Include_Parameter("@Project_ID", _ID)
                PT6.Include_Parameter("@Task_ID", _Expertise.ID)
                TG.Include_Transaction(PT6)
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, [Name] as Value From [clm_Project]"
            Return T
        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [clm_Project]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T.SQL_String = "Update clm_Project Set Name = @Name, GBS_PM = @GBS_PM, PSS_PM = @PSS_PM, Type_ID = @Type_ID, Status = @Status Where (ID = @ID)"
            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Name", _Name)
            T.Include_Parameter("@GBS_PM", _GBS_PM)
            T.Include_Parameter("@PSS_PM", _PSS_PM)
            T.Include_Parameter("@Type_ID", _Type)
            T.Include_Parameter("@Status", _Status)

            TG.Include_Transaction(T)

            TG.Include_Transaction(_MappingMatching.Get_Update)
            TG.Include_Transaction(_Transactional.Get_Update)
            TG.Include_Transaction(_HyperCare.Get_Update)
            TG.Include_Transaction(_Meeting.Get_Update)
            TG.Include_Transaction(_Scope.Get_Update)
            TG.Include_Transaction(_Expertise.Get_Update)

            Return TG
        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)

            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _ID = Data(0)("ID").ToString
                _Name = Data(0)("Name").ToString
                _PSS_PM = Data(0)("PSS_PM").ToString
                _GBS_PM = Data(0)("GBS_PM").ToString
                _Type = Data(0)("Type_ID")
                _Status = Data(0)("Status")

                _Documents.Clear()

                'Load documents:
                Dim Doc As DataTable
                Doc = GetTable("Select ID From clm_Files Where Project_ID = " & _ID)

                For Each R In Doc.Rows
                    _Documents.Add(New CM_Project_Files(R("ID")))
                Next

                Dim Tasks As New DataTable

                Tasks = GetTable("Select * From clm_Project_Task Where Project_ID = " & Code_ID)
                If Tasks.Rows.Count > 0 Then
                    For Each R As DataRow In Tasks.Rows
                        Dim Tk As New CM_Task(CInt(R("Task_ID")))
                        Select Case Tk.Task_Type
                            Case 1
                                _MappingMatching = Tk
                            Case 2
                                _Transactional = Tk
                            Case 3
                                _HyperCare = Tk
                            Case 4
                                _Meeting = Tk
                            Case 5
                                _Scope = Tk
                            Case 6
                                _Expertise = Tk
                        End Select

                    Next
                End If

            End If
            RaiseEvent Loaded()
        End Function
#End Region
    End Class
    Public Class CM_Task
        Inherits Base
#Region "Variables"
        Private _Task_ID As Integer
        Private _Task_Type As New Objects.Collaboration_Module.Task_Type
        Private _Allocation As Double
        Private _Resources As New List(Of CM_Resource)
        Private _Hours As Double
#End Region
#Region "Properties"
        Public Property ID() As Integer
            Get
                Return _Task_ID
            End Get
            Set(ByVal value As Integer)
                _Task_ID = value
            End Set
        End Property
        Public Property Task_Type() As Integer
            Get
                Return _Task_Type.ID
            End Get
            Set(ByVal value As Integer)
                _Task_Type.Load(value)
            End Set
        End Property
        Public ReadOnly Property Task_Type_Descrition() As String
            Get
                Return _Task_Type.Description
            End Get
        End Property
        Public Property Resources() As List(Of CM_Resource)
            Get
                Return _Resources
            End Get
            Set(ByVal value As List(Of CM_Resource))
                _Resources = value
            End Set
        End Property
        Public ReadOnly Property Allocation() As Double
            Get
                Return Math.Round(_Allocation, 2)
            End Get
        End Property
        Public ReadOnly Property Hours() As Double
            Get
                Return Math.Round(_Hours, 2)
            End Get
        End Property
#End Region
#Region "Methods"
        Public Sub New()
            MyBase.new()
            Clear()
        End Sub
        Public Sub New(ByVal ID As Integer)
            Load(ID)
            Object_Status = Objects.Object_Status.Update
        End Sub
        Public Sub New(ByVal _Type As String)
            Clear()
            Object_Status = Objects.Object_Status.Insert
            Dim T As Integer = 0

            Select Case _Type
                Case "MappingMatching"
                    _Task_Type.Load(1)
                Case "Transactional"
                    _Task_Type.Load(2)
                Case "HyperCare"
                    _Task_Type.Load(3)
                Case "Meeting"
                    _Task_Type.Load(4)
                Case "Scope"
                    _Task_Type.Load(5)
                Case "Expertise"
                    _Task_Type.Load(6)
            End Select
        End Sub

        Public Overrides Sub Clear()
            _Task_ID = 0
            _Task_Type = New Objects.Collaboration_Module.Task_Type
            _Allocation = 0
            _Hours = 0
            _Resources.Clear()
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim SP As New Objects.Stored_Procedure
            Dim TG As New Objects.Transaction_Group


            SP.Stored_Procedure_Name = "sp_Get_Next_Task_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
            If SP.Execute() Then
                Dim T As New Objects.Transaction
                _Task_ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)

                T.SQL_String = "Insert Into clm_Task(ID, Task_Type_ID, Allocation) Values(@ID, @Task_Type, @Allocation)"
                T.Include_Parameter("@ID", _Task_ID)
                T.Include_Parameter("@Task_Type", _Task_Type.ID)
                T.Include_Parameter("@Allocation", _Allocation)

                TG.Include_Transaction(T)

                For Each i As CM_Resource In _Resources
                    TG.Include_Transaction(i.Get_Insert)
                    Dim T2 As New Objects.Transaction
                    T2.SQL_String = "Insert Into clm_Task_Resource(ID_Task, IDResource) Values(@ID_Task, @IDResource)"
                    T2.Include_Parameter("@ID_Task", _Task_ID)
                    T2.Include_Parameter("@IDResource", i.ID)
                    TG.Include_Transaction(T2)
                Next
            End If
            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [clm_Task]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction
            T.SQL_String = "Update clm_Task Set Task_Type_ID = @Task_Type, Allocation = @Allocation Where (ID = @ID)"
            T.Include_Parameter("@ID", _Task_ID)
            T.Include_Parameter("@Task_Type", _Task_Type.ID)
            T.Include_Parameter("@Allocation", _Allocation)
            TG.Include_Transaction(T)

            For Each i As CM_Resource In _Resources
                Select Case i.Object_Status
                    Case Objects.Object_Status.Insert

                        TG.Include_Transaction(i.Get_Insert)

                        If i.ID > 0 Then
                            Dim T2 As New Objects.Transaction
                            T2.SQL_String = "Insert Into clm_Task_Resource(ID_Task, IDResource) Values(@ID_Task, @IDResource)"
                            T2.Include_Parameter("@ID_Task", _Task_ID)
                            T2.Include_Parameter("@IDResource", i.ID)
                            TG.Include_Transaction(T2)
                        End If



                    Case Objects.Object_Status.Update
                        TG.Include_Transaction(i.Get_Update)

                    Case Objects.Object_Status.Delete
                        Dim T2 As New Objects.Transaction
                        T2.SQL_String = "Delete From clm_Task_Resource Where ((ID_Task = @ID_Task) And (IDResource = @IDResource))"
                        T2.Include_Parameter("@ID_Task", _Task_ID)
                        T2.Include_Parameter("@IDResource", i.ID)
                        TG.Include_Transaction(T2)

                        TG.Include_Transaction(i.Get_Update)
                End Select


            Next
            Return TG
        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _Task_ID = Data(0)("ID").ToString
                _Task_Type.Load(Data(0)("Task_Type_ID").ToString)
                _Allocation = Data(0)("Allocation").ToString
                'Load task resources:
                Dim TR As New DataTable
                TR = GetTable("Select * From clm_Task_Resource Where ID_Task = " & Code_ID)
                If TR.Rows.Count > 0 Then
                    For Each r As DataRow In TR.Rows
                        Dim RS As New CM_Resource(r("IDResource"))
                        If RS.ID > 0 Then
                            _Resources.Add(RS)
                        End If
                    Next
                End If
            End If
            Get_Allocation_Value()
        End Function
        Public Sub Remove_Resource(ByVal Resource_ID As Integer)
            For Each r As CM_Resource In _Resources
                If r.ID = Resource_ID Then
                    Dim T1 As New Transaction
                    Dim T2 As New Transaction
                    Dim TG As New Transaction_Group

                    T1.SQL_String = "Delete From clm_Task_Resource Where ((ID_Task = @ID_Task) And (IDResource = @IDResource))"
                    T1.Include_Parameter("@ID_Task", _Task_ID)
                    T1.Include_Parameter("@IDResource", r.ID)
                    TG.Include_Transaction(T1)

                    T2.SQL_String = "Delete From clm_Resource Where (Resource_ID = @Resource_ID)"
                    T2.Include_Parameter("@Resource_ID", r.ID)
                    TG.Include_Transaction(T2)

                    If Execute(TG) Then
                        _Resources.Remove(r)
                        Exit Sub
                    End If

                    Get_Allocation_Value()
                End If
            Next
        End Sub

        Private Sub Get_Allocation_Value()
            _Allocation = 0
            _Hours = 0

            For Each r In _Resources
                _Allocation += r.MonthlyFTE
                _Hours += r.Hours
            Next
            _Allocation = _Allocation
            _Hours = _Hours
        End Sub
#End Region
    End Class
    Public Class CM_Resource
        Inherits Base
#Region "Variables"
        Private _Resource_ID As Integer
        Private _Resource_Type As New Objects.Collaboration_Module.Resource_Type
        Private _Month As Date = Now.Date
        Private _Hours As Double
        Private _FTE As Double
        Private _Event As String = ""
        Private _Entry_Type As String = ""
        Private _Owner As New Objects.User
#End Region
#Region "Properties"
        Public Property ID() As Integer
            Get
                Return _Resource_ID
            End Get
            Set(ByVal value As Integer)
                _Resource_ID = value
            End Set
        End Property
        Public Property Resource_Type_ID() As Integer
            Get
                Return _Resource_Type.ID
            End Get
            Set(ByVal value As Integer)
                If Not _Resource_Type.Load(value) Then
                    MsgBox("Invalid resource type code.", MsgBoxStyle.Information, "Resource type: " & value)
                End If
            End Set
        End Property
        Public ReadOnly Property Res_Type_Description() As String
            Get
                Return _Resource_Type.Description
            End Get
        End Property
        Public Property Month() As Date
            Get
                Return _Month
            End Get
            Set(ByVal value As Date)
                _Month = value
            End Set
        End Property
        Public Property Hours() As Double
            Get
                Return _Hours
            End Get
            Set(ByVal value As Double)
                _Hours = value
                Check_FTE()
            End Set
        End Property
        Public ReadOnly Property MonthlyFTE()
            Get
                Return Math.Round(_FTE, 3)
            End Get
        End Property
        Public Property [Event]() As String
            Get
                Return _Event
            End Get
            Set(ByVal value As String)
                _Event = value
            End Set
        End Property
        Public Property Entry_type() As String
            Get
                Return _Entry_Type
            End Get
            Set(ByVal value As String)
                _Entry_Type = value
                Check_FTE()
            End Set
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
#End Region
#Region "Methods"
        Public Overrides Sub Clear()
            _Resource_ID = 0
            _Resource_Type = New Objects.Collaboration_Module.Resource_Type
            _Month = Now.Date
            _Hours = 0
            _FTE = 0
            _Event = ""
            _Owner.Clear()
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim TG As New Objects.Transaction_Group

            If _Resource_Type.ID <> 0 Then
                Dim SP As New Objects.Stored_Procedure
                Dim T As New Objects.Transaction

                SP.Stored_Procedure_Name = "sp_Get_Next_Task_Resource_ID"
                SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
                If SP.Execute() Then
                    T = New Transaction
                    _Resource_ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)

                    T.SQL_String = "Insert Into clm_Resource(Resource_ID,Resource_Type,Month,Hours,FTE,Event,Entry_Type,Owner) Values(@Resource_ID,@Resource_Type,@Month,@Hours,@FTE,@Event,@Entry_Type,@Owner)"

                    T.Include_Parameter("@Resource_ID", _Resource_ID)
                    T.Include_Parameter("@Resource_Type", _Resource_Type.ID)
                    T.Include_Parameter("@Month", _Month)
                    T.Include_Parameter("@Hours", _Hours)
                    T.Include_Parameter("@FTE", _FTE)
                    T.Include_Parameter("@Event", _Event)
                    T.Include_Parameter("@Entry_Type", _Entry_Type)
                    T.Include_Parameter("@Owner", _Owner.TNumber)
                    TG.Include_Transaction(T)
                End If
            End If
            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [clm_Resource]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [Resource_ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group

            Select Case Object_Status
                Case Objects.Object_Status.Insert
                    TG = Get_Insert()
                Case Objects.Object_Status.Delete
                    TG = Get_Delete()
                Case Else
                    Dim T As New Objects.Transaction
                  
                    T.SQL_String = "Update clm_Resource Set Resource_Type = @Resource_Type, Month = @Month, Hours = @Hours, FTE = @FTE, Event = @Event, Entry_Type = @Entry_Type, Owner = @Owner Where (Resource_ID = @Resource_ID)"
                    T.Include_Parameter("@Resource_ID", _Resource_ID)
                    T.Include_Parameter("@Resource_Type", _Resource_Type.ID)
                    T.Include_Parameter("@Month", _Month)
                    T.Include_Parameter("@Hours", _Hours)
                    T.Include_Parameter("@FTE", _FTE)
                    T.Include_Parameter("@Event", _Event)
                    T.Include_Parameter("@Entry_Type", _Entry_Type)
                    T.Include_Parameter("@Owner", _Owner.TNumber)
                    TG.Include_Transaction(T)
            End Select

            Return TG
        End Function
        Public Sub New(ByVal ID As Integer)
            Load(ID)
        End Sub
        Public Sub New()
            MyBase.new()
        End Sub
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)

            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing AndAlso Data.Rows.Count > 0 Then
                _Resource_ID = Code_ID
                _Event = Data(0)("Event").ToString
                _FTE = Data(0)("FTE").ToString
                _Hours = Data(0)("Hours").ToString
                _Month = Data(0)("Month").ToString
                _Resource_Type.Load(Data(0)("Resource_Type").ToString)
                _Entry_Type = Data(0)("Entry_Type").ToString
                _Owner.Load(Data(0)("Owner").ToString)
            End If
        End Function
        Private Sub Check_FTE()
            If _Entry_Type.ToString.ToUpper <> "MATERIAL" Then
                _FTE = Objects.Functions.Collaboration_Module.Get_FTE(_Hours, CM_Input_Type.Hours)
            Else
                _FTE = Objects.Functions.Collaboration_Module.Get_FTE(_Hours, CM_Input_Type.Materials)
            End If
        End Sub
#End Region
    End Class
    Public Class Task_Type
        Inherits Base
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
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T = New Transaction
            T.SQL_String = "Delete clm_Task_Type Where ID = @ID"

            T.Include_Parameter("@ID", _ID)
            TG.Include_Transaction(T)

            Return TG
        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim SP As New Objects.Stored_Procedure
            Dim TG As New Objects.Transaction_Group

            SP.Stored_Procedure_Name = "sp_Get_Next_Task_Type_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
            If SP.Execute() Then
                Dim T As New Objects.Transaction

                _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)

                T = New Transaction
                T.SQL_String = "Insert Into clm_Task_Type(ID, Description) Values(@ID, @Description)"

                T.Include_Parameter("@ID", _ID)
                T.Include_Parameter("@Description", _Description)
                TG.Include_Transaction(T)
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, [Description] as Value From [clm_Task_Type]"
            Return T
        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select * From clm_Task_Type Where ID = @ID"

            T.Include_Parameter("@ID", Code_ID)

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T = New Transaction
            T.SQL_String = "Update clm_Task_Type set Description = @Description Where ID = @ID"

            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Description", _Description)
            TG.Include_Transaction(T)

            Return TG
        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            If MyBase.Load(Code_ID) Then
                _ID = Data.Rows(0)("ID")
                _Description = Data.Rows(0)("Description")

                Return True
            Else
                Return False
            End If
        End Function
#End Region
    End Class
    Public Class Resource_Type
        Inherits Base
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
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T = New Transaction
            T.SQL_String = "Delete clm_Resource_Type Where ID = @ID"

            T.Include_Parameter("@ID", _ID)
            TG.Include_Transaction(T)

            Return TG
        End Function

        Public Overrides Function Get_Insert() As Transaction_Group
            Dim SP As New Objects.Stored_Procedure
            Dim TG As New Objects.Transaction_Group

            SP.Stored_Procedure_Name = "sp_Get_Next_Resource_Type_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
            If SP.Execute() Then
                Dim T As New Objects.Transaction

                _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)
                T.SQL_String = "Insert Into clm_Resource_Type(ID, Description) Values(@ID, @Description)"

                T.Include_Parameter("@ID", _ID)
                T.Include_Parameter("@Description", _Description)
                TG.Include_Transaction(T)
            End If

            Return TG
        End Function

        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, [Description] as Value From [clm_Resource_Type]"
            Return T
        End Function

        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [clm_Resource_Type]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where ID = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function

        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T = New Transaction
            T.SQL_String = "Update clm_Resource_Type set Description = @Description Where ID = @ID"

            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Description", _Description)
            TG.Include_Transaction(T)

            Return TG
        End Function

        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            If MyBase.Load(Code_ID) Then
                _ID = Data.Rows(0)("ID")
                _Description = Data.Rows(0)("Description")

                Return True
            Else
                Return False
            End If
        End Function
#End Region
    End Class
    Public Class CM_Resource_Entry
        Inherits Objects.Base
        'Month Name @SQLServer: CAST(DATENAME(dbo.clm_Resource.Month, dbo.clm_Resource.Month) AS varchar(10)) + ' ' + CAST(DATEPART(year, dbo.clm_Resource.Month) AS varchar(4))
#Region "Variables"
        Private _Value As Double
        Private _Project_ID As Integer
        Private _Project_Name As String
        Private _Task_ID As Integer
        Private _Task_Type As String
        Private _Resource_ID As Integer
        Private _Month As Date
        Private _Owner As New Objects.User
        Private _Input_Type As String
        Private _FTE_Value As Double

#End Region
#Region "Properties"
        Protected Friend ReadOnly Property Project_ID() As Integer
            Get
                Return _Project_ID
            End Get
        End Property
        Public ReadOnly Property Project_Name() As String
            Get
                Return _Project_Name
            End Get
        End Property
        Protected Friend ReadOnly Property Task_ID() As Integer
            Get
                Return _Task_ID
            End Get
        End Property
        Public ReadOnly Property Task_Type() As String
            Get
                Return _Task_Type
            End Get
        End Property
        Protected Friend ReadOnly Property Resource_ID() As Integer
            Get
                Return _Resource_ID
            End Get
        End Property
        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                If value >= 0 Then
                    _Value = value

                    If _Input_Type.ToString.ToUpper <> "MATERIAL" Then
                        _FTE_Value = Objects.Functions.Collaboration_Module.Get_FTE(value, CM_Input_Type.Hours)
                    Else
                        _FTE_Value = Objects.Functions.Collaboration_Module.Get_FTE(value, CM_Input_Type.Materials)
                    End If
                Else
                    MsgBox("Entry must be great than zero", MsgBoxStyle.Exclamation, "Wrong entry value")
                End If
            End Set
        End Property
        Public ReadOnly Property Input_Type() As String
            Get
                Return IIf(_Input_Type.ToUpper.Length > 0, _Input_Type, "Hours")
            End Get
        End Property
        Protected Friend ReadOnly Property FTE_Value() As Double
            Get
                Return _FTE_Value
            End Get
        End Property
#End Region
#Region "Methods"
        Public Overrides Sub Clear()
            _Value = 0
            _Project_ID = 0
            _Project_Name = ""
            _Task_ID = 0
            _Task_Type = ""
            _Resource_ID = 0
            _Month = Now.Date
            _Input_Type = ""
            _FTE_Value = 0
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group

        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction


            T.SQL_String = "Select * From [vw_CM_Open_Task]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [Resource ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group

        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            If MyBase.Load(Code_ID) Then
                '_Record_Date = Now.Date
                _Value = 0

                _Project_ID = Data.Rows(0)("Project ID")
                _Project_Name = Data.Rows(0)("Project Name")
                _Task_ID = Data.Rows(0)("Task ID")
                _Task_Type = Data.Rows(0)("Task Type")
                _Resource_ID = Data.Rows(0)("Resource ID")
                _Month = Data.Rows(0)("Month")
                _Owner.Load(Data.Rows(0)("Owner"))
                _Input_Type = Data.Rows(0)("Entry_Type")
                Return True
            Else
                Return False
            End If
        End Function
#End Region

        Public Sub New()

        End Sub
    End Class
    Public Class CM_Entry
        Inherits Base
        'Table: clm_Resource_Entry
#Region "Events"
        Public Event Refreshed()
#End Region
#Region "Variables"
        Private _Saved_By As New Objects.User
        Private _Resources As New List(Of Objects.Collaboration_Module.CM_Resource_Entry)
        Private _Entry_Date As Date
#End Region
#Region "Properties"
        Public Property Saved_By() As String
            Get
                Return _Saved_By.TNumber
            End Get
            Set(ByVal value As String)
                _Saved_By.Load(value)
            End Set
        End Property
        Public Property Resources() As List(Of Objects.Collaboration_Module.CM_Resource_Entry)
            Get
                Return _Resources
            End Get
            Set(ByVal value As List(Of Objects.Collaboration_Module.CM_Resource_Entry))
                _Resources = value
            End Set
        End Property
        Public Property Entry_Date() As Date
            Get
                Return _Entry_Date
            End Get
            Set(ByVal value As Date)
                _Entry_Date = value
                Refresh(value)
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub New(ByVal TNumber As String, ByVal Month As Date)
            Refresh(Month, TNumber)
        End Sub
        Public Overrides Sub Clear()
            _Resources.Clear()
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim TG As New Objects.Transaction_Group

            For Each R As Objects.Collaboration_Module.CM_Resource_Entry In _Resources
                If R.Value > 0 Then
                    Dim T As New Objects.Transaction
                    T.SQL_String = "Insert Into clm_Resource_Entry(Record_Date, Created_By, Resource_ID, Entry_Month, Entry_Value, Entry_FTE_Value) Values({Fn Now()}, @Created_By, @Resource_ID, @Entry_Month, @Entry_Value, @Entry_FTE_Value)"
                    T.Include_Parameter("@Created_By", _Saved_By.TNumber)
                    T.Include_Parameter("@Resource_ID", R.Resource_ID)
                    T.Include_Parameter("@Entry_Month", _Entry_Date)
                    T.Include_Parameter("@Entry_Value", R.Value)
                    T.Include_Parameter("@Entry_FTE_Value", R.FTE_Value)

                    TG.Include_Transaction(T)
                End If
            Next
            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction

        End Function
        Public Overrides Function Get_Update() As Transaction_Group

        End Function
        Public Sub Refresh(ByVal Month As Date, Optional ByVal TNumber As String = "")
            _Resources.Clear()
            _Entry_Date = Month
            _Saved_By.TNumber = IIf(TNumber <> "", TNumber, _Saved_By.TNumber)
            Dim Data As New DataTable
            Dim T As New Transaction
            Dim StartDate As Date
            Dim EndDate As Date

            Date.TryParse(Month.Year & "/" & Month.Month & "/" & "01", StartDate)
            Date.TryParse(Month.Year & "/" & Month.Month & "/" & Date.DaysInMonth(Month.Year, Month.Month), EndDate)

            T.SQL_String = ("Select * From vw_CM_Open_Task Where ((Owner = @Owner) And (Month between @Start and @End))")
            T.Include_Parameter("@Owner", IIf(TNumber <> "", TNumber, _Saved_By.TNumber))
            T.Include_Parameter("@Start", StartDate)
            T.Include_Parameter("@End", EndDate)

            Data = GetTable(T)

            If Data.Rows.Count > 0 Then
                For Each R As DataRow In Data.Rows
                    Dim RS As New Objects.Collaboration_Module.CM_Resource_Entry
                    RS.Load(R("Resource ID"))
                    _Resources.Add(RS)
                Next
            End If
            RaiseEvent Refreshed()
        End Sub

#End Region
    End Class
    Public Class CM_Project_Files
#Region "Variables"
        Private _File_ID As Integer
        Private _Project_ID As Integer
        Private _File_Name As String
        Private _Owner As String
        Private _Visibility As Integer
        Private _Data As Byte()
        Private _Upload_Date As Date
        Private _Ext As String
#End Region
#Region "Properties"
        Public ReadOnly Property File_ID() As Integer
            Get
                Return _File_ID
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
        Public Property File_Name() As String
            Get
                Return _File_Name
            End Get
            Set(ByVal value As String)
                _File_Name = value
            End Set
        End Property
        Public ReadOnly Property Owner() As String
            Get
                Return _Owner
            End Get
        End Property
        Public ReadOnly Property Upload_Date() As Date
            Get
                Return _Upload_Date
            End Get
        End Property
        Protected Friend ReadOnly Property Extension() As String
            Get
                Return _Ext
            End Get
        End Property
#End Region
#Region "Methods"
        Public Sub New(ByVal File_ID As Integer, Optional ByVal Load_File As Boolean = False)
            Load(File_ID, Load_File)
        End Sub
        Public Sub New()

        End Sub

        Public Sub Load(ByVal File_ID As Integer, ByVal Load_File As Boolean)
            Dim DB As New Objects.Connection
            Dim Table As New DataTable

            If Load_File Then
                Table = DB.GetTable("Select * From clm_Files Where ID = " & File_ID)
            Else
                Table = DB.GetTable("Select ID, Project_ID, File_Name, Owner, Visibility, Upload_Date, Ext From clm_Files Where ID = " & File_ID)
            End If


            If Table.Rows.Count > 0 Then
                _File_ID = Table.Rows(0)("ID")
                _Project_ID = Table.Rows(0)("Project_ID")
                _File_Name = Table.Rows(0)("File_Name")
                _Owner = Table.Rows(0)("Owner")
                _Visibility = Table.Rows(0)("Visibility")

                If (Load_File) Then
                    _Data = Table.Rows(0)("Data")
                End If

                _Upload_Date = Table.Rows(0)("Upload_Date")
                _Ext = Table.Rows(0)("Ext")

            End If

        End Sub

        Public Function Upload_File(ByVal Path As String, ByVal pOwner As String, ByVal Pid As Integer, Optional ByVal pVisibility As Integer = 0) As Boolean
            Dim Success As Boolean = False

            If IO.File.Exists(Path) Then
                Try
                    'Get the file extention:
                    Dim FE As String() = Split(Path, ".")
                    _Ext = FE(FE.Count - 1)

                    'Read file
                    Dim S As String = ""
                    _Data = My.Computer.FileSystem.ReadAllBytes(Path)

                    'Optional: in the future for block file to others
                    _Visibility = pVisibility

                    _Project_ID = Pid
                    _Owner = pOwner
                    _Upload_Date = Now()

                    Dim DB As New Objects.Connection
                    Dim T As New Objects.Transaction

                    T.SQL_String = "Insert Into clm_Files (Project_ID, File_Name, Owner, Visibility, Data, Upload_Date,Ext) Values(@Project_ID, @File_Name, @Owner, @Visibility, @Data, {fn Now()},@Ext)"
                    T.Include_Parameter("@Project_ID", _Project_ID)
                    T.Include_Parameter("@File_Name", _File_Name)
                    T.Include_Parameter("@Owner", pOwner)
                    T.Include_Parameter("@Visibility", _Visibility)
                    T.Include_Parameter("@Data", _Data)
                    T.Include_Parameter("@Ext", _Ext)

                    If DB.Execute(T) Then
                        Success = True
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                    Success = False
                End Try

            Else
                MsgBox("File not found.", MsgBoxStyle.Information)
            End If

            Return Success
        End Function
        Public Function Download_File(ByVal Path As String) As Boolean
            Dim Status As Boolean = False
            Dim DataFile As DataTable
            Dim cn As New Objects.Connection

            DataFile = cn.GetTable("Select * From clm_Files Where ID = " & _File_ID)

            If DataFile.Rows.Count > 0 Then
                _Data = DataFile(0)("Data")
                If _Data.Length > 0 Then
                    My.Computer.FileSystem.WriteAllBytes(Path, _Data, False)
                Else
                    MsgBox("File can't be created, data not found.", MsgBoxStyle.Exclamation)
                End If
            End If

            Return Status
        End Function
        Public Function Delete_File() As Boolean
            Dim Res As Boolean = False

            Try
                Dim DB As New Objects.Connection
                If MsgBox("Do you really want to delete this file?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete file") = MsgBoxResult.Yes Then
                    If DB.Execute("Delete From clm_Files Where ID = " & _File_ID) Then
                        Res = True
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Return Res
        End Function

        Public Function Get_Default_Ext() As String
            Return _Ext
        End Function
#End Region
    End Class
    Namespace Variants
        Public Class clm_Variant
#Region "Variables"
            Private _Projects As New List(Of clm_Var)
            Private _Projects_type As New List(Of clm_Var)
            Private _Tasks As New List(Of clm_Var)
            Private _Owner As New List(Of clm_Var)
            Private _Resource As New List(Of clm_Var)
#End Region
#Region "Properties"
            Public ReadOnly Property Projects() As List(Of clm_Var)
                Get
                    Return _Projects
                End Get
            End Property
            Public ReadOnly Property Project_Value() As String
                Get
                    Dim i As Integer = Count_Selected(_Projects)

                    If i > 0 Then
                        Return "[" & i & "] Project(s) selected"
                    Else
                        Return "Show all projects"
                    End If
                End Get
            End Property

            Public ReadOnly Property Project_Types() As List(Of clm_Var)
                Get
                    Return _Projects_type
                End Get
            End Property
            Public ReadOnly Property Project_Type_Value() As String
                Get

                    Dim i As Integer = Count_Selected(_Projects_type)
                   
                    If i > 0 Then
                        Return "[" & i & "] Project type(s) selected"
                    Else
                        Return "Show all project types"
                    End If

                End Get
            End Property

            Public ReadOnly Property Task() As List(Of clm_Var)
                Get
                    Return _Tasks
                End Get
            End Property
            Public ReadOnly Property Task_Value() As String
                Get

                    Dim i As Integer = Count_Selected(_Tasks)

                    If i > 0 Then
                        Return "[" & i & "] task(s) selected"
                    Else
                        Return "Show all task"
                    End If

                End Get
            End Property

            Public ReadOnly Property Owner() As List(Of clm_Var)
                Get
                    Return _Owner
                End Get
            End Property
            Public ReadOnly Property Owner_Value() As String
                Get
                    Dim i As Integer = Count_Selected(_Owner)

                    If i > 0 Then
                        Return "[" & i & "] contact(s) selected"
                    Else
                        Return "Show all contacts"
                    End If

                End Get
            End Property

            Public ReadOnly Property Resource() As List(Of clm_Var)
                Get
                    Return _Resource
                End Get
            End Property
            Public ReadOnly Property Resource_Value() As String
                Get

                    Dim i As Integer = Count_Selected(_Resource)
                    
                    If i > 0 Then
                        Return "[" & i & "] resource(s) selected"
                    Else
                        Return "Show all resources"
                    End If

                End Get
            End Property
#End Region
#Region "Methods"
            Private Function Count_Selected(ByVal List As List(Of clm_Var)) As Integer
                Dim c As Integer = 0

                For Each i In List
                    If i.Selected Then
                        c += 1
                    End If
                Next

                Return c
            End Function
            Public Function Get_Filter() As String
                Dim pFilter As String = ""

                If Count_Selected(_Projects) > 0 Then
                    Dim F As String = ""
                    For Each i In _Projects
                        If i.Selected Then
                            If F.Length = 0 Then
                                F = "(ID = " & i.ID & ")"
                            Else
                                F = F & " Or (ID = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = " And (" & F & ")"
                End If


                If Count_Selected(_Projects_type) Then
                    Dim F As String = ""
                    For Each i In _Projects_type
                        If i.Selected Then
                            If F.Length = 0 Then
                                F = "(Project_Type_ID = " & i.ID & ")"
                            Else
                                F = F & " Or (Project_Type_ID = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If


                If Count_Selected(_Tasks) Then
                    Dim F As String = ""
                    For Each i In _Tasks
                        If i.Selected Then
                            If F.Length = 0 Then
                                F = "([Task ID] = " & i.ID & ")"
                            Else
                                F = F & " Or ([Task ID] = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If


                If Count_Selected(_Owner) Then
                    Dim F As String = ""
                    For Each i In _Owner
                        If i.Selected Then
                            If F.Length = 0 Then
                                F = "(Owner = '" & i.ID & "')"
                            Else
                                F = F & " Or (Owner = '" & i.ID & "')"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If


                If Count_Selected(_Resource) Then
                    Dim F As String = ""
                    For Each i In _Resource
                        If i.Selected Then
                            If F.Length = 0 Then
                                F = "(Resource_Type_ID = " & i.ID & ")"
                            Else
                                F = F & " Or (Resource_Type_ID = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If

                Return pFilter
            End Function
#End Region
        End Class
        Public Class clm_Var
#Region "Variables"
            Private _Selected As Boolean
            Private _ID As Object
            Private _Name As String
#End Region
#Region "Properties"
            Public Property Selected() As Boolean
                Get
                    Return _Selected
                End Get
                Set(ByVal value As Boolean)
                    _Selected = value
                End Set
            End Property
            Protected Friend Property ID() As Object
                Get
                    Return _ID
                End Get
                Set(ByVal value As Object)
                    _ID = value
                End Set
            End Property
            Public Property Description() As String
                Get
                    Return _Name
                End Get
                Set(ByVal value As String)
                    _Name = value
                End Set
            End Property

#End Region
#Region "Methods"
            Public Sub New()

            End Sub
            Public Sub New(ByVal ID As Object, ByVal Description As String)
                If Not ID Is Nothing AndAlso Not Description Is Nothing Then
                    _Selected = True
                    _ID = ID
                    _Name = Description
                End If
            End Sub
#End Region
        End Class
    End Namespace
End Namespace