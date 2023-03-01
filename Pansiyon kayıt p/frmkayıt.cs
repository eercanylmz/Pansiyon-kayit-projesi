using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting;

namespace Pansiyon_kayıt_p
{
    public partial class frmkayıt : Form
    {
        public frmkayıt()
        {
            InitializeComponent();
        }
        SqlConnection bağlan = new SqlConnection("Data Source=ERCANMONSTER\\SQLEXPRESS01; Initial Catalog=pansiyon;Integrated Security=True");
        private void verilerigoster()
        {
            listView1.Items.Clear();
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Select * From musterıler", bağlan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["İd"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Gtarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["Ctarih"].ToString());

                listView1.Items.Add(ekle);

            }
            bağlan.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmkayıt_Load(object sender, EventArgs e)
        {
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Select * From bosoda", bağlan);
            SqlDataReader oda = komut.ExecuteReader();
            while (oda.Read())
            {
                comboBox1.Items.Add(oda[0].ToString());

            }
            bağlan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bağlan.Open();
            
            
            SqlCommand komut = new SqlCommand("insert into musterıler (İd,Ad,Soyad,OdaNo,Gtarih,Telefon,Hesap,Ctarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "')", bağlan);
            komut.ExecuteNonQuery();
            komut.CommandText ="insert into doluoda (doluyerler) VALUES('"+comboBox1.Text+"')";
            komut.ExecuteNonQuery();
            komut.CommandText=("Delete From bosoda where bosyerler='"+comboBox1.Text+"'");
            komut.ExecuteNonQuery();
            bağlan.Close();
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            /*textBox4.Clear();*/
            textBox5.Clear();
            textBox6.Clear();

        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Delete From musterıler where id= (" + id + ")",bağlan);
            komut.ExecuteNonQuery();
            komut.CommandText = "insert into  bosoda (bosyerler) VALUES('" + comboBox1.Text + "')";
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete From doluoda where doluyerler='" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();
            bağlan.Close();
            verilerigoster();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1 .Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bağlan.Open();
            SqlCommand komut = new SqlCommand("update musterıler set id='" + textBox1.Text.ToString() + "',Ad='" + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "',OdaNo='" + comboBox1 .Text.ToString() + "',Gtarih='" + dateTimePicker1.Text.ToString() + "',Telefon='" + textBox5.Text.ToString() + "',Hesap='" + textBox6.Text.ToString() + "',Ctarih='" + dateTimePicker2.Text.ToString() + "'where id= " + id+ " ", bağlan);
            komut.ExecuteNonQuery();
            bağlan.Close();
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           /* textBox4.Clear();*/
            textBox5.Clear();
            textBox6.Clear();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            bağlan.Open();
            SqlCommand komut = new SqlCommand("Select * From musterıler where Ad like '%" + textBox7.Text + "%'", bağlan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["İd"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Gtarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["Ctarih"].ToString());

                listView1.Items.Add(ekle);

            }
            bağlan.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           textBox4.Text = textBox4.Text.Substring(1) + textBox4.Text.Substring(0,1);
        }
    }
}
