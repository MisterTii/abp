﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EmbeddedFiles;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.AspNetCore.Mvc
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AbpAspNetCoreMvcUiModule : AbpModule
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAssemblyOf<AbpAspNetCoreMvcUiModule>();

            services.Configure<NavigationOptions>(options =>
            {
                options.MenuContributors.Add(new EmbeddedDemoMainMenuContributor());
            });

            services.Configure<EmbeddedFileOptions>(options =>
            {
                options.Sources.Add(
                    new EmbeddedFileSet(
                        "/Views/",
                        GetType().GetTypeInfo().Assembly,
                        "Volo.Abp.AspNetCore.Mvc.UI.Views"
                        )
                    );
            });
        }
    }
}