Public Class ci_New_Actual_Line

    Private _User_Cancel As Boolean = True
    Private _Object As Object
    Private _LoadTask As Boolean = False

    Public Property User_Cancel() As Boolean
        Get
            Return _User_Cancel
        End Get
        Set(ByVal value As Boolean)
            _User_Cancel = value
        End Set
    End Property
    Public Property [Object]() As Object
        Get
            Return _Object
        End Get
        Set(ByVal value As Object)
            _Object = value
            BS.DataSource = _Object
        End Set
    End Property

    Private Sub ci_New_Actual_Line_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cn As New Objects.Connection

        With cboProject
            _LoadTask = False
            .DataSource = cn.GetTable("Select Distinct [Project ID], [Project Name] From vw_CI_Task Where Owner = '" & Environ("USERID") & "'")
            .DisplayMember = "Project Name"
            .ValueMember = "Project ID"

            .DataBindings.Add("SelectedValue", BS, "Project_ID", True, DataSourceUpdateMode.OnPropertyChanged)
            '.DataBindings.Add("Text", BS, "Project_Name", True, DataSourceUpdateMode.OnPropertyChanged)
            .SelectedIndex = 1
        End With

        _LoadTask = True

        With cboTask
            .DataSource = cn.GetTable("Select Distinct [Task ID], [Task Name] From vw_CI_Task Where ([Project ID] = " & BS.Item(0).Project_ID.ToString & ") And (Owner = '" & Environ("USERID") & "')")
            .DisplayMember = "Task Name"
            .ValueMember = "Task ID"

            .DataBindings.Add("SelectedValue", BS, "Task_ID", True, DataSourceUpdateMode.OnPropertyChanged)
            ' .DataBindings.Add("Text", BS, "Task_Name", True, DataSourceUpdateMode.OnPropertyChanged)
        End With
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        _User_Cancel = False
        _Object.Project_Name = cboProject.Text
        _Object.Task_Name = cboTask.Text
        Me.Close()
    End Sub

    Private Sub cboProject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProject.SelectedIndexChanged
        If _LoadTask Then
            Dim cn As New Objects.Connection

            With cboTask
                .DataSource = cn.GetTable("Select Distinct [Task ID], [Task Name] From vw_CI_Task Where ([Project ID] = " & BS.Item(0).Project_ID.ToString & ") And (Owner = '" & Environ("USERID") & "')")
                .DisplayMember = "Task Name"
                .ValueMember = "Task ID"

                ' .DataBindings.Add("SelectedValue", BS, "Task_ID", True, DataSourceUpdateMode.OnPropertyChanged)
                ' .DataBindings.Add("SelectedText", BS, "Task_Name", True, DataSourceUpdateMode.OnPropertyChanged)
            End With
        End If

    End Sub
End Class
