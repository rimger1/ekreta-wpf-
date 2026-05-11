using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekreta_wpf_.Models
{
    public class Osztaly
    {
        public Osztaly()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Osztalynev { get; set; }
        public int TeremId { get; set; }

        public Osztaly(string osztalynev, int teremId)
        {
            Osztalynev = osztalynev;
            TeremId = teremId;
        }
    }
}
