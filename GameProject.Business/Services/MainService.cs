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
            List<Campaign> campaignList = _campaignService.List();

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
                    gameList = CampaignMenuAdd(gameList);

                }
                if (getOption == 3)
                {
                    gameList = CampaignMenuUpdate(gameList);

                }
                if (getOption == 4)
                {
                    gameList = CampaignMenuDelete(gameList);

                }
                if (getOption == 5)
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

        public List<GameWithCampaignDto> CampaignMenuAdd(List<GameWithCampaignDto> gameList)
        {

            Console.WriteLine("1-Fifa");
            Console.WriteLine("2-Football Manager");
            Console.WriteLine("3-Eycof");
            Console.WriteLine("4-Sims");
            Console.WriteLine("Please enter Game Id that you want to add Campaign:");
            int gameId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Campaign Name:");
            string campaignName = Console.ReadLine();
            Console.WriteLine("Please enter Discount Rate:");
            int discountRate = Convert.ToInt32(Console.ReadLine());

            var campaign = new CampaignDto();
            campaign.GameId = gameId;
            campaign.DiscountRate = discountRate;
            campaign.CampaignName = campaignName;

            var sameGameCampaignList = _campaignService.GetByGameId(gameList, gameId);
            var lastId = 1;
            if (sameGameCampaignList.Count != 0)
            {
                lastId = sameGameCampaignList.FindLast(x => true).Id;
            }

            campaign.Id = (gameId * 10) + (lastId % 10 + 1);

            var campaignDto = _campaignService.Add(campaign);
            foreach (var item in gameList)
            {
                if (campaignDto.GameId == item.Id)
                {
                    item.campaignDtos.Add(campaignDto);
                }
            }
            return gameList;
        }

        public List<GameWithCampaignDto> CampaignMenuUpdate(List<GameWithCampaignDto> gameList)
        {
            _gameService.PrintList(gameList);
            Console.WriteLine("Enter Campaign number that you want to update:");
            int campaignId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Campaign Name:");
            string newCampaignName = Console.ReadLine();
            Console.WriteLine("Enter New Discount Rate:");
            int newDiscountRate = Convert.ToInt32(Console.ReadLine());

            var campaignToBeUpdated = _campaignService.Get(gameList, campaignId);
            var updatedCampaign = _campaignService.Update(campaignToBeUpdated, newCampaignName, newDiscountRate);
            foreach (var gameItem in gameList)
            {
                foreach (var campaignItem in gameItem.campaignDtos)
                {
                    if (campaignItem.Id == campaignId)
                    {
                        campaignItem.CampaignName = updatedCampaign.CampaignName;
                        campaignItem.DiscountRate = updatedCampaign.DiscountRate;
                    }
                }
            }
            return gameList;
        }

        public List<GameWithCampaignDto> CampaignMenuDelete(List<GameWithCampaignDto> gameList)
        {
            _gameService.PrintList(gameList);
            Console.WriteLine("Enter Campaign number that you want to delete:");
            int campaignId = Convert.ToInt32(Console.ReadLine());

            var campaignToBeDeleted = _campaignService.Get(gameList, campaignId);
            var deletedCampaign = _campaignService.Delete(campaignToBeDeleted);



            var deleteItem = new CampaignDto();

            foreach (var gameItem in gameList)
            {
                foreach (var campaignItem in gameItem.campaignDtos)
                {
                    if (campaignItem.Id == campaignId)
                    {
                        deleteItem = campaignItem;
                    }
                }
                gameItem.campaignDtos.Remove(deleteItem);
            }

            return gameList;
        }

        public int OptionMenu()
        {
            Console.WriteLine("Console Menu");
            Console.WriteLine("Press Enter 1 to Buy a game");
            Console.WriteLine("Press Enter 2 to Add Campaign");
            Console.WriteLine("Press Enter 3 to Update Campaign");
            Console.WriteLine("Press Enter 4 to Delete Campaign");
            Console.WriteLine("Press Enter 5 to Exit Console");
            int option = Convert.ToInt32(Console.ReadLine());

            return option;
        }

    }
}
