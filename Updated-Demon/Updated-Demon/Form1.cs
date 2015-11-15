using System;
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
        Bitmap buffer = null;
        Graphics panelGraphics = null;
        Graphics bufferGraphics = null;
        Demon demon = null;
        BackgroundWorker worker;
        const int SQUARE_SIDE = 2;
        const int ROWS = 240;
        const int COLUMNS = 320;

        public demonPanel()
        {
            InitializeComponent();
            demon = new Demon(ROWS,COLUMNS,SQUARE_SIDE,demonPanel1);
            setUpThreading();
        }

        private void setUpThreading()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
