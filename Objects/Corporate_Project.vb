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
#End Region
#Region "Methods"
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

        Public Function Delete_Resource(ByVal Task_ID As Integer) As Boolean
            For Each T As Objects.Corporate_Projects.CP_Resource In _Resource
                If T.ID = Task_ID Then
                    Return T.Delete()
                End If
            Next
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

#End Region
#Region "Methods"
        Public Sub New()

        End Sub

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
End Namespace



