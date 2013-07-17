Public Class frmBase
    ''' <summary>
    ''' Establece el texto en la barra de estado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message() As String
        Get
            Return txtMessage.Text
        End Get
        Set(ByVal value As String)
            txtMessage.Text = value
        End Set
    End Property
    Public Property ShowProgressBar() As Boolean
        Get
            Return pgStatus.Visible
        End Get
        Set(ByVal value As Boolean)
            pgStatus.Visible = value
        End Set
    End Property
    Public Property ProgressBarValue() As Integer
        Get
            Return pgStatus.Value
        End Get
        Set(ByVal value As Integer)
            pgStatus.Value = value
        End Set
    End Property
    Public Property ProgressBarMaxValue() As Integer
        Get
            Return pgStatus.Maximum
        End Get
        Set(ByVal value As Integer)
            pgStatus.Maximum = value
        End Set
    End Property
    Public Property ProgressBarStyle() As System.Windows.Forms.ProgressBarStyle
        Get
            Return pgStatus.Style
        End Get
        Set(ByVal value As System.Windows.Forms.ProgressBarStyle)
            pgStatus.Style = value
        End Set
    End Property
    Private Sub Base_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtMessage.Text = ""
        Me.lblFormName.Text = Me.Name
    End Sub
    Private Sub tmrTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTime.Tick
        txtMessage.Text = ""
        ImgError.Visible = False
        ImgInfo.Visible = False
        ImgWarning.Visible = False
        tmrTime.Enabled = False
    End Sub
    Public Overridable Sub ShowMessage(ByVal Message As String, Optional ByVal MsgType As MsgType = MsgType.Information)
        Select Case MsgType
            Case MsgType.Error
                ImgError.Visible = True
            Case MsgType.Information
                ImgInfo.Visible = True
            Case MsgType.Warning
                ImgWarning.Visible = True
        End Select

        txtMessage.Text = Message
        tmrTime.Enabled = True
    End Sub

   

End Class