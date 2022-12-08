using MyMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMarket;
//using MyMarket.Models;

namespace MyMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeItemController : Controller
    {
        public MarketContext db;
        public TypeItemController(MarketContext context)
        {
            db = context;
        }


        [HttpGet]

        public IActionResult Get()
        {
            return Json(db.TypeItem.ToList());
        }

        //public async void Get()
        //{
        //   await db.TypeItem.ToListAsync();
        //}

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            TypeItem typeItem = db.TypeItem.FirstOrDefault(u => u.Id == id);
            if (typeItem == null) NotFound(new { message = "Пользователь не найден" });
            return Json(typeItem);
        }

        [HttpPost]
        public IActionResult Create(TypeItem typeItem)
        {
            db.TypeItem.Add(typeItem);
            db.SaveChanges();
            return Json(typeItem);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TypeItem typeItem = db.TypeItem.FirstOrDefault(u => u.Id == id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (typeItem == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, удаляем его
            db.TypeItem.Remove(typeItem);
            db.SaveChanges();
            return Json(typeItem);
        }

        [HttpPut]
        public IActionResult Put(int id, TypeItem typeData)
        {
            var typeItem = db.TypeItem.FirstOrDefault(u => u.Id == typeData.Id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (typeItem == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, изменяем его данные и отправляем обратно клиенту

            typeItem.Name = typeData.Name;


            db.SaveChanges();
            return Json(typeItem);
        }



    }
}