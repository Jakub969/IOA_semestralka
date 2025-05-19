namespace cv1
{
    partial class NodePropertiesForm
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
            labelName = new Label();
            txtName = new TextBox();
            cmbNodeType = new ComboBox();
            labelType = new Label();
            numericCapacity = new NumericUpDown();
            labelCapacity = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCapacity).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 17);
            labelName.Name = "labelName";
            labelName.Size = new Size(51, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Názov";
            // 
            // txtName
            // 
            txtName.Location = new Point(165, 10);
            txtName.Name = "txtName";
            txtName.Size = new Size(151, 27);
            txtName.TabIndex = 1;
            // 
            // cmbNodeType
            // 
            cmbNodeType.FormattingEnabled = true;
            cmbNodeType.Location = new Point(164, 76);
            cmbNodeType.Name = "cmbNodeType";
            cmbNodeType.Size = new Size(151, 28);
            cmbNodeType.TabIndex = 2;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(11, 84);
            labelType.Name = "labelType";
            labelType.Size = new Size(63, 20);
            labelType.TabIndex = 3;
            labelType.Text = "Typ uzla";
            // 
            // numericCapacity
            // 
            numericCapacity.Location = new Point(165, 43);
            numericCapacity.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericCapacity.Name = "numericCapacity";
            numericCapacity.Size = new Size(150, 27);
            numericCapacity.TabIndex = 4;
            // 
            // labelCapacity
            // 
            labelCapacity.AutoSize = true;
            labelCapacity.Location = new Point(12, 50);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(147, 20);
            labelCapacity.TabIndex = 5;
            labelCapacity.Text = "Kapacita/Požiadavka";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(32, 125);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(198, 125);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Zrušiť";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // NodePropertiesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 177);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(labelCapacity);
            Controls.Add(numericCapacity);
            Controls.Add(labelType);
            Controls.Add(cmbNodeType);
            Controls.Add(txtName);
            Controls.Add(labelName);
            Name = "NodePropertiesForm";
            Text = "NodePropertiesForm";
            ((System.ComponentModel.ISupportInitialize)numericCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox txtName;
        private ComboBox cmbNodeType;
        private Label labelType;
        private NumericUpDown numericCapacity;
        private Label labelCapacity;
        private Button buttonOK;
        private Button buttonCancel;
    }
}