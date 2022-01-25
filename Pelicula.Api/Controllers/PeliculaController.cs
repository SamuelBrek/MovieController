using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelicula.Infraestructure.Repositories;
using Pelicula.Domain.entities;

namespace Pelicula.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllMovies()
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            return Ok(movies.GetAllMovies());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById (int id)
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            var movie = movies.GetById(id);
            if (movie == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            return Ok (movie);
        }

        [HttpGet]
        [Route("Directores/{director}")]
        public IActionResult GetGetDirectors (string director)
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            var movie = movies.GetDirectors(director);
            if (movie.Count() == 0)
            {
                return NotFound($"El director {director}, no existe o no tiene créditos en ningúna película registrada .");
            }
            return Ok (movie);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateMovie (Repelis newMovie)
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            movies.CreateMovie(newMovie);
            return Ok("Se ha agregado la pelicula");
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateMovie (int id, Repelis updateMovie)
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            var validation = movies.GetById(id);
            if (validation == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            movies.UpdateMovie(id, updateMovie);
            return Ok("Se ha actualizado la película");
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteMovie (int id)
        {
            PeliculaRepositorie movies = new PeliculaRepositorie();
            var validation = movies.GetById(id);
            if (validation == null)
            {
                return NotFound($"Has ingresado el id {id}, sin embargo, no existe dicha película.");
            }
            movies.DeleteMovie(id);
            return Ok($"Se ha eliminado la película con el id {id}");
        }
    }
}