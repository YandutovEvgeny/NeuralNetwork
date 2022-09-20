using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    class NeuroWeb
    {
        public List<FirstNeuron>[] firstNeurons;
        public List<SecondNeuron> secondNeurons;
        public ThirdNeuron thirdNeuron;

        public NeuroWeb()
        {
            firstNeurons = new List<FirstNeuron>[20];
            secondNeurons = new List<SecondNeuron>();
            thirdNeuron = new ThirdNeuron(secondNeurons);
            for (int i = 0; i < 20; i++)
            {
                firstNeurons[i] = new List<FirstNeuron>();
                for (int j = 0; j < 20; j++)
                    firstNeurons[i].Add(new FirstNeuron());
                secondNeurons.Add(new SecondNeuron(firstNeurons[i]));
            }
        }

        public void ThirdLayerTrain(int[,] figure, int answer)
        {
            int i = 0;
            foreach (SecondNeuron s in thirdNeuron._secondNeurons)
            {
                List<double> res = new List<double>();
                int j = 0;
                foreach(FirstNeuron fn in s._firstLayer)
                {
                    res.Add(fn.Input(new List<double>() { figure[i, j] }));
                    j++;
                }
                i++;
                s.SecondLayerTrain(res, answer);
            }
        }

        public double ThirdLayerInput(int[,] figure)
        {
            double result = 0;
            int i = 0;
            foreach (SecondNeuron s in thirdNeuron._secondNeurons)
            {
                List<double> res = new List<double>();
                int j = 0;
                foreach (FirstNeuron fn in s._firstLayer)
                {
                    res.Add(fn.Input(new List<double>() { figure[i, j] }));
                    j++;
                }
                i++;
                result += s.Input(res);
            }
            return result;
        }

        public void SecondLayerTrain(int[,] figure, int answer)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    result.Add(firstNeurons[i][j].Input(new List<double>() { figure[i, j] }));
                }
                secondNeurons[i].Train(result, answer);
                result = new List<double>();
            }
        }

        public List<double> SecondLayerInput(int[,] figure)
        {
            List<double> result = new List<double>();
            List<double> answer = new List<double>();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    result.Add(firstNeurons[i][j].Input(new List<double>() { figure[i, j] }));
                }
                answer.Add(secondNeurons[i].Input(result));
                result = new List<double>();
            }
            return answer;
        }
    }
}
