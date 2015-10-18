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
        private int seed = 0;
        private Bitmap buffer = null;
        private Graphics panelGraphics = null;
        private Graphics bufferGraphics = null;
        private Cell[][] rectangleMatrix;
        private const int ROWS = 240;
        private const int COLUMNS = 320;
        private const int SQUARE_SIDE = 2;

        public Form1()
        {
            rectangleMatrix = new Cell[ROWS][];
            initialiseArray();
            // Define the border style of the form to a dialog box.
            FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            MinimizeBox = false;
            InitializeComponent();
            addItemsToRulesComboBox();
            addItemsToColorsComboBox();
            createGraphicResourses();
            generateSquares();
            paintPanel();
        }

        private void initialiseArray()
        {
            for (int row = 0; row < ROWS; row++)
            {
                rectangleMatrix[row] = new Cell[COLUMNS];
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
                    rectangleMatrix[row][col] = new Cell(new Point(x, y), new Size(SQUARE_SIDE, SQUARE_SIDE));
                    rectangleMatrix[row][col].setStateRandomly(r.Next(0, 7));
                }
            }
        }



        private void paintPanel()
        {
            // clear the buffer of previous squares
            // using panel1 background color
            bufferGraphics.Clear(panel1.BackColor);

            // draw squares to buffer via its graphic drawing object
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Cell rect = rectangleMatrix[row][col];
                    string colorName = "" + rect.getCurrentState;
                    Color color = Color.FromName(colorName);
                    bufferGraphics.FillRectangle(new SolidBrush(color), rect.rectangle);
                }
            }
            panelGraphics.DrawImageUnscaled(buffer, 0,0); 
            // draw the buffer to panel1 using its graphic object
        }


        private void createGraphicResourses()
        {
            // microsoft recommends disposing of graphic resources
            // as soon as they are no longer needed.
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
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panelGraphics.DrawImageUnscaled(buffer, 0, 0);
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
                generateSquares();
                paintPanel();
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string rule, color;
            int gens;
            rule = comboBox1.Text;
            color = comboBox2.Text;
            if (!int.TryParse(textBox2.Text, out gens))
            {
                MessageBox.Show(" Generation is not a positive integer");
            }
            else
            {
                //start generation
                for (int i = 1; i <= gens; i++)
                {
                    PatternGenerator pattern = new PatternGenerator(rectangleMatrix);
                    //pattern.generatePattern;
                    label6.Text = i.ToString();
                }
            }
        }

        private bool isPositiveNumber(string line, out int number)
        {
            return Int32.TryParse(line, out number) || number < 0;
        }

          
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //colors combo box

        }


    }
}
