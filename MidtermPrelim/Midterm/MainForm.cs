using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Midterm
{
    public partial class MainForm : Form
    {
        private UserInput _userInput;
        private StreamWriter _resultsFile;

        public MainForm()
        {
            InitializeComponent();

            _userInput = UserInput.Default;
            RefreshUserInputDisplay();

            EnableDisable(_userInput.DataInstances != null && _userInput.DataInstances.Count > 0);
        }

        private void InitializeResultsFile()
        {
            const string RESULTS_FILENAME = "results.txt";
            string resultsDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string resultsFilePath = Path.Combine(resultsDir, RESULTS_FILENAME);

            try
            {
                _resultsFile = new StreamWriter(resultsFilePath);
                _resultsFile.AutoFlush = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("There was an error opening the results file ('{0}').  Output will only be displayed in the user interface.\r\nError Details: {1}", 
                    resultsFilePath, 
                    ex));
                _resultsFile = null;
            }
        }

        private void chooseDataFile_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = _userInput.DataFilePath;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _userInput.DataFilePath = openFileDialog.FileName;
                dataFileLabel.Text = _userInput.DataFilePath;

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

            InitializeResultsFile();

            output.Clear();

            NeuralNetwork net = new NeuralNetwork(_userInput);

            net.TrainingStateChanged += new NeuralNetwork.TrainingStateChangedEventHandler(net_TrainingStateChanged);
            Backpropagation.Calculate(net, _userInput);
        }

        void net_TrainingStateChanged(object sender, TrainingStateEventArgs e)
        {
            this.output.AppendText(Environment.NewLine);
            this.output.AppendText(e.TrainingState.ToString());
            this.output.AppendText(Environment.NewLine);

            try
            {
                if (_resultsFile != null)
                {
                    _resultsFile.WriteLine();
                    _resultsFile.WriteLine(e.TrainingState.ToString());
                    _resultsFile.WriteLine();
                }
            }
            catch (Exception ex)
            { 
                // failure to write to results file is not 'fatal', just note it in the log
                LogHelper.WriteDebug("Error writing to results file: {0}", ex);
            }
        }
    }
}
