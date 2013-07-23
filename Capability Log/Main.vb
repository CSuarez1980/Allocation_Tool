Imports System.Windows.Forms
Imports System.Xml

Public Class Main
#Region "Menu Options"
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        End
    End Sub
    Public Function Launch(ByVal pForm As String) As Boolean
        Dim MyObj As Type = Type.GetType("Capability_Log." & pForm)
        Dim W As Object = Activator.CreateInstance(MyObj)

        W.MdiParent = Me
        W.Show()
        Return True

    End Function
    Private Sub UsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsersToolStripMenuItem.Click
        Launch("frmUsers")
    End Sub
    Private Sub ProjectCategoriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectCategoriesToolStripMenuItem.Click
        Launch("frmProject_Category")
    End Sub
    Private Sub ValueStreamsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueStreamsToolStripMenuItem.Click
        Launch("frmValue_Stream")
    End Sub
    Private Sub ServiceLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServiceLineToolStripMenuItem.Click
        Launch("frmService_Line")
    End Sub
    Private Sub FormsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormsToolStripMenuItem1.Click
        Launch("Forms")
    End Sub
    Private Sub ProfilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfilesToolStripMenuItem.Click
        Launch("Profile")
    End Sub
    Private Sub ProjectStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectStatusToolStripMenuItem.Click
        Launch("frmStatus")
    End Sub
    Private Sub ProjectMaintenanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectMaintenanceToolStripMenuItem.Click
        Launch("frmProject")
    End Sub
    Private Sub TasksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasksToolStripMenuItem.Click
        Launch("frmTask")
    End Sub
    Private Sub TaskInputToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskInputToolStripMenuItem.Click
        Launch("frmTask_Entry")
    End Sub
    Private Sub TaskTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskTypeToolStripMenuItem.Click
        Launch("clm_Tasks_Type")
    End Sub
    Private Sub ResourceTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResourceTypeToolStripMenuItem.Click
        Launch("clm_Resource_Type")
    End Sub
    Private Sub ProjectsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectsToolStripMenuItem1.Click
        Launch("frmCollaborationModule")
    End Sub
    Private Sub MyTasksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyTasksToolStripMenuItem.Click
        Launch("frmCMEntry")
    End Sub
    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click
        Launch("clm_Report")
    End Sub
    Private Sub ProjectForecastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectForecastToolStripMenuItem.Click
        Launch("pss_Forecast")
    End Sub

#End Region

#Region "Form Methods"
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        goUser = New Objects.User
        goUser.Load(Environ("USERID"))
    End Sub
#End Region
End Class
