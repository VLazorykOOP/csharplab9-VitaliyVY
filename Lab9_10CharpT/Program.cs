using System.Collections;

public class ArrayList : IEnumerable, ICloneable
{
    private object[] array;
    private int capacity;
    private int count;

    public ArrayList()
    {
        capacity = 4;
        array = new object[capacity];
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public object this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public void Add(object item)
    {
        if (count == capacity)
        {
            capacity *= 2;
            Array.Resize(ref array, capacity);
        }
        array[count] = item;
        count++;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return array[i];
        }
    }

    public object Clone()
    {
        ArrayList clonedList = new ArrayList();
        foreach (object item in this)
        {
            clonedList.Add(item);
        }
        return clonedList;
    }

    public void Sort(IComparer comparer)
    {
        Array.Sort(array, 0, count, comparer);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Завдання 1 (Stack)");
            Console.WriteLine("2. Завдання 2 (Queue)");
            Console.WriteLine("3. Завдання 3 (ArrayList, IEnumerable, ICompare, ICloneable)");
            Console.WriteLine("4. Завдання 4 (Hashtable)");
            Console.WriteLine("0. Вихід\n");
            Console.Write("Виберіть завдання: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Програма завершила роботу.");
                    return;
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    Console.ReadKey();
                    break;
                case 4:
                    Task4();
                    break;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void Task1()
    {
        Console.WriteLine("Введіть перший рядок:");
        string s1 = Console.ReadLine();

        Console.WriteLine("Введіть другий рядок:");
        string s2 = Console.ReadLine();

        bool isReverse = IsReverse(s1, s2);

        if (isReverse)
            Console.WriteLine("Рядок s2 є зворотнім до рядка s1.");
        else
            Console.WriteLine("Рядок s2 НЕ є зворотнім до рядка s1.");
        static bool IsReverse(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Stack<char> stack = new Stack<char>();

            // Додаємо символи з першого рядка в стек
            foreach (char c in s1)
            {
                stack.Push(c);
            }

            // Перевіряємо, чи рядок s2 містить символи зі стеку в зворотньому порядку
            foreach (char c in s2)
            {
                if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }

            return true;
        }
    }

    static void Task2()
    {
        // Шлях до файлу з числами
        string filePath = "numbers.txt";

        // Перевірка наявності файлу
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл з числами не знайдено.");
            return;
        }

        // Читання чисел з файлу
        List<int> numbers = new List<int>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (int.TryParse(line, out int num))
                {
                    numbers.Add(num);
                }
            }
        }

        // Розділення чисел на позитивні та негативні
        Queue<int> positiveNumbers = new Queue<int>();
        Queue<int> negativeNumbers = new Queue<int>();
        foreach (int num in numbers)
        {
            if (num >= 0)
            {
                positiveNumbers.Enqueue(num);
            }
            else
            {
                negativeNumbers.Enqueue(num);
            }
        }

        // Виведення чисел у вказаному порядку
        Console.WriteLine("Позитивні числа:");
        while (positiveNumbers.Count > 0)
        {
            Console.WriteLine(positiveNumbers.Dequeue());
        }

        Console.WriteLine("Негативні числа:");
        while (negativeNumbers.Count > 0)
        {
            Console.WriteLine(negativeNumbers.Dequeue());
        }
    }

    public static void Task3()
    {
        // Задача 1: Перевірка, чи є рядок s2 зворотній s1
        bool IsReverse(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[s2.Length - 1 - i])
                    return false;
            }

            return true;
        }

        // Задача 2: Виведення чисел з файлу у вказаному порядку
        void PrintNumbersFromFile(string filePath)
        {
            ArrayList positiveNumbers = new ArrayList();
            ArrayList negativeNumbers = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int number = int.Parse(line);
                    if (number >= 0)
                        positiveNumbers.Add(number);
                    else
                        negativeNumbers.Add(number);
                }
            }

            Console.WriteLine("Positive numbers:");
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Negative numbers:");
            foreach (int number in negativeNumbers)
            {
                Console.WriteLine(number);
            }
        }

        // Приклад для задачі 1
        string s1 = "hello";
        string s2 = "olleh";
        Console.WriteLine("Is s2 reverse of s1? " + IsReverse(s1, s2)); // Очікується true

        // Приклад для задачі 2
        string filePath = "numbers.txt"; // Припустимо, що файл містить числа у кожному рядку
        PrintNumbersFromFile(filePath);
    }

    static Hashtable musicCatalog = new Hashtable();
    static void Task4()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати музичний диск");
            Console.WriteLine("2. Видалити музичний диск");
            Console.WriteLine("3. Додати пісню до музичного диска");
            Console.WriteLine("4. Видалити пісню з музичного диска");
            Console.WriteLine("5. Переглянути вміст каталогу");
            Console.WriteLine("6. Пошук усіх пісень виконавця");
            Console.WriteLine("0. Вихід\n");
            Console.Write("Виберіть опцію: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Програма завершила роботу.");
                    return;
                case 1:
                    AddDisk();
                    break;
                case 2:
                    RemoveDisk();
                    break;
                case 3:
                    AddSong();
                    break;
                case 4:
                    RemoveSong();
                    break;
                case 5:
                    ViewCatalog();
                    break;
                case 6:
                    SearchSongsByArtist();
                    break;
                default:
                    Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }


    static void AddDisk()
    {
        Console.Write("Введіть назву музичного диска: ");
        string diskTitle = Console.ReadLine();
        musicCatalog[diskTitle] = new Hashtable();
        Console.WriteLine("Музичний диск додано до каталогу.");
    }

    static void RemoveDisk()
    {
        Console.Write("Введіть назву музичного диска для видалення: ");
        string diskTitle = Console.ReadLine();
        if (musicCatalog.ContainsKey(diskTitle))
        {
            musicCatalog.Remove(diskTitle);
            Console.WriteLine("Музичний диск видалено з каталогу.");
        }
        else
        {
            Console.WriteLine("Музичний диск з такою назвою не знайдено.");
        }
    }

    static void AddSong()
    {
        Console.Write("Введіть назву музичного диска: ");
        string diskTitle = Console.ReadLine();
        if (musicCatalog.ContainsKey(diskTitle))
        {
            Console.Write("Введіть назву пісні: ");
            string songTitle = Console.ReadLine();
            Console.Write("Введіть виконавця пісні: ");
            string artist = Console.ReadLine();

            Hashtable disk = (Hashtable)musicCatalog[diskTitle];
            disk[songTitle] = artist;
            Console.WriteLine("Пісню додано на музичний диск.");
        }
        else
        {
            Console.WriteLine("Музичний диск з такою назвою не знайдено.");
        }
    }

    static void RemoveSong()
    {
        Console.Write("Введіть назву музичного диска: ");
        string diskTitle = Console.ReadLine();
        if (musicCatalog.ContainsKey(diskTitle))
        {
            Console.Write("Введіть назву пісні для видалення: ");
            string songTitle = Console.ReadLine();

            Hashtable disk = (Hashtable)musicCatalog[diskTitle];
            if (disk.ContainsKey(songTitle))
            {
                disk.Remove(songTitle);
                Console.WriteLine("Пісню видалено з музичного диска.");
            }
            else
            {
                Console.WriteLine("Пісню з такою назвою не знайдено на музичному диску.");
            }
        }
        else
        {
            Console.WriteLine("Музичний диск з такою назвою не знайдено.");
        }
    }

    static void ViewCatalog()
    {
        Console.WriteLine("Каталог музичних дисків:");
        foreach (DictionaryEntry diskEntry in musicCatalog)
        {
            string diskTitle = (string)diskEntry.Key;
            Console.WriteLine($"Музичний диск: {diskTitle}");
            Console.WriteLine("Пісні:");
            Hashtable disk = (Hashtable)diskEntry.Value;
            foreach (DictionaryEntry songEntry in disk)
            {
                string songTitle = (string)songEntry.Key;
                string artist = (string)songEntry.Value;
                Console.WriteLine($"  - {songTitle} ({artist})");
            }
        }
    }

    static void SearchSongsByArtist()
    {
        Console.Write("Введіть виконавця для пошуку: ");
        string artist = Console.ReadLine();
        Console.WriteLine($"Результати пошуку пісень виконавця {artist}:");
        foreach (DictionaryEntry diskEntry in musicCatalog)
        {
            Hashtable disk = (Hashtable)diskEntry.Value;
            foreach (DictionaryEntry songEntry in disk)
            {
                string songTitle = (string)songEntry.Key;
                string songArtist = (string)songEntry.Value;
                if (songArtist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"  - {songTitle} на музичному диску {diskEntry.Key}");
                }
            }
        }
    }
}
