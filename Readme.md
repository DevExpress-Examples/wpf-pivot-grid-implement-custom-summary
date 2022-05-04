<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2136)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# How to Create a Custom Summary to Display the Distinct Value Count

This example demonstrates how to count distinct values (the number of orders with equal product quantities) and display the result in the Pivot Grid.

![screenshot](./images/screenshot.png)

| Data Field | Expression |
| --- | --- |
| Count Distinct| ```DistinctCount([OrderID])``` |

Call the [CriteriaOperator.RegisterCustomFunction](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.CriteriaOperator.RegisterCustomFunction(DevExpress.Data.Filtering.ICustomFunctionOperator)) method to register a custom function in your project (see [Program.cs](./CS/Win_Pivot_CustomAggregates/Program.cs#L18)/[Program.vb](./VB/Win_Pivot_CustomAggregates/Program.vb#L18))

<!-- default file list -->
## Files to look at

- [MainWindow.xaml](./CS/DXPivotGrid_CustomSummary/MainWindow.xaml#L35) (VB: [MainWindow.xaml](./VB/DXPivotGrid_CustomSummary/MainWindow.xaml#L35))
- [MainWindow.xaml.cs](./CS/DXPivotGrid_CustomSummary/MainWindow.xaml.cs#L16) (VB: [MainWindow.xaml.vb](./VB/DXPivotGrid_CustomSummary/MainWindow.xaml.vb#L15))
- [DistinctCountFunction.cs](./CS/DXPivotGrid_CustomSummary/DistinctCountFunction.cs) (VB: [DistinctCountFunction.vb](./VB/DXPivotGrid_CustomSummary/DistinctCountFunction.cs))
<!-- default file list end -->
## Documentation

- [Custom Aggregate Functions](https://docs.devexpress.com/CoreLibraries/401333/devexpress-data-library/custom-aggregate-functions)
- [Custom Summaries](https://docs.devexpress.com/WPF/8052/controls-and-libraries/pivot-grid/data-shaping/aggregation/summaries/custom-summaries)
## More Examples 
- [Pivot Grid for WinForms - How to Create a Custom Summary Type to Display the Distinct Value Count](https://github.com/DevExpress-Examples/how-to-implement-the-distinct-count-summary-type-within-the-pivotgrid-e637)
- [Pivot Grid for WinForms - How to Aggregate Data by the Field's First Value](https://github.com/DevExpress-Examples/winforms-pivot-grid-custom-aggregates)
- [Pivot Grid for Web Forms - How to Aggregate Data by the Field's First Value](https://github.com/DevExpress-Examples/aspnet-pivot-grid-custom-aggregates)
