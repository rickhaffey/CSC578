//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Midterm
//{
//    public static class GradientDescent
//    {
//        public static List<double> CalculateWeights(UserInput userInput)
//        {
//            if (userInput == null) throw new ArgumentNullException("userInput");
//            userInput.Validate();

//            List<double> weights = new List<double>(userInput.DataInstances[0].Attributes.Count);

//            // initialize each weight to some small random value (between min / max init weights specified by the user
//            Random rnd = new Random((int)DateTime.Now.Ticks);
//            for (int i = 0; i < userInput.DataInstances[0].Attributes.Count; i++)
//            {
//                weights.Add(userInput.MinInitialWeight + rnd.NextDouble() * (userInput.MaxInitialWeight - userInput.MinInitialWeight));
//            }

//            int epoch = 1;

//            // until the termination condition is met, do
//            while (epoch <= userInput.MaxEpochs)
//            {
//                // for each training example
//                foreach (DataInstance instance in userInput.DataInstances)
//                {
//                    // compute the output
//                    double sum = 0;
//                    for (int i = 0; i < instance.Attributes.Count; i++)
//                    {
//                        sum += instance.Attributes[i] * weights[i];
//                    }

//                    // adjust each weight as
//                    for (int i = 0; i < weights.Count; i++)
//                    {
//                        weights[i] = weights[i] + userInput.LearningRate * (instance.Class - sum) * instance.Attributes[i];
//                    }
//                }

//                epoch++;
//            }

//            return weights;
//        }
//    }
//}
