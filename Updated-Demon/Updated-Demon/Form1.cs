using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updated_Demon
{
    public partial class demonPanel : Form
    {
        Demon demon = null;
        BackgroundWorker worker;
        const int SQUARE_SIDE = 2;
        const int ROWS = 240;
        const int COLUMNS = 320;
        const int DEFAULT_SEED = 0, DEFAULT_GENERATION = 100;
        int seed;

        public demonPanel()
        {

            InitializeComponent();
            int panelWidthOut = demonPanel1.Width - (COLUMNS * SQUARE_SIDE);
            int panelHeightOut = demonPanel1.Height - (ROWS * SQUARE_SIDE);
            this.Width -= panelWidthOut;
            this.Height -= panelHeightOut;

            demon = new Demon(ROWS,COLUMNS,SQUARE_SIDE, demonPanel1);
            SetUpThreading();
            AddItemsToColorsCombo();
            AddItemsToRulesCombo();
            colorCombo.SelectedIndex = 0;
            rulesCombo.SelectedIndex = 0;
            seedTextBox.Text = DEFAULT_SEED.ToString();
            generationTextBox.Text = DEFAULT_GENERATION.ToString();
            //set initial seed rectangle state to 0
            demon.Reset(DEFAULT_SEED);
            hashLabel.Text = demon.GetHash().ToString();
        }

        private void AddItemsToColorsCombo()
        {
            IEnumerator ie = Colors.GetColorsEnumerator();
            while (ie.MoveNext())
            {
                colorCombo.Items.Add(ie.Current.ToString());
            }
        }

        private void AddItemsToRulesCombo()
        {
            RulesList rules = new RulesList();
            foreach(string rule in rules.GetColors())
            {
                rulesCombo.Items.Add(rule);
            }

        }

        private void SetUpThreading()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_StartWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        #region backgroundworker methods

        private void worker_StartWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = (BackgroundWorker)sender;

            int workerGenCount = (int)e.Argument;

            for (int gen = 0; gen < workerGenCount; gen++)
            {
                //generate demon and set the rectangle states
                demon.RunGeneration();
                bgWorker.ReportProgress(gen);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //hasnt been cancelled during the process
            if (!worker.CancellationPending)
            {
                //display the actual 2d matrix
                demon.DisplayDemon();
                //update the generation count text
                //toolStripStatusLabelGens.Text = demon.NumGen.ToString();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //hasnt been cancelled during the process
            if (!worker.CancellationPending)
            {
                //activate panel
                demonPanel1.Enabled = true;
                //get calculated hash value from the generated cells
            }
        }

        #endregion

        private void seedTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void generationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void demonPanel1_Paint(object sender, PaintEventArgs e)
        {
            demon.DisplayDemon();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(seedTextBox.Text, out seed))
            {
                MessageBox.Show(" Reset failed with the following error " +
                    "\n" + "Invalid seed value");
            }
            else
            {
                demon.Reset(seed);
                demon.DisplayDemon();
                hashLabel.Text = demon.GetHash().ToString();
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int generation;
            string color, rule;
            rule = rulesCombo.Text;
            color = colorCombo.Text;
            if (isInvalidNumber(generationTextBox.Text, out generation) || generation < 1)
            {
                MessageBox.Show(" Unable to start Demon with the following error " +
                    "\n" + "Generations to run must be greater than 0");
            }
            else
            {
                //run the generations
                this.Enabled = false;
                worker.RunWorkerAsync(generation);
            }
        }
        private bool isInvalidNumber(string line, out int number)
        {
            return !Int32.TryParse(line, out number);
        }
        private void rulesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
