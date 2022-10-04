using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports;
using DevExpress.Data.XtraReports;


namespace MechanismsCD.FRMS
{
   
    public partial class FRMRPEMPEMPLOYEES : Form
    {

        DAL.DataAccessLayer db = new DAL.DataAccessLayer();
        public FRMRPEMPEMPLOYEES()
        {
            InitializeComponent();
            
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMRPEMPEMPLOYEES_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Text = Properties.Settings.Default.UserNameLogin;
                CLS_FRMS.RPEMPEMPLOYEES getcbdata = new CLS_FRMS.RPEMPEMPLOYEES();
                getcbdata.cbpreview(cb5);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            //Pnv.Visible = true;
            if(bgwork.IsBusy){label1.Visible = true;}
            else { bgwork.RunWorkerAsync();label1.Visible = false; }
            if (prog.Visible == false) { prog.Visible = true; }
            if (lb1.Visible == false) { lb1.Visible = true; }
            
            
                
            
        }

        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string name = "";
                if (cb5.InvokeRequired)
                {
                    cb5.Invoke(new MethodInvoker(delegate { name = cb5.Text; }));
                }
                string name1 = "";
                int id = 0;
                if (cb1.InvokeRequired)
                {
                    cb1.Invoke(new MethodInvoker(delegate
                    {
                        name1 = cb1.Text;
                        try
                        {
                            id = int.Parse(cb1.SelectedValue.ToString());
                        }
                        catch { }
                    }));
                }
                string name2 = "";
                if (cb2.InvokeRequired)
                {
                    cb2.Invoke(new MethodInvoker(delegate { name2 = cb2.Text; }));
                }
                string Datetime1 = "";
                if (dt1.InvokeRequired)
                {
                    dt1.Invoke(new MethodInvoker(delegate { Datetime1 = dt1.Text; }));
                }
                string Datetime2 = "";
                if (dt2.InvokeRequired)
                {
                    dt2.Invoke(new MethodInvoker(delegate { Datetime2 = dt2.Text; }));
                }
                switch (name)
                {
                    case "تنبيه العقود":
                        CLS_FRMS.RPEMPEMPLOYEES rp = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt = new DataTable();
                        Dt = rp.Emp_ConstractsAttentions();
                        DataTable Dt2 = Dt.Copy();
                        Dt2.Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 100; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2.ImportRow(Dt.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2, cb5);
                            });
                        }
                        break;
                    case "عقود بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt1 = new DataTable();
                        Dt1 = rp1.Emp_ConstractsBetweenTowDate(dt1, dt2);
                        DataTable Cons2 = Dt1.Copy();
                        Cons2.Clear();
                        for (int i = 0; i < Dt1.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Cons2.ImportRow(Dt1.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Cons2, cb5);
                            });
                        }
                        break;
                    case "اعداد الشعب":
                        CLS_FRMS.RPEMPEMPLOYEES GetDivisioncount = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtdivisioncount = new DataTable();
                        Dtdivisioncount = GetDivisioncount.RPEMP_DivisionCounts();
                        DataTable Dt2divisioncount = Dtdivisioncount.Copy();
                        Dt2divisioncount.Clear();
                        for (int i = 0; i < Dtdivisioncount.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2divisioncount.ImportRow(Dtdivisioncount.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2divisioncount, cb5);
                            });
                        }
                        break;
                    case "الاوامر الادارية للمنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetAdministration = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtadministration = new DataTable();
                        Dtadministration = GetAdministration.RPEMP_EmployeeAdministrations(id);
                        DataTable Dt2administration = Dtadministration.Copy();
                        Dt2administration.Clear();
                        for (int i = 0; i < Dtadministration.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2administration.ImportRow(Dtadministration.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2administration, cb5);
                            });
                        }
                        break;
                    case "الاوامر الادارية للمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetAdministration2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtadministration2 = new DataTable();
                        Dtadministration2 = GetAdministration2.RPEMP_EmployeeAdministrations2(id, dt1.Text, dt2.Text);
                        DataTable Dt2administration2 = Dtadministration2.Copy();
                        Dt2administration2.Clear();
                        for (int i = 0; i < Dtadministration2.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2administration2.ImportRow(Dtadministration2.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2administration2, cb5);
                            });
                        }
                        break;
                    case "بيانات اولاد المنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeChildren = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeechildre = new DataTable();
                        Dtemployeechildre = GetEmployeeChildren.RPEMP_EmployeeChildren(name1);
                        DataTable Dt2employeechidren = Dtemployeechildre.Copy();
                        Dt2employeechidren.Clear();
                        for (int i = 0; i < Dtemployeechildre.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeechidren.ImportRow(Dtemployeechildre.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeechidren, cb5);
                            });
                        }
                        break;
                    case "دوريات المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeDawria = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeeDawria = new DataTable();
                        DtemployeeDawria = GetEmployeeDawria.RPEMP_EmployeeDawria();
                        DataTable Dt2employeeDawria = DtemployeeDawria.Copy();
                        Dt2employeeDawria.Clear();
                        for (int i = 0; i < DtemployeeDawria.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeeDawria.ImportRow(DtemployeeDawria.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeeDawria, cb5);
                            });
                        }
                        break;
                    case "دوريات المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeDawria2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeeDawria2 = new DataTable();
                        DtemployeeDawria2 = GetEmployeeDawria2.RPEMP_EmployeeDawriabyDivision(name1);
                        DataTable Dt2employeeDawria2 = DtemployeeDawria2.Copy();
                        Dt2employeeDawria2.Clear();
                        for (int i = 0; i < DtemployeeDawria2.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeeDawria2.ImportRow(DtemployeeDawria2.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeeDawria2, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebydivision = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebydivision = new DataTable();
                        Dtemployeebydivision = GetEmployeebydivision.RPEMP_EmployeesByDivision(name1);
                        DataTable Dt2employeebydivision = Dtemployeebydivision.Copy();
                        Dt2employeebydivision.Clear();
                        for (int i = 0; i < Dtemployeebydivision.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebydivision.ImportRow(Dtemployeebydivision.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebydivision, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebyjob = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebyjob = new DataTable();
                        Dtemployeebyjob = GetEmployeebyjob.RPEMP_EmployeesByJob(name1);
                        DataTable Dt2employeebyjob = Dtemployeebyjob.Copy();
                        Dt2employeebyjob.Clear();
                        for (int i = 0; i < Dtemployeebyjob.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebyjob.ImportRow(Dtemployeebyjob.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebyjob, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب الموقف":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebysit = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebysit = new DataTable();
                        Dtemployeebysit = GetEmployeebysit.RPEMP_EmployeesBySituation(name1);
                        DataTable Dt2employeebysit = Dtemployeebysit.Copy();
                        Dt2employeebysit.Clear();
                        for (int i = 0; i < Dtemployeebysit.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebysit.ImportRow(Dtemployeebysit.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebysit, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebytype = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebytype = new DataTable();
                        Dtemployeebytype = GetEmployeebytype.RPEMP_EmployeesByType(name1);
                        DataTable Dt2employeebytype = Dtemployeebytype.Copy();
                        Dt2employeebytype.Clear();
                        for (int i = 0; i < Dtemployeebytype.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebytype.ImportRow(Dtemployeebytype.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebytype, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebyunit = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebyunit = new DataTable();
                        Dtemployeebyunit = GetEmployeebyunit.RPEMP_EmployeesByUnit(name1);
                        DataTable Dt2employeebyunit = Dtemployeebyunit.Copy();
                        Dt2employeebyunit.Clear();
                        for (int i = 0; i < Dtemployeebyunit.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebyunit.ImportRow(Dtemployeebyunit.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebyunit, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب مكان العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeebyWorkingPlace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeebyWorkingPlace = new DataTable();
                        DtemployeebyWorkingPlace = GetEmployeebyWorkingPlace.RPEMP_WorkingPlace(name1);
                        DataTable Dt2employeebyWorkingPlace = DtemployeebyWorkingPlace.Copy();
                        Dt2employeebyWorkingPlace.Clear();
                        for (int i = 0; i < DtemployeebyWorkingPlace.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2employeebyWorkingPlace.ImportRow(DtemployeebyWorkingPlace.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2employeebyWorkingPlace, cb5);
                            });
                        }
                        break;

                    case "سجل حضور منتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetAttendence = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtAttendence = new DataTable();
                        DtAttendence = GetAttendence.RPEMP_EmployeesnameAttendence(name1, Datetime1, Datetime2);
                        DataTable Dt2Attendence = DtAttendence.Copy();
                        Dt2Attendence.Clear();
                        for (int i = 0; i < DtAttendence.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Attendence.ImportRow(DtAttendence.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Attendence, cb5);
                            });
                        }
                        break;
                    case "سجل الحضور اليومي":
                        CLS_FRMS.RPEMPEMPLOYEES GetAttendence1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtAttendence1 = new DataTable();
                        DtAttendence1 = GetAttendence1.RPEMP_EmployeesnameAttendenceDaily(Datetime1);
                        DataTable Dt2Attendence1 = DtAttendence1.Copy();
                        Dt2Attendence1.Clear();
                        for (int i = 0; i < DtAttendence1.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Attendence1.ImportRow(DtAttendence1.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Attendence1, cb5);
                            });
                        }
                        break;
                    case "الاستضافة والتنسيب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTanseeb = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTanseeb = new DataTable();
                        DtTanseeb = GetTanseeb.RPEMP_EmployeesTanseebTowDate(Datetime1, Datetime2);
                        DataTable Dt2Tanseeb = DtTanseeb.Copy();
                        Dt2Tanseeb.Clear();
                        for (int i = 0; i < DtTanseeb.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Tanseeb.ImportRow(DtTanseeb.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Tanseeb, cb5);
                            });
                        }
                        break;
                    case "الاستضافة والتنسيب لمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTanseeb1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTanseeb1 = new DataTable();
                        DtTanseeb1 = GetTanseeb1.RPEMP_EmployeesTanseeb(name1, Datetime1, Datetime2);
                        DataTable Dt2Tanseeb1 = DtTanseeb1.Copy();
                        Dt2Tanseeb1.Clear();
                        for (int i = 0; i < DtTanseeb1.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Tanseeb1.ImportRow(DtTanseeb1.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Tanseeb1, cb5);
                            });
                        }
                        break;
                    case "وجبة العمل حسب الشعبة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTime = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTime = new DataTable();
                        DtWorkTime = GetWorkTime.RPEMP_EmployeesWorkTime(name1, Datetime1, Datetime2);
                        DataTable Dt2WorkTime = DtWorkTime.Copy();
                        Dt2WorkTime.Clear();
                        for (int i = 0; i < DtWorkTime.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2WorkTime.ImportRow(DtWorkTime.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2WorkTime, cb5);
                            });
                        }
                        break;
                    case "وجبة عمل منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTimeName = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTimeName = new DataTable();
                        DtWorkTimeName = GetWorkTimeName.RPEMP_EmployeesWorkTimeName(name1, Datetime1, Datetime2);
                        DataTable Dt2WorkTimeName = DtWorkTimeName.Copy();
                        Dt2WorkTimeName.Clear();
                        for (int i = 0; i < DtWorkTimeName.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2WorkTimeName.ImportRow(DtWorkTimeName.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2WorkTimeName, cb5);
                            });
                        }
                        break;
                    case "فئة عمل المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkType = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkType = new DataTable();
                        DtWorkType = GetWorkType.RPEMP_EmployeeWorkType();
                        DataTable Dt2WorkType = DtWorkType.Copy();
                        Dt2WorkType.Clear();
                        for (int i = 0; i < DtWorkType.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2WorkType.ImportRow(DtWorkType.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2WorkType, cb5);
                            });
                        }
                        break;
                    case "فئة عمل المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTypeByDivision = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTypeByDivision = new DataTable();
                        DtWorkTypeByDivision = GetWorkTypeByDivision.RPEMP_EmployeeWorkTypeBydivision(name1);
                        DataTable Dt2WorkTypeByDivision = DtWorkTypeByDivision.Copy();
                        Dt2WorkTypeByDivision.Clear();
                        for (int i = 0; i < DtWorkTypeByDivision.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2WorkTypeByDivision.ImportRow(DtWorkTypeByDivision.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2WorkTypeByDivision, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب فئات العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTypeByType = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTypeByType = new DataTable();
                        DtWorkTypeByType = GetWorkTypeByType.RPEMP_EmployeeWorkTypeByType(name1);
                        DataTable Dt2WorkTypeByType = DtWorkTypeByType.Copy();
                        Dt2WorkTypeByType.Clear();
                        for (int i = 0; i < DtWorkTypeByType.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2WorkTypeByType.ImportRow(DtWorkTypeByType.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2WorkTypeByType, cb5);
                            });
                        }
                        break;
                    case "جرد الزمنيات الغير مستقطعة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam = new DataTable();
                        Dtzam = Getzam.RPEMP_EmployeeZamanyiat(dt1.Text, dt2.Text);
                        DataTable Dt2zam = Dtzam.Copy();
                        Dt2zam.Clear();
                        for (int i = 0; i < Dtzam.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2zam.ImportRow(Dtzam.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2zam, cb5);
                            });
                        }
                        break;
                    case "جرد كافة الزمنيات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam1 = new DataTable();
                        Dtzam1 = Getzam1.RPEMP_EmployeeZamanyiatAll(dt1.Text, dt2.Text);
                        DataTable Dt2zam1 = Dtzam1.Copy();
                        Dt2zam1.Clear();
                        for (int i = 0; i < Dtzam1.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2zam1.ImportRow(Dtzam1.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2zam1, cb5);
                            });
                        }
                        break;
                    case "زمنيات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam2 = new DataTable();
                        Dtzam2 = Getzam2.RPEMP_EmployeeZamanyiatbyName(name1, dt1.Text, dt2.Text);
                        DataTable Dt2zam2 = Dtzam2.Copy();
                        Dt2zam2.Clear();
                        for (int i = 0; i < Dtzam2.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2zam2.ImportRow(Dtzam2.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2zam2, cb5);
                            });
                        }
                        break;
                    case "عناوين المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetLiveplace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtLiveplace = new DataTable();
                        DtLiveplace = GetLiveplace.RPEMP_EmployessandLivePlace();
                        DataTable Dt2Liveplace = DtLiveplace.Copy();
                        Dt2Liveplace.Clear();
                        for (int i = 0; i < DtLiveplace.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Liveplace.ImportRow(DtLiveplace.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Liveplace, cb5);
                            });
                        }
                        break;
                    case "ارقام هواتف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetMobile = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtMobile = new DataTable();
                        DtMobile = GetMobile.RPEMP_Employeesandmobile();
                        DataTable Dt2Mobile = DtMobile.Copy();
                        Dt2Mobile.Clear();
                        for (int i = 0; i < DtMobile.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Mobile.ImportRow(DtMobile.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Mobile, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب التحصيل الدراسي":
                        CLS_FRMS.RPEMPEMPLOYEES GetStudy = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtStudy = new DataTable();
                        DtStudy = GetStudy.RPEMP_EmployeesandStduy();
                        DataTable Dt2Study = DtStudy.Copy();
                        Dt2Study.Clear();
                        for (int i = 0; i < DtStudy.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Study.ImportRow(DtStudy.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Study, cb5);
                            });
                        }
                        break;
                    case "ارقام تخاويل المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTaghweel = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTaghweel = new DataTable();
                        DtTaghweel = GetTaghweel.RPEMP_EmployessandTaghweel();
                        DataTable Dt2Taghweel = DtTaghweel.Copy();
                        Dt2Taghweel.Clear();
                        for (int i = 0; i < DtTaghweel.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Taghweel.ImportRow(DtTaghweel.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Taghweel, cb5);
                            });
                        }
                        break;
                    case "بيانات عائلية":
                        CLS_FRMS.RPEMPEMPLOYEES GetFamily = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtFamily = new DataTable();
                        DtFamily = GetFamily.RPEMP_EmployessandTypeandchildren();
                        DataTable Dt2Family = DtFamily.Copy();
                        Dt2Family.Clear();
                        for (int i = 0; i < DtFamily.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Family.ImportRow(DtFamily.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Family, cb5);
                            });
                        }
                        break;
                    case "جرد موقف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetSituation = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSituation = new DataTable();
                        DtSituation = GetSituation.RPEMP_EmpSituation();
                        DataTable Dt2Situation = DtSituation.Copy();
                        Dt2Situation.Clear();
                        for (int i = 0; i < DtSituation.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2Situation.ImportRow(DtSituation.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2Situation, cb5);
                            });
                        }
                        break;
                    case "خلاصة الاعداد حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryJobs = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryJob = new DataTable();
                        DtSummaryJob = GetSummaryJobs.RPEMP_JobsName();
                        DataTable Dt2SummaryJob = DtSummaryJob.Copy();
                        Dt2SummaryJob.Clear();
                        for (int i = 0; i < DtSummaryJob.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2SummaryJob.ImportRow(DtSummaryJob.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2SummaryJob, cb5);
                            });
                        }
                        break;

                    case "خلاصة الاعداد حسب الجهات المستفيدة":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryBeneficiary = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryBeneficiary = new DataTable();
                        DtSummaryBeneficiary = GetSummaryBeneficiary.RPEMP_BeneficiaryCount();
                        DataTable Dt2SummaryBeneficiary = DtSummaryBeneficiary.Copy();
                        Dt2SummaryBeneficiary.Clear();
                        for (int i = 0; i < DtSummaryBeneficiary.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2SummaryBeneficiary.ImportRow(DtSummaryBeneficiary.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2SummaryBeneficiary, cb5);
                            });
                        }
                        break;
                    case "خلاصة الاعداد حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryUnits = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryUnits = new DataTable();
                        DtSummaryUnits = GetSummaryUnits.RPEMP_UnitsCounts();
                        DataTable Dt2SummaryUnits = DtSummaryUnits.Copy();
                        Dt2SummaryUnits.Clear();
                        for (int i = 0; i < DtSummaryUnits.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2SummaryUnits.ImportRow(DtSummaryUnits.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2SummaryUnits, cb5);
                            });
                        }
                        break;
                    case "المتغيرات اليومية العودة":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableComming = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableComming = new DataTable();
                        DtVariableComming = GetVariableComming.RPEMP_VariabelComming();
                        DataTable Dt2VariableComming = DtVariableComming.Copy();
                        Dt2VariableComming.Clear();
                        for (int i = 0; i < DtVariableComming.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2VariableComming.ImportRow(DtVariableComming.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2VariableComming, cb5);
                            });
                        }
                        break;
                    case "متغيرات منتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeVariable = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtEmployeeVariable = new DataTable();
                        DtEmployeeVariable = GetEmployeeVariable.RPEMP_VariabelEmployee(id);
                        DataTable Dt2EmployeeVariable = DtEmployeeVariable.Copy();
                        Dt2EmployeeVariable.Clear();
                        for (int i = 0; i < DtEmployeeVariable.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2EmployeeVariable.ImportRow(DtEmployeeVariable.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2EmployeeVariable, cb5);
                            });
                        }
                        break;
                    case "متغيرات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeVariable1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtEmployeeVariable1 = new DataTable();
                        DtEmployeeVariable1 = GetEmployeeVariable1.RPEMP_VariabelEmployeeTowDate(id, dt1.Text, dt2.Text);
                        DataTable Dt2EmployeeVariable1 = DtEmployeeVariable1.Copy();
                        Dt2EmployeeVariable1.Clear();
                        for (int i = 0; i < DtEmployeeVariable1.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2EmployeeVariable1.ImportRow(DtEmployeeVariable1.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2EmployeeVariable1, cb5);
                            });
                        }
                        break;
                    case "المتغيرات اليومية مجازون":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableGo = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableGo = new DataTable();
                        DtVariableGo = GetVariableGo.RPEMP_VariabelGo();
                        DataTable Dt2VariableGo = DtVariableGo.Copy();
                        Dt2VariableGo.Clear();
                        for (int i = 0; i < DtVariableGo.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2VariableGo.ImportRow(DtVariableGo.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2VariableGo, cb5);
                            });
                        }
                        break;
                    case "المتغيرات اليومية مجازون بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableGoTwoDate = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableGoTwoDate = new DataTable();
                        DtVariableGoTwoDate = GetVariableGoTwoDate.RPEMP_VariabelGoBetweenTwoDates(dt1.Text, dt2.Text);
                        DataTable Dt2VariableGoTwoDate = DtVariableGoTwoDate.Copy();
                        Dt2VariableGoTwoDate.Clear();
                        for (int i = 0; i < DtVariableGoTwoDate.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2VariableGoTwoDate.ImportRow(DtVariableGoTwoDate.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2VariableGoTwoDate, cb5);
                            });
                        }
                        break;
                    case "المنتسبين المنقطعين بدون عودة":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableNotcomming = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableNotcomming = new DataTable();
                        DtVariableNotcomming = GetVariableNotcomming.RPEMP_VariabelNotComming();
                        DataTable Dt2VariableNotcomming = DtVariableNotcomming.Copy();
                        Dt2VariableNotcomming.Clear();
                        for (int i = 0; i < DtVariableNotcomming.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2VariableNotcomming.ImportRow(DtVariableNotcomming.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2VariableNotcomming, cb5);
                            });
                        }
                        break;
                    case "خلاصة حسب اماكن العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryWorkPlace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryWorkPlace = new DataTable();
                        DtSummaryWorkPlace = GetSummaryWorkPlace.RPEMP_WorkPlace();
                        DataTable Dt2SummaryWorkPlace = DtSummaryWorkPlace.Copy();
                        Dt2SummaryWorkPlace.Clear();
                        for (int i = 0; i < DtSummaryWorkPlace.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2SummaryWorkPlace.ImportRow(DtSummaryWorkPlace.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2SummaryWorkPlace, cb5);
                            });
                        }
                        break;
                    case "خلاصة الاعداد حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryTypes = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryTypes = new DataTable();
                        DtSummaryTypes = GetSummaryTypes.RPEMP_TheTypecounts();
                        DataTable Dt2SummaryTypes = DtSummaryTypes.Copy();
                        Dt2SummaryTypes.Clear();
                        for (int i = 0; i < DtSummaryTypes.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2SummaryTypes.ImportRow(DtSummaryTypes.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2SummaryTypes, cb5);
                            });
                        }
                        break;
                    case "جرد المنتسبين حسب الشعبة والوجبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmpByDivAndSheft = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTEmpByDivAndSheft = new DataTable();
                        DTEmpByDivAndSheft = GetEmpByDivAndSheft.RPEMP_EmployeesByDivisionAndSheft(name1, name2);
                        DataTable DT2EmpByDivAndSheft = DTEmpByDivAndSheft.Copy();
                        DT2EmpByDivAndSheft.Clear();
                        for (int i = 0; i < DTEmpByDivAndSheft.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                DT2EmpByDivAndSheft.ImportRow(DTEmpByDivAndSheft.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, DT2EmpByDivAndSheft, cb5);
                            });
                        }
                        break;
                    case "ايفادات حسب الاسم بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByEmpName = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesByEmpName = new DataTable();
                        DtDisputchesByEmpName = GetDisputchesByEmpName.DisputchesByEmpName(name1, Convert.ToDateTime(Datetime1), Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesByEmpName = DtDisputchesByEmpName.Copy();
                        Dt2DisputchesByEmpName.Clear();
                        for (int i = 0; i < DtDisputchesByEmpName.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesByEmpName.ImportRow(DtDisputchesByEmpName.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesByEmpName, cb5);
                            });
                        }
                        break;
                    case "ايفادات حسب الجهة المقصودة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByDistenation = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesByDistenation = new DataTable();
                        DtDisputchesByDistenation = GetDisputchesByDistenation.DisputchesByDistenation(name1, Convert.ToDateTime(Datetime1), Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesByDistenation = DtDisputchesByDistenation.Copy();
                        Dt2DisputchesByDistenation.Clear();
                        for (int i = 0; i < DtDisputchesByDistenation.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesByDistenation.ImportRow(DtDisputchesByDistenation.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesByDistenation, cb5);
                            });
                        }
                        break;
                    case "ايفادات حسب رقم العجلة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByCarNO = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesByCarNO = new DataTable();
                        DtDisputchesByCarNO = GetDisputchesByCarNO.DisputchesByCarNO(name1, Convert.ToDateTime(Datetime1), Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesByCarNO = DtDisputchesByCarNO.Copy();
                        Dt2DisputchesByCarNO.Clear();
                        for (int i = 0; i < DtDisputchesByCarNO.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesByCarNO.ImportRow(DtDisputchesByCarNO.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesByCarNO, cb5);
                            });
                        }
                        break;
                    case "ايفادات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesBetweenTwoDates = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesBetweenTwoDates = new DataTable();
                        DtDisputchesBetweenTwoDates = GetDisputchesBetweenTwoDates.DisputchesBetweenTwoDates(Convert.ToDateTime(Datetime1),Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesBetweenTwoDates = DtDisputchesBetweenTwoDates.Copy();
                        Dt2DisputchesBetweenTwoDates.Clear();
                        for (int i = 0; i < DtDisputchesBetweenTwoDates.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesBetweenTwoDates.ImportRow(DtDisputchesBetweenTwoDates.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesBetweenTwoDates, cb5);
                            });
                        }
                        break;
                    case "جرد حسب حالة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByDisCase = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesByDisCase = new DataTable();
                        DtDisputchesByDisCase = GetDisputchesByDisCase.DisputchesByDisCase(name1, Convert.ToDateTime(Datetime1), Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesByDisCase = DtDisputchesByDisCase.Copy();
                        Dt2DisputchesByDisCase.Clear();
                        for (int i = 0; i < DtDisputchesByDisCase.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesByDisCase.ImportRow(DtDisputchesByDisCase.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesByDisCase, cb5);
                            });
                        }
                        break;
                    case "جرد حسب مرحلة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesCompleteOrNot = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtDisputchesCompleteOrNot = new DataTable();
                        DtDisputchesCompleteOrNot = GetDisputchesCompleteOrNot.DisputchesCompleteOrNot(name1, Convert.ToDateTime(Datetime1), Convert.ToDateTime(Datetime2));
                        DataTable Dt2DisputchesCompleteOrNot = DtDisputchesCompleteOrNot.Copy();
                        Dt2DisputchesCompleteOrNot.Clear();
                        for (int i = 0; i < DtDisputchesCompleteOrNot.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Dt2DisputchesCompleteOrNot.ImportRow(DtDisputchesCompleteOrNot.Rows[i]);
                                CLS_FRMS.RPEMPEMPLOYEES dgv = new CLS_FRMS.RPEMPEMPLOYEES();
                                dgv.Dgvdesign(Dgv, Dt2DisputchesCompleteOrNot, cb5);
                            });
                        }
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (cb5.Text)
                {
                    case "تنبيه العقود":
                        CLS_FRMS.RPEMPEMPLOYEES rp = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt = new DataTable();
                        Dt = rp.Emp_ConstractsAttentions();
                        prog.Maximum = Dt.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "عقود بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt1 = new DataTable();
                        Dt1 = rp1.Emp_ConstractsBetweenTowDate(dt1, dt2);
                        prog.Maximum = Dt1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "اعداد الشعب":
                        CLS_FRMS.RPEMPEMPLOYEES GetDivisioncount = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtdivisioncount = new DataTable();
                        Dtdivisioncount = GetDivisioncount.RPEMP_DivisionCounts();
                        prog.Maximum = Dtdivisioncount.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "الاوامر الادارية للمنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetOrder = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtOrder = new DataTable();
                        DtOrder = GetOrder.RPEMP_EmployeeAdministrations(int.Parse(cb1.SelectedValue.ToString()));
                        prog.Maximum = DtOrder.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "الاوامر الادارية للمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetOrder2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtOrder2 = new DataTable();
                        DtOrder2 = GetOrder2.RPEMP_EmployeeAdministrations2(int.Parse(cb1.SelectedValue.ToString()), dt1.Text, dt2.Text);
                        prog.Maximum = DtOrder2.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "بيانات اولاد المنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeechildren = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeechildren = new DataTable();
                        Dtemployeechildren = Getemployeechildren.RPEMP_EmployeeChildren(cb1.Text);
                        prog.Maximum = Dtemployeechildren.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "دوريات المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetemployeeDawria = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeeDawria = new DataTable();
                        DtemployeeDawria = GetemployeeDawria.RPEMP_EmployeeDawria();
                        prog.Maximum = DtemployeeDawria.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "دوريات المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetemployeeDawria2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeeDawria2 = new DataTable();
                        DtemployeeDawria2 = GetemployeeDawria2.RPEMP_EmployeeDawriabyDivision(cb1.Text);
                        prog.Maximum = DtemployeeDawria2.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeebydivision = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebydivision = new DataTable();
                        Dtemployeebydivision = Getemployeebydivision.RPEMP_EmployeesByDivision(cb1.Text);
                        prog.Maximum = Dtemployeebydivision.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeebyjob = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebyjob = new DataTable();
                        Dtemployeebyjob = Getemployeebyjob.RPEMP_EmployeesByJob(cb1.Text);
                        prog.Maximum = Dtemployeebyjob.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب الموقف":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeebysit = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebysit = new DataTable();
                        Dtemployeebysit = Getemployeebysit.RPEMP_EmployeesBySituation(cb1.Text);
                        prog.Maximum = Dtemployeebysit.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeebytype = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebytype = new DataTable();
                        Dtemployeebytype = Getemployeebytype.RPEMP_EmployeesByType(cb1.Text);
                        prog.Maximum = Dtemployeebytype.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES Getemployeebyunit = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtemployeebyunit = new DataTable();
                        Dtemployeebyunit = Getemployeebyunit.RPEMP_EmployeesByUnit(cb1.Text);
                        prog.Maximum = Dtemployeebyunit.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب مكان العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetemployeebyWorkingPlace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtemployeebyWorkingPlace = new DataTable();
                        DtemployeebyWorkingPlace = GetemployeebyWorkingPlace.RPEMP_WorkingPlace(cb1.Text);
                        prog.Maximum = DtemployeebyWorkingPlace.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;

                    case "سجل حضور منتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetAttendence = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtAttendence = new DataTable();
                        DtAttendence = GetAttendence.RPEMP_EmployeesnameAttendence(cb1.Text, dt1.Text, dt2.Text);
                        prog.Maximum = DtAttendence.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "سجل الحضور اليومي":
                        CLS_FRMS.RPEMPEMPLOYEES GetAttendence1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtAttendence1 = new DataTable();
                        DtAttendence1 = GetAttendence1.RPEMP_EmployeesnameAttendenceDaily(dt1.Text);
                        prog.Maximum = DtAttendence1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "الاستضافة والتنسيب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTanseeb = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTanseeb = new DataTable();
                        DtTanseeb = GetTanseeb.RPEMP_EmployeesTanseebTowDate(dt1.Text, dt2.Text);
                        prog.Maximum = DtTanseeb.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "الاستضافة والتنسيب لمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTanseeb1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTanseeb1 = new DataTable();
                        DtTanseeb1 = GetTanseeb1.RPEMP_EmployeesTanseeb(cb1.Text, dt1.Text, dt2.Text);
                        prog.Maximum = DtTanseeb1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "وجبة العمل حسب الشعبة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTime = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTime = new DataTable();
                        DtWorkTime = GetWorkTime.RPEMP_EmployeesWorkTime(cb1.Text, dt1.Text, dt2.Text);
                        prog.Maximum = DtWorkTime.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "وجبة عمل منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTimeName = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTimeName = new DataTable();
                        DtWorkTimeName = GetWorkTimeName.RPEMP_EmployeesWorkTimeName(cb1.Text, dt1.Text, dt2.Text);
                        prog.Maximum = DtWorkTimeName.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "فئة عمل المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkType = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkType = new DataTable();
                        DtWorkType = GetWorkType.RPEMP_EmployeeWorkType();
                        prog.Maximum = DtWorkType.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "فئة عمل المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTypeByDivision = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTypeByDivision = new DataTable();
                        DtWorkTypeByDivision = GetWorkTypeByDivision.RPEMP_EmployeeWorkTypeBydivision(cb1.Text);
                        prog.Maximum = DtWorkTypeByDivision.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب فئات العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetWorkTypeByType = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkTypeByType = new DataTable();
                        DtWorkTypeByType = GetWorkTypeByType.RPEMP_EmployeeWorkTypeByType(cb1.Text);
                        prog.Maximum = DtWorkTypeByType.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد الزمنيات الغير مستقطعة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam = new DataTable();
                        Dtzam = Getzam.RPEMP_EmployeeZamanyiat(dt1.Text, dt2.Text);
                        prog.Maximum = Dtzam.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد كافة الزمنيات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam1 = new DataTable();
                        Dtzam1 = Getzam1.RPEMP_EmployeeZamanyiatAll(dt1.Text, dt2.Text);
                        prog.Maximum = Dtzam1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "زمنيات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES Getzam2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dtzam2 = new DataTable();
                        Dtzam2 = Getzam2.RPEMP_EmployeeZamanyiatbyName(cb1.Text, dt1.Text, dt2.Text);
                        prog.Maximum = Dtzam2.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "عنوانين المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetLiveplace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtLiveplace = new DataTable();
                        DtLiveplace = GetLiveplace.RPEMP_EmployessandLivePlace();
                        prog.Maximum = DtLiveplace.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ارقام هواتف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetMobile = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtMobile = new DataTable();
                        DtMobile = GetMobile.RPEMP_Employeesandmobile();
                        prog.Maximum = DtMobile.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب التحصيل الدراسي":
                        CLS_FRMS.RPEMPEMPLOYEES GetStudy = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtStudy = new DataTable();
                        DtStudy = GetStudy.RPEMP_EmployeesandStduy();
                        prog.Maximum = DtStudy.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ارقام تخاويل المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetTaghweel = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtTaghweel = new DataTable();
                        DtTaghweel = GetTaghweel.RPEMP_EmployessandTaghweel();
                        prog.Maximum = DtTaghweel.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "بيانات عائلية":
                        CLS_FRMS.RPEMPEMPLOYEES GetFamily = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtFamily = new DataTable();
                        DtFamily = GetFamily.RPEMP_EmployessandTypeandchildren();
                        prog.Maximum = DtFamily.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد موقف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES GetSituation = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSituation = new DataTable();
                        DtSituation = GetSituation.RPEMP_EmpSituation();
                        prog.Maximum = DtSituation.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة الاعداد حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryJobs = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryJobs = new DataTable();
                        DtSummaryJobs = GetSummaryJobs.RPEMP_JobsName();
                        prog.Maximum = DtSummaryJobs.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة الاعداد حسب الجهات المستفيدة":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryBeneficiary = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryBeneficiary = new DataTable();
                        DtSummaryBeneficiary = GetSummaryBeneficiary.RPEMP_BeneficiaryCount();
                        prog.Maximum = DtSummaryBeneficiary.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة الاعداد حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryUnits = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryUnits = new DataTable();
                        DtSummaryUnits = GetSummaryUnits.RPEMP_UnitsCounts();
                        prog.Maximum = DtSummaryUnits.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "المتغيرات اليومية العودة":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableComming = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableComming = new DataTable();
                        DtVariableComming = GetVariableComming.RPEMP_VariabelComming();
                        prog.Maximum = DtVariableComming.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "متغيرات منتسب":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeVariable = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtEmployeeVariable = new DataTable();
                        DtEmployeeVariable = GetEmployeeVariable.RPEMP_VariabelEmployee(int.Parse(cb1.SelectedValue.ToString()));
                        prog.Maximum = DtEmployeeVariable.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "متغيرات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmployeeVariable1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtEmployeeVariable1 = new DataTable();
                        DtEmployeeVariable1 = GetEmployeeVariable1.RPEMP_VariabelEmployeeTowDate(int.Parse(cb1.SelectedValue.ToString()), dt1.Text, dt2.Text);
                        prog.Maximum = DtEmployeeVariable1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "المتغيرات اليومية مجازون":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableGo = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableGo = new DataTable();
                        DtVariableGo = GetVariableGo.RPEMP_VariabelGo();
                        prog.Maximum = DtVariableGo.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "المتغيرات اليومية مجازون بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableGoTwoDate = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableGoTwoDate = new DataTable();
                        DtVariableGoTwoDate = GetVariableGoTwoDate.RPEMP_VariabelGoBetweenTwoDates(dt1.Text, dt2.Text);
                        prog.Maximum = DtVariableGoTwoDate.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "المنتسبين المنقطعين بدون عودة":
                        CLS_FRMS.RPEMPEMPLOYEES GetVariableNotcomming = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtVariableNotcomming = new DataTable();
                        DtVariableNotcomming = GetVariableNotcomming.RPEMP_VariabelNotComming();
                        prog.Maximum = DtVariableNotcomming.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة حسب اماكن العمل":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryWorkPlace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryWorkPlace = new DataTable();
                        DtSummaryWorkPlace = GetSummaryWorkPlace.RPEMP_WorkPlace();
                        prog.Maximum = DtSummaryWorkPlace.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة الاعداد حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES GetSummaryTypes = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtSummaryTypes = new DataTable();
                        DtSummaryTypes = GetSummaryTypes.RPEMP_TheTypecounts();
                        prog.Maximum = DtSummaryTypes.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد المنتسبين حسب الشعبة والوجبة":
                        CLS_FRMS.RPEMPEMPLOYEES GetEmpByDivAndSheft = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTEmpByDivAndSheft = new DataTable();
                        DTEmpByDivAndSheft = GetEmpByDivAndSheft.RPEMP_EmployeesByDivisionAndSheft(cb1.Text, cb2.Text);
                        prog.Maximum = DTEmpByDivAndSheft.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ايفادات حسب الاسم بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByEmpName = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesByEmpName = new DataTable();
                        DTDisputchesByEmpName = GetDisputchesByEmpName.DisputchesByEmpName(cb1.Text, dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesByEmpName.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ايفادات حسب الجهة المقصودة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByDistenation = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesByDistenation = new DataTable();
                        DTDisputchesByDistenation = GetDisputchesByDistenation.DisputchesByDistenation(cb1.Text, dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesByDistenation.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ايفادات حسب رقم العجلة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByCarNO = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesByCarNO = new DataTable();
                        DTDisputchesByCarNO = GetDisputchesByCarNO.DisputchesByCarNO(cb1.Text, dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesByCarNO.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "ايفادات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesBetweenTwoDates = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesBetweenTwoDates = new DataTable();
                        DTDisputchesBetweenTwoDates = GetDisputchesBetweenTwoDates.DisputchesBetweenTwoDates(dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesBetweenTwoDates.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد حسب حالة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesByDisCase = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesByDisCase = new DataTable();
                        DTDisputchesByDisCase = GetDisputchesByDisCase.DisputchesByDisCase(cb1.Text, dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesByDisCase.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "جرد حسب مرحلة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES GetDisputchesCompleteOrNot = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DTDisputchesCompleteOrNot = new DataTable();
                        DTDisputchesCompleteOrNot = GetDisputchesCompleteOrNot.DisputchesCompleteOrNot(cb1.Text, dt1.Value, dt2.Value);
                        prog.Maximum = DTDisputchesCompleteOrNot.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cb5.Text)
                {
                    case "الاوامر الادارية للمنتسب":
                        cb1.DataSource = null;
                        cb1.Items.Clear();
                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        CLS_FRMS.CLSEMPLOYEES GetNames = new CLS_FRMS.CLSEMPLOYEES();
                        DataTable Dt = GetNames.SelectEmployees();
                        cb1.DataSource = Dt;
                        cb1.DisplayMember = "Emp_EmployeeName";
                        cb1.ValueMember = "Emp_ID";
                        break;
                    case "الاوامر الادارية للمنتسب بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSEMPLOYEES GetNames1 = new CLS_FRMS.CLSEMPLOYEES();
                        DataTable Dt1 = GetNames1.SelectEmployees();
                        cb1.DataSource = Dt1;
                        cb1.DisplayMember = "Emp_EmployeeName";
                        cb1.ValueMember = "Emp_ID";
                        break;
                    case "بيانات اولاد المنتسب":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNames2 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt2 = GetNames2.GetnameEmployees();
                        for (int i = 0; i < Dt2.Rows.Count; i++) { cb1.Items.Add(Dt2.Rows[i][0].ToString()); }
                        break;
                    case "دوريات المنتسبين حسب الشعبة":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الشعبة";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesDivision = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt3 = GetNamesDivision.DivisionsNameGettingData();
                        for (int i = 0; i < Dt3.Rows.Count; i++) { cb1.Items.Add(Dt3.Rows[i][1].ToString()); }
                        break;
                    case "جرد المنتسبين حسب الشعبة":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الشعبة";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesDivision2 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt4 = GetNamesDivision2.DivisionsNameGettingData();
                        for (int i = 0; i < Dt4.Rows.Count; i++) { cb1.Items.Add(Dt4.Rows[i][1].ToString()); }
                        break;
                    case "جرد المنتسبين حسب العنوان الوظيفي":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل العنوان الوظيفي";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesofJobs = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt5 = GetNamesofJobs.JobsNamesGettingdata();
                        for (int i = 0; i < Dt5.Rows.Count; i++) { cb1.Items.Add(Dt5.Rows[i][1].ToString()); }
                        break;
                    case "جرد المنتسبين حسب الموقف":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الموقف";
                        cb1.Items.Clear();
                        string[] str2 = new string[11];
                        str2[0] = "لاشيء"; str2[1] = "استضافة"; str2[2] = "تنسيب"; str2[3] = "تفريغ"; str2[4] = "نقل خدمات"; str2[5] = "انهاء خدمات";
                        str2[6] = "انهاء عقد"; str2[7] = "انهاء اجور يومية"; str2[8] = "استقالة"; str2[9] = "متقاعد"; str2[10] = "متوفي";
                        cb1.Items.AddRange(str2);
                        break;
                    case "جرد المنتسبين حسب الحالة":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الحالة";
                        cb1.Items.Clear();
                        string[] str3 = new string[6];
                        str3[0] = "اجازة طويلة"; str3[1] = "انهاء خدمات"; str3[2] = "تعيين";
                        str3[3] = "خارجي"; str3[4] = "عقد"; str3[5] = "نظام المكافأة";
                        cb1.Items.AddRange(str3);
                        break;
                    case "جرد المنتسبين حسب الوحدات":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الوحدة";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesofUnit = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt6 = GetNamesofUnit.UnitsNamesGettingdata();
                        for (int i = 0; i < Dt6.Rows.Count; i++) { cb1.Items.Add(Dt6.Rows[i][1].ToString()); }
                        break;
                    case "جرد المنتسبين حسب مكان العمل":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل مكان العمل";
                        cb1.Items.Clear();
                        CLS_FRMS.RPEMPEMPLOYEES GetNamesofWorkingplace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkingPlace = GetNamesofWorkingplace.WorkingPlaceGetData();
                        for (int i = 0; i < DtWorkingPlace.Rows.Count; i++) { cb1.Items.Add(DtWorkingPlace.Rows[i][0].ToString()); }
                        break;

                    case "سجل حضور منتسب":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNames3 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt7 = GetNames3.GetnameEmployees();
                        for (int i = 0; i < Dt7.Rows.Count; i++) { cb1.Items.Add(Dt7.Rows[i][0].ToString()); }
                        break;
                    case "الاستضافة والتنسيب لمنتسب بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNames4 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt8 = GetNames4.GetnameEmployees();
                        for (int i = 0; i < Dt8.Rows.Count; i++) { cb1.Items.Add(Dt8.Rows[i][0].ToString()); }
                        break;
                    case "وجبة العمل حسب الشعبة بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الشعبة";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesDivision3 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt9 = GetNamesDivision3.DivisionsNameGettingData();
                        for (int i = 0; i < Dt9.Rows.Count; i++) { cb1.Items.Add(Dt9.Rows[i][1].ToString()); }
                        break;
                    case "وجبة عمل منتسب بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNames5 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt10 = GetNames5.GetnameEmployees();
                        for (int i = 0; i < Dt10.Rows.Count; i++) { cb1.Items.Add(Dt10.Rows[i][0].ToString()); }
                        break;
                    case "فئة عمل المنتسبين حسب الشعبة":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الشعبة";
                        cb1.Items.Clear();
                        CLS_FRMS.CLSCONSTENTRY GetNamesDivision4 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt11 = GetNamesDivision4.DivisionsNameGettingData();
                        for (int i = 0; i < Dt11.Rows.Count; i++) { cb1.Items.Add(Dt11.Rows[i][1].ToString()); }
                        break;
                    case "جرد المنتسبين حسب فئات العمل":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل فئة العمل";
                        cb1.Items.Clear();
                        string[] str = new string[4];
                        str[0] = "A"; str[1] = "B"; str[2] = "C"; str[3] = "D";
                        cb1.Items.AddRange(str);
                        break;
                    case "زمنيات منتسب بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        CLS_FRMS.CLSCONSTENTRY GetNames6 = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable Dt12 = GetNames6.GetnameEmployees();
                        for (int i = 0; i < Dt12.Rows.Count; i++) { cb1.Items.Add(Dt12.Rows[i][0].ToString()); }
                        break;
                    case "متغيرات منتسب":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        CLS_FRMS.CLSEMPLOYEES GetNames7 = new CLS_FRMS.CLSEMPLOYEES();
                        DataTable Dt13 = GetNames7.SelectEmployees();
                        cb1.DataSource = Dt13;
                        cb1.DisplayMember = "Emp_EmployeeName";
                        cb1.ValueMember = "Emp_ID";
                        break;
                    case "متغيرات منتسب بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        CLS_FRMS.CLSEMPLOYEES GetNames8 = new CLS_FRMS.CLSEMPLOYEES();
                        DataTable Dt14 = GetNames8.SelectEmployees();
                        cb1.DataSource = Dt14;
                        cb1.DisplayMember = "Emp_EmployeeName";
                        cb1.ValueMember = "Emp_ID";
                        break;
                    case "المتغيرات اليومية مجازون":
                    case "المتغيرات اليومية مجازون بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اليوم";
                        cb2.BackColor = Color.Red; cb2.Text = "اكتب اسم المنظم";
                        string[] strday = new string[7];
                        strday[0] = "الاحد"; strday[1] = "الاثنين"; strday[2] = "الثلاثاء"; strday[3] = "الاربعاء";
                        strday[4] = "الخميس"; strday[5] = "الجمعة"; strday[6] = "السبت";
                        cb1.Items.Clear();
                        cb1.Items.AddRange(strday);
                        cb2.Items.Clear();

                        break;
                    case "جرد المنتسبين حسب الشعبة والوجبة":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل الشعبة";
                        cb2.BackColor = Color.Red; cb2.Text = "ادخل الوجبة";
                        cb1.Items.Clear();
                        cb1.Items.Add(Properties.Settings.Default.ServerName);
                        cb1.Items.Add(Properties.Settings.Default.ServerName1);
                        cb1.Items.Add(Properties.Settings.Default.ServerName2);
                        cb1.Items.Add(Properties.Settings.Default.ServerName3);
                        cb2.Items.Clear();
                        cb2.Items.Add("الوجبة الصباحية");
                        cb2.Items.Add("الوجبة المسائية");
                        cb2.Items.Add("الوجبة الليلية");
                        break;
                    case "ايفادات حسب الاسم بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                        CLS_FRMS.CLSEMPLOYEES GetNamesDis = new CLS_FRMS.CLSEMPLOYEES();
                        DataTable DtNameDis = GetNamesDis.SelectEmployees();
                        cb1.DataSource = DtNameDis;
                        cb1.DisplayMember = "Emp_EmployeeName";
                        break;
                    case "ايفادات حسب الجهة المقصودة بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل الجهة المقصودة";
                        CLS_FRMS.CLSCONSTENTRY GetDistenationDis = new CLS_FRMS.CLSCONSTENTRY();
                        DataTable DtDistenationDis = GetDistenationDis.DistenationSelecting();
                        cb1.DataSource = DtDistenationDis;
                        cb1.DisplayMember = "الجهة المقصودة";
                        break;
                    case "ايفادات حسب رقم العجلة بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل الجهة المقصودة";
                        CLS_FRMS.CLSCARS GetcarDis = new CLS_FRMS.CLSCARS();
                        DataTable DtcarDis = GetcarDis.CarDivisionGetDate();
                        cb1.DataSource = DtcarDis;
                        cb1.DisplayMember = "رقم العجلة";
                        break;
                    case "جرد حسب حالة الايفاد بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "ادخل حالة الايفاد";
                        string[] r3 = new string[4];
                        r3[0] = "تم الصرف"; r3[1] = "لم يصرف"; r3[2] = "تم الرفع من الشعبة"; r3[3] = "لم يرفع من الشعبة";
                        cb1.Items.Clear();
                        cb1.Items.AddRange(r3);

                        break;
                    case "جرد حسب مرحلة الايفاد بين تاريخين":
                        cb1.DataSource = null;

                        cb1.BackColor = Color.Red; cb1.Text = "مكتمل / غير مكتمل";
                        string[] r4 = new string[2];
                        r4[0] = "مكتمل"; r4[1] = "غير مكتمل";
                        cb1.Items.Clear();
                        cb1.Items.AddRange(r4);

                        break;

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //=========================

       
       
      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cb5.Text)
                {
                    case "تنبيه العقود":
                        CLS_FRMS.RPEMPEMPLOYEES rp = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt = new DataTable();
                        Dt = rp.Emp_ConstractsAttentions();
                        DS.DataSetMechanisms dss = new DS.DataSetMechanisms();
                        dss.Tables["EmpConstracts"].Clear();

                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dss.Tables["EmpConstracts"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                        }

                        REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                        REPORTS.ConstracAttention rpt = new REPORTS.ConstracAttention();

                        rpt.Parameters["CountRecord"].Value = Dt.Rows.Count;
                        rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }


                        rpt.DataSource = dss;
                        rpt.RequestParameters = false;
                        frm.documentViewer1.DocumentSource = rpt;
                        frm.ShowDialog();
                        break;
                    case "عقود بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp1 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt1 = new DataTable();
                        Dt1 = rp1.Emp_ConstractsBetweenTowDate(dt1, dt2);
                        DS.DataSetMechanisms DsConstractTowDate = new DS.DataSetMechanisms();
                        DsConstractTowDate.Tables["ConstractsTowDate"].Clear();

                        for (int i = 0; i < Dt1.Rows.Count; i++)
                        {
                            DsConstractTowDate.Tables["ConstractsTowDate"].Rows.Add(Dt1.Rows[i][0], Dt1.Rows[i][1],
                                Dt1.Rows[i][2], Dt1.Rows[i][3], Dt1.Rows[i][4], Dt1.Rows[i][5], Dt1.Rows[i][6],
                                Dt1.Rows[i][7]);
                        }

                        REPORTS.ReportsViewer frm2 = new REPORTS.ReportsViewer();
                        REPORTS.ConstractsBetweenTowDate rpt1 = new REPORTS.ConstractsBetweenTowDate();

                        rpt1.Parameters["CountRecord"].Value = Dt1.Rows.Count;
                        rpt1.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt1.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt1.Parameters["FromDate"].Value = dt1.Value;
                        rpt1.Parameters["ToDate"].Value = dt2.Value;




                        for (int i = 0; i < rpt1.Parameters.Count; i++)
                        {
                            rpt1.Parameters[i].Visible = false;
                        }

                        rpt1.DataSource = DsConstractTowDate;
                        rpt1.RequestParameters = false;
                        frm2.documentViewer1.DocumentSource = rpt1;
                        frm2.ShowDialog();
                        break;
                    case "اعداد الشعب":
                        CLS_FRMS.RPEMPEMPLOYEES rp2 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt2 = new DataTable();
                        Dt2 = rp2.RPEMP_DivisionCounts();
                        DS.DataSetMechanisms DsDivisionCounts = new DS.DataSetMechanisms();
                        DsDivisionCounts.Tables["DivisionCount"].Clear();

                        for (int i = 0; i < Dt2.Rows.Count; i++)
                        {
                            DsDivisionCounts.Tables["DivisionCount"].Rows.Add(Dt2.Rows[i][0], Dt2.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm3 = new REPORTS.ReportsViewer();
                        REPORTS.DivisionCount rpt2 = new REPORTS.DivisionCount();
                        int sum = 0;
                        for (int i = 0; i < Dt2.Rows.Count; i++)
                        {
                            sum = sum + int.Parse(Dt2.Rows[i][1].ToString());
                        }
                        rpt2.Parameters["DivisionCounts"].Value = Dt2.Rows.Count;
                        rpt2.Parameters["EmpCounts"].Value = sum;
                        rpt2.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt2.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();



                        for (int i = 0; i < rpt2.Parameters.Count; i++)
                        {
                            rpt2.Parameters[i].Visible = false;
                        }

                        rpt2.DataSource = DsDivisionCounts;
                        rpt2.RequestParameters = false;
                        frm3.documentViewer1.DocumentSource = rpt2;
                        frm3.ShowDialog();
                        break;
                    case "خلاصة الاعداد حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES rp3 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt3 = new DataTable();
                        Dt3 = rp3.RPEMP_UnitsCounts();
                        DS.DataSetMechanisms DsUnitsCounts = new DS.DataSetMechanisms();
                        DsUnitsCounts.Tables["UnitsCount"].Clear();

                        for (int i = 0; i < Dt3.Rows.Count; i++)
                        {
                            DsUnitsCounts.Tables["UnitsCount"].Rows.Add(Dt3.Rows[i][0], Dt3.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm4 = new REPORTS.ReportsViewer();
                        REPORTS.UnitsCount rpt3 = new REPORTS.UnitsCount();
                        int sumEmpUnits = 0;
                        for (int i = 0; i < Dt3.Rows.Count; i++)
                        {
                            sumEmpUnits = sumEmpUnits + int.Parse(Dt3.Rows[i][1].ToString());
                        }
                        rpt3.Parameters["UnitsCounts"].Value = Dt3.Rows.Count;
                        rpt3.Parameters["EmpCounts"].Value = sumEmpUnits;
                        rpt3.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt3.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();



                        for (int i = 0; i < rpt3.Parameters.Count; i++)
                        {
                            rpt3.Parameters[i].Visible = false;
                        }

                        rpt3.DataSource = DsUnitsCounts;
                        rpt3.RequestParameters = false;
                        frm4.documentViewer1.DocumentSource = rpt3;
                        frm4.ShowDialog();
                        break;
                    case "الاوامر الادارية للمنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES rp4 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt4 = new DataTable();
                        Dt4 = rp4.RPEMP_EmployeeAdministrations(int.Parse(cb1.SelectedValue.ToString()));
                        DS.DataSetMechanisms DsEmpAdmin = new DS.DataSetMechanisms();
                        DsEmpAdmin.Tables["EmployeesAdministration"].Clear();

                        for (int i = 0; i < Dt4.Rows.Count; i++)
                        {
                            DsEmpAdmin.Tables["EmployeesAdministration"].Rows.Add(Dt4.Rows[i][0], Dt4.Rows[i][1],
                                Dt4.Rows[i][2], Dt4.Rows[i][3], Dt4.Rows[i][4], Dt4.Rows[i][5]);
                        }

                        REPORTS.ReportsViewer frm5 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesAdministrations rpt4 = new REPORTS.EmployeesAdministrations();

                        rpt4.Parameters["EmpName"].Value = cb1.Text;

                        rpt4.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt4.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();

                        for (int i = 0; i < rpt4.Parameters.Count; i++)
                        {
                            rpt4.Parameters[i].Visible = false;
                        }

                        rpt4.DataSource = DsEmpAdmin;
                        rpt4.RequestParameters = false;
                        frm5.documentViewer1.DocumentSource = rpt4;
                        frm5.ShowDialog();
                        break;
                    case "الاوامر الادارية للمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp5 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt5 = new DataTable();
                        Dt5 = rp5.RPEMP_EmployeeAdministrations2(int.Parse(cb1.SelectedValue.ToString()), dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsEmpAdmin2 = new DS.DataSetMechanisms();
                        DsEmpAdmin2.Tables["EmployeesAdministration"].Clear();

                        for (int i = 0; i < Dt5.Rows.Count; i++)
                        {
                            DsEmpAdmin2.Tables["EmployeesAdministration"].Rows.Add(Dt5.Rows[i][0], Dt5.Rows[i][1],
                                Dt5.Rows[i][2], Dt5.Rows[i][3], Dt5.Rows[i][4], Dt5.Rows[i][5]);
                        }

                        REPORTS.ReportsViewer frm6 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesAdministrations2 rpt5 = new REPORTS.EmployeesAdministrations2();

                        rpt5.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt5.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt5.Parameters["FromDate"].Value = dt1.Value;
                        rpt5.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt5.Parameters.Count; i++)
                        {
                            rpt5.Parameters[i].Visible = false;
                        }

                        rpt5.DataSource = DsEmpAdmin2;
                        rpt5.RequestParameters = false;
                        frm6.documentViewer1.DocumentSource = rpt5;
                        frm6.ShowDialog();
                        break;
                    case "بيانات اولاد المنتسب":
                        CLS_FRMS.RPEMPEMPLOYEES rp6 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt6 = new DataTable();
                        Dt6 = rp6.RPEMP_EmployeeChildren(cb1.Text);
                        DS.DataSetMechanisms DsEmpChildren = new DS.DataSetMechanisms();
                        DsEmpChildren.Tables["EmployeeChildren"].Clear();

                        for (int i = 0; i < Dt6.Rows.Count; i++)
                        {
                            DsEmpChildren.Tables["EmployeeChildren"].Rows.Add(Dt6.Rows[i][0], Dt6.Rows[i][1],
                                Dt6.Rows[i][2], Dt6.Rows[i][3], Dt6.Rows[i][4], Dt6.Rows[i][5], Dt6.Rows[i][6]);
                        }

                        REPORTS.ReportsViewer frm7 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesChildren rpt6 = new REPORTS.EmployeesChildren();

                        rpt6.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt6.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt6.Parameters["FromDate"].Value = dt1.Value;
                        rpt6.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt6.Parameters.Count; i++)
                        {
                            rpt6.Parameters[i].Visible = false;
                        }

                        rpt6.DataSource = DsEmpChildren;
                        rpt6.RequestParameters = false;
                        frm7.documentViewer1.DocumentSource = rpt6;
                        frm7.ShowDialog();
                        break;
                    case "دوريات المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES rp7 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt7 = new DataTable();
                        Dt7 = rp7.RPEMP_EmployeeDawria();
                        DS.DataSetMechanisms DsEmpHolyday = new DS.DataSetMechanisms();
                        DsEmpHolyday.Tables["EmployeesHolyDay"].Clear();

                        for (int i = 0; i < Dt7.Rows.Count; i++)
                        {
                            DsEmpHolyday.Tables["EmployeesHolyDay"].Rows.Add(Dt7.Rows[i][0], Dt7.Rows[i][1]);
                        }

                        REPORTS.ReportsViewer frm8 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesHolyday rpt7 = new REPORTS.EmployeesHolyday();

                        rpt7.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt7.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt7.Parameters["EmpCounts"].Value = Dt7.Rows.Count;


                        for (int i = 0; i < rpt7.Parameters.Count; i++)
                        {
                            rpt7.Parameters[i].Visible = false;
                        }

                        rpt7.DataSource = DsEmpHolyday;
                        rpt7.RequestParameters = false;
                        frm8.documentViewer1.DocumentSource = rpt7;
                        frm8.ShowDialog();
                        break;
                    case "دوريات المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES rp8 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt8 = new DataTable();
                        Dt8 = rp8.RPEMP_EmployeeDawriabyDivision(cb1.Text);
                        DS.DataSetMechanisms DsEmpHolydayByDivision = new DS.DataSetMechanisms();
                        DsEmpHolydayByDivision.Tables["EmployeesHolyDay"].Clear();

                        for (int i = 0; i < Dt8.Rows.Count; i++)
                        {
                            DsEmpHolydayByDivision.Tables["EmployeesHolyDay"].Rows.Add(Dt8.Rows[i][0], Dt8.Rows[i][1]);
                        }

                        REPORTS.ReportsViewer frm9 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesHolydayByDivision rpt8 = new REPORTS.EmployeesHolydayByDivision();

                        rpt8.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt8.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt8.Parameters["EmpCounts"].Value = Dt8.Rows.Count;
                        rpt8.LbDivision.Text = cb1.Text;

                        for (int i = 0; i < rpt8.Parameters.Count; i++)
                        {
                            rpt8.Parameters[i].Visible = false;
                        }

                        rpt8.DataSource = DsEmpHolydayByDivision;
                        rpt8.RequestParameters = false;
                        frm9.documentViewer1.DocumentSource = rpt8;
                        frm9.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب الشعبة":
                        CLS_FRMS.RPEMPEMPLOYEES rp9 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt9 = new DataTable();
                        Dt9 = rp9.RPEMP_EmployeesByDivision(cb1.Text);
                        DS.DataSetMechanisms DsEmpDivision = new DS.DataSetMechanisms();
                        DsEmpDivision.Tables["EmployeesByDivision"].Clear();

                        for (int i = 0; i < Dt9.Rows.Count; i++)
                        {
                            DsEmpDivision.Tables["EmployeesByDivision"].Rows.Add(Dt9.Rows[i][0], Dt9.Rows[i][2],
                                Dt9.Rows[i][3], Dt9.Rows[i][4]);
                        }

                        REPORTS.ReportsViewer frm10 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesByDivision rpt9 = new REPORTS.EmployeesByDivision();

                        rpt9.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt9.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt9.Parameters["EmpCounts"].Value = Dt9.Rows.Count;
                        rpt9.LbDivision.Text = cb1.Text;


                        for (int i = 0; i < rpt9.Parameters.Count; i++)
                        {
                            rpt9.Parameters[i].Visible = false;
                        }

                        rpt9.DataSource = DsEmpDivision;
                        rpt9.RequestParameters = false;
                        frm10.documentViewer1.DocumentSource = rpt9;
                        frm10.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES rp10 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt10 = new DataTable();
                        Dt10 = rp10.RPEMP_EmployeesByJob(cb1.Text);
                        DS.DataSetMechanisms DsEmpJob = new DS.DataSetMechanisms();
                        DsEmpJob.Tables["EmployeesByJob"].Clear();

                        for (int i = 0; i < Dt10.Rows.Count; i++)
                        {
                            DsEmpJob.Tables["EmployeesByJob"].Rows.Add(Dt10.Rows[i][0], Dt10.Rows[i][1],
                                Dt10.Rows[i][2], Dt10.Rows[i][3]);
                        }

                        REPORTS.ReportsViewer frm11 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesByJob rpt10 = new REPORTS.EmployeesByJob();

                        rpt10.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt10.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt10.Parameters["EmpCounts"].Value = Dt10.Rows.Count;
                        rpt10.LbDivision.Text = cb1.Text;


                        for (int i = 0; i < rpt10.Parameters.Count; i++)
                        {
                            rpt10.Parameters[i].Visible = false;
                        }

                        rpt10.DataSource = DsEmpJob;
                        rpt10.RequestParameters = false;
                        frm11.documentViewer1.DocumentSource = rpt10;
                        frm11.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب الموقف":
                        CLS_FRMS.RPEMPEMPLOYEES rp11 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt11 = new DataTable();
                        Dt11 = rp11.RPEMP_EmployeesBySituation(cb1.Text);
                        DS.DataSetMechanisms DsEmpBySitu = new DS.DataSetMechanisms();
                        DsEmpBySitu.Tables["EmployeesBySitu"].Clear();

                        for (int i = 0; i < Dt11.Rows.Count; i++)
                        {
                            DsEmpBySitu.Tables["EmployeesBySitu"].Rows.Add(Dt11.Rows[i][0], Dt11.Rows[i][2]);
                        }

                        REPORTS.ReportsViewer frm12 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesBySitu rpt11 = new REPORTS.EmployeesBySitu();

                        rpt11.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt11.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt11.Parameters["EmpCounts"].Value = Dt11.Rows.Count;
                        rpt11.LbSitu.Text = cb1.Text;

                        for (int i = 0; i < rpt11.Parameters.Count; i++)
                        {
                            rpt11.Parameters[i].Visible = false;
                        }

                        rpt11.DataSource = DsEmpBySitu;
                        rpt11.RequestParameters = false;
                        frm12.documentViewer1.DocumentSource = rpt11;
                        frm12.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES rp12 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt12 = new DataTable();
                        Dt12 = rp12.RPEMP_EmployeesByType(cb1.Text);
                        DS.DataSetMechanisms DsEmpByType = new DS.DataSetMechanisms();
                        DsEmpByType.Tables["EmployeesByType"].Clear();

                        for (int i = 0; i < Dt12.Rows.Count; i++)
                        {
                            DsEmpByType.Tables["EmployeesByType"].Rows.Add(Dt12.Rows[i][0], Dt12.Rows[i][2],
                               Dt12.Rows[i][3], Dt12.Rows[i][4]);
                        }

                        REPORTS.ReportsViewer frm13 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesByType rpt12 = new REPORTS.EmployeesByType();

                        rpt12.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt12.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt12.Parameters["EmpCounts"].Value = Dt12.Rows.Count;
                        rpt12.LbType.Text = cb1.Text;

                        for (int i = 0; i < rpt12.Parameters.Count; i++)
                        {
                            rpt12.Parameters[i].Visible = false;
                        }

                        rpt12.DataSource = DsEmpByType;
                        rpt12.RequestParameters = false;
                        frm13.documentViewer1.DocumentSource = rpt12;
                        frm13.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب الوحدات":
                        CLS_FRMS.RPEMPEMPLOYEES rp13 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt13 = new DataTable();
                        Dt13 = rp13.RPEMP_EmployeesByUnit(cb1.Text);
                        DS.DataSetMechanisms DsEmpByUnit = new DS.DataSetMechanisms();
                        DsEmpByUnit.Tables["EmployeesByUnit"].Clear();

                        for (int i = 0; i < Dt13.Rows.Count; i++)
                        {
                            DsEmpByUnit.Tables["EmployeesByUnit"].Rows.Add(Dt13.Rows[i][0], Dt13.Rows[i][2],
                               Dt13.Rows[i][3]);
                        }

                        REPORTS.ReportsViewer frm14 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesByUnit rpt13 = new REPORTS.EmployeesByUnit();

                        rpt13.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt13.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt13.Parameters["EmpCounts"].Value = Dt13.Rows.Count;
                        rpt13.LbUnit.Text = cb1.Text;

                        for (int i = 0; i < rpt13.Parameters.Count; i++)
                        {
                            rpt13.Parameters[i].Visible = false;
                        }

                        rpt13.DataSource = DsEmpByUnit;
                        rpt13.RequestParameters = false;
                        frm14.documentViewer1.DocumentSource = rpt13;
                        frm14.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب مكان العمل":
                        CLS_FRMS.RPEMPEMPLOYEES rpWorkingPlace = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable DtWorkingPlace = new DataTable();
                        DtWorkingPlace = rpWorkingPlace.RPEMP_WorkingPlace(cb1.Text);
                        DS.DataSetMechanisms DsEmpByWorkingPlace = new DS.DataSetMechanisms();
                        DsEmpByWorkingPlace.Tables["EmpByWorkingPlace"].Clear();

                        for (int i = 0; i < DtWorkingPlace.Rows.Count; i++)
                        {
                            DsEmpByWorkingPlace.Tables["EmpByWorkingPlace"].Rows.Add(DtWorkingPlace.Rows[i][0], DtWorkingPlace.Rows[i][1],
                               DtWorkingPlace.Rows[i][2], DtWorkingPlace.Rows[i][3], i + 1);
                        }

                        REPORTS.ReportsViewer frmWorkingPlace = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesByWorkingPlace rptWorkingPlace = new REPORTS.EmployeesByWorkingPlace();

                        rptWorkingPlace.Parameters["RpType"].Value = cb5.SelectedItem + "\n مكان العمل: " + cb1.Text;
                        rptWorkingPlace.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rptWorkingPlace.Parameters["Count"].Value = DtWorkingPlace.Rows.Count;


                        for (int i = 0; i < rptWorkingPlace.Parameters.Count; i++)
                        {
                            rptWorkingPlace.Parameters[i].Visible = false;
                        }

                        rptWorkingPlace.DataSource = DsEmpByWorkingPlace;
                        rptWorkingPlace.RequestParameters = false;
                        frmWorkingPlace.documentViewer1.DocumentSource = rptWorkingPlace;
                        frmWorkingPlace.ShowDialog();
                        break;

                    case "الاستضافة والتنسيب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp14 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt14 = new DataTable();
                        Dt14 = rp14.RPEMP_EmployeesTanseebTowDate(dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsTanseeb1 = new DS.DataSetMechanisms();
                        DsTanseeb1.Tables["Tanseeb1"].Clear();

                        for (int i = 0; i < Dt14.Rows.Count; i++)
                        {
                            DsTanseeb1.Tables["Tanseeb1"].Rows.Add(Dt14.Rows[i][0], Dt14.Rows[i][1],
                               Dt14.Rows[i][2], Dt14.Rows[i][3], Dt14.Rows[i][4]);
                        }

                        REPORTS.ReportsViewer frm15 = new REPORTS.ReportsViewer();
                        REPORTS.Tanseeb1 rpt14 = new REPORTS.Tanseeb1();

                        rpt14.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt14.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt14.Parameters["EmpCount"].Value = Dt14.Rows.Count;
                        rpt14.Parameters["FromDate"].Value = dt1.Value;
                        rpt14.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt14.Parameters.Count; i++)
                        {
                            rpt14.Parameters[i].Visible = false;
                        }

                        rpt14.DataSource = DsTanseeb1;
                        rpt14.RequestParameters = false;
                        frm15.documentViewer1.DocumentSource = rpt14;
                        frm15.ShowDialog();
                        break;
                    case "الاستضافة والتنسيب لمنتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp15 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt15 = new DataTable();
                        Dt15 = rp15.RPEMP_EmployeesTanseeb(cb1.Text, dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsTanseeb2 = new DS.DataSetMechanisms();
                        DsTanseeb2.Tables["Tanseeb1"].Clear();

                        for (int i = 0; i < Dt15.Rows.Count; i++)
                        {
                            DsTanseeb2.Tables["Tanseeb1"].Rows.Add(Dt15.Rows[i][0], Dt15.Rows[i][1],
                               Dt15.Rows[i][2], Dt15.Rows[i][3], Dt15.Rows[i][4]);
                        }

                        REPORTS.ReportsViewer frm16 = new REPORTS.ReportsViewer();
                        REPORTS.Tanseeb2 rpt15 = new REPORTS.Tanseeb2();

                        rpt15.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt15.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt15.Parameters["FromDate"].Value = dt1.Value;
                        rpt15.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt15.Parameters.Count; i++)
                        {
                            rpt15.Parameters[i].Visible = false;
                        }

                        rpt15.DataSource = DsTanseeb2;
                        rpt15.RequestParameters = false;
                        frm16.documentViewer1.DocumentSource = rpt15;
                        frm16.ShowDialog();
                        break;
                    case "وجبة العمل حسب الشعبة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp16 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt16 = new DataTable();
                        Dt16 = rp16.RPEMP_EmployeesWorkTime(cb1.Text, dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsWorkTime = new DS.DataSetMechanisms();
                        DsWorkTime.Tables["EmployeeWorkTime"].Clear();

                        for (int i = 0; i < Dt16.Rows.Count; i++)
                        {
                            DsWorkTime.Tables["EmployeeWorkTime"].Rows.Add(Dt16.Rows[i][0], Dt16.Rows[i][1],
                               Dt16.Rows[i][2], Dt16.Rows[i][3]);
                        }

                        REPORTS.ReportsViewer frm17 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeeWorkTime rpt16 = new REPORTS.EmployeeWorkTime();

                        rpt16.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt16.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt16.Parameters["FromDate"].Value = dt1.Value;
                        rpt16.Parameters["ToDate"].Value = dt2.Value;
                        rpt16.LbDivisionName.Text = cb1.Text;
                        rpt16.Parameters["EmpCounts"].Value = Dt16.Rows.Count;

                        for (int i = 0; i < rpt16.Parameters.Count; i++)
                        {
                            rpt16.Parameters[i].Visible = false;
                        }

                        rpt16.DataSource = DsWorkTime;
                        rpt16.RequestParameters = false;
                        frm17.documentViewer1.DocumentSource = rpt16;
                        frm17.ShowDialog();
                        break;
                    case "جرد الزمنيات الغير مستقطعة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp17 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt17 = new DataTable();
                        Dt17 = rp17.RPEMP_EmployeeZamanyiat(dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsZam = new DS.DataSetMechanisms();
                        DsZam.Tables["EmployeeZam"].Clear();

                        for (int i = 0; i < Dt17.Rows.Count; i++)
                        {
                            DsZam.Tables["EmployeeZam"].Rows.Add(Dt17.Rows[i][0], Dt17.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm18 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesZam rpt17 = new REPORTS.EmployeesZam();

                        rpt17.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt17.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt17.Parameters["EmpCounts"].Value = Dt17.Rows.Count;
                        rpt17.Parameters["FromDate"].Value = dt1.Value;
                        rpt17.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt17.Parameters.Count; i++)
                        {
                            rpt17.Parameters[i].Visible = false;
                        }

                        rpt17.DataSource = DsZam;
                        rpt17.RequestParameters = false;
                        frm18.documentViewer1.DocumentSource = rpt17;
                        frm18.ShowDialog();
                        break;
                    case "جرد كافة الزمنيات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp18 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt18 = new DataTable();
                        Dt18 = rp18.RPEMP_EmployeeZamanyiatAll(dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsZam1 = new DS.DataSetMechanisms();
                        DsZam1.Tables["EmployeeZam"].Clear();

                        for (int i = 0; i < Dt18.Rows.Count; i++)
                        {
                            DsZam1.Tables["EmployeeZam"].Rows.Add(Dt18.Rows[i][0], Dt18.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm19 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesZam1 rpt18 = new REPORTS.EmployeesZam1();

                        rpt18.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt18.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt18.Parameters["EmpCounts"].Value = Dt18.Rows.Count;
                        rpt18.Parameters["FromDate"].Value = dt1.Value;
                        rpt18.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt18.Parameters.Count; i++)
                        {
                            rpt18.Parameters[i].Visible = false;
                        }

                        rpt18.DataSource = DsZam1;
                        rpt18.RequestParameters = false;
                        frm19.documentViewer1.DocumentSource = rpt18;
                        frm19.ShowDialog();
                        break;
                    case "زمنيات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp19 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt19 = new DataTable();
                        Dt19 = rp19.RPEMP_EmployeeZamanyiatbyName(cb1.Text, dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsZam2 = new DS.DataSetMechanisms();
                        DsZam2.Tables["EmployeeZam"].Clear();

                        for (int i = 0; i < Dt19.Rows.Count; i++)
                        {
                            DsZam2.Tables["EmployeeZam"].Rows.Add(Dt19.Rows[i][0], Dt19.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm20 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesZam2 rpt19 = new REPORTS.EmployeesZam2();

                        rpt19.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt19.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt19.Parameters["FromDate"].Value = dt1.Value;
                        rpt19.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt19.Parameters.Count; i++)
                        {
                            rpt19.Parameters[i].Visible = false;
                        }

                        rpt19.DataSource = DsZam2;
                        rpt19.RequestParameters = false;
                        frm20.documentViewer1.DocumentSource = rpt19;
                        frm20.ShowDialog();
                        break;
                    case "عناوين المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES rp20 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt20 = new DataTable();
                        Dt20 = rp20.RPEMP_EmployessandLivePlace();
                        DS.DataSetMechanisms DsEmpLive = new DS.DataSetMechanisms();
                        DsEmpLive.Tables["EmployeeLive"].Clear();

                        for (int i = 0; i < Dt20.Rows.Count; i++)
                        {
                            DsEmpLive.Tables["EmployeeLive"].Rows.Add(Dt20.Rows[i][0], Dt20.Rows[i][1], Dt20.Rows[i][2],
                                Dt20.Rows[i][3], Dt20.Rows[i][4], Dt20.Rows[i][5]);

                        }

                        REPORTS.ReportsViewer frm21 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesLive rpt20 = new REPORTS.EmployeesLive();

                        rpt20.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt20.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt20.Parameters["EmpCounts"].Value = Dt20.Rows.Count;


                        for (int i = 0; i < rpt20.Parameters.Count; i++)
                        {
                            rpt20.Parameters[i].Visible = false;
                        }

                        rpt20.DataSource = DsEmpLive;
                        rpt20.RequestParameters = false;
                        frm21.documentViewer1.DocumentSource = rpt20;
                        frm21.ShowDialog();
                        break;
                    case "ارقام هواتف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES rp21 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt21 = new DataTable();
                        Dt21 = rp21.RPEMP_Employeesandmobile();
                        DS.DataSetMechanisms DsEmpMobile = new DS.DataSetMechanisms();
                        DsEmpMobile.Tables["EmployeeMobile"].Clear();

                        for (int i = 0; i < Dt21.Rows.Count; i++)
                        {
                            DsEmpMobile.Tables["EmployeeMobile"].Rows.Add(Dt21.Rows[i][0], Dt21.Rows[i][1], Dt21.Rows[i][2],
                                Dt21.Rows[i][3], Dt21.Rows[i][4], Dt21.Rows[i][5]);

                        }

                        REPORTS.ReportsViewer frm22 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesMobile rpt21 = new REPORTS.EmployeesMobile();

                        rpt21.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt21.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt21.Parameters["EmpCounts"].Value = Dt21.Rows.Count;


                        for (int i = 0; i < rpt21.Parameters.Count; i++)
                        {
                            rpt21.Parameters[i].Visible = false;
                        }

                        rpt21.DataSource = DsEmpMobile;
                        rpt21.RequestParameters = false;
                        frm22.documentViewer1.DocumentSource = rpt21;
                        frm22.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب التحصيل الدراسي":
                        CLS_FRMS.RPEMPEMPLOYEES rp22 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt22 = new DataTable();
                        Dt22 = rp22.RPEMP_EmployeesandStduy();
                        DS.DataSetMechanisms DsEmpStudy = new DS.DataSetMechanisms();
                        DsEmpStudy.Tables["EmployeeStudy"].Clear();

                        for (int i = 0; i < Dt22.Rows.Count; i++)
                        {
                            DsEmpStudy.Tables["EmployeeStudy"].Rows.Add(Dt22.Rows[i][0], Dt22.Rows[i][1], Dt22.Rows[i][2],
                                Dt22.Rows[i][3], Dt22.Rows[i][4], Dt22.Rows[i][5]);

                        }

                        REPORTS.ReportsViewer frm23 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesStudy rpt22 = new REPORTS.EmployeesStudy();

                        rpt22.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt22.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt22.Parameters["EmpCounts"].Value = Dt22.Rows.Count;


                        for (int i = 0; i < rpt22.Parameters.Count; i++)
                        {
                            rpt22.Parameters[i].Visible = false;
                        }

                        rpt22.DataSource = DsEmpStudy;
                        rpt22.RequestParameters = false;
                        frm23.documentViewer1.DocumentSource = rpt22;
                        frm23.ShowDialog();
                        break;
                    case "ارقام تخاويل المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES rp23 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt23 = new DataTable();
                        Dt23 = rp23.RPEMP_EmployessandTaghweel();
                        DS.DataSetMechanisms DsEmpTaghweel = new DS.DataSetMechanisms();
                        DsEmpTaghweel.Tables["EmployeeTaghweel"].Clear();

                        for (int i = 0; i < Dt23.Rows.Count; i++)
                        {
                            DsEmpTaghweel.Tables["EmployeeTaghweel"].Rows.Add(Dt23.Rows[i][0], Dt23.Rows[i][1], Dt23.Rows[i][2],
                                Dt23.Rows[i][3]);

                        }

                        REPORTS.ReportsViewer frm24 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeeTaghweel rpt23 = new REPORTS.EmployeeTaghweel();

                        rpt23.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt23.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt23.Parameters["EmpCounts"].Value = Dt23.Rows.Count;


                        for (int i = 0; i < rpt23.Parameters.Count; i++)
                        {
                            rpt23.Parameters[i].Visible = false;
                        }

                        rpt23.DataSource = DsEmpTaghweel;
                        rpt23.RequestParameters = false;
                        frm24.documentViewer1.DocumentSource = rpt23;
                        frm24.ShowDialog();
                        break;
                    case "بيانات عائلية":
                        CLS_FRMS.RPEMPEMPLOYEES rp24 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt24 = new DataTable();
                        Dt24 = rp24.RPEMP_EmployessandTypeandchildren();
                        DS.DataSetMechanisms DsEmpFamilyinfo = new DS.DataSetMechanisms();
                        DsEmpFamilyinfo.Tables["EmployeeFamilyInfo"].Clear();

                        for (int i = 0; i < Dt24.Rows.Count; i++)
                        {
                            DsEmpFamilyinfo.Tables["EmployeeFamilyInfo"].Rows.Add(Dt24.Rows[i][0], Dt24.Rows[i][1], Dt24.Rows[i][2],
                                Dt24.Rows[i][3], Dt24.Rows[i][4]);

                        }

                        REPORTS.ReportsViewer frm25 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesFamilyInfo rpt24 = new REPORTS.EmployeesFamilyInfo();

                        rpt24.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt24.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt24.Parameters["EmpCounts"].Value = Dt24.Rows.Count;


                        for (int i = 0; i < rpt24.Parameters.Count; i++)
                        {
                            rpt24.Parameters[i].Visible = false;
                        }

                        rpt24.DataSource = DsEmpFamilyinfo;
                        rpt24.RequestParameters = false;
                        frm25.documentViewer1.DocumentSource = rpt24;
                        frm25.ShowDialog();
                        break;
                    case "جرد موقف المنتسبين":
                        CLS_FRMS.RPEMPEMPLOYEES rp25 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt25 = new DataTable();
                        Dt25 = rp25.RPEMP_EmpSituation();
                        DS.DataSetMechanisms DsSummarysitu = new DS.DataSetMechanisms();
                        DsSummarysitu.Tables["SumarySitu"].Clear();

                        for (int i = 0; i < Dt25.Rows.Count; i++)
                        {
                            DsSummarysitu.Tables["SumarySitu"].Rows.Add(Dt25.Rows[i][0], Dt25.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm26 = new REPORTS.ReportsViewer();
                        REPORTS.SummarySitu rpt25 = new REPORTS.SummarySitu();

                        double summarysitu = 0;
                        for (int i = 0; i < Dt25.Rows.Count; i++)
                        {
                            summarysitu = summarysitu + int.Parse(Dt25.Rows[i][1].ToString());
                        }
                        rpt25.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt25.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt25.Parameters["EmpCounts"].Value = summarysitu;


                        for (int i = 0; i < rpt25.Parameters.Count; i++)
                        {
                            rpt25.Parameters[i].Visible = false;
                        }

                        rpt25.DataSource = DsSummarysitu;
                        rpt25.RequestParameters = false;
                        frm26.documentViewer1.DocumentSource = rpt25;
                        frm26.ShowDialog();
                        break;
                    case "خلاصة الاعداد حسب العنوان الوظيفي":
                        CLS_FRMS.RPEMPEMPLOYEES rp26 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt26 = new DataTable();
                        Dt26 = rp26.RPEMP_JobsName();
                        DS.DataSetMechanisms DsJobsName = new DS.DataSetMechanisms();
                        DsJobsName.Tables["SummaryJobs"].Clear();

                        for (int i = 0; i < Dt26.Rows.Count; i++)
                        {
                            DsJobsName.Tables["SummaryJobs"].Rows.Add(Dt26.Rows[i][0], Dt26.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm27 = new REPORTS.ReportsViewer();
                        REPORTS.SummaryJobs rpt26 = new REPORTS.SummaryJobs();

                        double SumEmpJobs = 0;
                        for (int i = 0; i < Dt26.Rows.Count; i++)
                        {
                            SumEmpJobs = SumEmpJobs + int.Parse(Dt26.Rows[i][1].ToString());
                        }
                        rpt26.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt26.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt26.Parameters["EmpCounts"].Value = SumEmpJobs;


                        for (int i = 0; i < rpt26.Parameters.Count; i++)
                        {
                            rpt26.Parameters[i].Visible = false;
                        }

                        rpt26.DataSource = DsJobsName;
                        rpt26.RequestParameters = false;
                        frm27.documentViewer1.DocumentSource = rpt26;
                        frm27.ShowDialog();
                        break;
                    case "خلاصة الاعداد حسب الجهات المستفيدة":
                        CLS_FRMS.RPEMPEMPLOYEES rp27 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt27 = new DataTable();
                        Dt27 = rp27.RPEMP_BeneficiaryCount();
                        DS.DataSetMechanisms DsBeneName = new DS.DataSetMechanisms();
                        DsBeneName.Tables["SummaryBeneficiary"].Clear();

                        for (int i = 0; i < Dt27.Rows.Count; i++)
                        {
                            DsBeneName.Tables["SummaryBeneficiary"].Rows.Add(Dt27.Rows[i][0], Dt27.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm28 = new REPORTS.ReportsViewer();
                        REPORTS.SummaryBeneficiary rpt27 = new REPORTS.SummaryBeneficiary();

                        double SumEmpBene = 0;
                        for (int i = 0; i < Dt27.Rows.Count; i++)
                        {
                            SumEmpBene = SumEmpBene + int.Parse(Dt27.Rows[i][1].ToString());
                        }
                        rpt27.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt27.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt27.Parameters["EmpCounts"].Value = SumEmpBene;


                        for (int i = 0; i < rpt27.Parameters.Count; i++)
                        {
                            rpt27.Parameters[i].Visible = false;
                        }

                        rpt27.DataSource = DsBeneName;
                        rpt27.RequestParameters = false;
                        frm28.documentViewer1.DocumentSource = rpt27;
                        frm28.ShowDialog();
                        break;
                    case "خلاصة الاعداد حسب الحالة":
                        CLS_FRMS.RPEMPEMPLOYEES rp28 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt28 = new DataTable();
                        Dt28 = rp28.RPEMP_TheTypecounts();
                        DS.DataSetMechanisms DsType = new DS.DataSetMechanisms();
                        DsType.Tables["SmmaryTypes"].Clear();

                        for (int i = 0; i < Dt28.Rows.Count; i++)
                        {
                            DsType.Tables["SmmaryTypes"].Rows.Add(Dt28.Rows[i][0], Dt28.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm29 = new REPORTS.ReportsViewer();
                        REPORTS.SummaryType rpt28 = new REPORTS.SummaryType();

                        int SumType = 0;
                        for (int i = 0; i < Dt28.Rows.Count; i++)
                        {
                            SumType = SumType + int.Parse(Dt28.Rows[i][1].ToString());
                        }
                        rpt28.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt28.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt28.Parameters["EmpCounts"].Value = SumType;


                        for (int i = 0; i < rpt28.Parameters.Count; i++)
                        {
                            rpt28.Parameters[i].Visible = false;
                        }

                        rpt28.DataSource = DsType;
                        rpt28.RequestParameters = false;
                        frm29.documentViewer1.DocumentSource = rpt28;
                        frm29.ShowDialog();
                        break;
                    case "خلاصة حسب اماكن العمل":
                        CLS_FRMS.RPEMPEMPLOYEES rp29 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt29 = new DataTable();
                        Dt29 = rp29.RPEMP_WorkPlace();
                        DS.DataSetMechanisms DsWorkPlace = new DS.DataSetMechanisms();
                        DsWorkPlace.Tables["SummaryWorkPlace"].Clear();

                        for (int i = 0; i < Dt29.Rows.Count; i++)
                        {
                            DsWorkPlace.Tables["SummaryWorkPlace"].Rows.Add(Dt29.Rows[i][0], Dt29.Rows[i][1]);

                        }

                        REPORTS.ReportsViewer frm30 = new REPORTS.ReportsViewer();
                        REPORTS.SummaryWorkPlace rpt29 = new REPORTS.SummaryWorkPlace();

                        int SumWorkplace = 0;
                        for (int i = 0; i < Dt29.Rows.Count; i++)
                        {
                            SumWorkplace = SumWorkplace + int.Parse(Dt29.Rows[i][1].ToString());
                        }
                        rpt29.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt29.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt29.Parameters["EmpCounts"].Value = SumWorkplace;


                        for (int i = 0; i < rpt29.Parameters.Count; i++)
                        {
                            rpt29.Parameters[i].Visible = false;
                        }

                        rpt29.DataSource = DsWorkPlace;
                        rpt29.RequestParameters = false;
                        frm30.documentViewer1.DocumentSource = rpt29;
                        frm30.ShowDialog();
                        break;
                    case "المتغيرات اليومية مجازون":
                        CLS_FRMS.RPEMPEMPLOYEES rp30 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt30 = new DataTable();
                        Dt30 = rp30.RPEMP_VariabelGo();
                        DS.DataSetMechanisms DsVariableGo = new DS.DataSetMechanisms();
                        DsVariableGo.Tables["EmployeesVariables"].Clear();

                        for (int i = 0; i < Dt30.Rows.Count; i++)
                        {
                            DsVariableGo.Tables["EmployeesVariables"].Rows.Add(Dt30.Rows[i][0], Dt30.Rows[i][1]
                                , Dt30.Rows[i][2], i + 1);

                        }

                        REPORTS.ReportsViewer frm31 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesVariableGo rpt30 = new REPORTS.EmployeesVariableGo();


                        rpt30.LbDateNow.Text = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt30.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt30.Parameters["EmpCounts"].Value = Dt30.Rows.Count;
                        rpt30.LbDateVariable.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                        rpt30.Parameters["NameOfDay"].Value = cb1.Text;
                        rpt30.Parameters["RegisterVariable"].Value = cb2.Text;

                        for (int i = 0; i < rpt30.Parameters.Count; i++)
                        {
                            rpt30.Parameters[i].Visible = false;
                        }

                        rpt30.DataSource = DsVariableGo;
                        rpt30.RequestParameters = false;
                        frm31.documentViewer1.DocumentSource = rpt30;
                        frm31.ShowDialog();
                        break;
                    case "المتغيرات اليومية مجازون بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp30TwoDate = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt30TwoDate = new DataTable();
                        Dt30TwoDate = rp30TwoDate.RPEMP_VariabelGoBetweenTwoDates(dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsVariableGoTwoDate = new DS.DataSetMechanisms();
                        DsVariableGoTwoDate.Tables["EmployeesVariables"].Clear();

                        for (int i = 0; i < Dt30TwoDate.Rows.Count; i++)
                        {
                            DsVariableGoTwoDate.Tables["EmployeesVariables"].Rows.Add(Dt30TwoDate.Rows[i][0], Dt30TwoDate.Rows[i][1]
                                , Dt30TwoDate.Rows[i][2], i + 1);

                        }

                        REPORTS.ReportsViewer frm31TwoDate = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesVariableGo rpt30TwoDate = new REPORTS.EmployeesVariableGo();


                        rpt30TwoDate.LbDateNow.Text = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt30TwoDate.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt30TwoDate.Parameters["EmpCounts"].Value = Dt30TwoDate.Rows.Count;
                        rpt30TwoDate.LbDateVariable.Text = dt1.Text;
                        rpt30TwoDate.Parameters["NameOfDay"].Value = cb1.Text;
                        rpt30TwoDate.Parameters["RegisterVariable"].Value = cb2.Text;

                        for (int i = 0; i < rpt30TwoDate.Parameters.Count; i++)
                        {
                            rpt30TwoDate.Parameters[i].Visible = false;
                        }

                        rpt30TwoDate.DataSource = DsVariableGoTwoDate;
                        rpt30TwoDate.RequestParameters = false;
                        frm31TwoDate.documentViewer1.DocumentSource = rpt30TwoDate;
                        frm31TwoDate.ShowDialog();
                        break;
                    case "المتغيرات اليومية العودة":
                        CLS_FRMS.RPEMPEMPLOYEES rp31 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt31 = new DataTable();
                        Dt31 = rp31.RPEMP_VariabelComming();
                        DS.DataSetMechanisms DsVariableComming = new DS.DataSetMechanisms();
                        DsVariableComming.Tables["EmployeesVariables"].Clear();

                        for (int i = 0; i < Dt31.Rows.Count; i++)
                        {
                            DsVariableComming.Tables["EmployeesVariables"].Rows.Add(Dt31.Rows[i][0], Dt31.Rows[i][1]
                                , Dt31.Rows[i][2], i + 1);

                        }

                        REPORTS.ReportsViewer frm32 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeesVariableComming rpt31 = new REPORTS.EmployeesVariableComming();


                        rpt31.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt31.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt31.Parameters["EmpCounts"].Value = Dt31.Rows.Count;
                        rpt31.LbDateVariable.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
                        rpt31.Parameters["NameOfDay"].Value = cb1.Text;
                        rpt31.Parameters["RegisterVariable"].Value = cb2.Text;

                        for (int i = 0; i < rpt31.Parameters.Count; i++)
                        {
                            rpt31.Parameters[i].Visible = false;
                        }

                        rpt31.DataSource = DsVariableComming;
                        rpt31.RequestParameters = false;
                        frm32.documentViewer1.DocumentSource = rpt31;
                        frm32.ShowDialog();
                        break;
                    case "متغيرات منتسب":
                        CLS_FRMS.RPEMPEMPLOYEES rp32 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt32 = new DataTable();
                        Dt32 = rp32.RPEMP_VariabelEmployee(int.Parse(cb1.SelectedValue.ToString()));
                        DS.DataSetMechanisms DsVariableEmp = new DS.DataSetMechanisms();
                        DsVariableEmp.Tables["EmpVariables"].Clear();

                        for (int i = 0; i < Dt32.Rows.Count; i++)
                        {
                            DsVariableEmp.Tables["EmpVariables"].Rows.Add(null, Dt32.Rows[i][1], Dt32.Rows[i][2]
                                , Dt32.Rows[i][3], Dt32.Rows[i][4], Dt32.Rows[i][5], Dt32.Rows[i][6]);

                        }

                        REPORTS.ReportsViewer frm33 = new REPORTS.ReportsViewer();
                        REPORTS.EmpAllVar rpt32 = new REPORTS.EmpAllVar();
                        int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;

                        for (int i = 0; i < Dt32.Rows.Count; i++)
                        {
                            if (Dt32.Rows[i][1].ToString() == "اجازة") sum1 = sum1 + int.Parse(Dt32.Rows[i][2].ToString());
                            else if (Dt32.Rows[i][1].ToString() == "ارسال") sum2 = sum2 + int.Parse(Dt32.Rows[i][2].ToString());
                            else if (Dt32.Rows[i][1].ToString() == "غياب") sum3 = sum3 + int.Parse(Dt32.Rows[i][2].ToString());
                            else if (Dt32.Rows[i][1].ToString() == "ارسال خاص") sum4 = sum4 + int.Parse(Dt32.Rows[i][2].ToString());
                        }

                        rpt32.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt32.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt32.Parameters["VarCount1"].Value = sum1;
                        rpt32.Parameters["VarCount2"].Value = sum3;
                        rpt32.Parameters["VarCount3"].Value = sum2;
                        rpt32.LbEmpName.Text = cb1.Text;

                        for (int i = 0; i < rpt32.Parameters.Count; i++)
                        {
                            rpt32.Parameters[i].Visible = false;
                        }

                        rpt32.DataSource = DsVariableEmp;
                        rpt32.RequestParameters = false;
                        frm33.documentViewer1.DocumentSource = rpt32;
                        frm33.ShowDialog();
                        break;
                    case "متغيرات منتسب بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp33 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt33 = new DataTable();
                        Dt33 = rp33.RPEMP_VariabelEmployeeTowDate(int.Parse(cb1.SelectedValue.ToString()), dt1.Text, dt2.Text);
                        DS.DataSetMechanisms DsVariableEmp2 = new DS.DataSetMechanisms();
                        DsVariableEmp2.Tables["EmpVariables"].Clear();

                        for (int i = 0; i < Dt33.Rows.Count; i++)
                        {
                            DsVariableEmp2.Tables["EmpVariables"].Rows.Add(null, Dt33.Rows[i][1], Dt33.Rows[i][2]
                                , Dt33.Rows[i][3], Dt33.Rows[i][4], Dt33.Rows[i][5], Dt33.Rows[i][6]);

                        }

                        REPORTS.ReportsViewer frm34 = new REPORTS.ReportsViewer();
                        REPORTS.EmpAllVar2 rpt33 = new REPORTS.EmpAllVar2();
                        int summ1 = 0, summ2 = 0, summ3 = 0, summ4 = 0;

                        for (int i = 0; i < Dt33.Rows.Count; i++)
                        {
                            if (Dt33.Rows[i][1].ToString() == "اجازة") summ1 = summ1 + int.Parse(Dt33.Rows[i][2].ToString());
                            else if (Dt33.Rows[i][1].ToString() == "ارسال") summ2 = summ2 + int.Parse(Dt33.Rows[i][2].ToString());
                            else if (Dt33.Rows[i][1].ToString() == "غياب") summ3 = summ3 + int.Parse(Dt33.Rows[i][2].ToString());
                            else if (Dt33.Rows[i][1].ToString() == "ارسال خاص") summ4 = summ4 + int.Parse(Dt33.Rows[i][2].ToString());
                        }

                        rpt33.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt33.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt33.Parameters["VarCount1"].Value = summ1;
                        rpt33.Parameters["VarCount2"].Value = summ3;
                        rpt33.Parameters["VarCount3"].Value = summ2;
                        rpt33.Parameters["VarCount4"].Value = summ4;
                        rpt33.LbEmpName.Text = cb1.Text;
                        rpt33.Parameters["FromDate"].Value = dt1.Value;
                        rpt33.Parameters["ToDate"].Value = dt2.Value;

                        for (int i = 0; i < rpt33.Parameters.Count; i++)
                        {
                            rpt33.Parameters[i].Visible = false;
                        }

                        rpt33.DataSource = DsVariableEmp2;
                        rpt33.RequestParameters = false;
                        frm34.documentViewer1.DocumentSource = rpt33;
                        frm34.ShowDialog();
                        break;
                    case "المنتسبين المنقطعين بدون عودة":
                        CLS_FRMS.RPEMPEMPLOYEES rp34 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt34 = new DataTable();
                        Dt34 = rp34.RPEMP_VariabelNotComming();
                        DS.DataSetMechanisms DsVariableEmp3 = new DS.DataSetMechanisms();
                        DsVariableEmp3.Tables["EmpVarNotComming"].Clear();

                        for (int i = 0; i < Dt34.Rows.Count; i++)
                        {
                            DsVariableEmp3.Tables["EmpVarNotComming"].Rows.Add(Dt34.Rows[i][0], Dt34.Rows[i][1]
                                , Dt34.Rows[i][2]);

                        }

                        REPORTS.ReportsViewer frm35 = new REPORTS.ReportsViewer();
                        REPORTS.EmpVarNotComming rpt34 = new REPORTS.EmpVarNotComming();

                        rpt34.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt34.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt34.Parameters["EmpCounts"].Value = Dt34.Rows.Count;

                        for (int i = 0; i < rpt34.Parameters.Count; i++)
                        {
                            rpt34.Parameters[i].Visible = false;
                        }

                        rpt34.DataSource = DsVariableEmp3;
                        rpt34.RequestParameters = false;
                        frm35.documentViewer1.DocumentSource = rpt34;
                        frm35.ShowDialog();
                        break;
                    case "جرد المنتسبين حسب الشعبة والوجبة":
                        CLS_FRMS.RPEMPEMPLOYEES rp35 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt35 = new DataTable();
                        Dt35 = rp35.RPEMP_EmployeesByDivisionAndSheft(cb1.Text, cb2.Text);
                        DS.DataSetMechanisms DS = new DS.DataSetMechanisms();
                        DS.Tables["EmployeeByDivisionAndSheft"].Clear();

                        for (int i = 0; i < Dt35.Rows.Count; i++)
                        {
                            DS.Tables["EmployeeByDivisionAndSheft"].Rows.Add(i + 1, Dt35.Rows[i][0]);

                        }

                        REPORTS.ReportsViewer frm36 = new REPORTS.ReportsViewer();
                        REPORTS.EmployeeByDivisionAndSheft rpt35 = new REPORTS.EmployeeByDivisionAndSheft();

                        rpt35.Parameters["RpType"].Value = cb5.Text + "(" + cb1.Text + " , " + cb2.Text + ")";
                        rpt35.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt35.Parameters["EmpCount"].Value = Dt35.Rows.Count;

                        for (int i = 0; i < rpt35.Parameters.Count; i++)
                        {
                            rpt35.Parameters[i].Visible = false;
                        }

                        rpt35.DataSource = DS;
                        rpt35.RequestParameters = false;
                        frm36.documentViewer1.DocumentSource = rpt35;
                        frm36.ShowDialog();
                        break;
                    case "ايفادات حسب الاسم بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp36 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt36 = new DataTable();
                        Dt36 = rp36.DisputchesByEmpName(cb1.Text, dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS36 = new DS.DataSetMechanisms();
                        DS36.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt36.Rows.Count; i++)
                        {
                            DS36.Tables["DisputchesReport"].Rows.Add(i + 1, Dt36.Rows[i][0], Dt36.Rows[i][1]
                                , Convert.ToDateTime(Dt36.Rows[i][2]).ToString("yyyy/MM/dd"), Dt36.Rows[i][3], Dt36.Rows[i][4], Dt36.Rows[i][5], Convert.ToDateTime(Dt36.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt36.Rows[i][7], Convert.ToDateTime(Dt36.Rows[i][8]).ToString("yyyy/MM/dd"), Dt36.Rows[i][9], Dt36.Rows[i][10], Dt36.Rows[i][11], Dt36.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm37 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt36 = new REPORTS.RPDisputches();

                        rpt36.Parameters["RPType"].Value = cb5.Text + "\n\r اسم المنتسب:" + cb1.Text + " \n\r من:" + dt1.Text + "\n\r الى:"+dt2.Text;
                        rpt36.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt36.Parameters["Count"].Value = Dt36.Rows.Count;
                        rpt36.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt36.Parameters.Count; i++)
                        {
                            rpt36.Parameters[i].Visible = false;
                        }

                        rpt36.DataSource = DS36;
                        rpt36.RequestParameters = false;
                        frm37.documentViewer1.DocumentSource = rpt36;
                        frm37.ShowDialog();
                        break;
                    case "ايفادات حسب الجهة المقصودة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp37 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt37 = new DataTable();
                        Dt37 = rp37.DisputchesByDistenation(cb1.Text, dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS37 = new DS.DataSetMechanisms();
                        DS37.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt37.Rows.Count; i++)
                        {
                            DS37.Tables["DisputchesReport"].Rows.Add(i + 1, Dt37.Rows[i][0], Dt37.Rows[i][1]
                                , Convert.ToDateTime(Dt37.Rows[i][2]).ToString("yyyy/MM/dd"), Dt37.Rows[i][3], Dt37.Rows[i][4], Dt37.Rows[i][5], Convert.ToDateTime(Dt37.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt37.Rows[i][7], Convert.ToDateTime(Dt37.Rows[i][8]).ToString("yyyy/MM/dd"), Dt37.Rows[i][9], Dt37.Rows[i][10], Dt37.Rows[i][11], Dt37.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm38 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt37 = new REPORTS.RPDisputches();

                        rpt37.Parameters["RPType"].Value = cb5.Text + "\n\r الجهة المقصودة:" + cb1.Text + " \n\r من:" + dt1.Text + "\n\r الى:" + dt2.Text;
                        rpt37.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt37.Parameters["Count"].Value = Dt37.Rows.Count;
                        rpt37.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt37.Parameters.Count; i++)
                        {
                            rpt37.Parameters[i].Visible = false;
                        }

                        rpt37.DataSource = DS37;
                        rpt37.RequestParameters = false;
                        frm38.documentViewer1.DocumentSource = rpt37;
                        frm38.ShowDialog();
                        break;
                    case "ايفادات حسب رقم العجلة بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp38 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt38 = new DataTable();
                        Dt38 = rp38.DisputchesByCarNO(cb1.Text, dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS38 = new DS.DataSetMechanisms();
                        DS38.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt38.Rows.Count; i++)
                        {
                            DS38.Tables["DisputchesReport"].Rows.Add(i + 1, Dt38.Rows[i][0], Dt38.Rows[i][1]
                                , Convert.ToDateTime(Dt38.Rows[i][2]).ToString("yyyy/MM/dd"), Dt38.Rows[i][3], Dt38.Rows[i][4], Dt38.Rows[i][5], Convert.ToDateTime(Dt38.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt38.Rows[i][7], Convert.ToDateTime(Dt38.Rows[i][8]).ToString("yyyy/MM/dd"), Dt38.Rows[i][9], Dt38.Rows[i][10], Dt38.Rows[i][11], Dt38.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm39 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt38 = new REPORTS.RPDisputches();

                        rpt38.Parameters["RPType"].Value = cb5.Text + "\n\r الجهة المقصودة:" + cb1.Text + " \n\r من:" + dt1.Text + "\n\r الى:" + dt2.Text;
                        rpt38.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt38.Parameters["Count"].Value = Dt38.Rows.Count;
                        rpt38.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt38.Parameters.Count; i++)
                        {
                            rpt38.Parameters[i].Visible = false;
                        }

                        rpt38.DataSource = DS38;
                        rpt38.RequestParameters = false;
                        frm39.documentViewer1.DocumentSource = rpt38;
                        frm39.ShowDialog();
                        break;
                    case "ايفادات بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp39 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt39 = new DataTable();
                        Dt39 = rp39.DisputchesBetweenTwoDates(dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS39 = new DS.DataSetMechanisms();
                        DS39.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt39.Rows.Count; i++)
                        {
                            DS39.Tables["DisputchesReport"].Rows.Add(i + 1, Dt39.Rows[i][0], Dt39.Rows[i][1]
                                , Convert.ToDateTime(Dt39.Rows[i][2]).ToString("yyyy/MM/dd"), Dt39.Rows[i][3], Dt39.Rows[i][4], Dt39.Rows[i][5], Convert.ToDateTime(Dt39.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt39.Rows[i][7], Convert.ToDateTime(Dt39.Rows[i][8]).ToString("yyyy/MM/dd"), Dt39.Rows[i][9], Dt39.Rows[i][10], Dt39.Rows[i][11], Dt39.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm40 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt39 = new REPORTS.RPDisputches();

                        rpt39.Parameters["RPType"].Value = cb5.Text + " \n\r من:" + dt1.Text + "\n\r الى:" + dt2.Text;
                        rpt39.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt39.Parameters["Count"].Value = Dt39.Rows.Count;
                        rpt39.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt39.Parameters.Count; i++)
                        {
                            rpt39.Parameters[i].Visible = false;
                        }

                        rpt39.DataSource = DS39;
                        rpt39.RequestParameters = false;
                        frm40.documentViewer1.DocumentSource = rpt39;
                        frm40.ShowDialog();
                        break;
                    case "جرد حسب حالة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp40 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt40 = new DataTable();
                        Dt40 = rp40.DisputchesByDisCase(cb1.Text, dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS40 = new DS.DataSetMechanisms();
                        DS40.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt40.Rows.Count; i++)
                        {
                            DS40.Tables["DisputchesReport"].Rows.Add(i + 1, Dt40.Rows[i][0], Dt40.Rows[i][1]
                                , Convert.ToDateTime(Dt40.Rows[i][2]).ToString("yyyy/MM/dd"), Dt40.Rows[i][3], Dt40.Rows[i][4], Dt40.Rows[i][5], Convert.ToDateTime(Dt40.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt40.Rows[i][7], Convert.ToDateTime(Dt40.Rows[i][8]).ToString("yyyy/MM/dd"), Dt40.Rows[i][9], Dt40.Rows[i][10], Dt40.Rows[i][11], Dt40.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm41 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt40 = new REPORTS.RPDisputches();

                        rpt40.Parameters["RPType"].Value = cb5.Text + "\n\r حالة الايفاد:" + cb1.Text + " \n\r من:" + dt1.Text + "\n\r الى:" + dt2.Text;
                        rpt40.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt40.Parameters["Count"].Value = Dt40.Rows.Count;
                        rpt40.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt40.Parameters.Count; i++)
                        {
                            rpt40.Parameters[i].Visible = false;
                        }

                        rpt40.DataSource = DS40;
                        rpt40.RequestParameters = false;
                        frm41.documentViewer1.DocumentSource = rpt40;
                        frm41.ShowDialog();
                        break;
                    case "جرد حسب مرحلة الايفاد بين تاريخين":
                        CLS_FRMS.RPEMPEMPLOYEES rp41 = new CLS_FRMS.RPEMPEMPLOYEES();
                        DataTable Dt41 = new DataTable();
                        Dt41 = rp41.DisputchesCompleteOrNot(cb1.Text, dt1.Value, dt2.Value);
                        DS.DataSetMechanisms DS41 = new DS.DataSetMechanisms();
                        DS41.Tables["DisputchesReport"].Clear();

                        for (int i = 0; i < Dt41.Rows.Count; i++)
                        {
                            DS41.Tables["DisputchesReport"].Rows.Add(i + 1, Dt41.Rows[i][0], Dt41.Rows[i][1]
                                , Convert.ToDateTime(Dt41.Rows[i][2]).ToString("yyyy/MM/dd"), Dt41.Rows[i][3], Dt41.Rows[i][4], Dt41.Rows[i][5], Convert.ToDateTime(Dt41.Rows[i][6]).ToString("yyyy/MM/dd")
                                , Dt41.Rows[i][7], Convert.ToDateTime(Dt41.Rows[i][8]).ToString("yyyy/MM/dd"), Dt41.Rows[i][9], Dt41.Rows[i][10], Dt41.Rows[i][11], Dt41.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer frm42 = new REPORTS.ReportsViewer();
                        REPORTS.RPDisputches rpt41 = new REPORTS.RPDisputches();

                        rpt41.Parameters["RPType"].Value = cb5.Text + "\n\r مرحلة الايفاد:" + cb1.Text + " \n\r من:" + dt1.Text + "\n\r الى:" + dt2.Text;
                        rpt41.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt41.Parameters["Count"].Value = Dt41.Rows.Count;
                        rpt41.Parameters["Date"].Value = DateTime.Now.ToString("yyyy/MM/dd");

                        for (int i = 0; i < rpt41.Parameters.Count; i++)
                        {
                            rpt41.Parameters[i].Visible = false;
                        }

                        rpt41.DataSource = DS41;
                        rpt41.RequestParameters = false;
                        frm42.documentViewer1.DocumentSource = rpt41;
                        frm42.ShowDialog();
                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
       

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }
    }
}
