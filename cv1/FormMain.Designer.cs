namespace cv1
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            panelTools = new Panel();
            panelShortestPath = new Panel();
            label4 = new Label();
            textBoxShortestPath = new TextBox();
            buttonShortestPath = new Button();
            labelEndNode = new Label();
            labelStartNode = new Label();
            numericUpDownEndNode = new NumericUpDown();
            numericUpDownStartNode = new NumericUpDown();
            panelBackground = new Panel();
            label9 = new Label();
            textBoxHeight = new TextBox();
            label8 = new Label();
            textBoxWidth = new TextBox();
            label6 = new Label();
            labelMapSize = new Label();
            labelBackgroundName = new Label();
            label5 = new Label();
            label1 = new Label();
            trackBarBackgroundTransparency = new TrackBar();
            checkBoxBackgroundVisible = new CheckBox();
            groupBoxState = new GroupBox();
            radioButtonInsertEdge = new RadioButton();
            radioButtonInsertNode = new RadioButton();
            radioButtonEdit = new RadioButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadBackgroundToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            doubleBufferPanelDrawing = new DoubleBufferPanel();
            contextMenuProperties = new ContextMenuStrip(components);
            propertiesToolStripMenuItem = new ToolStripMenuItem();
            panelTools.SuspendLayout();
            panelShortestPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndNode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartNode).BeginInit();
            panelBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundTransparency).BeginInit();
            groupBoxState.SuspendLayout();
            menuStrip1.SuspendLayout();
            contextMenuProperties.SuspendLayout();
            SuspendLayout();
            // 
            // panelTools
            // 
            panelTools.BackColor = SystemColors.AppWorkspace;
            panelTools.Controls.Add(panelShortestPath);
            panelTools.Controls.Add(panelBackground);
            panelTools.Controls.Add(groupBoxState);
            panelTools.Dock = DockStyle.Left;
            panelTools.Location = new Point(0, 30);
            panelTools.Margin = new Padding(3, 4, 3, 4);
            panelTools.Name = "panelTools";
            panelTools.Size = new Size(205, 983);
            panelTools.TabIndex = 0;
            // 
            // panelShortestPath
            // 
            panelShortestPath.BackColor = Color.FromArgb(192, 255, 192);
            panelShortestPath.Controls.Add(label4);
            panelShortestPath.Controls.Add(textBoxShortestPath);
            panelShortestPath.Controls.Add(buttonShortestPath);
            panelShortestPath.Controls.Add(labelEndNode);
            panelShortestPath.Controls.Add(labelStartNode);
            panelShortestPath.Controls.Add(numericUpDownEndNode);
            panelShortestPath.Controls.Add(numericUpDownStartNode);
            panelShortestPath.Dock = DockStyle.Top;
            panelShortestPath.Location = new Point(0, 337);
            panelShortestPath.Margin = new Padding(3, 4, 3, 4);
            panelShortestPath.Name = "panelShortestPath";
            panelShortestPath.Size = new Size(205, 264);
            panelShortestPath.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 189);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 44;
            label4.Text = "Total distance (km)";
            // 
            // textBoxShortestPath
            // 
            textBoxShortestPath.Location = new Point(6, 216);
            textBoxShortestPath.Margin = new Padding(3, 4, 3, 4);
            textBoxShortestPath.Name = "textBoxShortestPath";
            textBoxShortestPath.Size = new Size(183, 27);
            textBoxShortestPath.TabIndex = 43;
            // 
            // buttonShortestPath
            // 
            buttonShortestPath.Location = new Point(6, 144);
            buttonShortestPath.Margin = new Padding(3, 4, 3, 4);
            buttonShortestPath.Name = "buttonShortestPath";
            buttonShortestPath.Size = new Size(184, 31);
            buttonShortestPath.TabIndex = 42;
            buttonShortestPath.Text = "Find shortest path";
            buttonShortestPath.UseVisualStyleBackColor = true;
            buttonShortestPath.Click += buttonShortestPath_Click;
            // 
            // labelEndNode
            // 
            labelEndNode.AutoSize = true;
            labelEndNode.Location = new Point(9, 69);
            labelEndNode.Name = "labelEndNode";
            labelEndNode.Size = new Size(72, 20);
            labelEndNode.TabIndex = 41;
            labelEndNode.Text = "End node";
            // 
            // labelStartNode
            // 
            labelStartNode.AutoSize = true;
            labelStartNode.Location = new Point(9, 4);
            labelStartNode.Name = "labelStartNode";
            labelStartNode.Size = new Size(78, 20);
            labelStartNode.TabIndex = 40;
            labelStartNode.Text = "Start node";
            // 
            // numericUpDownEndNode
            // 
            numericUpDownEndNode.Location = new Point(6, 93);
            numericUpDownEndNode.Margin = new Padding(3, 4, 3, 4);
            numericUpDownEndNode.Name = "numericUpDownEndNode";
            numericUpDownEndNode.Size = new Size(184, 27);
            numericUpDownEndNode.TabIndex = 39;
            // 
            // numericUpDownStartNode
            // 
            numericUpDownStartNode.Location = new Point(6, 28);
            numericUpDownStartNode.Margin = new Padding(3, 4, 3, 4);
            numericUpDownStartNode.Name = "numericUpDownStartNode";
            numericUpDownStartNode.Size = new Size(184, 27);
            numericUpDownStartNode.TabIndex = 38;
            // 
            // panelBackground
            // 
            panelBackground.BackColor = Color.AntiqueWhite;
            panelBackground.Controls.Add(label9);
            panelBackground.Controls.Add(textBoxHeight);
            panelBackground.Controls.Add(label8);
            panelBackground.Controls.Add(textBoxWidth);
            panelBackground.Controls.Add(label6);
            panelBackground.Controls.Add(labelMapSize);
            panelBackground.Controls.Add(labelBackgroundName);
            panelBackground.Controls.Add(label5);
            panelBackground.Controls.Add(label1);
            panelBackground.Controls.Add(trackBarBackgroundTransparency);
            panelBackground.Controls.Add(checkBoxBackgroundVisible);
            panelBackground.Dock = DockStyle.Top;
            panelBackground.Location = new Point(0, 0);
            panelBackground.Margin = new Padding(3, 4, 3, 4);
            panelBackground.Name = "panelBackground";
            panelBackground.Size = new Size(205, 337);
            panelBackground.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(10, 180);
            label9.Name = "label9";
            label9.Size = new Size(54, 20);
            label9.TabIndex = 30;
            label9.Text = "Height";
            // 
            // textBoxHeight
            // 
            textBoxHeight.Location = new Point(77, 176);
            textBoxHeight.Margin = new Padding(3, 4, 3, 4);
            textBoxHeight.Name = "textBoxHeight";
            textBoxHeight.Size = new Size(114, 27);
            textBoxHeight.TabIndex = 29;
            textBoxHeight.Text = "100";
            textBoxHeight.TextAlign = HorizontalAlignment.Right;
            textBoxHeight.TextChanged += textBoxHeight_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 141);
            label8.Name = "label8";
            label8.Size = new Size(49, 20);
            label8.TabIndex = 28;
            label8.Text = "Width";
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new Point(77, 136);
            textBoxWidth.Margin = new Padding(3, 4, 3, 4);
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new Size(114, 27);
            textBoxWidth.TabIndex = 27;
            textBoxWidth.Text = "100";
            textBoxWidth.TextAlign = HorizontalAlignment.Right;
            textBoxWidth.TextChanged += textBoxWidth_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 107);
            label6.Name = "label6";
            label6.Size = new Size(152, 20);
            label6.TabIndex = 26;
            label6.Text = "Map dimensions (km)";
            // 
            // labelMapSize
            // 
            labelMapSize.AutoSize = true;
            labelMapSize.Location = new Point(10, 76);
            labelMapSize.Name = "labelMapSize";
            labelMapSize.Size = new Size(71, 20);
            labelMapSize.TabIndex = 25;
            labelMapSize.Text = "Map size:";
            // 
            // labelBackgroundName
            // 
            labelBackgroundName.AutoSize = true;
            labelBackgroundName.Location = new Point(10, 43);
            labelBackgroundName.Name = "labelBackgroundName";
            labelBackgroundName.Size = new Size(82, 20);
            labelBackgroundName.TabIndex = 24;
            labelBackgroundName.Text = "not loaded";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 15);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 20;
            label5.Text = "Background name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 256);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 23;
            label1.Text = "Background intensity";
            // 
            // trackBarBackgroundTransparency
            // 
            trackBarBackgroundTransparency.Location = new Point(10, 280);
            trackBarBackgroundTransparency.Margin = new Padding(3, 4, 3, 4);
            trackBarBackgroundTransparency.Maximum = 255;
            trackBarBackgroundTransparency.Name = "trackBarBackgroundTransparency";
            trackBarBackgroundTransparency.Size = new Size(184, 56);
            trackBarBackgroundTransparency.TabIndex = 22;
            trackBarBackgroundTransparency.Value = 255;
            trackBarBackgroundTransparency.Scroll += trackBarBackgroundTransparency_Scroll;
            // 
            // checkBoxBackgroundVisible
            // 
            checkBoxBackgroundVisible.AutoSize = true;
            checkBoxBackgroundVisible.Checked = true;
            checkBoxBackgroundVisible.CheckState = CheckState.Checked;
            checkBoxBackgroundVisible.Location = new Point(10, 223);
            checkBoxBackgroundVisible.Margin = new Padding(3, 4, 3, 4);
            checkBoxBackgroundVisible.Name = "checkBoxBackgroundVisible";
            checkBoxBackgroundVisible.Size = new Size(156, 24);
            checkBoxBackgroundVisible.TabIndex = 21;
            checkBoxBackgroundVisible.Text = "Background visible";
            checkBoxBackgroundVisible.UseVisualStyleBackColor = true;
            checkBoxBackgroundVisible.CheckedChanged += checkBoxBackgroundVisible_CheckedChanged;
            // 
            // groupBoxState
            // 
            groupBoxState.Controls.Add(radioButtonInsertEdge);
            groupBoxState.Controls.Add(radioButtonInsertNode);
            groupBoxState.Controls.Add(radioButtonEdit);
            groupBoxState.Location = new Point(8, 623);
            groupBoxState.Margin = new Padding(3, 4, 3, 4);
            groupBoxState.Name = "groupBoxState";
            groupBoxState.Padding = new Padding(3, 4, 3, 4);
            groupBoxState.Size = new Size(184, 137);
            groupBoxState.TabIndex = 2;
            groupBoxState.TabStop = false;
            groupBoxState.Text = "Editor state";
            // 
            // radioButtonInsertEdge
            // 
            radioButtonInsertEdge.AutoSize = true;
            radioButtonInsertEdge.Location = new Point(13, 96);
            radioButtonInsertEdge.Margin = new Padding(3, 4, 3, 4);
            radioButtonInsertEdge.Name = "radioButtonInsertEdge";
            radioButtonInsertEdge.Size = new Size(104, 24);
            radioButtonInsertEdge.TabIndex = 2;
            radioButtonInsertEdge.Text = "Insert edge";
            radioButtonInsertEdge.UseVisualStyleBackColor = true;
            radioButtonInsertEdge.CheckedChanged += radioButtonInsertEdge_CheckedChanged;
            // 
            // radioButtonInsertNode
            // 
            radioButtonInsertNode.AutoSize = true;
            radioButtonInsertNode.Location = new Point(13, 63);
            radioButtonInsertNode.Margin = new Padding(3, 4, 3, 4);
            radioButtonInsertNode.Name = "radioButtonInsertNode";
            radioButtonInsertNode.Size = new Size(104, 24);
            radioButtonInsertNode.TabIndex = 1;
            radioButtonInsertNode.Text = "Insert node";
            radioButtonInsertNode.UseVisualStyleBackColor = true;
            radioButtonInsertNode.CheckedChanged += radioButtonInsertNode_CheckedChanged;
            // 
            // radioButtonEdit
            // 
            radioButtonEdit.AutoSize = true;
            radioButtonEdit.Checked = true;
            radioButtonEdit.Location = new Point(13, 29);
            radioButtonEdit.Margin = new Padding(3, 4, 3, 4);
            radioButtonEdit.Name = "radioButtonEdit";
            radioButtonEdit.Size = new Size(56, 24);
            radioButtonEdit.TabIndex = 0;
            radioButtonEdit.TabStop = true;
            radioButtonEdit.Text = "Edit";
            radioButtonEdit.UseVisualStyleBackColor = true;
            radioButtonEdit.CheckedChanged += radioButtonEdit_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1570, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadBackgroundToolStripMenuItem, closeToolStripMenuItem, toolStripMenuItem1, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripMenuItem2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(208, 26);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // loadBackgroundToolStripMenuItem
            // 
            loadBackgroundToolStripMenuItem.Name = "loadBackgroundToolStripMenuItem";
            loadBackgroundToolStripMenuItem.Size = new Size(208, 26);
            loadBackgroundToolStripMenuItem.Text = "Load background";
            loadBackgroundToolStripMenuItem.Click += loadBackgroundToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(208, 26);
            closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(205, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(208, 26);
            openToolStripMenuItem.Text = "Load";
            openToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(208, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(208, 26);
            saveAsToolStripMenuItem.Text = "Save as...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(205, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(208, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // doubleBufferPanelDrawing
            // 
            doubleBufferPanelDrawing.Dock = DockStyle.Fill;
            doubleBufferPanelDrawing.Location = new Point(205, 30);
            doubleBufferPanelDrawing.Margin = new Padding(3, 4, 3, 4);
            doubleBufferPanelDrawing.Name = "doubleBufferPanelDrawing";
            doubleBufferPanelDrawing.Size = new Size(1365, 983);
            doubleBufferPanelDrawing.TabIndex = 1;
            doubleBufferPanelDrawing.Paint += doubleBufferPanelDrawing_Paint;
            doubleBufferPanelDrawing.MouseDown += doubleBufferPanelDrawing_MouseDown;
            doubleBufferPanelDrawing.MouseMove += doubleBufferPanelDrawing_MouseMove;
            doubleBufferPanelDrawing.MouseUp += doubleBufferPanelDrawing_MouseUp;
            // 
            // contextMenuProperties
            // 
            contextMenuProperties.ImageScalingSize = new Size(20, 20);
            contextMenuProperties.Items.AddRange(new ToolStripItem[] { propertiesToolStripMenuItem });
            contextMenuProperties.Name = "contextMenuProperties";
            contextMenuProperties.Size = new Size(146, 28);
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(145, 24);
            propertiesToolStripMenuItem.Text = "Properties";
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1570, 1013);
            Controls.Add(doubleBufferPanelDrawing);
            Controls.Add(panelTools);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Network editor";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            panelTools.ResumeLayout(false);
            panelShortestPath.ResumeLayout(false);
            panelShortestPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndNode).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartNode).EndInit();
            panelBackground.ResumeLayout(false);
            panelBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundTransparency).EndInit();
            groupBoxState.ResumeLayout(false);
            groupBoxState.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuProperties.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTools;
        private DoubleBufferPanel doubleBufferPanelDrawing;
        private GroupBox groupBoxState;
        private RadioButton radioButtonInsertEdge;
        private RadioButton radioButtonInsertNode;
        private RadioButton radioButtonEdit;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadBackgroundToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem2;
        private Panel panelBackground;
        private Label label9;
        private TextBox textBoxHeight;
        private Label label8;
        private TextBox textBoxWidth;
        private Label label6;
        public Label labelBackgroundName;
        private Label label5;
        private Label label1;
        private TrackBar trackBarBackgroundTransparency;
        private CheckBox checkBoxBackgroundVisible;
        public Label labelMapSize;
        private Panel panelShortestPath;
        private Label label4;
        private TextBox textBoxShortestPath;
        private Button buttonShortestPath;
        private Label labelEndNode;
        private Label labelStartNode;
        private NumericUpDown numericUpDownEndNode;
        private NumericUpDown numericUpDownStartNode;
        private ContextMenuStrip contextMenuProperties;
        private ToolStripMenuItem propertiesToolStripMenuItem;
    }
}
