using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekreta_wpf_.Models
{
    public class Felhasznalo
    {
        public Felhasznalo()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Jelszo { get; set; }
        public int Szerepkor { get; set; }

        public Felhasznalo(string felhasznaloNev, string teljesNev, string jelszo, int szerepkor)
        {
            FelhasznaloNev = felhasznaloNev;
            TeljesNev = teljesNev;
            Jelszo = jelszo;
            Szerepkor = szerepkor;
        }
    }
}
