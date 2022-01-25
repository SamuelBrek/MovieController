using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicula.Domain.entities
{
    public class Repelis
    {
        public int idMovie { get; set; }
        public string titleMovie { get; set; }
        public string directorMovie { get; set; }
        public string genreMovie { get; set; }
        public int puntMovie { get; set; }
        public int ratingMovie { get; set; }
        public int ypubliMovie { get; set; }
    }
}