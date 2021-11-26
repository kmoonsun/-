using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
 * Class StudentManagement
 * 
 * 학생관리를 위한 메서드들이 포함된 클래스입니다.
 * 모든 학생은 해당 클래스를 통해 관리됩니다.
 * 
 * MainClass에서 관리하고자 하는 학생 배열을 반드시
 * 배개변수로 받아와야 합니다.
 * - 자체적으로 학생 배열을 생성하지 않습니다.
 * - 생성자를 통해 10명의 학생을 하드코딩했습니다.
 */

namespace Project1_UnivMngSys
{
    class StudentManagement
    {
        List<Student> students;
        Error error = new Error();
        StringSet strSet = new StringSet();

        public StudentManagement() { }

        // 외부에서 관리할 student 리스트를 받아온다. 
        // sutdent 관련 
        public StudentManagement(List<Student> studentSet)
        {
            students = studentSet;
            // init
            students.Add(new Student("20140000", "011-1234-2506", "kyz1101@gmail.com", "김문선", "컴퓨터공학과"));
            students.Add(new Student("20140001", "011-1234-3571", "name@gmail.com", "정예인", "컴퓨터공학과"));
            students.Add(new Student("20140002", "011-1234-4211", "orient@gmail.com", "아이린", "컴퓨터공학과"));
            students.Add(new Student("20140003", "011-1234-0082", "mynoi@gmail.com", "서지수", "컴퓨터공학과"));
            students.Add(new Student("20140004", "011-1234-2114", "creams@gmail.com", "류수정", "컴퓨터공학과"));
            students.Add(new Student("20140005", "011-1234-0900", "chocol@gmail.com", "정은지", "컴퓨터공학과"));
            students.Add(new Student("20140006", "011-1234-1744", "okka2@gmail.com", "슬기", "컴퓨터공학과"));
            students.Add(new Student("20140007", "011-1234-9850", "yoonsna@gmail.com", "조이", "컴퓨터공학과"));
            students.Add(new Student("20140008", "011-1234-3570", "yeins@gmail.com", "유아", "컴퓨터공학과"));
            students.Add(new Student("20140009", "011-1234-9811", "irenlove@gmail.com", "은하", "컴퓨터공학과"));
        }

        /*ㅡㅡㅡㅡㅡㅡㅡㅡㅡAddStudent()ㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/
        public void AddStudent()
        {
            // size : 5
            string[] InputMsg =
            {
                "\n\t-이름입력 : ", "\t-학번입력 : ", string.Empty,// 학과선택
                "\n\t-이메일 : ", "\n\t-전화번호 : ", string.Empty // 장학금
            };

            int count = InputMsg.Length;
            Student newStudent = new Student();

            // 왜 이렇게 만들었는지 기억이 안남...
            strSet.AddStudentUi();
            for (int i = 0; i < count; i++)
            {
                Console.Write(InputMsg[i]);

                switch (i)
                {
                    case 0:
                        newStudent.Name = GetName(); 
                        break;
                    case 1:
                        newStudent.Id = GetId();
                        break;
                    case 2:
                        newStudent.Department = GetDepartment();
                        break;
                    case 3:
                        newStudent.Email = GetEmail();
                        break;
                    case 4:
                        newStudent.Phone = GetPhone();
                        break;
                    case 5:
                        GetScholarship(newStudent.Id, 0);
                        break;
                }
            }
            students.Add(newStudent);

            // 학생을 계속 추가할지 선택
            ContinueAdding();
        }
        
        public void ContinueAdding()
        {
            Console.Clear();
            strSet.AddStudentComplete();

            string select = Console.ReadLine();
            int flag = error.NumberToString(select);
           
            switch (flag)
            {
                // int NumberToString은 오류시 -1 return.
                case -1:
                    error.MsgWrongNumber();
                    strSet.MenuClear();
                    ContinueAdding();
                    break;
                case 1:
                    AddStudent();
                    break;
                case 2:
                    // 함수가 종료되면 새롭게 Menu가 시작된다.
                    break;
                default:
                    error.MsgWrongMenu();
                    strSet.MenuClear();
                    ContinueAdding();
                    break;
            }   
        }
        /*ㅡㅡㅡㅡㅡㅡㅡGet student informationㅡㅡㅡㅡㅡㅡㅡ*/
        public string GetName()
        {
            string strInput = Console.ReadLine();
            if (error.IsRightName(strInput))
                return strInput;
            else
            {
                error.MsgWrongName();
                GetName();
            }

            return string.Empty;
        }
       
