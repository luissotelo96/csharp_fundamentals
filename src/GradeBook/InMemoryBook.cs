using static GradeBook.InMemoryBook;

namespace GradeBook
{
    public class NameObject
    {
        public NameObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }


    public interface IBook
    {
        void AddGrade(double grade);
        Stadistics GetStadistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }


    public abstract class Book: NameObject , IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Stadistics GetStadistics();
    }


    public class InMemoryBook : Book
    {        
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();

        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(5);
                    break;
                case 'B':
                    AddGrade(4);
                    break;
                case 'C':
                    AddGrade(3);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Stadistics GetStadistics()
        {

            var stadistics = new Stadistics();

            foreach (var grade in grades)
            {
                stadistics.Add(grade);

            }            

            return stadistics;
        }

        private List<double> grades;
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public override event GradeAddedDelegate GradeAdded;
    }
}