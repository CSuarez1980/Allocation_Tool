Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Text
Imports iXL = Microsoft.Office.Interop.Excel

Public Class MSExcel

    Public Function ExportToExcel(ByVal pTable As System.Data.DataTable) As Boolean
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim oQueryTable As Excel.QueryTable
        Dim rs As ADODB.Recordset

        Try
            xlApp = CreateObject("Excel.Application")

            xlApp.UserControl = True
            xlBook = xlApp.Workbooks.Add
            xlSheet = xlBook.Worksheets(1)

            rs = ConvertToRecordset(pTable)

            oQueryTable = xlSheet.QueryTables.Add(rs, xlSheet.Cells(1, 1))
            oQueryTable.Refresh()

            xlApp.Visible = True
            rs = Nothing

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ExportToExcel(ByVal pTable As System.Data.DataTable, ByVal pFilePath As String) As Boolean
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim oQueryTable As Excel.QueryTable
        Dim rs As ADODB.Recordset


        Try
            If Len(Dir(pFilePath)) > 0 Then
                Kill(pFilePath)
            End If

            xlApp = CreateObject("Excel.Application")

            xlApp.UserControl = True
            xlBook = xlApp.Workbooks.Add
            xlSheet = xlBook.Worksheets(1)

            rs = ConvertToRecordset(pTable)

            oQueryTable = xlSheet.QueryTables.Add(rs, xlSheet.Cells(1, 1))
            oQueryTable.Refresh()

            xlApp.ActiveWorkbook.SaveAs(pFilePath)

            xlApp.ActiveWorkbook.Close()
            xlApp.Quit()

            Return True
        Catch ex As Exception
            Return False
        Finally
            rs = Nothing
        End Try
    End Function

    Public Shared Sub DataTableToRange(ByVal anchorCell As Excel.Range, _
    ByVal tableToCopy As System.Data.DataTable, _
    Optional ByVal tableHeader As String = "")

        If tableHeader <> "" Then
            Try
                anchorCell.Value = tableHeader
                anchorCell = anchorCell.Offset(1, 0)
            Catch ex As Exception
            End Try
        End If

        Dim tableHeaderOffset As Integer = 0

        For Each loopHeaders As DataColumn In tableToCopy.Columns
            Try
                anchorCell.Offset(0, tableHeaderOffset).Value = loopHeaders.ColumnName
            Catch ex As Exception
            End Try

            tableHeaderOffset += 1

        Next

        anchorCell.Offset(1, 0).CopyFromRecordset(ConvertToRecordset(tableToCopy))

    End Sub

    Public Shared Function ConvertToRecordset(ByVal inTable As System.Data.DataTable) As ADODB.Recordset
        Dim result As ADODB.Recordset = New ADODB.Recordset()
        Dim Value As String = ""

        result.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        Dim resultFields As ADODB.Fields = result.Fields
        Dim inColumns As System.Data.DataColumnCollection = inTable.Columns
        Try

            For Each inColumn As DataColumn In inColumns
                resultFields.Append(inColumn.ColumnName, _
                    TranslateType(inColumn.DataType), _
                    inColumn.MaxLength, _
                    ADODB.FieldAttributeEnum.adFldIsNullable, _
                    Nothing)
            Next

            result.Open(System.Reflection.Missing.Value _
                    , System.Reflection.Missing.Value _
                    , ADODB.CursorTypeEnum.adOpenStatic _
                    , ADODB.LockTypeEnum.adLockOptimistic)

            For Each dr As DataRow In inTable.Rows
                result.AddNew(System.Reflection.Missing.Value, _
                          System.Reflection.Missing.Value)

                For columnIndex As Integer = 0 To inColumns.Count - 1
                    If Not DBNull.Value.Equals(dr(columnIndex)) Then
                        If dr(columnIndex).ToString <> "" Then

                            Value = dr(columnIndex).ToString
                            'Estos son caracteres que no pueden ser exportados a excel,
                            'el proceso se cae cuando los encuentra.

                            If Value.IndexOf("�") >= 0 Then
                                Value = Replace(Value, "�", "")
                            End If
                            If Value.IndexOf("″") >= 0 Then
                                Value = Replace(Value, "″", Chr(34))
                            End If
                            If Value.IndexOf("⅝") >= 0 Then
                                Value = Replace(Value, "⅝", "5/8")
                            End If
                            If Value.IndexOf("⅜") >= 0 Then
                                Value = Replace(Value, "⅜", "3/8")
                            End If
                            If Value.IndexOf("") >= 0 Then
                                Value = Replace(Value, "", "3/8")
                            End If
                            If Value.IndexOf("ǿ") >= 0 Then
                                Value = Replace(Value, "ǿ", "ó")
                            End If
                            resultFields(columnIndex).Value = Value
                        Else
                            resultFields(columnIndex).Value = ""
                        End If
                    Else
                        resultFields(columnIndex).Value = dr(columnIndex)
                    End If
                Next
            Next
            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Shared Function TranslateType(ByVal columnType As Type) As ADODB.DataTypeEnum
        Select Case columnType.UnderlyingSystemType.ToString()

            Case "System.Boolean"
                Return ADODB.DataTypeEnum.adBoolean

            Case "System.Byte"
                Return ADODB.DataTypeEnum.adUnsignedTinyInt

            Case "System.Char"
                Return ADODB.DataTypeEnum.adChar

            Case "System.DateTime"
                Return ADODB.DataTypeEnum.adDate

            Case "System.Decimal"
                Return ADODB.DataTypeEnum.adCurrency

            Case "System.Double"
                Return ADODB.DataTypeEnum.adDouble

            Case "System.Int16"
                Return ADODB.DataTypeEnum.adSmallInt

            Case "System.Int32"
                Return ADODB.DataTypeEnum.adInteger

            Case "System.Int64"
                Return ADODB.DataTypeEnum.adBigInt

            Case "System.SByte"
                Return ADODB.DataTypeEnum.adTinyInt

            Case "System.Single"
                Return ADODB.DataTypeEnum.adSingle

            Case "System.UInt16"
                Return ADODB.DataTypeEnum.adUnsignedSmallInt

            Case "System.UInt32"
                Return ADODB.DataTypeEnum.adUnsignedInt

            Case "System.UInt64"
                Return ADODB.DataTypeEnum.adUnsignedBigInt

        End Select

        'Note Strings are not cased and will return here:
        Return ADODB.DataTypeEnum.adVarChar

    End Function

End Class

