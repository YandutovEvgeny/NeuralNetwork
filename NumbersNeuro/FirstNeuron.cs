using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    class FirstNeuron : AbstractNeuron
    {
        public FirstNeuron() : base() { }

        public override double Input(List<double> num)
        {
            return num[0] * Weight;
        }

        public override void Train(List<double> input, double output)
        {
            Error = output - (Input(input) + 0.3);
            double correction = Error / (Input(input) + 0.3);
            correction *= 0.001;
            Weight += correction;
        }
    }
}
