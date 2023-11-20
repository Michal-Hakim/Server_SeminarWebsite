

using BLL.Interfaces;
using BLL.Repository_BLL;
using DAL.Actions;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add a temp to get to the items in appsettings.json
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddPolicy("AllowAll", options =>
{
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
}));

//Add Manager Dependencies
builder.Services.AddDbContext<SeminarWebsiteContext>(x => x.UseSqlServer(configuration["SeminarWebsite"]));

//Add Layers
builder.Services.AddScoped <IAttendencePerCourseDAL, AttendencePerCourseActions > ();
builder.Services.AddScoped <ICoursesDAL, CoursesActions > ();
builder.Services.AddScoped <IExistedLessonsDAL, ExistedLessonsActions > ();
builder.Services.AddScoped <IMajorDAL, MajorActions > ();
builder.Services.AddScoped <IMajorCoursesDAL, MajorCoursesActions > ();
builder.Services.AddScoped <IMarkPerCourseDAL, MarkPerCourseActions > ();
builder.Services.AddScoped <ISeminarDAL, SeminarActions > ();
builder.Services.AddScoped <IStaffDAL, StaffActions > ();
builder.Services.AddScoped <IStudentsDAL, StudentsActions > ();
builder.Services.AddScoped <IUserDAL, UserActions > ();
builder.Services.AddScoped <IAttendencePerCourseBLL, AttendencePerCourseBLL > ();
builder.Services.AddScoped <ICoursesBLL, CoursesBLL > ();
builder.Services.AddScoped <IExistedLessonsBLL, ExistedLessonsBLL > ();
builder.Services.AddScoped <IMajorBLL, MajorBLL > ();
builder.Services.AddScoped <IMajorCoursesBLL, MajorCoursesBLL > ();
builder.Services.AddScoped <IMarkPerCourseBLL, MarkPerCourseBLL > ();
builder.Services.AddScoped <ISeminarBLL, SeminarBLL > ();
builder.Services.AddScoped <IStaffBLL, StaffBLL > ();
builder.Services.AddScoped <IStudentsBLL, StudentsBLL > ();
builder.Services.AddScoped <IUserBLL, UserBLL > ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
