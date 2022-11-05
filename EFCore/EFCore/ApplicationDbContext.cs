using EFCore.Configurations;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ApplicationDbContext:DbContext
    {



        // our business Tables 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Override this method to configure the database (and other options)
        // to be used for this context. This method is called for each instance
        // of the context that is created. The base implementation does nothing. 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // to connect to DB this is not suitable way the best way create 
            // appsetting.json file and put connection string on it 
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCoreDB;Integrated Security=True");
        }
        //This is the most powerful method of configuration and allows configuration
        //to be specified without modifying your entity classes.
        //and to apply Fluent API instead of Data Annotation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // we will move them to seperate file in folder Configurations
            // for clean code  

            // This
            modelBuilder.Entity<Blog>()
                .Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(50);

            //OR This if we work from separate class 
            // new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            //OR This
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
            //----------------------
            // To cahnge Table Name with Fluent API
            modelBuilder.Entity<Blog>()
                .ToTable("Blogss");
            //----------------------
            // To Change Schema Name with Fluent API
            modelBuilder.Entity<Blog>()
                .ToTable("Blog", schema: "blogging");
            //----------------------
            // any table will create with default Schema name blogging
            modelBuilder.HasDefaultSchema("blogging");
            //---------------------
            // To ignore specific properity in table when created with Fluent API
            modelBuilder.Entity<Blog>()
                .Ignore(b => b.CreateTime);
            //---------------------
            //Change Column Name with Fluent API
            modelBuilder.Entity<Blog>()
                .Property(e => e.Url)
                .HasColumnName("BlogUrl");
            //----------------------
            //Change Column Data Types with Fluent API
            modelBuilder.Entity<Blog>()
                .Property(e => e.Url)
                .HasColumnType("varchar(150)");
            //----------------------
            //Change Column Data Types length with Fluent API
            modelBuilder.Entity<Blog>()
                .Property(e => e.Url)
                .HasMaxLength(50);
            //------------------------
            // set Key for specific table with Fluent API 
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);
            //------------------------
            //Set Composite Key  with Fluent API 
            modelBuilder.Entity<Book>()
                .HasKey(b => new { b.Name, b.Author });
            //------------------------
            //Set Default Value when insert into database and no value pass 
            modelBuilder.Entity<Blog>()
                .Property(b => b.Rating)
                .HasDefaultValue(2);

            modelBuilder.Entity<Blog>()
                .Property(b => b.CreateTime)
                .HasDefaultValue(DateTime.Now);
            //------------------------
            //Computed Columns with Fluent API
            modelBuilder.Entity<Author>()
                .Property(a => a.DisplayName)
                .HasComputedColumnSql("[FName] + [LName]");
            //------------------------
            // Primary Key Default Value with Fluent API
            // cause Data Type is byte is set in database as primary but not identity
            // to solve this problem we can use Data Annotation or Fluent API 
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

        }


    }
}
