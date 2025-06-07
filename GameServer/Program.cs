using SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Imposta il path base per quando l'app è servita su /Game000
app.UsePathBase("/Game000");

// Middleware per reindirizzare le richieste correttamente (opzionale, già gestito da UsePathBase)
app.Use((context, next) =>
{
    context.Request.PathBase = new PathString("/Game000");
    return next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();
