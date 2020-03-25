using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura.Extension
{
    public static class ConnectionExtension
    {
        public static void ConfigurarBaseDados(this IServiceCollection services)
        {
            Repositorio.Repositorio.Setup();
        }
    }
}