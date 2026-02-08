using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VendingMachinesApi26.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

builder.Services.AddDbContext<VendingMachines26Context>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });
var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Map("/login/api/v1/SignIn", async (User emp, VendingMachines26Context db) =>
{
    User? employee = await db.Users.FirstOrDefaultAsync(p => p.Email == emp.Email && p.Password == emp.Password);
   
    var claims = new List<Claim> { new Claim(ClaimTypes.Surname, emp.Password) };
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
    audience: AuthOptions.AUDIENCE,
    claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
    var response = new
    {
        access_token = encoderJWT,
        username = emp.Email
    };
    return Results.Json(response);
});

app.MapPost("/api/machines/post", 
    [Authorize] async (VendingMachine machine, VendingMachines26Context db) => {
    
    VendingMachine newMachine = new VendingMachine
    {
        IdVendingMachine = machine.IdVendingMachine,
        Name = machine.Name,
        Model = machine.Model,
        SerialNumber = machine.SerialNumber,
        InventNumber = machine.InventNumber,
        Company = machine.Company,
        Location = machine.Location,
        Status = machine.Status,
        TotalIncome = machine.TotalIncome,
        LastMaintenanceDate = machine.LastMaintenanceDate,
        NextMaintenanceDate = machine.NextMaintenanceDate,
        InstallDate = machine.InstallDate,
        CreatedDate = machine.CreatedDate
    };
    db.VendingMachines.Add(newMachine);
    db.SaveChanges();
});

app.MapPost("/api/maintainances/post", 
    [Authorize] async (Maintenance maintenance, VendingMachines26Context db) =>
{
    Maintenance new_maintanance = new Maintenance
    {
        IssuesFound = maintenance.IssuesFound,
        WorkDescription = maintenance.WorkDescription,
        Date = maintenance.Date,
        IdUser = maintenance.IdUser,
        IdVendingMachine = maintenance.IdVendingMachine
    };
    db.Maintenances.Add(new_maintanance);
    db.SaveChanges();
});

app.MapPut("/api/machines/put", [Authorize] async (VendingMachine machine, VendingMachines26Context db) =>
{
    VendingMachine? new_machine = db.VendingMachines.FirstOrDefault(m => m.IdVendingMachine ==  machine.IdVendingMachine);
    if (new_machine != null)
    {
        new_machine.IdVendingMachine = machine.IdVendingMachine;
        new_machine.Name = machine.Name;
        new_machine.Model = machine.Model;
        new_machine.SerialNumber = machine.SerialNumber;
        new_machine.InventNumber = machine.InventNumber;
        new_machine.Company = machine.Company;
        new_machine.Location = machine.Location;
        new_machine.Status = machine.Status;
        new_machine.TotalIncome = machine.TotalIncome;
        new_machine.LastMaintenanceDate = machine.LastMaintenanceDate;
        new_machine.NextMaintenanceDate = machine.NextMaintenanceDate;
        new_machine.InstallDate = machine.InstallDate;
        new_machine.CreatedDate = machine.CreatedDate;
        db.Entry(new_machine).State = EntityState.Modified;
        db.Update(new_machine);
        db.SaveChanges();
    }
    return new_machine;
});

app.MapPut("/api/maintainances/put", [Authorize] async (Maintenance maintenance, VendingMachines26Context db) =>
{
    Maintenance? new_maintenance = db.Maintenances.FirstOrDefault(m => m.IdMaintenance == maintenance.IdMaintenance);
    if(new_maintenance != null)
    {
        new_maintenance.IdVendingMachine = maintenance.IdVendingMachine;
        new_maintenance.IssuesFound = maintenance.IssuesFound;
        new_maintenance.IdUser = maintenance.IdUser;
        new_maintenance.WorkDescription = maintenance.WorkDescription;
        new_maintenance.Date = maintenance.Date;
        db.Entry(new_maintenance).State = EntityState.Modified;
        db.Update(new_maintenance);
        db.SaveChanges();
    }
});

app.MapPost("api/users/info", async (string email, VendingMachines26Context db) =>
{
    User? check_user = db.Users.FirstOrDefault(u => u.Email == email);
    return check_user;

});

app.Run();