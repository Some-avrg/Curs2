namespace Sudoku
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
            this.SuspendLayout();
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(520, 12);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(75, 23);
            this.CheckButton.TabIndex = 0;
            this.CheckButton.Text = "Проверить";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // ExitToMenuButton
            // 
            this.ExitToMenuButton.Location = new System.Drawing.Point(520, 66);
            this.ExitToMenuButton.Name = "ExitToMenuButton";
            this.ExitToMenuButton.Size = new System.Drawing.Size(74, 24);
            this.ExitToMenuButton.TabIndex = 1;
            this.ExitToMenuButton.Text = "Выход";
            this.ExitToMenuButton.UseVisualStyleBackColor = true;
            this.ExitToMenuButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(475, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 38);
            this.label1.TabIndex = 2;
            // 
            // NoteButton
            // 
            this.NoteButton.Location = new System.Drawing.Point(520, 123);
            this.NoteButton.Name = "NoteButton";
            this.NoteButton.Size = new System.Drawing.Size(73, 41);
            this.NoteButton.TabIndex = 3;
            this.NoteButton.Text = "add/remove note";
            this.NoteButton.UseVisualStyleBackColor = true;
            this.NoteButton.Click += new System.EventHandler(this.NoteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 450);
            this.Controls.Add(this.NoteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitToMenuButton);
            this.Controls.Add(this.CheckButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button NoteButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button ExitToMenuButton;

        #endregion

        private System.Windows.Forms.Button CheckButton;
    }
}