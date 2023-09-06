using DesafioPulseITAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPulseITAPI.Controllers
{
    [ApiController]
    [Route( "api/invitado" )]
    public class InvitadoController : Controller
    {
        [HttpGet( "index" )]
        public ActionResult Index ()
        {
            return Ok();
        }

        [HttpGet( "details/{id}" )]
        public ActionResult Details ( int id )
        {
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Guardar evento en la BD
                Invitado result = context.Invitados.First( x => x.Id == id );
                if (result  != null)
                {
                    return Ok( result );
                }
            }
            return BadRequest( "No se pudo encontrar" );
        }

        [HttpPost( "create" )]
        public IActionResult Create ( Invitado invitado )
        {
            // Crear lista con los ID de las invitaciones
            int idInvitacion = -1;
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Guardar evento en la BD
                var result = context.Add( invitado );
                context.SaveChanges();

                // Conseguir el ID de la invitación creado
                idInvitacion = result.Entity.Id;
            }

            return Ok( idInvitacion );
        }

        [HttpPost( "edit" )]
        public ActionResult Edit ( Invitado invitado )
        {
            using ( DesafioPulseItContext context = new DesafioPulseItContext() )
            {
                // Recuperar invitación de la BD
                Invitado result = context.Invitados.First( x => x.Id == invitado.Id );
                // El invitado respondió la invitación
                result.Respondio = true;
                // Actualizar asistencia
                result.Asiste = invitado.Asiste;
                context.SaveChanges();

                if ( result != null )
                {
                    return Ok( result );
                }
            }
            return BadRequest( "No se pudo encontrar" );
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
