using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumbersNeuro
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Brush brush;
        Bitmap bitmap;
        NeuroWeb neuroWeb;
        string[] files;
        public Form1()
        {
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            brush = new SolidBrush(Color.Black);
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            neuroWeb = new NeuroWeb();
            ClearBitmap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int[,] array = BitmapToArray.GetArray(bitmap, pictureBox1.Height, pictureBox1.Width);
            Bitmap test = CenterArray.Generate(array, pictureBox1.Height, pictureBox1.Width);
            array = BitmapToArray.GetArray(test);

            List<double> result = neuroWeb.SecondLayerInput(array);
            foreach (double r in result)
            {
                richTextBox1.Text += Math.Round(r, 2).ToString() + "\n";
            }

            foreach (List<FirstNeuron> x in neuroWeb.firstNeurons)
            {
                richTextBox1.Text += "\n";
                foreach (FirstNeuron y in x)
                {
                    if (y.Weight > 1)
                        richTextBox1.Text += y.Weight.ToString("#.##") + "\t";
                    else
                        richTextBox1.Text += "\t";
                }
            }
            MessageBox.Show(neuroWeb.ThirdLayerInput(array).ToString());
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                graphics.FillRectangle(brush, e.X - 3, e.Y - 3, 10, 10);
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (e.X + i < bitmap.Width - 1 && e.Y + j < bitmap.Height - 1)
                            if (e.X - i >= 0 && e.Y - j >= 0)
                            {
                                bitmap.SetPixel(e.X + i, e.Y + j, Color.White);
                                bitmap.SetPixel(e.X - i, e.Y - j, Color.White);
                            }
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bitmap.Save("C:\\1\\1.bmp");
            ClearBitmap();
            graphics.Clear(Color.White);
        }

        void ClearBitmap()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i,j,Color.Black);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            bitmap = new Bitmap(Image.FromFile(openFileDialog.FileName), 
                pictureBox1.Width, pictureBox1.Height);
            button1.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                files =  Directory.GetFiles(dialog.SelectedPath);
            }
            foreach (string name in files)
            {
                listBox1.Items.Add(name);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (string path in listBox1.Items)
            {
                bitmap = new Bitmap(Image.FromFile(path),
                pictureBox1.Width, pictureBox1.Height);
                int[,] array = BitmapToArray.GetArray(bitmap, pictureBox1.Height, pictureBox1.Width);
                Bitmap test = CenterArray.Generate(array, pictureBox1.Height, pictureBox1.Width);
                array = BitmapToArray.GetArray(test);

                neuroWeb.SecondLayerTrain(array, Convert.ToInt32(textBox1.Text) + 1);
                neuroWeb.ThirdLayerTrain(array, Convert.ToInt32(textBox1.Text) + 1);
            }
            MessageBox.Show("Теперь качок");
        }
    }
}
