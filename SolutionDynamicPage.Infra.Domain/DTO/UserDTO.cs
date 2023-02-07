using SolutionDynamicPage.Infra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolutionDynamicPage.Infra.Domain.DTO
{
    public class UserDTO
    {


        public int id { get; set; }

        [Required(ErrorMessage = "Digite o Login")]
        public string login { get; set; }
        
        [Required(ErrorMessage = "Digite a Senha")]
        public string password { get; set; }



        public User mapToEntity()
        {
            return new User()
            {

                Id = id,
                Login = login,
                Password = password
            

            };
        }
        public UserDTO mapToDTO(User user)
        {
            return new UserDTO()
            {
                id = user.Id,
                login = user.Login,
                password = user.Password
                
            };
        }
    }
}
