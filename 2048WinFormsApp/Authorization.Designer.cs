﻿namespace _2048WinFormsApp
{
    partial class Authorization
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
            buttonLogin = new Button();
            textBoxName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(12, 41);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(360, 23);
            buttonLogin.TabIndex = 0;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(49, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(322, 23);
            textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Имя";
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 75);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(buttonLogin);
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogin;
        public TextBox textBoxName;
        private Label label1;
    }
}