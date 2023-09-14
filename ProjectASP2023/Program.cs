using Application;
using Application.Command;
using Application.Logger;
using Application.Queries;
using Application.Uploader;
using DataAccess;
using Implementation;
using Implementation.EF.Command;
using Implementation.EF.Queries;
using Implementation.Logger;
using Implementation.Uploader;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProjectASP2023.Handler;
using ProjectASP2023.JWT;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "AspIspit",
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123ASDjfipoawopriqwop123124")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
// Add services to the container.
builder.Services.AddTransient<UseCaseHandler>();
//NeAutorizovan
builder.Services.AddTransient<IRegisterCommand, EFRegisterCommand>();

//Autorizovan
builder.Services.AddTransient<IGetPostQuery, EFGetPostQuery>();//Ne autorizovan
builder.Services.AddTransient<IGetOnePostQuery, EFGetOnePostQuery>();//Ne autorizovan
builder.Services.AddTransient<IAddPostCommand, EFAddPostCommand>();
builder.Services.AddTransient<IDeletePostCommand, EFDeletePostCommand>();
builder.Services.AddTransient<IChangePostCommand,EFPostChangeCommand>();
builder.Services.AddTransient<IAddCommentCommand, EFAddCommentCommand>();
builder.Services.AddTransient<IDeleteCommenCommand,EFDeleteCommentCommand>();
builder.Services.AddTransient<IBase64FileUploader, Base64FileUploader>();

//Admin
builder.Services.AddTransient<IAddCategoryAdmin,EFAddCategoryAdminCommand>();
builder.Services.AddTransient<IChangeCategoryAdmin,EFChangeCategoryAdminCommand>();
builder.Services.AddTransient<IDeleteCommentCommandAdmin,EFDeleteCommentCommandAdmin>();
builder.Services.AddTransient<IDeletePostAdmin, EFDeletePostCommandAdmin>();
builder.Services.AddTransient<IGetUsersAdminQuery,EFGetUsersAdminQuery>();
builder.Services.AddTransient<IDeleteUsersCommand,EFDeleteUsersCommand>();
builder.Services.AddTransient<IGetUseCaseLog,EfUseCaseLoggerQuery>();

builder.Services.AddTransient<PostValidatior>();
builder.Services.AddTransient<CommentValidator>();
builder.Services.AddTransient<RegisterValidator>();
builder.Services.AddTransient<ChangePostValidator>();
builder.Services.AddTransient<CategoryValidator>();

builder.Services.AddTransient<IUseCaseLogger, EFUseCaseLogger>();

builder.Services.AddTransient<BlogContext>(x =>
{
    DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
    builder.UseSqlServer(@"Data Source=DESKTOP-ADVVOD4\SQLEXPRESS01;Initial Catalog=ASPProject;Integrated Security=True;TrustServerCertificate=true");
    return new BlogContext(builder.Options);
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ProjectASP2023",
        Version = "v1",
        Description = "Description of your API",
    });
});
builder.Services.AddTransient<JwtManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IApplicationUser>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];

    //Pristup payload-u
    var claims = accessor.HttpContext.User;

    if (claims == null || claims.FindFirst("UserId") == null)
    {
        return new AnonymousUser();
    }

    var actor = new JwtUser
    {
        Username = claims.FindFirst("Username").Value,
        Id = Int32.Parse(claims.FindFirst("UserId").Value),
        Identity = claims.FindFirst("Username").Value,
        // "[1, 2, 3, 4, 5]"
        UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
    };

    return actor;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectASP2023");
    });
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
