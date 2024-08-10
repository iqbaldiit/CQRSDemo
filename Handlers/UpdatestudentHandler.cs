using CQRSDemo.Commands;
using CQRSDemo.Models;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class UpdatestudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdatestudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var oStudentDetail = await _studentRepository.GetStudentDetailsAsync(command.Id);
            if (oStudentDetail == null)
                return default;

            oStudentDetail.StudentName = command.StudentName;
            oStudentDetail.StudentEmail = command.StudentEmail;
            oStudentDetail.StudentAddress = command.StudentAddress;
            oStudentDetail.StudentAge = command.StudentAge;

            return await _studentRepository.UpdateStudentDetailsAsync(oStudentDetail);
        }
    }
}
