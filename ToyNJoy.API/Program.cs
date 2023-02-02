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

// 注入数据库上下文
builder.Services.AddDbContext<ToyNjoyContext>();

// 注入自定义工具类 builder.Configuration = appsettings.json
builder.Services.AddSingleton(new TokenHelper(builder.Configuration, new JwtSecurityTokenHandler()));

// 添加jwt验证：
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:ValidIssuer"],//发布者
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:ValidAudience"],//接收者（可以不设置，在生成Token时再指定）
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

app.UseAuthentication();// 在前 鉴权
app.UseAuthorization();// 在后  授权

app.MapControllers();

app.Run();
