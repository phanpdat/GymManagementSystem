
using DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.DAL
{
    public class UserGymDAL
    {
        private GYM2Entities context;

        public UserGymDAL()
        {
            context = new GYM2Entities();
        }

        public USER GetUser(string userID)
        {
            return context.USERS.FirstOrDefault(u => u.UserID == userID);
        }

        public USER GetUser(string userID, string password)
        {
            return context.USERS.FirstOrDefault(u => u.UserID == userID && u.Password == password);
        }

        public bool IsUserIDExist(string userID)
        {
            return context.USERS.Any(u => u.UserID == userID);
        }

        public void AddUser(string userID, string password, string role)
        {
            var userGym = new USER
            {
                UserID = userID,
                Password = password,
                Role = role
            };
            context.USERS.Add(userGym);
            context.SaveChanges();
        }

        public string GetUserRoleByUserID(string userID)
        {
            var user = context.USERS.FirstOrDefault(u => u.UserID == userID);
            return user?.Role;
        }

        public void UpdateUser(USER user)
        {
            var existingUser = context.USERS.FirstOrDefault(u => u.UserID == user.UserID);
            if (existingUser != null)
            {
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                context.SaveChanges();
            }
        }

        public USER GetUserByUserID(string userID)
        {
            return context.USERS.FirstOrDefault(u => u.UserID == userID);
        }

        //Đổi Pass
        public bool ChangePassword(string userID, string newPassword)
        {
            var user = context.USERS.FirstOrDefault(u => u.UserID == userID);
            if (user != null)
            {
                user.Password = newPassword;
                context.SaveChanges();
                return true; 
            }

            return false; 
        }
    }
}
