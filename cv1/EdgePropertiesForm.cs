using cv1.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cv1
{
    public partial class EdgePropertiesForm : Form
    {
        private NetworkEdge edge;
        public EdgePropertiesForm(NetworkEdge edge)
        {
            InitializeComponent();
            this.edge = edge;

            numericLength.Value = (decimal)edge.Length;
            chkAutoCalculate.Checked = !edge.isLengthManual;
            chkEnabled.Checked = edge.IsEnabled;

            numericLength.Enabled = edge.isLengthManual;

            chkAutoCalculate.CheckedChanged += chkAutoCalculate_CheckedChanged;
            buttonOK.Click += buttonOK_Click;
            buttonCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
        }

        private void chkAutoCalculate_CheckedChanged(object sender, EventArgs e)
        {
            numericLength.Enabled = !chkAutoCalculate.Checked;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            edge.IsEnabled = chkEnabled.Checked;
            edge.SetAutoLengthCalculation(chkAutoCalculate.Checked);

            if (!chkAutoCalculate.Checked)
                edge.Length = (float)numericLength.Value;

            DialogResult = DialogResult.OK;
        }
    }
}
