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
        public Form1()
        {
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
            //main paint panel

        }

        private void label6_Click(object sender, EventArgs e)
        {
            //generations label

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
            string rules, colors;
            int seed, gens;
            rules = comboBox1.Text;
            colors = comboBox2.Text;
            if (!int.TryParse(textBox1.Text, out seed) && !int.TryParse(textBox2.Text, out gens))
            {
                MessageBox.Show("Seed or Generation is not a number");
            }
            //start button
            else{
                //execute code here and start the automata with the given parameters
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //colors combo box

        }

        private void label5_Click(object sender, EventArgs e)
        {
            //hash value label
        }
    }
}
