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
        private Bitmap buffer = null;
        private Graphics panelGraphics = null;
        private Graphics bufferGraphics = null;
        private Rectangle[][] rectangleMatrix;
        private const int ROWS = 240;
        private const int COLUMNS = 320;
        private const int SQUARE_SIDE = 2;
        private int seed = 0;
        public Form1()
        {
            rectangleMatrix = new Rectangle[ROWS][];
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
            for (int i = 0; i < ROWS; i++)
            {
                rectangleMatrix[i] = new Rectangle[COLUMNS];
            }
        }

        private void generateSquares()
        {
            for (int row = 0; row < ROWS; row++)
            {
                //get y coordinate of row
                int y = row * SQUARE_SIDE + panel1.Top;
                for (int col = 0; col < COLUMNS; col++)
                {
                    //get x coordinate of column
                    int x = col * SQUARE_SIDE + panel1.Left;
                    rectangleMatrix[row][col] = new Rectangle(new Point(x, y), new Size(SQUARE_SIDE, SQUARE_SIDE));
                }
            }
        }



        private void paintPanel()
        {
            Random r = new Random(seed);
            // clear the buffer of previous squares
            // using panel1 background color
            bufferGraphics.Clear(panel1.BackColor);

            // draw squares to buffer via its graphic drawing object
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLUMNS; col++)
                {
                    Color color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    bufferGraphics.FillRectangle(new SolidBrush(color), rectangleMatrix[row][col]);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string rule, color;
            int gens;
            rule = comboBox1.Text;
            color = comboBox2.Text;
            if (!int.TryParse(textBox2.Text, out gens))
            {
                MessageBox.Show("Seed or Generation is not a positive integer");
            }
            else
            {
                createGraphicResourses();
                generateSquares();
                paintPanel();
                for (int i = 1; i <= gens; i++)
                {
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
