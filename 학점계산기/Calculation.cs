using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 학점계산기
{
    class Calculation : Subject, ICalculation // 학점 계산하는 메서드 정의
    {
        Form2 f2 = null;
        public void Calculation1(Form2 form2)
        {
            f2 = form2;
            double totalGrades = 0;
            int totalCredits = 0;
            for (int i = 0; i < f2.Grades.Length; i++)
            {
                if (f2.Grades[i].SelectedItem != null)
                {
                    int gpa = int.Parse(f2.Credits[i].Text);
                    totalCredits += gpa;
                    totalGrades += gpa * GradeScore3(f2.Grades[i].SelectedItem.ToString());
                }
            }
            f2.label7.Text = (totalGrades / totalCredits).ToString("0.00");
        }
        public void Calculation2(Form2 form2)
        {
            f2 = form2;
            double totalGrades = 0;
            int totalCredits = 0;
            for (int i = 0; i < f2.Grades.Length; i++)
            {
                if (f2.Grades[i].SelectedItem != null)
                {
                    int gpa = int.Parse(f2.Credits[i].Text);
                    totalCredits += gpa;
                    totalGrades += gpa * GradeScore5(f2.Grades[i].SelectedItem.ToString());
                }
            }
            f2.label7.Text = (totalGrades / totalCredits).ToString("0.00");
        }
    }


    interface ICalculation // 학점 계산하는 메서드 호출
    {
        void Calculation1(Form2 form2);
        void Calculation2(Form2 form2);
    }
}
