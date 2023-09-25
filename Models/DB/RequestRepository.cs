using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.DB
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Request request)
        {
            request.Id = Guid.NewGuid();

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetAll()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
