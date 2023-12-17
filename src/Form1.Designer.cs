namespace MarioPicrossRipper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openRomDialog = new System.Windows.Forms.OpenFileDialog();
            this.openRomButton = new System.Windows.Forms.Button();
            this.puzzleIndexBar = new System.Windows.Forms.TrackBar();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.exportCurrentPuzzleButton = new System.Windows.Forms.Button();
            this.saveSingleBitmapDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAllBitmapsDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.exportAllPuzzlesButton = new System.Windows.Forms.Button();
            this.puzzleImageBox = new MarioPicrossRipper.PixelPerfectPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.puzzleIndexBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puzzleImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openRomDialog
            // 
            this.openRomDialog.FileName = "openRomDialog";
            this.openRomDialog.Title = "Open ROM";
            this.openRomDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenRomDialogOk);
            // 
            // openRomButton
            // 
            this.openRomButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.openRomButton.Location = new System.Drawing.Point(425, 74);
            this.openRomButton.Margin = new System.Windows.Forms.Padding(2);
            this.openRomButton.Name = "openRomButton";
            this.openRomButton.Size = new System.Drawing.Size(117, 37);
            this.openRomButton.TabIndex = 0;
            this.openRomButton.Text = "Open ROM";
            this.openRomButton.UseVisualStyleBackColor = true;
            this.openRomButton.Click += new System.EventHandler(this.OpenRomButtonClick);
            // 
            // puzzleIndexBar
            // 
            this.puzzleIndexBar.Location = new System.Drawing.Point(321, 156);
            this.puzzleIndexBar.Margin = new System.Windows.Forms.Padding(2);
            this.puzzleIndexBar.Maximum = 256;
            this.puzzleIndexBar.Name = "puzzleIndexBar";
            this.puzzleIndexBar.Size = new System.Drawing.Size(303, 56);
            this.puzzleIndexBar.TabIndex = 6;
            this.puzzleIndexBar.Scroll += new System.EventHandler(this.PuzzleIndexBarScroll);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(321, 133);
            this.indexTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.ReadOnly = true;
            this.indexTextBox.Size = new System.Drawing.Size(74, 22);
            this.indexTextBox.TabIndex = 7;
            // 
            // exportCurrentPuzzleButton
            // 
            this.exportCurrentPuzzleButton.Enabled = false;
            this.exportCurrentPuzzleButton.Location = new System.Drawing.Point(363, 217);
            this.exportCurrentPuzzleButton.Name = "exportCurrentPuzzleButton";
            this.exportCurrentPuzzleButton.Size = new System.Drawing.Size(117, 49);
            this.exportCurrentPuzzleButton.TabIndex = 8;
            this.exportCurrentPuzzleButton.Text = "Export Current Puzzle";
            this.exportCurrentPuzzleButton.UseVisualStyleBackColor = true;
            this.exportCurrentPuzzleButton.Click += new System.EventHandler(this.ExportCurrentPuzzleButtonClick);
            // 
            // saveSingleBitmapDialog
            // 
            this.saveSingleBitmapDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveSingleBitmapDialogOk);
            // 
            // saveAllBitmapsDialog
            // 
            this.saveAllBitmapsDialog.HelpRequest += new System.EventHandler(this.saveAllBitmapsDialog_HelpRequest);
            // 
            // exportAllPuzzlesButton
            // 
            this.exportAllPuzzlesButton.Enabled = false;
            this.exportAllPuzzlesButton.Location = new System.Drawing.Point(486, 217);
            this.exportAllPuzzlesButton.Name = "exportAllPuzzlesButton";
            this.exportAllPuzzlesButton.Size = new System.Drawing.Size(117, 49);
            this.exportAllPuzzlesButton.TabIndex = 9;
            this.exportAllPuzzlesButton.Text = "Export All Puzzles";
            this.exportAllPuzzlesButton.UseVisualStyleBackColor = true;
            this.exportAllPuzzlesButton.Click += new System.EventHandler(this.ExportAllPuzzlesButtonClick);
            // 
            // puzzleImageBox
            // 
            this.puzzleImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.puzzleImageBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.puzzleImageBox.Location = new System.Drawing.Point(11, 11);
            this.puzzleImageBox.Margin = new System.Windows.Forms.Padding(2);
            this.puzzleImageBox.Name = "puzzleImageBox";
            this.puzzleImageBox.OffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            this.puzzleImageBox.Size = new System.Drawing.Size(300, 300);
            this.puzzleImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.puzzleImageBox.TabIndex = 1;
            this.puzzleImageBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 323);
            this.Controls.Add(this.exportAllPuzzlesButton);
            this.Controls.Add(this.exportCurrentPuzzleButton);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.puzzleIndexBar);
            this.Controls.Add(this.puzzleImageBox);
            this.Controls.Add(this.openRomButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mario\'s Picross Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.puzzleIndexBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puzzleImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openRomDialog;
        private System.Windows.Forms.Button openRomButton;
        private PixelPerfectPictureBox puzzleImageBox;
        private System.Windows.Forms.TrackBar puzzleIndexBar;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.Button exportCurrentPuzzleButton;
        private System.Windows.Forms.SaveFileDialog saveSingleBitmapDialog;
        private System.Windows.Forms.FolderBrowserDialog saveAllBitmapsDialog;
        private System.Windows.Forms.Button exportAllPuzzlesButton;
    }
}

