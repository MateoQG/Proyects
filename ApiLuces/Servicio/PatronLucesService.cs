using ApiLuces.Propiedades;
using ApiLuces.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace ApiLuces.Servicio
{
    public class PatronLucesService : IPatronLucesService
    {

        private readonly IMemoryCache _memoryCache;
        private const string PatronLucesCacheKey = "PatronLuces";

        public PatronLucesService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AlmacenarPatronLuces(PatronLuces patron)
        {
            // Almacenar en caché con una expiración de 1 hora
            _memoryCache.Set(PatronLucesCacheKey, patron, TimeSpan.FromHours(1));
        }

        public PatronLuces GetPatronLuces()
        {
            // Intentar obtener el valor de la caché
            if (_memoryCache.TryGetValue(PatronLucesCacheKey, out PatronLuces patronLuces))
            {
                return patronLuces;
            }

            // Si no está en caché, devolver null o manejar según sea necesario
            return null;
        }
    }

}

