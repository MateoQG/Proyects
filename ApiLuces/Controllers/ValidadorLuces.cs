using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLuces.Propiedades;
using ApiLuces.DTO;
using AutoMapper;
using System;
using ApiLuces.Servicio;

namespace ApiLuces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidadorLuces : ControllerBase
    {
        
        private readonly IPatronLucesService _patronLucesService;
        private readonly IMapper _mapper;

        public ValidadorLuces(IPatronLucesService patronLucesService, IMapper mapper)
        {
            
            _patronLucesService= patronLucesService;
            _mapper = mapper;
        }



        [HttpPost("/Patron")]
        public IActionResult ValidadorPatron(PatronLucesDTO dato)
        {
            var info = _mapper.Map<PatronLuces>(dato);
            _patronLucesService.AlmacenarPatronLuces(info);
            return Ok(info);
        }


        [HttpPost("/Medición")]
        public IActionResult EnrutadorMedicion( MedicionLucesDTO dto)
        {
            var patronLuces = _patronLucesService.GetPatronLuces();
            if (patronLuces == null)
            {
                return BadRequest("No se ha establecido un patrón de luces. Por favor,indique el patron.");
            }
            var lucesConMedicionRequerida = new List<string>();
            var lucesConMedicionNoRequerida = new List<string>();

            var dato = _mapper.Map<MedicionLucesDTO>(dto);

            if (patronLuces.Int_Baja_Izq_1 == false)
            {
                if (dato.Int_Baja_Izq_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Int_Baja_Izq_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Int_Baja_Izq_1));
                }
            }
            else
            {
                if (dato.Int_Baja_Izq_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Int_Baja_Izq_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Int_Baja_Izq_1));
                }
            }

            if (patronLuces.Inc_Baja_Izq_1 == false)
            {
                if (dato.Int_Baja_Izq_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Inc_Baja_Izq_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Inc_Baja_Izq_1));
                }
            }
            else
            {
                if (dato.Inc_Baja_Izq_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Inc_Baja_Izq_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Inc_Baja_Izq_1));
                }
            }

            if (patronLuces.Int_Baja_Der_1 == false)
            {
                if (dato.Int_Baja_Der_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Int_Baja_Der_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Int_Baja_Der_1));
                }
            }
            else
            {
                if (dato.Int_Baja_Der_1 == null)
                {
                    lucesConMedicionRequerida.Add(nameof(dato.Int_Baja_Der_1));
                }
                else
                {
                    lucesConMedicionNoRequerida.Add(nameof(dato.Int_Baja_Der_1));
                }
            }

            var respuesta = new
            {
                LucesConMedicionRequerida = lucesConMedicionRequerida,
                LucesConMedicionNoRequerida = lucesConMedicionNoRequerida

            };            

            return Ok(respuesta);
        }
    
     
    }
}
    
