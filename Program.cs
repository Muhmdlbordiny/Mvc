namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //.AddSessionStateTempDataProvider();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region Custom Middlemware "Inline Middleware"
            //app.Use(async (httpContext, next) => {
            //    await  httpContext.Response.WriteAsync("MiddleWare 1\n");
            //    await  next.Invoke();
            //    await httpContext.Response.WriteAsync("MiddleWare 1_1\n");


            //});

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("Terminate\n");
            //});
            //app.Use(async (httpContext, next) => {
            //    await httpContext.Response.WriteAsync("MiddleWare 2\n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("MiddleWare 2_2\n");

            //});
            #endregion


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}