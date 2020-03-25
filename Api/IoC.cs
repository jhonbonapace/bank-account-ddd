using Aplicacao.Implementacao;
using Aplicacao.Interface;
using Infraestrutura.Repositorio.Implementacao;
using Infraestrutura.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class IoC
    {
        public static void ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IContaCorrenteServico, ContaCorrenteServico>();
            services.AddScoped<IContaCorrenteMovimentacaoServico, ContaCorrenteMovimentacaoServico>();

            services.AddScoped<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            services.AddScoped<IContaCorrenteMovimentacaoRepositorio, ContaCorrenteMovimentacaoRepositorio>();
        }
    }
}