Imports System.Windows.Forms
Imports System.Xml

Public Class Main
#Region "Menu Options"
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        End
    End Sub
    Public Function Launch(ByVal pForm As String) As Boolean
        Dim Found As Boolean = False
        If Debugger.IsAttached Then
            Found = True
        End If

        For Each Profile As Objects.Profile In goUser.Profiles
            For Each Form As Objects.Forms In Profile.Forms
                If Form.ID = pForm Then
                    Found = True
                End If

                If Found Then
                    Exit For
                End If
            Next

            If Found Then
                Exit For
            End If
        Next

        If Found Then
            Dim MyObj As Type = Type.GetType("Capability_Log." & pForm)
            Dim W As Object = Activator.CreateInstance(MyObj)

            'grp.SendToBack()
            ' W.MdiParent = Me
            W.Show()
            Return True
        Else
            MsgBox("You don't have access to this module." & Chr(13) & Chr(13) & "Access code: " & pForm, MsgBoxStyle.Exclamation)
            Return False
        End If

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
    Private Sub ProjectsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Launch("clm_Forecast")
    End Sub
    Private Sub MyTasksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Launch("clm_Actual_Entry")
    End Sub
    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Launch("clm_Report")
    End Sub
    Private Sub ProjectForecastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectForecastToolStripMenuItem.Click
        Launch("pss_Forecast")
    End Sub
    Private Sub ActualInputToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualInputToolStripMenuItem.Click
        Launch("pss_Actual_Entry")
    End Sub
    Private Sub ReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem1.Click
        Launch("pss_Report")
    End Sub
    Private Sub ProjectForecast2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectForecast2ToolStripMenuItem.Click
        Launch("cp_Forecast")
    End Sub
    Private Sub ActualsInput2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualsInput2ToolStripMenuItem.Click
        Launch("cp_Actuals")
    End Sub
    Private Sub Report2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Report2ToolStripMenuItem.Click
        Launch("cp_Report")
    End Sub
#End Region
#Region "Form Methods"
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim D As New DataTable
        'Dim xl As New Objects.MSExcel

        'D = xl.Read_XLSX("C:\PDFs\AT.xlsx", "Datas", True)

        If Not goUser.Has_Access Then
            MsgBox("You do not have access to this tool. Please request access to the aplication owner.")
            End
        End If

        Load_Projects()
    End Sub
    Private Sub Load_Projects()
        Dim P As New DataTable
        Dim cn As New Objects.Connection
        Dim CPNode As New TreeNode
        Dim PSSNode As New TreeNode
        Dim Images As New ImageList

        Images.Images.Add(My.Resources.agt_action_success)
        Images.Images.Add(My.Resources.loopnone)
        Images.Images.Add(My.Resources.messagebox_info)
        Images.Images.Add(My.Resources.agt_softwareD) 'Corporate Projects = 3
        Images.Images.Add(My.Resources.agt_login) 'PSS Project = 4
        Images.Images.Add(My.Resources.agt_add_to_autorun) 'Continous improvement =5

        trvProjects.ImageList = Images

        'Corporate Projects:
        P = cn.GetTable("Select distinct [Project Name] From vw_CM_Open_Task Where Owner = '" & goUser.TNumber & "'")
        If P.Rows.Count > 0 Then
            Dim CINode As New TreeNode

            CPNode.Text = "Corporate Projects         "
            CPNode.NodeFont = New Font(trvProjects.Font, FontStyle.Bold)
            CPNode.ForeColor = Color.Indigo
            CPNode.ImageIndex = 3
            CPNode.SelectedImageIndex = 3

            For Each r As DataRow In P.Rows
                Dim ParentNode As New TreeNode(r("Project Name"))
                ParentNode.ForeColor = Color.Indigo
                CPNode.Nodes.Add(ParentNode)
                Dim T As New DataTable
                T = cn.GetTable("Select distinct [Task Type] From vw_CM_Open_Task Where [Project Name] = '" & r("Project Name") & "' And Owner = '" & goUser.TNumber & "'")
                If T.Rows.Count > 0 Then
                    For Each sn As DataRow In T.Rows
                        Dim childnode = New TreeNode(sn("Task Type"))
                        childnode.ForeColor = Color.Indigo
                        ParentNode.Nodes.Add(childnode)
                    Next
                End If
            Next
            trvProjects.Nodes.Add(CPNode)
        End If


        'PSS Projects:
        P = cn.GetTable("Select distinct [Project Name] From vw_PSS_Open_Task Where Owner = '" & goUser.TNumber & "'")
        If P.Rows.Count > 0 Then
            Dim CINode As New TreeNode

            PSSNode.Text = "PSS Projects          "
            PSSNode.NodeFont = New Font(trvProjects.Font, FontStyle.Bold)
            PSSNode.ForeColor = Color.Chocolate
            PSSNode.ImageIndex = 4
            PSSNode.SelectedImageIndex = 4

            For Each r As DataRow In P.Rows
                Dim ParentNode As New TreeNode(r("Project Name"))
                ParentNode.ForeColor = Color.Chocolate
                PSSNode.Nodes.Add(ParentNode)
                Dim T As New DataTable
                T = cn.GetTable("Select distinct [Task Type] From vw_PSS_Open_Task Where [Project Name] = '" & r("Project Name") & "' And Owner = '" & goUser.TNumber & "'")
                If T.Rows.Count > 0 Then
                    For Each sn As DataRow In T.Rows
                        Dim childnode = New TreeNode(sn("Task Type"))
                        childnode.ForeColor = Color.Chocolate
                        ParentNode.Nodes.Add(childnode)
                    Next
                End If
            Next
            trvProjects.Nodes.Add(PSSNode)
        End If

        'Continous improvement projects:
        P = cn.GetTable("Select distinct [Project Name] From vw_CI_Open_Task Where Owner = '" & goUser.TNumber & "'")
        If P.Rows.Count > 0 Then

            Dim CINode As New TreeNode

            CINode.Text = "Continous Improvement Projects              "
            CINode.NodeFont = New Font(trvProjects.Font, FontStyle.Bold)
            CINode.ForeColor = Color.SeaGreen
            CINode.ImageIndex = 5
            CINode.SelectedImageIndex = 5

            For Each r As DataRow In P.Rows
                Dim ParentNode As New TreeNode(r("Project Name"))
                ParentNode.ForeColor = Color.SeaGreen
                CINode.Nodes.Add(ParentNode)
                Dim T As New DataTable
                T = cn.GetTable("Select distinct [Task Name] From vw_CI_Open_Task Where [Project Name] = '" & r("Project Name") & "' And Owner = '" & goUser.TNumber & "'")
                If T.Rows.Count > 0 Then
                    For Each sn As DataRow In T.Rows
                        Dim childnode = New TreeNode(sn("Task Name"))
                        childnode.ForeColor = Color.SeaGreen
                        ParentNode.Nodes.Add(childnode)
                    Next
                End If
            Next
            trvProjects.Nodes.Add(CINode)
            trvProjects.ExpandAll()
        End If
    End Sub
#End Region



End Class
