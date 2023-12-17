using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace MarioPicrossRipper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeElements();   //inits various bits of data used by this form
        }

        private void InitializeElements()
        {
            //init the index text box to the index bar's value
            indexTextBox.Text = puzzleIndexBar.Value.ToString();

            //init the open ROM dialog to its constant data
            openRomDialog.Filter = "Gameboy ROMS (*.gb)|*.gb";
            openRomDialog.Title = "Select Mario Picross ROM";
            openRomDialog.FilterIndex = 0;
            openRomDialog.RestoreDirectory = true;
            openRomDialog.FileName = "";

            //init the save single bitmap dialog to its constant data
            saveSingleBitmapDialog.Filter = "PNG Files (*.png)|*.png";
            saveSingleBitmapDialog.Title = "Save Current Puzzle Image";
            saveSingleBitmapDialog.FilterIndex = 0;
            saveSingleBitmapDialog.RestoreDirectory = true;
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
                    MessageBox.Show(ex.Message);
                }

                offset += 32;
            }

            DrawThePuzzle();
            exportCurrentPuzzleButton.Enabled = true;
            exportAllPuzzlesButton.Enabled = true;
        }

        private void OpenRomButtonClick(object sender, EventArgs e)
        {
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
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExportCurrentPuzzleButtonClick(object sender, EventArgs e)
        {
            saveSingleBitmapDialog.FileName = puzzleIndexBar.Value.ToString() + ".png";

            saveSingleBitmapDialog.ShowDialog();
        }

        private void SaveSingleBitmapDialogOk(object sender, CancelEventArgs e)
        {
            SaveSingleBitmap(puzzleImageBox.Image, saveSingleBitmapDialog.FileName);
        }

        private void ExportAllPuzzlesButtonClick(object sender, EventArgs e)
        {
            DialogResult result = saveAllBitmapsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ExportAllBitmaps(saveAllBitmapsDialog.SelectedPath);
            }
        }

        private void saveAllBitmapsDialog_HelpRequest(object sender, EventArgs e)
        {
            ExportAllBitmaps(saveAllBitmapsDialog.SelectedPath);
        }

        private void SaveSingleBitmap(System.Drawing.Image img, string fileName)
        {
            //just in case the file name doesn't have the *.png extension
            if (!fileName.Contains(".png"))
            {
                fileName = fileName + ".png";
            }

            img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void ExportAllBitmaps(string folderPath)
        {
            PuzzleDrawer draw = new PuzzleDrawer();

            for (int index = 0; index < Program.puzzles.Count; index++)
            {
                var img = draw.PuzzleToBitmap(Program.puzzles[index]);
                SaveSingleBitmap(img, folderPath + "/" + index.ToString() + ".png");
            }
        }
        
    }
}
