using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using server.Data;
using server.Interfaces;
using server.Models;
using server.Repository;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Services

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "GameVault API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });


    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var signingKey = builder.Configuration["JWT:SigningKey"] ?? throw new InvalidOperationException("JWT:SigningKey configuration is missing.");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey))
    };
});

builder.Services.AddScoped<IReviewRepo, ReviewRepository>();
builder.Services.AddScoped<IGameRepo, GameRepository>();
builder.Services.AddScoped<IGenreRepo, GenreRepository>();
builder.Services.AddScoped<IFranchiseRepo, FranchiseRepository>();
builder.Services.AddScoped<IStatusRepo, StatusRepository>();
builder.Services.AddScoped<IImageRepo, ImageRepository>();
builder.Services.AddScoped<IDeveloperRepo, DeveloperRepository>();
builder.Services.AddScoped<IPublisherRepo, PublisherRepository>();
builder.Services.AddScoped<IVideoGameCollectionRepo, VideoGameCollectionRepository>();
builder.Services.AddScoped<IVideoGameGenreRepo, VideoGameGenreRepository>();
builder.Services.AddScoped<INewsRepo, NewsRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddHttpClient<IGDBService>(service =>
{
    service.BaseAddress = new Uri("https://api.igdb.com/v4/");
    service.DefaultRequestHeaders.Add("Accept", "application/json");
    service.DefaultRequestHeaders.Add("Client-ID", builder.Configuration["IGDB:ClientID"]);
    service.DefaultRequestHeaders.Add("Authorization", $"Bearer {builder.Configuration["IGDB:AccessToken"]}");
});

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}






app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin => true));

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
