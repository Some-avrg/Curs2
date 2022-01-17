namespace Curse_2_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckButton = new System.Windows.Forms.Button();
            this.ExitToMenuButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NoteButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(506, 12);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(89, 37);
            this.CheckButton.TabIndex = 0;
            this.CheckButton.Text = "Check the solution";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // ExitToMenuButton
            // 
            this.ExitToMenuButton.Location = new System.Drawing.Point(506, 414);
            this.ExitToMenuButton.Name = "ExitToMenuButton";
            this.ExitToMenuButton.Size = new System.Drawing.Size(89, 24);
            this.ExitToMenuButton.TabIndex = 1;
            this.ExitToMenuButton.Text = "Exit";
            this.ExitToMenuButton.UseVisualStyleBackColor = true;
            this.ExitToMenuButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(495, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 38);
            this.label1.TabIndex = 2;
            // 
            // NoteButton
            // 
            this.NoteButton.Location = new System.Drawing.Point(508, 113);
            this.NoteButton.Name = "NoteButton";
            this.NoteButton.Size = new System.Drawing.Size(87, 41);
            this.NoteButton.TabIndex = 3;
            this.NoteButton.Text = "Add/Remove note";
            this.NoteButton.UseVisualStyleBackColor = true;
            this.NoteButton.Click += new System.EventHandler(this.NoteButton_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.Location = new System.Drawing.Point(473, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Time past:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(605, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitToMenuButton);
            this.Controls.Add(this.CheckButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button NoteButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button ExitToMenuButton;

        #endregion

        private System.Windows.Forms.Button CheckButton;
    }
}