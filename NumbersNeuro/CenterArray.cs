using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersNeuro
{
    static class CenterArray
    {
        static public Bitmap Generate(int [,] arr, int h, int w)
        {
            int top = 0;
            int left = 0;
            int bot = 0;
            int right = 0;
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                {
                    if (arr[i, j] == 1 && top == 0)
                        top = i;
                    if (arr[h-i-1, j] == 1 && bot == 0)
                        bot = h - i - 1;
                }
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    if (arr[j, i] == 1 && left == 0)
                        left = i;
                    if (arr[j, w - i - 1] == 1 && right == 0)
                        right = w - i - 1;
                }
            
            Bitmap result = new Bitmap(right - left + 1, bot - top + 1);
            for (int i = 0; i < result.Height; i++)
                for (int j = 0; j < result.Width; j++)
                {
                    if (arr[top + i, left + j] == 1)
                        result.SetPixel(j, i, Color.Black);
                    else
                        result.SetPixel(j,i, Color.White);
                }
            return result;
        }
    }
}
