using MyMarket.Models;
using Microsoft.AspNetCore.Mvc;
using MyMarket;
using MyMarket.Models;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;

namespace MyMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        public MarketContext db;
        public IWebHostEnvironment env;

        public ItemController(MarketContext context, IWebHostEnvironment env)
        {
            db = context;
            this.env = env;
        }


        [HttpGet()]

        public IActionResult Get(int? typeId,int? factoryId,int? page, int? limit)
        {
            //limit = limit?? 3;
            //page = page;
            int? offset = page * limit - limit;
            //for (int i = 1; i <= page * limit; i++)
            //{
            //    Item items = db.Item.FirstOrDefault(u => u.Id);
            //}
            List<Item> items = new List<Item>();
          
                if (typeId != null && factoryId == null)
                    items = db.Item.Where(i => i.TypeId == typeId).ToList();
                if (typeId == null && factoryId != null)
                    items = db.Item.Where(i => i.FactoryId == factoryId).ToList();
                if (typeId != null && factoryId != null)
                    items = db.Item.Where(i => i.FactoryId == factoryId && i.TypeId == typeId).ToList();
                if (typeId == null && factoryId == null)
                    items = db.Item.ToList();
                if (page != null && limit != null)
                {
                    return Json(items.Skip((int)offset).Take((int)limit));
            }
            else
                return Json(items);
           // return Json(items);
        }


        //public void Get()
        //{
        //    db.TypeItem.ToList();
        //}

        //[HttpGet("{id}")]

        //public IActionResult GetById(int id)
        //{

        //    //var item = from ItemInfo in db.ItemInfo
        //    //           join Item in db.Item on ItemInfo.ItemId equals Item.Id
        //    //    var item = db.ItemInfo.Join(db.Item, // второй набор
        //    //iteminfo => iteminfo.ItemId, // свойство-селектор объекта из первого набора
        //    //item => item.Id, // свойство-селектор объекта из второго набора
        //    //(iteminfo, item) => new // результат
        //    //{
        //    //    ItemId=iteminfo.ItemId,
        //    //    Title = iteminfo.Title,
        //    //    Value = iteminfo.Value,
        //    //    Img=item.Img,
        //    //    Description= item.Description

        //    //}).Where(u => u.ItemId == id)/*.FirstOrDefault(u => u.ItemId == id)*/.ToList();
        //    List<ItemInfo> itemInfo = db.ItemInfo.Where(u => u.ItemId == id).ToList();
        //    Item item = db.Item.FirstOrDefault(u => u.Id == id);
        //    if (itemInfo == null) NotFound(new { message = "Пользователь не найден" });
        //    //itemInfo.Insert(0, item);

        //    //return Json(item);
        //    return Json(itemInfo);
        //}

        [HttpGet("{id}")]
        public IActionResult GetBy(int id)
        {
            List<ItemInfo> itemInfo = db.ItemInfo.Where(u => u.ItemId == id).ToList();
            Item item = db.Item.FirstOrDefault(u => u.Id == id);
            item.ItemInfo = itemInfo;
            
            return Json(item);
        }

            // [HttpGet]
            //// [ServiceFilter]
            // public IActionResult GetByTypeAndFact(int typeid, int factoryid)
            // {

            //     List<Item> items = db.Item.Where(u => u.TypeId == typeid && u.FactoryId == factoryid).ToList();
            //     if (items == null) NotFound(new { message = "Пользователь не найден" });
            //     return Json(items);
            // }

            //[HttpGet("factoryid={factoryid}")]
            //public IActionResult GetByFact(int typeid, int factoryid)
            //{
            //    List<Item> items = db.Item.Where(u => u.FactoryId == factoryid).ToList();
            //    if (items == null) NotFound(new { message = "Пользователь не найден" });
            //    return Json(items);
            //}

            //[HttpGet("typeid={typeid}")]
            //public IActionResult GetByType(int typeid, int factoryid)
            //{
            //    List<Item> items = db.Item.Where(u => u.TypeId == typeid).ToList();
            //    if (items == null) NotFound(new { message = "Пользователь не найден" });
            //    return Json(items);
            //}



            [HttpPost]
        public IActionResult Create(Item item)
        {
           
            db.Item.Add(item);
            db.SaveChanges();
            return Json(item);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item item = db.Item.FirstOrDefault(u => u.Id == id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (item == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, удаляем его
            db.Item.Remove(item);
            db.SaveChanges();
            return Json(item);
        }

        [HttpPut]
        public IActionResult Put(int id, Item typeData)
        {
            var item = db.Item.FirstOrDefault(u => u.Id == typeData.Id);

            // если не найден, отправляем статусный код и сообщение об ошибке
            if (item == null) return NotFound(new { message = "Пользователь не найден" });

            // если пользователь найден, изменяем его данные и отправляем обратно клиенту

            item.Name = typeData.Name;
            item.Price = typeData.Price;
            item.Rating = typeData.Rating;
            item.TypeId = typeData.TypeId;
            item.FactoryId = typeData.FactoryId;
            item.Img = typeData.Img;
            item.Description = typeData.Description;
            // item.Factory = typeData.Factory;
            //  item.Type=typeData.Type;


            db.SaveChanges();
            return Json(item);
        }

        [Route("SaveFile")]
        [HttpPost]
        public IActionResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = env.ContentRootPath + "/Photos/" + filename;
                using(var stream=new FileStream(physicalPath,FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return Json(filename);
            }
            catch (Exception)
            {
                return NotFound(new { message = "Trouble" });


            }

        }

    }
}
