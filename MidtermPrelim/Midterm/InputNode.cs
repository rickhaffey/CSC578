using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class InputNode : Node
    {
        public InputNode(int index, double initialValue)
            : base(index, initialValue)
        {
            InitializeNode();
        }

        public InputNode(int index) : base(index) 
        {
            InitializeNode();
        }

        private void InitializeNode()
        {
            SetLabel("x");
            LogHelper.WriteDebug("InputNode Created: {0}", _label);        
        }

        public void CalculateValue(DataInstance dataInstance)
        {
            // no recalculation for the x0 node
            if (IsThresholdUnit)
            {
                LogHelper.WriteDebug("Skipping Calculate() for threshold input: {0} [value:{1}]", _label, _value);
                return; 
            }
  
            // value of an input node is simply the attribute value from the data instance
            _value = dataInstance.Attributes[Index - 1];
            LogHelper.WriteDebug("Calculate() for input: {0}; value: {1}", _label, _value);
        }
    }
}
