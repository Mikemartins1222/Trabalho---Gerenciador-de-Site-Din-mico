using SolutionDynamicPage.Infra.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Domain.IServices
{
    public interface ISiteProfileService : IBaseService<SiteProfileDTO>
    {

        public Task<int> SetIsPublished(int id);
        public Task<int> CleanPublished();
        public Task<SiteProfileDTO> GetPublished();
    }
}
