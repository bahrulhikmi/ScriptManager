﻿using System;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
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
