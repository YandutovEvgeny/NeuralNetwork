using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkColors
{
    class OutputNeuro
    {
        List<Neuro> neuros;
        public OutputNeuro()
        {
            neuros = new List<Neuro>();
        }

        public bool Input(List<Neuro> neuros)
        {
            if (neuros[0].Result +
                   neuros[1].Result +
                   neuros[2].Result > 0.5) 
                return true;
            else 
                return false;
        }

        public void Train(List<Neuro> neuros, bool result = true)
        {
            bool myResult = Input(neuros);

            //if(neuros[0].Result > 0.5 && result == true)
                neuros[0].Train(neuros[0].Data, 1);
            //if (neuros[1].Result > 0.5 && result == true)
                neuros[1].Train(neuros[1].Data, 1);
            //if (neuros[2].Result > 0.5 && result == true)
                neuros[2].Train(neuros[2].Data, 1);

            /*if (neuros[0].Result <= 0.5 && result == true)
                neuros[0].Train(neuros[0].Data, 0);
            if (neuros[1].Result <= 0.5 && result == true)
                neuros[1].Train(neuros[1].Data, 0);
            if (neuros[2].Result <= 0.5 && result == true)
                neuros[2].Train(neuros[2].Data, 0);*/
        }
    }
}
