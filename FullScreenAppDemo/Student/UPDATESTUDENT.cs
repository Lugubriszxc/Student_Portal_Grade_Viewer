﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FullScreenAppDemo.db;
using FullScreenAppDemo.perips;

namespace FullScreenAppDemo
{
    public partial class UPDATESTUDENT : Form
    {
        //int selectedRow = 0;

        
        studentPortalEntities _context = new studentPortalEntities();
        int studID;

        public static string schoolID = "";
        public static string updateChoice = "";

        //string[] spid = new string[255];
        List<string> spid = new List<string>();
        int counter = 0;
        public UPDATESTUDENT()
        {
            InitializeComponent();
        }

        private void PROCEED_Click(object sender, EventArgs e)
        {
            
            UPDATEPANEL.Show();
            NEXTPANEL.Hide();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            

            RegisStudent mj = new RegisStudent();
            mj.TopLevel = false;
            NEXTPANEL.Controls.Clear();
            NEXTPANEL.Controls.Add(mj);
            mj.Show();
        }
        private void openSTList()
        {
            //RegisDashboard mj = new RegisDashboard();
            //mj.Show();

            //RegisStudent m = new RegisStudent();
            //m.TopLevel = false;

          
            //mj.DashboardPanel.Controls.Clear();
            //mj.DashboardPanel.Controls.Add(m);

            //m.Show();


            RegisStudent mj = new RegisStudent();
            mj.TopLevel = false;
            NEXTPANEL.Controls.Clear();
            NEXTPANEL.Controls.Add(mj);
            mj.Show();


        }

        private void UPDATESTUDENT_Load(object sender, EventArgs e)
        {
            
            UPDATEPANEL.Hide();
            NEXTPANEL.Show();


            dgvSubAssignment.Columns[0].Visible = false;
            dgvSubAssignment.Columns[5].Visible = false;
            dgvSubAssignment.Columns[6].Visible = false;

            loadList();
            yearLoad();
            loadSemester();
            loadSubs();
        }
        public void loadList()
        {
            //textS_StudentID.Text = studentList.studentID;
            studID = Int32.Parse(RegisStudent.studentID.ToString());
            schoolID = RegisStudent.schoolID.ToString();
            //MessageBox.Show(studID.ToString());
            //var selectedRowID = _context.studentBackgrounds.Where(q => q.StudentID == studID).FirstOrDefault();
            //var selectedRow = _context.userAccs.Where(q => q.id == selectedRowID).FirstOrDefault();

            var selectedRowID = _context.studentBackgrounds.Where(q => q.S_SchoolID == schoolID).FirstOrDefault();

            textS_StudentID.Text = selectedRowID.S_SchoolID.ToString().Trim();
            textS_Fname.Text = selectedRowID.S_fname.ToString().Trim();
            textS_Mname.Text = selectedRowID.S_mname.ToString().Trim();
            textS_Lname.Text = selectedRowID.S_lname.ToString().Trim();
            comboGender.Text = selectedRowID.S_Sex.ToString().Trim();
            date_S_Birthdate.Value = Convert.ToDateTime(selectedRowID.S_Birthdate.ToString());
            textS_MobileNumber.Text = selectedRowID.S_mNumber.ToString().Trim();
            textS_EmailAdd.Text = selectedRowID.S_emailAdd.ToString().Trim();
            textS_Religion.Text = selectedRowID.S_Religion.ToString().Trim();
            textS_Citizenship.Text = selectedRowID.S_Citizenship.ToString().Trim();
            textS_Province.Text = selectedRowID.S_Province.ToString().Trim();
            textS_Municipality.Text = selectedRowID.S_municipality.ToString().Trim();
            textS_Barangay.Text = selectedRowID.S_barangay.ToString().Trim();
            textS_Guardian_Fname.Text = selectedRowID.S_Guardian_fname.ToString().Trim();
            textS_Guardian_Mname.Text = selectedRowID.S_Guardian_mname.ToString().Trim();
            textS_Guardian_LName.Text = selectedRowID.S_Guardian_lname.ToString().Trim();
            textS_Guardian_Contact.Text = selectedRowID.S_Guardian_contact.ToString().Trim();

            loadDepartment();
        }



        private void loadDepartment()
        {
            var selected = _context.Departments.ToList();


            //Getting the department id from student profile
            var studProf = _context.Student_Profile.FirstOrDefault(q => q.StudentID == studID.ToString());
            int studDep = Int32.Parse(studProf.DepartmentID.ToString());

            //Getting the department id from department id
            var studDepName = _context.Departments.FirstOrDefault(q => q.Department_ID == studDep);
            string studDepNames = studDepName.Department_Name.ToString();

            foreach (var item in selected)
            {
                DepartmentValue dv = new DepartmentValue();
                dv.Text = item.Department_Name; //Display name
                dv.Value = item.Department_ID; //value inside the name

                cBDepartment.Items.Add(dv);
            }

            cBDepartment.SelectedIndex = cBDepartment.FindString(studDepNames);
            loadCourse();
        }

