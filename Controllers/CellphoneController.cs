using CrudWAuth.Entities;
using CrudWAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CrudWAuth.Controllers
{
    public class CellphoneController : Controller
    {
       private readonly AppDbContext _context;
       public CellphoneController(AppDbContext context)
        {
             _context = context;
        }

       public IActionResult Index()
       {
            return View();
       }
       
        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CellphoneViewModels model)
        {
            Cellphone phone = new Cellphone();
            {

                phone.Brand = model.Brand;
                phone.CpValue = model.CpValue;

            };
            _context.Cellphones.Add(phone);
            _context.SaveChanges();

            return RedirectToAction("List");

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult List() 
        {

            var viewModel = _context.Cellphones.ToList();
           
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Selpon = _context.Cellphones.Find(id);
            return View(Selpon);
        
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Cellphone phone)
        {
            var Selpon = _context.Cellphones.Find(phone.Id);

            if (Selpon is not null)
            {   
                Selpon.Brand = phone.Brand;
                Selpon.CpValue = phone.CpValue;
                _context.SaveChanges();
            
            }
            return RedirectToAction("List");
        }

   
        [Authorize]
        public IActionResult Delete(int id) 
        {
            var selpon = _context.Cellphones.SingleOrDefault(cellphone => cellphone.Id == id);
            if(selpon != null)
            {
                _context.Cellphones.Remove(selpon);
                _context.SaveChanges();
            }
               
            return RedirectToAction("List", "Cellphone");
        }

    }
}
