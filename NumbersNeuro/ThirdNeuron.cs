using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    class ThirdNeuron : AbstractNeuron
    {
        public List<SecondNeuron> _secondNeurons;

        public ThirdNeuron(List<SecondNeuron> secondNeurons) : base()
        {
            _secondNeurons = secondNeurons;
        }
        public override double Input(List<double> neurons)
        {
            double result = 0;
            foreach (double data in neurons)
            {
                result += data;
            }
            return result;
        }

        public override void Train(List<double> input, double output)
        {
            for (int i = 0; i < _secondNeurons.Count; i++)
            {
                _secondNeurons[i].Train(new List<double>() { input[i] }, output);
            }
        }
    }
}
