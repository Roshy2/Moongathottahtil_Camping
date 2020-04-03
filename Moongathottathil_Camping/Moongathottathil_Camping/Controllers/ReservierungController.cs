using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Moongathottathil_Camping.Models;
using Moongathottathil_Camping.Models.db;

namespace Moongathottathil_Camping.Controllers
{
    public class ReservierungController : Controller
    {
        private IRepositoryAnfrage rep;
        // GET: Reservierung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Anfrage()
        {
            return View(new Campingplatzreservierung());
        }
       [HttpPost]
        public ActionResult Anfrage(Campingplatzreservierung campres)
        {
            if(campres == null)
            {
                return RedirectToAction("Anfrage");
            }

            CheckAnfrage(campres);

            if (!ModelState.IsValid)
            {
                return View(campres);
            }
            else
            {
                rep = new RepositoryAnfrageDB();
                rep.Open();
                if (rep.Insert(campres))
                {
                    rep.Close();
                    return View("Message", new Message("Anfrage", "Ihre Daten wurden erfolgreich abgespeichert!"));
                }
                else
                {
                    rep.Close();
                    return View("Message", new Message("Anfrage", "Ihre Daten konnten nicht abgespeichert werden!"));
                }
            }
        }

        private void CheckAnfrage(Campingplatzreservierung campres)
        {
            if(campres == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(campres.Vorname.Trim()))
            {
                ModelState.AddModelError("Vorname", "Vorname ist ein Pflichtfeld.");
            }
            if (string.IsNullOrEmpty(campres.Nachname.Trim()))
            {
                ModelState.AddModelError("Nachname", "Nachname ist ein Pflichtfeld.");
            }
            if ((campres.Von == null) || (DateTime.Now > campres.Von))
            {
                ModelState.AddModelError("Von", "Von ist ein Pflichtfeld.");
            }
            if ((campres.Bis == DateTime.MinValue) || (campres.Bis < campres.Von))
            {
                ModelState.AddModelError("Bis", "Bis ist ein Pflichtfeld.");
            }
            if (string.IsNullOrEmpty(campres.Strasse.Trim()))
            {
                ModelState.AddModelError("Strasse", "Strasse ist ein Pflichtfeld.");
            }
            if ((campres.Plz <999) || (campres.Plz >100000))
            {
                ModelState.AddModelError("Plz", "Plz ist ein Pflichtfeld.");
            }
            if (string.IsNullOrEmpty(campres.Ort.Trim()))
            {
                ModelState.AddModelError("Ort", "Ort ist ein Pflichtfeld.");
            }

            if (string.IsNullOrEmpty(campres.Email.Trim()))
            {
                ModelState.AddModelError("Email", "Email ist ein Pflichtfeld.");
            }
            if (string.IsNullOrEmpty(campres.Reservierplatz.Trim()))
            {
                ModelState.AddModelError("Reservierplatz", "Reservierplatz ist ein Pflichtfeld.");
            }
        }
    }
}