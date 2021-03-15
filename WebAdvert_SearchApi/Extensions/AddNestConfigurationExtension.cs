using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using WebAdvert_SearchApi.Models;

namespace WebAdvert_SearchApi.Extensions
{
    public static class AddNestConfigurationExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection elasticSeacrhSection = configuration.GetSection("ES");
            var elasticSearchUrl = elasticSeacrhSection.GetValue<string>("url");
            string userName = elasticSeacrhSection.GetValue<string>("UserName");
            string password = elasticSeacrhSection.GetValue<string>("Password");

            var connectionSettings = new ConnectionSettings(new Uri(elasticSearchUrl))
                .BasicAuthentication(userName, password)
                .DefaultIndex("adverts")
                .DefaultMappingFor<AdvertType>(d => d.IndexName("advert"))
                .DefaultMappingFor<AdvertType>(advert => advert.IdProperty(p => p.Id));

            var client = new ElasticClient(connectionSettings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
