
using GameProject.Business.Interfaces;
using GameProject.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DayFiveHomeworkFive
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                       .AddSingleton<IMainService, MainService>()
                       .AddSingleton<ICustomerService, CustomerService>()
                       .AddSingleton<IGameService, GameService>()
                       .AddSingleton<ICampaignService, CampaignService>()
                       .BuildServiceProvider();


            var mainConsole = serviceProvider.GetService<IMainService>();
            mainConsole.RunConsole();
        }
    }
}
