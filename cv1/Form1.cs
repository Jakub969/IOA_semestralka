using cv1.Enums;
using cv1.Network;
using cv1.Tools;
using Microsoft.VisualBasic.Devices;
using System.Drawing;

namespace cv1
{
    public partial class Form1 : Form
    {
        private EnumEditorState state = EnumEditorState.None;
        private EnumEditorMode mode = EnumEditorMode.Edit;

        private NetworkData network;
        private bool framedSelectionBox = true;

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

        private void doubleBufferPanelDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
            else if (e.Button == MouseButtons.Right)
            {
                network.InsertNode(e.Location);
            }

            doubleBufferPanelDrawing.Invalidate();
        }

        private void doubleBufferPanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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

            doubleBufferPanelDrawing.Invalidate();
        }

        private void doubleBufferPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == EnumEditorState.Selecting)
            {
                bool ctrlPressed = (network.Key == Keys.ControlKey);

                if (framedSelectionBox)
                    network.SelectNode(SelectionBoxFramed.TrackedRectangle, ctrlPressed);
                else
                    network.SelectNode(SelectionBox.TrackedRectangle, ctrlPressed);
            }

            state = EnumEditorState.None;
            SelectionBoxFramed.IsActive = false;
            SelectionBox.IsActive = false;
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
            if (radioButtonEdit.Checked)
                mode = EnumEditorMode.InsertNode;
        }

        private void radioButtonInsertEdge_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEdit.Checked)
                mode = EnumEditorMode.InsertEdge;

        }
    }
}
