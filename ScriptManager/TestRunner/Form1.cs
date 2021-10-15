using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Runner.Classes;

namespace TestRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DefinitionItem defItem = new DefinitionItem();
            defItem.Path = @"D:\Workplace\HD14\SwissArmy\ScriptManager\Actions";
            defItem.ScriptFileName = "Test.exe";
            var runner = new ExeRunner();
            var _ = runner.Run(defItem, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefinitionItem defItem = new DefinitionItem();
            defItem.Path = @"D:\Workplace\HD14\SwissArmy\ScriptManager\Actions";
            defItem.ScriptFileName = "Test.ps1";
            var runner = new WinScriptRunner();
            var _ = runner.Run(defItem, null);
        }
    }
}
