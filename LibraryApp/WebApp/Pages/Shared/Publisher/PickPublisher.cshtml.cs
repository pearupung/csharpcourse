using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared.Publisher
{
    public class PickPublisherModel
    {
        public SelectList PublishersSelectlist { get; set; }
        public int? Publisher { get; set; }
        public string? NewPublisher { get; set; }
        
        public PickPublisherModel()
        {
        }

        public PickPublisherModel(SelectList publishersSelectList)
        {
            PublishersSelectlist = publishersSelectList;
        }
    }
}