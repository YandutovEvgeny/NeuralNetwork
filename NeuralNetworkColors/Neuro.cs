using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkColors
{
    class Neuro
    {
        public double Weight { get; set; }
        public double Error { get; set; }
        public double Result { get; set; }
        public double Data { get; set; }

        public Neuro()
        {
            Random random = new Random();
            Weight = random.NextDouble();
        }
        public double Input(double data)
        {
            if (data == 0) data = 0.001;
            Data = data;
            Result = Weight * data;
            return Weight * data;
        }

        public void Train(double input, double output)
        {
            double result = Input(input);
            Error = output - result;
            double correction = Error / result;
            correction = correction * 0.001;
            Weight += correction;
            //Weight = 1 / (1 + Math.Pow(2.9, -Weight));
        }
    }
}
