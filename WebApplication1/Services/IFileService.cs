using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IFileService
    {
        public Student GetStudentByIndexNr(String indexNr);
        public void AddStudent(Student student);
        public void RemoveStudentByIndexNr(String indexNr);
        public Student UpdateStudentByIndexNr(Student student, String indexNr);
        public void SaveToFile();

    }
}
