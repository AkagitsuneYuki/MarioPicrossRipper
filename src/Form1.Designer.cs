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
            this.openRomDialog = new System.Windows.Forms.OpenFileDialog();
            this.openRomButton = new System.Windows.Forms.Button();
            this.puzzleIndexBar = new System.Windows.Forms.TrackBar();
            this.indexTextBox = new System.Windows.Forms.TextBox();
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
            this.ClientSize = new System.Drawing.Size(645, 322);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.puzzleIndexBar);
            this.Controls.Add(this.puzzleImageBox);
            this.Controls.Add(this.openRomButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}

