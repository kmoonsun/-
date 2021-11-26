using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * class MainMenu
 * 
 * 메인 메뉴 클래스 입니다.
 * Main에서 무한 루프한다.
 * 종료할 경우 return false하여 
 * Main에서 무한루프를 종료한다.
 */
namespace Project1_UnivMngSys
{
    class MainMenu
    {
        StudentManagement stManage;
       
        public MainMenu() { }
        public MainMenu(StudentManagement manage)
        {
            stManage = manage;
            // 장학금 정보 init
            ScholInit();
        }

        ~MainMenu() { Console.WriteLine("\n\tMsg :: 학사관리 프로그램을 종료합니다.\n"); }

        StringSet strSet = new StringSet();
        Error error = new Error();

        public void ScholInit()
        {
            Scholarship data = new Scholarship();
            data.Amount = "300";
            data.Date = "20140320";
            data.ScholName = "학업우수장학금";
            data.ScolId = "20140631";
            data.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data);

            Scholarship data1 = new Scholarship();
            data1.Amount = "150";
            data1.Date = "20180102";
            data1.ScholName = "봉사장학금";
            data1.ScolId = "20140001";
            data1.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data1);

            Scholarship data2 = new Scholarship();
            data2.Amount = "350";
            data2.Date = "20180102";
            data2.ScholName = "교육근로장학금";
            data2.ScolId = "20140002";
            data2.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data2);

            Scholarship data3 = new Scholarship();
            data3.Amount = "550";
            data3.Date = "20180102";
            data3.ScholName = "국가근로장학금";
            data3.ScolId = "20140003";
            data3.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data3);

            Scholarship data4 = new Scholarship();
            data4.Amount = "550";
            data4.Date = "20180102";
            data4.ScholName = "학업우수장학금";
            data4.ScolId = "20140004";
            data4.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data4);

            Scholarship data5 = new Scholarship();
            data5.Amount = "550";
            data5.Date = "20180102";
            data5.ScholName = "국가근로장학금";
            data5.ScolId = "20140005";
            data5.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data5);

            Scholarship data6 = new Scholarship();
            data6.Amount = "250";
            data6.Date = "20180102";
            data6.ScholName = "경진대회우수상";
            data6.ScolId = "20140006";
            data6.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data6);

            Scholarship data7 = new Scholarship();
            data7.Amount = "550";
            data7.Date = "20180102";
            data7.ScholName = "국가근로장학금";
            data7.ScolId = "20140007";
            data7.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data7);

            Scholarship data8 = new Scholarship();
            data8.Amount = "50";
            data8.Date = "20180102";
            data8.ScholName = "멘토장학금";
            data8.ScolId = "20140008";
            data8.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data8);

            Scholarship data9 = new Scholarship();
            data9.Amount = "550";
            data9.Date = "20180102";
            data9.ScholName = "국가근로장학금";
            data9.ScolId = "20140009";
            data9.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data9);

            Scholarship data10 = new Scholarship();
            data10.Amount = "150";
            data10.Date = "20180102";
            data10.ScholName = "봉사우수장학금";
            data10.ScolId = "20140631";
            data10.ScolDepartment = "컴퓨터공학과";
            MainClass.scolarshipList.Add(data10);
        }

        // 현황출력 메뉴 ui
        public void SummaryMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t   [학생 현황]");
            strSet.MenuLine();
            Console.WriteLine("\n\t 1. 학생 현황 요약");
            Console.WriteLine("\n\t 2. 전체 학생 보기");
            Console.WriteLine("\n\t 3. 뒤로가기");
            strSet.MenuLine();
            Console.Write("\t >> ");
            string input = Console.ReadLine();

            // 숫자가 아닌 값 예외처리
            int menuNumber = 10;
            if (error.isRightMenu(input))
                menuNumber = int.Parse(input);
            else
            {
                error.MsgWrongMenu();
                strSet.MenuClear();
                SummaryMenu();
            }

            switch (menuNumber)
            {
                case 1:
                    stManage.SummaryStudents();
                    SummaryMenu();
                    break;
                case 2:
                    stManage.PrintAllStudents();
                    SummaryMenu();
                    break;
                case 3:
                    return;
                default:
                    return;
            }
        }

        // 메인 메뉴 ui
        public bool Menu()
        {
            Console.Clear();
            strSet.MenuHeadLine();
            strSet.MenuLine();
            Console.WriteLine("\n\t 1. 학생 추가");
            Console.WriteLine("\n\t 2. 학생 검색");
            Console.WriteLine("\n\t 3. 현황 검색");
            Console.WriteLine("\n\t 4. 종료");
            strSet.MenuLine();
            Console.Write("\t >> ");
            string input = Console.ReadLine();

            // 숫자가 아닌 값 예외처리
            int menuNumber = 10;
            if (error.isRightMenu(input))
                menuNumber = int.Parse(input);
            else
            {
                error.MsgWrongMenu();
                strSet.MenuClear();
                Menu();
            }

            switch (menuNumber)
            {
                case 1:
                    stManage.AddStudent();
                    break;
                case 2:
                    stManage.SearchStudent();
                    break;
                case 3:
                    SummaryMenu();
                    break;
                case 4: // 종료
                    return false;
                //case 5:
                //    break;
                default:
                    error.MsgWrongMenu();
                    strSet.MenuClear();
                    //Menu();
                    break;
            }
            return true;
        }
    }
}
