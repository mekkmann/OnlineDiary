using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnlineDiaryContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineDiaryContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// FOR AUTH0
builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.Authority = builder.Configuration["Auth0:Domain"];
options.Audience = builder.Configuration["Auth0:Audience"];
});


builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "read:books",
        policy => policy.Requirements.Add(
            new HasScopeRequirement("read:books", builder.Configuration["Auth0:Domain"])) 
        );
});
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
}

app.UseHttpsRedirection();

// FOR AUTH0
app.UseAuthentication();
//

app.UseAuthorization(); // also for auth0 but automatically added

app.MapControllers();

app.Run();
