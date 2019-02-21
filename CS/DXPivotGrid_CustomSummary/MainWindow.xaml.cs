using System;
using System.Collections;
using System.Windows;

namespace DXPivotGrid_CustomSummary {
    public partial class MainWindow : Window {
        DataSet1TableAdapters.SalesPersonTableAdapter adapter = 
            new DataSet1TableAdapters.SalesPersonTableAdapter();
        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = adapter.GetData();
        }
        private void pivotGridControl1_CustomSummary(object sender, DevExpress.Xpf.PivotGrid.PivotCustomSummaryEventArgs e) {
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
