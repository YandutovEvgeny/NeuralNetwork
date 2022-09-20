using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    class SecondNeuron : AbstractNeuron
    {
        public List<FirstNeuron> _firstLayer;
        public SecondNeuron(List<FirstNeuron> firstLayer) : base()
        {
            _firstLayer = firstLayer;
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
            for (int i = 0; i < _firstLayer.Count; i++)
            {
                _firstLayer[i].Train(new List<double>() { input[i] }, output);
            }
        }

        public void SecondLayerTrain(List<double> input, double output)
        {
            Error = output - (Input(input) + 0.3);
            double correction = Error / (Input(input) + 0.3);
            correction *= 0.001;
            Weight += correction;
        }
    }
}
