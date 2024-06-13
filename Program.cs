using System;

class Program
{

    static Random random = new Random();
    static void Main(string[] args)
    {

        int N = 10;
        char C = 'C';
        string file_path_1 = "";
        string file_path_2 = "";
        string file_path = @"C:\Users\Lenovo\source\repos\lab4_9\input.txt";
        string bin_file = @"C:\Users\Lenovo\source\repos\lab4_9\lab4.bin";
        string line_file = File.ReadAllText(file_path);
        SortWordByLength(line_file);
        SwapCharInWords(line_file, file_path);
        ReadFileAndDisplayCharacters(line_file);
        CreateFileWithCharacterLines(N, C, file_path_1);
        //AppendFileToEnd();
        string tempFilePath = Path.GetTempFileName(); // Создание временного файла

        RemoveEmptyLines(file_path_2, tempFilePath);

        // Замена исходного файла временным файлом без пустых строк
        File.Delete(file_path_2);
        File.Move(tempFilePath, file_path_2);


        string[] fileNames = { "file1.bin", "file2.bin", "file3.bin", "file4.bin" };

        // Заполнение файлов случайными числами
        foreach (var fileName in fileNames)
        {
            CreateRandomBinaryFile(fileName, 10); // Создаем файл с 10 случайными числами
        }

        foreach (var fileName in fileNames)
        {
            Console.WriteLine($"Обработка файла: {fileName}");
            if (File.Exists(fileName))
            {
                int[] numbers = ReadBinaryFile(fileName);
                Console.WriteLine("Исходное содержимое файла:");
                PrintArray(numbers);

                if (numbers.Length > 0)
                {
                    ResetMinMaxValues(numbers);
                    WriteBinaryFile(fileName, numbers);

                    Console.WriteLine("Содержимое файла после изменения:");
                    PrintArray(numbers);
                }
                else
                {
                    Console.WriteLine("Файл пуст.");
                }
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }
        }






    }

    // Меняем местами четные и нечетные символы.
    static void SwapCharInWords(string line_file, string file_path)
    {
        string[] words = line_file.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            char[] elements = words[i].ToCharArray();

            for (int e = 0; e < elements.Length - 1; e += 2)
            {
                char temp = elements[e];
                elements[e] = elements[e + 1];
                elements[e + 1] = temp;
            }

            words[i] = new string(elements);
        }
        string result = String.Join(" ", words);

