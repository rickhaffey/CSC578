using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class TrainingState
    {
        public long Epoch { get; set; }
        public double MaxRMSE { get; set; }
        public double AvgRMSE { get; set; }
        public float PercentCorrect { get; set; }

        public static TrainingState Default
        {
            get
            {
                return new TrainingState() 
                {
                    Epoch = 0,
                    MaxRMSE = double.MaxValue,
                    AvgRMSE = double.MaxValue,
                    PercentCorrect = 0
                };
            }
        }

        public override string ToString()
        {
            return string.Format("***** Epoch {0} *****\r\nMaximum RMSE: {1}\r\nAverage RMSE: {2}\r\nPercent Correct: {3:P}\r\n",
                Epoch, MaxRMSE, AvgRMSE, PercentCorrect);
        }
    }
}
