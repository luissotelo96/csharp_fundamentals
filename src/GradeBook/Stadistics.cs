namespace GradeBook
{
    public class Stadistics
    {

        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 5.0:
                        return 'A';
                    case var d when d >= 4.0:
                        return 'B';
                    case var d when d >= 3.0:
                        return 'C';
                    case var d when d >= 2.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public Stadistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }
    }
}