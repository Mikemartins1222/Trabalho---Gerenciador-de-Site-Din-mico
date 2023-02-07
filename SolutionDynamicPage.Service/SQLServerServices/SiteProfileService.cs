using SolutionDynamicPage.Infra.Domain.DTO;
using SolutionDynamicPage.Infra.Domain.Entities;
using SolutionDynamicPage.Infra.Domain.IRepositories;
using SolutionDynamicPage.Infra.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Service.SQLServerServices
{
    public  class SiteProfileService : ISiteProfileService
    {
        private readonly ISiteProfileRepository _repository;

        public SiteProfileService(ISiteProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }

        public List<SiteProfileDTO> FindAll()
        {
            return _repository.FindAll()
                              .Select(site => new SiteProfileDTO()
                              {
                                  id = site.Id,
                                  profileName = site.ProfileName,
                                  businessName = site.BusinessName,
                                  description = site.Description,
                                  facebookAdress = site.FacebookAdress,
                                  instagramAdress = site.InstagramAdress,
                                  address = site.Address,
                                  email = site.Email,
                                  cellPhone = site.CellPhone,
                                  imageLogo = site.ImageLogo,
                                  imageBanner = site.ImageBanner,
                                  title = site.Title,
                                  imageDescription = site.ImageDescription,
                                  footerDescription = site.FooterDescription,
                                  isPublished = site.IsPublished

                              }).ToList();
        }

        public async Task<SiteProfileDTO> FindById(int id)
        {
            var dto = new SiteProfileDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }

        
        
        
        public async Task<int> CleanPublished()
        {

            var searchPublishedList = _repository.FindAll()
                                .Select(site => new SiteProfileDTO()
                                {
                                    id = site.Id,
                                    profileName = site.ProfileName,
                                    businessName = site.BusinessName,
                                    description = site.Description,
                                    facebookAdress = site.FacebookAdress,
                                    instagramAdress = site.InstagramAdress,
                                    address = site.Address,
                                    email = site.Email,
                                    cellPhone = site.CellPhone,
                                    imageLogo = site.ImageLogo,
                                    imageBanner = site.ImageBanner,
                                    title = site.Title,
                                    imageDescription = site.ImageDescription,
                                    footerDescription = site.FooterDescription,
                                    isPublished = site.IsPublished

                                }).ToList();


            foreach (var status in searchPublishedList)
            {
                status.isPublished = false;
                await _repository.Update(status.mapToEntity());
               
            }

            return 1;
        }
        
        public async Task<int> SetIsPublished(int id)
        {
            var profile = await _repository.FindById(id);
            profile.IsPublished = true;
            await _repository.Update(profile);

            return 1;
        }


        public async Task<SiteProfileDTO> GetPublished()
        {

            var searchPublishedList = _repository.FindAll()
                                .Select(site => new SiteProfileDTO()
                                {
                                    id = site.Id,
                                    profileName = site.ProfileName,
                                    businessName = site.BusinessName,
                                    description = site.Description,
                                    facebookAdress = site.FacebookAdress,
                                    instagramAdress = site.InstagramAdress,
                                    address = site.Address,
                                    email = site.Email,
                                    cellPhone = site.CellPhone,
                                    imageLogo = site.ImageLogo,
                                    imageBanner = site.ImageBanner,
                                    title = site.Title,
                                    imageDescription = site.ImageDescription,
                                    footerDescription = site.FooterDescription,
                                    isPublished = site.IsPublished

                                }).ToList();


            var result = searchPublishedList.Where(p => p.isPublished == true);
            SiteProfileDTO dto;
            return dto = result.FirstOrDefault();

        }


        public Task<int> Save(SiteProfileDTO dto)
        {
            if (dto.id > 0)
            {
                return _repository.Update(dto.mapToEntity());
            }
            else
            {
                return _repository.Save(dto.mapToEntity());
            }
        }



    }
}
