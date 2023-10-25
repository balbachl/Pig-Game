using Microsoft.AspNetCore.Mvc;
using Pig.Models;
using System.Diagnostics;

namespace Pig.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            // get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            // notify if there's a winner 
            if (game.IsGameOver)
            {
                TempData["message"] = $"{game.CurrentPlayerName} wins!";
            }

            // pass game object to view
            return View(game);
        }

        [HttpPost]
        public IActionResult NewGame()
        {
            // get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.NewGame();

            // store game object in session and redirect (PRG pattern)
            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Roll()
        {
            // get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Roll();

            // store game object in session and redirect (PRG pattern)
            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Hold()
        {
            // get game object from session
            var sess = new GameSession(HttpContext.Session);
            var game = sess.GetGame();

            game.Hold();

            // store game object in session and redirect (PRG pattern)
            sess.SetGame(game);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}