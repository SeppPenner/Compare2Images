using System;
using System.Drawing;
using System.Windows.Forms;

namespace howto_compare_images
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadTitleAndDescription();
        }

        private void LoadTitleAndDescription()
        {
            Text = Application.ProductName + @" " + Application.ProductVersion;
        }

        private void ButtonFile1_Click(object sender, EventArgs e)
        {
            DialogSelectFile.FileName = TextFile1.Text;
            if (DialogSelectFile.ShowDialog() != DialogResult.OK) return;
            TextFile1.Text = DialogSelectFile.FileName;
            LabelResult.Text = "";
            try
            {
                var bm = new Bitmap(TextFile1.Text);
                Image1.Image = (Bitmap) bm.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ButtonGo.Enabled = Image1.Image != null &&
                               Image2.Image != null;
        }

        private void ButtonFile2_Click(object sender, EventArgs e)
        {
            DialogSelectFile.FileName = TextFile2.Text;
            if (DialogSelectFile.ShowDialog() != DialogResult.OK) return;
            TextFile2.Text = DialogSelectFile.FileName;
            LabelResult.Text = "";
            try
            {
                var bm = new Bitmap(TextFile2.Text);
                Image2.Image = (Bitmap) bm.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ButtonGo.Enabled = Image1.Image != null &&
                               Image2.Image != null;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Load the images.
            var bm1 = (Bitmap) Image1.Image;
            var bm2 = (Bitmap) Image2.Image;

            // Make a difference image.
            var wid = Math.Min(bm1.Width, bm2.Width);
            var hgt = Math.Min(bm1.Height, bm2.Height);
            var bm3 = new Bitmap(wid, hgt);

            // Create the difference image.
            var areIdentical = true;
            var eqColor = Color.White;
            var neColor = Color.Red;
            for (var x = 0; x < wid; x++)
            for (var y = 0; y < hgt; y++)
                if (bm1.GetPixel(x, y).Equals(bm2.GetPixel(x, y)))
                {
                    bm3.SetPixel(x, y, eqColor);
                }
                else
                {
                    bm3.SetPixel(x, y, neColor);
                    areIdentical = false;
                }

            // Display the result.
            ImageResult.Image = bm3;

            Cursor = Cursors.Default;
            if (bm1.Width != bm2.Width || bm1.Height != bm2.Height) areIdentical = false;
            LabelResult.Text = areIdentical ? "The images are identical" : "The images are different";
        }
    }
}