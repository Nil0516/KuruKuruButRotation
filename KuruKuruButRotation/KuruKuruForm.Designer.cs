﻿namespace KuruKuruButRotation
{
    partial class KuruKuruForm
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
            this.mainImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mainImage
            // 
            this.mainImage.Image = global::KuruKuruButRotation.Properties.Resources.kuru;
            this.mainImage.Location = new System.Drawing.Point(-1, 0);
            this.mainImage.Name = "mainImage";
            this.mainImage.Size = new System.Drawing.Size(403, 336);
            this.mainImage.TabIndex = 1;
            this.mainImage.TabStop = false;
            this.mainImage.Click += new System.EventHandler(this.mainImage_Click);
            // 
            // KuruKuruForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 332);
            this.Controls.Add(this.mainImage);
            this.Name = "KuruKuruForm";
            this.Text = "KuruKuruForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KuruKuruForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox mainImage;
    }
}