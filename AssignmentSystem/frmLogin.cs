using AssignmentSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.Text = "";
            txtPassword.Text = "";

            //get cookie
            if (ConfigurationSettings.AppSettings["UserName"] != null)
            {
                txtUserName.Text = ConfigurationSettings.AppSettings["UserName"].ToString();
            }
            if (ConfigurationSettings.AppSettings["Password"] != null)
            {
                txtPassword.Text = ConfigurationSettings.AppSettings["Password"].ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Login();
             
        }

        private void Login()
        {
            Cursor.Current = Cursors.WaitCursor;

            ////exprie 
            //if (DateTime.Now.Month==11)
            //{
            //    MessageBox.Show("โปรแกรมหมดอายุ", "Information");
            //    return;
            //}


            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือ รหัสผ่านต้องไม่เป็นค่าว่าง", "Information");
                txtUserName.Focus();
                return;
            }




            //check username password 
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            Personnel user = new PersonnelRepo().Login(userName, password);

            if (user is null)
            {
                MessageBox.Show("ชื่อผู้ใช้ หรือ รหัสผ่านต้องไม่ถูกต้อง", "Information");
                txtUserName.Focus();
                return;
            }

            //exprice 
            //if (DateTime.Now.Month>=5)
            //{
            //    MessageBox.Show("Expirce");
            //    return;
            //}

            GlobalVar.UserID = user.P_id;
            GlobalVar.UserName = user.P_name;
            GlobalVar.PUser = txtUserName.Text;
            GlobalVar.UserStatus = user.P_status;

            GlobalVar.PathFolder = ConfigurationSettings.AppSettings["PathFolder"].ToString();
            GlobalVar.PathReport = ConfigurationSettings.AppSettings["PathReport"].ToString();
            GlobalVar.ServerName = ConfigurationSettings.AppSettings["ServerName"].ToString();
            GlobalVar.Database = ConfigurationSettings.AppSettings["Database"].ToString();
            GlobalVar.SqlUserID = ConfigurationSettings.AppSettings["SqlUserID"].ToString();
            GlobalVar.SqlPassword = ConfigurationSettings.AppSettings["SqlPassword"].ToString();

            UpdateSetting("UserName", txtUserName.Text);
            UpdateSetting("Password", txtPassword.Text);


            frmMain fMain = new frmMain();
            fMain.Show();
            this.Hide();
            Cursor.Current = Cursors.Default;
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              Login();
            }
        }
    }
}
