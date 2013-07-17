Public Enum SQL_Action
    [Nothing] = 0
    [Insert] = 1
    [Update] = 2
    [Delete] = 3
End Enum
Public Enum Get_Param_From
    [Default] = 0
    Server = 1
End Enum

Public Enum Object_Status
    None = 0
    Insert = 1
    Update = 2
    Delete = 3
End Enum
Public Enum CM_Input_Type
    Materials = 1
    Hours = 2
End Enum

Public MustInherit Class Base
    Inherits Connection
#Region "Variables"
    Private _Data As DataTable
    Private _Action As SQL_Action = Objects.SQL_Action.Nothing
    Private _Execute_Action As Boolean
    Private _Object_Status As Object_Status
#End Region
#Region "Properties"
    Protected Friend ReadOnly Property Data() As DataTable
        Get
            Return _Data
        End Get
    End Property
    Protected Friend Property SQL_Action() As Objects.SQL_Action
        Get
            Return _Action
        End Get
        Set(ByVal value As Objects.SQL_Action)
            _Action = value
        End Set
    End Property
    Protected Friend Property Execute_Action() As Boolean
        Get
            Return _Execute_Action
        End Get
        Set(ByVal value As Boolean)
            _Execute_Action = value
        End Set
    End Property
    Protected Friend Property Object_Status() As Object_Status
        Get
            Return _Object_Status
        End Get
        Set(ByVal value As Object_Status)
            _Object_Status = value
        End Set
    End Property

#End Region
#Region "Methods"
    Public MustOverride Function Get_Insert() As Transaction_Group
    Public MustOverride Function Get_Update() As Transaction_Group
    Public MustOverride Function Get_Delete() As Transaction_Group
    Public MustOverride Function Get_Search_List() As Transaction
    Public MustOverride Function Get_Select(Optional ByVal Code_ID As Object = Nothing) As Transaction
    Public MustOverride Sub Clear()

    Public Function Get_Actions() As Transaction_Group
        Select Case _Action
            Case SQL_Action.Insert
                Return Get_Insert()

            Case SQL_Action.Update
                Return Get_Update()

            Case SQL_Action.Delete
                Return Get_Delete()
        End Select

    End Function
    Public Function Save(Optional ByVal pAction As SQL_Action = SQL_Action.Nothing) As Boolean
        If _Execute_Action Then
            If pAction <> Objects.SQL_Action.Nothing Or _Action <> SQL_Action.Nothing Then
                Dim T As New List(Of Transaction_Group)

                If pAction = SQL_Action.Nothing Then
                    pAction = _Action
                End If

                Select Case pAction
                    Case SQL_Action.Insert
                        Return Execute(Get_Insert)

                    Case SQL_Action.Update
                        Return Execute(Get_Update)

                    Case SQL_Action.Delete
                        Return Execute(Get_Delete)
                End Select

                _Execute_Action = False
            End If
        End If
    End Function
    Public Overridable Function Load(Optional ByVal Code_ID As Object = Nothing) As Boolean
        Clear()
        _Data = GetTable(Get_Select(Code_ID))

        If Not Data Is Nothing AndAlso _Data.Rows.Count > 0 Then
            _Object_Status = Objects.Object_Status.Update
            Return True
        Else
            _Object_Status = Objects.Object_Status.None
            Return False
        End If
    End Function
    Public Function Search_List() As DataTable
        Return GetTable(Get_Search_List())
    End Function
    Public Function Encrypt(ByVal pString As String) As String
        Dim I As Integer
        Dim L As Integer
        Dim ES As String
        Dim Msk As String

        Msk = ")@*$&^!\[]{/:';<~`+=zo2916qw-"
        L = Len(pString)
        If L > 30 Then L = 30
        ES = ""
        For I = 1 To L
            ES = ES + Chr(Asc(Mid(Msk, I, 1)) Xor Asc(Mid(pString, I, 1)))
        Next

        Encrypt = ES
    End Function
    Public Sub Set_Action(ByVal Action As Objects.SQL_Action)
        _Action = Action
    End Sub
    Public Sub Allow_Action(ByVal Allow As Boolean)
        _Execute_Action = Allow
    End Sub
    Public Sub New()
        _Object_Status = Objects.Object_Status.Insert
    End Sub
#End Region
End Class

Public Class Transaction
#Region "Variables"
    Private _SQL_String As String = Nothing
    Private _Parameters As New List(Of A_Parameter)
