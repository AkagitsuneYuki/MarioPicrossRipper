using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarioPicrossRipper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            indexTextBox.Text = puzzleIndexBar.Value.ToString();
        }

        private void OpenRomDialogOk(object sender, CancelEventArgs e)
        {
            byte[] buffer = File.ReadAllBytes(openRomDialog.FileName);
            byte[] refrenceData = { 0xF3, 0xC3, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0xF0, 0x40, 0xCB, 0x7F, 0xC8, 0x21, 0x39, 0xC3 };

            for(int i = 0; i < refrenceData.Length; i++)
            {
                if(refrenceData[i] != buffer[i])
                {
                    MessageBox.Show("This file doesn't match with the original ROM!\nPlease make sure the file isn't corrupted.","Error!");
                    return;
                    //throw new Exception("Header doesn't match!");
                }
            }

            Program.puzzles.Clear();

            int offset = 0x92b0;    //this is where in the file the puzzles begin
            //last one is at 0xb2b0

            for(int puzzleIndex = 0; puzzleIndex < 257; puzzleIndex++)
            {
                byte[] data = new byte[32];

                for(int i = 0; i < 32; i++)
                {
                    data[i] = (byte)(buffer[offset + i]);
                }

                try
                {
                    Program.puzzles.Add(new Picross(data));
                }
                catch(Exception ex)
                {
                    //do stuff here
                }

                offset += 32;
            }

            DrawThePuzzle();
            exportCurrentPuzzleButton.Enabled = true;
        }

        private void OpenRomButtonClick(object sender, EventArgs e)
        {
            openRomDialog.Filter = "Gameboy ROMS (*.gb)|*.gb";
            openRomDialog.Title = "Select Mario Picross ROM";
            openRomDialog.FilterIndex = 0;
            openRomDialog.RestoreDirectory = true;
            openRomDialog.FileName = "";

            openRomDialog.ShowDialog();
        }

        private void PuzzleIndexBarScroll(object sender, EventArgs e)
        {
            indexTextBox.Text = puzzleIndexBar.Value.ToString();
            DrawThePuzzle();
        }

        private void DrawThePuzzle()
        {
            if(Program.puzzles.Count != 0)
            {
                int puzzleToDraw = puzzleIndexBar.Value;

                PuzzleDrawer draw = new PuzzleDrawer();
                try
                {
                    puzzleImageBox.Image = draw.PuzzleToBitmap(Program.puzzles[puzzleToDraw]);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExportCurrentPuzzleButtonClick(object sender, EventArgs e)
        {
            saveSingleBitmapDialog.Filter = "PNG Files (*.png)|*.png";
            saveSingleBitmapDialog.Title = "Save Current Puzzle Image";
            saveSingleBitmapDialog.FilterIndex = 0;
            saveSingleBitmapDialog.RestoreDirectory = true;
            saveSingleBitmapDialog.FileName = puzzleIndexBar.Value.ToString() + ".png";

            saveSingleBitmapDialog.ShowDialog();
        }

        private void SaveSingleBitmapDialogOk(object sender, CancelEventArgs e)
        {
            //just in case the file name doesn't have the *.png extension
            string fileName = saveSingleBitmapDialog.FileName;
            if (!fileName.Contains(".png"))
            {
                fileName = fileName + ".png";
            }

            puzzleImageBox.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
