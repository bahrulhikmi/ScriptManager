using Common.Interfaces;
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
            LoadConfiguration();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            SetConfigTitle();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // save the config before closing form
            if (!SaveConfiguration())
            {
                MessageBox.Show("Unable to save the configuration. Please contact Said (nur_said@technologyonecorp.com) for help", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void SetConfigTitle()
        {
            this.Text = "Swiss Army Knife Config " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() +
                            "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() +
                            "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
        }


        private void LoadConfiguration()
        {
           
        }

        private bool SaveConfiguration()
        {
            return false;
        }
    }
}
