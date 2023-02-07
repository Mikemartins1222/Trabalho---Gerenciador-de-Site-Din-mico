using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Domain.Entities
{
    public class SiteProfile
    {
   
     
        public int Id { get; set; }
       
        public string ProfileName { get; set; }

        public string BusinessName { get; set; }
        public string Description { get; set; }

        public string? FacebookAdress { get; set; }

        public string? InstagramAdress { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string CellPhone { get; set; }
        public string ImageLogo { get; set; }
        public string ImageBanner { get; set; }

        public string Title { get; set; }

        public string ImageDescription { get; set; }

        public string FooterDescription { get; set; }

        public bool IsPublished { get; set; }

    }
}
