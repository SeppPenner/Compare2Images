// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Compare2Images
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// The main form.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.InitializeComponent();
            this.LoadTitleAndDescription();
        }

        /// <summary>
        /// Loads the title and description.
        /// </summary>
        private void LoadTitleAndDescription()
        {
            this.Text = $@"{Application.ProductName} {Application.ProductVersion}";
        }

        /// <summary>
        /// Handles the call to the button to open the first file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonFirstFileClick(object sender, EventArgs e)
        {
            this.DialogSelectFile.FileName = this.TextFile1.Text;

            if (this.DialogSelectFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.TextFile1.Text = this.DialogSelectFile.FileName;
            this.LabelResult.Text = string.Empty;

            try
            {
                var bm = new Bitmap(this.TextFile1.Text);
                this.Image1.Image = (Bitmap)bm.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ButtonGo.Enabled = this.Image1.Image != null && this.Image2.Image != null;
        }

        /// <summary>
        /// Handles the call to the button to open the second file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonSecondFileClick(object sender, EventArgs e)
        {
            this.DialogSelectFile.FileName = this.TextFile2.Text;

            if (this.DialogSelectFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.TextFile2.Text = this.DialogSelectFile.FileName;
            this.LabelResult.Text = string.Empty;

            try
            {
                var bm = new Bitmap(this.TextFile2.Text);
                this.Image2.Image = (Bitmap)bm.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ButtonGo.Enabled = this.Image1.Image != null && this.Image2.Image != null;
        }

        /// <summary>
        /// Handles the call to the button click to run the comparison.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonGoClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Load the images.
            var bm1 = (Bitmap)this.Image1.Image;
            var bm2 = (Bitmap)this.Image2.Image;

            // Make a difference image.
            var wid = Math.Min(bm1.Width, bm2.Width);
            var hgt = Math.Min(bm1.Height, bm2.Height);
            var bm3 = new Bitmap(wid, hgt);

            // Create the difference image.
            var areIdentical = true;
            var equalColor = Color.White;
            var notEqualColor = Color.Red;

            for (var x = 0; x < wid; x++)
            {
                for (var y = 0; y < hgt; y++)
                {
                    if (bm1.GetPixel(x, y).Equals(bm2.GetPixel(x, y)))
                    {
                        bm3.SetPixel(x, y, equalColor);
                    }
                    else
                    {
                        bm3.SetPixel(x, y, notEqualColor);
                        areIdentical = false;
                    }
                }
            }

            // Display the result.
            this.ImageResult.Image = bm3;

            this.Cursor = Cursors.Default;
            if (bm1.Width != bm2.Width || bm1.Height != bm2.Height)
            {
                areIdentical = false;
            }

            this.LabelResult.Text = areIdentical ? "The images are identical" : "The images are different";
        }
    }
}