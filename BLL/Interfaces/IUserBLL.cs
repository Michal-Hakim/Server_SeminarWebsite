using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBLL
    {
        //Get
        public List<UserDTO> GetAllUsers();
        public UserDTO? GetUserByUserID(string userID);
        public List<UserDTO> GetUsersByUserIDAndMajorCode(short majorCode);
        
        //Put
        public List<UserDTO> UpdateUserByUserID(string userID, UserDTO userDTO);

        //Post
        public List<UserDTO> AddUser(UserDTO userDTO);

        //Delete
        //public List<UserDTO> DeleteUserByUserID(string userID);
    }
}
