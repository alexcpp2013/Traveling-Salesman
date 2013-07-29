using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aiGenetic
{
    public partial class SettingsDlg : Form
    {
        private Settings s;

        public Settings S
        {
            get { return this.s; }
        }

        public SettingsDlg(Settings sets)
        {
            InitializeComponent();
            s = sets;
            cbCrossover.SelectedItem = s.crossover.ToString();
            cbSelection.SelectedItem = s.selection.ToString();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            switch (cbCrossover.SelectedIndex)
            {
                case 0:
                    s.crossover = Crossover.Cycle;
                    break;
                case 1:
                    s.crossover = Crossover.Greedy;
                    break;
            }
            s.crossoverPercent = (int)nudCrossover.Value;
            if (chbTwins.Checked && !s.eliminateTwins)
                s.eliminateTwins = true;
            else
                s.eliminateTwins = false;
            s.elitePercent = (int)nudElite.Value;
            s.mutationPercent = (int)nudMutation.Value;
            switch (cbSelection.SelectedIndex)
            {
                case 0:
                    s.selection = Selection.Roulette;
                    break;
                case 1:
                    s.selection = Selection.Tournament;
                    break;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
