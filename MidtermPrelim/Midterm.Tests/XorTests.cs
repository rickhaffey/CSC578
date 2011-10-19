using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Midterm;

namespace Midterm.Tests
{
    [TestFixture]
    public class XorTests
    {
        [Test]
        public void Fixed()
        {
            UserInput userInput = new UserInput()
            {
                DataFilePath = ".\\TestData\\xor.csv",
                ErrorMargin = 0.1,
                HiddenNodeCount = 2,
                LearningRate = 0.1,
                MaxEpochs = 10,
                MaxInitialWeight = 0.6,
                MinInitialWeight = 0.6
            };

            NeuralNetwork net = new NeuralNetwork(userInput);
            Backpropagation.Calculate(net, userInput);

            Assert.AreEqual(net.TrainingState.Epoch, 10);

            Assert.LessOrEqual(Math.Abs(net.TrainingState.MaxRMSE - 0.5432215742673802), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.AvgRMSE - 0.4999911891911738), 0.0000001);
            Assert.LessOrEqual(Math.Abs(net.TrainingState.PercentCorrect - 0), 0.05);
        }
    }
}
