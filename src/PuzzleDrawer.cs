using System.Drawing;

namespace MarioPicrossRipper
{
    internal class PuzzleDrawer
    {
        public Bitmap PuzzleToBitmap(Picross puzzle)
        {
            Bitmap bmp = new Bitmap(160, 150);
            int index = 0;
            Graphics g = Graphics.FromImage(bmp);
            for (int y = 0; y < bmp.Height / 10; y++)
            {
                for(int x = 0; x < bmp.Width / 10; x++)
                {
                    if(puzzle.PuzzleData[index] == 1)
                    {
                        //bmp.SetPixel(x, y, Color.Black);
                        g.FillRectangle(Brushes.Black, x * 10, y * 10, 10, 10);
                    }
                    else
                    {
                        //bmp.SetPixel(x, y, Color.White);
                        g.FillRectangle(Brushes.White, x * 10, y * 10, 10, 10);
                    }
                    index++;
                }
            }
            return bmp;
        }

    }
}
