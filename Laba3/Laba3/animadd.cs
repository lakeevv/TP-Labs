using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba3
{
    public partial class animadd : Form
    {
        public animadd()
        {
            InitializeComponent();
        }

        public String spc
        {
            get { return SPC.Text; }
            set { SPC.Text = value; }
        }
        public String kls
        {
            get { return (KLS.Text); }
            set { KLS.Text = value; }
        }
        public int wdh
        {
            get { return Convert.ToInt32(WDH.Text); }
            set { WDH.Text = value.ToString(); }
        }
        public string plc
        {
            get { return (PLC.Text); }
            set { PLC.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
