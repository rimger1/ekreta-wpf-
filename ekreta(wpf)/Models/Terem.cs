using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekreta_wpf_.Models
{
    public class Terem
    {
        public Terem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TeremNev { get; set; }

        public Terem(string teremNev)
        {
            TeremNev = teremNev;
        }
    }
}
