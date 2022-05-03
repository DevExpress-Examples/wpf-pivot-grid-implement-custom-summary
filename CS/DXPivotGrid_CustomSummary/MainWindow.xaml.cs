using DevExpress.DataAccess.Excel;
using System;
using System.Collections;
using System.Windows;

namespace DXPivotGrid_CustomSummary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.ThemedWindow
    {
        ExcelDataSource ds = new ExcelDataSource();
        public MainWindow()
        {
            DevExpress.Data.Filtering.CriteriaOperator.RegisterCustomFunction(new DistinctCountFunction());
            InitializeComponent();

            ds.Name = "Excel Data Source";
            ds.FileName = "SalesPerson.xlsx";
            ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Data");
            ds.SourceOptions = new ExcelSourceOptions(worksheetSettings);
            ds.Fill();

            pivotGridControl1.DataSource = ds;
        }

        private void PivotGridControl1_Loaded(object sender, RoutedEventArgs e)
        {
            pivotGridControl1.BestFit();
        }
    }
}
