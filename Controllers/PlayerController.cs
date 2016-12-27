using AngularCRUD_Latest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AngularCRUD_Latest.Controllers
{
    public class PlayerController : Controller
    {
        private MyContextClass _context = null;

        public PlayerController()
        {
            _context = new MyContextClass();
        }
        // GET: Player
        public JsonResult GetPlayers()
        {
            List<Player> listOfPlayers = _context.Players.ToList();
            return Json( new { players = listOfPlayers },JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id)
        {
            Player PlayerWithId = _context.Players.Where(c => c.PlayerId == id).SingleOrDefault();
            return Json(new { player = PlayerWithId }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new  { status = "Added Player Succesfully" });
        }



        public JsonResult UpdatePlayer(Player player)
        {

            //var result = _context.Players.Where(c => c.PlayerId == id).SingleOrDefault();
            //if (result != null)
            //{
            //    result.Name = "Some new value"; // Won't work as only a single value would be updated
            //    _context.SaveChanges();
            //}

            // More Info
            // http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record/15339512#15339512


            _context.Entry(player).State = System.Data.Entity.EntityState.Modified; 
            _context.SaveChanges();
            return Json(new { status = " Player Updated Succesfully" });
        }


        public JsonResult DeletePlayer(int id)
        {
            Player PlayerWithId = _context.Players.Where(c => c.PlayerId == id).SingleOrDefault();
            _context.Players.Remove(PlayerWithId);
            _context.SaveChanges();
            return Json(new { status = " Player Deleted Succesfully" });
        }


    }
}