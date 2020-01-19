﻿using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using BulbaCourses.DiscountAggregator.Logic;
using BulbaCourses.DiscountAggregator.Logic.Models;
using BulbaCourses.DiscountAggregator.Web.App_Start;
using BulbaCourses.DiscountAggregator.Web.Filters;
using BulbaCourses.DiscountAggregator.Web.Properties;
using FluentValidation;
using FluentValidation.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(BulbaCourses.DiscountAggregator.Web.Startup))]

namespace BulbaCourses.DiscountAggregator.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            SwaggerConfig.Register(config);
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new BadRequestFilterAttribute());

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                IssuerName = "http://localhost:44382",
                Authority = "http://localhost:44382",
                ValidationMode = ValidationMode.Local,
                SigningCertificate = new X509Certificate2(Resources.bulbacourses, "123")

            });

            app.UseNinjectMiddleware(() => ConfigureValidation(config)).UseNinjectWebApi(config);
        }

        private IKernel ConfigureValidation(HttpConfiguration config)
        {
            var kernel = new StandardKernel(new LogicModule());

            kernel.Load<AutoMapperLoad>();

            // Web API configuration and services
            FluentValidationModelValidatorProvider.Configure(config,
                cfg => cfg.ValidatorFactory = new NinjectValidationFactory(kernel));

            //IValidator<Course>
            AssemblyScanner.FindValidatorsInAssemblyContaining<Course>()
                .ForEach(result => kernel.Bind(result.InterfaceType)
                    .To(result.ValidatorType));
               
            return kernel;
        }
    }
}
