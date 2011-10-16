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
            long epoch = 0;

            // do until the termination condition is met
            while (++epoch <= userInput.MaxEpochs)
            {
                // iterate through the training examples
                foreach (DataInstance trainingExample in userInput.DataInstances)
                {
                    // 1. propagate the input forward through the network
                    neuralNetwork.InputNodes.ForEach(input => input.CalculateValue(trainingExample));
                    neuralNetwork.HiddenNodes.ForEach(hidden => hidden.CalculateValue(neuralNetwork.Weights));
                    neuralNetwork.OutputNodes.ForEach(output => output.CalculateValue(neuralNetwork.Weights));

                    // 2. propagate error backward through the network
                    // for each network output unit, calc error term
                    neuralNetwork.OutputNodes.ForEach(output => output.CalculateError(trainingExample));

                    // for each hidden unit, calc error term
                    neuralNetwork.HiddenNodes.ForEach(hidden => hidden.CalculateError(neuralNetwork.Weights));

                    // update each network weight
                    neuralNetwork.Weights.ForEach(weight => weight.CalculateValue(userInput.LearningRate));
                }

                // classify the data based on the updated weights
                neuralNetwork.TrainingState =  ClassifyData(neuralNetwork, userInput, epoch);

                // check to see if the accuracy is within the user specified threshold
                if (neuralNetwork.TrainingState.MaxRMSE < userInput.ErrorMargin)
                    break;
            }
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
