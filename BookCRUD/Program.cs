using BookCRUD.Repositories; // Import namespace cho repository

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC cho các controller và view
builder.Services.AddControllersWithViews();

// Đăng ký BookRepository để Dependency Injection (DI)
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Nếu không ở chế độ phát triển, xử lý lỗi và sử dụng HSTS
if (!app.Environment.IsDevelopment())
{
    // Chuyển hướng tới trang lỗi nếu xảy ra ngoại lệ
    app.UseExceptionHandler("/Home/Error");
    // Sử dụng HTTP Strict Transport Security
    app.UseHsts();
}

// Chuyển hướng HTTP sang HTTPS
app.UseHttpsRedirection();

// Sử dụng các tệp tĩnh như CSS, JavaScript
app.UseStaticFiles();

// Thiết lập hệ thống routing
app.UseRouting();

// Sử dụng xác thực nếu cần (hiện tại có thể để sẵn sàng cho tương lai)
app.UseAuthorization();

// Định nghĩa route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

// Chạy ứng dụng
app.Run();
