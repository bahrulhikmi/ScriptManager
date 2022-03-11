using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common.Interfaces;
using Serilog;

namespace SwissArmyKnife
{
    public partial class FrmMain : Form
    {
        IConfigReader configReader;
        IDefinitionReader definitionReader;
        private List<IConfigItem> configurations;

        public FrmMain()
        {
            InitializeComponent();

            //Could use Automapper here, but just instantiate it for now
            definitionReader = new Reader.DefinitionReader();
            configReader = new Reader.ConfigReader();

        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            //LoadConfig();
            LoadDefinitionsAndPopulateUI();


            // delete this when ready
            tesToolStripMenuItem.Visible = false;
        }


        private void LoadConfig()
        {
           configurations = configReader.Read();
        }

        void LoadDefinitionsAndPopulateUI()
        {
            try
            {
                var definitions = definitionReader.Read();

                foreach (var definition in definitions)
                {
                    var item = new ToolStripMenuItem();
                    item.Text = definition.Name;

                    if (definition.IconPath != null && definition.IconPath.Length > 0)
                        item.Image = Image.FromFile(definition.IconPath);

                    item.Click += new EventHandler(RunScript);
                    cmsSwissArmyKnife.Items.Insert(0, item);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Load Definition");
                throw;
            }
        }

        void RunScript(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Running the script...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to run the script. Please ask Said!");
                throw;
            }
        }
   
        private void tesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DefinitionItem defItem = new DefinitionItem();
            //defItem.Path = @"D:\Workplace\HD14\SwissArmy\ScriptManager\Actions";
            //defItem.ScriptFileName = "Test.exe";
            //var runner = new ExeRunner();
            //RunnerResult res = runner.Run(defItem, null);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Information("Application Stop");
        }
    }
}
