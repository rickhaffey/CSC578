using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class TrainingStateEventArgs
    {
        private TrainingState _trainingState;

        public TrainingStateEventArgs(TrainingState trainingState)
        {
            _trainingState = trainingState;
        }

        public TrainingState TrainingState { get { return _trainingState; } }
    }
}
