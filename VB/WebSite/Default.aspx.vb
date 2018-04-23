Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub ASPxGridView1_HeaderFilterFillItems(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewHeaderFilterEventArgs)
		If e.Column.FieldName = "CategoryName" Then
			Dim orderedList = e.Values.OrderByDescending(Function(x) x.DisplayText, New MyComparer()).ToList()
			e.Values.Clear()
			e.Values.AddRange(orderedList)
		End If
	End Sub
	Public Class MyComparer
		Implements IComparer(Of String)
		Public Sub New()

		End Sub
		Public Function Compare(ByVal x As String, ByVal y As String) As Integer Implements IComparer(Of String).Compare
			If x = y Then
                Return 0
            End If
            If x.StartsWith("(") AndAlso y.StartsWith("(") Then
                Return -String.Compare(x.Substring(1), y.Substring(1))
            End If
            If x = "(All)" OrElse x = "(Blanks)" OrElse x = "(Non blanks)" Then
                Return 1
            End If
            If y = "(All)" OrElse y = "(Blanks)" OrElse y = "(Non blanks)" Then
                Return -1
            End If            
			Return String.Compare(x, y)
		End Function
	End Class
End Class