namespace ctd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=CaiThienDiem}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}