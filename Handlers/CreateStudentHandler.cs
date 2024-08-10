using CQRSDemo.Commands;
using CQRSDemo.Models;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var oStudentdetails = new StudentDetails()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge,
            };

            return await _studentRepository.AddStudentDetailsAsync(oStudentdetails);
        }
    }
}
