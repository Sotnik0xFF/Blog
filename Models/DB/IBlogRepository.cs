﻿using System.Threading.Tasks;

namespace Blog.Models.DB
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
