using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * class Scholarship
 * 
 * 장학금 클래스입니다.
 * 장학금 클래스는 MainClass에 전역
 * 리스트로 선언됩니다.
 * - 학생들 개인은 장학금리스트를 가지지 않고 통합적으로
 * 관리하도록 하였습니다.
 * 
 */
namespace Project1_UnivMngSys
{
    class Scholarship
    {
        private string m_ScolId;            // 수여자 학번
        private string m_ScolName;          // 장학금 명
        private string m_ScolDepartment;    // 수여 부서
        private string m_date;              // 수여일
        private string m_amount;            // 장학금 액수

        public Scholarship() { }
        public Scholarship(string id ,string name, string department, string date, string amount)
        {
            m_ScolId = id;
            m_ScolName = name;
            m_ScolDepartment = department;
            m_date = date;
            m_amount = amount;
        }

        public string ScolId { get; set; }
        public string ScholName { get; set; }
        public string ScolDepartment { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
    }
}
