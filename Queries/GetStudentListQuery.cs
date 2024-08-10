
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Queries
{
    public class GetStudentListQuery:IRequest<List<StudentDetails>>
    {
    }
}
