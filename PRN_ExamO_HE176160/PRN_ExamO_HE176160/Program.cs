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

            app.MapGet("/login", () =>
            {
                // Return the appropriate response for the /login route
                return "Please log in to continue.";
            });

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Dashboard}/{action=Index}"
            //    );

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