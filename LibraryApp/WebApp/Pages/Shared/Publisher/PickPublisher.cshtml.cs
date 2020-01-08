using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Publisher
{
    public class PickPublisherModel
    {
        public SelectList PublishersSelectlist { get; set; }
        
        public int? PublisherId { get; set; }
        public string? NewPublisherName { get; set; }
        
        public PickPublisherModel()
        {
        }

        public PickPublisherModel(SelectList publishersSelectList)
        {
            PublishersSelectlist = publishersSelectList;
        }
    }
}