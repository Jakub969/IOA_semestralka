using cv1.Enums;
using cv1.Network;
using cv1.Tools;
using Microsoft.VisualBasic.Devices;

namespace cv1
{
    public partial class Form1 : Form
    {
        private EnumEditorState state = EnumEditorState.None;
        private NetworkData network;

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
                SelectionBox.Draw(g);
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
                    SelectionBox.StartingMousePosition = e.Location;
                    SelectionBox.IsActive = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                network.Nodes.Add(new(e.Location));
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
                    using Region r = SelectionBox.Track(e.Location);
                    doubleBufferPanelDrawing.Invalidate(r);
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
                network.SelectNode(SelectionBox.TrackedRectangle, ctrlPressed);
            }

            state = EnumEditorState.None;
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
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            network.Key = Keys.None;
        }
    }
}
