using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var book = new InMemoryBook("Book 1");
            book.GradeAdded += OnGradeAdded;*/
            IBook book = new DiskBook("Disk Book 1");

            EnterGrade(book);

            var bookStadistics = book.GetStadistics();

            Console.WriteLine($"The average is {bookStadistics.Average}");
            Console.WriteLine($"The highest is {bookStadistics.High}");
            Console.WriteLine($"The lowest is {bookStadistics.Low}");
            Console.WriteLine($"The letter value is {bookStadistics.Letter}");
        }


        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Por favor ingrese un valor o q para salir: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("The grade is added");
        }
    }
}

