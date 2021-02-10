using GameProject.Business.DTOs;
using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Services
{
    public class MainService : IMainService
    {
        private readonly ICustomerService _customerService;
        private readonly IGameService _gameService;
        private readonly ICampaignService _campaignService;

        public MainService()
        {
        }

        public MainService(ICustomerService customerService, IGameService gameService, ICampaignService campaignService)
        {
            _customerService = customerService;
            _gameService = gameService;
            _campaignService = campaignService;
        }

        public void RunConsole()
        {
            bool registerCheck = false;
            List<GameWithCampaignDto> gameList = _gameService.ListWithCampaign();

            while (true)
            {
                var getOption = OptionMenu();

                if (getOption == 1)
                {
                    while (registerCheck == false)
                    {
                        registerCheck = RegisterMenu();
                        if (registerCheck == false)
                            Console.WriteLine("Access denied - You must enter correct information");
                        else
                            Console.WriteLine("Successfully Registered");
                    }

                    GameMenu(gameList);
                }
                if (getOption == 2)
                {
                    gameList = CampaignMenu(gameList);

                }
                if (getOption == 3)
                {
                    break;
                }
            }
        }

        public bool RegisterMenu()
        {
            Console.WriteLine("You need to register first to buy a game");
            var customer = _customerService.Register();
            bool customerCheck = false;
            if (customer != null)
            {
                customerCheck = _customerService.Check(customer);

            }
            return customerCheck;
        }


        public List<GameWithCampaignDto> GameMenu(List<GameWithCampaignDto> gameList)
        {
            _gameService.PrintList(gameList);
            Console.WriteLine("Enter Game number that you want to buy:");
            int option = Convert.ToInt32(Console.ReadLine());
            _gameService.Sale(option);

            return gameList;

        }

        public List<GameWithCampaignDto> CampaignMenu(List<GameWithCampaignDto> gameList)
        {
            var campaignDto = _campaignService.Add();
            foreach (var item in gameList)
            {
                if (campaignDto.GameId == item.Id)
                {
                    item.campaignDtos.Add(campaignDto);
                }
            }
            return gameList;
        }

        public int OptionMenu()
        {
            Console.WriteLine("Console Menu");
            Console.WriteLine("Press Enter 1 to Buy a game");
            Console.WriteLine("Press Enter 2 to Add Campaign");
            Console.WriteLine("Press Enter 3 to Exit Console");
            int option = Convert.ToInt32(Console.ReadLine());

            return option;
        }

    }
}
