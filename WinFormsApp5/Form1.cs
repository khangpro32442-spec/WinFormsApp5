using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();

            employees.Add(new Employee { Id = "NV001", Name = "Nguyễn Thị Thu Hiền", Salary = 8500000 });
            RefreshList();
        }

        private void RefreshList()
        {
            listView1.Items.Clear();
            foreach (var e in employees)
            {
                var item = new ListViewItem(e.Id);
                item.SubItems.Add(e.Name);
                item.SubItems.Add(e.Salary.ToString("N0", CultureInfo.InvariantCulture));
                item.Tag = e;
                listView1.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var f = new EmployeeForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                var emp = new Employee { Id = f.MSNV, Name = f.EmployeeName, Salary = f.LuongCB };
                employees.Add(emp);
                RefreshList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = listView1.SelectedItems[0];
            var emp = item.Tag as Employee;
            if (emp == null) return;

            using var f = new EmployeeForm();
            f.MSNV = emp.Id;
            f.EmployeeName = emp.Name;
            f.LuongCB = emp.Salary;

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                emp.Id = f.MSNV;
                emp.Name = f.EmployeeName;
                emp.Salary = f.LuongCB;
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = listView1.SelectedItems[0];
            var emp = item.Tag as Employee;
            if (emp == null) return;

            var r = MessageBox.Show($"Xóa nhân viên {emp.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                employees.Remove(emp);
                RefreshList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    internal class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
