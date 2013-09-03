Public Class frmTask_Entry_Values

#Region "Variables"
    Private _Tasks As New List(Of Objects.Task)
    Private _Entry_List As New List(Of Objects.Task_Entry)
#End Region

#Region "Properties"
    Public Property Tasks() As List(Of Objects.Task)
        Get
            Return _Tasks
        End Get
        Set(ByVal value As List(Of Objects.Task))
            _Tasks = value
        End Set
    End Property
#End Region

#Region "Methods"
    Private Sub frmTask_Entry_Values_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Tasks_Entries(Now.Date())
        BS.DataSource = _Entry_List
        dtgEntry.DataSource = BS
        'dtgEntry.Columns("ConnectionStatus").Visible = False
        'dtgEntry.Columns("ConnectionString").Visible = False
        'dtgEntry.Columns("Data").Visible = False
        'dtgEntry.Columns("Entry_Date").Visible = False
        'dtgEntry.Columns("Entry_ID").Visible = False
        'dtgEntry.Columns("Entry_Type").Visible = False
        'dtgEntry.Columns("Execute_Action").Visible = False
        'dtgEntry.Columns("SQL_Action").Visible = False
        'dtgEntry.Columns("SQL_String").Visible = False
        'dtgEntry.Columns("Status").Visible = False
    End Sub
    Private Sub Load_Tasks_Entries(ByVal TDate As Date)
        _Entry_List.Clear()

        For Each T In _Tasks
            _Entry_List.Add(New Objects.Task_Entry(T.ID, TDate, Objects.Entry_type.Manual))
        Next
        BS.ResetBindings(False)
    End Sub
    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        Load_Tasks_Entries(dtpDate.Value)
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim Saved As Boolean = True
        For Each ET As Objects.Task_Entry In _Entry_List
            ET.Allow_Action(True)
            ET.Created_By = Environ("USERID")

            If Not ET.Save() Then
                Saved = False
            End If
        Next

        If Saved Then
            ShowMessage("Records saved.", MsgType.Information)
        Else
            ShowMessage("Records couldn't be saved.", MsgType.Error)
        End If
    End Sub
    Private Sub dtgEntry_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgEntry.DataError
        MsgBox("Please enter a valid value.", MsgBoxStyle.Exclamation)
    End Sub
#End Region

End Class


