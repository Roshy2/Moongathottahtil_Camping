using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moongathottathil_Camping.Models
{
    public class Campingplatzreservierung
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Strasse { get; set; }
        public int Plz { get; set; }
        public string Ort { get; set; }
        public int Telefonnummer { get; set; }
        public string Email { get; set; }
        public string Reservierplatz { get; set; }
    }
}