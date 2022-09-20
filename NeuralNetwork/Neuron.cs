using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Neuron
    {
        private double Weight { get; set; }
        public double Error { get; set; }
        public Neuron()
        {
            Random random = new Random();
            Weight = random.NextDouble();
        }
        public double Input(double data)
        {
            return Weight * data;
        }

        public void Train(double input, double output)
        {
            double result = Input(input);
            Error = output - result;
            double correction = Error / result;
            correction = correction * 0.00001;
            Weight += correction;
        }
    }
}
