using CQRSDemo.Commands;
using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await _mediator.Send(new GetStudentListQuery());
        }
        [HttpGet("studentId")]
        public async Task<StudentDetails>GetStudentDetailsAsync(int studentId)
        {
            return await _mediator.Send(new GetStudentByIdQuery() { Id = studentId });
        }
        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            return await _mediator.Send(new CreateStudentCommand(
            
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge
            ));
        }
        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            return await _mediator.Send(new UpdateStudentCommand(
                studentDetails.Id,
                studentDetails.StudentName,
                studentDetails.StudentEmail,
                studentDetails.StudentAddress,
                studentDetails.StudentAge
            ));
        }
        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int studentId)
        {
            return await _mediator.Send(new DeleteStudentCommand() { Id=studentId});
        }
    }
}
