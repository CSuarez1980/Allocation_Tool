Public Class cp_Report

    Private _Variant As New Objects.Corporate_Projects.Variants.cp_Variant

    Private Sub clm_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CapabilityLogDataSet.vw_cp_Raw_Data' table. You can move, or remove it, as needed.
        AddHandler dtpStart.ValueChanged, AddressOf Refresh_Variant
        AddHandler dtpEnd.ValueChanged, AddressOf Refresh_Variant

        BS.DataSource = _Variant

        txtProjects.DataBindings.Add("Text", BS, "Project_Value", True, DataSourceUpdateMode.OnPropertyChanged)
        txtProjectType.DataBindings.Add("Text", BS, "Project_Type_Value", True, DataSourceUpdateMode.OnPropertyChanged)
        txtTask.DataBindings.Add("Text", BS, "Task_Value", True, DataSourceUpdateMode.OnPropertyChanged)
        txtContact.DataBindings.Add("Text", BS, "Owner_Value", True, DataSourceUpdateMode.OnPropertyChanged)
        txtResource.DataBindings.Add("Text", BS, "Resource_Value", True, DataSourceUpdateMode.OnPropertyChanged)

        Refresh_Report()
    End Sub

    Public Sub Refresh_Report()
        rtpReport.Focus()
        Dim DB As New Objects.Connection
        Dim cmd As New SqlClient.SqlCommand
        Dim AD As New System.Data.SqlClient.SqlDataAdapter
        Dim Str As String = ""

        Str = "Select * From vw_cp_Raw_Data Where ([Date] Between '" & Year(dtpStart.Value.ToString) & Format(Month(dtpStart.Value.ToString), "00") & "' and '" & Year(dtpEnd.Value.ToString) & Format(Month(dtpEnd.Value.ToString), "00") & "')" & _Variant.Get_Filter

        cmd.CommandText = Str
        cmd.CommandType = CommandType.Text
        cmd.Connection = DB.Get_DBConnection

        AD.SelectCommand = cmd
        Me.CapabilityLogDataSet.vw_CM_Raw_Data.Clear()
        AD.Fill(Me.CapabilityLogDataSet.vw_CM_Raw_Data)

        Me.rtpReport.RefreshReport()
    End Sub

    Public Sub R() Handles rtpReport.ReportRefresh
        Refresh_Report()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New clm_Search

        frm.Set_Object(_Variant.Projects)
        frm.ShowDialog()
        BS.ResetBindings(False)
    End Sub

    Public Sub Refresh_Variant()
        Dim Data As New DataTable
        Dim DB As New Objects.Connection
        Dim T As New Objects.Transaction

        T.Set_SQLString("Select * From vw_cp_Raw_Data Where [Date] between @Start and @End")
        T.Include_Parameter("@Start", Year(dtpStart.Value.ToString) & Format(Month(dtpStart.Value.ToString), "00"))
        T.Include_Parameter("@End", Year(dtpEnd.Value.ToString) & Format(Month(dtpEnd.Value.ToString), "00"))

        'T.Include_Parameter("@Start", dtpStart.Value)
        'T.Include_Parameter("@End", dtpEnd.Value)

        Data = DB.GetTable(T)

        If Data.Rows.Count > 0 Then
            _Variant.Projects.Clear()
            _Variant.Project_Types.Clear()
            _Variant.Task.Clear()
            _Variant.Owner.Clear()
            _Variant.Resource.Clear()

            'Select Project based on date range
            Dim Q = (From P In Data _
                     Group P By PI = P("Project"), PN = P("Name") Into Group _
                     Select New With { _
                                      .ID = PI, _
                                      .Name = PN})

            'Load variants:
            For Each I In Q
                _Variant.Projects.Add(New Objects.Corporate_Projects.Variants.cp_Var(I.ID, I.Name))
            Next

            'Select project types based on date range
            Dim PT = (From P In Data _
                    Group P By PI = P("Project Type"), PN = P("Project Type Description") Into Group _
                    Select New With { _
                                     .ID = PI, _
                                     .Name = PN})
            'Load variants:
            For Each I In PT
                _Variant.Project_Types.Add(New Objects.Corporate_Projects.Variants.cp_Var(I.ID, I.Name))
            Next

            ''Select tasks based on date range
            'Dim TT = (From P In Data _
            '        Group P By PI = P("Task ID"), PN = P("Task Name") Into Group _
            '        Select New With { _
            '                         .ID = PI, _
            '                         .Name = PN})
            ''Load variants:
            'For Each I In TT
            '    _Variant.Task.Add(New Objects.Collaboration_Module.Variants.clm_Var(I.ID, I.Name))
            'Next

            'Select contacts based on date range
            Dim CT = (From P In Data _
                   Group P By PI = P("Owner"), PN = P("Owner Name") Into Group _
                   Select New With { _
                                    .ID = PI, _
                                    .Name = PN})
            'Load variants:
            For Each I In CT
                _Variant.Owner.Add(New Objects.Corporate_Projects.Variants.cp_Var(I.ID, I.Name))
            Next

            'Select resources based on date range
            Dim RT = (From P In Data _
                  Group P By PI = P("Resource"), PN = P("Resource Description") Into Group _
                  Select New With { _
                                   .ID = PI, _
                                   .Name = PN})
            'Load variants:
            For Each I In RT
                _Variant.Resource.Add(New Objects.Corporate_Projects.Variants.cp_Var(I.ID, I.Name))
            Next
        Else
            'MsgBox("No data found.")
            Me.ShowMessage("No data could be selected", MsgType.Warning)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frm As New clm_Search

        frm.Set_Object(_Variant.Project_Types)
        frm.ShowDialog()
        BS.ResetBindings(False)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim frm As New clm_Search

        frm.Set_Object(_Variant.Task)
        frm.ShowDialog()
        BS.ResetBindings(False)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New clm_Search
        frm.Set_Object(_Variant.Owner)
        frm.ShowDialog()
        BS.ResetBindings(False)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim frm As New clm_Search
        frm.Set_Object(_Variant.Resource)
        frm.ShowDialog()
        BS.ResetBindings(False)
    End Sub

    Private Sub cmdExport2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport2Excel.Click
        Dim XL As New Objects.MSExcel
        XL.ExportToExcel(Me.CapabilityLogDataSet.vw_CM_Raw_Data)

    End Sub


    Private Sub FillByToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.vw_CM_Raw_DataTableAdapter.FillBy(Me.CapabilityLogDataSet.vw_CM_Raw_Data)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
