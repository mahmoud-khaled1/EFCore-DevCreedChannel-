using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(50),Required]
        public string FName { get; set; }
        [MaxLength(50), Required]
        public string LName { get; set; }
        public string DisplayName { get; set; }
        
    }
}
