namespace WebApplication1.Models
{
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string nrIndex { get; set; }
        public string dataUrodzenia { get; set; }
        public string studia { get; set; }
        public string tryb { get; set; }    
        public string email { get; set; }
        public string imieOjca { get; set; }
        public string imieMatki { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   nrIndex == student.nrIndex;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nrIndex);
        }
    }
}
