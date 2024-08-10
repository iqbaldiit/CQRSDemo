using MediatR;

namespace CQRSDemo.Commands
{
    public class DeleteStudentCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
