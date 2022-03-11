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
using Reader;

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
            ConfigReader configReader = new ConfigReader();
            var configs = configReader.Read();
            DataGridViewRow row;
            foreach (var config in configs)
            {
                row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = config.ConfigKey;
                row.Cells[1].Value = config.Value;
                dataGridView1.Rows.Add(row);
            }
        }

        private bool SaveConfiguration()
        {
            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void propertyGridASK_Click(object sender, EventArgs e)
        {

        }
    }
}
