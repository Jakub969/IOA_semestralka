namespace cv1
{
    partial class EdgePropertiesForm
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
            labelLength = new Label();
            numericLength = new NumericUpDown();
            chkAutoCalculate = new CheckBox();
            chkEnabled = new CheckBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            labelAutoCalculate = new Label();
            labelEnabledEdge = new Label();
            ((System.ComponentModel.ISupportInitialize)numericLength).BeginInit();
            SuspendLayout();
            // 
            // labelLength
            // 
            labelLength.AutoSize = true;
            labelLength.Location = new Point(12, 23);
            labelLength.Name = "labelLength";
            labelLength.Size = new Size(88, 20);
            labelLength.TabIndex = 0;
            labelLength.Text = "Vzdialenosť";
            // 
            // numericLength
            // 
            numericLength.Location = new Point(200, 16);
            numericLength.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericLength.Name = "numericLength";
            numericLength.Size = new Size(150, 27);
            numericLength.TabIndex = 1;
            // 
            // chkAutoCalculate
            // 
            chkAutoCalculate.AutoSize = true;
            chkAutoCalculate.Location = new Point(249, 50);
            chkAutoCalculate.Name = "chkAutoCalculate";
            chkAutoCalculate.Size = new Size(101, 24);
            chkAutoCalculate.TabIndex = 2;
            chkAutoCalculate.Text = "checkBox1";
            chkAutoCalculate.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Location = new Point(249, 80);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(101, 24);
            chkEnabled.TabIndex = 3;
            chkEnabled.Text = "checkBox2";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 127);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(249, 127);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Zrušiť";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelAutoCalculate
            // 
            labelAutoCalculate.AutoSize = true;
            labelAutoCalculate.Location = new Point(12, 51);
            labelAutoCalculate.Name = "labelAutoCalculate";
            labelAutoCalculate.Size = new Size(231, 20);
            labelAutoCalculate.TabIndex = 6;
            labelAutoCalculate.Text = "Automatický výpočet vzdialenosti";
            // 
            // labelEnabledEdge
            // 
            labelEnabledEdge.AutoSize = true;
            labelEnabledEdge.Location = new Point(12, 80);
            labelEnabledEdge.Name = "labelEnabledEdge";
            labelEnabledEdge.Size = new Size(115, 20);
            labelEnabledEdge.TabIndex = 7;
            labelEnabledEdge.Text = "Hrana povolená";
            // 
            // EdgePropertiesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 171);
            Controls.Add(labelEnabledEdge);
            Controls.Add(labelAutoCalculate);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(chkEnabled);
            Controls.Add(chkAutoCalculate);
            Controls.Add(numericLength);
            Controls.Add(labelLength);
            Name = "EdgePropertiesForm";
            Text = "EdgePropertiesForm";
            ((System.ComponentModel.ISupportInitialize)numericLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLength;
        private NumericUpDown numericLength;
        private CheckBox chkAutoCalculate;
        private CheckBox chkEnabled;
        private Button buttonOK;
        private Button buttonCancel;
        private Label labelAutoCalculate;
        private Label labelEnabledEdge;
    }
}