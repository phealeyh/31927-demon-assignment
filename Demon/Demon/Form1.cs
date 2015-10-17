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
        private const int ROWS = 240;
        private const int COLUMNS = 320;
              
        public Form1()
        {
            //Cells cells = new cells();
            InitializeComponent();
            addItemsToRulesComboBox();
            addItemsToColorsComboBox();
        }

        private void addItemsToColorsComboBox()
        {
            for (int i = 0; i < colors.Length; i++)
            {
                comboBox2.Items.Add(colors[i]);
            }
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

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Random number = new Random(100);
            //get first point (x coordinate is 0)
            //get second point
            //get third point
            //get fourht point (x coordinate is 0)
            //get boundary points of the panel
            Color randomColor = Color.FromArgb(number.Next(0,255), number.Next(0,255), number.Next(0,255));
            Rectangle[,] retangleMatrix = new Rectangle[240,320];
            Rectangle r = new Rectangle(new Point(2,92), new Size(5,5));
            e.Graphics.FillRectangle(new SolidBrush(randomColor), r);
            for(int row = 0; row < 240; row++)
            {
                for(int col = 0; col < 320; col++)
                {
                    
                    //rectangleMatrix[row, col] = new Rectangle(new Point(), new Size(4,4));
                    //show pixel
                }
            }

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
            int seed = 0, gens;
            rule = comboBox1.Text;
            color = comboBox2.Text;
            if (!int.TryParse(textBox1.Text, out seed) || !int.TryParse(textBox2.Text, out gens))
            {
                MessageBox.Show("Seed or Generation is not a positive integer");
            }
            else{
                //start first generation
                for (int i = 1; i <= gens; i++)
                {
                    label6.Text = i.ToString();
                }
            }
        }

        private void generateLine(int i)
        {

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
