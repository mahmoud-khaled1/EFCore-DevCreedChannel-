using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Content { get;set; }

        public Blog Blog { get; set; }

        public ICollection<Tag> Tags{ get; set; }
    }
}
