using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * Class Student
 * 
 * 학생 클래스입니다.
 * 모든 예외처리는 Error클래스에 선언되어 있으며
 * Student클래스는 StudentManagemet클래스를 통해 관리됩니다.
 */

namespace Project1_UnivMngSys
{
    class Student
    {
        private string m_id;        // 학번
        private string m_phone;     // 전화번호
        private string m_email;     // 이메일
        private string m_name;      // 이름
        private string m_department;// 학과
        
        public Student() { }

        public Student(string id, string phone, string email, string name, string department)
        {
            m_id = id;
            m_phone = phone;
            m_email = email;
            m_name = name;
            m_department = department;
        }

        // Properties.
        public string Id
        {
            get { return m_id; }

            set
            {
                m_id = value;
            }
        }

        public string Phone
        {
            get { return m_phone; }
            
            set
            {
                m_phone = value;
            }
        }

        public string Email
        {
            get { return m_email; }

            set
            {
                m_email = value;
            }
        }

        public string Name
        {
            get { return m_name; }

            set
            {
                m_name = value;
            }
        }

        public string Department
        {
            get { return m_department; }

            set
            {
                m_department = value;
            }
        }
 
    }//class::student
}//namespace
