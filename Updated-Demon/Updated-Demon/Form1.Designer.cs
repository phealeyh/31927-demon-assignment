namespace Updated_Demon
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
            this.generationTextBox = new System.Windows.Forms.TextBox();
            this.rulesCombo = new System.Windows.Forms.ComboBox();
            this.colorCombo = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.demonPanel1 = new System.Windows.Forms.Panel();
            this.generationCountLabel = new System.Windows.Forms.Label();
            this.hashLabel = new System.Windows.Forms.Label();
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
            this.seedTextBox.TextChanged += new System.EventHandler(this.seedTextBox_TextChanged);
            // 
            // generationTextBox
            // 
            resources.ApplyResources(this.generationTextBox, "generationTextBox");
            this.generationTextBox.Name = "generationTextBox";
            this.generationTextBox.TextChanged += new System.EventHandler(this.generationTextBox_TextChanged);
            // 
            // rulesCombo
            // 
            this.rulesCombo.FormattingEnabled = true;
            resources.ApplyResources(this.rulesCombo, "rulesCombo");
            this.rulesCombo.Name = "rulesCombo";
            this.rulesCombo.SelectedIndexChanged += new System.EventHandler(this.rulesCombo_SelectedIndexChanged);
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
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // startButton
            // 
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // demonPanel1
            // 
            resources.ApplyResources(this.demonPanel1, "demonPanel1");
            this.demonPanel1.Name = "demonPanel1";
            this.demonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.demonPanel1_Paint);
            // 
            // generationCountLabel
            // 
            resources.ApplyResources(this.generationCountLabel, "generationCountLabel");
            this.generationCountLabel.Name = "generationCountLabel";
            // 
            // hashLabel
            // 
            resources.ApplyResources(this.hashLabel, "hashLabel");
            this.hashLabel.Name = "hashLabel";
            // 
            // demonPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hashLabel);
            this.Controls.Add(this.generationCountLabel);
            this.Controls.Add(this.demonPanel1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.colorCombo);
            this.Controls.Add(this.rulesCombo);
            this.Controls.Add(this.generationTextBox);
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
        private System.Windows.Forms.TextBox generationTextBox;
        private System.Windows.Forms.ComboBox rulesCombo;
        private System.Windows.Forms.ComboBox colorCombo;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel demonPanel1;
        private System.Windows.Forms.Label generationCountLabel;
        private System.Windows.Forms.Label hashLabel;
    }
}

