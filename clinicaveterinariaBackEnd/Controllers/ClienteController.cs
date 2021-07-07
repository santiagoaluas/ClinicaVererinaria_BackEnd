using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.ClienteDtos;
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
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _datacontex;
        private readonly IMapper _mapper;

        public ClienteController(DataContext datacontex,
                                 IMapper mapper)
        {
            _datacontex = datacontex;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> All_Clientes()
        {
            List<Cliente> listaClientes = await _datacontex.Clientes.ToListAsync();
            List<ClienteDto> ClientesDtos = _mapper.Map<List<ClienteDto>>(listaClientes);
            return listaClientes.Count > 0 ? Ok(new RespuestaServer { exito = true, mesaje = "Existo lista", data = ClientesDtos }) :
                                            Ok(new RespuestaServer { exito = false, mesaje = "No hay mascotas para mostrar" });
        }

    }
}
