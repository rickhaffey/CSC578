using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public abstract class Node
    {
        protected string _label;
        private readonly int _index;
        protected double _value;
        protected double _error;

        public string Label { get { return _label; } }
        public int Index { get { return _index; } }
        public double Value { get { return _value; } }
        public double Error { get { return _error; } }

        public Node(int index, double initialValue)
        {
            _value = initialValue;
            _index = index;
        }

        public Node(int index) : this(index, 0.0) { }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Label, Value);
        }

        protected void SetLabel(string labelCategory)
        {
            _label = string.Format("{0}{1}", labelCategory, _index);
        }
    }
}
