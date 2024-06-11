using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetCare.Domain;
using PetCare.Infrastructure;
using PetCare.Web.Components;
using PetCare.Web.Components.Account;
using PetCare.Domain;
using PetCare.Domain.Interfaces;
using PetCare.Infrastructure.Repositories;
using MudBlazor.Services;
using PetCare.Aplication.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddMvcCore();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
#region dependencies

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<IPetDetailsRepository, PetDetailsRepository>();
builder.Services.AddScoped<IClinicVisitRepository, ClinicVisitRepository>();
builder.Services.AddScoped<IStVaccinesRepository, StVaccinesRepository>();

builder.Services.AddScoped<PetUseCase>();
builder.Services.AddScoped<StVaccineUseCase>();


#endregion

builder.Services.AddSwaggerGen (c =>
{
    c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
});

// #region Minio
// var config = builder.Configuration.GetSection("Minio");
// builder.Services.AddMinio(client => client
//     .WithEndpoint(config.GetSection("Endpoint").Value)
//     .WithCredentials(config.GetSection("AccessKey").Value, config.GetSection("SecretKey").Value)
//     .WithSSL(true));
// builder.Services.AddScoped<IFileRepository, FileRepository>();
// #endregion

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ADMIN", policy => policy.RequireRole("ADMIN"));
    options.AddPolicy("GUEST", policy => policy.RequireRole("GUEST"));
});

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(PetCare.PetApp._Imports).Assembly)
    .AddAdditionalAssemblies(typeof(PetCare.Admin._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

//dotnet ef database update --project .\PetCare.Infrastructure\PetCare.Infrastructure.csproj --startup-project .\PetCare.Web\PetCare.Web.csproj
//dotnet ef migrations add InitialMigration --project .\PetCare.Infrastructure\PetCare.Infrastructure.csproj --startup-project .\PetCare.Web\PetCare.Web.csproj
