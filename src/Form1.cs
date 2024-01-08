using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MarioPicrossRipper
{
    public partial class MainForm : Form
    {

        const string referenceHash = "E5B6B21E9344E5CD87CFA1EBB89546351D9ACE88";    //the hash of all the bytes before the puzzle data in ROM

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

            byte[] refData;
            try
            {
                refData = GetReferenceDataFromROM(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return; //not sure if needed but whatever
            }

            if(GetHash(refData) == referenceHash)
            {
                Program.puzzles.Clear();

                int offset = 0x92b0;    //this is where in the file the puzzles begin
                                        //last one is at 0xb2b0

                for (int puzzleIndex = 0; puzzleIndex < 257; puzzleIndex++)
                {
                    byte[] data = new byte[32];

                    for (int i = 0; i < 32; i++)
                    {
                        data[i] = (byte)(buffer[offset + i]);
                    }

                    try
                    {
                        Program.puzzles.Add(new Picross(data));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    offset += 32;
                }

                DrawThePuzzle();
                exportCurrentPuzzleButton.Enabled = true;
                exportAllPuzzlesButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid ROM!\nMake sure the correct ROM was selected,\nor that your ROM isn't corrupt!\nIf you see this with a clean ROM, report it on GitHub.");
            }
            
        }

        /// <summary>
        /// Takes the ROM as a byte array and gets only the bytes needed for integrity verification.
        /// </summary>
        private byte[] GetReferenceDataFromROM(byte[] rom)
        {
            //There are 37,552 bytes before the puzzle data
            //We only need to check these bytes as the puzzle decoder skips any puzzle that has invalid data.
            byte[] output = new byte[37552];

            if(rom.Length >= output.Length)
            {
                for(int i = 0; i< output.Length; i++)
                {
                    output[i] = (byte)(rom[i] & 0xFF);
                }
            }
            else
            {
                throw new Exception("ROM is smaller than expected size!");
            }

            return output;
        }

        private string GetHash(byte[] data)
        {
            using(HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider())
            {
                byte[] hashBytes = hashAlgorithm.ComputeHash(data);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
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
