using switch_my_shell.Properties;

namespace switch_my_shell
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            customShell = new RadioButton();
            defaultShell = new RadioButton();
            button1 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MidnightBlue;
            label1.ImageAlign = ContentAlignment.BottomRight;
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 0;
            label1.Text = "Switch my shell";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 50);
            label2.Name = "label2";
            label2.Size = new Size(451, 30);
            label2.TabIndex = 1;
            label2.Text = "Select which shell you want to use. Your desktop and taskbar will disappear for a few\r\nseconds during this process.";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // customShell
            // 
            customShell.AutoSize = true;
            customShell.Location = new Point(28, 93);
            customShell.Name = "customShell";
            customShell.Size = new Size(94, 19);
            customShell.TabIndex = 5;
            customShell.TabStop = true;
            customShell.Text = "Custom shell";
            customShell.UseVisualStyleBackColor = true;
            customShell.CheckedChanged += customShell_CheckedChanged;
            // 
            // defaultShell
            // 
            defaultShell.AutoSize = true;
            defaultShell.Location = new Point(28, 118);
            defaultShell.Name = "defaultShell";
            defaultShell.Size = new Size(142, 19);
            defaultShell.TabIndex = 6;
            defaultShell.TabStop = true;
            defaultShell.Text = "Default Windows shell";
            defaultShell.UseVisualStyleBackColor = true;
            defaultShell.CheckedChanged += defaultShell_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(423, 15);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(button1);
            panel1.Location = new Point(-8, 154);
            panel1.Name = "panel1";
            panel1.Size = new Size(539, 123);
            panel1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(502, 206);
            Controls.Add(defaultShell);
            Controls.Add(customShell);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "Switch shell";
            Icon = Properties.Resources.Icon;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private RadioButton customShell;
        private RadioButton defaultShell;
        private Button button1;
        private Panel panel1;
    }
}