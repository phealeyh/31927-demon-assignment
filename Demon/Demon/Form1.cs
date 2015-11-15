using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demon
{
    enum Numbers { zero, one, two, three };

    public partial class Form1 : Form
    {
        String rule;
        private int seed = 0, generation_count = 0;
        private Bitmap buffer = null;
        private Graphics panelGraphics = null;
        private Graphics bufferGraphics = null;
        private const int MAX_STATES = 8;
        private const int ROWS = 240;
        private const int COLUMNS = 320;
        //change to 4
        private const int SQUARE_SIDE = 2;
        private BackgroundWorker worker;
        private PatternGenerator patternGenerator;
        private Rectangle[,] rectangles;
        private Color[] palette;
        public Form1()
        {
            rectangles = new Rectangle[ROWS, COLUMNS];
            patternGenerator = new PatternGenerator(ROWS,COLUMNS);
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
                if (Rule.Orthogonal.ToString().Equals(rule))
                {
                    patternGenerator.generateOrthogonalPattern();
                }
                else if (Rule.Diagonal.ToString().Equals(rule))
                {
                    patternGenerator.generateDiagonalPattern();
                }
                else //alternating
                {
                    patternGenerator.generateOrthogonalPattern();
                    rule = Rule.Diagonal.ToString();
                    patternGenerator.generateDiagonalPattern();
                    rule = Rule.Alternating.ToString();
                }
                    
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
                label5.Text = getCellHash().ToString();
            }
        }




        private void generateSquares()
        {
            //find out color here and use that as pallette
            Random rand = new Random(seed);
            for (int row = 0; row < ROWS; row++)
            {
                //get y coordinate of row
                int y = row * SQUARE_SIDE;
                for (int col = 0; col < COLUMNS; col++)
                {
                    int state = rand.Next(MAX_STATES);
                    //get x coordinate of column
                    int x = col * SQUARE_SIDE;
                    Rectangle r = new Rectangle(new Point(x, y),
                        new Size(SQUARE_SIDE, SQUARE_SIDE));
                    rectangles[row, col] = r;
                    patternGenerator.getCells[row, col].setRectangle(r);
                    patternGenerator.getCells[row,col].setStateRandomly(state);
                    patternGenerator.getNextGeneration[row, col].setRectangle(r);
                    patternGenerator.getNextGeneration[row, col].setStateRandomly(state);
                }
            }
            string hash = getCellHash().ToString();
            label5.Text = hash;
        }


        private uint getCellHash()
        {
            int state, hash = 0;
            for(int column = 0; column < COLUMNS; column++)
            {
                for(int row = 0; row < ROWS; row++)
                {
                    state = (int)patternGenerator.getCells[row,column].getCurrentState;
                    hash ^= ((row * column + 1) * (state + 1));
                }
            }
            return (uint)hash;
        }





        private void paintBitmapBuffer()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Rectangle rect = patternGenerator.getCells[row, col].rectangle;
                    int state =(int) patternGenerator.getCells[row,col].getCurrentState;
                    Color color = palette[state];
                    bufferGraphics.FillRectangle(new SolidBrush(color), rect);
                }
            }
        }


        private void createGraphicResourses()
        {
            if (panelGraphics != null) panelGraphics.Dispose();
            if (bufferGraphics != null) bufferGraphics.Dispose();
            if (buffer != null) buffer.Dispose();

            panelGraphics = panel1.CreateGraphics();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reset button
            if (!int.TryParse(textBox1.Text, out seed))
            {
                MessageBox.Show(" Reset failed with the following error " +
                    "\n" + "Invalid seed value");
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
            string color;
            rule = comboBox1.Text;
            color = comboBox2.Text;
            if (isInvalidNumber(textBox2.Text, out generation) || generation < 1)
            {
                MessageBox.Show(" Unable to start Demon with the following error " +
                    "\n" + "Generations to run must be greater than 0" );
            }
            else
            {
                if (buffer.Width != this.Width || buffer.Height != this.Height)
                {
                    createGraphicResourses();
                }
                this.Enabled = false;
                worker.RunWorkerAsync(generation);
            }
        }

        private bool isInvalidNumber(string line, out int number)
        {
            return !Int32.TryParse(line, out number);
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String color = comboBox2.Text;
            String rainbow  = colors[(int)Numbers.zero];
            String black_white = colors[(int)Numbers.one];
            String aztec = colors[(int)Numbers.two];
            String caramel = colors[(int)Numbers.three];
            if (color.Equals(rainbow))
            {
                //set rainbow color
                palette = new Color[MAX_STATES]{Color.Red,Color.Green,Color.Blue,
                    Color.LightGreen,Color.DarkGreen,Color.Orange,Color.Purple,Color.Yellow};
            }
            else if (color.Equals(black_white))
            {
                //set black/white scheme
                palette = new Color[MAX_STATES]{Color.White,Color.Black,Color.White,
                    Color.Black,Color.White,Color.Black,Color.White,Color.Black};
            }
            else if (color.Equals(aztec))
            {
                //set aztec
                palette = new Color[MAX_STATES]{Color.Orange,Color.Aqua,Color.Purple,
                    Color.Pink,Color.Orange,Color.Aqua,Color.Purple,Color.Pink};
            }

            else if (color.Equals(caramel))
            {
                //set caramel
                palette = new Color[MAX_STATES]{Color.Black,Color.Yellow,Color.Orange,
                    Color.Gold,Color.Black,Color.Yellow,Color.Orange,Color.Gold};
            }


            if (bufferGraphics != null)
            {
                paintBitmapBuffer();
                panelGraphics.DrawImageUnscaled(buffer, 0, 0);
            }

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
