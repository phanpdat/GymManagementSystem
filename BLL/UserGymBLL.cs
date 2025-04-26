
using DB_Entity;
using Login_Register.DAL;
using System;
using System.Windows.Forms;

namespace Login_Register.BLL
{
    public class UserGymBLL
    {
        private readonly UserGymDAL _userGymDAL = new UserGymDAL();

        public USER GetUser(string userID) => _userGymDAL.GetUser(userID);

        public void AddUser(string userID, string password, string role)
        {
            if (_userGymDAL.IsUserIDExist(userID))
                throw new Exception("UserID đã tồn tại. Vui lòng chọn UserID khác.");

            _userGymDAL.AddUser(userID, password, role);
        }

        public bool Login(string userID, string password) => _userGymDAL.GetUser(userID, password) != null;

        public string GetUserRole(string userID) => _userGymDAL.GetUserRoleByUserID(userID);

        public void UpdateUser(USER user) => _userGymDAL.UpdateUser(user);

        public USER GetUserByUserID(string userID) => _userGymDAL.GetUserByUserID(userID);

        //Đổi Pass
        public bool ChangePassword(string userID, string newPassword)
        {
            
            return _userGymDAL.ChangePassword(userID, newPassword);
        }
    }
}
