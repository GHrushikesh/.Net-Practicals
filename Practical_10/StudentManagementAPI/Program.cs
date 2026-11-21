using StudentManagementAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Configure Services (Dependency Injection)
// ==========================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ==========================================
// 2. Configure HTTP Request Pipeline (Middleware)
// ==========================================

// Custom Middleware 1: Centralized Exception Handling
app.UseGlobalExceptionHandler();

// Custom Middleware 2: Request & Response Logging
app.UseRequestLogging();

// Swagger Documentation Middleware (in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
