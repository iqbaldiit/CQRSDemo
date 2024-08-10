using CQRSDemo.Data;
using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly DbContextClass _dbContext;
        public StudentRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StudentDetails> AddStudentDetailsAsync(StudentDetails oStudentDetails)
        {
            var oResult=_dbContext.Students.Add(oStudentDetails);
            await _dbContext.SaveChangesAsync();
            return oResult.Entity;
        }
        public async Task<int> DeleteStudentDetailsAsync(int Id)
        {
            var oStudent=_dbContext.Students.Where(x=>x.Id == Id).FirstOrDefault();
            _dbContext.Students.Remove(oStudent);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateStudentDetailsAsync(StudentDetails studentDetails)
        {
            var oStudent=_dbContext.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<List<StudentDetails>> GetStudentListasync()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<StudentDetails>GetStudentDetailsAsync(int id)
        {
            return await _dbContext.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
