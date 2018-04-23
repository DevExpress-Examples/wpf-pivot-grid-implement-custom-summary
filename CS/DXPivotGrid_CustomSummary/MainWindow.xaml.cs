using System.Windows;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_CustomSummary {
    public partial class MainWindow : Window {
        DataSet1TableAdapters.OrderReportsTableAdapter adapter = 
            new DataSet1TableAdapters.OrderReportsTableAdapter();
        int minSum = 500;
        public MainWindow() {
            InitializeComponent();
            pivotGridControl1.DataSource = adapter.GetData();
        }
        private void pivotGridControl1_CustomSummary(object sender, PivotCustomSummaryEventArgs e) {
            if (e.DataField != fieldExtendedPrice) return;

            // A variable which counts the number of orders whose sum exceeds $500.
            int order500Count = 0;

            // Get the record set corresponding to the current cell.
            PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();

            // Iterate through the records and count the orders.
            for (int i = 0; i < ds.RowCount; i++) {
                PivotDrillDownDataRow row = ds[i];

                // Get the order's total sum.
                decimal orderSum = (decimal)row[fieldExtendedPrice];
                if (orderSum >= minSum) order500Count++;
            }

            // Calculate the percentage.
            if (ds.RowCount > 0) {
                e.CustomValue = (decimal)order500Count / ds.RowCount;
            }
        }
    }
}
