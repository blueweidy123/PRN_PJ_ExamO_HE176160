namespace PRN_ExamO_HE176160
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // enable attribute routing
            app.MapControllers();

            app.MapControllerRoute(
                name: "login",
                pattern: "/login",
                defaults: new { controller = "Dashboard", action = "Login" }
            );

            app.MapControllerRoute(
                name: "test",
                pattern: "/test",
                defaults: new { controller = "Dashboard", action = "test" }
            );

            app.MapControllerRoute(
                name: "home",
                pattern: "/home",
                defaults: new { controller = "Dashboard", action = "Index" }
            );

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/home");
                return Task.CompletedTask;

            });

            app.MapControllerRoute(
                name: "exam",
                pattern: "/exam/{ExamId}",
                defaults: new { controller = "Exam", action = "TakeExam" }
            );

            app.Run();
        }
    }
}