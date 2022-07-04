using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using E_Library.Model;
using E_Library.BUS.BUS;
using E_Library.BUS.IBUS;
using E_Library.Repository.IRepository;
using E_Library.Repository.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



//BoMon
builder.Services.AddTransient<IBoMon, BoMonRepository>();
builder.Services.AddTransient<IBoMonBUS, BoMonBUS>();
//ChuDe
builder.Services.AddTransient<IChuDe, ChuDeRepository>();
builder.Services.AddTransient<IChuDeBUS, ChuDeBUS>();
//TroGiup
builder.Services.AddTransient<ITroGiup, TroGiupRepository>();
builder.Services.AddTransient<ITroGiupBUS, TroGiupBUS>();
//TepRieng
builder.Services.AddTransient<ITepRieng, TepRiengRepository>();
builder.Services.AddTransient<ITepRiengBUS, TepRiengBUS>();
//ThongBao
builder.Services.AddTransient<IThongBao, ThongBaoRepository>();
builder.Services.AddTransient<IThongBaoBUS, ThongBaoBUS>();

//ThongBao
builder.Services.AddTransient<IThongBao, ThongBaoRepository>();
builder.Services.AddTransient<IThongBaoBUS, ThongBaoBUS>();
//DeThi
builder.Services.AddTransient<IDeThi, DeThiRepository>();
builder.Services.AddTransient<IDeThiBUS, DeThiBUS>();
//TaiKhoan

builder.Services.AddTransient<ITaiKhoan, TaiKhoanRepository>();
builder.Services.AddTransient<ITaiKhoanBUS, TaiKhoanBUS>();
//VaiTro
builder.Services.AddTransient<IVaiTro, VaiTroRepository>();
builder.Services.AddTransient<IVaiTroBUS, VaiTroBUS>();
//PhanQuyen
builder.Services.AddTransient<IPhanQuyen, PhanQuyenRepository>();
builder.Services.AddTransient<IPhanQuyenBUS, PhanQuyenBUS>();
//MonHoc
builder.Services.AddTransient<IMonHoc, MonHocRepository>();
builder.Services.AddTransient<IMonHocBUS, MonHocBUS>();
//LopHoc
builder.Services.AddTransient<ILopHoc, LopHocRepository>();
builder.Services.AddTransient<ILopHocBUS, LopHocBUS>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:8080",
                                "https://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<E_LibraryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ELibraryDbContext")));
builder.Services.AddIdentity<TaiKhoan, IdentityRole>()
                .AddEntityFrameworkStores<E_LibraryDbContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.Zero;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
