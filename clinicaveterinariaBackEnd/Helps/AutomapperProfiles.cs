using AutoMapper;
using clinicaveterinariaBackEnd.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Helps
{
    public class AutomapperProfiles
    {
        public static Action<IMapperConfigurationExpression> ProfilesConfig =
            new Action<IMapperConfigurationExpression>(cfg =>
            {
                cfg.AddProfile<ClienteProfiles>();
                cfg.AddProfile<MascotasProfiles>();
                cfg.AddProfile<RazaProfiles>();
                cfg.AddProfile<UsuarioProfile>();
                //cfg.AddProfile<EmpresasRetornarProfile>();
                //cfg.AddProfile<EmpresaProfile>();
                //cfg.AddProfile<ComprobantePagoReturnProfile>();
                //cfg.AddProfile<SolicitudPagosProfile>();
                //cfg.AddProfile<UsuarioVizualiarIngresoProfile>();
                //cfg.AddProfile<UsuariosProfile>();
                //cfg.AddProfile<TiposEmpresaProfile>();
                //cfg.AddProfile<EmpresaVizualizarProfile>();
                //cfg.AddProfile<SolicitudPagoRetornarComprobanteProfile>();
                //cfg.AddProfile<TarjetaVizualizarComprobanteProfile>();
                //cfg.AddProfile<BancoVizualizarComprobanteProfile>();
                //cfg.AddProfile<PerfilesProfile>();
                //cfg.AddProfile<BancoVizualizarProfile>();
                //cfg.AddProfile<MediaProdifle>();
                //cfg.AddProfile<PermisosProfile>();
            });
    }
}
