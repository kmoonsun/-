using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Class StringSet
 * 
 * 프로그램에서 필요한 UI 또는 문자열등을
 * 정의하는 클래스입니다.

 */

namespace Project1_UnivMngSys
{
    class StringSet
    {
        Random rand = new Random();
  
        string[] nameSet =
        {
            "김채원", "김다은", "김은경", "김은지", "김은주"
            ,"이은서", "이은영", "이경희", "이하은", "이하윤"
            ,"박희진", "박혜진", "박현주", "박지혜", "박지민"
            ,"정미경", "정민정", "정미영", "정유진", "정영미"
            ,"이수진", "이하늘", "이미주", "이지은", "이서현"
            ,"김병철", "김대현", "김도현", "김도윤", "김건우"
            ,"박하준", "박재현", "박지원", "박진호", "박민규"
            ,"오민재","오주석", "오승호", "오시우", "오용철"
            ,"남윤우", "남영재", "남우진", "남승호", "남성진"
        };

        public string[] departmentSet =
        {
            "컴퓨터공학과", "정보통신학과", "건축학과", "패션디자인과","간호학과"
        };

        public string IdPicker()
        {
            int[] id = { 2,0,1,0,0,0,0,0 };
           
            for (int i = 3; i < 8; i++)
            {
                id[i] = rand.Next(0, 9);
            }
            // 정수 배열을 string으로 변환.
            string result = string.Join("", id);

            return result;
        }

        public void MenuHeadLine()
        {
            Console.WriteLine("\n\t     .NET 학사관리 프로그램");
        }

        public void MenuLine()
        {
            Console.Write("\n");
            Console.Write("\t───────────────");
            Console.WriteLine("─────────────────");
        }

        public void NoEnterMenuLine()
        { 
            Console.Write("\t───────────────");
            Console.Write("─────────────────");
            Console.Write("─────────────────");
            Console.Write("─────────────────");
            Console.Write("────────");
        }

        public void TabMenuLine()
        {
            Console.Write("\n");
            Console.Write("\t\t───────────────");
            Console.WriteLine("─────────────────");
        }

        public void MenuClear()
        {
            Console.WriteLine("\n\tMsg :: 계속하려면 아무키나 누르세요...");
            Console.ReadLine();
            Console.Clear();
        }


        public bool DeleteConfirm()
        {
            Console.WriteLine("\n\tMsg :: 정말 삭제하시겠습니까? [Y / AnyKey]");
            Console.Write("\t>> ");
            string input = Console.ReadLine();
            
            if (input == "y" || input == "Y")
            {
                Console.WriteLine("\n\t삭제되었습니다!\n");
                MenuClear();
                return true;
            }
            else
                return false;
        }


        public void AddStudentUi()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t   [학생추가]  ");
            Console.WriteLine("\n\t이름, 학번, 학과, 메일, 전화, 장학");
            MenuLine();
        }

        public void SearchStudentUi()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t   [학생검색]  ");
            Console.Write("\n\t학번을 이용하여 학생을 검색합니다.");
            Console.Write("\n\t돌아가려면 Enter 입력.");
            MenuLine();
            Console.Write("\n\t-학번 : ");
        }

        public void SummaryStudentsUi(int total, int countsSchol, int amount)
        {
            float temp = (float)countsSchol / total;
            Console.Clear();
            Console.WriteLine("\n\t\t   [학사현황]  ");
            MenuLine();
            Console.WriteLine("\n\t-전체학생수 : " + total + "명");
            Console.WriteLine("\n\t-장학금총액 : " + amount + "만원");
            Console.WriteLine("\n\t-장학지급건수 : " + countsSchol + "건");
            Console.WriteLine("\n\t-평균수혜수 : " + $"{temp:F2}" + "건");
            Console.WriteLine("\n\t-평균장학금 : " + amount / countsSchol +"만원");
            MenuLine();
            MenuClear();
        }

        // 전체 학생 목록을 출력하고 index를 통해 학생에게 접근.
        public void PrintAllStudentsUi()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t  [전체학생]  ");
            Console.WriteLine("\n\t\t\t  학번 | 이름 | 학과 | 전화번호 | 메일주소\n");
            NoEnterMenuLine();
            Console.WriteLine();
        }

        public void StudentsAccessByIndex()
        {
            Console.WriteLine("\n\n\tMsg :: Index를 입력하면 상세정보로 이동합니다.");
            Console.WriteLine("\n\t돌아가려면 아무키나 입력하세요.");
            MenuLine();
            Console.Write("\t>> ");
        }

        /***********************학생검색결과************************/
       
        public void PrintSearch(Student target)
        {
            Console.Clear();
            Console.Write("\n\t\t   [검색결과]");
            MenuLine();
            Console.WriteLine("\n\t" + target.Name + " 학생의 정보입니다.");
            Console.WriteLine("\n\t-학    번 : " + target.Id);
            Console.WriteLine("\t-학    과 : " + target.Department);
            Console.WriteLine("\t-메일주소 : " + target.Email);
            Console.WriteLine("\t-전화번호 : " + target.Phone);
            Console.Write("\n\t\t   [장학내역]");
            MenuLine();
            StudentManagement.PrintScholarship(target.Id);
            MenuLine();
        }

        // 검색 결과 표시 성공 return true, 아니면 return false.
       /* public int SearchStudentResult(Student target)
        {
           MenuLine();
            if (target == null)
                return -1;
            
            else
            {
               

                //any 나기기, 1 정보변경 2 삭제
                
                bool result = int.TryParse(input, out menuSelect);
                if (menuSelect != -1)
                {
                    switch (menuSelect)
                    {
                        case 1:
                            // 정보변경 메뉴로 이동
                            return 1;
                        case 2:
                            // 학생 삭제 메뉴로 이동
                            return 2;
                        default:
                            return 0;
                    }
                }
                else
                    return 0;
            }
        }  */

        

        public void ChangeId(Student target)
        {
            PrintSearch(target);
            MenuClear();
            //Console.Write(input);
        }
        /***********************학생검색결과END************************/

        public void AddStudentComplete()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t [학생추가 완료]  ");
            Console.Write("\n\t     계속 추가하시겠습니까?");
            MenuLine();
            Console.WriteLine("\n\t1. 계속 추가");
            Console.WriteLine("\n\t2. 메뉴로 돌아간다.");
            MenuLine();
            Console.Write("\t>> ");
        }
        
        public void AddDepartmentUi()
        {
            Console.WriteLine("\n\t\tMsg :: 학과번호 혹은 학과명 입력");
            Console.Write("\t\t>> ");

        }

        public void PrintDeparmentSet()
        {
            int numbering = 1;
            TabMenuLine();
            Console.Write("\t\t 학과번호    학과명");
            TabMenuLine();
           
            foreach (var item in departmentSet)
            {
                Console.Write($"\t\t     {numbering}\t   {item}\n");
                numbering++;
            }
            TabMenuLine();
        }
  
        public string NamePicker()
        {
            int num = rand.Next(0, 44);
            return nameSet[num];
        }

        public string DepartmentPicker()
        {
            int num = rand.Next(0, 4);
            return departmentSet[num];
        }
    }
}
