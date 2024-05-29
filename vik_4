using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //////////////////////////
        Console.WriteLine("Task1: ");
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/Task1.bin", 1, 2, 3, 4, 5);
            Console.WriteLine("Файл успешно создан и данные записаны.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
        Read("C:/ConsoleApp1/Task.bin");
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/Task2.bin");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
        
        //////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task2: ");
        ReadFile("C:/ConsoleApp1/Task2.bin");
        ReadFile("C:/ConsoleApp1/Task2.bin", 2);
        
        //////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task3: ");
        string[] test_files = { "C:/ConsoleApp1/file1.bin", "C:/ConsoleApp1/file2.bin", "C:/ConsoleApp1/file3.bin", "C:/ConsoleApp1/file4.bin" };
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/file1.bin");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/file2.bin");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/file3.bin");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
        try
        {
            CreateTheNewFile("C:/ConsoleApp1/file4.bin");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }

        foreach (var file_test in test_files)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Обработка файла {file_test}...");
            Console.WriteLine(" ");

            int[] write_numbers = new int[new Random().Next(1, 100)];
            for (int i = 0; i < write_numbers.Length; i++)
            {
                write_numbers[i] = new Random().Next(1, 100);
            }
            WriteBinaryFile(file_test, write_numbers);

            int[] number_values = ReadBinaryFile(file_test);

            if (number_values.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
                continue;
            }

            Console.WriteLine("Исходное содержимое файла:");
            PrintNumbers(number_values);

            int min_value = number_values.Min();
            int max_value = number_values.Max();

            for (int i = 0; i < number_values.Length; i++)
            {
                if (number_values[i] == min_value || number_values[i] == max_value)
                {
                    number_values[i] = 0;
                }
            }

            WriteBinaryFile(file_test, number_values);

            Console.WriteLine("Содержимое файла после изменения:");
            PrintNumbers(number_values);
        }
        //////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task4.1");
        string filePath = @"C:/ConsoleApp1/text1.txt";
        CreateTheNewFile(filePath);
        GenerateRandomEnglishString(filePath, 10);
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл '{filePath}' не найден.");
            return;
        }

        Console.WriteLine("Символы в файле и их коды:");
        int totalChars = DisplayFileChars(filePath);
        Console.WriteLine($"Общее количество символов в файле: {totalChars}");
        
        //////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task4.2");
        int N = 5; // Количество строк
        char C = '*'; // Символ для заполнения строк

        string text2 = @"C:/ConsoleApp1/text2.txt";

        NC(text2, N, C);

        readagain(text2);

	//////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task4.3");

        string fileadd1 = @"C:/add1.txt";
        string fileadd2 = @"C:/add2.txt";

        Add(fileadd1, fileadd2);
        
        //////////////////////////
        Console.WriteLine(" ");
        Console.WriteLine("Task4.3");
        
        string path_value = @"C:/test.txt"; // Путь к исходному файлу, который нужно изменить.
        string temp_file = Path.GetTempFileName(); // Создаем временный файл и получаем его полный путь.
        using (var sr = new StreamReader(path_value)) // Создаем объект StreamReader для чтения из исходного файла.
        using (var sw = new StreamWriter(temp_file)) // Создаем объект StreamWriter для записи во временный файл.
        {
            string line; // Объявляем переменную для хранения каждой строки из файла.
            while ((line = sr.ReadLine()) != null) // Читаем файл построчно, пока не достигнем конца файла.
            {
                if (!String.IsNullOrWhiteSpace(line)) // Если строка не пустая...
                sw.WriteLine(line); // ...записываем ее во временный файл.
                }
            
        }
        File.Delete(path_value); // Удаляем исходный файл.
        File.Move(temp_file, path_value); // Переименовываем временный файл в исходный файл.
        }
    }
    static void Add(string fileadd1, string fileadd2)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileadd1, true))
            {
                using (StreamReader reader = new StreamReader(fileadd2))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
                using (StreamReader reader = new StreamReader(fileadd2))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"'{fileadd2}' добавлено в конец файла '{fileadd1}'.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {e.Message}");
        }

    }
    static void NC(string path, int n, char c)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 1; i <= n; i++)
                {
                    // Создаем строку, содержащую i символов C
                    string line = new string(c, i);

                    // Записываем строку в файл
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"Файл '{path}' успешно создан.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка при создании файла: {e.Message}");
        }

    }
    static void GenerateRandomEnglishString(string path, int length)
    {
        Random rand = new Random();
        string randomString = "";

        // Генерация рандомной строки из английских букв заданной длины
        for (int i = 0; i < length; i++)
        {
            // Случайный выбор кода символа в диапазоне английских букв в ASCII
            randomString += (char)rand.Next('a', 'z' + 1);
        }

        // Запись строки в файл
        File.WriteAllText(path, randomString);
    }

    static int DisplayFileChars(string path)
    {
        int totalChars = 0;
        using (StreamReader reader = new StreamReader(path, Encoding.Default))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int currentChar = reader.Read();
                totalChars++;
                Console.WriteLine($"Символ: {Convert.ToChar(currentChar)} Код: {currentChar}");
            }
        }
        return totalChars;
    }
    static int[] ReadBinaryFile(string test_file)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(test_file, FileMode.Open)))
        {
            return reader.ReadBytes((int)reader.BaseStream.Length).Select(b => (int)b).ToArray();
        }
    }

    static void WriteBinaryFile(string test_file, int[] numbers_value)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(test_file, FileMode.Create)))
        {
            writer.Write(numbers_value.Select(n => (byte)n).ToArray());
        }
    }

    static void PrintNumbers(int[] numbers_value)
    {
        foreach (var number_value in numbers_value)
        {
            Console.Write(number_value + " ");
        }
        Console.WriteLine();
    }
    static void ReadFile(string path, uint n = 10, string delimiter = ", ")
    {
        try
        {
            // Проверяем, существует ли файл
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл '{path}' не существует.");
                return;
            }

            // Проверяем, не является ли файл пустым
            if (new FileInfo(path).Length == 0)
            {
                Console.WriteLine("<empty file>");
                return;
            }

            // Читаем все целые числа из бинарного файла
            using (FileStream fileStream = File.OpenRead(path))
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            //using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (binaryReader.PeekChar() != -1)
                {
                    // Читаем целое число из бинарного файла
                    int number = binaryReader.ReadInt32();
                    Console.Write(number);
                    Console.Write(delimiter);

                    // Если достигнуто количество чисел для вывода в строке, переходим на новую строку
                    if (binaryReader.BaseStream.Position % (sizeof(int) * n) == 0)
                        Console.WriteLine();
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
    }

    static void CreateTheNewFile(string path, params int[] values)
    {
        try
        {
            // Открываем или создаем бинарный файл для записи
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                // Записываем каждое число в бинарный файл
                foreach (int value in values)
                {
                    binaryWriter.Write(value);
                }
            }
        }
        catch (IOException e)
        {
            // В случае ошибки при записи в файл, генерируем исключение
            throw new IOException($"Ошибка при записи в файл: {e.Message}");
        }
    }
    static void Read(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл '{path}' не существует.");
                return;
            }
            using (FileStream fileStream = File.OpenRead(path))
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            {
                string numbers = "";
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    int number = binaryReader.ReadInt32();
                    numbers += number + ", ";
                }

                // Удаляем лишнюю запятую и пробел в конце строки
                if (numbers.Length > 0)
                {
                    numbers = numbers.Remove(numbers.Length - 2);
                }

                Console.WriteLine(numbers);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла: {e.Message}");
        }
    }
    static void readagain(string path)
    {
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки + {e.Message}");
        }
    }
}
