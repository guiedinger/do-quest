using Do.Quest.Domain.Interfaces.Notifications;
using Do.Quest.Domain.Interfaces.Repositories;
using Do.Quest.Domain.Interfaces.Services;
using Do.Quest.Domain.Notifications;
using Do.Quest.Domain.Services;
using Do.Quest.Infra.Data.Context;
using Do.Quest.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<IGrupoUsuarioService, GrupoUsuarioService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IQuestionarioService, QuestionarioService>();
builder.Services.AddScoped<IQuestionarioRepository, QuestionarioRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<QuestionarioContext>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
      builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
