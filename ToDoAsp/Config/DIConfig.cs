using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoAsp.Dao.Repository;
using ToDoAsp.Dao.Service;

namespace ToDoAsp.Config
{
    public static class DIConfig
    {
        public static void Services(WebApplicationBuilder builder)
        {

            //Database Context
            builder.Services.AddDbContext<ApplicationDbContext>(ops =>
                ops.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));



            //JWT Context
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));


            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                       
                        context.Token = context.Request.Cookies["jwtToken"];

                        Console.Write(context.Token);
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            //End JWT Context



            builder.Services.AddScoped<TasksRepository>();
            builder.Services.AddScoped<TasksService>();
        }

    }
}
