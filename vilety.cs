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
    public partial class vilety : Form
    {
        public vilety()
        {
            InitializeComponent();
            getinfo();
        }

        private void getinfo()
        {
            string query = "SELECT id_vilet, id_reys, time_vilet, id_samolet FROM vilety";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=aero;User=root;Password=2633;");
                MySqlCommand cmd = new MySqlCommand("insert into vilety(id_vilet, id_reys, time_vilet, id_samolet) value('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "');", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка внесения данных!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите изменить данные?", "Подтвердите свои действия", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            try
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=aero;User=root;Password=2633;");
                MySqlCommand cmd = new MySqlCommand("update vilety set id_vilet ='" + textBox1.Text + "', id_reys = '" + textBox2.Text + "', time_vilet = '" + textBox3.Text + "', id_samolet = '" + textBox4.Text + "' where id_vilet =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";", conn);
                Console.WriteLine("update vilety set id_vilet ='" + textBox1.Text + "', id_reys = '" + textBox2.Text + "', time_vilet = '" + textBox3.Text + "', id_samolet = '" + textBox4.Text + "' where id_vilet =" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";");
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                getinfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите удалить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string del = "delete from vilety where id_vilet = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ";";
                    do_Action(del);
                    getinfo();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
        }
        private void do_Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Произшла непредвиденная ошибка!");
            }
        }
    }
}
