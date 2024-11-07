using cv1.Enums;
using cv1.Network;
using cv1.Tools;
using Microsoft.VisualBasic.Devices;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace cv1
{
    public partial class Form1 : Form
    {
        private EnumEditorState state = EnumEditorState.None;
        private EnumEditorMode mode = EnumEditorMode.Edit;

        private Point currentMousePos;
        private NetworkData network;
        private bool framedSelectionBox = true;

        private NetworkNode? edgeNodeStart = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void doubleBufferPanelDrawing_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (network != null)
            {
                network.Draw(g);
            }

            if (mode == EnumEditorMode.Edit)
            {
                if (state == EnumEditorState.Selecting)
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

                    if (framedSelectionBox)
                    {
                        // selection box without frame
                        SelectionBoxFramed.Draw(g);
                    }
                    else
                    {
                        // selection box with frame
                        SelectionBox.Draw(g);
                    }
                }
            }
            if (mode == EnumEditorMode.InsertEdge)
            {
                if (edgeNodeStart != null && currentMousePos.X != 0 && currentMousePos.Y != 0)
                {
                    using Pen p = new(Color.DarkGray, 2.0f);
                    g.DrawLine(p, edgeNodeStart.Position, currentMousePos);
                }
            }
        }

        private void doubleBufferPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mode == EnumEditorMode.Edit)
                {
                    bool ctrlPressed = (network.Key == Keys.ControlKey);

                    if (!network.SelectNode(e.Location, ctrlPressed))
                    {
                        network.SelectNode(new Rectangle(), ctrlPressed);
                        state = EnumEditorState.SelectBegin;

                        if (framedSelectionBox)
                            SelectionBoxFramed.InitSelectionBox(e.Location);
                        else
                            SelectionBox.InitSelectionBox(e.Location);
                    }
                }
                else if (mode == EnumEditorMode.InsertNode)
                {
                    network.InsertNode(e.Location);
                }
                else if (mode == EnumEditorMode.InsertEdge)
                {
                    edgeNodeStart = network.IsNodeHitByMouse(e.Location);

                    if (edgeNodeStart != null)
                        state = EnumEditorState.InsertEdge;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
            }

            doubleBufferPanelDrawing.Invalidate();
        }

        private void doubleBufferPanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mode == EnumEditorMode.Edit)
                {
                    if (state == EnumEditorState.Selecting || state == EnumEditorState.SelectBegin)
                    {
                        state = EnumEditorState.Selecting;

                        if (framedSelectionBox)
                        {
                            using Region r = SelectionBoxFramed.Track(e.Location);
                            doubleBufferPanelDrawing.Invalidate(r);
                        }
                        else
                        {
                            using Region r = SelectionBox.Track(e.Location);
                            doubleBufferPanelDrawing.Invalidate(r);
                        }

                        return;
                    }
                }
                if (mode == EnumEditorMode.InsertEdge)
                {
                    currentMousePos = e.Location;
                }
            }

            doubleBufferPanelDrawing.Invalidate();
        }

        private void doubleBufferPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == EnumEditorMode.Edit)
            {
                if (state == EnumEditorState.Selecting)
                {
                    bool ctrlPressed = (network.Key == Keys.ControlKey);

                    if (framedSelectionBox)
                        network.SelectNode(SelectionBoxFramed.TrackedRectangle, ctrlPressed);
                    else
                        network.SelectNode(SelectionBox.TrackedRectangle, ctrlPressed);
                }
            }
            if (mode == EnumEditorMode.InsertEdge)
            {
                if (edgeNodeStart != null)
                {
                    NetworkNode? edgeNodeEnd = network.IsNodeHitByMouse(e.Location);

                    if (edgeNodeEnd != null)
                    {
                        if (!network.InsertEdge(edgeNodeStart, edgeNodeEnd))
                            MessageBox.Show("Can not insert. Edge exists.", "Network editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            state = EnumEditorState.None;
            SelectionBoxFramed.IsActive = false;
            SelectionBox.IsActive = false;
            edgeNodeStart = null;
            currentMousePos = new(0, 0);

            doubleBufferPanelDrawing.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\\Users\\lekyr1\\Desktop\\data\\MapaPodklad.png";

            network = new(path);

            doubleBufferPanelDrawing.Invalidate();
        }

        private void checkBoxBackgroundVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (network != null)
                network.BackgroundVisible = checkBoxBackgroundVisible.Checked;

            trackBarBackgroundTransparency.Enabled = checkBoxBackgroundVisible.Checked;

            doubleBufferPanelDrawing.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            network.Key = e.KeyCode;

            if (e.KeyCode == Keys.Delete && network.SeletedAny)
            {
                if (MessageBox.Show("Delete selected elements?", "Network editor", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    network.RemoveSelected();
                    doubleBufferPanelDrawing.Invalidate();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            network.Key = Keys.None;
        }

        private void radioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEdit.Checked)
                mode = EnumEditorMode.Edit;
        }

        private void radioButtonInsertNode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInsertNode.Checked)
                mode = EnumEditorMode.InsertNode;
        }

        private void radioButtonInsertEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInsertEdge.Checked)
                mode = EnumEditorMode.InsertEdge;

        }

        private void trackBarBackgroundTransparency_Scroll(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"Documents";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Browse XML Files";
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ShowDialog();
        }
    }
}
