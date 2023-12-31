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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace FullScreenAppDemo
{
    public partial class ChangeStudentLoad : Form
    {

        studentPortalEntities _context = new studentPortalEntities();

        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        int classID = 0;
        int instructorID = 0;
        int subjectID = 0;

        string fileName = "";
        List<string> spid = new List<string>();
        public ChangeStudentLoad()
        {
            InitializeComponent();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            StudentLoad mj = new StudentLoad();
            mj.TopLevel = false;
            uipanel.Controls.Clear();
            uipanel.Controls.Add(mj);
            mj.Show();
        }

        private void ChangeStudentLoad_Load(object sender, EventArgs e)
        {
            checkList();
        }
        private void checkList()
        {
            if (dgvStudentLoad.Rows.Count <= 0)
            {
                gunaButton1.Visible = false;
            }
            else
            {
                gunaButton1.Visible = true;
            }
        }

        private void PROCEED_Click(object sender, EventArgs e)
        {
            loadCurrentData();
        }
        private void loadCurrentData()
        {
            /*dgvStudent.DataSource = null;
            dgvStudent.Rows.Clear();
            dgvStudent.Columns.Clear();
            dgvStudent.Refresh();*/

            // Clear the rows
            dgvStudentLoad.DataSource = null;
            dgvStudentLoad.Rows.Clear();
            dgvStudentLoad.Columns.Clear();

            // Reset the row count to the original value
            //dgvStudentLoad.RowCount = dgvStudentLoad.RowCount;
            dgvStudentLoad.Refresh();

            classID = Class.classID;
            instructorID = loginInstructor.instructorID;
            subjectID = Class.subjectID;

            var res = (
                from ai in _context.Student_Profile
                    /*join cl in _context.Class_S on ai.ClassID equals classID.ToString()
                    join ins in _context.Instructors on ai.InstructorID equals ins.InstructorID.ToString()
                    join sub in _context.S_Subject on ai.SubjectID equals sub.SubjectID.ToString()*/
                join stud in _context.studentBackgrounds on ai.StudentID equals stud.StudentID.ToString()

                where ai.ClassID == classID.ToString() && ai.InstructorID == instructorID.ToString()
                && ai.SubjectID == subjectID.ToString()

                select new
                {
                    studentID = stud.StudentID,
                    schoolID = stud.S_SchoolID,
                    STUDENT = stud.S_fname + " " + stud.S_mname + " " + stud.S_lname,
                    GRADE = !string.IsNullOrEmpty(ai.Grade.ToString()) ? ai.Grade.ToString() : " "
                    //StudentID = !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()) ? dataGridView1.CurrentRow.Cells[0].Value.ToString() : " ";
                }
                ).ToList();

            dgvStudentLoad.DataSource = res;
            checkList();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                sFDialog.InitialDirectory = "C";
            sFDialog.Title = "SAVE AS EXCEL FILE";
            sFDialog.FileName = "";
            sFDialog.Filter = "Excel Files (2016|*.xlsx|Excel Files(.CSV)|*.csv";

            if (sFDialog.ShowDialog() != DialogResult.Cancel)
            {
                Cursor.Current = Cursors.WaitCursor;
                //Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Quit();
                excelApp.Application.Workbooks.Add(Type.Missing);

                Range columnheaders = excelApp.Range["A5:D5"];
                //excelApp.Columns.ColumnWidth = 20;

                //populate data first from classID, subjectID, instructorID.
                string className = "";
                string subjectName = "";
                string instructor = "";
                var resClass = _context.Class_S.Where(q => q.ClassID == classID).FirstOrDefault();
                if (resClass != null)
                {
                    className = resClass.ClassName;
                }

                var resInstructor = _context.Instructors.Where(q => q.InstructorID == instructorID).FirstOrDefault();
                if (resInstructor != null)
                {
                    instructor = resInstructor.Instructor_fname + " " + resInstructor.Instructor_mname + " " + resInstructor.Instructor_lname;
                }

                var resSubject = _context.S_Subject.Where(q => q.SubjectID == subjectID).FirstOrDefault();
                if (resSubject != null)
                {
                    subjectName = resSubject.SubjectName;
                }
                //uiStudentLoad ul = new uiStudentLoad();
                //string className = ul.lblClass.Text.Trim();

                excelApp.Range["A1:B1"].Cells.Merge();
                excelApp.Range["C1:D1"].Cells.Merge();
                excelApp.Range["A2:B2"].Cells.Merge();
                excelApp.Range["C2:D2"].Cells.Merge();

                excelApp.Range["A5:D5"].RowHeight = 25;
                excelApp.Range["A5:D5"].ColumnWidth = 20;

                //columnheaders.Columns.AutoFit();
                excelApp.Columns.AutoFit();

                Range allData = excelApp.Range["A1:D2"];
                allData.Borders.LineStyle = XlLineStyle.xlContinuous;
                allData.Borders.Weight = XlBorderWeight.xlThin;
                allData.Font.Color = Color.Gold;

                //System.Xml.Formatting rangeFormatting = allData.BeginUpdateFormatting();
                allData.Borders.Color = Color.White;
                allData.Cells.Interior.Color = Color.Maroon;

                /*Range rng = excelApp.Cells[i + 5, j + 1];
                rng.Borders.LineStyle = XlLineStyle.xlContinuous;
                rng.Borders.Weight = XlBorderWeight.xlThin;
                rng.Font.Color = Color.Gold;

                rng.Borders.Color = Color.White;
                rng.Cells.Interior.Color = Color.Maroon;*/

                Range colHead = excelApp.Range["A5 : D5"];
                colHead.Borders.LineStyle = XlLineStyle.xlContinuous;
                colHead.Borders.Weight = XlBorderWeight.xlThin;
                colHead.Font.Color = Color.Gold;
                colHead.Borders.Color = Color.White;
                colHead.Cells.Interior.Color = Color.Maroon;

                string sem = Class.sem.ToString();
                excelApp.Cells[1, 1] = "Class : " + " " + className;
                excelApp.Cells[2, 1] = "Instructor : " + " " + instructor;
                excelApp.Cells[1, 3] = "Subject : " + " " + subjectName;
                excelApp.Cells[2, 3] = "Semester : " + " " + sem;


                //Where the column name should start
                for (int i = 1; i < dgvStudentLoad.Columns.Count + 1; i++)
                {
                    excelApp.Cells[5, i] = dgvStudentLoad.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvStudentLoad.Rows.Count; i++)
                {
                    //where the column value should start
                    for (int j = 0; j < dgvStudentLoad.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 6, j + 1] = dgvStudentLoad.Rows[i].Cells[j].Value.ToString();
                        Range colData = excelApp.Cells[i + 6, j + 1];
                        colData.Borders.LineStyle = XlLineStyle.xlContinuous;
                        colData.Borders.Weight = XlBorderWeight.xlMedium;
                        colData.Font.Color = Color.Black;
                        colData.Borders.Color = Color.Black;
                        colData.Cells.Interior.Color = Color.LightGray;
                        // excelApp.Cells[i + 2, j + 1] = !string.IsNullOrEmpty(dgvStudentLoad.Rows[i].Cells[j].Value.ToString()) ? dgvStudentLoad.Rows[i].Cells[j].Value.ToString() : " ";
                        //StudentID = !string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[0].Value.ToString()) ? dataGridView1.CurrentRow.Cells[0].Value.ToString() : " ";
                    }
                }

                /*Microsoft.Office.Interop.Excel.Workbook workbook;
                Worksheet ws = workbook.Worksheets["Sheet1"];*/

                fileName = sFDialog.FileName.ToString(); //SAVE THE FILE GLOBALLY
                excelApp.ActiveWorkbook.SaveCopyAs(sFDialog.FileName.ToString());
                excelApp.ActiveWorkbook.Saved = true;

                DialogResult dialogResult = MessageBox.Show("Export Done. Would you like to open it?", "OPEN EXCEL FILE?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //excelApp.Workbooks.Open(sFDialog.FileName.ToString(), ReadOnly: true);
                    //excelApp.Visible = true;
                    excelApp.Quit();
                    openFile();
                    //excelApp.Workbooks.Open(sFDialog.FileName.ToString(), ReadOnly: false);
                }
                else
                {
                    excelApp.Quit();
                }

            }
            Cursor.Current = Cursors.Default;
            }
            catch
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void openFile()
        {
            string fileName = sFDialog.FileName.ToString();
            //MessageBox.Show(fileName);
            var excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbooks books = excelApp.Workbooks;
            Excel.Workbook sheet = books.Open(fileName);
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
           
            dgvStudentLoad.DataSource = null;
            dgvStudentLoad.Columns.Clear();
            dgvStudentLoad.Refresh();

            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files Only | *.xlsx; *.xls";
                ofd.Title = "Choose the Excel File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }

                if (fileName != "")
                {
                    Microsoft.Office.Interop.Excel.Application xlApp;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
                    Microsoft.Office.Interop.Excel.Range xlRange;

                    try
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkbook = xlApp.Workbooks.Open(fileName);
                        xlWorksheet = xlWorkbook.Worksheets["Sheet1"];
                        xlRange = xlWorksheet.UsedRange;

                        dgvStudentLoad.Columns.Add("STUDENT ID", xlRange.Cells[5, 1].Text);
                        dgvStudentLoad.Columns.Add("SCHOOL ID", xlRange.Cells[5, 2].Text);
                        dgvStudentLoad.Columns.Add("STUDENT", xlRange.Cells[5, 3].Text);
                        dgvStudentLoad.Columns.Add("GRADE", xlRange.Cells[5, 4].Text);

                        dgvStudentLoad.ColumnCount = xlRange.Columns.Count;

                        for (int xlrow = 6; xlrow <= xlRange.Rows.Count; xlrow++)
                        {
                            dgvStudentLoad.Rows.Add(xlRange.Cells[xlrow, 1].Text, xlRange.Cells[xlrow, 2].Text, xlRange.Cells[xlrow, 3].Text, xlRange.Cells[xlrow, 4].Text);
                        }

                        xlWorkbook.Close();
                        xlApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
            {
                classID = Class.classID;
                instructorID = loginInstructor.instructorID;
                subjectID = Class.subjectID;

                string studentID = "";
                string schoolID = "";

                if (MessageBox.Show("Are you sure you want to Make Changes", "Make Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //SAVE THE FILE LOCATION
                    if (fileName != "")
                    {
                        var resFile = _context.assignSubjects.Where(q => q.a_classID == classID.ToString() && q.a_subjectID == subjectID.ToString() && q.a_instructorID == instructorID.ToString()).FirstOrDefault();
                        if (resFile != null)
                        {
                            resFile.a_FileLocation = fileName;
                            _context.SaveChanges();
                            MessageBox.Show("Succesfully Making Changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    for (int i = 0; i < dgvStudentLoad.Rows.Count; i++)
                    {
                        studentID = dgvStudentLoad.Rows[i].Cells[0].Value.ToString();
                        schoolID = dgvStudentLoad.Rows[i].Cells[1].Value.ToString();

                        var res = _context.Student_Profile.Where(q => q.StudentID == studentID.ToString() && q.SchoolID == schoolID.ToString() &&
                        q.ClassID == classID.ToString() && q.SubjectID == subjectID.ToString() && q.InstructorID == instructorID.ToString()).FirstOrDefault();

                        if (res != null)
                        {
                            //res.Grade = dgvStudentLoad.Rows[i].Cells[3].Value.ToString();
                            if (string.IsNullOrEmpty(dgvStudentLoad.Rows[i].Cells[3].Value as string))
                            {
                                dgvStudentLoad.Rows[i].Cells[3].Value = " ";
                            }
                            res.Grade = !string.IsNullOrEmpty(dgvStudentLoad.Rows[i].Cells[3].Value.ToString()) ? dgvStudentLoad.Rows[i].Cells[3].Value.ToString() : " "; //0 means empty character
                        }
                    }

                    _context.SaveChanges();
                    loadCurrentData();
                    MessageBox.Show("Succesfully Making Changes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
