using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    public partial class Form1 : Form
    {
        Neuron neuron;
        public Form1()
        {
            InitializeComponent();
            neuron = new Neuron();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 200000; i++)
            {
                int x = random.Next(1,360);
                neuron.Train(x, x * 0.0174533);
            }
            MessageBox.Show("Обучение закончено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double result = neuron.Input(x);
            MessageBox.Show($"{x} градусов, это {result} радиан");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 200000; i++)
            {
                int x = random.Next(1, 360);
                neuron.Train(x, x * 0.621371);
            }
            MessageBox.Show("Обучение закончено");
        }
    }
}
