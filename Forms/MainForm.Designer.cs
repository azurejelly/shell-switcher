using switch_my_shell.Properties;

namespace switch_my_shell
{
    partial class MainForm
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
            title = new Label();
            description = new Label();
            customShell = new RadioButton();
            defaultShell = new RadioButton();
            apply = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.FlatStyle = FlatStyle.System;
            title.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title.ForeColor = Color.FromArgb(0, 50, 153);
            title.ImageAlign = ContentAlignment.BottomRight;
            title.Location = new Point(28, 19);
            title.Name = "title";
            title.Size = new Size(118, 21);
            title.TabIndex = 0;
            title.Text = "Switch my shell";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Location = new Point(25, 50);
            description.Name = "description";
            description.Size = new Size(451, 30);
            description.TabIndex = 1;
            description.Text = "Select which shell you want to use. Your desktop and taskbar will disappear for a few\r\nseconds during this process.";
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
            // apply
            // 
            apply.Location = new Point(423, 14);
            apply.Name = "apply";
            apply.Size = new Size(75, 23);
            apply.TabIndex = 7;
            apply.Text = "Apply";
            apply.UseVisualStyleBackColor = true;
            apply.Click += apply_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(apply);
            panel1.Location = new Point(-8, 157);
            panel1.Name = "panel1";
            panel1.Size = new Size(539, 120);
            panel1.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(502, 206);
            Controls.Add(defaultShell);
            Controls.Add(customShell);
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = Resources.Icon;
            Name = "MainForm";
            Text = "Switch shell";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label description;
        private RadioButton customShell;
        private RadioButton defaultShell;
        private Button apply;
        private Panel panel1;
    }
}