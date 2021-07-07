using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.RazaDtos;
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
    [Route("[controller]")]
    [ApiController]
    public class RazaController : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;

        public RazaController(DataContext dataContext,
                               IMapper mapper)
        {
            _datacontext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerMascotasAsync()
        {
            try
            {
                List<Raza> listaRazas = await _datacontext.Razas.ToListAsync();
                List<RazaDto> RazasDto = _mapper.Map<List<RazaDto>>(listaRazas);
                return Ok(new RespuestaServer
                {
                    exito =true,
                    mesaje = "Se obtuvo correctectamente los datos",
                    data = RazasDto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaServer
                {
                    exito = false,
                    mesaje = ex.Message
                });
            }
            

        }

    }
}
