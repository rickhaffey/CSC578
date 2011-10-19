using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Midterm
{
    public class DataInstance
    {
        List<double> _attributes;
        double _class;
        private List<double> _calculatedClasses;
        private string _csv;

        public List<double> Attributes { get { return _attributes; } }
        public double Class { get { return _class; } }
        public List<double> CalculatedClasses { get { return _calculatedClasses; } }

        public DataInstance(string csv)
        {
            Guard.IsNullOrEmpty(csv, "csv");

            _csv = csv;

            // build up a data instance from a csv line
            string[] values = csv.Split(',');

            _attributes = new List<double>();
            for (int i = 0; i < values.Length - 1; i++)
            {
                _attributes.Add(double.Parse(values[i]));  // todo: handling for unparsable values
            }

            _class = double.Parse(values[values.Length - 1]);

            _calculatedClasses = new List<double>();
        }

        public double RMSE
        {
            get
            {
                double sumOfsquareOfErrors = this.CalculatedClasses.Sum(cc => Math.Pow(this.Class - cc, 2));
                return Math.Sqrt(sumOfsquareOfErrors / this.CalculatedClasses.Count);
            }
        }

        public static List<DataInstance> ReadFile(string filepath)
        {
            Guard.IsNullOrEmpty(filepath, "filepath");

            string[] lines = File.ReadAllLines(filepath);
            List<DataInstance> result = new List<DataInstance>();

            foreach (string line in lines)
            {
                result.Add(new DataInstance(line));    
            }

            return result;
        }

        public override string ToString()
        {
            return _csv;
        }
    }
}
