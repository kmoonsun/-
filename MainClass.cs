using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * .NET 학사관리 프로그램
 * 20140631_김문선_프로젝트1
 * 
 * [ClASS]
 * - Error              :: 에러관리 및 예외처리
 * - MiainClass         :: 프로그램 진입점
 * - MainMenu           :: 메인 메뉴 혹은 서브 메뉴
 * - Scholarship        :: 장학금 클래스
 * - StringSet          :: 각종 문자열 및 기능 UI
 * - Student            :: 학생 클래스
 * - StudentManagemnet  :: 전체적인 학생 관리 클래스
 * 
 * [MENU]
 * 1. 학생 추가
 * 
 * 2. 학생 검색
 *      ㄴ 1. 정보변경
 *              ㄴ 1. 학번변경
 *              ㄴ 2. 이름변경
 *              ㄴ 3. 전화번호 변경
 *              ㄴ 4. 학과 변경
 *              ㄴ 5. 이메일 변경
 *              ㄴ 6. 장학금 내역 변경
 *                      ㄴ 1. 내역 추가
 *                      ㄴ 2. 내역 변경
 *                      ㄴ 3. 내역 삭제
 *      ㄴ 2. 학생삭제
 *      
 * 3. 현황 검색
 *      ㄴ 1. 학생 현황 요약
 *      ㄴ 2. 전체 학생 보기
 *              ㄴ 학생 INDEX를 통한 학생정보변경(2-1)로 이동.
 *      ㄴ 3. 뒤로가기
 *      
 * 4. 종료
 * 
 */

namespace Project1_UnivMngSys
{
    class MainClass
    {
        // 전체 장학 내역 리스트
        public static List<Scholarship> scolarshipList = new List<Scholarship>();

        static void Main(string[] args)
        {
            Console.Title = ".NET 학사관리 프로그램_20140631 김문선";
            Console.SetWindowSize(110, 52);
            
            // 학생 리스트
            List<Student> stList = new List<Student>();
            // 학생 관리 객체 (반드시 학생리스트를 넣어야 한다.)
            StudentManagement stManage = new StudentManagement(stList);
            // 메인 메뉴
            MainMenu mainMenu = new MainMenu(stManage);
            
            // Menu Loop
            bool loopController = true;
            while(loopController)
            {
                // 메인메뉴가 false를 반환하면 종료.
                loopController = mainMenu.Menu();
                if (!loopController)
                    break;
            }
        }
    }
}
