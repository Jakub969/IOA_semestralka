using cv1.Enums;
using cv1.Network;
using cv1.Tools;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace cv1
{
    public partial class FormMain : Form
    {
        private EnumEditorState state = EnumEditorState.None;
        private EnumEditorMode mode = EnumEditorMode.Edit;

        private Point startMousePos;
        private Point currentMousePos;
        private NetworkData network;
        private bool framedSelectionBox = true;
        private NetworkNode? edgeNodeStart = null;
        private string projectPath = string.Empty;
        private NetworkNode clickedNode = null;
        private NetworkEdge clickedEdge = null;

        public FormMain()
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
                    if (state == EnumEditorState.PossibleDrag)
                    {
                        state = EnumEditorState.NodeDragging;
                        startMousePos = e.Location;
                    }
                    else
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
            else if (e.Button == MouseButtons.Right && mode == EnumEditorMode.Edit)
            {
                clickedNode = network.IsNodeHitByMouse(e.Location);
                clickedEdge = network.IsEdgeHitByMouse(e.Location);

                if (clickedNode != null || clickedEdge != null)
                {
                    contextMenuProperties.Show(doubleBufferPanelDrawing, e.Location);
                }
            }

            doubleBufferPanelDrawing.Invalidate();
            RefreshUserInterface();
        }

        private void doubleBufferPanelDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mode == EnumEditorMode.Edit)
                {
                    if (state == EnumEditorState.NodeDragging)
                    {
                        network.NodeDrawingOffset = new(e.Location.X - startMousePos.X, e.Location.Y - startMousePos.Y);
                    }
                    else if (state == EnumEditorState.Selecting || state == EnumEditorState.SelectBegin)
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
            else if (e.Button == MouseButtons.Right)
            {

            }
            else if (e.Button == MouseButtons.None)
            {
                if (network.HoverOverSelectedNode(e.Location))
                {
                    state = EnumEditorState.PossibleDrag;
                    Cursor = Cursors.Hand;
                }
                else
                {
                    state = EnumEditorState.None;
                    Cursor = Cursors.Default;
                }
            }

            doubleBufferPanelDrawing.Invalidate();
        }

        private void doubleBufferPanelDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == EnumEditorMode.Edit)
            {
                if (state == EnumEditorState.NodeDragging)
                {
                    network.UpdateNodesPositionsAfterDrag();
                }
                else if (state == EnumEditorState.Selecting)
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
            startMousePos = new(0, 0);
            network.NodeDrawingOffset = new(0, 0);

            doubleBufferPanelDrawing.Invalidate();
            RefreshUserInterface();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            network = new()
            {
                BackgroundAlpha = trackBarBackgroundTransparency.Value
            };

            panelBackground.Enabled = false;
            doubleBufferPanelDrawing.Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (network != null)
            {
                if (MessageBox.Show("Network loaded, do you wan to reset?", "Network editor", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }

            network = new()
            {
                BackgroundAlpha = trackBarBackgroundTransparency.Value
            };

            panelBackground.Enabled = false;

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

            RefreshUserInterface();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            network.Key = Keys.None;
        }

        private void radioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            // deselect all nodes
            network.SelectNode(new Rectangle());
            doubleBufferPanelDrawing.Invalidate();

            if (radioButtonEdit.Checked)
                mode = EnumEditorMode.Edit;
        }

        private void radioButtonInsertNode_CheckedChanged(object sender, EventArgs e)
        {
            // deselect all nodes
            network.SelectNode(new Rectangle());
            doubleBufferPanelDrawing.Invalidate();

            if (radioButtonInsertNode.Checked)
                mode = EnumEditorMode.InsertNode;
        }

        private void radioButtonInsertEdge_CheckedChanged(object sender, EventArgs e)
        {
            // deselect all nodes
            network.SelectNode(new Rectangle());
            doubleBufferPanelDrawing.Invalidate();

            if (radioButtonInsertEdge.Checked)
                mode = EnumEditorMode.InsertEdge;

        }

        private void trackBarBackgroundTransparency_Scroll(object sender, EventArgs e)
        {
            network.BackgroundAlpha = trackBarBackgroundTransparency.Value;
            doubleBufferPanelDrawing.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveNetworkData();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.InitialDirectory = @"Documents";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Browse XML Files";
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.ShowDialog();

            projectPath = saveFileDialog.FileName;
            SaveNetworkData();
        }

        private void SaveNetworkData()
        {
            if (string.IsNullOrWhiteSpace(projectPath))
                return;

            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            var serializer = new DataContractSerializer(network.GetType());
            FileStream writer = new(projectPath, FileMode.Create);

            serializer.WriteObject(writer, network);
            writer.Close();
        }

        private void LoadNetworkData()
        {
            if (string.IsNullOrWhiteSpace(projectPath))
                return;

            FileStream fs = new(projectPath, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer? serializer = new(typeof(NetworkData));

            if (serializer == null)
                return;

            if (serializer.ReadObject(reader, true) is not NetworkData data)
                return;

            network = new()
            {
                BackgroundAlpha = trackBarBackgroundTransparency.Value
            };

            network.BitmapPath = data.BitmapPath;

            foreach (var node in data.Nodes)
            {
                network.Nodes.Add(node);
            }

            foreach (var edge in data.Edges)
            {
                NetworkNode? startNode = network.Nodes.Find(n => n.ID == edge.StartNodeID);
                NetworkNode? endNode = network.Nodes.Find(n => n.ID == edge.EndNodeID);

                if (startNode == null || endNode == null)
                    continue;

                network.Edges.Add(new NetworkEdge(startNode, endNode, edge.ID));
            }

            network.BackgroundVisible = data.BackgroundVisible;

            reader.Close();
            fs.Close();

            doubleBufferPanelDrawing.Invalidate();
            RefreshUserInterface();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = @"Documents",
                RestoreDirectory = true,
                Title = "Browse XML Files",
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 2,
                CheckFileExists = true,
                CheckPathExists = true
            };

            openFileDialog.ShowDialog();
            projectPath = openFileDialog.FileName;
            LoadNetworkData();
        }

        private void loadBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = @"Desktop",
                RestoreDirectory = true,
                Title = "Browse PNG Files",
                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|All files (*.*)|*.*",
                FilterIndex = 2,
                CheckFileExists = true,
                CheckPathExists = true
            };

            openFileDialog.ShowDialog();

            network.BitmapPath = openFileDialog.FileName;

            RefreshUserInterface();
        }

        private void RefreshUserInterface()
        {
            if (network == null)
                return;

            if (network.Nodes.Count > 1)
            {
                panelShortestPath.Enabled = true;
                labelStartNode.Text = "Start node <0," + (network.Nodes.Count - 1).ToString() + ">";
                labelEndNode.Text = "End node <0," + (network.Nodes.Count - 1).ToString() + ">";
                numericUpDownStartNode.Maximum = network.Nodes.Count - 1;
                numericUpDownStartNode.Value = 0;

                numericUpDownEndNode.Maximum = network.Nodes.Count - 1;
                numericUpDownEndNode.Value = 0;
            }
            else
            {
                panelShortestPath.Enabled = false;
                labelStartNode.Text = "Start node";
                labelEndNode.Text = "End node";
                numericUpDownStartNode.Value = 0;
                numericUpDownEndNode.Value = 0;
            }

            if (network.BitmapImage != null)
            {
                panelBackground.Enabled = true;
                labelBackgroundName.Text = Path.GetFileName(network.BitmapPath);
                labelMapSize.Text = "Map size: " + network.BitmapImage.Width + " x " + network.BitmapImage.Height;

                textBoxWidth.Text = network.MapWidth.ToString();
                textBoxHeight.Text = network.MapHeight.ToString();

                CoordTransformations.Umax = network.BitmapImage.Width;
                CoordTransformations.Vmin = network.BitmapImage.Height;
                CoordTransformations.Xmax = network.MapWidth;
                CoordTransformations.Ymax = network.MapHeight;
            }
            else
            {
                panelBackground.Enabled = false;
                labelBackgroundName.Text = "not loaded";
                labelMapSize.Text = "Map size:";
                textBoxWidth.Text = string.Empty;
                textBoxHeight.Text = string.Empty;
            }
        }

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            if (network == null)
                return;

            if (float.TryParse(textBoxWidth.Text, out float dialogValue))
            {
                network.MapWidth = dialogValue;
                RefreshUserInterface();
            }
            else
                MessageBox.Show("Wrong number format");
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBoxWidth.Text, out float dialogValue))
            {
                network.MapHeight = dialogValue;
                RefreshUserInterface();
            }
            else
                MessageBox.Show("Wrong number format");
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedNode != null)
            {
                NodePropertiesForm nodeForm = new NodePropertiesForm(clickedNode);
                if (nodeForm.ShowDialog() == DialogResult.OK)
                {
                    doubleBufferPanelDrawing.Invalidate();
                }
            }
            else if (clickedEdge != null)
            {
                EdgePropertiesForm edgeForm = new EdgePropertiesForm(clickedEdge);
                if (edgeForm.ShowDialog() == DialogResult.OK)
                {
                    doubleBufferPanelDrawing.Invalidate();
                }
            }

            clickedNode = null;
            clickedEdge = null;
        }

        private void buttonShortestPath_Click(object sender, EventArgs e)
        {
            if (network == null || network.Nodes.Count == 0)
            {
                MessageBox.Show("No nodes to calculate the path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int startNodeIndex = (int)numericUpDownStartNode.Value;
            int endNodeIndex = (int)numericUpDownEndNode.Value;

            if (startNodeIndex == endNodeIndex)
            {
                MessageBox.Show("Start and end nodes must be different.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var startNode = network.Nodes.ElementAtOrDefault(startNodeIndex);
            var endNode = network.Nodes.ElementAtOrDefault(endNodeIndex);

            if (startNode == null || endNode == null)
            {
                MessageBox.Show("Invalid node selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pathFinder = new ShortestPath(network);
            var (path, totalDistance) = pathFinder.FindPath(startNode, endNode);

            if (path.Count == 0 || float.IsPositiveInfinity(totalDistance))
            {
                MessageBox.Show("No path found between selected nodes.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxShortestPath.Text = "No path";
            }
            else
            {
                network.Nodes.ForEach(n => n.Selected = false);
                path.ForEach(n => n.Selected = true);

                textBoxShortestPath.Text = totalDistance.ToString("F2");
                doubleBufferPanelDrawing.Invalidate();
            }
        }

        private void buttonClassicalCW_Click(object sender, EventArgs e)
        {
            if (!network.ValidateParameters(out string validationMsg))
            {
                MessageBox.Show(validationMsg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var solver = new ClarkeWrightSolver(network, vehicleCapacity: (float)numericCarCapacity.Value);
            var routes = solver.Solve();

            DisplayRoutes(routes);
        }

        private void DisplayRoutes(List<List<NetworkNode>> routes)
        {
            foreach (var edge in network.Edges)
                edge.RouteIndex = null;
            var pathfinder = new ShortestPath(network);
            String message = "";
            int r = 0;
            foreach (var route in routes)
            {
                for (int i = 0; i < route.Count - 1; i++)
                {
                    var a = route[i];
                    var b = route[i + 1];

                    var directEdge = network.Edges.FirstOrDefault(e =>
                        (e.StartNode == a && e.EndNode == b) ||
                        (e.EndNode == a && e.StartNode == b));

                    if (directEdge != null)
                    {
                        directEdge.RouteIndex = r;
                    }
                    else
                    {
                        var (pathNodes, _) = pathfinder.FindPath(a, b);
                        for (int j = 0; j < pathNodes.Count - 1; j++)
                        {
                            var ea = pathNodes[j];
                            var eb = pathNodes[j + 1];

                            var edgeInPath = network.Edges.FirstOrDefault(e =>
                                (e.StartNode == ea && e.EndNode == eb) ||
                                (e.EndNode == ea && e.StartNode == eb));

                            if (edgeInPath != null)
                                edgeInPath.RouteIndex = r;
                        }
                    }
                    message += $"{route[i].Name} -> ";
                }
                r++;
                message += $"{route.Last().Name}\n";
            }
            Console.WriteLine(message);
            MessageBox.Show(message, "Routes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            doubleBufferPanelDrawing.Invalidate();
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            if (!network.IsConnected())
            {
                MessageBox.Show("The network is not fully connected. Please ensure connectivity before running algorithms.", "Connectivity Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isolatedNodes = network.IsolatedNodes();
            if (isolatedNodes.Any())
            {
                MessageBox.Show($"The network has isolated nodes: {string.Join(", ", isolatedNodes.Select(n => n.Name))}", "Isolation Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("The network is fully connected and has no isolated nodes.", "Connectivity Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
