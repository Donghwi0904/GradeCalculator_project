using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 학점계산기
{
    public partial class Form2 : Form
    {
        Form1 f1 = null;
        private Subject[] subjects;
        public TextBox[] Titles;
        public TextBox[] Credits;
        public ComboBox[] Grades;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
            label8.Text = f1.textBox2.Text;
            
            subjects = new Subject[] // 기본 과목, 학점
            {
                new Subject {Title = "고급시스템프로그래밍",Credit=3},
                new Subject("웹프로그래밍", 3),
                new Subject("컴퓨터구조", 3),
                new Subject("이산수학",3),
                new Subject("네트워크와데이터통신", 3),
                new Subject("멀티미디어응용", 3),
                new Subject("영어", 3),
                new Subject("성서적세계관의확립",1)
            };

            Titles = new TextBox[8]
            {
                Subject1,Subject2,Subject3,Subject4,Subject5,Subject6,Subject7,Subject8
            };

            Credits = new TextBox[8]
            {
                Credit1,Credit2,Credit3,Credit4,Credit5,Credit6,Credit7,Credit8
            };

            Grades = new ComboBox[8]
            {
                Grade1,Grade2,Grade3,Grade4,Grade5,Grade6,Grade7,Grade8
            };

            for (int i = 0; i < subjects.Length; i++)
            {
                Titles[i].Text = subjects[i].Title;
                Credits[i].Text = subjects[i].Credit.ToString();
            }
        }

        private void button_Calculation_Click(object sender, EventArgs e)
        {
            if (PS_3.Checked == true && PS_5.Checked == false) // 4.3만점 기준
            {
                label5.Text = " / 4.30";
                Calculation calculation = new Calculation();
                calculation.Calculation1(this);

                User user = DataManager.Users.Single((x) => x.Id == f1.textBox1.Text);
                DataManager.Users.Remove(user);
                user.Id = f1.textBox1.Text;
                user.Name = f1.textBox2.Text;
                user.GPA = double.Parse(label7.Text);
                DataManager.Users.Add(user);
                DataManager.Save();

                if (File.Exists(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt"))
                {
                    StreamWriter sw = File.CreateText(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt");
                    sw.WriteLine($"사용자 ID : {f1.textBox1.Text}, 이름 : {f1.textBox2.Text}, 학점 : {label7.Text}\n" +
                         $"{Subject1.Text}   | 학점 : {Credit1.Text} | 등급 : {Grade1.Text}\n" +
                         $"{Subject2.Text}              | 학점 : {Credit2.Text} | 등급 : {Grade2.Text}\n" +
                         $"{Subject3.Text}                 | 학점 : {Credit3.Text} | 등급 : {Grade3.Text}\n" +
                         $"{Subject4.Text}                    | 학점 : {Credit4.Text} | 등급 : {Grade4.Text}\n" +
                         $"{Subject5.Text}   | 학점 : {Credit5.Text} | 등급 : {Grade5.Text}\n" +
                         $"{Subject6.Text}            | 학점 : {Credit6.Text} | 등급 : {Grade6.Text}\n" +
                         $"{Subject7.Text}                          | 학점 : {Credit7.Text} | 등급 : {Grade7.Text}\n" +
                         $"{Subject8.Text}      | 학점 : {Credit8.Text} | 등급 : {Grade8.Text}\n");
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt");
                    sw.WriteLine($"사용자 ID : {f1.textBox1.Text}, 이름 : {f1.textBox2.Text}, 학점 : {label7.Text}\n" +
                         $"{Subject1.Text}   | 학점 : {Credit1.Text} | 등급 : {Grade1.Text}\n" +
                         $"{Subject2.Text}              | 학점 : {Credit2.Text} | 등급 : {Grade2.Text}\n" +
                         $"{Subject3.Text}                 | 학점 : {Credit3.Text} | 등급 : {Grade3.Text}\n" +
                         $"{Subject4.Text}                    | 학점 : {Credit4.Text} | 등급 : {Grade4.Text}\n" +
                         $"{Subject5.Text}   | 학점 : {Credit5.Text} | 등급 : {Grade5.Text}\n" +
                         $"{Subject6.Text}            | 학점 : {Credit6.Text} | 등급 : {Grade6.Text}\n" +
                         $"{Subject7.Text}                          | 학점 : {Credit7.Text} | 등급 : {Grade7.Text}\n" +
                         $"{Subject8.Text}      | 학점 : {Credit8.Text} | 등급 : {Grade8.Text}\n");
                    sw.Close();
                }
            }
            else if (PS_5.Checked == true && PS_3.Checked == false) // 4.5만점 기준
            {
                label5.Text = " / 4.50";
                Calculation calculation = new Calculation();
                calculation.Calculation2(this);

                User user = DataManager.Users.Single((x) => x.Id == f1.textBox1.Text);
                DataManager.Users.Remove(user);
                user.Id = f1.textBox1.Text;
                user.Name = f1.textBox2.Text;
                user.GPA = double.Parse(label7.Text);
                DataManager.Users.Add(user);
                DataManager.Save();

                if (File.Exists(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt"))
                {
                    StreamWriter sw = File.CreateText(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt");
                    sw.WriteLine($"사용자 ID : {f1.textBox1.Text}, 이름 : {f1.textBox2.Text}, 학점 : {label7.Text}\n" +
                         $"{Subject1.Text}   | 학점 : {Credit1.Text} | 등급 : {Grade1.Text}\n" +
                         $"{Subject2.Text}              | 학점 : {Credit2.Text} | 등급 : {Grade2.Text}\n" +
                         $"{Subject3.Text}                 | 학점 : {Credit3.Text} | 등급 : {Grade3.Text}\n" +
                         $"{Subject4.Text}                    | 학점 : {Credit4.Text} | 등급 : {Grade4.Text}\n" +
                         $"{Subject5.Text}   | 학점 : {Credit5.Text} | 등급 : {Grade5.Text}\n" +
                         $"{Subject6.Text}            | 학점 : {Credit6.Text} | 등급 : {Grade6.Text}\n" +
                         $"{Subject7.Text}                          | 학점 : {Credit7.Text} | 등급 : {Grade7.Text}\n" +
                         $"{Subject8.Text}      | 학점 : {Credit8.Text} | 등급 : {Grade8.Text}\n");
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText(@"C:\Users\ehdgn\OneDrive\바탕 화면\PJExcel.txt");
                    sw.WriteLine($"사용자 ID : {f1.textBox1.Text}, 이름 : {f1.textBox2.Text}, 학점 : {label7.Text}\n" +
                         $"{Subject1.Text}   | 학점 : {Credit1.Text} | 등급 : {Grade1.Text}\n" +
                         $"{Subject2.Text}              | 학점 : {Credit2.Text} | 등급 : {Grade2.Text}\n" +
                         $"{Subject3.Text}                 | 학점 : {Credit3.Text} | 등급 : {Grade3.Text}\n" +
                         $"{Subject4.Text}                    | 학점 : {Credit4.Text} | 등급 : {Grade4.Text}\n" +
                         $"{Subject5.Text}   | 학점 : {Credit5.Text} | 등급 : {Grade5.Text}\n" +
                         $"{Subject6.Text}            | 학점 : {Credit6.Text} | 등급 : {Grade6.Text}\n" +
                         $"{Subject7.Text}                          | 학점 : {Credit7.Text} | 등급 : {Grade7.Text}\n" +
                         $"{Subject8.Text}      | 학점 : {Credit8.Text} | 등급 : {Grade8.Text}\n");
                    sw.Close();
                }
            }
            else if (PS_3.Checked == false && PS_5.Checked == false) // 만점 기준 없을 때
            {
                MessageBox.Show("좌측 상단의 만점 기준을 선택하세요!", "Error");
            }
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            Subject1.Text = null;
            Subject2.Text = null;
            Subject3.Text = null;
            Subject4.Text = null;
            Subject5.Text = null;
            Subject6.Text = null;
            Subject7.Text = null;
            Subject8.Text = null;
            Credit1.Text = null;
            Credit2.Text = null;
            Credit3.Text = null;
            Credit4.Text = null;
            Credit5.Text = null;
            Credit6.Text = null;
            Credit7.Text = null;
            Credit8.Text = null;
            Grade1.Text = null;
            Grade2.Text = null;
            Grade3.Text = null;
            Grade4.Text = null;
            Grade5.Text = null;
            Grade6.Text = null;
            Grade7.Text = null;
            Grade8.Text = null;
            label7.Text = null;
        }

        private void Menu_Login_Click(object sender, EventArgs e)
        {
            Clear();
            this.Hide();
            new Form1().ShowDialog();
        }

        private void Menu_Fomula_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(학점*이수학점) / 이수학점의 총합 = 평점\n\n※예제(3과목 기준)※\n\n->(4.5*3) + (4.5*3) + (4.5*3) = 평점", "학점 계산법");
        }

        private void Menu_Manage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3(this).ShowDialog();
        }

        private void PS_3_CheckedChanged(object sender, EventArgs e) // 4.3 만점 기준 등급
        {
            foreach (var cb in Grades)
            {
                cb.Items.Clear();
                cb.Items.Add("A+");
                cb.Items.Add("A");
                cb.Items.Add("A-");
                cb.Items.Add("B+");
                cb.Items.Add("B");
                cb.Items.Add("B-");
                cb.Items.Add("C+");
                cb.Items.Add("C");
                cb.Items.Add("C-");
                cb.Items.Add("D+");
                cb.Items.Add("D");
                cb.Items.Add("D-");
                cb.Items.Add("F");
            }
        }
        private void PS_5_CheckedChanged(object sender, EventArgs e) // 4.5만점 기준 등급
        {
            foreach (var cb in Grades)
            {
                cb.Items.Clear();
                cb.Items.Add("A+");
                cb.Items.Add("A");
                cb.Items.Add("B+");
                cb.Items.Add("B");
                cb.Items.Add("C+");
                cb.Items.Add("C");
                cb.Items.Add("D+");
                cb.Items.Add("D");
                cb.Items.Add("F");
            }
        }
    }
}