        // 현재 다시시도 할 시에 빈 스트링 반환하는 버그 있음...
        public string GetId()
        {
            string strInput = Console.ReadLine();
            if (error.IsRightId(strInput, students))
                return strInput;
            else
            {
                error.MsgWrongId();
                GetId();
            }
            return "error";
        }

        public string IGetDepartment()
        {
            int flag;
            strSet.AddDepartmentUi();
            string strInput = Console.ReadLine();

            // 숫자로 변환을 시도해서 변환 가능하면 true, flag = 변환값.
            // 변환이 불가능하면 flase, flag = 0.
            bool result = int.TryParse(strInput, out flag);
            if(result)
            {
                // 존재하는 학과번호인지 판단.
                if (error.IsRightDepart(flag))
                    // 학과번호는 1번부터 시작. 배열은 0번부터.
                    return strSet.departmentSet[flag-1];
                else
                {
                    error.MsgWrongDepart();
                    IGetDepartment();
                }
            }
            else
            {
                // 존재하는 학과명인지 판단.
                if (error.IsRightDepart(strInput))
                    return strInput;
                else
                {
                    error.MsgWrongDepart();
                    IGetDepartment();
                }
            }
            return string.Empty;
        }

        public string GetDepartment()
        {
            strSet.PrintDeparmentSet();
            return IGetDepartment();
        }

        public string GetEmail()
        {
            string strInput = Console.ReadLine();
            if (error.IsRightEmail(strInput))
                return strInput;
            else
            {
                error.MsgWrongEmail();
                GetEmail();
            }
            return string.Empty;
        }

        public string GetPhone()
        {
            string strInput = Console.ReadLine();
            if (error.IsRightPhone(strInput))
                return strInput;
            else
            {
                error.MsgWrongPhone();
                GetPhone();
            }
            return string.Empty;
        }
            
        public string[] GetScholarshipUi()
        {
            // 장학금명, 수여부서, 수여일, 장학금 액수
            string[] arrSchol = new string[4];
            string strInput;
            int len = arrSchol.Length;

            strSet.TabMenuLine();
            Console.Write("\t\t        장학금 입력");
            strSet.TabMenuLine();

            for (int i = 0; i < len; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("\t\t-장학금명 : ");
                        strInput = Console.ReadLine();
                        if (error.IsRightName(strInput))
                            arrSchol[i] = strInput;
                        else
                        {
                            error.MsgWrongScholName();
                            --i; continue;
                        }
                        break;
                    case 1:
                        Console.Write("\t\t-수여부서 : ");
                        strInput = Console.ReadLine();
                        if (error.IsRightName(strInput))
                            arrSchol[i] = strInput;
                        else
                        {
                            error.MsgWrongScholName();
                            --i; continue;
                        }
                        break;
                    case 2:
                        Console.Write("\t\t-수여일(yyyymmdd) : ");
                        strInput = Console.ReadLine();
                        if (error.IsRightName(strInput))
                            arrSchol[i] = strInput;
                        else
                        {
                            error.MsgWrongScholName();
                            --i; continue;
                        }
                        break;
                    case 3:
                        Console.Write("\t\t-액수 : ");
                        strInput = Console.ReadLine();
                        if (error.NumberToString(strInput) == -1)
                        {
                            error.MsgWrongScholAmount();
                            --i; continue;
                        }
                        else 
                            arrSchol[i] = strInput;
                        
                        break;
                }
            }
            return arrSchol;
        }

        public Scholarship GetScholarship(string currentId, int directAddFlag)
        {
            Scholarship schol = new Scholarship();
            string[] arr = GetScholarshipUi();

            schol.ScholName = arr[0];
            schol.ScolDepartment = arr[1];
            schol.Date = arr[2];
            schol.Amount = arr[3];
            schol.ScolId = currentId;

            // 전역 리스트인 통합 장학금 리스트에 등록 해줘야함.
            if (directAddFlag == 0)
                MainClass.scolarshipList.Add(schol);
            return schol;
        }

