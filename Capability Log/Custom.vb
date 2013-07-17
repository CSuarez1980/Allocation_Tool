Imports System
Imports System.Windows.Forms
Public Enum CalendarFormat
    None = 0
    Short_Date = 1
    Month_Year = 2
End Enum


Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New(ByVal Format As CalendarFormat)
        MyBase.New(New CalendarCell(Format))
        HeaderText = "Month"
        Name = "dtpMonth"
    End Sub
    Public Sub New()
        MyBase.New(New CalendarCell())
        Name = "dtpMonth"
    End Sub
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell. 
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property
End Class
Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub
    Public Sub New(ByVal Format As CalendarFormat)
        ' Use the short date format.
        Select Case Format
            Case CalendarFormat.None
                Me.Style.Format = "d"
            Case CalendarFormat.Month_Year
                Me.Style.Format = "MMMM' 'yyyy"
        End Select
        Me.Value = Now.Date
    End Sub
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value. 
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)

        ' Use the default row value when Value property is null. 
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        Else
            ctl.Value = CType(Me.Value, DateTime)
        End If
    End Sub
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that CalendarCell uses. 
            Return GetType(CalendarEditingControl)
        End Get
    End Property
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains. 
            Return GetType(DateTime)
        End Get
    End Property
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value. 
            Return DateTime.Now
        End Get
    End Property
End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DatagridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub
    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get
        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is  
                ' null, empty, or not in the format of a date. 
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default 
                ' value so we're not left with a null value. 
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property
    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub
    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property
    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed. 
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done. 

    End Sub
    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property
    Public Property EditingControlDataGridView() As DatagridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DatagridView)
            dataGridViewControl = value
        End Set

    End Property
    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property
    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property
    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class

Public Class MonthColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Items.Add("Select_One")
        Items.Add("January")
        Items.Add("February")
        Items.Add("March")
        Items.Add("April")
        Items.Add("May")
        Items.Add("June")
        Items.Add("July")
        Items.Add("August")
        Items.Add("September")
        Items.Add("October")
        Items.Add("November")
        Items.Add("December")

        HeaderText = "Month"
        Name = "cboMonth"
    End Sub
End Class

Public Class EventsColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Items.Add("SIT")
        Items.Add("BAT")
        Items.Add("TCO")
        Items.Add("CO")

        HeaderText = "Event"
        Name = "cboEvent"
    End Sub
End Class
Public Class EntryTypeColumn
    Inherits DataGridViewComboBoxColumn

    Public Sub New()
        Items.Add("Material")
        Items.Add("Hours")

        HeaderText = "Entry Type"
        Name = "cboEntryType"
    End Sub
End Class








