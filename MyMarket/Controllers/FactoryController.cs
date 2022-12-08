using MyMarket.Models;
using Microsoft.AspNetCore.Mvc;
using MyMarket;
//using MyMarket.Models;

namespace MyMarket.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : Controller
    {
        public MarketContext db;
        public FactoryController(MarketContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(db.Factory.ToList());
        }

        //public void Get()
        //{
        //    db.TypeItem.ToList();
        //}

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Factory? factory = db.Factory.FirstOrDefault(u => u.Id == id);
            if (factory == null) NotFound(new { message = "Пользователь не найден" });
            return Json(factory);
        }

        [HttpPost]
        public IActionResult Create(Factory factory)
        {
            db.Factory.Add(factory);
            db.SaveChanges();
            return Json(factory);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Factory? factory = db.Factory.FirstOrDefault(u => u.Id == id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (factory == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, удаляем его
            db.Factory.Remove(factory);
            db.SaveChanges();
            return Json(factory);
        }

        [HttpPut]
        public IActionResult Put(int id, Factory factoryData)
        {
            var factory = db.Factory.FirstOrDefault(u => u.Id == factoryData.Id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (factory == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, изменяем его данные и отправляем обратно клиенту

            factory.Name = factoryData.Name;


            db.SaveChanges();
            return Json(factory);
        }
    }
}