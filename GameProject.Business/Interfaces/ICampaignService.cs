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
        CampaignDto Add();
    }
}
