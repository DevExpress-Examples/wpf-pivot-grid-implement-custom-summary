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
            InitializeComponent();

            ds.Name = "Excel Data Source";
            ds.FileName = "SalesPerson.xlsx";
            ExcelWorksheetSettings worksheetSettings = new ExcelWorksheetSettings("Data");
            ds.SourceOptions = new ExcelSourceOptions(worksheetSettings);
            ds.Fill();

            pivotGridControl1.DataSource = ds;
        }

        private void pivotGridControl1_CustomSummary(object sender, DevExpress.Xpf.PivotGrid.PivotCustomSummaryEventArgs e)
        {
            string name = e.DataField.FieldName;

            IList list = e.CreateDrillDownDataSource();
            Hashtable ht = new Hashtable();
            for (int i = 0; i < list.Count; i++)
            {
                DevExpress.XtraPivotGrid.PivotDrillDownDataRow row = list[i] as DevExpress.XtraPivotGrid.PivotDrillDownDataRow;
                object v = row[name];
                if (v != null && v != DBNull.Value)
                    ht[v] = null;
            }
            e.CustomValue = ht.Count;
        }

        private void PivotGridControl1_Loaded(object sender, RoutedEventArgs e)
        {
            pivotGridControl1.BestFit();
        }
    }
}
