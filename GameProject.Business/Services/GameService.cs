using GameProject.Business.DTOs;
using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject.Business.Services
{
    public class GameService:IGameService
    {
        private readonly ICampaignService _campaignService;
        public GameService(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public List<Game> List()
        {
            var gameList = new List<Game>();

            Game gameOne = new Game();
            gameOne.Id = 1;
            gameOne.GameName = "Fifa";
            gameList.Add(gameOne);
            Game gameTwo = new Game();
            gameTwo.Id = 2;
            gameTwo.GameName = "Football Manager";
            gameList.Add(gameTwo);
            Game gameThree = new Game();
            gameThree.Id = 3;
            gameThree.GameName = "Eycof";
            gameList.Add(gameThree);
            Game gameFour = new Game();
            gameFour.Id = 4;
            gameFour.GameName = "Sims";
            gameList.Add(gameFour);

            return gameList;
        }

        public List<GameWithCampaignDto> ListWithCampaign()
        {
            var gameList = List();
            var campaignList = _campaignService.List();

            var gameDtoList = new List<GameWithCampaignDto>();

            foreach (var gameItem in gameList)
            {
                var gameDto = new GameWithCampaignDto();
                gameDto.GameName = gameItem.GameName;
                gameDto.Id = gameItem.Id;
                gameDto.campaignDtos = new List<CampaignDto>();
              
                foreach (var campaignItem in campaignList)
                {
                    if(gameItem.Id==campaignItem.GameId)
                    {
                        var campaignDto = new CampaignDto();
                        campaignDto.Id = campaignItem.Id;
                        campaignDto.GameId = campaignDto.GameId;
                        campaignDto.DiscountRate = campaignItem.DiscountRate;
                        campaignDto.CampaignName = campaignItem.CampaignName;

                        gameDto.campaignDtos.Add(campaignDto);
                    }
                }
                gameDtoList.Add(gameDto);
            }

            return gameDtoList;
        }

        public void PrintList(List<GameWithCampaignDto> gameDtoList)
        {
            Console.WriteLine("GameList");
            foreach (var item in gameDtoList)
            {
                Console.WriteLine(item.Id + "-" + item.GameName);
                if (item.campaignDtos != null)
                {
                    foreach (var campaignItem in item.campaignDtos)
                    {
                        Console.WriteLine(campaignItem.CampaignName + "-" + campaignItem.DiscountRate + "% discount");
                    }
                }
            }
        }

        public Game Get(int gameId)
        {
            var gameList = List();
            var game = gameList.First(i => i.Id == gameId);

            return game;
        }

        public Game Sale(int id)
        {
            var saledGame = Get(id);
            Console.WriteLine(saledGame.GameName + "was successfully purchased");

            return saledGame;
        }
    }
}