#End Region
#Region "Properties"
    ''' <summary>
    ''' SQL String to be excecuted
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <code>ie: Insert Into Table(Field_A, Field_B) Values(@Value_A, @Value_B)</code>
    Protected Friend Property SQL_String() As String
        Get
            Return _SQL_String
        End Get
        Set(ByVal value As String)
            _SQL_String = value
        End Set
    End Property
    Public ReadOnly Property Parameters() As List(Of A_Parameter)
        Get
            Return _Parameters
        End Get
    End Property
#End Region
#Region "Methods"
    Public Sub Include_Parameter(ByVal pField As String, ByVal pValue As Object)
        Dim lParameter As New A_Parameter(pField, pValue)

        _Parameters.Add(lParameter)
    End Sub
    Public Sub Include_Parameter(ByVal pParameters As List(Of A_Parameter))
        For Each P As A_Parameter In pParameters
            _Parameters.Add(P)
        Next
    End Sub
    Public Sub Clear_Parameters()
        _Parameters.Clear()
    End Sub
    Public Sub Set_SQLString(ByVal SQLString As String)
        _SQL_String = SQLString
    End Sub
    Public Sub New()
        Clear_Parameters()
    End Sub
#End Region
End Class

Public Class Transaction_Group
#Region "Variables"
    Private _Transactions As New List(Of Transaction)
#End Region
#Region "Properties"
    Public ReadOnly Property Transactions() As List(Of Transaction)
        Get
            Return _Transactions
        End Get
    End Property
#End Region
#Region "Methods"
    Public Function Include_Transaction(ByVal pTransaction As Transaction) As Boolean
        _Transactions.Add(pTransaction)
        Return True
    End Function
    Public Function Include_Transaction(ByVal pTransaction As Transaction_Group) As Boolean
        Dim iTG As New Transaction_Group

        If Not pTransaction Is Nothing Then
            For Each iT As Transaction In pTransaction.Transactions
                _Transactions.Add(iT)
            Next
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub Clear_Transactions()
        _Transactions.Clear()
    End Sub
    Public Sub New()
        Clear_Transactions()
    End Sub
#End Region
End Class

Public Class Connection
    'Inherits Transaction
#Region "Variables"
    Private _Status As String
    Private _ConnectionDB As New SqlClient.SqlConnection
#End Region
#Region "Properties"
    ''' <summary>
    ''' Indica el resultado de la ultima operación
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    ''' <summary>
    ''' Induca el estado de la conexión
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend ReadOnly Property ConnectionStatus() As Boolean
        Get
            Return _ConnectionDB.State
        End Get
    End Property
    ''' <summary>
    ''' Returns database connection string
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend ReadOnly Property ConnectionString() As String
        Get

            Dim oServer As New Server
            Return oServer.GetConnectionString


        End Get
    End Property
    Protected Friend ReadOnly Property Connection() As SqlClient.SqlConnection
        Get
            Return _ConnectionDB
        End Get

    End Property
