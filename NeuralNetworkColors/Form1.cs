using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkColors
{
    public partial class Form1 : Form
    {
        List<Neuro> Input;
        OutputNeuro outputNeuro;
        public Form1()
        {
            InitializeComponent();
            Input = new List<Neuro>
            {
                new Neuro(),
                new Neuro(),
                new Neuro()
            };
            outputNeuro = new OutputNeuro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap("C:\\1\\2.jpg");
            int h = bitmap.Height;
            int w = bitmap.Width;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    Input[0].Input(c.R / 255.0);
                    Input[1].Input(c.G / 255.0);
                    Input[2].Input(c.B / 255.0);
                    outputNeuro.Train(Input);
                }
            }
            MessageBox.Show("Готово");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            Input[0].Input(colorDialog.Color.R / 255.0);
            Input[1].Input(colorDialog.Color.G / 255.0);
            Input[2].Input(colorDialog.Color.B / 255.0);
            MessageBox.Show($"{Input[0].Result} {Input[1].Result} {Input[2].Result}");
            MessageBox.Show(outputNeuro.Input(Input).ToString());
        }
    }
}
