using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0924_rebuild
{

    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookManager manager = PhoneBookManager.CreateInstance();      //new를 한 번만 하게 하자
            try
            {
                while (true)
                {       //캐치로 던진 에러 받아보자
                    manager.ShowMenu();
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: manager.InputData(); break;
                        case 2: manager.ListData(); break;
                        case 3: manager.SearchData(); break;
                        case 4: manager.DeleteData(); break;
                        case 5: manager.SortData(); break;
                        case 6: Console.WriteLine("프로그램을 종료합니다"); return;
                    }
                }
            }

            catch (Exception err)
            { Console.WriteLine(err.Message); }       //예외 처리하고나서 바로 꺼진다 블록을 어디까지 잡아야 다시 메뉴가 실행될까

        }
    }
}
