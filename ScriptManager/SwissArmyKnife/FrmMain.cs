using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Interfaces;

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
            LoadConfig();
            LoadDefinitionsAndPopulateUI();
        }


        private void LoadConfig()
        {
           configurations = configReader.Read();
        }

        void LoadDefinitionsAndPopulateUI()
        {
            var definitions = definitionReader.Read();
            cmsSwissArmyKnife.Items.Clear();
            cmsSwissArmyKnife.Items.Add(configToolStripMenuItem);
            cmsSwissArmyKnife.Items.Add(exitToolStripMenuItem);

            foreach(var definition in definitions)
            {
                var item = new ToolStripMenuItem();
                item.Text = definition.Name;
                cmsSwissArmyKnife.Items.Add(item);
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
    }
}
