using AssignmentSystem.Model;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void lblExport_Click(object sender, EventArgs e)
        {

        }


        private void pcbNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmAddEditAssignment fAddEditAssignment = new frmAddEditAssignment();
            fAddEditAssignment.Action = "Add";
            fAddEditAssignment.Show();

            Cursor.Current = Cursors.Default;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuPersonal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmPersonal fPersonal = new frmPersonal();
            fPersonal.ShowDialog(this);

            Cursor.Current = Cursors.Default;
        }

        private string code;
        private void frmMain_Load(object sender, EventArgs e)
        {
            code = "";
            dgvList.AutoGenerateColumns = false;


            if (GlobalVar.UserStatus == "User")
            {
                grdSummary.Visible = false;
                pcbExport.Visible = false;
                lblExport.Visible = false;
                ToolStripMenuItemMainI.Visible = false;

                pcbNew.Enabled = false;
                pcbDelete.Enabled = false;
                grbUpdteTarget.Enabled = false;

            }

            LoadData();

        }
        private void LoadData()
        {
            Cursor.Current = Cursors.WaitCursor;

            code = "";
            
            List<Personnel> personnels1 = new PersonnelRepo().GetPersonnels();
            personnels1.Add(new Personnel { P_id = "0000", P_name = "-กรุณาเลือกข้อมูล-" });
            cmbA_sender.DataSource = personnels1.OrderBy(c=>c.P_id).ToList();
            cmbA_sender.ValueMember = "P_name";
            cmbA_sender.DisplayMember = "P_name";

            List<Personnel> personnels2 = new PersonnelRepo().GetPersonnels();
            personnels2.Add(new Personnel { P_id = "0000", P_name = "-กรุณาเลือกข้อมูล-" });
            cmbAssignTo.DataSource = personnels2.OrderBy(c=>c.P_id).ToList();
            cmbAssignTo.ValueMember = "P_name";
            cmbAssignTo.DisplayMember = "P_name";

            List<AssignmentPartial> assignmentPartials = new AssignmentRepo().GetAssignmentsForActive().ToList();
            dgvList.DataSource = assignmentPartials;


            //summary task 
            lblJobSummary.Text = assignmentPartials.Where(c => c.U_status == "Wait").Count().ToString();
            grdSummary.DataSource = null;
            grdSummary.DataSource = assignmentPartials.Where(c => c.U_status == "Wait").GroupBy(c => c.A_assign).Select(g => new { User = g.Key, Count = g.Count() }).OrderBy(c => c.User).ToList();


            Cursor.Current = Cursors.Default;
        }


        private void dgvList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string userStatus = (string)dgvList["U_status", e.RowIndex].Value;
            string targetDateStr = (string)dgvList["A_target", e.RowIndex].Value;
            DateTime targetDate = DateTime.ParseExact(targetDateStr, @"dd/MM/yyyy",  System.Globalization.CultureInfo.InvariantCulture); //Convert.ToDateTime(targetDateStr);


            if (userStatus == "Wait" && targetDate < DateTime.Now.Date)
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }

            if (userStatus == "Complete")
            {
                dgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            }

        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            EditData();
        }
        private void EditData()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (code != "")
            {
                frmAddEditAssignment fAddEditAssignment = new frmAddEditAssignment();
                fAddEditAssignment.Action = "Edit";
                fAddEditAssignment.Code = code;
                fAddEditAssignment.Show();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
            Cursor.Current = Cursors.Default;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["A_id"].FormattedValue.ToString();
            }
        }

        private void pcbDelete_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("ไม่สามารถทำการลบข้อมูลได้", "Information");
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูล : " + code, "กรุณายืนยัน", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Result result = new AssignmentRepo().Delete(code);
                    if (result.Flag)
                    {
                        MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "Information");
                        LoadData();
                    }

                }

            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void pcbRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }
        private void Reset()
        {
            txtA_id.Text = "";
            txtA_name.Text = "";
            txtA_code.Text = "";
            txtRemark.Text = "";
            chkA_date.Checked = false;
            dtpA_startDate.Value = DateTime.Now;
            dtpA_endDate.Value = DateTime.Now;
            cmbA_sender.SelectedIndex = 0;
            cmbAssignTo.SelectedIndex = 0;
            txtBrand.Text = "";
            chkSenderOpen.Checked = false;
            chkSenderClose.Checked = false;
            chkAssignWait.Checked = false;
            chkAssignComplete.Checked = false;
            chkAll.Checked = false;

        }

        private void pcbReset_Click(object sender, EventArgs e)
        {
            Reset();
            LoadData();
        }

        private void pcbExport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ExportExcel();
            Cursor.Current = Cursors.Default;
        }

        private void ExportExcel()
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook ExcelBook;
            Microsoft.Office.Interop.Excel._Worksheet ExcelSheet;

            int i = 0;
            int j = 0;

            //create object of excel
            ExcelBook = (Microsoft.Office.Interop.Excel._Workbook)ExcelApp.Workbooks.Add(1);
            ExcelSheet = (Microsoft.Office.Interop.Excel._Worksheet)ExcelBook.ActiveSheet;

            // header
            for (i = 1; i <= this.dgvList.Columns.Count; i++)
            {
                ExcelSheet.Cells[1, i] = this.dgvList.Columns[i - 1].HeaderText;
            }

            // data
            for (i = 1; i <= this.dgvList.RowCount; i++)
            {
                for (j = 1; j <= dgvList.Columns.Count; j++)
                {
                    ExcelSheet.Cells[i + 1, j] = dgvList.Rows[i - 1].Cells[j - 1].Value;
                }
            }

            ExcelApp.Visible = true;
            ExcelSheet = null;
            ExcelBook = null;
            ExcelApp = null;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["A_id"].FormattedValue.ToString();
                if (code != "")
                {
                    EditData();
                }
            }
        }

        private void pcbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            Cursor.Current = Cursors.WaitCursor;

            List<AssignmentPartial> assignments = new List<AssignmentPartial>();
            string id = txtA_id.Text;
            string name = txtA_name.Text.ToLower();
            string code = txtA_code.Text.ToLower();
            string brand = txtBrand.Text.ToLower();
            DateTime startDate = dtpA_startDate.Value.Date;
            DateTime endDate= dtpA_endDate.Value.Date;
            string remark = txtRemark.Text.ToLower();
            string sender = cmbA_sender.Text;
            string assignTo = cmbAssignTo.Text;


            if (chkAll.Checked)
            {
                //ต้องมีเงื่อนไขในการ search 
                if (id == "" && name == "" && code == "" && brand == "" &&
                    chkA_date.Checked == false && remark == "" && sender == "-กรุณาเลือกข้อมูล-" &&
                    assignTo == "-กรุณาเลือกข้อมูล-" && chkSenderOpen.Checked == false && chkSenderClose.Checked == false &&
                   chkAssignWait.Checked == false && chkAssignComplete.Checked == false)
                {
                    MessageBox.Show("กรุณาระบุเงือนไขในการค้นหา");
                    return;
                }

                assignments = new AssignmentRepo().GetAssignments();
            }
            else
            {
                assignments = new AssignmentRepo().GetAssignmentsForActive();
            }

         

 


            if (id != "")
            {
                assignments = assignments.Where(c => c.A_id == id).ToList();
            }
            if (name != "")
            {
                assignments = assignments.Where(c => c.A_name.ToLower().Contains(name)).ToList();
            }
            if (code != "")
            {
                assignments = assignments.Where(c => c.A_code.ToLower().Contains(code)).ToList();
            }
            if (brand != "")
            {
                assignments = assignments.Where(c => c.A_Brand.ToLower().Contains(brand)).ToList();
            }

            //sender status 
            if (chkSenderOpen.Checked && chkSenderClose.Checked)
            {
                assignments = assignments.Where(c => c.A_status == "Open" || c.A_status == "Closed").ToList();
            }
            if (chkSenderOpen.Checked && chkSenderClose.Checked == false)
            {
                assignments = assignments.Where(c => c.A_status == "Open").ToList();
            }
            if (chkSenderOpen.Checked == false && chkSenderClose.Checked)
            {
                assignments = assignments.Where(c => c.A_status == "Closed").ToList();
            }

            //assign status 
            if (chkAssignWait.Checked && chkAssignComplete.Checked)
            {
                assignments = assignments.Where(c => c.U_status == "Wait" || c.U_status == "Complete").ToList();
            }
            if (chkAssignWait.Checked && chkAssignComplete.Checked == false)
            {
                assignments = assignments.Where(c => c.U_status == "Wait").ToList();
            }
            if (chkAssignWait.Checked == false && chkAssignComplete.Checked)
            {
                assignments = assignments.Where(c => c.U_status == "Complete").ToList();
            }

            //date 
            if (chkA_date.Checked)
            {
                // assignments = assignments.Where(c => DateTime.ParseExact( c.A_date,@"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(c.A_date, @"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) <= endDate).ToList();
                 assignments = assignments.Where(c => DateTime.ParseExact(c.A_date,"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(c.A_date,"dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) <= endDate).ToList();
                
            }

            if (remark !="")
            {
                assignments = assignments.Where(c => c.A_detail.ToLower().Contains(remark) || c.U_detail1.ToLower().Contains(remark) || c.U_detail2.ToLower().Contains(remark) || c.U_detail3.ToLower().Contains(remark)).ToList();
            }
 
            if (sender !="-กรุณาเลือกข้อมูล-")
            {
                assignments = assignments.Where(c => c.A_sander == sender).ToList();
            }
            if (assignTo != "-กรุณาเลือกข้อมูล-")
            {
                assignments = assignments.Where(c => c.A_assign == assignTo).ToList();
            }

           

            dgvList.DataSource = assignments;

            //summarytask
            lblJobSummary.Text = assignments.Where(c => c.U_status == "Wait").Count().ToString();
            grdSummary.DataSource = null;
            grdSummary.DataSource = assignments.Where(c => c.U_status == "Wait").GroupBy(c => c.A_assign).Select(g => new { User = g.Key, Count = g.Count() }).OrderBy(c => c.User).ToList();


            Cursor.Current = Cursors.Default;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการที่จะ update target ใช่หรือไม่", "comfirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string status;
                string id;
                //do something
                List<string> aIDs = new List<string>();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    status =(string) dgvList.Rows[i].Cells["U_status"].Value;
                    if (status=="Wait")
                    {
                        aIDs.Add(dgvList.Rows[i].Cells["A_id"].Value.ToString());
                    }
                }

                if (aIDs.Count()>0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //update target
                    Result result = new AssignmentRepo().UpdateTarget(aIDs, dtpNewTarget.Value);

                    if (result.Flag)
                    {
                        MessageBox.Show("Update Target เรียบร้อยแล้ว");

                    }

                    Cursor.Current = Cursors.Default;
                }
            }
   
        }

        private void ToolStripMenuExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการออกจากโปรแกรม ใช่หรือไม่", "กรุณายืนยัน", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
