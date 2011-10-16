using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Midterm
{
    public partial class MainForm : Form
    {
        private UserInput _userInput;

        public MainForm()
        {
            InitializeComponent();
            _userInput = UserInput.Default;
            RefreshUserInputDisplay();

            EnableDisable(_userInput.DataInstances != null && _userInput.DataInstances.Count > 0);
        }

        private void chooseDataFile_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = _userInput.DataFilePath;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _userInput.DataFilePath = openFileDialog.FileName;
                RefreshUserInputDisplay();

                EnableDisable(true);
            }
        }

        private void EnableDisable(bool enabled)
        {
            hiddenNodes.Enabled = enabled;
            learningRate.Enabled = enabled;
            errorMargin.Enabled = enabled;
            maxEpochs.Enabled = enabled;
            minInitWeight.Enabled = enabled;
            maxInitWeight.Enabled = enabled;
            trainButton.Enabled = enabled;
        }

        private void RefreshUserInputDisplay()
        {
            dataFileLabel.Text = _userInput.DataFilePath;
            hiddenNodes.Text = _userInput.HiddenNodeCount.ToString();
            learningRate.Text = _userInput.LearningRate.ToString();
            errorMargin.Text = _userInput.ErrorMargin.ToString();
            maxEpochs.Text = _userInput.MaxEpochs.ToString();
            minInitWeight.Text = _userInput.MinInitialWeight.ToString();
            maxInitWeight.Text = _userInput.MaxInitialWeight.ToString();
        }

        private void UpdateUserInputFromControls()
        {
            _userInput.DataFilePath = dataFileLabel.Text;
            _userInput.HiddenNodeCount = int.Parse(hiddenNodes.Text);
            _userInput.LearningRate = double.Parse(learningRate.Text);
            _userInput.ErrorMargin = double.Parse(errorMargin.Text);
            _userInput.MaxEpochs = int.Parse(maxEpochs.Text);
            _userInput.MinInitialWeight = double.Parse(minInitWeight.Text);
            _userInput.MaxInitialWeight = double.Parse(maxInitWeight.Text);         
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            UpdateUserInputFromControls();

            output.Clear();

            NeuralNetwork net = new NeuralNetwork(_userInput);
            net.TrainingStateChanged += new NeuralNetwork.TrainingStateChangedEventHandler(net_TrainingStateChanged);
            Backpropagation.Calculate(net, _userInput);
        }

        void net_TrainingStateChanged(object sender, TrainingStateEventArgs e)
        {
            this.output.AppendText(Environment.NewLine);
            this.output.AppendText(e.TrainingState.ToString());
        }
    }
}
