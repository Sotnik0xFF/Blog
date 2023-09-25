using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Models.DB
{
    public interface IRequestRepository
    {
        Task Add(Request request);
        Task<Request[]> GetAll();
    }
}
