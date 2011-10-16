using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class Weight
    {
        private Node _fromNode;
        private Node _toNode;
        private double _value;

        public Weight(Node from, Node to, double value)
        {
            _fromNode = from;
            _toNode = to;
            _value = value;
        }

        public double Value { get { return _value; } }
        public Node FromNode { get { return _fromNode; } }
        public Node ToNode { get { return _toNode; } }

        public static double GetInitialWeight(double min, double max)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            return min + rnd.NextDouble() * (max - min);
        }

        public override string ToString()
        {
            return string.Format("w:{0}->{1}: {2}", _fromNode.Label, _toNode.Label, Value);
        }

        public void CalculateValue(double learningRate)
        {
            double delta = learningRate * ToNode.Error * FromNode.Value;
            _value = _value + delta;
        }
    }
}
