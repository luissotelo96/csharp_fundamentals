namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;



        public Book(string name)
        {
            grades = new List<double>();
            Name = name;

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

        public void AddGrade(double grade)
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

        public Stadistics GetStadistics(){

            var stadistics = new Stadistics();

            stadistics.Average = calculateGradesAverage();  
            stadistics.High =  calculateMaxGrade();
            stadistics.Low =  calculateMinGrade();

            switch (stadistics.Average)
            {
                case var d when d >= 5.0:
                    stadistics.Letter = 'A';
                    break;
                case var d when d >= 4.0:
                    stadistics.Letter = 'B';
                    break;
                case var d when d >= 3.0:
                    stadistics.Letter = 'C';
                    break;
                case var d when d >= 2.0:
                    stadistics.Letter = 'D';
                    break;
                default:
                    stadistics.Letter = 'F';
                    break;
            }

            return stadistics;      
        }

        public double calculateGradesAverage(){
            var result = 0.0;
            foreach(var number in grades){
                result += number;
            }
            return result /= grades.Count;
        }

        public double calculateMaxGrade(){
            var result = double.MinValue;
            foreach(var number in grades){
                result = Math.Max(number, result);
            }
            return result;
        }

        public double calculateMinGrade(){
            var result = double.MaxValue;
            foreach(var number in grades){
                result = Math.Min(number, result);
            }
            return result;
        }
    }
}