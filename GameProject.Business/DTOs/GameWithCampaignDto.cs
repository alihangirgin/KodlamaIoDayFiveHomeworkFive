using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.DTOs
{
    public class GameWithCampaignDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public List<CampaignDto> campaignDtos { get; set; }
    }
}