        private void loadCourse()
        {

            cBCourse.Items.Clear();
            string depID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
            var selectedC = _context.Courses.ToList();

            //Getting the course id from student profile
            var studProf = _context.Student_Profile.FirstOrDefault(q => q.StudentID == studID.ToString());
            int studCourse = Int32.Parse(studProf.CourseID.ToString());

            //Getting the course id from course
            var studCourseName = _context.Courses.FirstOrDefault(q => q.CourseID == studCourse);
            string studCourseNames = studCourseName.Course_name.ToString();

            foreach (var item in selectedC)
            {
                if (item.DepartmentID == depID)
                {
                    courseValue cv = new courseValue();
                    cv.Text = item.Course_name; //Display name
                    cv.Value = item.CourseID; //value inside the name

                    cBCourse.Items.Add(cv);
                }
            }
            //cBCourse.SelectedIndex = -1;
            //cBDepartment.SelectedIndex = cBDepartment.FindString(studDepNames);
            cBCourse.SelectedIndex = cBCourse.FindString(studCourseNames);
            loadSection();
        }
        private void loadSubs()
        {
            string depID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
            string corID = (cBCourse.SelectedItem as courseValue).Value.ToString();
            string clID = ((cBSection.SelectedItem as classValue).Value.ToString());

            var res = (
                from sp in _context.Student_Profile
                join sb in _context.S_Subject on sp.SubjectID equals sb.SubjectID.ToString()
                join ib in _context.Instructors on sp.InstructorID equals ib.InstructorID.ToString()
                where (sp.StudentID == studID.ToString()) && (sp.Semester == cBSemester.Text.Trim())
                && (sp.YearLevel == cBYear.Text.Trim()) && (sp.DepartmentID == depID)
                && (sp.CourseID == corID) && (sp.ClassID == clID)

                select new studentAssignSub
                {
                    CODE = sb.SubjectCode.ToString(),
                    UNITS = sb.SubjectUnit.ToString(),
                    SUBJECT = sb.SubjectName.ToString(),
                    INSTRUCTOR = ib.Instructor_fname + ", " + ib.Instructor_lname,
                    subject_id = sb.SubjectID,
                    SubjectID = sp.SP_ID,
                    instructor_id = ib.InstructorID
                }

                ).ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(res);
            dgvSubAssignment.DataSource = dt;
            calculateUnit();
           
        }

        private void calculateUnit()
        {
            int sum = 0;
            string hello = "";
            for (int i = 0; i < dgvSubAssignment.Rows.Count; ++i)
            {
                //sum += Convert.ToInt32(dgvSubAssignment.Rows[i].Cells[2].Value);
                hello = dgvSubAssignment.Rows[i].Cells[3].Value.ToString();
                if (hello != "")
                {
                    //sum = Int32.Parse(hello.ToString());
                    sum += Int32.Parse(hello.ToString());
                }
            }
            labelUnits.Text = sum.ToString();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to UPDATE", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                  string schoolID = textS_StudentID.Text.Trim();


                var res = _context.studentBackgrounds.Where(q => q.S_SchoolID == schoolID).ToList();

                _context.studentBackgrounds.Where(q => q.S_SchoolID == schoolID.ToString()).ToList().ForEach(
                    stud =>
                    {
                        stud.S_fname = textS_Fname.Text.Trim();
                        stud.S_mname = textS_Mname.Text.Trim();
                        stud.S_lname = textS_Lname.Text.Trim();
                        stud.S_Sex = comboGender.Text.Trim();
                        stud.S_Birthdate = date_S_Birthdate.Text.Trim();
                        stud.S_mNumber = textS_MobileNumber.Text.Trim();
                        stud.S_emailAdd = textS_EmailAdd.Text.Trim();
                        stud.S_Religion = textS_Religion.Text.Trim();
                        stud.S_Citizenship = textS_Citizenship.Text.Trim();
                        stud.S_Province = textS_Province.Text.Trim();
                        stud.S_municipality = textS_Municipality.Text.Trim();
                        stud.S_barangay = textS_Barangay.Text.Trim();
                        stud.S_Guardian_fname = textS_Guardian_Fname.Text.Trim();
                        stud.S_Guardian_mname = textS_Guardian_Mname.Text.Trim();
                        stud.S_Guardian_lname = textS_Guardian_LName.Text.Trim();
                        stud.S_Guardian_contact = textS_Guardian_Contact.Text.Trim();
                    }
                    );

                var selectedDepID = _context.Student_Profile.Where(q => q.StudentID == studID.ToString()).FirstOrDefault();

                _context.SaveChanges();
                updatedProfile();
                MessageBox.Show("Succesfully Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                openSTList();
                
            }
           
        }

