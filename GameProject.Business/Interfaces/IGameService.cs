using GameProject.Business.DTOs;
using GameProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.Interfaces
{
    public interface IGameService
    {
        List<Game> List();
        List<GameWithCampaignDto> ListWithCampaign();
        void PrintList(List<GameWithCampaignDto> gameDtoList);
        Game Get(int gameId);
        Game Sale(int id);
    }
}
