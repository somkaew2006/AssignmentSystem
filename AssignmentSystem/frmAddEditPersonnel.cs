using AssignmentSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentSystem
{
    public partial class frmAddEditPersonnel : Form
    {
        public frmAddEditPersonnel()
        {
            InitializeComponent();
        }

        public string Action { get; set; }
        public string Code { get; set; }

        private void frmAddEditPersonnel_Load(object sender, EventArgs e)
        {
            
            if (Action == "Edit")
            {
                Personnel personnel = new PersonnelRepo().GetPersonnel(Code);
                txtUserName.Text = personnel.P_name;
                txtUser.Text = personnel.P_user;
                txtPassword.Text = personnel.P_pass;
                txtStatus.Text = personnel.P_status;

                chkUsing.Checked = false;
                if (personnel.P_using=="Active")
                {
                    chkUsing.Checked = true;    
                }

                //txtUserName.Text = personnel.Pname;
                //txtUserID.Text = personnel.Puser;
                //txtPassword.Text = personnel.Ppass;
            }
        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("ข้อมูล ชื่อ-สกุล ห้ามเป็นค่าว่าง", "Error");
                txtUserName.Focus();
                return;
            }
            if (txtUser.Text == "")
            {
                MessageBox.Show("ข้อมูล User ห้ามเป็นค่าว่าง", "Error");
                txtUser.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("ข้อมูล Password ห้ามเป็นค่าว่าง", "Error");
                txtPassword.Focus();
                return;
            }

            if (txtStatus.Text =="")
            {
                MessageBox.Show("ข้อมูล Status ห้ามเป็นค่าว่าง", "Error");
                txtStatus.Focus();
                return;
            }
 
            


            Result result = new Result();
            if (Action == "Add")
            {
                Personnel model = new Personnel();
                model.P_name = txtUserName.Text;
                model.P_user = txtUser.Text;
                model.P_pass = txtPassword.Text;
                model.P_status = txtStatus.Text;
                model.P_using = "NonActive";

                if (chkUsing.Checked)
                {
                    model.P_using = "Active"; 
                }

                result = new PersonnelRepo().Create(model);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
            else
            {

                //edit 
                Personnel model = new Personnel();
                model.P_id = Code; 
                model.P_name = txtUserName.Text;
                model.P_user = txtUser.Text;
                model.P_pass = txtPassword.Text;
                model.P_status = txtStatus.Text;
                model.P_using = "NonActive";

                if (chkUsing.Checked)
                {
                    model.P_using = "Active";
                }

                result = new PersonnelRepo().Update(model, Code);
                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    this.Close();
                }
            }
        }
    }
}
