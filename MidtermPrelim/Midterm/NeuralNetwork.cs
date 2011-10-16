using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class NeuralNetwork
    {
        private List<InputNode> _inputNodes;
        private List<HiddenNode> _hiddenNodes;
        private List<OutputNode> _outputNodes;
        private List<Weight> _weights = new List<Weight>();

        public List<InputNode> InputNodes { get { return _inputNodes; } }
        public List<HiddenNode> HiddenNodes { get { return _hiddenNodes; } }
        public List<OutputNode> OutputNodes { get { return _outputNodes; } }
        public List<Weight> Weights { get { return _weights; } }

        private TrainingState _trainingState;
        public TrainingState TrainingState
        {
            get
            {
                return _trainingState;
            }
            set
            {
                _trainingState = value;
                OnTrainingStateChanged(_trainingState);
            }
        }

        public delegate void TrainingStateChangedEventHandler(object sender, TrainingStateEventArgs e);
        public event TrainingStateChangedEventHandler TrainingStateChanged;

        public NeuralNetwork(UserInput userInput)
        {
            InitializeInputNodes(userInput.DataInstances[0].Attributes.Count);
            InitializeHiddenNodes(userInput.HiddenNodeCount, userInput.MinInitialWeight, userInput.MaxInitialWeight);
            InitializeOutputNodes(userInput.MinInitialWeight, userInput.MaxInitialWeight);
        }

        private void InitializeInputNodes(int inputNodeCount)
        {
            _inputNodes = new List<InputNode>(inputNodeCount);

            // add the x0 'input'
            InputNode x0 = new InputNode(0, -1.0);
            //x0.Value = -1; // per assignment instructions
            _inputNodes.Add(x0);

            // add the true input nodes
            for (int i = 1; i <= inputNodeCount; i++)
            {
                _inputNodes.Add(new InputNode(i));
            }
        }

        private void InitializeHiddenNodes(int hiddenNodeCount, double minInitialWeight, double maxInitialWeight)
        {
            _hiddenNodes = new List<HiddenNode>(hiddenNodeCount);

            // add the h0 'input' for the output layer
            HiddenNode h0 = new HiddenNode(0, -1.0);
            //h0.Value = -1; // per assignment instructions
            _hiddenNodes.Add(h0);

            // add the true hidden nodes
            for (int i = 1; i <= hiddenNodeCount; i++)
            {
                HiddenNode hiddenNode = new HiddenNode(i);
                _hiddenNodes.Add(hiddenNode);

                // initialize inbound weights
                foreach (InputNode inputNode in _inputNodes)
                {
                    double initialValue = Weight.GetInitialWeight(minInitialWeight, maxInitialWeight);
                    _weights.Add(new Weight(inputNode, hiddenNode, initialValue));
                }
            }
        }

        private void InitializeOutputNodes(double minInitialWeight, double maxInitialWeight)
        {
            // per instructions -- one output node
            _outputNodes = new List<OutputNode>(1);
            OutputNode outputNode = new OutputNode(1);
            _outputNodes.Add(outputNode);

            // initialize inbound weights
            foreach (HiddenNode hiddenNode in _hiddenNodes)
            {
                double initialValue = Weight.GetInitialWeight(minInitialWeight, maxInitialWeight);
                _weights.Add(new Weight(hiddenNode, outputNode, initialValue));
            }
        }

        protected void OnTrainingStateChanged(TrainingState trainingState)
        {
            if (TrainingStateChanged != null)
            {
                TrainingStateChanged(this, new TrainingStateEventArgs(trainingState));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" -- network -- ");
            sb.AppendLine(" input nodes");
            _inputNodes.ForEach(input => sb.AppendLine(input.ToString()));
            sb.AppendLine(" hidden nodes");
            _hiddenNodes.ForEach(hidden => sb.AppendLine(hidden.ToString()));
            sb.AppendLine(" output nodes");
            _outputNodes.ForEach(output => sb.AppendLine(output.ToString()));
            sb.AppendLine(" weights");
            _weights.ForEach(weight => sb.AppendLine(weight.ToString()));
            return sb.ToString();
        }
    }
}
