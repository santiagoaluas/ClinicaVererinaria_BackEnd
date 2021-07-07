using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.MascotaDtos;
using clinicaveterinariaBackEnd.Entities;
using clinicaveterinariaBackEnd.Helps;
using clinicaveterinariaBackEnd.Helps.Respuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;

        public MascotaController(DataContext dataContext,
                               IMapper mapper)
        {
            _datacontext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMastocasAsync()
        {
            try
            {
                List<Mascota> listaMascota = await _datacontext.Mascota.ToListAsync();
                return listaMascota.Count > 0 ? Ok(new RespuestaServer { exito = true, mesaje = "Existo lista", data = listaMascota }) : 
                                                Ok(new RespuestaServer { exito = true, mesaje = "No hay mascotas para mostrar" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaServer { exito = false, mesaje = ex.Message });
            }
        }
        [HttpGet("{criteriobusqueda}")]
        public async Task<IActionResult> ObtenerMascota(string criteriobusqueda)
        {
            try
            {
                List<Mascota> listaMascota = await _datacontext.Mascota.Where(x => x.Cliente.CedulaCliente.Contains(criteriobusqueda)
                                                                              || x.Cliente.NombreCliente.Contains(criteriobusqueda)
                                                                              || x.Cliente.ApellidoCliente.Contains(criteriobusqueda))
                                                                              .OrderBy(x => x.Cliente.ApellidoCliente).ToListAsync();
                return listaMascota.Count > 0 ? Ok(new RespuestaServer { exito = true, mesaje = "Existo lista", data = listaMascota }) :
                                                Ok(new RespuestaServer { exito = true, mesaje = "No hay mascotas para mostrar" });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaServer { exito = false, mesaje = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMascota(CreateMascotaDto mascota)
        {
            try
            {
                Mascota CreateMascota = _mapper.Map<Mascota>(mascota);
                await _datacontext.Mascota.AddAsync(CreateMascota);
                return Ok(CreateMascota);
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaServer { exito = false, mesaje = ex.Message });
            }
        }
    }
}
