
using System.ComponentModel.Design;
using System.Data;

namespace diaryjm
{
    internal class Program
    {
        static DateTime dt = DateTime.Now;


        private static Note note = new Note("Sperma", "Да я люблю сосать член это пенис и на мне жидкая сперма",
            DateTime.Now,
            DateTime.Now.AddDays(1));

        static void Main(string[] args)
        {
            Menu();

            int pos = 1;
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != 1)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow && pos != 4)
                {
                    pos++;
                }
                
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.SetCursorPosition(0, 8);

            switch (pos)
            {
                case 1:
                    InfoMenu(note);
                    break;
                case 2:
                    Console.WriteLine("Bad choice, u lozer");
                    break;
                case 3:
                    Console.WriteLine("Not bad alternative");
                    break;
                case 4:
                    Console.WriteLine("Just why?...");
                    break;
                default:
                    return;
            }
        }
        static void Menu()
        {
            Console.WriteLine("Чем вы хотите заняться сегодня:\n  " +
                              "1. go to college\n  " +
                              "2. go to shop\n  " +
                              "3. go to walk\n  " +
                              "4. stay in bed");
        } 

            

        static void InfoMenu(Note note)
        {
            Console.Clear();
            Console.WriteLine(note.name + "\n" + note.date + "\n" + note.deadline + "\n" + note.text);
            Console.ReadLine();
            Console.Clear();
            
        }
    }
}