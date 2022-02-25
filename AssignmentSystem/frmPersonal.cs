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
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
        }


        private string code;
        private string userName; 
        private void frmPersonal_Load(object sender, EventArgs e)
        {
            code = "";
            userName = "";
            dgvList.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            List<Personnel> personnels = new PersonnelRepo().GetPersonnels();
            dgvList.DataSource = personnels;
            code = "";
            userName = "";
        }

        private void pcbAdd_Click(object sender, EventArgs e)
        {
            
            frmAddEditPersonnel fAddEditPersonnel = new frmAddEditPersonnel();
            fAddEditPersonnel.Action = "Add";
            fAddEditPersonnel.ShowDialog(this);

            LoadData();
        }

        private void pcbEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void Edit()
        {
            if (code != "")
            {
                frmAddEditPersonnel fAddEditPersonnel = new frmAddEditPersonnel();
                fAddEditPersonnel.Action = "Edit";
                fAddEditPersonnel.Code = code;
                fAddEditPersonnel.ShowDialog(this);

                LoadData();
            }
            else
            {
                MessageBox.Show("ยังไม่ได้เลือกรายการ", "Information");
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                dgvList.CurrentRow.Selected = true;
                code = dgvList.Rows[e.RowIndex].Cells["P_id"].FormattedValue.ToString();
                userName = dgvList.Rows[e.RowIndex].Cells["P_name"].FormattedValue.ToString();
            }
        }

        private void pcbDelete_Click(object sender, EventArgs e)
        {
            if (code != "")
            {
                DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูล : " + userName, "กรุณายืนยัน", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Result result = new PersonnelRepo().Delete(code);
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

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }
    }
}
