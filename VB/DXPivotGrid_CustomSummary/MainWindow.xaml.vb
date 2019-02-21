Imports DevExpress.DataAccess.Excel
Imports System
Imports System.Collections
Imports System.Windows

Namespace DXPivotGrid_CustomSummary
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DevExpress.Xpf.Core.ThemedWindow

		Private ds As New ExcelDataSource()
		Public Sub New()
			InitializeComponent()

			ds.Name = "Excel Data Source"
			ds.FileName = "SalesPerson.xlsx"
			Dim worksheetSettings As New ExcelWorksheetSettings("Data")
			ds.SourceOptions = New ExcelSourceOptions(worksheetSettings)
			ds.Fill()

			pivotGridControl1.DataSource = ds
		End Sub

		Private Sub pivotGridControl1_CustomSummary(ByVal sender As Object, ByVal e As DevExpress.Xpf.PivotGrid.PivotCustomSummaryEventArgs)
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim name_Renamed As String = e.DataField.FieldName

			Dim list As IList = e.CreateDrillDownDataSource()
			Dim ht As New Hashtable()
			For i As Integer = 0 To list.Count - 1
				Dim row As DevExpress.XtraPivotGrid.PivotDrillDownDataRow = TryCast(list(i), DevExpress.XtraPivotGrid.PivotDrillDownDataRow)
				Dim v As Object = row(name_Renamed)
				If v IsNot Nothing AndAlso v IsNot DBNull.Value Then
					ht(v) = Nothing
				End If
			Next i
			e.CustomValue = ht.Count
		End Sub

		Private Sub PivotGridControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			pivotGridControl1.BestFit()
		End Sub
	End Class
End Namespace
