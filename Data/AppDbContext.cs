﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){  }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
    }    

}
