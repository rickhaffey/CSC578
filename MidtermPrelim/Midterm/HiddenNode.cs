using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class HiddenNode : Node
    {
        public HiddenNode(int index, double initialValue) : base(index, initialValue)
        {
            InitializeNode();
        }

        public HiddenNode(int index) : base(index)
        {
            InitializeNode();
        }

        private void InitializeNode()
        {
            SetLabel("h");
            LogHelper.WriteDebug("HiddenNode Created: {0}", _label);
        }

        public void CalculateValue(List<Weight> weights)
        {
            // no recalculation of value for the threshold node
            if (IsThresholdUnit)
            {
                LogHelper.WriteDebug("Skipping CalculateValue() for threshold hidden: {0} [value:{1}]", _label, _value);
                return;
            }

            double net = weights.Where(w => w.ToNode.Equals(this)).Sum(w => w.FromNode.Value * w.Value);
            _value = 1.0 / (1.0 + Math.Exp(-net));
            LogHelper.WriteDebug("CalculateValue() for hidden: {0}; value: {1}", _label, _value);
        }


        public void CalculateError(List<Weight> weights)
        {
            double multiplier = _value * (1 - _value);
            double sum = weights.Where(weight => weight.FromNode.Equals(this)).Sum(weight => weight.Value * weight.ToNode.Error);
            _error = sum * multiplier;
            LogHelper.WriteDebug("CalculateError() for hidden: {0}; error: {1}", _label, _error);
        }
    }
}