        /*ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ학생검색ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/
        public Student SearchStudentById(string id)
        {
            Student target = null;

            foreach (var item in students)
            {
                if (item.Id == id)
                {
                    target = item;
                    break;
                }
            }
            // 대상이 없을 경우 return null
            return target;
        }

        public void SearchStudent()
        {
            Student target = null;
            string targetId = string.Empty;
            strSet.SearchStudentUi();

            targetId = Console.ReadLine();
            // -1 이면 상위 메뉴로 이동.
            if(error.isRightMenu(targetId))
            {
                // return target Student
                target = SearchStudentById(targetId);

                if (target == null)
                {
                    error.MsgWrongIdOnlySearch();
                    strSet.MenuClear();
                    SearchStudent();
                }

                if (int.Parse(targetId) == -1)
                    return;
                else
                {
                    DataChangeSelect(target);
                }
            }
        }

        public void DataChangeSelect(Student target)
        {
            if (error.IsRightId(target.Id))
            {
                // -1 실패, 0 나기기, 1 정보변경 2 삭제
                strSet.PrintSearch(target);
                Console.Write("\t1. 정보 변경    |    ");
                Console.WriteLine("2. 학생 삭제");
                Console.WriteLine("\n\t돌아가려면 아무키나 입력하세요.");
                strSet.MenuLine();
                Console.Write("\t>> ");

                string input = Console.ReadLine();


                if (error.isRightMenu(input))
                {
                    int menuBranch = int.Parse(input);
                    switch (menuBranch)
                    {
                        case 1:
                            ChangeData(target);
                            break;
                        case 2:
                            DeleteStudent(target);
                            SearchStudent();
                            break;
                    }
                }
                else
                    SearchStudent();
            }
        }

    /*ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ정보변경ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/

    public void ChangeData(Student target)
        {
            Console.Clear();
            Console.Write("\n\t\t   [정보변경]");
            strSet.MenuLine();
            Console.WriteLine("\n\t 1. 학번 변경");
            Console.WriteLine("\n\t 2. 이름 변경");
            Console.WriteLine("\n\t 3. 전화번호 변경");
            Console.WriteLine("\n\t 4. 학과 변경");
            Console.WriteLine("\n\t 5. 이메일 변경");
            Console.WriteLine("\n\t 6. 장학금 내역 변경");
            strSet.MenuLine();
            Console.WriteLine("\n\t뒤로가려면 아무키나 누르세요.\n");
            Console.Write("\t>> ");

            string input = Console.ReadLine();

            // 이유는 모르겠으나 error class를 사용할 수 없다 ㅜㅜ
            int flag=0;
            bool result = int.TryParse(input, out flag);

            if (result)
            {
                switch (flag)
                {
                    case 1: // 학번 변경
                        ChangeId(target);
                        ChangeData(target);
                        break;
                    case 2: // 이름 변경
                        ChangeName(target);
                        ChangeData(target);
                        break;
                    case 3: // 전화번호 변경
                        ChangePhone(target);
                        ChangeData(target);
                        break;
                    case 4: // 학과 변경
                        ChangeDepartment(target);
                        ChangeData(target);
                        break;
                    case 5: // 이메일 변경
                        ChangeEmail(target);
                        ChangeData(target);
                        break;
                    case 6: // 장학금 내역 변경
                        ChangeScolarship(target);
                        ChangeData(target);
                        break;
                    default:
                        ChangeData(target);
                        break;
                }
            }
            else
                DataChangeSelect(target);
        }

        public void ChangeDepartment(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t학과를 변경합니다.");
            Console.WriteLine("\n\t현재 학과는 " + target.Department + "입니다.");
            strSet.MenuLine();

            target.Department = GetDepartment();
            Console.WriteLine("\n\tMsg :: 변경을 완료했습니다!");
            strSet.MenuClear();
        }

        public void ChangeEmail(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t메일주소를 변경합니다.");
            Console.WriteLine("\n\t현재 메일주소는 " + target.Email + "입니다.");
            strSet.MenuLine();
            Console.Write("\t>> ");

            target.Email = GetEmail();
            Console.WriteLine("\n\tMsg :: 변경을 완료했습니다!");
            strSet.MenuClear();
        }

        public void ChangePhone(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t전화번호를 변경합니다.");
            Console.WriteLine("\n\t현재 전화번호는 " + target.Phone + "입니다.");
            strSet.MenuLine();
            Console.Write("\t>> ");

            target.Phone = GetPhone();
            Console.WriteLine("\n\tMsg :: 변경을 완료했습니다!");
            strSet.MenuClear();
        }

        public void ChangeName(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t이름을 변경합니다.");
            Console.WriteLine("\n\t현재 이름은 " + target.Name + "입니다.");
            strSet.MenuLine();
            Console.Write("\t>> ");

            target.Name = GetName();
            Console.WriteLine("\n\tMsg :: 변경을 완료했습니다!");
            strSet.MenuClear();
        }

        public void DeleteStudent(Student target)
        {
            // delete 를 수락했을 경우 true
            if (strSet.DeleteConfirm())
            {
                // 학생정보 삭제
                students.Remove(target);
                // 장학데이터 삭제
                DeleteScolarshipData(target.Id);
            }
            else
                DataChangeSelect(target);
        }

        public void ChangeScolarship(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t\t장학내역을 변경합니다.");
            Console.WriteLine("\n\t\t뒤로가려면 아무키나 누르세요.");
            strSet.TabMenuLine();
            Console.WriteLine("\n\t\t1. 내역 추가");
            Console.WriteLine("\n\t\t2. 내역 변경");
            Console.WriteLine("\n\t\t3. 내역 삭제");
            strSet.TabMenuLine();
            Console.Write("\t\t>> ");

            string input = Console.ReadLine();
            int menuSelect;
            bool result = int.TryParse(input, out menuSelect);
            if (menuSelect != -1)
            {
                switch (menuSelect)
                {
                    case 1:// 내역추가
                        GetScholarship(target.Id, 0);
                        ChangeScolarship(target);
                        break;
                    case 2:// 내역변경
                        // 이건 바꾸려는 대상 장학금 정보 입력받고 덮어씌우기
                        ModifyScolarshipData(target.Id);
                        ChangeScolarship(target);
                        break;
                    case 3:// 내역삭제  
                        DeleteScolarshipDataUi(target.Id);
                        ChangeScolarship(target);
                        break;
                    default:
                        return;
                }
            }
            else
                return;

        }

        public void ModifyScolarshipData(string targetId)
        {
            strSet.TabMenuLine();
            Console.WriteLine("\n\t\t변경할 장학정보의 번호를 입력하세요.");
            strSet.TabMenuLine();
            Console.Write("\t\t>> ");

            string input = Console.ReadLine();
            int number = error.NumberToString(input);
            if (number == -1)
            {
                Console.WriteLine("\n\t\t!올바른 번호를 입력하세요.");
                Console.Write("\t"); strSet.MenuClear();
            }

            else
            {
                // 존재하는 장학 정보인지 확인하는 조건.
                if (CountScholarshipData(targetId) >= number && 0 < number)
                {
                    MainClass.scolarshipList[SelectScholarshipByNumber(number, targetId)] = GetScholarship(targetId, 1);
                }
                else
                {
                    Console.WriteLine("\n\t\t!올바른 번호를 입력하세요.");
                    Console.Write("\t"); strSet.MenuClear();
                }
            }
        }

        public int CountScholarshipData(string targetId)
        {
            int count = 0;
            foreach(var item in MainClass.scolarshipList)
            {
                if (item.ScolId == targetId)
                    count++;
            }

            return count;
        }

        public void DeleteScolarshipDataUi(string targetId)
        {
            strSet.TabMenuLine();
            Console.WriteLine("\n\t\t삭제할 장학정보의 번호를 입력하세요.");
            Console.WriteLine("\n\t\t0을 입력하면 전체 삭제됩니다.");
            strSet.TabMenuLine();
            Console.Write("\t\t>> ");

            string input = Console.ReadLine();
            int number = error.NumberToString(input);
            if (number != -1)
            {
                if (number == 0)
                {
                    DeleteScolarshipData(targetId);
                    return;
                }
                // 장학금 번호를 입력하면 삭줴~
                MainClass.scolarshipList.RemoveAt(SelectScholarshipByNumber(number, targetId));
            }
        }


        // 메뉴에서 보여지는 인덱스와 실제 장학금 인덱스를 대조하여 위치를 리턴.
        public int SelectScholarshipByNumber(int index, string targetId)
        {
            List<Scholarship> temp = MainClass.scolarshipList;
            int targetIndex = 0, count = 0; index--; // 사용자에게는 1부터 보여진다.

            // 전역 배열이 입력된 순서로 있는 배열의 index를 찾는다.
            foreach (var item in temp)
            {
                if (item.ScolId == targetId)
                {
                    if (targetIndex == index)
                        break;
                    else
                        targetIndex++;
   
                }
                count++;
            }

            return count;
        }

        public void DeleteScolarshipData(string targetId)
        {
            for (int i = MainClass.scolarshipList.Count-1; i >=0; i--)
            {
                if (MainClass.scolarshipList[i].ScolId == targetId)
                    MainClass.scolarshipList.RemoveAt(i);
            }
        }

        // 기존의 id, 새로운 id
        public void ChangeScolarshipId(string currentId, string newId)
        {
            foreach(var item in MainClass.scolarshipList)
            {
                if (item.ScolId == currentId)
                    item.ScolId = newId;
            }
        }

        public void ChangeId(Student target)
        {
            strSet.PrintSearch(target);
            Console.WriteLine("\n\t학번을 변경합니다.");
            Console.WriteLine("\n\t현재 학번은 " + target.Id + "입니다.");
            strSet.MenuLine();
            Console.Write("\t>> ");

            string currentId = target.Id;
            target.Id = GetId();
            string newId = target.Id;
            ChangeScolarshipId(currentId, newId);
        }


        

        // 장학금 출력
        public static void PrintScholarship(string id)
        {
            bool findValue = false;
            int count = 1;
            // 주의! 전역 장학금 리스트에서 data를 가져온다.
            Console.WriteLine("\t[장학금명] [수여학과] [수여일자] [금액]\n");
            
            foreach (var item in MainClass.scolarshipList)
            {
                if (item.ScolId == id)
                {
                    findValue = true;
                    Console.Write("\t["+ count + "] ");
                    Console.Write(item.ScholName);
                    Console.Write(" | " + item.ScolDepartment);
                    Console.Write(" | " + item.Date);
                    Console.WriteLine(" | " + item.Amount + "만원");
                    count++;
                }
            }

            if (!findValue)
                Console.WriteLine("\t장학정보가 없습니다.");
        }

        /*ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ학생 현황ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ*/
        public void SummaryStudents()
        {
            // 학생의 수
            int total = students.Count();
            // 장학금 지급 건수
            int countSchol = MainClass.scolarshipList.Count();
            // 장학금 총액 (전역 장학 리스트)
            int amount = 0;
            foreach(var item in MainClass.scolarshipList)
            {
                amount += int.Parse(item.Amount);
            }

            strSet.SummaryStudentsUi(total, countSchol, amount);
        }

        // 전체출력 후 index로 접근 
        public void PrintAllStudents()
        {
            strSet.PrintAllStudentsUi();    // 텍스트
            int index = 1;
            foreach(var item in students)
            {
                Console.Write("\t" + index + ". " + item.Id);
                Console.Write("\t" + item.Name);
                Console.Write("\t" + item.Department);
                Console.Write("\t" + item.Phone);
                Console.WriteLine("\t" + item.Email);
                index++;
            }

            strSet.NoEnterMenuLine();       // 텍스트
            strSet.StudentsAccessByIndex(); // 텍스트
            string input = Console.ReadLine();
            // if 입력한 숫자가 index라면 상세정보 이동.
            // else 함수 종료

            if (error.isRightMenu(input))
            {
                int parseInput = int.Parse(input);
                // input이 index 범위 안에 있다면...
                if ((parseInput <= index-1) && (0 < parseInput))
                {
                    Student target = students[parseInput - 1];
                    DataChangeSelect(target);
                    PrintAllStudents();
                }
                else
                    return;
            }
            else
                return;
        }
    }//class::StudentManagement
}//namespace
