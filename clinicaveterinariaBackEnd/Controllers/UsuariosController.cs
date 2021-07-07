using AutoMapper;
using clinicaveterinariaBackEnd.Dtos.ClienteDtos;
using clinicaveterinariaBackEnd.Dtos.Respuestas;
using clinicaveterinariaBackEnd.Dtos.UsuariosDtos;
using clinicaveterinariaBackEnd.Entities;
using clinicaveterinariaBackEnd.Helps;
using clinicaveterinariaBackEnd.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _datacontex;
        private readonly IMapper _mapper;
        private  IUserService _userService;
        private readonly AppSettings _appSettings;
        public UsuariosController(DataContext datacontex,
                                 IMapper mapper,
                                 IOptions<AppSettings> appSetting,
                                 IUserService userService)
        {
            _userService = userService;
            _datacontex = datacontex;
            _mapper = mapper;
            _appSettings = appSetting.Value;
        }

        [HttpGet("{IdUsuario}")]
        public async Task<ActionResult> Obtener_Usuario(Guid IdUsuario)
        {
            Respuesta resp = new();
            Usuario usaurio = await _datacontex.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario.ToString());
            if (usaurio != null)
            {
                resp.exito = true;
                resp.mensaje = "Se obtuvo el Cliente Exitosamente";
                resp.data = usaurio;
                return Ok(resp);
            }
            else
            {
                resp.exito = false;
                resp.mensaje = "No se Obtuvo Cliente";
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Grabar_Usuario(UsuarioGrabar usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.IdUsuario = Guid.NewGuid().ToString();
            Usuario UsuarioGrabado =_userService.Create(usuario, usuarioDto.password);
            UsuarioDto usuarioResponder = _mapper.Map<UsuarioDto>(UsuarioGrabado);
            usuarioResponder.token = Obtener_Token(new UsuarioLogin() { username = usuarioDto.username, password = usuarioDto.password });
            return Ok(usuarioResponder);
            //return CreatedAtAction(nameof(Obtener_Usuario), new { username = usuarioResponder.id }, usuarioResponder);
        }

        public string Obtener_Token(UsuarioLogin model)
        {
            var userAuthenticated = _userService.Authenticate(model.username, model.password);

            if (userAuthenticated == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userAuthenticated.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, userAuthenticated.EmailUsuario),
                    new Claim(ClaimTypes.Role, "admin"),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // return basic user info (without password) and token to store client side
            //UsuarioDto userDto = _mapper.Map<UsuarioDto>(userAuthenticated);
            string tokenReturn = tokenHandler.WriteToken(token);
            return tokenReturn;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UsuarioLogin model)
        {
            var userAuthenticated = _userService.Authenticate(model.username, model.password);

            //if (userAuthenticated.EstadoVerificadorUsuario ==  UsuarioEmailVerificacionEnum.NOVERIFICADO)
            //    return BadRequest(new { message = "unauthenticated user" });

            if (userAuthenticated == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userAuthenticated.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Email, userAuthenticated.EmailUsuario),
                    new Claim(ClaimTypes.Role, "admin"),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // return basic user info (without password) and token to store client side
            UsuarioDto userDto = _mapper.Map<UsuarioDto>(userAuthenticated);
            userDto.token = tokenHandler.WriteToken(token);

            return Ok(userDto);
        }
    }
}
