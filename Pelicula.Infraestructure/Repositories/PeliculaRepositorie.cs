using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelicula.Domain.entities;

namespace Pelicula.Infraestructure.Repositories
{
    public class PeliculaRepositorie
    {
        public static List<Repelis> _movies = new List<Repelis>();

        public IEnumerable<Repelis> GetAllMovies(){
            return _movies;
        }

        public Repelis GetById(int id)
        {
            var movies = _movies.Where(movie => movie.idMovie == id);
            return movies.FirstOrDefault();
        }

        public IEnumerable<Repelis> GetDirectors(string director)
        {
            var movies = _movies.Where(movie => movie.directorMovie == director);
            return movies;
        }


        public void CreateMovie (Repelis newMovie)
        {
            _movies.Add(newMovie);
        }

        public void UpdateMovie (int id, Repelis updateMovie)
        {
            if (id <= 0 || updateMovie == null)
            {
                throw new ArgumentException("Falta aún información por completar");
            }
            var entity = GetById(id);

            entity.titleMovie = updateMovie.titleMovie;
            entity.directorMovie = updateMovie.directorMovie;
            entity.genreMovie = updateMovie.genreMovie;
            entity.puntMovie = updateMovie.puntMovie;
            entity.ratingMovie = updateMovie.ratingMovie;
            entity.ypubliMovie = updateMovie.ypubliMovie;
            _movies.Remove(entity);
            _movies.Add(entity);
        }

        public void DeleteMovie (int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Falta aún información por completar");
            }
            var result = GetById(id);
            _movies.Remove(result);
        }

    }
}