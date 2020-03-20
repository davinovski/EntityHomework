using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityHomework.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Author Name")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }

        public Author(string name, ICollection<Book> books)
        {
            Name = name;
            Books = books;
        }
       
        

    }
}