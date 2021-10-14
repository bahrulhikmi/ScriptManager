using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissArmyKnife
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            this.Text = "Swiss Army Knife Config " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() +
                            "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() +
                            "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
        }
    }
}
