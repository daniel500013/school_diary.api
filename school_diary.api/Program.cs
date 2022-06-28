using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using school_diary.api.Model;
using school_diary.api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DiaryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Diary API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              { securitySchema, new[] { "Bearer" } }
          });
});

var auth = new authSettings();
builder.Configuration.GetSection("Jwt").Bind(auth);

// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.Audience = "https://localhost:7167";
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = auth.Issuer,
        ValidAudience = auth.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.Key)),
    };
});

builder.Services.AddScoped<accountService>();
builder.Services.AddScoped<lessonService>();
builder.Services.AddScoped<markService>();
builder.Services.AddScoped<gradeService>();
builder.Services.AddScoped<roleService>();
builder.Services.AddScoped<classManagerService>();
builder.Services.AddScoped<approveService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddSingleton(auth);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
