using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class Category
    {
        // cause Data Type is byte is set in database as primary but not identity
        // to solve this problem we can use Data Annotation or Fluent API 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }
    }
}
