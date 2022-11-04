using Aggregation.Interfaces;
using Aggregation.Mappings;
using Aggregation.Repository;
using Aggregation.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

const string CORS_POLICY_NAME = "AvtosCORSPolicy";

var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(typeof(AggregateMappings)); });

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mappingConfig);
builder.Services.AddTransient<ICsvData, CsvData>();
builder.Services.AddTransient<IAggregateRepository, AggregateRepository>();


var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AggregationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AggregateDatabase"),
        a => a.MigrationsAssembly("Aggregation.Migrations"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS_POLICY_NAME,
        builder =>
        {
            builder.WithOrigins("https://localhost:44365/");
            builder.AllowAnyHeader();
            builder.WithExposedHeaders("X-TotalResults");
            builder.AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CORS_POLICY_NAME);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();