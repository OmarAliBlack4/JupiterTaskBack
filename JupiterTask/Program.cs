using JupiterTask.Data;
using JupiterTask.Entites;
using JupiterTask.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JupiterTask
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(Opthion =>
            {
                Opthion.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<IdentityStoreContext>(Opthion =>
            {
                Opthion.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddIdentity<UserIdentity, IdentityRole>()
                .AddEntityFrameworkStores<IdentityStoreContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<RoleAndUserService>();

            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevClient",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") //My Local
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });
            #endregion

            var app = builder.Build();

            #region Auto Update DataBase
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            await dbContext.Database.MigrateAsync();

            var roleAndUserService = services.GetRequiredService<RoleAndUserService>();
            await roleAndUserService.CreateAdminRoleAndUserAsync(); 
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            
            app.UseCors("AllowAngularDevClient"); 

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}