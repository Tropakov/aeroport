using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace aeroport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            passager Win = new passager();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port Win = new port();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reys Win = new reys();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            samolety Win = new samolety();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vilety Win = new vilety();
            Win.Owner = this;
            this.Hide();
            Win.Show();
        }
    }
}
