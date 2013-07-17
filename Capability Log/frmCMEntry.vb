Imports Objects.Functions
Public Class frmCMEntry
    Private WithEvents _Resources As New Objects.Collaboration_Module.CM_Entry(goUser.TNumber, Now.Date)

    Private Sub frmCMEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Resources.Saved_By = goUser.TNumber
        dtpMonth.DataBindings.Add("Value", _Resources, "Entry_Date", True, DataSourceUpdateMode.OnPropertyChanged)
        BS.DataSource = _Resources.Resources
        dtgResources.DataSource = BS
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        _Resources.Allow_Action(True)
        If _Resources.Save(Objects.SQL_Action.Insert) Then
            Me.ShowMessage("Record saved.", MsgType.Information)
        Else
            Me.ShowMessage("Unable to save record.", MsgType.Error)
        End If
    End Sub

    Public Sub Refresh_Binding() Handles _Resources.Refreshed
        BS.ResetBindings(False)
    End Sub
End Class
