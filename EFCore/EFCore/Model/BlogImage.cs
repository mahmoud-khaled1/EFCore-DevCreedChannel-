using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public  class BlogImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Caption  { get; set; }

        //public int BlogId { get; set; }
        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")] // Data Annotation if we didn't name ForeignKey with BlogId and wnat to name it anything
        public Blog Blog { get; set; }
    }
}
