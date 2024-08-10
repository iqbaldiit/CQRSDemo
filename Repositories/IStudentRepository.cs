using CQRSDemo.Models;

namespace CQRSDemo.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<StudentDetails>>GetStudentListasync();
        public Task<StudentDetails> GetStudentDetailsAsync(int id);
        public Task<StudentDetails> AddStudentDetailsAsync(StudentDetails oStudentDetails);
        public Task<int> UpdateStudentDetailsAsync(StudentDetails oStudentDetails);
        public Task<int> DeleteStudentDetailsAsync(int id);
    }
}
