Namespace Corporate_Projects
    Public Class CP_Project
        Inherits Objects.Base
#Region "Events"
        Public Event Loaded()
#End Region
#Region "Variables"
        Private _ID As Integer
        Private _Name As String
        Private _GBS_PM As String
        Private _PSS_PM As String
        Private _Type As Integer
        Private _Status As Integer
        Private _Resource As New List(Of CP_Resource)

        Private _Documents As New List(Of Objects.Corporate_Projects.CP_Project_Files)
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

        Public Property Tasks() As List(Of CP_Resource)
            Get
                Return _Resource
            End Get
            Set(ByVal value As List(Of CP_Resource))
                _Resource = value
            End Set
        End Property
        Public ReadOnly Property Documents() As List(Of Objects.Corporate_Projects.CP_Project_Files)
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
            _Type = 1
            _Status = 1

            _Resource.Clear()
            _Documents.Clear()
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T.SQL_String = "Delete From cp_Project Where (ID = @ID)"
            T.Include_Parameter("@ID", _ID)
            TG.Include_Transaction(T)

            Dim T2 As New Objects.Transaction
            T2.SQL_String = "Delete From cp_Resources Where ([Project] = @ID)"
            T2.Include_Parameter("@ID", _ID)
            TG.Include_Transaction(T2)

            Return TG
        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim SP As New Objects.Stored_Procedure
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            SP.Stored_Procedure_Name = "sp_Get_Next_CP_Project_ID"
            SP.Include_Parameter("@ID", 0, ParameterDirection.Output)
            If SP.Execute() Then
                _ID = SP.Get_Parameter_Value("@ID", Get_Param_From.Server)

                T.SQL_String = "Insert Into cp_Project(ID, Name, GBS_PM, PSS_PM, Type_ID, Status) Values(@ID, @Name, @GBS_PM, @PSS_PM, @Type_ID, @Status)"
                T.Include_Parameter("@ID", _ID)
                T.Include_Parameter("@Name", _Name)
                T.Include_Parameter("@GBS_PM", _GBS_PM)
                T.Include_Parameter("@PSS_PM", _PSS_PM)
                T.Include_Parameter("@Type_ID", _Type)
                T.Include_Parameter("@Status", _Status)
                TG.Include_Transaction(T)

                For Each R As Objects.Corporate_Projects.CP_Resource In _Resource
                    If R.Resource_Type_ID <> 0 Then
                        R.Project = _ID
                        TG.Include_Transaction(R.Get_Insert)
                    End If
                Next
            End If

            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, [Name] as Value From [cp_Project]"
            Return T
        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [cp_Project]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim TG As New Objects.Transaction_Group
            Dim T As New Objects.Transaction

            T.SQL_String = "Update cp_Project Set Name = @Name, GBS_PM = @GBS_PM, PSS_PM = @PSS_PM, Type_ID = @Type_ID, Status = @Status Where (ID = @ID)"
            T.Include_Parameter("@ID", _ID)
            T.Include_Parameter("@Name", _Name)
            T.Include_Parameter("@GBS_PM", _GBS_PM)
            T.Include_Parameter("@PSS_PM", _PSS_PM)
            T.Include_Parameter("@Type_ID", _Type)
            T.Include_Parameter("@Status", _Status)

            TG.Include_Transaction(T)

            For Each r As Objects.Corporate_Projects.CP_Resource In _Resource
                Select Case r.Object_Status
                    Case Objects.Object_Status.Insert
                        If r.Resource_Type_ID <> 0 Then
                            r.Project = _ID
                            TG.Include_Transaction(r.Get_Insert)
                        End If

                    Case Objects.Object_Status.Update
                        TG.Include_Transaction(r.Get_Update)
                End Select
            Next

            Return TG
        End Function

        Public Function Delete_Resource(ByVal Task_ID As Integer) As Boolean
            For Each T As Objects.Corporate_Projects.CP_Resource In _Resource
                If T.ID = Task_ID Then
                    Return T.Delete()
                End If
            Next
        End Function

        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _ID = Data(0)("ID")
                _Name = Data(0)("Name").ToString
                _GBS_PM = Data(0)("GBS_PM").ToString
                _PSS_PM = Data(0)("PSS_PM").ToString
                _Type = Data(0)("Type_ID")
                _Status = Data(0)("Status")
                _Resource.Clear()

                'Load documents:
                _Documents.Clear()
                Dim Doc As DataTable
                Doc = GetTable("Select ID From cp_Files Where Project_ID = " & _ID)

                For Each R In Doc.Rows
                    _Documents.Add(New Objects.Corporate_Projects.CP_Project_Files(R("ID")))
                Next

                Dim TR As New DataTable
                TR = GetTable("Select * From cp_Resources Where Project = " & Code_ID)
                If TR.Rows.Count > 0 Then
                    For Each r As DataRow In TR.Rows
                        Dim RS As New CP_Resource(r("Resource_ID"))
                        If RS.ID > 0 Then
                            _Resource.Add(RS)
                        End If
                    Next
                End If

                RaiseEvent Loaded()
            End If
        End Function
