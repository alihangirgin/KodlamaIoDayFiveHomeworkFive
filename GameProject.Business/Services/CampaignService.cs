using GameProject.Business.DTOs;
using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject.Business.Services
{
    public class CampaignService : ICampaignService
    {
        public List<Campaign> List()
        {
            var campaignList = new List<Campaign>();

            Campaign campaignOne = new Campaign();
            campaignOne.Id = 10;
            campaignOne.GameId = 1;
            campaignOne.DiscountRate = 20;
            campaignOne.CampaignName = "WinterSale";
            campaignList.Add(campaignOne);

            Campaign campaignTwo = new Campaign();
            campaignTwo.Id = 11;
            campaignTwo.GameId = 1;
            campaignTwo.DiscountRate = 10;
            campaignTwo.CampaignName = "Hallowen Sale";
            campaignList.Add(campaignTwo);

            return campaignList;
        }

        public void PrintList(List<Campaign> campaignList)
        {
            Console.WriteLine("GameList");
            foreach (var item in campaignList)
            {
                Console.WriteLine(item.CampaignName);
            }
        }


        public CampaignDto Get(List<GameWithCampaignDto> campaignList, int campaignId)
        {
            var campaign = new CampaignDto();

            foreach (var gameItem in campaignList)
            {
                foreach (var campaignItem in gameItem.campaignDtos)
                {
                    if (campaignItem.Id == campaignId)
                    {
                        campaign.Id = campaignItem.Id;
                        campaign.DiscountRate = campaignItem.DiscountRate;
                        campaign.CampaignName = campaignItem.CampaignName;
                        campaign.GameId = campaignItem.GameId;
                    }

                }
            }
            return campaign;
        }

        public List<CampaignDto> GetByGameId(List<GameWithCampaignDto> gameList, int gameId)
        {
            var resultCampaignList = new List<CampaignDto>();

            foreach (var gameItem in gameList)
            {

                if (gameItem.Id == gameId)
                {
                    foreach (var campaignItem in gameItem.campaignDtos)
                    {
                        var campaign = new CampaignDto();
                        campaign.CampaignName = campaignItem.CampaignName;
                        campaign.DiscountRate = campaignItem.DiscountRate;
                        campaign.Id = campaignItem.Id;
                        campaign.GameId = campaignItem.GameId;
                        resultCampaignList.Add(campaign);
                    }
                }

            }
            return resultCampaignList;
        }

        public CampaignDto Add(CampaignDto campaign)
        {

            Console.WriteLine(campaign.CampaignName + " was successfully added");

            return campaign;
        }


        public CampaignDto Update(CampaignDto campaign, string newCampaignName, int newDiscountRate)
        {
            campaign.CampaignName = newCampaignName;
            campaign.DiscountRate = newDiscountRate;
            Console.WriteLine(campaign.CampaignName + " was successfully updated");

            return campaign;
        }

        //we have give to gameList as a parameter due to we haven't got any databese.
        public CampaignDto Delete(CampaignDto campaign)
        {

            Console.WriteLine(campaign.CampaignName + " was successfully deleted");

            return campaign;
        }

    }
}
