namespace PRN_ExamO_HE176160
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            app.UseSession();

            // enable attribute routing
            app.MapControllers();


            app.MapControllerRoute(
                name: "login",
                pattern: "/login",
                defaults: new { controller = "Dashboard", action = "Login" }
            );

            app.MapControllerRoute(
                name: "logout",
                pattern: "/logout",
                defaults: new { controller = "Dashboard", action = "Logout" }
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

            app.MapControllerRoute(
                name: "admin",
                pattern: "/admin",
                defaults: new { controller = "Dashboard", action = "Admin" }
            );

            app.MapControllerRoute(
                name: "accept",
                pattern: "/accept/{requestId}",
                defaults: new { controller = "Dashboard", action = "Accept" }
            );

            app.MapControllerRoute(
                name: "reject",
                pattern: "/reject/{requestId}",
                defaults: new { controller = "Dashboard", action = "Reject" }
            );

            app.MapControllerRoute(
                name: "request",
                pattern: "/admin/request",
                defaults: new { controller = "Dashboard", action = "Request" }
            );


            app.MapControllerRoute(
                name: "submitExam",
                pattern: "/exam/submit",
                defaults: new { controller = "Exam", action = "SubmitExam" }
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

            app.MapControllerRoute(
                name: "showResult",
                pattern: "/exam/result/{ExamId}",
                defaults: new { controller = "Result", action = "ShowResult" }
            );

            app.MapControllerRoute(
                name: "exam",
                pattern: "/postExam/{ExamId}",
                defaults: new { controller = "Exam", action = "PostSubmit" }
            );

            app.MapControllerRoute(
                name: "statistic",
                pattern: "/statistic/{range?}",
                defaults: new { controller = "Statistic", action = "MarkStatistic" }
            );

            app.MapControllerRoute(
                name: "markRange",
                pattern: "/markrange/{range}",
                defaults: new { controller = "Statistic", action = "MarkRange" }
            );



            app.Run();
        }
    }
}