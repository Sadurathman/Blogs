using Blogs.Data;
using Blogs.Models;
using Blogs.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Controllers
{
    public class HomeController : Controller
    {
        //private AppDBContext _ctx;

         private readonly IRepository _repo;


        public HomeController(IRepository repo)
         {
          _repo = repo;
         }

       /* public HomeController(AppDBContext ctx)
        {
            _ctx = ctx;
        }*/
        public IActionResult Index()
        {
            var posts = _repo.GetAllPost();
            return View();
        }

        public IActionResult Post(int Id)
        {
            var post = _repo.GetPost(Id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            //_ctx.Add(post);
            //await  _ctx.SaveChangesAsync();
            _repo.AddPost(post);

            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }
    }
}
