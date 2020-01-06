using Domain;

namespace WebApp.Pages.Shared.Partials
{
    public class CreateAuthorPartialModel
    {
        public Author Author { get; set; }

        public CreateAuthorPartialModel()
        {
            
        }

        public CreateAuthorPartialModel(Author author)
        {
            Author = author;
        }
    }
}