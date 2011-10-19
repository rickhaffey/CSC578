using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class OutputNode : Node
    {
        public OutputNode(int index) : base(index)
        {
            SetLabel("o");
            LogHelper.WriteDebug("OutputNode Created: {0}", _label);
        }

        public void CalculateValue(List<Weight> weights)
        {
            double net = weights.Where(w => w.ToNode.Equals(this)).Sum(w => w.FromNode.Value * w.Value);
            _value = 1.0 / (1.0 + Math.Exp(-net));
            LogHelper.WriteDebug("CalculateValue() for output: {0}; value: {1}", _label, _value);
        }

        public void CalculateError(DataInstance dataInstance)
        {
            _error = _value * (1.0 - _value) * (dataInstance.Class - _value);
            LogHelper.WriteDebug("CalculateError() for output: {0}; value: {1}", _label, _error);
        }
    }
}
