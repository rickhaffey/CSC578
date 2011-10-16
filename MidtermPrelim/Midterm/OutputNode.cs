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
        }

        public void CalculateValue(List<Weight> weights)
        {
            double net = weights.Where(w => w.ToNode.Index == Index).Sum(w => w.FromNode.Value * w.Value);
            _value = 1.0 / (1.0 + Math.Exp(-net));
        }

        public void CalculateError(DataInstance dataInstance)
        {
            _error = _value * (1.0 - _value) * (dataInstance.Class - _value);
        }
    }
}
