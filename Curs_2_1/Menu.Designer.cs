using System.ComponentModel;

namespace Sudoku
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.StartButton = new System.Windows.Forms.Button();
            this.RecordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(121, 54);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(123, 37);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // RecordsButton
            // 
            this.RecordsButton.Location = new System.Drawing.Point(121, 144);
            this.RecordsButton.Name = "RecordsButton";
            this.RecordsButton.Size = new System.Drawing.Size(122, 38);
            this.RecordsButton.TabIndex = 1;
            this.RecordsButton.Text = "Records";
            this.RecordsButton.UseVisualStyleBackColor = true;
            this.RecordsButton.Click += new System.EventHandler(this.ViewRecords);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 298);
            this.Controls.Add(this.RecordsButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button RecordsButton;

        #endregion
    }
}