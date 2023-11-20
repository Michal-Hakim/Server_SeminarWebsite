using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class UserActions : IUserDAL
    {
        readonly SeminarWebsiteContext _DB;

        #region C-tor
        public UserActions(SeminarWebsiteContext DB)
        {
            this._DB = DB;
        }
        #endregion

        //Get
        #region GetAllUsers
        public List<UserTbl> GetAllUsers()
        {
            return _DB.UserTbls.ToList();
        }
        #endregion

        #region GetUserByUserID
        public UserTbl? GetUserByUserID(string userID)
        {
            return GetAllUsers().FirstOrDefault(x => x.UserId.Equals(userID));
        }
        #endregion

        //Post
        #region AddUser
        public List<UserTbl> AddUser(UserTbl userTbl)
        {
            _DB.UserTbls.Add(userTbl);
            _DB.SaveChanges();
            return GetAllUsers();
        }
        #endregion

        //Delete
        #region DeleteUserByUserID
        public List<UserTbl> DeleteUserByUserID(string userID)
        {
            UserTbl userTbl = GetUserByUserID(userID);
            if (userTbl != null)
            {
                _DB.UserTbls.Remove(userTbl);
                _DB.SaveChanges();
            }
            return GetAllUsers();
        }
        #endregion

        //Put
        #region UpdateUserByUserID
        public List<UserTbl> UpdateUserByUserID(string userID, UserTbl userTbl)
        {
            UserTbl existingUser = _DB.UserTbls.FirstOrDefault(x => x.UserId.Equals(userID));
            if (existingUser != null)
            {
                existingUser.UserPassword = existingUser.UserPassword;
                existingUser.UserFirstName = userTbl.UserFirstName;
                existingUser.UserLastName = userTbl.UserLastName;
                existingUser.UserHomePhoneNumber = userTbl.UserHomePhoneNumber;
                existingUser.UserCellPhoneNumber = userTbl.UserCellPhoneNumber;
                existingUser.UserHebrewDateOfBirth = userTbl.UserHebrewDateOfBirth;
                existingUser.UserEnglishDateOfBirth = userTbl.UserEnglishDateOfBirth;
                existingUser.UserAddress = userTbl.UserAddress;
                existingUser.UserLocationCity = userTbl.UserLocationCity;
                _DB.SaveChanges();
            }
            return GetAllUsers();
        }
        #endregion

    }
}
