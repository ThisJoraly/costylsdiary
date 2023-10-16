using System.Collections;
using System.Runtime.InteropServices;

namespace diaryjm;

public class Diary
{
    // Чувак, эта вечеринка отстой. Я ненавижу этих людей
    public static ConsoleKeyInfo key = new ConsoleKeyInfo();
    public static List<Note> notes = new List<Note>();
    public static List<Note> dailyNotes;
    
    static DateTime dt = DateTime.Now;
    static int pos = 1;

    static Note note = new Note("Помыть посуду", "Помыть бы сегодня посуду...", new DateTime(2023, 10, 15),
        new DateTime(2023, 10, 15));

    static Note note2 = new Note("Сдать практы", "Практические как гидра, отрезаешь одну появляются две другие",
        new DateTime(2023, 10, 15), new DateTime(2023, 10, 20));

    static Note note3 = new Note("Забрать посылку", "Посылки???? На почте???? Уже бегу!", new DateTime(2023, 10, 14),
        new DateTime(2023, 10, 23));

    static Note note4 = new Note("Купить подарок", "А кому подарок-то?", new DateTime(2023, 10, 13),
        new DateTime(2023, 10, 23));

    static Note note5 = new Note("Забрать документы", "Наконец-то документы доделали!", new DateTime(2023, 10, 18),
        new DateTime(2023, 10, 25));

    private static bool bl = false;

    public static void init()
    {

        notes.Add(note);
        notes.Add(note2);
        notes.Add(note3);
        notes.Add(note4);
        notes.Add(note5);
    }

    public static void moving(ConsoleKeyInfo cursor)
    {

        do
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("  ");
            if (key.Key == ConsoleKey.UpArrow && pos != 1)
            {
                pos--;
            }
            else if (key.Key == ConsoleKey.DownArrow && pos != notes.Count) //TODO число 4 - на длину массива
            {
                pos++;
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
                dailyNotes = new List<Note>();
                dt = dt.AddDays(-1);
                menu();


            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                dailyNotes = new List<Note>();
                dt = dt.AddDays(1);
                menu();


            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                launchMenu();
            }

            Console.SetCursorPosition(0, pos);
            Console.WriteLine("->");
            key = Console.ReadKey();

        } while (key.Key != ConsoleKey.Enter);

        Console.SetCursorPosition(0, 8); //TODO - под массив (видимо +4)
        choice(pos);
    }

    
    
    
    
    


    public static void launchMenu()
    {
        menu();
        Diary.moving(Diary.key);
    }

    public static void menu()
    {
        Console.Clear();

        Console.WriteLine("Выбрана дата: " + dt.ToString("D"));
        getAllNotes(notes);


    }
    public static void getAllNotes(List<Note> notes)
    {

        int i = 1;
        
        foreach (Note note in notes)
        {
            if (note.date.Date == dt.Date)
            {
                Console.Write("  " + i + ". ");
                Console.WriteLine(note.name);
                
                dailyNotes.Add(note);
                i++;
            }
        }
    }


    public static void choice(int ipos)
    {
        if (notes.Count > 0)
        {
            infoMenu(dailyNotes[pos-1]);
        }
    }
    

    public static void infoMenu(Note note)
    {
        Console.Clear();
        Console.WriteLine(note.name + "\n" + note.text + "\n" + note.date + "\n" + note.deadline);
        ConsoleKeyInfo secondkey = Console.ReadKey();
        if (secondkey.Key == ConsoleKey.Escape)
        {
            launchMenu();
        }

        Console.ReadLine();


    }

    
}
