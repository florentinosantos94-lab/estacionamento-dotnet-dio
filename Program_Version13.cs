using MinimalApiVeiculos.Models;
using MinimalApiVeiculos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT Config
var secretKey = builder.Configuration["JwtSecret"] ?? "super_secret_key_123";
builder.Services.AddSingleton(new JwtService(secretKey));
builder.Services.AddSingleton<AdminService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
        };
    });

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

var veiculos = new List<Veiculo>();

app.MapPost("/login", (Admin login, JwtService jwt, AdminService adminService) =>
{
    if (!adminService.Validate(login.Username, login.Password))
        return Results.Unauthorized();

    var token = jwt.GenerateToken(login.Username);
    return Results.Ok(new { token });
});

app.MapPost("/veiculos", (Veiculo veiculo) =>
{
    veiculos.Add(veiculo);
    return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
}).RequireAuthorization();

app.MapGet("/veiculos", () => veiculos).RequireAuthorization();

app.MapGet("/veiculos/{id}", (Guid id) =>
{
    var veiculo = veiculos.FirstOrDefault(v => v.Id == id);
    return veiculo is null ? Results.NotFound() : Results.Ok(veiculo);
}).RequireAuthorization();

app.MapDelete("/veiculos/{id}", (Guid id) =>
{
    var veiculo = veiculos.FirstOrDefault(v => v.Id == id);
    if (veiculo is null) return Results.NotFound();
    veiculos.Remove(veiculo);
    return Results.NoContent();
}).RequireAuthorization();

app.Run();