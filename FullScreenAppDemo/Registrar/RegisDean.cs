﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullScreenAppDemo.db;
using FullScreenAppDemo.perips;

namespace FullScreenAppDemo
{
    public partial class RegisDean : Form
    {

        studentPortalEntities _context = new studentPortalEntities();
        DepartmentValue dv = new DepartmentValue();
        courseValue cv = new courseValue();

        public static int departmentID = 0;
       
        public static int courseID = 0;

        public static int deanID = 0;
        public static string choicedean = "";
        public static string choicedepartment = "";
        public static string choicecourse = "";
       // string DEANID = "";


        public RegisDean()
        {
            InitializeComponent();
        }


        private void RegisDean_Load(object sender, EventArgs e)
        {
            
            loadData();
            //dgvDepartmentList.DataSource = _context.Departments.ToList();
            loadCourse();
            loaddep();

            deletedepartment.Visible = false;




        }
        public void loadData()
        {
            var res = (
                from dea in _context.Deans
                join dep in _context.Departments
                on dea.Department_ID equals dep.Department_ID.ToString()

                select new DeanWithDepartment
                {
                    DeanID = dea.DeanID,
                    Dean_Name = dea.Dean_fname + ", " + dea.Dean_lname,
                    Department_Name = dep.Department_Name
                }
             ).ToList();

            dgvDeanList.DataSource = res;
        }
        private void loadCourse()
        {
            var res1 = (
                from cour in _context.Courses
                join deps in _context.Departments
                on cour.DepartmentID equals deps.Department_ID.ToString()

                select new courseImps
                {
                    CourseID = cour.CourseID,
                    Course_name = cour.Course_name,
                    Department_Name = deps.Department_Name
                }

                ).ToList();

            dgvCourseList.DataSource = res1;
        }
        private void loaddep()
        {
            dgvDepartmentList.DataSource = _context.Departments.ToList();
        }
        private void btnAddDean_Click_1(object sender, EventArgs e)
        {

            choicedean = "add";
            DeanImport std = new DeanImport(this);
            std.UpdateEventHandler += F5_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void F2_UpdateEventHandler1(object sender, DepartmentImport.UpdateEventArgs args)
        {
            loaddep();
        }
        private void F5_UpdateEventHandler1(object sender, DeanImport.UpdateEventArgs args)
        {
            loadData();
        }
       
        private void F3_UpdateEventHandler1(object sender, CourseImport.UpdateEventArgs args)
        {
            loadCourse();
        }
        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            choicedepartment = "add";
            DepartmentImport std = new DepartmentImport(this);
            std.UpdateEventHandler += F2_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void deletedepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int departID = Int32.Parse(departmentID.ToString());
                    var selectedRow = _context.Departments.Where(q => q.Department_ID == departID).FirstOrDefault();

                    _context.Departments.Remove(selectedRow);
                    _context.SaveChanges();
                    dgvDepartmentList.DataSource = _context.Departments.ToList();

                    deletedepartment.Visible = false;
                    MessageBox.Show("Successfully Deleted");
                }
            }
            catch
            {
                MessageBox.Show("ERROR HAPPENS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
          
            
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            choicecourse = "add";
            CourseImport std = new CourseImport(this);
            std.UpdateEventHandler += F3_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void deletecourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int departID = Int32.Parse(courseID.ToString());
                    var selectedRow = _context.Courses.Where(q => q.CourseID == departID).FirstOrDefault();

                    _context.Courses.Remove(selectedRow);
                    _context.SaveChanges();
                    loadCourse();
                    MessageBox.Show("Successfully Deleted");
                    deletecourse.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("ERROR HAPPENS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        private void dgvDepartmentList_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDepartmentList.SelectedRows.Count > 0)
            {
                departmentID = Convert.ToInt32(dgvDepartmentList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void dgvCourseList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourseList.SelectedRows.Count > 0)
            {
                courseID = Convert.ToInt32(dgvCourseList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dgvDeanList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            choicedean = "update";
            DeanImport std = new DeanImport(this);
            std.UpdateEventHandler += F5_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void dgvDeanList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDeanList.SelectedRows.Count > 0)
            {
                deanID = Int32.Parse(dgvDeanList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }


        private void dgvDepartmentList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // deletedepartment.Visible = true;
            choicedepartment = "update";
            DepartmentImport v = new DepartmentImport(this);
            v.UpdateEventHandler += F2_UpdateEventHandler1;
            v.ShowDialog();
        }

        private void dgvCourseList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            choicecourse = "update";
            CourseImport std = new CourseImport(this);
            std.UpdateEventHandler += F3_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void dgvCourseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deletecourse.Visible = true;
        }

        private void dgvDepartmentList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  deletedepartment.Visible = true;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to DELETE", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var selectedRow = _context.Deans.Where(q => q.DeanID == deanID).FirstOrDefault();

                    //MessageBox.Show("Are you sure you want to delete?",)
                    _context.Deans.Remove(selectedRow);
                    _context.SaveChanges();

                    loadData();
                    MessageBox.Show("Succesfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("ERROR HAPPENS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void dgvDeanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gunaButton1.Visible = true;
        }

        private void dgvDepartmentList_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            choicedepartment = "update";
            DepartmentImport std = new DepartmentImport(this);
            std.UpdateEventHandler += F2_UpdateEventHandler1;
            std.ShowDialog();
        }

        private void dgvDepartmentList_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvDepartmentList.SelectedRows.Count > 0)
            {
                departmentID = Convert.ToInt32(dgvDepartmentList.SelectedRows[0].Cells[0].Value.ToString());
            }
            //deletedepartment.Visible = true;
        }

        private void dgvDepartmentList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            deletedepartment.Visible = true;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            //String keyword = guna2TextBox1.Text.Trim();
            //dgvDeanList.DataSource = _context.Deans.Where(q => q.Dean_fname.Contains(keyword)).Select(qr => new
            //  {
            //    qr.DeanID,
            //    qr.Dean_fname,
            //    qr.Dean_lname,
            //    qr.Dean_mname


            //}).Tolist();

            var res = (

                from dea in _context.Deans.Where(q => DbFunctions.Like(q.Dean_fname,"%" + guna2TextBox1.Text + "%"))
                join dep in _context.Departments
                on dea.Department_ID equals dep.Department_ID.ToString()

               


                select new DeanWithDepartment
                {
                    DeanID = dea.DeanID,
                    Dean_Name = dea.Dean_fname + ", " + dea.Dean_lname,
                    Department_Name = dep.Department_Name
                }
             ).ToList();

            dgvDeanList.DataSource = res;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            var res = (

                from hel in _context.Departments.Where(q => DbFunctions.Like(q.Department_Name, "%" + guna2TextBox2.Text + "%"))


                  select new { hel.Department_ID, hel.Department_Name}
            ).ToList();

            dgvDepartmentList.DataSource = res;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            deletedepartment.Visible = false;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
           
            var res1 = (
                from cour in _context.Courses.Where(q => DbFunctions.Like(q.Course_name, "%" + guna2TextBox3.Text + "%"))

                join deps in _context.Departments
                on cour.DepartmentID equals deps.Department_ID.ToString()

                select new courseImps
                {
                    CourseID = cour.CourseID,
                    Course_name = cour.Course_name,
                    Department_Name = deps.Department_Name
                }

                ).ToList();

            dgvCourseList.DataSource = res1;
        }
    }
}
