using Api.Interface;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class TvShowController : ControllerBase
	{
		private readonly ICrud _dataTvShow;

		public TvShowController(ICrud dataTvShow)
		{
			_dataTvShow = dataTvShow;
		}

		/// <summary>
		/// Obtiene todos los programas de TV.
		/// </summary>
		/// <returns>Lista de todos los programas de TV.</returns>
		[HttpGet]
		[ProducesResponseType(200)]
		public ActionResult<IEnumerable<MTvShowClass>> Get()
		{
			return Ok(_dataTvShow.GetData());
		}

		/// <summary>
		/// Obtiene un programa de TV por su ID.
		/// </summary>
		/// <param name="id">ID del programa de TV.</param>
		/// <returns>El programa de TV correspondiente al ID especificado.</returns>
		/// <response code="200">Programa de TV encontrado correctamente.</response>
		/// <response code="404">Programa de TV no encontrado.</response>
		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(404)]
		public ActionResult<MTvShowClass> Get(int id)
		{
			var tvShow = _dataTvShow.GetData(id);
			if (tvShow == null)
			{
				return NotFound();
			}
			return Ok(tvShow);
		}

		/// <summary>
		/// Añade un nuevo programa de TV.
		/// </summary>
		/// <param name="tvShow">Datos del nuevo programa de TV.</param>
		/// <returns>El programa de TV añadido.</returns>
		/// <response code="201">Programa de TV creado correctamente.</response>
		/// <response code="400">Datos de solicitud inválidos.</response>
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		public ActionResult<MTvShowClass> Post([FromBody] MTvShowClass tvShow)
		{
			if (tvShow == null)
			{
				return BadRequest();
			}
			_dataTvShow.AddTvShow(tvShow);
			return CreatedAtAction(nameof(Get), new { id = tvShow.Id }, tvShow);
		}

		/// <summary>
		/// Actualiza un programa de TV existente por su ID.
		/// </summary>
		/// <remarks>
		/// Ejemplo de solicitud:
		///
		///     PUT /api/tvshow/1
		///     {
		///         "id": 1,
		///         "name": "Nuevo nombre del programa de TV",
		///         "favorite": true
		///     }
		///
		/// </remarks>
		/// <param name="id">ID del programa de TV a actualizar.</param>
		/// <param name="updatedTvShow">Datos actualizados del programa de TV.</param>
		/// <returns>Respuesta HTTP sin contenido.</returns>
		/// <response code="204">Actualización exitosa.</response>
		/// <response code="400">Datos de solicitud inválidos.</response>
		/// <response code="404">Programa de TV no encontrado.</response>
		[HttpPut("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		[ProducesResponseType(400)]
		public ActionResult Put(int id, [FromBody] MTvShowClass updatedTvShow)
		{
			var tvShow = _dataTvShow.GetData(id);
			if (tvShow == null)
			{
				return NotFound();
			}
			if (updatedTvShow == null || id != updatedTvShow.Id)
			{
				return BadRequest();
			}
			_dataTvShow.UpdateTvShow(id, updatedTvShow);
			return NoContent();
		}

		/// <summary>
		/// Elimina un programa de TV por su ID.
		/// </summary>
		/// <param name="id">ID del programa de TV a eliminar.</param>
		/// <returns>Respuesta HTTP sin contenido.</returns>
		/// <response code="204">Eliminación exitosa.</response>
		/// <response code="404">Programa de TV no encontrado.</response>
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public ActionResult Delete(int id)
		{
			var tvShow = _dataTvShow.GetData(id);
			if (tvShow == null)
			{
				return NotFound();
			}
			_dataTvShow.DeleteTvShow(tvShow);
			return NoContent();
		}
	}
}
