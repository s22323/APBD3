using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class FileService : IFileService
    {
        public static HashSet<Student> students = new HashSet<Student>();
        private static String path = "./Data/students.csv";
        public void AddStudent(Student student)
        {
            if (!students.Contains(student))
            {
                students.Add(student);
            };
            SaveToFile();
        }

        public Student GetStudentByIndexNr(string indexNr)
        {
            foreach (Student student in students)
            {
                if (student.nrIndex.Equals(indexNr))
                {
                    return student;
                }
            }
            throw new StudentNotFoundException("Nie znaleziono studenta o podanym nr indexu");
        }

        public void RemoveStudentByIndexNr(string indexNr)
        {
            Student studentToDelete = null;
            foreach (Student student in students)
            {
                if (student.nrIndex.Equals(indexNr))
                {
                    students.Remove(student);
                    studentToDelete = student;
                }
            }
            if (studentToDelete == null)
            {
                throw new StudentNotFoundException("Nie znaleziono studenta o podanym numerze indeksu");
            }
            SaveToFile();
        }

        public Student UpdateStudentByIndexNr(Student student, string indexNr)
        {
            Student studentToUpdate = GetStudentByIndexNr(indexNr);
            if (!studentToUpdate.nrIndex.Equals(student.nrIndex))
            {
                studentToUpdate.Imie = student.Imie;
                studentToUpdate.Nazwisko = student.Nazwisko;
                studentToUpdate.dataUrodzenia = student.dataUrodzenia;
                studentToUpdate.studia = student.studia;
                studentToUpdate.tryb = student.tryb;
                studentToUpdate.email = student.email;
                studentToUpdate.imieOjca = student.imieOjca;
                studentToUpdate.imieMatki = student.imieMatki;
                SaveToFile();
                return studentToUpdate;
            }
            throw new StudentNotFoundException("Nie znaleziono studenta o podanym numerze indeksu");
        }

        public void SaveToFile()
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (Student student in students)
            {
                sw.WriteLine(student);
            }
        }
    }
}