#End Region

    End Class
    Public Class CP_Resource
        Inherits Objects.Base

#Region "Variables"
        Private _Resource_ID As Integer
        Private _Resource_Type As New Objects.Collaboration_Module.Resource_Type
        Private _Owner As New Objects.User
        Private _Task_Month As Date = Now.Date
        Private _Value As Double
        Private _Entry_Type As String = ""
        Private _FTE As Double
        Private _Event As String = ""
        Private _Project As Integer
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
        Public Property Owner() As String
            Get
                Return _Owner.TNumber
            End Get
            Set(ByVal value As String)
                If _Owner.Load(value) Then
                    _Owner.Name = "Not Found"
                End If
            End Set
        End Property
        Public ReadOnly Property Owner_Name() As String
            Get
                Return _Owner.Name
            End Get
        End Property
        Public Property Task_Month() As Date
            Get
                Return _Task_Month
            End Get
            Set(ByVal value As Date)
                _Task_Month = value
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
        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                _Value = value
                Check_FTE()
            End Set
        End Property
        Public ReadOnly Property FTE() As Double
            Get
                Return Math.Round(_FTE, 2)
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
        Public Property Project() As Integer
            Get
                Return _Project
            End Get
            Set(ByVal value As Integer)
                _Project = value
            End Set
        End Property
