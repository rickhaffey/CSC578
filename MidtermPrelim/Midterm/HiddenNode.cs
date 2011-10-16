using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class HiddenNode : Node
    {
        public HiddenNode(int index, double initialValue) : base(index)
        {
            SetLabel("h");
        }

        public HiddenNode(int index) : base(index)
        {
            SetLabel("h");
        }

        public void CalculateValue(List<Weight> weights)
        {
            double net = weights.Where(w => w.ToNode.Index == Index).Sum(w => w.FromNode.Value * w.Value);
            _value = 1.0 / (1.0 + Math.Exp(-net));
        }

        public void CalculateError(List<Weight> weights)
        {
            double multiplier = _value * (1 - _value);
            double sum = weights.Where(weight => weight.FromNode.Index == this.Index).Sum(weight => weight.Value * weight.ToNode.Error);
            _error = sum * multiplier;
        }
    }
}
