using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Business.DTOs
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public int GameId { get; set; }
        public int DiscountRate { get; set; }
    }
}
