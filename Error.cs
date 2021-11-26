using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Class Error
 * 프로그램에서 입력받는 값이 정상인지 확인하는
 * 메소드들을 포함하는 클래스입니다.
 * 
 * Msg...() :: 오류가 발생한 이유를 출력.
 */

namespace Project1_UnivMngSys
{
    class Error
    {
        public bool IsRightName(string name)
        {
            int len = name.Length;
            if (len > 0)
                return true;
            else
                return false;
        }

        public void MsgWrongScholName()
        {
            Console.WriteLine("\n\t\tMsg :: 1자리 이상 문자입력.");
            //Console.Write("\t\t다시입력 >> ");
        }

        public void MsgWrongName()
        {
            Console.WriteLine("\n\tMsg :: 이름은 1자리 이상의 문자입니다.");
            Console.Write("\n\t다시입력 >> ");
        }

        // String을 Int로 오류 없이 변환.
        public int NumberToString(string data)
        {
            int flag;
            bool result = int.TryParse(data, out flag);

            if (result)
                return flag;
            else
                return -1;
        }

        public void MsgWrongScholAmount()
        {
            Console.WriteLine("\n\t\tMsg :: 0원 이상 정수입니다.");
        }

        public void MsgWrongNumber()
        {
            Console.WriteLine("\n\tMsg :: 정수를 입력하세요.");
        }

        // @overloding - 올바른 학번인지만 확인(중복검사 제외) 
        public bool IsRightId(string id)
        {
            // 오류가 발생하면 -1 반환.
            int flag = NumberToString(id);
            if (flag == -1)
                return false;

            int len = id.Length;
            // 학번은 반드시 8자리.
            if (len == 8)
                return true;
            else
                return false;
        }

        public bool IsRightId(string id, List<Student> students)
        {
            // 오류가 발생하면 -1 반환.
            int flag = NumberToString(id);
            if (flag == -1)
                return false;

            int len = id.Length;
            // 학번은 반드시 8자리.
            if (len == 8)
            {   
                // 동일한 학번을 가진 학생 검색.
                foreach(var item in students)
                {
                    if (item.Id == id)
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        public void MsgWrongIdOnlySearch()
        {
            Console.WriteLine("\n\tMsg :: 학번은 반드시 8자리입니다. 혹은 존재하지 않습니다.");
        }

        public void MsgWrongId()
        {
            Console.WriteLine("\n\tMsg :: 동일한 학번이 있거나 8자리가 아닙니다.");
            Console.Write("\n\t다시입력 >> ");
        }

        public bool IsRightPhone(string phone)
        {
            string myPhone = phone;

            // 전화번호에서 '-' 제거하기.
            myPhone = myPhone.Replace("-", string.Empty);

            int len = myPhone.Length;
            // 전화번호는 반드시 11자리. '-' 제외.
            if (len == 11)
                return true;
            else
                return false;
        }

        public void MsgWrongPhone()
        {
            Console.WriteLine("\n\tMsg :: 11자리 번호를 입력하세요.");
            Console.Write("\n\t다시입력 >> ");
        }

        public bool IsRightEmail(string email)
        {
            foreach(var item in email)
            {
                // 이메일 주소에는 반드시 '@' 가 포함되어야 한다.
                if (item == '@')
                    return true;
            }
            return false;
        }

        public void MsgWrongEmail()
        {
            Console.WriteLine("\n\tMsg :: 올바른 형식을 입력하세요. ( address@host )");
            Console.Write("\n\t다시입력 >> ");
        }

        StringSet strSet = new StringSet();
        public bool IsRightDepart(string departmentName)
        {
            foreach(var item in strSet.departmentSet)
            {
                if (item == departmentName)
                    return true;
            }
            return false;
        }

        // @Overloading
        public bool IsRightDepart(int departmentNumber)
        {
            // 메뉴에는 학과번호가 1부터 출력되기 때문에 1을 더해준다.
            int len = strSet.departmentSet.Length + 1;

            // 학과번호가 올바른 번호인지 판단. 
            if (departmentNumber < len && departmentNumber > 0)
                return true;
            else
                return false;
        }

        public void MsgWrongDepart()
        {
            Console.WriteLine("\n\t\tMsg :: 학과번호 혹은 학과명을 정확히 입력하세요.");
        }

        // 숫자로 변환할 수 있는지?
        public bool isRightMenu(string menu)
        {
            int flag;
            bool result = int.TryParse(menu, out flag);

            if (result)
                return true;
            else
                return false;
        }

        public void MsgWrongMenu()
        {
            Console.WriteLine("\n\tMsg :: 올바른 메뉴를 선택하세요.");
        }

        // 장학금 수혜내역 추가해야함.
    }
}
