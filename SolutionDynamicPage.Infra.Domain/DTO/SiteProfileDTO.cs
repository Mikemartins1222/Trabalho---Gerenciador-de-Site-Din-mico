using SolutionDynamicPage.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SolutionDynamicPage.Infra.Domain.DTO
{
    public class SiteProfileDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Preset")]
        public string profileName { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do Negócio/Empresa")]
        public string businessName { get; set; }
        
        [Required(ErrorMessage = "Digite a Descrição")]
        public string description { get; set; }

        public string? facebookAdress { get; set; }

        public string? instagramAdress { get; set; }
        
        [Required(ErrorMessage = "Digite o Endereço")]
        public string address { get; set; }
        
        [Required(ErrorMessage = "Digite o E-mail")]
        public string email { get; set; }
        public string? phone { get; set; }
        
        [Required(ErrorMessage = "Digite o Celular")]
        [Phone]
        public string cellPhone { get; set; }
        public string? imageLogo { get; set; }
        public string? imageBanner { get; set; }
        
        [Required(ErrorMessage = "Digite o Título do Texto")]
        public string title { get; set; }

        public string? imageDescription { get; set; }

        [Required(ErrorMessage = "Digite a Descrição do Rodapé")]
        public string footerDescription { get; set; }

        public bool isPublished { get; set; }


        public SiteProfile mapToEntity()
        {
            return new SiteProfile()
            {
               
                Id = id,
                ProfileName = profileName,
                BusinessName = businessName,
                Description = description,
                FacebookAdress = facebookAdress,
                InstagramAdress = instagramAdress,
                Address = address,
                Email = email,
                Phone= phone,
                CellPhone = cellPhone,
                ImageLogo = imageLogo,
                ImageBanner = imageBanner,
                Title = title,
                ImageDescription = imageDescription,
                FooterDescription = footerDescription,
                IsPublished = isPublished

            };
        }
        public SiteProfileDTO mapToDTO(SiteProfile site)
        {
            return new SiteProfileDTO()
            {
                id = site.Id,
                profileName = site.ProfileName,
                businessName = site.BusinessName,
                description = site.Description,
                facebookAdress = site.FacebookAdress,
                instagramAdress = site.InstagramAdress,
                address = site.Address,
                email = site.Email,
                phone= site.Phone,
                cellPhone = site.CellPhone,
                imageLogo = site.ImageLogo,
                imageBanner = site.ImageBanner,
                title = site.Title,
                imageDescription = site.ImageDescription,
                footerDescription = site.FooterDescription,
                isPublished = site.IsPublished
            };
        }

    }
}
