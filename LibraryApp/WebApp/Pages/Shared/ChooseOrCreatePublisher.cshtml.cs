using System;
using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Shared
{
    public class _ChooseOrCreatePublisher : Controller
    {
        public _ChooseOrCreatePublisher(SelectList publishersSelectList)
        {
            PublishersSelectlist = publishersSelectList;
        }

        public int Publisher { get; set; }
        public SelectList PublishersSelectlist { get; set; }

        public String NewPublisher { get; set; }
        // GET
        public IActionResult Index()
        {
            
            
            return View();
        }
    }
}