using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FromTund
{
    public partial class Form1 : Form
    {
        SQLConnection conn = new SQLConnection();
        ShowFullData showData = new ShowFullData();
        Resourse set = new Resourse();

        public Form1()
        {
            InitializeComponent();
        }

        int id = 0;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            NimetusBox.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            KogusBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            HindBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();  
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()=="")
            {
                string pilt = "None";
                PiltBox.Image = Image.FromFile(set.GetResourcesFolder()+pilt);
            }
            else
            {
                string pilt = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                PiltBox.Image = Image.FromFile(set.GetResourcesFolder()+pilt);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Кнопка Показывания
        {
            dataGridView1.Rows.Clear();
            List<string[]> data = showData.show();
            foreach (string[] s in data)
            {
                try
                {
                    dataGridView1.Rows.Add(s);
                }
                catch
                {
                    break;
                }
                
            }

            KatBox.Items.Clear();
            conn.open();
            string kat = "Select kat_nimi from kategoria";
            List<string[]> katt = conn.SelectOne(kat);
            conn.close();
            foreach (string[] ss in katt)
            {
                try
                {
                    KatBox.Items.Add(ss[0]);
                }
                catch
                {
                    break;
                }
                
            }
        }

        private void AddButton_Click(object sender, EventArgs e) //Кнопка Добавления
        {
            conn.open();
            int KatInd = KatBox.SelectedIndex + 1;
            string command = "INSERT INTO Tooded(Nimetus, Kogus, Hind, Pilt,kategoria_id) VALUES('" + this.NimetusBox.Text + "','" +
                             this.KogusBox.Text + "','" + this.HindBox.Text + "','" + this.PiltBox.Text + "','"+KatInd+"');";
            conn.Select(command);
            conn.close();
            dataGridView1.Rows.Clear();
            List<string[]> data = showData.show();
            foreach (string[] s in data)
            {
                try
                {
                    dataGridView1.Rows.Add(s);
                }
                catch
                {
                    break;
                }
                
            }
            
        }

        private void DelButton_Click(object sender, EventArgs e) //Кнопка удаления
        {
            conn.open();
            int index = dataGridView1.CurrentRow.Index;
            string number = (string)dataGridView1.Rows[index].Cells[0].Value;
            int idnumber = int.Parse(number);
            string delrow = "DELETE FROM tooded WHERE  ID = '"+idnumber+"';";
            conn.SelectOne(delrow);
            conn.close();
            dataGridView1.Rows.Clear();
            List<string[]> data = showData.show();
            foreach (string[] s in data)
            {
                try
                {
                    dataGridView1.Rows.Add(s);
                }
                catch
                {
                    break;
                }
                
            }
            
        }

        private void KatBox_SelectedIndexChanged(object sender, EventArgs e) //Выпадающее меню
        {
          
        }

        private void button2_Click(object sender, EventArgs e) //Кнопка доавить Картинку
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //Кнопка Обновить
        {
            
        }
    }
}