#End Region
#Region "Methods"
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal Code_ID As Integer)
            Load(Code_ID)
        End Sub

        Public Overrides Sub Clear()
            _Resource_ID = 0
            _Resource_Type = New Objects.Collaboration_Module.Resource_Type
            _Owner = New Objects.User
            _Task_Month = Now.Date
            _Value = 0
            _Entry_Type = ""
            _FTE = 0
            _Event = ""
            _Project = 0
        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group
            Dim T As New Objects.Transaction
            Dim TG As New Objects.Transaction_Group

            T.SQL_String = "Delete From cp_Resources Where Resource_ID = @Resource_ID"
            T.Include_Parameter("@Resource_ID", _Resource_ID)

            TG.Include_Transaction(T)
            Return TG
        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim T As New Objects.Transaction
            Dim TG As New Objects.Transaction_Group

            T.SQL_String = "Insert Into cp_Resources(Project,Resource_Type,Owner,Task_Month,Value,Entry_Type,FTE,Event) Values(@Project,@Resource_Type,@Owner,@Task_Month,@Value,@Entry_Type,@FTE,@Event)"
            T.Include_Parameter("@Project", _Project)
            T.Include_Parameter("@Resource_Type", _Resource_Type.ID)
            T.Include_Parameter("@Owner", _Owner.TNumber)
            T.Include_Parameter("@Task_Month", _Task_Month)
            T.Include_Parameter("@Value", _Value)
            T.Include_Parameter("@Entry_Type", _Entry_Type)
            T.Include_Parameter("@FTE", _FTE)
            T.Include_Parameter("@Event", _Event)

            TG.Include_Transaction(T)
            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction
            Dim T As New Transaction
            T.SQL_String = "Select ID as Code, [Description] as Value From [clm_Resource_Type]"
            Return T
        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [cp_Resources]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [Resource_ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group
            Dim T As New Objects.Transaction
            Dim TG As New Objects.Transaction_Group

            T.SQL_String = "Update cp_Resources Set Resource_Type = @Resource_Type, Owner = @Owner, Task_Month = @Task_Month, Value = @Value, Entry_Type = @Entry_Type,FTE = @FTE, Event = @Event Where Resource_ID = @Resource_ID"
            T.Include_Parameter("@Project", _Project)
            T.Include_Parameter("@Resource_Type", _Resource_Type.ID)
            T.Include_Parameter("@Owner", _Owner.TNumber)
            T.Include_Parameter("@Task_Month", _Task_Month)
            T.Include_Parameter("@Value", _Value)
            T.Include_Parameter("@Entry_Type", _Entry_Type)
            T.Include_Parameter("@FTE", _FTE)
            T.Include_Parameter("@Event", _Event)
            T.Include_Parameter("@Resource_ID", _Resource_ID)

            TG.Include_Transaction(T)
            Return TG
        End Function
        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            Dim _Loaded As Boolean = False
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _Resource_ID = Data(0)("Resource_ID")
                _Resource_Type.Load(Data(0)("Resource_Type"))
                _Owner.Load(Data(0)("Owner"))
                _Task_Month = Data(0)("Task_Month")
                _Value = Data(0)("Value")
                _Entry_Type = Data(0)("Entry_Type")
                _FTE = Data(0)("FTE")
                _Event = Data(0)("Event")
                _Project = Data(0)("Project")
                _Loaded = True
            End If
            Return _Loaded
        End Function


        Private Sub Check_FTE()
            If _Entry_Type.ToString.ToUpper <> "MATERIAL" Then
                _FTE = Objects.Functions.Collaboration_Module.Get_FTE(_Value, CM_Input_Type.Hours)
            Else
                _FTE = Objects.Functions.Collaboration_Module.Get_FTE(_Value, CM_Input_Type.Materials)
            End If
        End Sub
        Public Function Delete() As Boolean
            Return Execute(Get_Delete)
        End Function
#End Region

    End Class
    Public Class CP_Project_Files
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
                Table = DB.GetTable("Select * From cp_Files Where ID = " & File_ID)
            Else
                Table = DB.GetTable("Select ID, Project_ID, File_Name, Owner, Visibility, Upload_Date, Ext From cp_Files Where ID = " & File_ID)
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

                    T.SQL_String = "Insert Into cp_Files (Project_ID, File_Name, Owner, Visibility, Data, Upload_Date,Ext) Values(@Project_ID, @File_Name, @Owner, @Visibility, @Data, {fn Now()},@Ext)"
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

            DataFile = cn.GetTable("Select * From cp_Files Where ID = " & _File_ID)

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
                    If DB.Execute("Delete From cp_Files Where ID = " & _File_ID) Then
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

    Public Class CP_Actual
        Inherits Objects.Base

#Region "Variables"
        Private _ID As Integer
        Private _Record_Date As DateTime

        Private _Resource As Integer = 1

        Private _Created_By As String
        Private _Actual_Date As DateTime = Now.Date
        Private _Value As Double = 0
        Private _FTE As Double = 0

        Private _ProjectID As Integer = 0
        Private _Entry_Type As String = ""

        Private _Total_Value As Double = 0
        Private _Total_FTE As Double = 0
#End Region
#Region "Properties"

        Protected Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        Public Property Record_Date() As DateTime
            Get
                Return _Record_Date
            End Get
            Set(ByVal value As DateTime)
                _Record_Date = value
            End Set
        End Property
        Public Property Resource_Type() As Integer
            Get
                Return _Resource
            End Get
            Set(ByVal value As Integer)
                _Resource = value
            End Set
        End Property
        Protected Property Created_By() As String
            Get
                Return _Created_By

            End Get
            Set(ByVal value As String)
                _Created_By = value
            End Set
        End Property
        Public Property Actual_Date() As DateTime
            Get
                Return _Actual_Date
            End Get
            Set(ByVal value As DateTime)
                _Actual_Date = value
            End Set
        End Property
        Public Property Value() As Double
            Get
                Return _Value
            End Get
            Set(ByVal value As Double)
                _Value = value
                If _Entry_Type.ToString.ToUpper <> "MATERIAL" Then
                    _FTE = Objects.Functions.Collaboration_Module.Get_FTE(value, CM_Input_Type.Hours)
                Else
                    _FTE = Objects.Functions.Collaboration_Module.Get_FTE(value, CM_Input_Type.Materials)
                End If
            End Set
        End Property
        Public Property FTE() As Double
            Get
                Return Math.Round(_FTE, 2)
            End Get
            Set(ByVal value As Double)
                _FTE = value
            End Set
        End Property
        Public ReadOnly Property Total_Value() As Double
            Get
                Return _Total_Value
            End Get
        End Property
        Public ReadOnly Property Total_FTE() As Double
            Get
                Return Math.Round(_Total_FTE, 2)
            End Get
        End Property
        Public Property Project_ID() As Integer
            Get
                Return _ProjectID
            End Get
            Set(ByVal value As Integer)
                _ProjectID = value
            End Set
        End Property
        Public Property Entry_Type() As String
            Get
                Return _Entry_Type
            End Get
            Set(ByVal value As String)
                _Entry_Type = value
            End Set
        End Property

#End Region
#Region "Methods"
        Public Sub New()
            MyBase.New()
            _Created_By = Environ("USERID")
        End Sub
        Public Sub New(ByVal ID As Integer)
            Load(ID)
        End Sub
        Public Overrides Sub Clear()

        End Sub
        Public Overrides Function Get_Delete() As Transaction_Group

        End Function
        Public Overrides Function Get_Insert() As Transaction_Group
            Dim T As New Objects.Transaction
            Dim TG As New Objects.Transaction_Group

            T.SQL_String = "Insert Into cp_Actuals(Record_Date, Resource, Created_By, Actual_Date, Value, FTE, ProjectID, Entry_Type) Values({fn now()}, @Resource, @Created_By, @Actual_Date, @Value, @FTE, @ProjectID, @Entry_Type)"
            T.Include_Parameter("@Resource", _Resource)
            T.Include_Parameter("@Created_By", Environ("USERID"))
            T.Include_Parameter("@Actual_Date", _Actual_Date)
            T.Include_Parameter("@Value", _Value)
            T.Include_Parameter("@FTE", _FTE)
            T.Include_Parameter("@ProjectID", _ProjectID)
            T.Include_Parameter("@Entry_Type", _Entry_Type)

            TG.Include_Transaction(T)
            Return TG
        End Function
        Public Overrides Function Get_Search_List() As Transaction

        End Function
        Public Overrides Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
            Dim T As New Transaction

            T.SQL_String = "Select * From [vw_CP_Open_Tasks]"
            If Not Code_ID Is Nothing Then
                T.SQL_String = T.SQL_String & " Where [Resource_ID] = @ID"
                T.Include_Parameter("@ID", Code_ID)
            End If

            Return T
        End Function
        Public Overrides Function Get_Update() As Transaction_Group

        End Function

        Public Overrides Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
            MyBase.Load(Code_ID)
            If Not Data Is Nothing AndAlso Not Code_ID Is Nothing Then
                _Resource = Data(0)("Resource_Type")
                _ProjectID = Data(0)("Project")
                _Entry_Type = Data(0)("Entry_Type")
                _Total_Value = Data(0)("Total Value")
                _Total_FTE = Data(0)("Total FTE")

            End If
        End Function
#End Region
    End Class

    Namespace Variants
        Public Class cp_Variant
#Region "Variables"
            Private _Projects As New List(Of cp_Var)
            Private _Projects_type As New List(Of cp_Var)
            Private _Tasks As New List(Of cp_Var)
            Private _Owner As New List(Of cp_Var)
            Private _Resource As New List(Of cp_Var)
#End Region
#Region "Properties"
            Public ReadOnly Property Projects() As List(Of cp_Var)
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

            Public ReadOnly Property Project_Types() As List(Of cp_Var)
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

            Public ReadOnly Property Task() As List(Of cp_Var)
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

            Public ReadOnly Property Owner() As List(Of cp_Var)
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

            Public ReadOnly Property Resource() As List(Of cp_Var)
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
            Private Function Count_Selected(ByVal List As List(Of cp_Var)) As Integer
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
                                F = "(Project = " & i.ID & ")"
                            Else
                                F = F & " Or (Project = " & i.ID & ")"
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
                                F = "([Project Type] = " & i.ID & ")"
                            Else
                                F = F & " Or ([Project Type] = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If


                'If Count_Selected(_Tasks) Then
                '    Dim F As String = ""
                '    For Each i In _Tasks
                '        If i.Selected Then
                '            If F.Length = 0 Then
                '                F = "([Task ID] = " & i.ID & ")"
                '            Else
                '                F = F & " Or ([Task ID] = " & i.ID & ")"
                '            End If
                '        End If
                '    Next
                '    pFilter = pFilter & " And (" & F & ")"
                'End If


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
                                F = "([Resource] = " & i.ID & ")"
                            Else
                                F = F & " Or ([Resource] = " & i.ID & ")"
                            End If
                        End If
                    Next
                    pFilter = pFilter & " And (" & F & ")"
                End If

                Return pFilter
            End Function
#End Region
        End Class
        Public Class cp_Var
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






