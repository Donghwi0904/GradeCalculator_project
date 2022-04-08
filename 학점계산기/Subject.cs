using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 학점계산기
{
    class Subject : ISubject
    {
        public string Title { get; set; }
        public int Credit { get; set; }
        public Subject() { }
        public Subject(string title, int credit)
        {
            this.Title = title;
            this.Credit = credit;
        }
        public double GradeScore3(string a)
        {
            if (a == "A+") return 4.3;
            else if (a == "A") return 4.0;
            else if (a == "A-") return 3.7;
            else if (a == "B+") return 3.3;
            else if (a == "B") return 3.0;
            else if (a == "B-") return 2.7;
            else if (a == "C+") return 2.3;
            else if (a == "C") return 2.0;
            else if (a == "C-") return 1.7;
            else if (a == "D+") return 1.3;
            else if (a == "D") return 1.0;
            else if (a == "D-") return 0.7;
            else return 0;
        }

        public double GradeScore5(string b)
        {
            if (b == "A+") return 4.5;
            else if (b == "A") return 4.0;
            else if (b == "B+") return 3.5;
            else if (b == "B") return 3.0;
            else if (b == "C+") return 2.5;
            else if (b == "C") return 2.0;
            else if (b == "D+") return 1.5;
            else if (b == "D") return 1.0;
            else return 0;
        }
    }
    interface ISubject // 과목, 이수학점, 등급, 리턴값 호출하는 인터페이스
    {
        double GradeScore3(string a);
        double GradeScore5(string b);
    }
}
