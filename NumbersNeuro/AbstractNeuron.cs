using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    abstract class AbstractNeuron
    {
        public double Weight { get; set; }
        public double Error { get; set; }

        public AbstractNeuron()
        {
            Weight = 0.5;
        }

        abstract public double Input(List<double> neurons);
        abstract public void Train(List<double> input, double output);
    }
}
