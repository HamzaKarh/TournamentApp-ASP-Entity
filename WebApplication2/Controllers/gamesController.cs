using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class gamesController : Controller
    {
        private DBmodel db = new DBmodel();

        // GET: games
        public ActionResult Index()
        {
            var games = db.games.Include(g => g.team).Include(g => g.team1).Include(g => g.team2).Include(g => g.tournament);
            return View(games.ToList());
        }

        // GET: games/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: games/Create
        public ActionResult Create()
        {
            ViewBag.rteam_id = new SelectList(db.teams, "id", "name");
            ViewBag.winner_id = new SelectList(db.teams, "id", "name");
            ViewBag.bteam_id = new SelectList(db.teams, "id", "name");
            ViewBag.tournament_id = new SelectList(db.tournaments, "id", "description");
            return View();
        }

        // POST: games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,bteam_id,rteam_id,tournament_id,winner_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rteam_id = new SelectList(db.teams, "id", "name", game.rteam_id);
            ViewBag.winner_id = new SelectList(db.teams, "id", "name", game.winner_id);
            ViewBag.bteam_id = new SelectList(db.teams, "id", "name", game.bteam_id);
            ViewBag.tournament_id = new SelectList(db.tournaments, "id", "description", game.tournament_id);
            return View(game);
        }

        // GET: games/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.rteam_id = new SelectList(db.teams, "id", "name", game.rteam_id);
            ViewBag.winner_id = new SelectList(db.teams, "id", "name", game.winner_id);
            ViewBag.bteam_id = new SelectList(db.teams, "id", "name", game.bteam_id);
            ViewBag.tournament_id = new SelectList(db.tournaments, "id", "description", game.tournament_id);
            return View(game);
        }

        // POST: games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,bteam_id,rteam_id,tournament_id,winner_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rteam_id = new SelectList(game.tournament.teams, "id", "name", game.rteam_id);
            ViewBag.bteam_id = new SelectList(game.tournament.teams, "id", "name", game.bteam_id);
            ViewBag.winner_id = new SelectList(db.teams, "id", "name", game.winner_id);
            ViewBag.tournament_id = new SelectList(db.tournaments, "id", "name", game.tournament_id);
            return View(game);
        }

        // GET: games/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            game game = db.games.Find(id);
            db.games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
