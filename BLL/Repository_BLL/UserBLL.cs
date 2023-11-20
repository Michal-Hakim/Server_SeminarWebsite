using AutoMapper;
using Azure.Core;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DTO.Repository_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository_BLL
{
    public class UserBLL : IUserBLL
    {
        static readonly IMapper _Mapper;

        #region C-tor static
        static UserBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.AutoMapper>();
            });
            _Mapper = config.CreateMapper();
        }
        #endregion

        readonly IUserDAL _userDAL;
        readonly IStudentsBLL _studentBLL;

        #region C-tor public
        public UserBLL(IUserDAL userDAL, IStudentsBLL studentBLL)
        {
            _userDAL = userDAL;
            _studentBLL = studentBLL;
        }
        #endregion
        
        //Get
        #region GetAllUsers
        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> userDTO = new List<UserDTO>();
            List<UserTbl> userTblToUserDTO = _userDAL.GetAllUsers();

            foreach (UserTbl item in userTblToUserDTO)
                userDTO.Add(_Mapper.Map<UserTbl, UserDTO>(item));
            return userDTO;
        }
        #endregion

        #region GetUserByUserID
        public UserDTO? GetUserByUserID(string userID)
        {
            return _Mapper.Map<UserTbl, UserDTO>(_userDAL.GetUserByUserID(userID));
        }
        #endregion

        #region GetUsersByUserIDAndMajorCode
        public List<UserDTO> GetUsersByUserIDAndMajorCode(short majorCode)
        {
            List<StudentsDTO> students = _studentBLL.GetAllStudentsByStudentMajorCode(majorCode);
            List<UserDTO> users = new List<UserDTO>();
            foreach (StudentsDTO item in students)
            {
                UserDTO u = GetUserByUserID(item.StudentId)!;
                users.Add(u);
            }
            return users;
        }
        #endregion

        //Post
        #region AddUser
        public List<UserDTO> AddUser(UserDTO userDTO)
        {
            _userDAL.AddUser(_Mapper.Map<UserDTO, UserTbl>(userDTO));
            return GetAllUsers();
        }
        #endregion

        //Put
        #region UpdateUserByUserID
        public List<UserDTO> UpdateUserByUserID(string userID, UserDTO userDTO)
        {
            _userDAL.UpdateUserByUserID(userID, _Mapper.Map<UserDTO, UserTbl>(userDTO));
            return GetAllUsers();
        }
        #endregion

        //Delete

    }
}
