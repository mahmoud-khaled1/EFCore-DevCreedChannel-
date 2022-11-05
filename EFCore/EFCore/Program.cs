using EFCore.Model;
using System;

namespace EFCore
{
    class program
    {
        public static void Main(string[]args)
        {
            var _context=new ApplicationDbContext();
            //var emp = new Employee
            //{
            //    Name = "Mahmoud"
            //};
            //_context.Employees.Add(emp);
            //_context.SaveChanges();

            //_context.Blogs.Add(new Blog { Url = "ioio" });
            //_context.SaveChanges();

            _context.Authors.Add(new Author { FName = "mahmoud", LName = "khaled" });
            _context.SaveChanges();


            Console.ReadKey();
        }
    }
}