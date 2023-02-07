using SolutionDynamicPage.Infra.Domain.DTO;
using SolutionDynamicPage.Infra.Domain.IRepositories;
using SolutionDynamicPage.Infra.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Service.SQLServerServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<UserDTO> FindAll()
        {
            return _repository.FindAll()
                              .Select(user => new UserDTO()
                              {
                                  id = user.Id,
                                  login = user.Login,
                                  password = user.Password
                       

                              }).ToList();
        }

        public async Task<UserDTO> FindById(int id)
        {
            var dto = new UserDTO();
            return dto.mapToDTO(await _repository.FindById(id));
        }


        public Task<int> Save(UserDTO dto)
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


        public async Task<int> Delete(int id)
        {
            var entity = await _repository.FindById(id);
            return await _repository.Delete(entity);
        }
    }
}