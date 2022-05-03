Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.PivotGrid.ServerMode.Queryable
Imports System.Linq.Expressions
Imports DevExpress.Data.Linq
Imports DevExpress.DataProcessing.Criteria

Namespace DXPivotGrid_CustomSummary
	Friend Class DistinctCountFunction
		Implements ICustomAggregateFunction, ICustomFunctionOperatorBrowsable

		Public ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
			Get
				Return "DistinctCount"
			End Get
		End Property
		Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description
			Get
				Return "Displays the number of unique values of the field"
			End Get
		End Property

		Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
			Get
				Return DevExpress.Data.Filtering.FunctionCategory.Math
			End Get
		End Property

		Public ReadOnly Property FunctionCategory() As String
			Get
				Return "Aggregate"
			End Get
		End Property

		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
			Throw New NotImplementedException()
		End Function

		Public Function GetAggregationContextType(ByVal inputType As Type) As Type Implements ICustomAggregateFunction.GetAggregationContextType
			Return GetType(DistinctCountAggregateState)
		End Function

		Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
			Return count <= MaxOperandCount AndAlso count >= MinOperandCount
		End Function

		Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
			Return IsValidOperandCount(operandCount) AndAlso operandIndex = 0
		End Function

		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
			Return GetType(Integer)
		End Function
	End Class
	Friend Class DistinctCountAggregateState
		Implements ICustomAggregateFunctionContext(Of Object, Integer)

		Private values As New HashSet(Of Object)()
		Public Function GetResult() As Integer Implements ICustomAggregateFunctionContext(Of Object, Integer).GetResult
			Return values.Count
		End Function
		Public Sub Process(ByVal value As Object) Implements ICustomAggregateFunctionContext(Of Object, Integer).Process
			If Not values.Contains(value) Then
				values.Add(value)
			End If
		End Sub
	End Class
End Namespace
