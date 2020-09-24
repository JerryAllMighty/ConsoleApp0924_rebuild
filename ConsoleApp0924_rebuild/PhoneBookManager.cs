using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0924_rebuild
{
    class PhoneBookManager
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];
        int curCnt = 0;
        public static PhoneBookManager instance;

        private PhoneBookManager()
        {

        }
          
        public static PhoneBookManager CreateInstance()
        {
            if (instance == null)
                instance = new PhoneBookManager();
                
            return instance;
        }
        

        public void ShowMenu()
        {
            Console.WriteLine("------------------------ 주소록 ---------------------------------------");
            Console.WriteLine("1. 입력  |  2. 목록  |  3. 검색  |  4. 삭제  |   5.정렬    |   6. 종료");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.Write("선택: ");
        }

        public void InputData()
        {
            
                Console.Write("이름: ");
                string name = Console.ReadLine().Trim();
                //if (name == "") or if (name.Length < 1) or if (name.Equals(""))
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("이름은 필수입력입니다");     //리턴 지웠음 문제 생기면 다시 넣어볼 것

                }
                else
                {
                    int dataIdx = SearchName(name);
                    if (dataIdx > -1)
                    {
                        throw new Exception("이미 등록된 이름입니다. 다른 이름으로 입력하세요");
                    }
                }
           

            Console.Write("전화번호: ");
            string phone = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(phone))
            {
                throw new Exception ("전화번호는 필수입력입니다");
            }

            Console.Write("생일: ");
            string birth = Console.ReadLine().Trim();

            if (birth.Length < 1)
                infoStorage[curCnt++] = new PhoneInfo(name, phone);
            else
                infoStorage[curCnt++] = new PhoneInfo(name, phone, birth);
        }

        public void ListData()
        {
            if (curCnt == 0)
            {
                throw new Exception ("입력된 데이터가 없습니다.");
            }

            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
            }
        }

        public void SearchData()
        {
            Console.WriteLine("주소록 검색을 시작합니다......");
            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                throw new Exception ("검색된 데이터가 없습니다");
            }
            else
            {
                infoStorage[dataIdx].ShowPhoneInfo();
            }

            #region 모두 찾기
            //int findCnt = 0;
            //for(int i=0; i<curCnt; i++)
            //{
            //    // ==, Equals(), CompareTo()
            //    if (infoStorage[i].Name.Replace(" ","").CompareTo(name) == 0)
            //    {
            //        infoStorage[i].ShowPhoneInfo();
            //        findCnt++;
            //    }
            //}
            //if (findCnt < 1)
            //{
            //    Console.WriteLine("검색된 데이터가 없습니다");
            //}
            //else
            //{
            //    Console.WriteLine($"총 {findCnt} 명이 검색되었습니다.");
            //}
            #endregion
        }

        private int SearchName()
        {
            Console.Write("이름: ");
            string name = Console.ReadLine().Trim().Replace(" ", "");

            for (int i = 0; i < curCnt; i++)        //이미 이름이 있다는 의미
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        private int SearchName(string name)
        {
            for (int i = 0; i < curCnt; i++)
            {
                if (infoStorage[i].Name.Replace(" ", "").CompareTo(name) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void SortData()
        {
            Console.WriteLine("무엇을 기준으로 정렬하시겠습니까?");
            Console.WriteLine("1. 이름  |  2. 전화번호");
            int answer = int.Parse(Console.ReadLine());
            PhoneInfo[] infoStorage2 = new PhoneInfo[curCnt];
            Array.Copy(infoStorage, infoStorage2, curCnt);

            if (answer == 1)
            {
                PhonenameComparer nameComparer = new PhonenameComparer();
                Array.Sort(infoStorage2, nameComparer);

                foreach (PhoneInfo x in infoStorage2)
                {
                    Console.WriteLine(x.ToString());
                }

            }
            else if (answer == 2)
            {
                PhonenameComparer numberComparer = new PhonenameComparer();
                Array.Sort(infoStorage2, numberComparer);
                foreach (PhoneInfo x in infoStorage2)
                {
                    Console.WriteLine(x.ToString());
                }
            }
            else { throw new Exception ("다른 값을 입력하셨습니다."); }

        }

        public void DeleteData()
        {
            Console.WriteLine("주소록 삭제를 시작합니다......");

            int dataIdx = SearchName();
            if (dataIdx < 0)
            {
                throw new Exception ("삭제할 데이터가 없습니다");
            }
            else
            {
                for (int i = dataIdx; i < curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine("주소록 삭제가 완료되었습니다");
            }
        }

        
    }
}
