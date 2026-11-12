using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAnalysis
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double AverageScore { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public override string ToString() => $"{FullName} - {AverageScore:F1}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { FirstName = "Иван",     LastName = "Петров",     Age = 20, AverageScore = 85.5 },
                new Student { FirstName = "Анна",     LastName = "Сидорова",   Age = 23, AverageScore = 78.1 },
                new Student { FirstName = "Олег",     LastName = "Кузнецов",   Age = 19, AverageScore = 74.9 },
                new Student { FirstName = "Мария",    LastName = "Васильева",  Age = 26, AverageScore = 91.3 },
                new Student { FirstName = "Алексей",  LastName = "Смирнов",    Age = 22, AverageScore = 95.2 },
            };

            Console.WriteLine("--- Список студентов-хорошистов (балл от 75 до 90) ---");
            var goodStudents = students
                .Where(s => s.AverageScore >= 75 && s.AverageScore <= 90)
                .OrderByDescending(s => s.AverageScore);

            foreach (var s in goodStudents)
                Console.WriteLine($"{s.FullName} - {s.AverageScore:F1}");

            Console.WriteLine("\n--- Все студенты ---");
            List<string> names = students
                .Select(s => s.FullName)
                .ToList();

            foreach (var name in names)
                Console.WriteLine(name);

            Console.WriteLine("\n--- Сортировка по возрасту ---");
            var byAge = students
                .OrderBy(s => s.Age);

            foreach (var s in byAge)
                Console.WriteLine($"{s.FullName} - {s.Age} {PluralYears(s.Age)}");

            Console.WriteLine("\n--- Рейтинг студентов младше 25 лет (по убыванию балла) ---");
            var rating = students
                .Where(s => s.Age < 25)                       
                .OrderByDescending(s => s.AverageScore)       
                .Select(s => $"{s.FullName} - {s.AverageScore:F1}");

            foreach (var line in rating)
                Console.WriteLine(line);

            Console.ReadLine();
        }

        static string PluralYears(int age)
        {
            int lastDigit = age % 10;
            int lastTwo = age % 100;

            if (lastTwo >= 11 && lastTwo <= 14) return "лет";
            if (lastDigit == 1) return "год";
            if (lastDigit >= 2 && lastDigit <= 4) return "года";
            return "лет";
        }
    }
}