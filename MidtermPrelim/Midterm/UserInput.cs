using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class UserInput
    {
        private string _dataFilePath;
        private List<DataInstance> _dataInstances;

        public string DataFilePath
        {
            get
            {
                return _dataFilePath;
            }
            set
            {
                _dataFilePath = value;
                if (!string.IsNullOrEmpty(_dataFilePath))
                {
                    _dataInstances = DataInstance.ReadFile(_dataFilePath);
                }
            }
        }
        public int HiddenNodeCount { get; set; }
        public double LearningRate { get; set; }
        public double ErrorMargin { get; set; }
        public int MaxEpochs { get; set; }
        public double MinInitialWeight { get; set; }
        public double MaxInitialWeight { get; set; }

        public List<DataInstance> DataInstances { get { return _dataInstances; } }

        public static UserInput Default
        {
            get
            {
                return new UserInput()
                {
                    DataFilePath = null,
                    //DataFilePath = @"C:\Users\Rick\Documents\My Dropbox\DePaul\CSC578\Assignments\Midterm\xor.csv",
                    HiddenNodeCount = 1,
                    LearningRate = 0.1,
                    ErrorMargin = 0.1,
                    MaxEpochs = 1000,
                    MinInitialWeight = 0.1,
                    MaxInitialWeight = 0.1
                };
            }
        }

        public void Validate()
        {
            if (DataInstances == null || DataInstances.Count == 0)
                throw new ArgumentException("UserInput.DataInstances");

        }

    }
}
