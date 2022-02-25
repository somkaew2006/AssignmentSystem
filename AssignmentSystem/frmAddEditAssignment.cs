using AssignmentSystem.Model;
using AssignmentSystem.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentSystem
{
    public partial class frmAddEditAssignment : Form
    {
        public frmAddEditAssignment()
        {
            InitializeComponent();
        }
        public string Action { get; set; }
        public string Code { get; set; }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddEditAssignment_Load(object sender, EventArgs e)
        {
            if (GlobalVar.UserStatus == "User")
            {
                cmbA_sender.Enabled = false;
                cmbA_assign.Enabled = false;
                cmbA_status.Enabled = false;
            }

            LoadData();

            if (Action == "Edit")
            {
                // get data for edit
                Assignment assignment = new AssignmentRepo().GetAssignmentByID(Code);

                txtA_id.Text = assignment.A_id;
                dtpA_date.Value = DateTime.ParseExact(assignment.A_date, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                dtpA_time.Value = Convert.ToDateTime(assignment.A_time);
                txtA_name.Text = assignment.A_name;
                txtA_code.Text = assignment.A_code;
                txtA_link.Text = assignment.A_link;
                txtA_brand.Text = assignment.A_Brand;
                if (assignment.C1 == "True")
                {
                    chkC1.Checked = true;
                    btnOpenA_link.BackColor = Color.LightGreen;
                }

                cmbA_sender.Text = assignment.A_sander;
                cmbA_assign.Text = assignment.A_assign;
                dtpA_target.Value = DateTime.ParseExact(assignment.A_target, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                cmbA_status.Text = assignment.A_status;
                txtA_detail.Text = assignment.A_detail;
                
                cmbU_status.Text = assignment.U_status;
                txtU_remark.Text = assignment.U_remark;

                //v1
                dtpU_date1.Value = DateTime.ParseExact(assignment.U_date1, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtU_detail1.Text = assignment.U_detail1;
                txtU_link1.Text = assignment.U_link1;
                if (assignment.C2 == "True")
                {
                    chkC2.Checked = true;
                    btnOpenU_link1.BackColor = Color.LightGreen;
                }
                if (assignment.Rec1 == "True")
                {
                    chkRecomment1.Checked = true;
                }

                //v2
                dtpU_date2.Value = DateTime.ParseExact(assignment.U_date2, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtU_detail2.Text = assignment.U_detail2;
                txtU_link2.Text = assignment.U_link2;
                if (assignment.C3 == "True")
                {
                    chkC3.Checked = true;
                    btnOpenU_link2.BackColor = Color.LightGreen;
                }
                if (assignment.Rec2 == "True")
                {
                    chkRecomment2.Checked = true;
                }

                //v3
                dtpU_date3.Value = DateTime.ParseExact(assignment.U_date3, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtU_detail3.Text = assignment.U_detail3;
                txtU_link3.Text = assignment.U_link3;
                if (assignment.C4 == "True")
                {
                    chkC4.Checked = true;
                    btnOpenU_link3.BackColor = Color.LightGreen;
                }
                if (assignment.Rec3 == "True")
                {
                    chkRecomment3.Checked = true;
                }
            }
        }

        private void LoadData()
        {
           
            cmbA_sender.DataSource = new PersonnelRepo().GetPersonnels();
            cmbA_sender.DisplayMember = "P_name";
            cmbA_sender.ValueMember = "P_name";
            cmbA_sender.SelectedValue = GlobalVar.UserName;

            cmbA_assign.DataSource = new PersonnelRepo().GetPersonnels();
            cmbA_assign.DisplayMember = "P_name";
            cmbA_assign.ValueMember = "P_name";

            cmbA_status.Items.Add("Open");
            cmbA_status.Items.Add("Closed");
            cmbA_status.SelectedIndex = 0;

            cmbU_status.Items.Add("Wait");
            cmbU_status.Items.Add("Complete");
            cmbU_status.SelectedIndex = 0;

        }

        private void btnOpenAdminDoc_Click(object sender, EventArgs e)
        {
            string pathFile = txtA_link.Text;
            if (pathFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                return;
            }


            try
            {

                Cursor.Current = Cursors.WaitCursor;

                System.Diagnostics.Process process = new System.Diagnostics.Process();




                // string[] f = pathFile.Split('\\');
                //string fileName = f[(f.Length - 1)];
                // string folder = f[(f.Length - 1)];
                //  string dest = GlobalVar.PathFolder + txtA_id.Text  + "\\" + folder;

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.FileName = pathFile;

                //process.StartInfo.Arguments = @" ";

                process.Start();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void chkC1_CheckedChanged(object sender, EventArgs e)
        {
            string docFile = txtA_link.Text;
            if (chkC1.Checked && docFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                chkC1.Checked = false;
                return;
            }
        }

        private void btnOpenU_link1_Click(object sender, EventArgs e)
        {
            string pathFile = txtU_link1.Text;
            if (pathFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                return;
            }



            try
            {

                Cursor.Current = Cursors.WaitCursor;

                System.Diagnostics.Process process = new System.Diagnostics.Process();




                //  string[] f = pathFile.Split('\\');
                //string fileName = f[(f.Length - 1)];
                // string folder = f[(f.Length - 1)];
                //  string dest = GlobalVar.PathFolder + txtA_id.Text + "\\" + folder;

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.FileName = pathFile;

                //process.StartInfo.Arguments = @" ";

                process.Start();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chk_C2_CheckedChanged(object sender, EventArgs e)
        {
            string docFile = txtU_link1.Text;
            if (chkC2.Checked && docFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                chkC2.Checked = false;
                return;
            }
        }

        private void btnOpenU_link2_Click(object sender, EventArgs e)
        {
            string pathFile = txtU_link2.Text;
            if (pathFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                return;
            }

            try
            {

                Cursor.Current = Cursors.WaitCursor;

                System.Diagnostics.Process process = new System.Diagnostics.Process();




                //  string[] f = pathFile.Split('\\');
                //string fileName = f[(f.Length - 1)];
                // string folder = f[(f.Length - 1)];
                //  string dest = GlobalVar.PathFolder + txtA_id.Text + "\\" + folder;

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.FileName = pathFile;

                //process.StartInfo.Arguments = @" ";

                process.Start();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chkC3_CheckedChanged(object sender, EventArgs e)
        {
            string docFile = txtU_link2.Text;
            if (chkC3.Checked && docFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                chkC3.Checked = false;
                return;
            }
        }

        private void btnOpenU_link3_Click(object sender, EventArgs e)
        {
            string pathFile = txtU_link3.Text;
            if (pathFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                return;
            }

            try
            {

                Cursor.Current = Cursors.WaitCursor;

                System.Diagnostics.Process process = new System.Diagnostics.Process();




                //  string[] f = pathFile.Split('\\');
                //string fileName = f[(f.Length - 1)];
                // string folder = f[(f.Length - 1)];
                //  string dest = GlobalVar.PathFolder + txtA_id.Text + "\\" + folder;

                process.StartInfo.UseShellExecute = true;

                process.StartInfo.FileName = pathFile;

                //process.StartInfo.Arguments = @" ";

                process.Start();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void chkC4_CheckedChanged(object sender, EventArgs e)
        {
            string docFile = txtU_link3.Text;
            if (chkC4.Checked && docFile == "")
            {
                MessageBox.Show("คุณต้องทำการบันทึกข้อมูลก่อน!");
                chkC4.Checked = false;
                return;
            }


        }

        private void pcbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtA_name.SelectAll();
            txtA_name.Focus();

            //if (txtA_name.Text == "")
            //{
            //    MessageBox.Show("ข้อมูลชื่องานห้ามเป็นค่าว่าง", "Error");
            //    txtA_name.Focus();
            //    return;
            //}

            //if (txtA_code.Text == "")
            //{
            //    MessageBox.Show("ข้อมูล Code ห้ามเป็นค่าว่าง", "Error");
            //    txtA_code.Focus();
            //    return;
            //}

            Assignment assignment = new Assignment();
            assignment.A_date = dtpA_date.Value.ToString("dd/MM/yyyy");
            assignment.A_time = dtpA_time.Value.ToString("hh:mm");
            assignment.A_name = txtA_name.Text;
            assignment.A_name_detail = txtA_name.Text;
            assignment.A_Brand = txtA_brand.Text;
            assignment.A_code = txtA_code.Text;
            assignment.A_link = txtA_link.Text;
            assignment.C1 = "False";
            if (chkC1.Checked)
            {
                assignment.C1 = "True";
            }
            assignment.A_sander = cmbA_sender.Text;
            assignment.A_assign = cmbA_assign.Text;
            assignment.A_target = dtpA_target.Value.ToString("dd/MM/yyyy");
            assignment.A_status = cmbA_status.Text;
            assignment.A_detail = txtA_detail.Text;
            //assignment.A_detail=ls
            //user 
            assignment.U_status = cmbU_status.Text;
            assignment.U_remark = txtU_remark.Text;

            //sub1
            assignment.U_date1 = dtpU_date1.Value.ToString("dd/MM/yyyy");
            assignment.U_detail1 = txtU_detail1.Text;
            assignment.U_link1 = txtU_link1.Text;
            assignment.C2 = "False";
            assignment.Rec1 = "False";
            if (chkC2.Checked)
            {
                assignment.C2 = "True";
            }
            if (chkRecomment1.Checked)
            {
                assignment.Rec1 = "True";
            }

            //sub2
            assignment.U_date2 = dtpU_date2.Value.ToString("dd/MM/yyyy");
            assignment.U_detail2 = txtU_detail2.Text;
            assignment.U_link2 = txtU_link2.Text;
            assignment.C3 = "False";
            assignment.Rec2 = "False";
            if (chkC3.Checked)
            {
                assignment.C3 = "True";
            }
            if (chkRecomment2.Checked)
            {
                assignment.Rec2 = "True";
            }

            //sub3
            assignment.U_date3 = dtpU_date3.Value.ToString("dd/MM/yyyy");
            assignment.U_detail3 = txtU_detail3.Text;
            assignment.U_link3 = txtU_link3.Text;
            assignment.C4 = "False";
            assignment.Rec3 = "False";
            if (chkC4.Checked)
            {
                assignment.C4 = "True";
            }
            if (chkRecomment3.Checked)
            {
                assignment.Rec3 = "True";
            }

            Result result = new Result();
            if (Action == "Add" && txtA_id.Text =="")
            {
                result = new AssignmentRepo().Create(assignment);

                if (result.Flag)
                {
                    // สร้าง folder สำหรับวาง file 
                    CreateFolder(result.Code);
                    CreateFolderA(result.Code);
                    CreateFolderV1(result.Code);
                    CreateFolderV2(result.Code);
                    CreateFolderV3(result.Code);

                    assignment = new Assignment();
                    assignment.A_id = result.Code;
                    assignment.A_link = txtA_link.Text;
                    assignment.U_link1 = txtU_link1.Text;
                    assignment.U_link2 = txtU_link2.Text;
                    assignment.U_link3 = txtU_link3.Text;


                    result = new AssignmentRepo().UpdatePathFolder(assignment, result.Code);

                    if (result.Flag)
                    {
                        txtA_id.Text = result.Code;
                        Code = result.Code;
                        MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                    }
                    else
                    {
                        MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล ขั้นตอน Update path folder" + result.Message, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล" + result.Message, "Error");
                }
            }
            else
            {
                //edit
                assignment.A_id = txtA_id.Text;

                result = new AssignmentRepo().Update(assignment, Code);

                if (result.Flag)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "information");
                }
                else
                {
                    MessageBox.Show("เกิดปัญหาในการบันทึกข้อมูล " + result.Message);
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void CreateFolder(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo;
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);

            }
            catch (Exception)
            {

                throw;
            }


        }
        private void CreateFolderA(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo + "\\" + "Data";
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);

            }
            catch (Exception)
            {

                throw;
            }
            txtA_link.Text = dest;
        }
        private void CreateFolderV1(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo + "\\" + "Supplier 1";
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);

            }
            catch (Exception)
            {

                throw;
            }
            txtU_link1.Text = dest;
        }
        private void CreateFolderV2(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo + "\\" + "Supplier 2";
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);

            }
            catch (Exception)
            {

                throw;
            }
            txtU_link2.Text = dest;
        }
        private void CreateFolderV3(string JobNo)
        {
            //create folder 
            string dest = GlobalVar.PathFolder + JobNo + "\\" + "Supplier 3";
            try
            {
                if (Directory.Exists(dest))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(dest);

            }
            catch (Exception)
            {

                throw;
            }
            txtU_link3.Text = dest;
        }
    }
}
