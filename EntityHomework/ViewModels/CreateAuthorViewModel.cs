using EntityHomework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityHomework.ViewModels
{
    public class CreateAuthorViewModel
    {
        [Required]
        public Author Author { get; set; }

        public List<Book> AvailableBooks { get; set; }

        public int[] SelectedBooks { get; set; }

        public CreateAuthorViewModel()
        {

        }

    }
}