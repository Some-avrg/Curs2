using System.ComponentModel;

namespace Curse_2_1
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(121, 41);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(122, 37);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // RecordsButton
            // 
            this.RecordsButton.Location = new System.Drawing.Point(121, 122);
            this.RecordsButton.Name = "RecordsButton";
            this.RecordsButton.Size = new System.Drawing.Size(122, 38);
            this.RecordsButton.TabIndex = 1;
            this.RecordsButton.Text = "Records";
            this.RecordsButton.UseVisualStyleBackColor = true;
            this.RecordsButton.Click += new System.EventHandler(this.ViewRecords);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExitProgram);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(355, 298);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RecordsButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button RecordsButton;

        #endregion
    }
}