// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Compare2Images;

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
        var image = this.LoadImage(this.TextFile1.Text);

        if (image is not null)
        {
            this.Image1.Image?.Dispose();
            this.Image1.Image = image;
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
        var image = this.LoadImage(this.TextFile2.Text);

        if (image is not null)
        {
            this.Image2.Image?.Dispose();
            this.Image2.Image = image;
        }

        this.ButtonGo.Enabled = this.Image1.Image != null && this.Image2.Image != null;
    }

    /// <summary>
    /// Loads the image from the given file.
    /// </summary>
    /// <param name="fileName">The name of the file to load.</param>
    /// <returns>The loaded image or <c>null</c> if the file could not be read.</returns>
    private Bitmap? LoadImage(string fileName)
    {
        try
        {
            // A bitmap created from a file path keeps that file locked for as long as it exists,
            // and a clone of it keeps the lock as well. Copying the bitmap gives an independent
            // image, so the file is released as soon as the temporary bitmap is disposed.
            using var fileImage = new Bitmap(fileName);
            return new Bitmap(fileImage);
        }
        catch (Exception ex)
        {
            var text = $"{ex.Message}{Environment.NewLine}{Environment.NewLine}{ex.StackTrace}";
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
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

        try
        {
            // Load the images.
            var bm1 = (Bitmap?)this.Image1.Image;
            var bm2 = (Bitmap?)this.Image2.Image;

            if (bm1 is null || bm2 is null)
            {
                return;
            }

            // Make a difference image.
            var width = Math.Min(bm1.Width, bm2.Width);
            var height = Math.Min(bm1.Height, bm2.Height);
            var bm3 = new Bitmap(width, height);

            // Create the difference image.
            var areIdentical = true;
            var equalColor = Color.White;
            var notEqualColor = Color.Red;

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
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
            this.ImageResult.Image?.Dispose();
            this.ImageResult.Image = bm3;

            if (bm1.Width != bm2.Width || bm1.Height != bm2.Height)
            {
                areIdentical = false;
            }

            this.LabelResult.Text = areIdentical ? "The images are identical" : "The images are different";
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }
    }
}
