using LMS.AutoMapper;
using LMS.Data;
using LMS.Repositories;
using LMS.Repositories.Interfaces;
using LMS.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LMSDB")));


builder.Services.AddControllers();

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBorrowerRepository, BorrowerRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