#End Region
#Region "Methods"
    Public Function Get_DBConnection() As SqlClient.SqlConnection
        OpenConnection()
        Return _ConnectionDB
    End Function
    ''' <summary>
    ''' Open database connection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function OpenConnection() As Boolean
        Try
            If _ConnectionDB Is Nothing Then
                _ConnectionDB = New SqlClient.SqlConnection
            End If

            If _ConnectionDB.State.Equals(ConnectionState.Closed) Then
                Dim DB As New Server
                _ConnectionDB = New SqlClient.SqlConnection(DB.GetConnectionString)
                _ConnectionDB.Open()
            End If

            Return True
        Catch ex As Exception
            _Status = ex.Message
            Throw New Exception(ex.Message)
            'Return False
        End Try
    End Function
    ''' <summary>
    ''' Close database connection
    ''' </summary>
    Protected Friend Function CloseConnection() As Boolean
        Try
            If _ConnectionDB.State.Equals(ConnectionState.Open) Then
                _ConnectionDB.Close()
            End If

            Return True
        Catch ex As Exception
            _Status = ex.Message
            Return False
        End Try

    End Function
    'Public Overridable Function Direct_Execute(ByVal pTransaction As Transaction) As Boolean
    '    Dim _Result As Boolean = False
    '    If Not pTransaction Is Nothing Then
    '        Dim _Com As SqlClient.SqlCommand

    '        Try
    '            If Me.OpenConnection() Then
    '                _Com = New SqlClient.SqlCommand(pTransaction.SQL_String, _ConnectionDB)

    '                For Each P As A_Parameter In pTransaction.Parameters
    '                    _Com.Parameters.AddWithValue(P.Field, P.Value)
    '                Next
    '                _Com.ExecuteNonQuery()

    '                RaiseEvent Exec_Result(True, "Execution success")
    '                _Result = True
    '            End If
    '        Catch ex As Exception
    '            Me.Status = ex.Message
    '            RaiseEvent Exec_Result(False, ex.Message)
    '        Finally
    '            Me.CloseConnection()
    '            _Com = Nothing
    '        End Try
    '    End If
    '    Return _Result
    'End Function
    Public Overridable Function Execute(ByVal pTransaction As Transaction) As Boolean
        Dim _Result As Boolean = False
        If Not pTransaction Is Nothing Then
            Dim _Tran As SqlClient.SqlTransaction = Nothing
            Dim _Com As SqlClient.SqlCommand

            Try
                If Me.OpenConnection() Then
                    _Tran = _ConnectionDB.BeginTransaction

                    _Com = New SqlClient.SqlCommand(pTransaction.SQL_String, _ConnectionDB)
                    _Com.Transaction = _Tran

                    For Each P As A_Parameter In pTransaction.Parameters
                        _Com.Parameters.AddWithValue(P.Parameter_Name, P.Value)
                    Next
                    _Com.ExecuteNonQuery()

                    _Tran.Commit()
                    RaiseEvent Exec_Result(True, "Execution success")
                    _Result = True
                End If
            Catch ex As Exception
                _Tran.Rollback()
                Me.Status = ex.Message
                RaiseEvent Exec_Result(False, ex.Message)
            Finally
                Me.CloseConnection()
                _Tran = Nothing
                _Com = Nothing
            End Try
        End If
        Return _Result
    End Function
    Public Overridable Function Execute(ByVal pTransaction As Transaction_Group) As Boolean
        Dim _Result As Boolean = False
        If Not pTransaction Is Nothing Then
            Dim _Tran As SqlClient.SqlTransaction = Nothing
            Dim _Com As SqlClient.SqlCommand

            Try
                If Me.OpenConnection() Then
                    _Tran = _ConnectionDB.BeginTransaction

                    For Each T As Transaction In pTransaction.Transactions
                        _Com = New SqlClient.SqlCommand(T.SQL_String, _ConnectionDB)
                        _Com.Transaction = _Tran

                        For Each P As A_Parameter In T.Parameters
                            _Com.Parameters.AddWithValue(P.Parameter_Name, P.Value)
                        Next
                        _Com.ExecuteNonQuery()
                    Next

                    _Tran.Commit()
                End If
                RaiseEvent Exec_Result(True, "Execution success")
                _Result = True

            Catch ex As Exception
                _Tran.Rollback()
                Me.Status = ex.Message
                RaiseEvent Exec_Result(False, ex.Message)

            Finally
                Me.CloseConnection()
                _Tran = Nothing
                _Com = Nothing
            End Try

        End If
        Return _Result
    End Function
    Public Function Execute(ByVal String_SQL As String) As Boolean
        Dim _Result As Boolean = False
        Dim _Tran As SqlClient.SqlTransaction = Nothing
        Dim _Com As SqlClient.SqlCommand

        If String_SQL.Length > 0 Then
            Try
                If OpenConnection() Then

                    _Tran = _ConnectionDB.BeginTransaction

                    _Com = New SqlClient.SqlCommand(String_SQL, _ConnectionDB)
                    _Com.Transaction = _Tran

                    _Com.ExecuteNonQuery()
                    _Tran.Commit()

                    _Result = True

                Else
                    _Result = False
                End If
            Catch ex As Exception
                _Result = False
            Finally
                Me.CloseConnection()
                _Tran = Nothing
                _Com = Nothing
            End Try
        End If
    End Function

    ''' <summary>
    ''' Retorna un DataTable a partir de una instrucción SQL
    ''' </summary>
    ''' <param name="pTransaction">Instrucción SQL</param>
    Public Overridable Function GetTable(ByVal pTransaction As Transaction) As System.Data.DataTable
        Dim DataTableTmp As New DataTable
        Dim _Adapter As New SqlClient.SqlDataAdapter
        Dim Pr As New SqlClient.SqlParameter

        Try
            DataTableTmp = New DataTable()

            If Me.OpenConnection() Then
                _Adapter = New SqlClient.SqlDataAdapter(pTransaction.SQL_String, _ConnectionDB)

                For Each P As A_Parameter In pTransaction.Parameters
                    Pr = New SqlClient.SqlParameter
                    Pr.ParameterName = P.Parameter_Name
                    Pr.Value = P.Value
                    _Adapter.SelectCommand.Parameters.Add(Pr)
                Next

                _Adapter.Fill(DataTableTmp)

            End If

            'If DataTableTmp.Rows.Count > 0 Then
            Return DataTableTmp
            'Else
            'Return Nothing
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            CloseConnection()
            DataTableTmp.Dispose()
            _Adapter.Dispose()
            _Adapter = Nothing
            _ConnectionDB = Nothing
        End Try

    End Function
    Public Overridable Function GetTable(ByVal SQLString As String) As System.Data.DataTable
        Dim DataTableTmp As New DataTable
        Dim _Adapter As New SqlClient.SqlDataAdapter
        Dim Pr As New SqlClient.SqlParameter

        Try
            DataTableTmp = New DataTable()

            If Me.OpenConnection() Then
                _Adapter = New SqlClient.SqlDataAdapter(SQLString, _ConnectionDB)

                'For Each P As A_Parameter In pTransaction.Parameters
                '    Pr = New SqlClient.SqlParameter
                '    Pr.ParameterName = P.Parameter_Name
                '    Pr.Value = P.Value
                '    _Adapter.SelectCommand.Parameters.Add(Pr)
                'Next

                _Adapter.Fill(DataTableTmp)

            End If

            'If DataTableTmp.Rows.Count > 0 Then
            Return DataTableTmp
            'Else
            'Return Nothing
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            CloseConnection()
            DataTableTmp.Dispose()
            _Adapter.Dispose()
            _Adapter = Nothing
            _ConnectionDB = Nothing
        End Try

    End Function
    Public Sub New()
        OpenConnection()
    End Sub
#End Region
#Region "Events"
    Public Event Exec_Result(ByVal pSuccess As Boolean, ByVal pMessage As String)
#End Region
End Class

Friend Class Server
#Region "Variables"
    Private _ServerName As String
    Private _ServerIP As String
    Private _LoginUser As String
    Private _LoginPassword As String
    Private _DataBase As String
#End Region
#Region "Properties"
    ''' <summary>
    ''' Server name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerName() As String
        Get
            Return _ServerName
        End Get
    End Property
    ''' <summary>
    ''' Server IP
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerIP() As String
        Get
            Return _ServerIP
        End Get
    End Property
    ''' <summary>
    ''' User name for login
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoginUser() As String
        Get
            Return _LoginUser
        End Get
    End Property
    ''' <summary>
    ''' User password for data base access
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoginPassword() As String
        Get
            Return _LoginPassword
        End Get
    End Property
    ''' <summary>
    ''' Database name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataBase() As String
        Get
            Return _DataBase
        End Get
    End Property
#End Region
#Region "Methods"
    Public Function GetConnectionString(Optional ByVal UseServerIP As Boolean = False) As String
        If UseServerIP Then
            Return "Data Source=" & _ServerIP & "; Initial Catalog=" & _DataBase & ";User ID=" & _LoginUser & "; Password=" & _LoginPassword & "; Connection Timeout=3000;"
        Else
            Return "Data Source=" & _ServerName & "; Initial Catalog=" & _DataBase & ";User ID=" & _LoginUser & "; Password=" & _LoginPassword & "; Connection Timeout=3000;"
        End If
    End Function
    Private Function GetDefaultConnectionString() As Boolean
        Try
            _ServerName = "131.190.71.208"
            _DataBase = "CapabilityLog"
            _LoginUser = "SA"
            _LoginPassword = "heavymetal"
            _ServerIP = "131.190.71.208"

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Sub New()
        GetDefaultConnectionString()
    End Sub
#End Region
End Class

Public Class A_Parameter
#Region "Variables"
    Private _Value As Object
    Private _Parameter_Name As String
    Private _Parameter_Type As System.Data.ParameterDirection = ParameterDirection.Input
    Private _Returned_Value As Object 'ParameterDirection must be "Output" in order to get returned value
#End Region
#Region "Properties"
    Public Property Value() As Object
        Get
            Return _Value
        End Get
        Set(ByVal value As Object)
            _Value = value
        End Set
    End Property
    Public Property Parameter_Name() As String
        Get
            Return _Parameter_Name
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Public Property Parameter_Type() As System.Data.ParameterDirection
        Get
            Return _Parameter_Type
        End Get
        Set(ByVal value As System.Data.ParameterDirection)
            _Parameter_Type = value
        End Set
    End Property
    Public Property Returned_Value() As Object
        Get
            Return _Returned_Value
        End Get
        Set(ByVal value As Object)
            _Returned_Value = value
        End Set
    End Property
#End Region
#Region "Methods"
    Public Sub New(ByVal Parameter_Name As String, ByVal pValue As Object, Optional ByVal Direction As System.Data.ParameterDirection = ParameterDirection.Input)
        _Parameter_Name = Parameter_Name
        _Value = pValue
        _Parameter_Type = Direction
    End Sub
#End Region
End Class

Public Class Stored_Procedure
    Inherits Objects.Connection
#Region "Variables"
    Private _Stored_Procedure_Name As String = Nothing
    Private _Parameters As New List(Of A_Parameter)
#End Region
#Region "Properties"
    Public Property Stored_Procedure_Name() As String
        Get
            Return _Stored_Procedure_Name
        End Get
        Set(ByVal value As String)
            _Stored_Procedure_Name = value
        End Set
    End Property
    Public Shadows ReadOnly Property Parameters() As List(Of A_Parameter)
        Get
            Return _Parameters
        End Get
    End Property
#End Region
#Region "Methods"
    Public Shadows Sub Include_Parameter(ByVal Parameter_Name As String, ByVal Value As Object, Optional ByVal Direction As System.Data.ParameterDirection = ParameterDirection.Input)
        Dim lParameter As New A_Parameter(Parameter_Name, Value, Direction)

        _Parameters.Add(lParameter)
    End Sub
    Public Shadows Sub Include_Parameter(ByVal pParameters As List(Of A_Parameter))
        For Each P As A_Parameter In pParameters
            _Parameters.Add(P)
        Next
    End Sub
    Public Shadows Sub Clear_Parameters()
        _Parameters.Clear()
    End Sub
    Public Sub New()
        Clear_Parameters()
    End Sub
    Public Function Get_Parameter_Value(ByVal Parameter_Name As String, Optional ByVal Get_Param As Get_Param_From = Get_Param_From.Default) As Object
        Dim Value As Object = Nothing

        For Each P As A_Parameter In _Parameters
            If P.Parameter_Name = Parameter_Name Then
                If Get_Param = Get_Param_From.Default Then
                    Value = P.Value
                Else
                    Value = P.Returned_Value
                End If
                Exit For
            End If
        Next

        Return Value
    End Function

    Public Shadows Function Execute() As Boolean
        'Dim DB As New Datos.Connection(True)

        Try
            If openConnection Then
                'If DB.ConnectionStatus = System.Data.ConnectionState.Open Then
                Dim cmd As New SqlClient.SqlCommand
                Dim reader As SqlClient.SqlDataReader
                Dim Pr As New SqlClient.SqlParameter

                cmd.CommandText = _Stored_Procedure_Name
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = Connection

                For Each P As A_Parameter In _Parameters
                    Pr = New SqlClient.SqlParameter
                    Pr.ParameterName = P.Parameter_Name
                    Pr.Value = P.Value
                    Pr.Direction = P.Parameter_Type
                    cmd.Parameters.Add(Pr)
                Next

                reader = cmd.ExecuteReader

                For Each P As A_Parameter In _Parameters
                    P.Returned_Value = cmd.Parameters(P.Parameter_Name).Value
                Next

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function
#End Region
End Class

Namespace Functions
    Namespace Collaboration_Module
        Public Module CM_Functions
            Public Function Get_FTE(ByVal Value As Double, ByVal InputType As CM_Input_Type) As Double
                Dim Returned_Value As Double = 0

                Select Case InputType
                    Case CM_Input_Type.Materials
                        Returned_Value = (Value * (0.033 / 60)) / 173.33
                    Case CM_Input_Type.Hours
                        Returned_Value = Value / 173.33
                End Select

                Return Returned_Value
            End Function
        End Module
    End Namespace
    Namespace Global_Functions
        Public Module Commun_Functions
            Public Function GetWorkingDays(ByVal StartDate As Date, ByVal EndDate As Date) As Integer
                Dim _Total As Integer
                Dim bd As Integer = 0
                While StartDate < EndDate
                    If StartDate.DayOfWeek <> DayOfWeek.Saturday AndAlso StartDate.DayOfWeek <> DayOfWeek.Sunday Then _Total += 1
                    StartDate = StartDate.AddDays(1)
                End While

                Return _Total
            End Function
        End Module


    End Namespace
End Namespace