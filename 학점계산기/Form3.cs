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
    public partial class Form3 : Form
    {
        Form2 f2 = null;
        public Form3(Form2 form2)
        {
            InitializeComponent();
            f2 = form2;
            textBox3.Text = f2.label7.Text;
            dataGridView1.DataSource = DataManager.Users;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.Users.Exists((x) => x.Id == textBox1.Text))
                {
                    MessageBox.Show("사용자 ID가 겹칩니다");
                }
                else
                {
                    User user = new User()
                    {
                        Id = textBox1.Text,
                        Name = textBox2.Text,
                        GPA = double.Parse(textBox3.Text)
                    };
                    DataManager.Users.Add(user);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Users;
                    DataManager.Save();
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void button_Change_Click(object sender, EventArgs e)
        {
            try
            {
                User user = DataManager.Users.Single((x) => x.Id == textBox1.Text);
                user.Name = textBox2.Text;
                user.GPA = double.Parse(textBox3.Text);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Users;
            }
            catch (Exception exception)
            {
                MessageBox.Show("존재하지 않는 사용자입니다");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                User user = DataManager.Users.Single((x) => x.Id == textBox1.Text);
                DataManager.Users.Remove(user);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Users;
                DataManager.Save();
            }
            catch (Exception exception)
            {
                MessageBox.Show("존재하지 않는 사용자입니다");
            }
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                User user = dataGridView1.CurrentRow.DataBoundItem as User;
                textBox1.Text = user.Id;
                textBox2.Text = user.Name;
                textBox3.Text = user.GPA.ToString();
            }
            catch (Exception exception)
            {
            }
        }
    }
}
