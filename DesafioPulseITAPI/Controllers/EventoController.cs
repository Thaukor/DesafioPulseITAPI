using DesafioPulseITAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPulseITAPI.Controllers
{
    [ApiController]
    [Route( "api/evento" )]
    public class EventoController : Controller
    {
        [HttpGet( "index" )]
        public ActionResult Index ()
        {
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Guardar evento en la BD
                var result = context.Eventos.ToList();
                if ( result != null )
                {
                    return Ok( result );
                }
            }
            return BadRequest();
        }

        [HttpGet( "details/{id}" )]
        public ActionResult Details ( int id )
        {
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Guardar evento en la BD
                Evento result = context.Eventos.First( x => x.Id == id );
                if ( result != null )
                {
                    return Ok( result );
                }
            }
            return BadRequest( "No se pudo encontrar" );
        }

        [HttpPost( "create" )]
        public IActionResult Create ( Evento evento )
        {
            int eventoID = -1;
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Guardar evento en la BD
                var result = context.Add( evento );
                context.SaveChanges();

                Console.WriteLine( result.Entity.Id );

                // Conseguir el ID del evento creado
                eventoID = result.Entity.Id;
            }

            return Ok( eventoID );
        }

        [HttpGet( "edit" )]
        public ActionResult Edit ( int id )
        {
            return Ok();  
        }

        [HttpPost( "edit" )]
        public ActionResult Edit ( int id, IFormCollection collection )
        {
            try
            {
                return RedirectToAction( nameof( Index ) );
            }
            catch
            {
                return Ok();
            }
        }

        [HttpGet( "delete" )]
        public ActionResult Delete ( int id )
        {
            return Ok();
        }

        [HttpPost( "delete" )]
        public ActionResult Delete ( int id, IFormCollection collection )
        {
            try
            {
                return RedirectToAction( nameof( Index ) );
            }
            catch
            {
                return Ok();
            }
        }
    }
}
