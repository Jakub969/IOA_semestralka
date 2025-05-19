using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using cv1.Enums;
using cv1.Network;

namespace cv1
{
    public partial class NodePropertiesForm : Form
    {
        private NetworkNode node;
        public NodePropertiesForm(NetworkNode node)
        {
            InitializeComponent();
            this.node = node;

            txtName.Text = node.Name;
            cmbNodeType.DataSource = Enum.GetValues(typeof(EnumNodeType));
            cmbNodeType.SelectedItem = node.Type;
            numericCapacity.Value = (decimal)node.CapacityOrDemand;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            node.Name = txtName.Text;
            node.Type = (EnumNodeType)cmbNodeType.SelectedItem;
            node.CapacityOrDemand = (float)numericCapacity.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
