using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public class Backpropagation
    {
        public static void Calculate(NeuralNetwork neuralNetwork, UserInput userInput)
        {
            LogHelper.WriteDebug("Backpropagation.Calculate - Enter");
            long epoch = 0;

            // do until the termination condition is met
            while (++epoch <= userInput.MaxEpochs && neuralNetwork.TrainingState.MaxRMSE >= userInput.ErrorMargin)
            {
                LogHelper.WriteDebug("Starting epoch {0}", epoch);

                // iterate through the training examples
                foreach (DataInstance trainingExample in userInput.DataInstances)
                {
                    LogHelper.WriteDebug("Processing training example: {0}", trainingExample);

                    // 1. 
                    LogHelper.WriteDebug("Propagating input forward through network.");
                    neuralNetwork.InputNodes.ForEach(input => input.CalculateValue(trainingExample));
                    neuralNetwork.HiddenNodes.ForEach(hidden => hidden.CalculateValue(neuralNetwork.Weights));
                    neuralNetwork.OutputNodes.ForEach(output => output.CalculateValue(neuralNetwork.Weights));

                    // 2. propagate error backward through the network
                    LogHelper.WriteDebug("Calculating output unit error values.");
                    neuralNetwork.OutputNodes.ForEach(output => output.CalculateError(trainingExample));

                    LogHelper.WriteDebug("Calculating hidden unit error values.");
                    neuralNetwork.HiddenNodes.ForEach(hidden => hidden.CalculateError(neuralNetwork.Weights));

                    LogHelper.WriteDebug("Updating network weights.");
                    neuralNetwork.Weights.ForEach(weight => weight.CalculateValue(userInput.LearningRate));
                }

                // classify the data based on the updated weights
                LogHelper.WriteDebug("Running classification with updated weights.");
                neuralNetwork.TrainingState =  ClassifyData(neuralNetwork, userInput, epoch);
            }
            
            LogHelper.WriteDebug("Backpropagation.Calculate - Exit");
        }

        private static TrainingState ClassifyData(NeuralNetwork neuralNetwork, UserInput userInput, long epoch)
        {
            // calculate the output for each training example
            foreach (DataInstance trainingExample in userInput.DataInstances)
            {
                neuralNetwork.InputNodes.ForEach(input => input.CalculateValue(trainingExample));
                neuralNetwork.HiddenNodes.ForEach(hidden => hidden.CalculateValue(neuralNetwork.Weights));
                neuralNetwork.OutputNodes.ForEach(output => output.CalculateValue(neuralNetwork.Weights));

                // associated all the calculated outputs (1 for our current case) with the training example
                trainingExample.CalculatedClasses.Clear();
                neuralNetwork.OutputNodes.ForEach(output => trainingExample.CalculatedClasses.Add(output.Value));
            }

            // calculate RMSE for all training examples
            List<double> RMSEs = userInput.DataInstances.ConvertAll(trainingExample => trainingExample.RMSE);

            // return the results
            return new TrainingState() 
            {
                Epoch = epoch,
                MaxRMSE = RMSEs.Max(),
                AvgRMSE = RMSEs.Average(),
                PercentCorrect = (float)RMSEs.Where(rmse => rmse < userInput.ErrorMargin).Count() / (float)RMSEs.Count
            };
        }
    }
}
