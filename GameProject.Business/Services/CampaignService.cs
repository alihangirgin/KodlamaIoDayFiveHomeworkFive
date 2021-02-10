using GameProject.Business.DTOs;
using GameProject.Business.Interfaces;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Services
{
    public class CampaignService:ICampaignService
    {
        public List<Campaign> List()
        {
            var campaignList = new List<Campaign>();

            Campaign campaignOne = new Campaign();
            campaignOne.Id = 1;
            campaignOne.GameId = 1;
            campaignOne.DiscountRate = 20;
            campaignOne.CampaignName = "WinterSale";
            campaignList.Add(campaignOne);

            Campaign campaignTwo = new Campaign();
            campaignTwo.Id = 1;
            campaignTwo.GameId = 1;
            campaignTwo.DiscountRate = 10;
            campaignTwo.CampaignName = "Hallowen Sale";
            campaignList.Add(campaignTwo);

            return campaignList;
        }

        public CampaignDto Add()
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

            var campaignDto = new CampaignDto();
            campaignDto.CampaignName = campaignName;
            campaignDto.DiscountRate = discountRate;
            campaignDto.GameId = gameId;

            Console.WriteLine(campaignName + " was successfully added");

            return campaignDto;
        }
    }
}
