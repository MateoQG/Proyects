using ApiLuces.Propiedades;

namespace ApiLuces.Servicio
{
    public interface IPatronLucesService
    {
        void AlmacenarPatronLuces(PatronLuces patron);
        PatronLuces GetPatronLuces();
    }
}