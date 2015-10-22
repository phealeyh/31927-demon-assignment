using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon
{
    public partial class Form1 : Form
    {
        private int seed = 0, generation_count = 0;
        private Bitmap buffer = null;
        private Graphics panelGraphics = null;
        private Graphics bufferGraphics = null;
        private const int ROWS = 240;
        private const int COLUMNS = 320;
        private const int SQUARE_SIDE = 5;
        private BackgroundWorker worker;
        private CellMatrix cellMatrix;

        public Form1()
        {
            cellMatrix = new CellMatrix();
            // Define the border style of the form to a dialog box.
            FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            MinimizeBox = false;
            InitializeComponent();
            addItemsToRulesComboBox();
            addItemsToColorsComboBox();
            generateSquares();
            createGraphicResourses();
            paintBitmapBuffer();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_StartSquares;
            worker.ProgressChanged += worker_DisplaySquares;
            worker.RunWorkerCompleted += worker_FinishSquares;

        }

        private void worker_StartSquares(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            int prev_count = generation_count;
            generation_count += (int)e.Argument;
            for (int i = prev_count; i < generation_count; i++)
            {
                //update cellMatrix.getCells()() based on pattern
                cellMatrix.generateNextGeneration(comboBox1.Text);
                paintBitmapBuffer();
                bgWorker.ReportProgress(i + 1);

            }
        }

        private void worker_DisplaySquares(object sender, ProgressChangedEventArgs e)
        {
            if (!worker.CancellationPending)
            {
                panelGraphics.DrawImageUnscaled(buffer, 0, 0);
                label6.Text = e.ProgressPercentage.ToString();
            }
        }


        private void worker_FinishSquares(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!worker.CancellationPending)
            {
                this.Enabled = true;
            }
        }




        public void generateSquares()
        {
            Random r = new Random(seed);

            for (int row = 0; row < ROWS; row++)
            {
                //get y coordinate of row
                int y = row * SQUARE_SIDE + panel1.Top;
                for (int col = 0; col < COLUMNS; col++)
                {
                    //get x coordinate of column
                    int x = col * SQUARE_SIDE + panel1.Left;
                    Cell cell = new Cell(new Point(x, y), new Size(SQUARE_SIDE, SQUARE_SIDE));
                    cell.setStateRandomly(r.Next(0, 7));
                    cellMatrix.getCells[row][col] = cell;
                }
            }
        }

        private void paintBitmapBuffer()
        {
            // clear the buffer of previous squares
            // using panel1 background color
            bufferGraphics.Clear(panel1.BackColor);

            // draw squares to buffer via its graphic drawing object
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Cell rect = cellMatrix.getCells[row][col];
                    string colorName = rect.getCurrentState.ToString();
                    Color color = Color.FromName(colorName);
                    bufferGraphics.FillRectangle(new SolidBrush(color), cellMatrix.getCells[row][col].rectangle);
                }
            }
        }


        private void createGraphicResourses()
        {
            //initialises the graphics resources
            if (panelGraphics != null) panelGraphics.Dispose();
            if (bufferGraphics != null) bufferGraphics.Dispose();
            if (buffer != null) buffer.Dispose();

            // the graphics object allows you to draw to 
            // something (such as a panel or bitmap)
            // panelGraphics sets you up to draw to panel1
            panelGraphics = panel1.CreateGraphics();

            // set up background bitmap
            // and associated graphics drawing object
            buffer = new Bitmap(panel1.Width, panel1.Height);
            bufferGraphics = Graphics.FromImage(buffer);
        }

        private void addItemsToColorsComboBox()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                comboBox2.Items.Add(colors[i]);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void addItemsToRulesComboBox()
        {
            for (int i = 0; i < rules.Length; i++)
            {
                comboBox1.Items.Add(rules[i]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //main form
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            //seed label
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //gens label
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //rules label

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //seed text box

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            //generation text box

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //rules combo box
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reset button
            if (!int.TryParse(textBox1.Text, out seed))
            {
                MessageBox.Show("Seed is not an integer");
            }
            else
            {
                generation_count = 0;
                generateSquares();
                paintBitmapBuffer();
                label6.Text = generation_count.ToString();
                panelGraphics.DrawImageUnscaled(buffer, 0, 0);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            int generation;
            string rule, color;
            rule = comboBox1.Text;
            color = comboBox2.Text;
            if (isInvalidNumber(textBox2.Text, out generation))
            {
                MessageBox.Show(" Generation is not a positive integer or a number greater than or equal to 1");
            }
            else
            {
                //set the patternGenerator rule and color
                //start generation
                if (buffer.Width != this.Width || buffer.Height != this.Height)
                {
                    // in case the  cuserhanged the form size while last running
                    createGraphicResourses();
                }
                this.Enabled = false;
                //pass gens as argument
                worker.RunWorkerAsync(generation);
            }
        }

        private bool isInvalidNumber(string line, out int number)
        {
            return !Int32.TryParse(line, out number) || number < 1;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //colors combo box
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //hash value label
        }


        private void label6_Click(object sender, EventArgs e)
        {
            //generations label

        }

    }
}
