using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Partials
{
    public class PickAuthorPartialModel
    {
        public Author Author { get; set; }
        public List<int> Type { get; set; }
        public MultiSelectList BookAuthorsSelectList { get; set; }
        public List<int> SelectedAuthorIds { get; set; }
        
        public PickAuthorPartialModel()
        {
            
        }

        public PickAuthorPartialModel(Author author)
        {
            Author = author;
        }

        
        
    }
}