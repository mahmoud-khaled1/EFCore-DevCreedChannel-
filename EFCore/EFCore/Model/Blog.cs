using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    // change Table and Schema name with Data Annotation
    //[Table("Blogss",Schema="blogging")]
    public class Blog
    {
        public int  Id{ get; set; }
        //[Column("BlogUrl")]// this column will create in DB with name BlogUrl
        //[Column(TypeName ="varchar(200)")]// this column will create in DB with dataType varchar with length 200
        //[MaxLength(100)] // save in DB with varchar(100)
        public string Url{ get; set; }
        //[NotMapped]
        public DateTime CreateTime{ get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

    }
}
