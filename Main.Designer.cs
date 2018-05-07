namespace Compare2Images
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ButtonFile2 = new System.Windows.Forms.Button();
            this.LabelFile2 = new System.Windows.Forms.Label();
            this.ButtonFile1 = new System.Windows.Forms.Button();
            this.LabelFile1 = new System.Windows.Forms.Label();
            this.TextFile1 = new System.Windows.Forms.TextBox();
            this.DialogSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.TextFile2 = new System.Windows.Forms.TextBox();
            this.ButtonGo = new System.Windows.Forms.Button();
            this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanelRowOne = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanelRowTwo = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanelRowThree = new System.Windows.Forms.TableLayoutPanel();
            this.ImageResult = new System.Windows.Forms.PictureBox();
            this.Image2 = new System.Windows.Forms.PictureBox();
            this.Image1 = new System.Windows.Forms.PictureBox();
            this.LabelResult = new System.Windows.Forms.Label();
            this.TableLayoutPanelMain.SuspendLayout();
            this.TableLayoutPanelRowOne.SuspendLayout();
            this.TableLayoutPanelRowTwo.SuspendLayout();
            this.TableLayoutPanelRowThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonFile2
            // 
            this.ButtonFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFile2.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFile2.Image")));
            this.ButtonFile2.Location = new System.Drawing.Point(464, 3);
            this.ButtonFile2.Name = "ButtonFile2";
            this.ButtonFile2.Size = new System.Drawing.Size(24, 18);
            this.ButtonFile2.TabIndex = 3;
            this.ButtonFile2.UseVisualStyleBackColor = false;
            this.ButtonFile2.Click += new System.EventHandler(this.ButtonFile2_Click);
            // 
            // LabelFile2
            // 
            this.LabelFile2.AutoSize = true;
            this.LabelFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelFile2.Location = new System.Drawing.Point(3, 0);
            this.LabelFile2.Name = "LabelFile2";
            this.LabelFile2.Size = new System.Drawing.Size(44, 24);
            this.LabelFile2.TabIndex = 14;
            this.LabelFile2.Text = "File 2";
            // 
            // ButtonFile1
            // 
            this.ButtonFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFile1.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFile1.Image")));
            this.ButtonFile1.Location = new System.Drawing.Point(464, 3);
            this.ButtonFile1.Name = "ButtonFile1";
            this.ButtonFile1.Size = new System.Drawing.Size(24, 18);
            this.ButtonFile1.TabIndex = 1;
            this.ButtonFile1.UseVisualStyleBackColor = false;
            this.ButtonFile1.Click += new System.EventHandler(this.ButtonFile1_Click);
            // 
            // LabelFile1
            // 
            this.LabelFile1.AutoSize = true;
            this.LabelFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelFile1.Location = new System.Drawing.Point(3, 0);
            this.LabelFile1.Name = "LabelFile1";
            this.LabelFile1.Size = new System.Drawing.Size(44, 24);
            this.LabelFile1.TabIndex = 9;
            this.LabelFile1.Text = "File 1";
            // 
            // TextFile1
            // 
            this.TextFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextFile1.Location = new System.Drawing.Point(53, 3);
            this.TextFile1.Name = "TextFile1";
            this.TextFile1.Size = new System.Drawing.Size(405, 20);
            this.TextFile1.TabIndex = 0;
            // 
            // DialogSelectFile
            // 
            this.DialogSelectFile.Filter = "Graphics Files|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif;*.tiff|All Files|*.*";
            this.DialogSelectFile.Title = "Select File";
            // 
            // TextFile2
            // 
            this.TextFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextFile2.Location = new System.Drawing.Point(53, 3);
            this.TextFile2.Name = "TextFile2";
            this.TextFile2.Size = new System.Drawing.Size(405, 20);
            this.TextFile2.TabIndex = 2;
            // 
            // ButtonGo
            // 
            this.ButtonGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonGo.Enabled = false;
            this.ButtonGo.Location = new System.Drawing.Point(3, 63);
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(491, 24);
            this.ButtonGo.TabIndex = 4;
            this.ButtonGo.Text = "Go";
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.ColumnCount = 1;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelRowOne, 0, 0);
            this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelRowTwo, 0, 1);
            this.TableLayoutPanelMain.Controls.Add(this.ButtonGo, 0, 2);
            this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelRowThree, 0, 3);
            this.TableLayoutPanelMain.Controls.Add(this.LabelResult, 0, 4);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 5;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelMain.Size = new System.Drawing.Size(497, 358);
            this.TableLayoutPanelMain.TabIndex = 18;
            // 
            // TableLayoutPanelRowOne
            // 
            this.TableLayoutPanelRowOne.ColumnCount = 3;
            this.TableLayoutPanelRowOne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanelRowOne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelRowOne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelRowOne.Controls.Add(this.LabelFile1, 0, 0);
            this.TableLayoutPanelRowOne.Controls.Add(this.ButtonFile1, 2, 0);
            this.TableLayoutPanelRowOne.Controls.Add(this.TextFile1, 1, 0);
            this.TableLayoutPanelRowOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelRowOne.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanelRowOne.Name = "TableLayoutPanelRowOne";
            this.TableLayoutPanelRowOne.RowCount = 1;
            this.TableLayoutPanelRowOne.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelRowOne.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelRowOne.Size = new System.Drawing.Size(491, 24);
            this.TableLayoutPanelRowOne.TabIndex = 3;
            // 
            // TableLayoutPanelRowTwo
            // 
            this.TableLayoutPanelRowTwo.ColumnCount = 3;
            this.TableLayoutPanelRowTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanelRowTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelRowTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelRowTwo.Controls.Add(this.LabelFile2, 0, 0);
            this.TableLayoutPanelRowTwo.Controls.Add(this.ButtonFile2, 2, 0);
            this.TableLayoutPanelRowTwo.Controls.Add(this.TextFile2, 1, 0);
            this.TableLayoutPanelRowTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelRowTwo.Location = new System.Drawing.Point(3, 33);
            this.TableLayoutPanelRowTwo.Name = "TableLayoutPanelRowTwo";
            this.TableLayoutPanelRowTwo.RowCount = 1;
            this.TableLayoutPanelRowTwo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelRowTwo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayoutPanelRowTwo.Size = new System.Drawing.Size(491, 24);
            this.TableLayoutPanelRowTwo.TabIndex = 16;
            // 
            // TableLayoutPanelRowThree
            // 
            this.TableLayoutPanelRowThree.ColumnCount = 3;
            this.TableLayoutPanelRowThree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelRowThree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelRowThree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelRowThree.Controls.Add(this.ImageResult, 2, 0);
            this.TableLayoutPanelRowThree.Controls.Add(this.Image2, 1, 0);
            this.TableLayoutPanelRowThree.Controls.Add(this.Image1, 0, 0);
            this.TableLayoutPanelRowThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelRowThree.Location = new System.Drawing.Point(3, 93);
            this.TableLayoutPanelRowThree.Name = "TableLayoutPanelRowThree";
            this.TableLayoutPanelRowThree.RowCount = 1;
            this.TableLayoutPanelRowThree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelRowThree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.TableLayoutPanelRowThree.Size = new System.Drawing.Size(491, 232);
            this.TableLayoutPanelRowThree.TabIndex = 17;
            // 
            // ImageResult
            // 
            this.ImageResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageResult.Location = new System.Drawing.Point(329, 3);
            this.ImageResult.Name = "ImageResult";
            this.ImageResult.Size = new System.Drawing.Size(159, 226);
            this.ImageResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageResult.TabIndex = 0;
            this.ImageResult.TabStop = false;
            // 
            // Image2
            // 
            this.Image2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image2.Location = new System.Drawing.Point(166, 3);
            this.Image2.Name = "Image2";
            this.Image2.Size = new System.Drawing.Size(157, 226);
            this.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Image2.TabIndex = 2;
            this.Image2.TabStop = false;
            // 
            // Image1
            // 
            this.Image1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Image1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image1.Location = new System.Drawing.Point(3, 3);
            this.Image1.Name = "Image1";
            this.Image1.Size = new System.Drawing.Size(157, 226);
            this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Image1.TabIndex = 1;
            this.Image1.TabStop = false;
            // 
            // LabelResult
            // 
            this.LabelResult.AutoSize = true;
            this.LabelResult.Location = new System.Drawing.Point(3, 328);
            this.LabelResult.Name = "LabelResult";
            this.LabelResult.Size = new System.Drawing.Size(0, 13);
            this.LabelResult.TabIndex = 18;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 358);
            this.Controls.Add(this.TableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.TableLayoutPanelMain.ResumeLayout(false);
            this.TableLayoutPanelMain.PerformLayout();
            this.TableLayoutPanelRowOne.ResumeLayout(false);
            this.TableLayoutPanelRowOne.PerformLayout();
            this.TableLayoutPanelRowTwo.ResumeLayout(false);
            this.TableLayoutPanelRowTwo.PerformLayout();
            this.TableLayoutPanelRowThree.ResumeLayout(false);
            this.TableLayoutPanelRowThree.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonFile2;
        internal System.Windows.Forms.Label LabelFile2;
        internal System.Windows.Forms.Button ButtonFile1;
        internal System.Windows.Forms.Label LabelFile1;
        internal System.Windows.Forms.TextBox TextFile1;
        internal System.Windows.Forms.OpenFileDialog DialogSelectFile;
        internal System.Windows.Forms.TextBox TextFile2;
        internal System.Windows.Forms.Button ButtonGo;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelRowOne;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelRowTwo;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelRowThree;
        internal System.Windows.Forms.PictureBox ImageResult;
        internal System.Windows.Forms.PictureBox Image2;
        internal System.Windows.Forms.PictureBox Image1;
        private System.Windows.Forms.Label LabelResult;
    }
}

