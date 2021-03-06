﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DatingApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using DatingApp.Api.Helpers;
using AutoMapper;
namespace DatingApp.Api
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
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            services.AddAutoMapper();
            services.AddTransient<Seed>();
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IDatingRepository,DatingRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=> {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(
                        Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                  //if an appln encounters exception captures the exception in developer friendly page
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder => {
                                        builder.Run (async context => {
                                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                            var error = context.Features.Get<IExceptionHandlerFeature>();
                                            if(error != null)
                                            {
                                                context.Response.AddApplicationError(error.Error.Message);
                                                await context.Response.WriteAsync(error.Error.Message);            
                                            }
                                        }) ;
                                    });       
            }

            //seeder.SeedUsers();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            
            //app.UseHttpsRedirection();
             //tells the framework we are using for this application, gives the ability to route different actions
            //Mvc is the middle that connects the software web requests to the data
            //this supports attribute routing. what this means is if you go to sample values controller it has Route[routename]
            //this translates to http://localhost:5000/api/[controllername] here values
            //inside the controller several actions like Get, Get(int id)
            //Get http://localhost:5000/api/values hits the default Get method
            //Get http://localhost:5000/api/values/5 hits Get(int id) because the method has HttpGet
            //POST will hit default post method http://localhost:5000/api/values/5 Post([FromBody] string value)
            app.UseMvc();
            
        }
    }
}
