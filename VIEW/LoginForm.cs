
using DB_Entity;
using HLV.BLL;
using HLV.VIEW;
using HOC_VIEN;
using HOC_VIEN.BLL;
using HOC_VIEN.VIEW;
using Login_Register.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Register.VIEW
{
    public partial class LoginForm : Form
    {
        private UserGymBLL userGymBLL;
        private HocVienBLL hocVienBLL;
        private PTBLL ptBLL;
        public LoginForm()
        {
            InitializeComponent();
            userGymBLL = new UserGymBLL();
            hocVienBLL = new HocVienBLL();
            ptBLL = new PTBLL();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userID = txtusername.Text;
                string password = txtPass.Text;

                if (userGymBLL.Login(userID, password))
                {
                    string role = userGymBLL.GetUserRole(userID);
                    HOCVIEN hocVien = null;
                    PT pt = null;
                    if (role == "HV")
                    {
                        hocVien = hocVienBLL.GetHocVienByUserID(userID);
                        HVForm hocVienForm = new HVForm(hocVien);
                        hocVienForm.Show();
                    }
                    else if (role == "PT")
                    {
                        pt = ptBLL.GetPTByUserID(userID);
                        PTForm ptForm = new PTForm(pt);
                        ptForm.Show();
                    }
                    else if (role == "Admin")
                    {
                        //AdminForm adminForm = new AdminForm();
                        //adminForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
