using GameProject.Business.DTOs;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Interfaces
{
    public interface ICampaignService
    {
        List<Campaign> List();
        CampaignDto Get(List<GameWithCampaignDto> campaignList, int campaignId);
        List<CampaignDto> GetByGameId(List<GameWithCampaignDto> gameList, int gameId);
        CampaignDto Add(CampaignDto campaign);
        CampaignDto Update(CampaignDto campaign, string newCampaignName, int newDiscountRate);
        CampaignDto Delete(CampaignDto campaign);

    }
}