        Console.WriteLine("Перевернутые слова:");
        Console.WriteLine(result);
        File.WriteAllText(file_path, result);
    }
    // Сортировка слов по длине.
    static void SortWordByLength(string line_file)
    {
        string[] words = line_file.Split(' ');
        Console.WriteLine("Исходные слова:");
        Console.WriteLine(line_file + "\n");

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words.Length - i - 1; j++)
            {
                if (words[j].Length > words[j + 1].Length)
                {
                    string temp = words[j];
                    words[j] = words[j + 1];
                    words[j + 1] = temp;

                }
            }
        }

        Console.Write("Отсортированные слова: ");
        for (int i = 0; i < words.Length; i++)
        {
            Console.Write(words[i] + " ");
        }
        Console.WriteLine();
    }

    // Создание бинарного файла
    static void CreateTheNewFile(string path, string delimiter = "", params int[] values)
    {
        try
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
            {
                foreach (var i in values)
                {
                    binaryWriter.Write(i);
                    if (!String.IsNullOrEmpty(delimiter))
                        binaryWriter.Write(delimiter);
                }
            }
            Console.WriteLine("Файл успешно записан!");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Ошибка ввода данных{e.Message}");
        }
    }
    static void ReadFile(string path, uint n = 10, string delimiter = ", ")
    {
        try
        {
            using (FileStream fileStream = File.OpenRead(path))
            using (BinaryReader binaryReader = new BinaryReader(fileStream))
            {
                if (fileStream.Length == 0)
                {
                    Console.WriteLine("< empty file >");
                    return;
                }
                int i = 0;
                while (binaryReader.PeekChar() != -1)
                {
                    int tmp = binaryReader.ReadInt32();
                    Console.Write(tmp);
                    if (fileStream.Position < fileStream.Length)
                    {
                        Console.Write(delimiter);
                        i++;
                        if (i == n)
                            Console.WriteLine();
                    }
                    else
                        Console.WriteLine(".");

                }
            }

        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка обработки файла {e.Message}");
        }
    }

    static void CreateRandomBinaryFile(string fileName, int length)
    {
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = random.Next(Int32.MinValue, Int32.MaxValue);
        }
        WriteBinaryFile(fileName, numbers);
    }

    static void ResetMinMaxValues(int[] numbers)
    {
        int min = Int32.MaxValue;
        int max = Int32.MinValue;

        // Находим минимальное и максимальное значения
        foreach (int number in numbers)
        {
            if (number < min) min = number;
            if (number > max) max = number;
        }

        // Обнуляем минимальное и максимальное значения
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == min || numbers[i] == max)
            {
                numbers[i] = 0;
            }
        }
    }

    static int[] ReadBinaryFile(string fileName)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            int fileLength = (int)reader.BaseStream.Length / 4;
            int[] numbers = new int[fileLength];
            for (int i = 0; i < fileLength; i++)
            {
                numbers[i] = reader.ReadInt32();
            }
            return numbers;
        }
    }

    static void WriteBinaryFile(string fileName, int[] numbers)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            foreach (int number in numbers)
            {
                writer.Write(number);
            }
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    static void ReadFileAndDisplayCharacters(string file_path)
    {
        int totalCharacters = 0;

        try
        {
            using (StreamReader reader = new StreamReader(file_path))
            {
                int currentChar;
                while ((currentChar = reader.Read()) != -1) // Чтение до конца файла
                {
                    char character = (char)currentChar;
                    Console.WriteLine($"Символ: {character}, Код: {(int)character}");
                    totalCharacters++;
                }
            }

            // Коды символов конца строки
            int carriageReturn = (int)'\r'; // Возврат каретки
            int lineFeed = (int)'\n'; // Перевод строки

            // Код пробела
            int space = (int)' ';

            Console.WriteLine($"Общее количество символов: {totalCharacters}");
            Console.WriteLine($"Код возврата каретки (CR): {carriageReturn}");
            Console.WriteLine($"Код перевода строки (LF): {lineFeed}");
            Console.WriteLine($"Код пробела: {space}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при чтении файла:");
            Console.WriteLine(ex.Message);
        }
    }

    static void CreateFileWithCharacterLines(int N, char C, string file_path_1)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(file_path_1))
            {
                for (int i = 1; i <= N; i++)
                {
                    writer.WriteLine(new string(C, i));
                }
            }

            Console.WriteLine($"Файл '{file_path_1}' успешно создан.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при записи в файл:");
            Console.WriteLine(ex.Message);
        }
    }

    static void AppendFileToEnd(string first_file, string second_file)
    {
        try
        {
            // Чтение содержимого второго файла
            string contentToAppend = File.ReadAllText(second_file);

            // Дописывание содержимого второго файла в конец первого файла
            using (StreamWriter writer = new StreamWriter(first_file, true))
            {
                writer.Write(contentToAppend);
            }

            Console.WriteLine($"Содержимое файла '{second_file}' было успешно дописано в конец файла '{first_file}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при дописывании файла:");
            Console.WriteLine(ex.Message);
        }
    }

    static void RemoveEmptyLines(string file_Path, string tempFilePath)
    {
        using (StreamReader reader = new StreamReader(file_Path))
        using (StreamWriter writer = new StreamWriter(tempFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line)) // Проверка на пустую строку
                {
                    writer.WriteLine(line); // Запись строки, если она не пустая
                }
            }
        }
    }




}

