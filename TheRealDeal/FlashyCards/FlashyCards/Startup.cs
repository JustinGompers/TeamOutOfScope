﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashyCards.DAL;
using FlashyCards.DAL.FlashCardDAL;
using FlashyCards.DAL.FlashCardDeckDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FlashyCards
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<UserRegisterDataAccessLayer, UserRegisterDataAccessLayer>(x => new UserRegisterDataAccessLayer(@"Data Source=.\sqlexpress;Initial Catalog=FlashCardDB;Integrated Security=true"));
            services.AddScoped<DeckOptionsDAL, DeckOptionsDAL>(x => new DeckOptionsDAL(@"Data Source=.\sqlexpress;Initial Catalog=FlashCardDB;Integrated Security=true"));
            services.AddScoped<CardOptionsDAL, CardOptionsDAL>(x => new CardOptionsDAL(@"Data Source=.\sqlexpress;Initial Catalog=FlashCardDB;Integrated Security=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
