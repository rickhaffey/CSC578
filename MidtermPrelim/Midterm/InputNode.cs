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
            SetLabel("x");
        }

        public InputNode(int index) : base(index) 
        {
            SetLabel("x");
        }

        public void CalculateValue(DataInstance dataInstance)
        {
            // no recalculation for the x0 node
            if (Index == 0) return;
  
            // value of an input node is simply the attribute value from the data instance
            _value = dataInstance.Attributes[Index - 1];
        }
    }
}
