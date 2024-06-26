
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите номер задачи (1-4):");
        int taskNumber = Convert.ToInt32(Console.ReadLine());

        switch (taskNumber)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            default:
                Console.WriteLine("Неверный номер задачи.");
                break;
        }
    }

    // Задача 1
    static void Task1()
    {
        string filePath = "yourFilePath.txt"; 
        using (StreamReader reader = new StreamReader(filePath))
        {
            int counter = 0;
            int symbol;
            while ((symbol = reader.Read()) != -1)
            {
                char c = (char)symbol;
                Console.WriteLine($"Символ: {c}, Код: {symbol}");
                counter++;
            }
            Console.WriteLine($"Общее количество символов: {counter}");
        }
        // Коды символов конца строки: \r (возврат каретки) - 13, \n (новая строка) - 10
        // Код пробела: 32
    }

    // Задача 2
    static void Task2()
    {
        int N = 5; 
        char C = 'C'; 
        string filePath = "yourFilePath.txt"; 
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 1; i <= N; i++)
            {
                writer.WriteLine(new string(C, i));
            }
        }
    }

    // Задача 3
    static void Task3()
    {
        string filePath1 = "FilePath1.txt"; 
        string filePath2 = "FilePath2.txt"; 
        using (StreamWriter writer = new StreamWriter(filePath1, true))
        using (StreamReader reader = new StreamReader(filePath2))
        {
            writer.Write(reader.ReadToEnd());
        }
    }

    // Задача 4
    static void Task4()
    {
        string filePath = "yourFilePath.txt"; 
        string tempFilePath = Path.GetTempFileName();
        using (StreamReader reader = new StreamReader(filePath))
        using (StreamWriter writer = new StreamWriter(tempFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    writer.WriteLine(line);
                }
            }
        }
        File.Delete(filePath);
        File.Move(tempFilePath, filePath);
    }
}
