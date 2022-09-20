using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    static class BitmapToArray
    {
        public static int[,] GetArray(Bitmap bitmap, int h = 20, int w = 20)
        {
            //Сжимаем картинку 
            Bitmap bitmap1 = new Bitmap(bitmap, w, h);
            int[,] array = new int[h,w];

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    Color c = bitmap1.GetPixel(j, i);
                    if ((c.R + c.G + c.B) / 3 > 150)
                        array[i, j] = 1;
                    else
                        array[i, j] = 0;
                }
            return array;
        }
    }
}
