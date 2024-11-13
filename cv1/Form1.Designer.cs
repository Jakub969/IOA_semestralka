namespace cv1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTools = new Panel();
            label4 = new Label();
            textBoxShortestPath = new TextBox();
            buttonShortestPath = new Button();
            label3 = new Label();
            label2 = new Label();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            trackBarBackgroundTransparency = new TrackBar();
            groupBoxState = new GroupBox();
            radioButtonInsertEdge = new RadioButton();
            radioButtonInsertNode = new RadioButton();
            radioButtonEdit = new RadioButton();
            checkBoxBackgroundVisible = new CheckBox();
            doubleBufferPanelDrawing = new DoubleBufferPanel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundTransparency).BeginInit();
            groupBoxState.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTools
            // 
            panelTools.BackColor = SystemColors.AppWorkspace;
            panelTools.Controls.Add(label4);
            panelTools.Controls.Add(textBoxShortestPath);
            panelTools.Controls.Add(buttonShortestPath);
            panelTools.Controls.Add(label3);
            panelTools.Controls.Add(label2);
            panelTools.Controls.Add(numericUpDown2);
            panelTools.Controls.Add(numericUpDown1);
            panelTools.Controls.Add(label1);
            panelTools.Controls.Add(trackBarBackgroundTransparency);
            panelTools.Controls.Add(groupBoxState);
            panelTools.Controls.Add(checkBoxBackgroundVisible);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 24);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(179, 774);
            panelTools.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 355);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 11;
            label4.Text = "Total distance (km)";
            // 
            // textBoxShortestPath
            // 
            textBoxShortestPath.Location = new Point(9, 375);
            textBoxShortestPath.Name = "textBoxShortestPath";
            textBoxShortestPath.Size = new Size(161, 23);
            textBoxShortestPath.TabIndex = 10;
            // 
            // buttonShortestPath
            // 
            buttonShortestPath.Location = new Point(9, 321);
            buttonShortestPath.Name = "buttonShortestPath";
            buttonShortestPath.Size = new Size(161, 23);
            buttonShortestPath.TabIndex = 9;
            buttonShortestPath.Text = "Find shortest path";
            buttonShortestPath.UseVisualStyleBackColor = true;
            buttonShortestPath.Click += buttonShortestPath_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 265);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 8;
            label3.Text = "End node";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 216);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 7;
            label2.Text = "Start node";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(9, 283);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(161, 23);
            numericUpDown2.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(9, 234);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(161, 23);
            numericUpDown1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(119, 15);
            label1.TabIndex = 4;
            label1.Text = "Background intensity";
            // 
            // trackBarBackgroundTransparency
            // 
            trackBarBackgroundTransparency.Location = new Point(12, 55);
            trackBarBackgroundTransparency.Maximum = 255;
            trackBarBackgroundTransparency.Name = "trackBarBackgroundTransparency";
            trackBarBackgroundTransparency.Size = new Size(161, 45);
            trackBarBackgroundTransparency.TabIndex = 3;
            trackBarBackgroundTransparency.Value = 255;
            trackBarBackgroundTransparency.Scroll += trackBarBackgroundTransparency_Scroll;
            // 
            // groupBoxState
            // 
            groupBoxState.Controls.Add(radioButtonInsertEdge);
            groupBoxState.Controls.Add(radioButtonInsertNode);
            groupBoxState.Controls.Add(radioButtonEdit);
            groupBoxState.Location = new Point(9, 99);
            groupBoxState.Name = "groupBoxState";
            groupBoxState.Size = new Size(161, 103);
            groupBoxState.TabIndex = 2;
            groupBoxState.TabStop = false;
            groupBoxState.Text = "Editor state";
            // 
            // radioButtonInsertEdge
            // 
            radioButtonInsertEdge.AutoSize = true;
            radioButtonInsertEdge.Location = new Point(11, 72);
            radioButtonInsertEdge.Name = "radioButtonInsertEdge";
            radioButtonInsertEdge.Size = new Size(83, 19);
            radioButtonInsertEdge.TabIndex = 2;
            radioButtonInsertEdge.Text = "Insert edge";
            radioButtonInsertEdge.UseVisualStyleBackColor = true;
            radioButtonInsertEdge.CheckedChanged += radioButtonInsertEdge_CheckedChanged;
            // 
            // radioButtonInsertNode
            // 
            radioButtonInsertNode.AutoSize = true;
            radioButtonInsertNode.Location = new Point(11, 47);
            radioButtonInsertNode.Name = "radioButtonInsertNode";
            radioButtonInsertNode.Size = new Size(84, 19);
            radioButtonInsertNode.TabIndex = 1;
            radioButtonInsertNode.Text = "Insert node";
            radioButtonInsertNode.UseVisualStyleBackColor = true;
            radioButtonInsertNode.CheckedChanged += radioButtonInsertNode_CheckedChanged;
            // 
            // radioButtonEdit
            // 
            radioButtonEdit.AutoSize = true;
            radioButtonEdit.Checked = true;
            radioButtonEdit.Location = new Point(11, 22);
            radioButtonEdit.Name = "radioButtonEdit";
            radioButtonEdit.Size = new Size(45, 19);
            radioButtonEdit.TabIndex = 0;
            radioButtonEdit.TabStop = true;
            radioButtonEdit.Text = "Edit";
            radioButtonEdit.UseVisualStyleBackColor = true;
            radioButtonEdit.CheckedChanged += radioButtonEdit_CheckedChanged;
            // 
            // checkBoxBackgroundVisible
            // 
            checkBoxBackgroundVisible.AutoSize = true;
            checkBoxBackgroundVisible.Checked = true;
            checkBoxBackgroundVisible.CheckState = CheckState.Checked;
            checkBoxBackgroundVisible.Location = new Point(12, 12);
            checkBoxBackgroundVisible.Name = "checkBoxBackgroundVisible";
            checkBoxBackgroundVisible.Size = new Size(126, 19);
            checkBoxBackgroundVisible.TabIndex = 2;
            checkBoxBackgroundVisible.Text = "Background visible";
            checkBoxBackgroundVisible.UseVisualStyleBackColor = true;
            checkBoxBackgroundVisible.CheckedChanged += checkBoxBackgroundVisible_CheckedChanged;
            // 
            // doubleBufferPanelDrawing
            // 
            doubleBufferPanelDrawing.Dock = DockStyle.Fill;
            doubleBufferPanelDrawing.Location = new Point(179, 24);
            doubleBufferPanelDrawing.Name = "doubleBufferPanelDrawing";
            doubleBufferPanelDrawing.Size = new Size(1099, 774);
            doubleBufferPanelDrawing.TabIndex = 1;
            doubleBufferPanelDrawing.Paint += doubleBufferPanelDrawing_Paint;
            doubleBufferPanelDrawing.MouseDown += doubleBufferPanelDrawing_MouseDown;
            doubleBufferPanelDrawing.MouseMove += doubleBufferPanelDrawing_MouseMove;
            doubleBufferPanelDrawing.MouseUp += doubleBufferPanelDrawing_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1278, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, closeToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Load";
            openToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 798);
            Controls.Add(doubleBufferPanelDrawing);
            Controls.Add(panelTools);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            panelTools.ResumeLayout(false);
            panelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundTransparency).EndInit();
            groupBoxState.ResumeLayout(false);
            groupBoxState.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTools;
        private DoubleBufferPanel doubleBufferPanelDrawing;
        private CheckBox checkBoxBackgroundVisible;
        private GroupBox groupBoxState;
        private RadioButton radioButtonInsertEdge;
        private RadioButton radioButtonInsertNode;
        private RadioButton radioButtonEdit;
        private TrackBar trackBarBackgroundTransparency;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button buttonShortestPath;
        private Label label3;
        private Label label2;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private TextBox textBoxShortestPath;
        private Label label4;
        private ToolStripMenuItem saveToolStripMenuItem;
    }
}
