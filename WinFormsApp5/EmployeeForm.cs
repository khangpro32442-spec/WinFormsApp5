using System;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public class EmployeeForm : Form
    {
        private TextBox txtMSNV;
        private TextBox txtName;
        private TextBox txtSalary;
        private Button btnOk;
        private Button btnCancel;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MSNV
        {
            get => txtMSNV.Text.Trim();
            set => txtMSNV.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EmployeeName
        {
            get => txtName.Text.Trim();
            set => txtName.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal LuongCB
        {
            get
            {
                if (decimal.TryParse(txtSalary.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.Number, CultureInfo.InvariantCulture, out var v))
                    return v;
                if (decimal.TryParse(txtSalary.Text.Trim(), out v))
                    return v;
                return 0;
            }
            set => txtSalary.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtMSNV = new TextBox();
            this.txtName = new TextBox();
            this.txtSalary = new TextBox();
            this.btnOk = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.txtMSNV.Location = new System.Drawing.Point(140, 20);
            this.txtMSNV.Size = new System.Drawing.Size(250, 25);
            this.txtMSNV.Font = this.Font;

            this.txtName.Location = new System.Drawing.Point(140, 60);
            this.txtName.Size = new System.Drawing.Size(250, 25);
            this.txtName.Font = this.Font;

            this.txtSalary.Location = new System.Drawing.Point(140, 100);
            this.txtSalary.Size = new System.Drawing.Size(250, 25);
            this.txtSalary.Font = this.Font;

            this.btnOk.Text = "Đồng ý";
            this.btnOk.Location = new System.Drawing.Point(140, 150);
            this.btnOk.Size = new System.Drawing.Size(110, 34);
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Click += BtnOk_Click;


            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Location = new System.Drawing.Point(280, 150);
            this.btnCancel.Size = new System.Drawing.Size(110, 34);
            this.btnCancel.DialogResult = DialogResult.Cancel;

            var lbl1 = new Label() { Text = "MSNV:", Location = new System.Drawing.Point(28, 24), AutoSize = true };
            lbl1.Font = this.Font;
            lbl1.ForeColor = System.Drawing.Color.Black;

            var lbl2 = new Label() { Text = "Tên nhân viên:", Location = new System.Drawing.Point(28, 64), AutoSize = true };
            lbl2.Font = this.Font;
            lbl2.ForeColor = System.Drawing.Color.Black;

            var lbl3 = new Label() { Text = "Lương căn bản:", Location = new System.Drawing.Point(28, 104), AutoSize = true };
            lbl3.Font = this.Font;
            lbl3.ForeColor = System.Drawing.Color.Black;

            this.ClientSize = new System.Drawing.Size(420, 200);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(this.txtMSNV);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nhân viên";
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MSNV))
            {
                MessageBox.Show("MSNV không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(EmployeeName))
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (LuongCB <= 0)
            {
                MessageBox.Show("Lương phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
        }
    }
}
