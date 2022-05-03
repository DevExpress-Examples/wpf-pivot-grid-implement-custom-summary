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
			DevExpress.Data.Filtering.CriteriaOperator.RegisterCustomFunction(New DistinctCountFunction())

			InitializeComponent()

			ds.Name = "Excel Data Source"
			ds.FileName = "SalesPerson.xlsx"
			Dim worksheetSettings As New ExcelWorksheetSettings("Data")
			ds.SourceOptions = New ExcelSourceOptions(worksheetSettings)
			ds.Fill()

			pivotGridControl1.DataSource = ds
		End Sub

		Private Sub PivotGridControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			pivotGridControl1.BestFit()
		End Sub
	End Class
End Namespace
