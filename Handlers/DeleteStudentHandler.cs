using CQRSDemo.Commands;
using CQRSDemo.Repositories;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class DeleteStudentHandler:IRequestHandler<DeleteStudentCommand,int>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var oStudent=_studentRepository.GetStudentDetailsAsync(command.Id);
            if (oStudent == null) 
                return default;
            return await _studentRepository.DeleteStudentDetailsAsync(oStudent.Id);
        }
    }
}
