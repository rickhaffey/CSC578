using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Midterm;

namespace Midterm.Tests
{
    [TestFixture]
    public class IrisTests
    {
        [Test]
        public void Fixed_10Epochs()
        {
            UserInput userInput = new UserInput()
            {
                DataFilePath = ".\\TestData\\iris.csv",
                ErrorMargin = 0.05,
                HiddenNodeCount = 10,
                LearningRate = 0.1,
                MaxEpochs = 10,
                MaxInitialWeight = 0.02,
                MinInitialWeight = 0.02
            };

            NeuralNetwork net = new NeuralNetwork(userInput);
            Backpropagation.Calculate(net, userInput);

            Assert.AreEqual(net.TrainingState.Epoch, 10);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.MaxRMSE - 0.7647903291625834), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.AvgRMSE - 0.4198381630410543), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.PercentCorrect - 0), 0.05);       
        }

        [Test]
        public void Fixed_200Epochs()
        {
            UserInput userInput = new UserInput()
            {
                DataFilePath = ".\\TestData\\iris.csv",
                ErrorMargin = 0.05,
                HiddenNodeCount = 10,
                LearningRate = 0.1,
                MaxEpochs = 200,
                MaxInitialWeight = 0.02,
                MinInitialWeight = 0.02
            };

            NeuralNetwork net = new NeuralNetwork(userInput);
            Backpropagation.Calculate(net, userInput);

            Assert.AreEqual(net.TrainingState.Epoch, 200);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.MaxRMSE - 0.3539866109402714), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.AvgRMSE - 0.08665010792931953), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.PercentCorrect - .43), 0.05);
        }
    
    }
}
