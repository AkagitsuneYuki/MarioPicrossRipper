using System;
using System.Drawing;

namespace MarioPicrossRipper
{
    internal class PuzzleDrawer
    {
        public Bitmap PuzzleToBitmap(Picross puzzle)
        {
            var bmp = new Bitmap(puzzle.Width, puzzle.Height);
            var g = Graphics.FromImage(bmp);

            for (var i = 0; i < puzzle.PuzzleData.Length; i++)
            {
                var x = i % 16;
                var y = i / 16;
                var color = puzzle.PuzzleData[i] == 1 ? Brushes.Black : Brushes.White;
                g.FillRectangle(color, x, y, 1, 1);
            }
            
            return bmp;
        }

    }
}
