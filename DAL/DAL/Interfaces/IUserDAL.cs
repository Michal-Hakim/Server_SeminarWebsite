using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        //Get
        public List<UserTbl> GetAllUsers();
        public UserTbl? GetUserByUserID(string userID);

        //Put
        public List<UserTbl> UpdateUserByUserID(string userID, UserTbl userTbl);
        //public List<UserTbl> UpdateUserByUserID(string userID);

        //Post
        public List<UserTbl> AddUser(UserTbl userTbl);

        //Delete
        public List<UserTbl> DeleteUserByUserID(string userID);
    }
}
