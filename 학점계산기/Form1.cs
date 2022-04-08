using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 학점계산기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.Users.Exists((x) => x.Id == textBox1.Text))
                {
                    MessageBox.Show("환영합니다!");
                    this.Hide();
                    new Form2(this).ShowDialog();
                }
                else
                {
                    MessageBox.Show("존재하지 않는 사용자입니다", "Error");
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void button_Member_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.Users.Exists((x) => x.Id == textBox1.Text))
                {
                    MessageBox.Show("중복되는 ID가 있습니다", "Error");
                }
                else
                {
                    User user = new User()
                    {
                        Id = textBox1.Text,
                        Name = textBox2.Text,
                    };
                    DataManager.Users.Add(user);
                    DataManager.Save();
                    MessageBox.Show("등록 되었습니다");
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void Menu_Explain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("여러분들의 학점을 계산해 주는 프로그램입니다.\n\n참고용으로만 사용하세요!", "프로그램 설명");
        }
    }
}
