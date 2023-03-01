using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pansiyon_kayıt_p
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Substring(1) + textBox3.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "kullanıcı" && textBox2.Text == "kullanıcı")
            {
                frmkayıt frm = new frmkayıt();
                frm.Show();  // form2 göster diyoruz
                this.Hide();   // bu yani form1 gizle diyoruz
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                //checkBox işaretli ise
                if (checkBox1.Checked)
                {
                    //karakteri göster.
                    textBox2.PasswordChar = '\0';
                }
                //değilse karakterlerin yerine * koy.
                else
                {
                    textBox2.PasswordChar = '*';
                }
            }
        }
    }
}
