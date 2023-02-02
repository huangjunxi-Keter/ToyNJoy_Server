using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToyNJoy.Entity;
using ToyNJoy.Utiliy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ע�����ݿ�������
builder.Services.AddDbContext<ToyNjoyContext>();

// ע���Զ��幤���� builder.Configuration = appsettings.json
builder.Services.AddSingleton(new TokenHelper(builder.Configuration, new JwtSecurityTokenHandler()));

// ���jwt��֤��
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:ValidIssuer"],//������
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:ValidAudience"],//�����ߣ����Բ����ã�������Tokenʱ��ָ����
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:IssuerSigninKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();// ��ǰ ��Ȩ
app.UseAuthorization();// �ں�  ��Ȩ

app.MapControllers();

app.Run();
