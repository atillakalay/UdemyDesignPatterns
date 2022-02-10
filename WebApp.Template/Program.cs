using BaseProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using WebApp.Template.Models;

namespace BaseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            identityDbContext.Database.Migrate();

            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser() { UserName = "User1", Email = "user1@outlook.com", PictureUrl = "/UserPictures/signIn.png", Description = "Lorem Ipsum, dizgi ve bask� end�strisinde kullan�lan m�g�r metinlerdir. Lorem Ipsum, ad� bilinmeyen bir matbaac�n�n bir hurufat numune kitab� olu�turmak �zere bir yaz� galerisini alarak kar��t�rd��� 1500'lerden beri end�stri standard� sahte metinler olarak kullan�lm��t�r." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User2", Email = "user2@outlook.com", PictureUrl = "/UserPictures/signIn.png", Description = "Lorem Ipsum, dizgi ve bask� end�strisinde kullan�lan m�g�r metinlerdir. Lorem Ipsum, ad� bilinmeyen bir matbaac�n�n bir hurufat numune kitab� olu�turmak �zere bir yaz� galerisini alarak kar��t�rd��� 1500'lerden beri end�stri standard� sahte metinler olarak kullan�lm��t�r." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User3", Email = "user3@outlook.com", PictureUrl = "/UserPictures/signIn.png", Description = "Lorem Ipsum, dizgi ve bask� end�strisinde kullan�lan m�g�r metinlerdir. Lorem Ipsum, ad� bilinmeyen bir matbaac�n�n bir hurufat numune kitab� olu�turmak �zere bir yaz� galerisini alarak kar��t�rd��� 1500'lerden beri end�stri standard� sahte metinler olarak kullan�lm��t�r." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User4", Email = "user4@outlook.com", PictureUrl = "/UserPictures/signIn.png", Description = "Lorem Ipsum, dizgi ve bask� end�strisinde kullan�lan m�g�r metinlerdir. Lorem Ipsum, ad� bilinmeyen bir matbaac�n�n bir hurufat numune kitab� olu�turmak �zere bir yaz� galerisini alarak kar��t�rd��� 1500'lerden beri end�stri standard� sahte metinler olarak kullan�lm��t�r." }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User5", Email = "user5@outlook.com", PictureUrl = "/UserPictures/signIn.png", Description = "Lorem Ipsum, dizgi ve bask� end�strisinde kullan�lan m�g�r metinlerdir. Lorem Ipsum, ad� bilinmeyen bir matbaac�n�n bir hurufat numune kitab� olu�turmak �zere bir yaz� galerisini alarak kar��t�rd��� 1500'lerden beri end�stri standard� sahte metinler olarak kullan�lm��t�r." }, "Password12*").Wait();

            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