        private void cBDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUpdateCourse();
            loadUpdatedSection();
           
        }

        private void cBCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUpdatedSection();
        }

        private void cBYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUpdatedSection();
        }
        private void loadUpdateCourse()
        {
            cBCourse.Items.Clear();
            string depID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
            var selectedC = _context.Courses.ToList();

            foreach (var item in selectedC)
            {
                if (item.DepartmentID == depID)
                {
                    courseValue cv = new courseValue();
                    cv.Text = item.Course_name; //Display name
                    cv.Value = item.CourseID; //value inside the name

                    cBCourse.Items.Add(cv);
                }
            }
            cBCourse.SelectedIndex = -1;
        }
        private void loadUpdatedSection()
        {
            cBSection.Items.Clear();
            string Department_ID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
            string yearLevel = cBYear.Text.Trim();

            if (cBCourse.Text.Trim() != "")
            {
                string CourseID = (cBCourse.SelectedItem as courseValue).Value.ToString();
                var selectedClass = _context.Class_S.ToList();

                foreach (var item in selectedClass)
                {
                    if (item.DepartmentID == Department_ID && item.CourseID == CourseID && item.YearLevel == yearLevel)
                    {
                        classValue cvs = new classValue();
                        cvs.Text = item.ClassName;
                        cvs.Value = item.ClassID;

                        cBSection.Items.Add(cvs);
                    }
                }
                cBSection.SelectedIndex = -1;
            }
        }

        private void updatedProfile()
        {
            try
            {
                string schoolID = textS_StudentID.Text.Trim();
                //RENDER IF THERE IS ALREADY AN EXISITNG DATA UNDER THE SELECTED SCHOOL ID
                //GET THE SELECTED COMBO BOXES
                string departmentID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
                string courseID = (cBCourse.SelectedItem as courseValue).Value.ToString();
                string yearLevel = cBYear.Text.Trim();
                string classID = (cBSection.SelectedItem as classValue).Value.ToString();
                string semester = cBSemester.Text.Trim();


                var render = _context.Student_Profile.Where(q => q.SchoolID == schoolID
                && q.DepartmentID == departmentID && q.CourseID == courseID && q.YearLevel == yearLevel
                && q.ClassID == classID && q.Semester == semester).FirstOrDefault();

                if (render != null)
                {
                    string studentID = RegisStudent.studentID.ToString();
                    //CHECK IF IT'S BECAUSE OF ORIGINAL VALUE
                    var res = _context.Student_Profile.Where(q => q.StudentID == studentID).FirstOrDefault();
                    string odepartmentID = res.DepartmentID;
                    string ocourseID = res.CourseID;
                    string oyearLevel = res.YearLevel;
                    string oclassID = res.ClassID;
                    string osemester = res.Semester;

                    if (odepartmentID == departmentID && ocourseID == courseID && oyearLevel == yearLevel
                        && oclassID == classID && osemester == semester) // MEANS IT'S BECAUSE OF ORIGINAL DATA
                    {
                        //Get the values that is missing and remove it.
                        //string d = spid.Length.ToString();

                        for (int i = 0; i < spid.Count; i++)
                        {
                            if (spid[i] != null || spid[i] != "")
                            {
                                int convertSPID = int.Parse(spid[i].ToString());
                                string spidString = spid[i].ToString();
                                var selectedRegis = _context.regisGrades.Where(q => q.SP_ID == spidString).FirstOrDefault();
                                var selectedRowID = _context.Student_Profile.Where(q => q.SP_ID == convertSPID).FirstOrDefault();
                                _context.regisGrades.Remove(selectedRegis);
                                _context.Student_Profile.Remove(selectedRowID);
                            }
                        }
                        _context.SaveChanges();

                        //int studID = Convert.ToInt32(textS_StudentID.ToString());
                        _context.Student_Profile.Where(q => q.StudentID == studID.ToString()).ToList().ForEach(
                            x =>
                            {
                                x.DepartmentID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
                                x.CourseID = (cBCourse.SelectedItem as courseValue).Value.ToString();
                                x.YearLevel = cBYear.Text.Trim();
                                x.ClassID = (cBSection.SelectedItem as classValue).Value.ToString();
                                x.Semester = cBSemester.Text.Trim();
                            }
                            );

                        /*db.tblTemp.Where(x => x.ProductID == parmProductID && x.IsActive == true).ToList().ForEach(x =>
                        {
                            x.IsActive = false; x.UpdatedTimeStamp = DateTime.Now;
                        });
                        db.SaveChanges();*/

                        _context.SaveChanges();
                        openSTList();
                    }
                    else
                    {
                        MessageBox.Show("THERE IS ALREADY AN EXISITNG RECORD IN THIS SELECTED ID");
                    }
                }
                else
                {
                    //Get the values that is missing and remove it.
                    //string d = spid.Length.ToString();

                    for (int i = 0; i < spid.Count; i++)
                    {
                        if (spid[i] != null || spid[i] != "")
                        {
                            int convertSPID = int.Parse(spid[i].ToString());
                            string spidString = spid[i].ToString();
                            var selectedRegis = _context.regisGrades.Where(q => q.SP_ID == spidString).FirstOrDefault();
                            var selectedRowID = _context.Student_Profile.Where(q => q.SP_ID == convertSPID).FirstOrDefault();
                            _context.regisGrades.Remove(selectedRegis);
                            _context.Student_Profile.Remove(selectedRowID);
                        }
                    }
                    _context.SaveChanges();

                    //int studID = Convert.ToInt32(textS_StudentID.ToString());
                    _context.Student_Profile.Where(q => q.StudentID == studID.ToString()).ToList().ForEach(
                        x =>
                        {
                            x.DepartmentID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
                            x.CourseID = (cBCourse.SelectedItem as courseValue).Value.ToString();
                            x.YearLevel = cBYear.Text.Trim();
                            x.ClassID = (cBSection.SelectedItem as classValue).Value.ToString();
                            x.Semester = cBSemester.Text.Trim();
                        }
                        );

                    /*db.tblTemp.Where(x => x.ProductID == parmProductID && x.IsActive == true).ToList().ForEach(x =>
                    {
                        x.IsActive = false; x.UpdatedTimeStamp = DateTime.Now;
                    });
                    db.SaveChanges();*/

                    _context.SaveChanges();
                    openSTList();
                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void yearLoad()
        {
            var studProf = _context.Student_Profile.FirstOrDefault(q => q.StudentID == studID.ToString());
            string studYear = studProf.YearLevel.ToString();

            cBYear.SelectedIndex = cBYear.FindString(studYear);
            loadSection();
        }

        private void loadSemester()
        {
            var studProf = _context.Student_Profile.FirstOrDefault(q => q.StudentID == studID.ToString());
            string studSem = studProf.Semester.ToString();

            cBSemester.SelectedIndex = cBSemester.FindString(studSem);
        }

        private void loadSection()
        {
            cBSection.Items.Clear();
            string Department_ID = (cBDepartment.SelectedItem as DepartmentValue).Value.ToString();
            string yearLevel = cBYear.Text.Trim();

            var studProf = _context.Student_Profile.FirstOrDefault(q => q.StudentID == studID.ToString());
            int studSectionID = Int32.Parse(studProf.ClassID.ToString());

            var studSection = _context.Class_S.FirstOrDefault(q => q.ClassID == studSectionID);
            string studSectionName = studSection.ClassName.ToString();

            if (cBCourse.Text.Trim() != "")
            {
                string CourseID = (cBCourse.SelectedItem as courseValue).Value.ToString();
                var selectedClass = _context.Class_S.ToList();

                foreach (var item in selectedClass)
                {
                    if (item.DepartmentID == Department_ID && item.CourseID == CourseID && item.YearLevel == yearLevel)
                    {
                        classValue cvs = new classValue();
                        cvs.Text = item.ClassName;
                        cvs.Value = item.ClassID;

                        cBSection.Items.Add(cvs);
                    }
                }
                //cBSection.SelectedIndex = -1;
                cBSection.SelectedIndex = cBSection.FindString(studSectionName);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to DELETE", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int rowindex = dgvSubAssignment.CurrentCell.RowIndex;

                spid.Add(!string.IsNullOrEmpty(dgvSubAssignment.CurrentRow.Cells[0].Value.ToString()) ? dgvSubAssignment.CurrentRow.Cells[0].Value.ToString() : "");
                counter++;
                dgvSubAssignment.Rows.Remove(dgvSubAssignment.CurrentRow);
                dgvSubAssignment.Refresh();
                calculateUnit();


                gunaButton1.Visible = false;
                MessageBox.Show("Succesfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void dgvSubAssignment_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gunaButton1.Visible = true;
        }

        private void UPDATEPANEL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            UPDATEPANEL.Hide();
            NEXTPANEL.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            

            schoolID = textS_StudentID.Text.Trim();
            updateChoice = "addExisting";

            RegisStudent mj = new RegisStudent();
            mj.TopLevel = false;
            NEXTPANEL.Controls.Clear();
            NEXTPANEL.Controls.Add(mj);
            mj.Show();





        }
      
    }
}
