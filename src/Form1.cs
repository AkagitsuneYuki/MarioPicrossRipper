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
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            byte[] buffer = File.ReadAllBytes(openFileDialog1.FileName);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Gameboy ROMS (*.gb)|*.gb";
            openFileDialog1.Title = "Select Mario Picross ROM";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";

            openFileDialog1.ShowDialog();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            DrawThePuzzle();
        }

        private void DrawThePuzzle()
        {
            if(Program.puzzles.Count != 0)
            {
                int puzzleToDraw = trackBar1.Value;

                PuzzleDrawer draw = new PuzzleDrawer();
                try
                {
                    pictureBox1.Image = draw.PuzzleToBitmap(Program.puzzles[puzzleToDraw]);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
