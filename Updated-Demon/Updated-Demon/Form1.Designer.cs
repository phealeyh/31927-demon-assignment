﻿namespace Updated_Demon
{
    partial class demonPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(demonPanel));
            this.seedLabel = new System.Windows.Forms.Label();
            this.genLabel = new System.Windows.Forms.Label();
            this.rulesLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rulesCombo = new System.Windows.Forms.ComboBox();
            this.colorCombo = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // seedLabel
            // 
            resources.ApplyResources(this.seedLabel, "seedLabel");
            this.seedLabel.Name = "seedLabel";
            // 
            // genLabel
            // 
            resources.ApplyResources(this.genLabel, "genLabel");
            this.genLabel.Name = "genLabel";
            // 
            // rulesLabel
            // 
            resources.ApplyResources(this.rulesLabel, "rulesLabel");
            this.rulesLabel.Name = "rulesLabel";
            // 
            // colorLabel
            // 
            resources.ApplyResources(this.colorLabel, "colorLabel");
            this.colorLabel.Name = "colorLabel";
            // 
            // seedTextBox
            // 
            resources.ApplyResources(this.seedTextBox, "seedTextBox");
            this.seedTextBox.Name = "seedTextBox";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // rulesCombo
            // 
            this.rulesCombo.FormattingEnabled = true;
            resources.ApplyResources(this.rulesCombo, "rulesCombo");
            this.rulesCombo.Name = "rulesCombo";
            // 
            // colorCombo
            // 
            this.colorCombo.FormattingEnabled = true;
            resources.ApplyResources(this.colorCombo, "colorCombo");
            this.colorCombo.Name = "colorCombo";
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // demonPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.colorCombo);
            this.Controls.Add(this.rulesCombo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.seedTextBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.rulesLabel);
            this.Controls.Add(this.genLabel);
            this.Controls.Add(this.seedLabel);
            this.Name = "demonPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Label genLabel;
        private System.Windows.Forms.Label rulesLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox rulesCombo;
        private System.Windows.Forms.ComboBox colorCombo;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel panel1;
    }
}

