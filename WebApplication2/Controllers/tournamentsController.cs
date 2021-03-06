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
    public class tournamentsController : Controller
    {
        private DBmodel db = new DBmodel();

        // GET: tournaments
        public ActionResult Index()
        {
            return View(db.tournaments.ToList());
        }

        // GET: tournaments/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: tournaments/Create
        public ActionResult Create()
        {
            return View(new tournament());
        }
        

        // POST: tournaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nb_participants,description,game,name,start_date,team_size")] tournament tournament)
        {
            if (ModelState.IsValid)
            {
                
                db.tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(tournament);
        }


        public ActionResult CreateGame([Bind(Include = "id,nb_participants,description,game,name,start_date,team_size")] long? id)
        {

            tournament t = db.tournaments.Find(id);
            return RedirectToAction("Create", "games", new game(t:t));
        }
        // GET: tournaments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();  
            }
            return View(tournament);
        }

        // POST: tournaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id, nb_participants,description,game,name,start_date,team_size")] tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }


        public ActionResult addTeam(long? id)
        {

            tournament t = db.tournaments.Find(id);
            return RedirectToAction("Create", "teams", new team(tournamentId: t.id));

        }

        // GET: tournaments/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tournament tournament = db.tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tournament tournament = db.tournaments.Find(id);
            foreach (team t in tournament.teams.ToList())
            {
                foreach (player p in t.players.ToList())
                {
                    db.players.Remove(p);
                }
                db.SaveChanges();
                db.teams.Remove(t);
            }
            db.SaveChanges();
            db.games.RemoveRange(tournament.games);
            db.SaveChanges();
            db.tournaments.Remove(tournament);
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
