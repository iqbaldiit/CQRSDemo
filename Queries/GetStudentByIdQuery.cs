using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Queries
{
    public class GetStudentByIdQuery:IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
