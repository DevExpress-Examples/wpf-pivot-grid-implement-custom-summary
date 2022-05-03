using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.PivotGrid.ServerMode.Queryable;
using System.Linq.Expressions;
using DevExpress.Data.Linq;
using DevExpress.DataProcessing.Criteria;

namespace DXPivotGrid_CustomSummary {
    class DistinctCountFunction : ICustomAggregateFunction, ICustomFunctionOperatorBrowsable {
        public string Name => "DistinctCount";
        public int MinOperandCount => 1;

        public int MaxOperandCount => 1;

        public string Description => @"Displays the number of unique values of the field";

        public FunctionCategory Category => DevExpress.Data.Filtering.FunctionCategory.Math;

        public string FunctionCategory => "Aggregate";

        public object Evaluate(params object[] operands) {
            throw new NotImplementedException();
        }

        public Type GetAggregationContextType(Type inputType) {
            return typeof(DistinctCountAggregateState);
        }

        public bool IsValidOperandCount(int count) {
            return count <= MaxOperandCount && count >= MinOperandCount;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type) {
            return IsValidOperandCount(operandCount) && operandIndex == 0;
        }

        public Type ResultType(params Type[] operands) {
            return typeof(int);
        }
    }
    class DistinctCountAggregateState : ICustomAggregateFunctionContext<object, int> {
        HashSet<object> values = new HashSet<object>();
        public int GetResult() {
            return values.Count;
        }
        public void Process(object value) {
            if(!values.Contains(value))
                values.Add(value);
        }
    }
}
