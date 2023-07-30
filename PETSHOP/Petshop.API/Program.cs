using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Petshop.BL.Repositories;
using Petshop.DAL.Contexts;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
builder.Services.AddCors(opt =>
{
   // opt.AddPolicy(name: "izinverilenler", policy => { policy.WithOrigins("http://localhost:5190/").AllowAnyHeader().AllowAnyMethod().AllowCredentials(); });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5174",
        ValidAudience = "n65",
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benimözelkeybilgisi"))
    };

});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sw=>
{
    sw.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Petshop Web API- Version 1",
        Description = "Bu proje.net core 7.0 ile geliþtirilmiþtir",
        TermsOfService = new Uri("http://www.petshop.com/sozlesme"),
        Contact =new OpenApiContact
        {
            Name="Efe Yusuf Kurt",
            Email="efe.yusuf_kurt@hotmail.com"
            
        },    
        License= new OpenApiLicense
        {
            Name = " MIT License",
            Url=new Uri("http://www.petshop.com/apilisance"),

        }
    });

    sw.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml"));

});

var app = builder.Build();
app.UseCors("izinverilenler");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
