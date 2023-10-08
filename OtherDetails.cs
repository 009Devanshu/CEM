using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Diagnostics;
using iText.Layout.Borders;
using System.Windows.Forms;
using System.Data.SqlClient;
using iText.Kernel.Colors;
using iText.IO.Image;
using System.Globalization;
using static iText.Kernel.Pdf.Colorspace.PdfCieBasedCs;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Geom;
using System.Drawing;
using System.Reflection;

namespace CEM
{
    public partial class OtherDetails : DevExpress.XtraEditors.XtraForm
    {
        string EmployeeName;
        string EmpCode;
        string Designation;
        DateTime DateOfJoining;
        string Pan;
        string EmpAddress;
        double TotalCTC;
        double EmpBasic;
        double EmpHra;
        double EmpTA;
        double OtherAllowance;
        double MedicalAllowance;
        double RemoteWorkAllowance;
        double Bonus;
        double PF;
        double ESIC;
        double Loan;
        double Advance;
        double Other;
        double TDS;
        double TotalEarnings;
        double Deductions;
        double NetPayable;

        string employee_name;

        double MonthlySalary;

        string gettingMonth;
        string gettingYear;
        public int MaxMonthlyAttendance;
        int ActualAttendance;



        /*  int autoattendance;
          int DaysInAMonth;
          int AutoMonthlyAttendance;*/

        //Note:- AutoMonthlyAttendace and DaysInAMonth are same.

        string data_path = System.Configuration.ConfigurationManager.
    ConnectionStrings["mydb"].ConnectionString;


        public OtherDetails()
        {
            InitializeComponent();
        }

        private void OtherDetails_Load(object sender, EventArgs e)
        {
            gettingMonth = comboBoxMonth.Text;
            gettingYear = comboBoxYear.Text;
            //if else (user did not select month or year
            comboBoxMonth.SelectedIndex = 0;
            comboBoxYear.SelectedIndex = 0;

            //I will have to automatically display the value based on the month
            MaxMonthlyAttendance = GetDays(comboBoxMonth.Text, comboBoxYear.Text);
            textBoxAttendance.Text = MaxMonthlyAttendance.ToString();
            //autoAttendanceText = textBoxAttendance.Text;
            radiono.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaxMonthlyAttendance = GetDays(comboBoxMonth.Text, comboBoxYear.Text);
            textBoxAttendance.Text = textBoxAttendance.Text;



            ActualAttendance = int.Parse(textBoxAttendance.Text);

            Form ffff = Application.OpenForms["Home"];
            employee_name = ((Home)ffff).EmpName;

            

            string folderPath = $@"F:\Salary_Slips\{employee_name}";
            Directory.CreateDirectory(folderPath);

            string pdfPath = $@"{folderPath}\{employee_name}_SalarySlip_{comboBoxMonth.Text}{comboBoxYear.Text}.pdf";
           
            //string watermarkText = "Watermark Text";


            try
                {
                    // Create a watermark

                    iText.Kernel.Pdf.PdfWriter write = new iText.Kernel.Pdf.PdfWriter(pdfPath);
                    PdfDocument pdf = new PdfDocument(write);
                    pdf.AddNewPage();

                    iText.Layout.Document document = new iText.Layout.Document(pdf);
                    //*********************************************************

                    string imagepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "log6.png");


                    //string imagepath = Application.StartupPath + "\\Resources" + "\\log6.png";

                    string imagepath2 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo2.png");
                    //string imagepath2 = Application.StartupPath + "\\Resources" + "\\logo2.png";





                    iText.Layout.Element.Image logo2 = new iText.Layout.Element.Image(ImageDataFactory.Create(imagepath));


                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(imagepath2));
                    logo.SetHeight(30);
                    logo.SetWidth(120);
                    logo.SetFixedPosition(76, 738);


                    Form f = Application.OpenForms["Home"];
                    EmployeeName = ((Home)f).EmpName;
                    EmpCode = ((Home)f).EmpCode;
                    Designation = ((Home)f).Designation;
                    DateOfJoining = ((Home)f).DateOfJoining;

                    //Changing format of DateTime(DateOfJoining)
                    string originalDate = DateOfJoining.ToString(); // Assuming DateOfJoining is a DateTime object
                    DateTime dt = DateTime.ParseExact(originalDate, "dd-MMM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    string reformattedDate = dt.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);

                    Pan = ((Home)f).Pan;
                    EmpAddress = ((Home)f).EmpAddress;
                    TotalCTC = double.Parse(((Home)f).TotalCTC);
                    EmpBasic = double.Parse(((Home)f).EmpBasic);
                    EmpHra = double.Parse(((Home)f).EmpHra);
                    EmpTA = double.Parse(((Home)f).EmpTA);
                    OtherAllowance = double.Parse(((Home)f).OtherAllowance);
                    MedicalAllowance = double.Parse(((Home)f).MedicalAllowance);
                    RemoteWorkAllowance = double.Parse(((Home)f).RemoteWorkAllowance);
                    Bonus = double.Parse(((Home)f).Bonus);
                    PF = double.Parse(((Home)f).PF);
                    ESIC = double.Parse(((Home)f).ESIC);
                    Loan = double.Parse(((Home)f).Loan);
                    Advance = double.Parse(((Home)f).Advance);
                    Other = double.Parse(((Home)f).Other);
                    TDS = double.Parse(((Home)f).TDS);
                    TotalEarnings = double.Parse(((Home)f).TotalEarnings);
                    Deductions = double.Parse(((Home)f).TotalDeductions);
                    NetPayable = double.Parse(((Home)f).NetPayable);








                    EmpBasic = (EmpBasic * ActualAttendance) / MaxMonthlyAttendance;


                    EmpHra = (EmpHra * ActualAttendance) / MaxMonthlyAttendance;

                    EmpTA = (EmpTA * ActualAttendance) / MaxMonthlyAttendance;
                    if (EmpTA < 0)
                    {
                        EmpTA = 0;
                    }

                    OtherAllowance = (OtherAllowance * ActualAttendance) / MaxMonthlyAttendance;
                    if (OtherAllowance < 0)
                    {
                        OtherAllowance = 0;
                    }
                    MedicalAllowance = (MedicalAllowance * ActualAttendance) / MaxMonthlyAttendance;
                    RemoteWorkAllowance = (RemoteWorkAllowance * ActualAttendance) / MaxMonthlyAttendance;
                    Bonus = (Bonus * ActualAttendance) / MaxMonthlyAttendance;

                    if (radioyes.Checked == true)
                    {
                        TDS = (TDS * ActualAttendance) / MaxMonthlyAttendance;
                    }

                    //MonthlySalary = TotalCTC / 12;
                    //MonthlySalary = (MonthlySalary * ActualAttendance) / MaxMonthlyAttendance;

                    TotalEarnings = (TotalEarnings * ActualAttendance) / MaxMonthlyAttendance;

                    Deductions = PF + ESIC + Loan + Advance + Other + TDS;
                    NetPayable = TotalEarnings - Deductions;

                    string InWords = ConvertRoundedDoubleToWords(NetPayable);

                    string FormattedEmpBasic;
                    if (EmpBasic == 0)
                    {
                        FormattedEmpBasic = "0";
                    }
                    else
                    {

                        /* FormattedEmpBasic = EmpBasic.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedEmpBasic = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", EmpBasic);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedEmpBasic = string.Format(hindi, "{0:#,#}", EmpBasic);
                        //FormattedEmpBasic = EmpBasic.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedEmpBasic = EmpBasic.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }
                    string FormattedEmpHra;
                    if (EmpHra == 0)
                    {
                        FormattedEmpHra = "0";
                    }
                    else
                    {
                        /* FormattedEmpHra = EmpHra.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedEmpHra = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", EmpHra);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedEmpHra = string.Format(hindi, "{0:#,#}", EmpHra);
                        // FormattedEmpHra = EmpHra.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedEmpHra = EmpHra.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedEmpTA;
                    if (EmpTA == 0)
                    {
                        FormattedEmpTA = "0";
                    }
                    else
                    {
                        /* FormattedEmpTA = EmpTA.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedEmpTA = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", EmpTA);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedEmpTA = string.Format(hindi, "{0:#,#}", EmpTA);
                        //FormattedEmpTA = EmpTA.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedEmpTA = EmpTA.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedOtherAllowance;
                    if (OtherAllowance == 0)
                    {
                        FormattedOtherAllowance = "0";
                    }
                    else
                    {
                        /* FormattedOtherAllowance = OtherAllowance.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedOtherAllowance = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", OtherAllowance);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedOtherAllowance = string.Format(hindi, "{0:#,#}", OtherAllowance);
                        // FormattedOtherAllowance = OtherAllowance.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedOtherAllowance = OtherAllowance.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }
                    string FormattedMedicalAllowance;
                    if (MedicalAllowance == 0)
                    {
                        FormattedMedicalAllowance = "0";
                    }
                    else
                    {
                        /*FormattedMedicalAllowance = MedicalAllowance.ToString("#,#", CultureInfo.InvariantCulture);
                        FormattedMedicalAllowance = String.Format(CultureInfo.InvariantCulture,
                                                        "{0:#,#}", MedicalAllowance);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedMedicalAllowance = string.Format(hindi, "{0:#,#}", MedicalAllowance);
                        //FormattedMedicalAllowance = MedicalAllowance.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedMedicalAllowance = MedicalAllowance.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedRemoteWorkAllowance;
                    if (RemoteWorkAllowance == 0)
                    {
                        FormattedRemoteWorkAllowance = "0";
                    }
                    else
                    {
                        /*FormattedRemoteWorkAllowance = RemoteWorkAllowance.ToString("#,#", CultureInfo.InvariantCulture);
                        FormattedRemoteWorkAllowance = String.Format(CultureInfo.InvariantCulture,
                                                        "{0:#,#}", RemoteWorkAllowance);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedRemoteWorkAllowance = string.Format(hindi, "{0:#,#}", RemoteWorkAllowance);
                        //FormattedRemoteWorkAllowance = RemoteWorkAllowance.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedRemoteWorkAllowance = RemoteWorkAllowance.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }
                    string FormattedBonus;
                    if (Bonus == 0)
                    {
                        FormattedBonus = "0";
                    }
                    else
                    {
                        /*FormattedBonus = Bonus.ToString("#,#", CultureInfo.InvariantCulture);
                        FormattedBonus = String.Format(CultureInfo.InvariantCulture,
                                                        "{0:#,#}", Bonus);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedBonus = string.Format(hindi, "{0:#,#}", Bonus);
                        //FormattedBonus = Bonus.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedBonus = Bonus.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedPF;
                    if (PF == 0)
                    {
                        FormattedPF = "0";
                    }
                    else
                    {
                        /* FormattedPF = PF.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedPF = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", PF);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedPF = string.Format(hindi, "{0:#,#}", PF);
                        //FormattedPF = PF.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedPF = PF.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedESIC;
                    if (ESIC == 0)
                    {
                        FormattedESIC = "0";
                    }
                    else
                    {
                        /* FormattedESIC = ESIC.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedESIC = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", ESIC);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedESIC = string.Format(hindi, "{0:#,#}", ESIC);
                        //FormattedESIC = ESIC.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedESIC = ESIC.ToString("#,0.00", CultureInfo.InvariantCulture);
                    }

                    string FormattedLoan;
                    if (Loan == 0)
                    {
                        FormattedLoan = "0";
                    }
                    else
                    {
                        /* FormattedLoan = Loan.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedLoan = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", Loan);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedLoan = string.Format(hindi, "{0:#,#}", Loan);
                        //FormattedLoan = Loan.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedLoan = Loan.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedAdvance;
                    if (Advance == 0)
                    {
                        FormattedAdvance = "0";
                    }
                    else
                    {
                        /*FormattedAdvance = Advance.ToString("#,#", CultureInfo.InvariantCulture);
                        FormattedAdvance = String.Format(CultureInfo.InvariantCulture,
                                                        "{0:#,#}", Advance);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedAdvance = string.Format(hindi, "{0:#,#}", Advance);
                        //FormattedAdvance = Advance.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedAdvance = Advance.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedOther;
                    if (Other == 0)
                    {
                        FormattedOther = "0";
                    }
                    else
                    {
                        /* FormattedOther = Other.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedOther = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", Other);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedOther = string.Format(hindi, "{0:#,#}", Other);
                        //FormattedOther = Other.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedOther = Other.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedTDS;
                    if (TDS == 0)
                    {
                        FormattedTDS = "0";
                    }
                    else
                    {
                        /* FormattedTDS = TDS.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedTDS = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", TDS);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedTDS = string.Format(hindi, "{0:#,#}", TDS);
                        //FormattedTDS = TDS.ToString("0.00", CultureInfo.InvariantCulture);
                        //FormattedTDS = TDS.ToString("#,0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedTotalEarnings;
                    if (TotalEarnings == 0)
                    {
                        FormattedTotalEarnings = "0";
                    }
                    else
                    {
                        /* FormattedTotalEarnings = TotalEarnings.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedTotalEarnings = String.Format(CultureInfo.InvariantCulture,
                                                           "{0:#,#}", TotalEarnings);
 */
                        //decimal parsed = decimal.Parse(TotalEarnings, CultureInfo.InvariantCulture);

                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedTotalEarnings = string.Format(hindi, "{0:#,#}", TotalEarnings);
                        //FormattedTotalEarnings = TotalEarnings.ToString("0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedTotalDeductions;
                    if (Deductions == 0)
                    {
                        FormattedTotalDeductions = "0";
                    }
                    else
                    {
                        /* FormattedTotalDeductions = TotalDeductions.ToString("#,#", CultureInfo.InvariantCulture);
                         FormattedTotalDeductions = String.Format(CultureInfo.InvariantCulture,
                                                         "{0:#,#}", TotalDeductions);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedTotalDeductions = string.Format(hindi, "{0:#,#}", Deductions);
                        //FormattedTotalDeductions = TotalDeductions.ToString("0.00", CultureInfo.InvariantCulture);

                    }

                    string FormattedNetPayable;
                    if (NetPayable == 0)
                    {
                        FormattedNetPayable = "0";
                    }
                    else
                    {
                        /*FormattedNetPayable = NetPayable.ToString("#,#", CultureInfo.InvariantCulture);
                        FormattedNetPayable = string.Format(CultureInfo.InvariantCulture, "{0:#,##,###}", NetPayable);*/
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        FormattedNetPayable = string.Format(hindi, "{0:#,#}", NetPayable);
                        //FormattedNetPayable = NetPayable.ToString("0.00", CultureInfo.InvariantCulture);

                    }




                    logo2.SetFixedPosition(5, 410);
                    logo2.SetOpacity(0.1f);
                    logo2.SetRotationAngle(Math.PI * 35 / 180);
                    logo2.SetWidth(560).SetHeight(130).SetPadding(200);




                    //************************************************
                    Div container = new Div();
                    container.SetMarginTop(26);

                    float colFirst = 1700f;
                    float[] colWidthFirst = { colFirst };
                    Table firstTable = new Table(colWidthFirst)
                        .SetHeight(90)
                        .SetBorder(new SolidBorder(0.8f))
                        .SetMarginRight(40).SetMarginLeft(40).SetMarginTop(10);
                    Cell cellFirst = new Cell()
                        .Add(logo).SetBorder(Border.NO_BORDER);
                    firstTable.AddCell(cellFirst);

                    float colTop1 = 500f;
                    float colTop2 = 1700f;
                    float[] colWidthTop = { colTop1, colTop2 };
                    Table tableTop = new Table(colWidthTop)

                        .SetHeight(65)
                       .SetMarginBottom(0)
                         .SetMarginLeft(35).SetMarginRight(35).SetBorderTop(new SolidBorder(0.8f)).SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f)).SetBorderBottom(new SolidBorder(0.5f));
                    Cell cell = new Cell()
                        .SetPaddingTop(12)
                        .SetPaddingRight(90)
                        .SetBorder(Border.NO_BORDER)
                        .Add(logo);


                    Cell cell2 = new Cell(1, 1)
                         .SetPaddingTop(5)
                         .SetPaddingRight(35)
    .SetBorder(Border.NO_BORDER)
    .SetTextAlignment(TextAlignment.CENTER)
    .Add(new Paragraph()
         .SetFontSize(9)
        //.SetPaddingRight(120)
        .Add("ATF LABS PRIVATE LIMITED")
        .SetBold()
    )
    .Add(new Paragraph("Office1: 6/2A,Galib Pura,MG Road, Near Hariparwat Police Station, Agra,U.P-282002\n" +
                "Office2: Shahtoot Marg, Block A, Sector 26A, Gurugram, Haryana 122002\n\n"))
    .Add(new Paragraph()
        .SetTextAlignment(TextAlignment.RIGHT) // Align this to the right
        .Add("Contact Number:- 8126394316")
    )
    .SetFontSize(7);





                    tableTop.AddCell(cell);
                    tableTop.AddCell(cell2);


                    //iText.Kernel.Colors.Color customColor = new DeviceRgb(174, 214, 241);
                    iText.Kernel.Colors.Color customColor = new DeviceRgb(191, 201, 202);

                    float col2 = 600f;
                    float[] colWidth2 = { col2, col2 };
                    Table table2 = new Table(colWidth2);
                    table2.SetMarginLeft(35).SetMarginRight(35)
                        .SetBackgroundColor(customColor)
                        .SetBorderTop(new SolidBorder(0.5f))
                        .SetMarginTop(0)
                       .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));

                    gettingMonth = comboBoxMonth.Text;
                    gettingMonth = gettingMonth.ToUpper();
                    gettingYear = comboBoxYear.Text;
                    gettingYear = gettingYear.ToUpper();
                    Cell cell21 = new Cell(1, 2).Add(new Paragraph("SALARY SLIP FOR THE MONTH " + gettingMonth + " " + gettingYear))
                        .SetFontSize(10)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER);

                    table2.AddCell(cell21);




                    float col11 = 200f;
                    float col12 = 590f;
                    float col13 = 500f;
                    float col14 = 300f;
                    float[] colWidth = { col11, col12, col13, col14 };
                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 19, 31, 25, 25 }))
                         .SetWidth(UnitValue.CreatePercentValue(100))
                        .SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)


                       .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));
                    Cell cell11 = new Cell()

                        .SetBorderRight(new SolidBorder(0.8f))
                        .SetBold()

                        .Add(new Paragraph("Name\nDesignation\nDate of Joining\nEmployee Code"));
                    Cell cell12 = new Cell()

                        .SetBorderRight(new SolidBorder(0.8f))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph(EmployeeName + "\n" + Designation + "\n" + reformattedDate + "\n" + EmpCode + "\n"));
                    Cell cell13 = new Cell()

                         .SetBorderRight(new SolidBorder(0.8f))
                         .SetBold()
                         .Add(new Paragraph("Days in a month\nAttendance\nPAN"));
                    Cell cell14 = new Cell()
                         .SetBorderRight(new SolidBorder(0.8f))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph(MaxMonthlyAttendance + "\n" + ActualAttendance + "\n" + Pan));


                    table.AddCell(cell11);
                    table.AddCell(cell12);
                    table.AddCell(cell13);
                    table.AddCell(cell14);


                    ////////
                    float col91 = 400f;
                    float col92 = 490f;
                    float col93 = 500f;
                    float col94 = 100f;
                    float[] colWidth9 = { col91, col92, col93, col94 };
                    Table table9 = new Table(UnitValue.CreatePercentArray(new float[] { 30, 20, 25, 25 }))
                         .SetWidth(UnitValue.CreatePercentValue(100))
                          .SetBackgroundColor(customColor)
                        .SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)
                        .SetBold()

                        .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));

                    Cell cell911 = new Cell()
                        .SetBold()
                        .SetBorderRight(new SolidBorder(0.8f))
                        .Add(new Paragraph("Earnings"));
                    Cell cell912 = new Cell()
                         .SetBold()
                         .SetBorderRight(new SolidBorder(0.8f))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph("Amount in Rs"));
                    Cell cell913 = new Cell()
                          .SetBold()
                         .SetBorderRight(new SolidBorder(0.8f))
                         .Add(new Paragraph("Deductions"));
                    Cell cell914 = new Cell()
                         .SetBold()
                         .SetBorderRight(new SolidBorder(0.8f))
                         .SetTextAlignment(TextAlignment.LEFT)
                         .Add(new Paragraph("Amount in Rs"));


                    table9.AddCell(cell911);
                    table9.AddCell(cell912);
                    table9.AddCell(cell913);
                    table9.AddCell(cell914);


                    float col331 = 400f;
                    float col332 = 490f;
                    float col333 = 500f;
                    float col334 = 100f;
                    float[] colwidth31 = { col331, col332, col333, col334 };
                    Table table31 = new Table(UnitValue.CreatePercentArray(new float[] { 30, 20, 25, 25 })).SetWidth(UnitValue.CreatePercentValue(100));
                    table31.SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)
                        .SetBorder(Border.NO_BORDER)

                        .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));

                    Cell cell311 = new Cell()
                        .SetBorderRight(new SolidBorder(0.8f))
                        .SetBold()
                        .Add(new Paragraph("Basic\nHRA\nTA\nOther Allowance\nMedical Allowance\nRemote work allowance\nBonus"));
                    Cell cell312 = new Cell()
                         .SetBorderRight(new SolidBorder(0.8f))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph(FormattedEmpBasic + "\n" + FormattedEmpHra + "\n" + FormattedEmpTA + "\n" + FormattedOtherAllowance + "\n" + FormattedMedicalAllowance + "\n" + FormattedRemoteWorkAllowance + "\n" + FormattedBonus));
                    Cell cell313 = new Cell()
                         .SetBorderRight(new SolidBorder(0.8f))
                         .SetBold()
                         .Add(new Paragraph("PF\nESIC\nLoan\nAdvance\nOther\nTDS"));
                    Cell cell314 = new Cell()
                         .SetBorderRight(new SolidBorder(0.8f))
                        .SetTextAlignment(TextAlignment.LEFT)
                        .Add(new Paragraph(FormattedPF + "\n" + FormattedESIC + "\n" + FormattedLoan + "\n" + FormattedAdvance + "\n" + FormattedOther + "\n" + FormattedTDS));

                    table31.AddCell(cell311);
                    table31.AddCell(cell312);
                    table31.AddCell(cell313);
                    table31.AddCell(cell314);


                    float col431 = 500f;
                    float col432 = 300f;
                    float col433 = 600f;
                    float col434 = 300f;
                    float[] colwidth41 = { col431, col432, col433, col434 };
                    Table table41 = new Table(UnitValue.CreatePercentArray(new float[] { 30, 20, 25, 25 })).SetWidth(UnitValue.CreatePercentValue(100))
                         .SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)
                         .SetBold()

                          .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));

                    Cell cell411 = new Cell()
                        .SetFontSize(9)
                        .SetBold()
                        .SetBorderRight(new SolidBorder(0.8f))
                        .Add(new Paragraph("Total Earnings(A)"));
                    Cell cell412 = new Cell()
                         .SetBold()
                        .SetTextAlignment(TextAlignment.LEFT)
                         .SetBorderRight(new SolidBorder(0.8f))
                          .SetBackgroundColor(customColor)
                         .Add(new Paragraph("" + FormattedTotalEarnings));
                    Cell cell413 = new Cell()
                        .SetFontSize(9)
                        .SetBold()
                         .SetBorderRight(new SolidBorder(0.8f))
                         .Add(new Paragraph("Total Deductions(B)"));
                    Cell cell414 = new Cell()
                         .SetBold()
                         .SetTextAlignment(TextAlignment.LEFT)
                         .SetBackgroundColor(customColor)
                         .Add(new Paragraph("" + FormattedTotalDeductions));
                    table41.AddCell(cell411);
                    table41.AddCell(cell412);
                    table41.AddCell(cell413);
                    table41.AddCell(cell414);


                    float col531 = 500f;
                    float col532 = 300f;
                    float col533 = 600f;
                    float col534 = 300f;
                    float[] colwidth51 = { col531, col532, col533, col534 };
                    Table table51 = new Table(UnitValue.CreatePercentArray(new float[] { 30, 20, 25, 25 })).SetWidth(UnitValue.CreatePercentValue(100))
                         .SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)
                         .SetBold()
                         .SetBorderBottom(new SolidBorder(0.8f))
                         .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));

                    Cell cell511 = new Cell()
                        .SetFontSize(9)
                        .SetBorderRight(new SolidBorder(0.8f))
                        .Add(new Paragraph("Net Payable(A-B)"));
                    Cell cell512 = new Cell()
                        .SetTextAlignment(TextAlignment.LEFT)
                         .SetBorderRight(new SolidBorder(0.8f))
                          .SetBackgroundColor(customColor)
                         .Add(new Paragraph("" + FormattedNetPayable));
                    Cell cell513 = new Cell()
                        .SetBorderRight(new SolidBorder(0.8f))
                       .Add(new Paragraph(""));
                    Cell cell514 = new Cell()
                         .SetTextAlignment(TextAlignment.CENTER)
                         .Add(new Paragraph(""));

                    table51.AddCell(cell511);
                    table51.AddCell(cell512);
                    table51.AddCell(cell513);
                    table51.AddCell(cell514);


                    float col611 = 10f;
                    float col612 = 1690f;

                    float[] colwidth6 = { col611, col612 };
                    Table table61 = new Table(UnitValue.CreatePercentArray(new float[] { 10, 80 })).SetWidth(UnitValue.CreatePercentValue(100))
                        .SetMarginLeft(35).SetMarginRight(35).SetFontSize(9)
                        .SetBold()
                        //.SetBorderBottom(new SolidBorder(0.8f))
                        .SetBorderBottom(new SolidBorder(0.8f))
                         .SetBorderRight(new SolidBorder(0.8f)).SetBorderLeft(new SolidBorder(0.8f));
                    Cell cell611 = new Cell()
                       .SetBorder(Border.NO_BORDER)
                       .Add(new Paragraph("In words:-"));
                    Cell cell612 = new Cell()
                          .SetBorder(Border.NO_BORDER)
                         .Add(new Paragraph(InWords + " rupees only"));

                    table61.AddCell(cell611);
                    table61.AddCell(cell612);

                    iText.Kernel.Colors.Color customColor2 = new DeviceRgb(224, 224, 224);
                    float col711 = 1200f;
                    float col712 = 500f;
                    float[] colwidhbottom = { col711, col712 };
                    Table table71 = new Table(colwidhbottom)
                       //.SetBackgroundColor(customColor2)
                       .SetMarginLeft(35).SetMarginRight(35).SetFontSize(7)
                       .SetBold().SetMarginTop(80);
                    Cell celllast = new Cell()
                        .SetItalic()
                        .SetFontSize(7)
                        .SetBorder(Border.NO_BORDER).SetFontColor(ColorConstants.BLACK)

                        .Add(new Paragraph("*THIS IS A SYSTEM GENERATED PAYSLIP AND DOES NOT REQUIRE SIGNATURE*"));
                    Cell cellbottom = new Cell()
                        .SetBorder(Border.NO_BORDER)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetFontColor(ColorConstants.BLUE)
                        .SetFontSize(8)
                        .SetPaddingRight(5)
                        .Add(new Paragraph("https://atf-labs.com"));
                    table71.AddCell(celllast);
                    table71.AddCell(cellbottom);


                    /* table2.SetBorderTop(new SolidBorder(1f)).SetBorderBottom(new SolidBorder(0.3f));
                     table.SetBorderTop(new SolidBorder(0.3f)).SetBorderTop(new SolidBorder(1f));
                     table9.SetBorderTop(new SolidBorder(1f)).SetBorderTop(new SolidBorder(1f));
                     table31.SetBorderTop(new SolidBorder(1f)).SetBorderTop(new SolidBorder(1f));
                     table41.SetBorderTop(new SolidBorder(1f)).SetBorderTop(new SolidBorder(1f));
                     table51.SetBorderTop(new SolidBorder(1f)).SetBorderTop(new SolidBorder(1f));
                     table61.SetBorderTop(new SolidBorder(1f)).SetBorderTop(new SolidBorder(1f));*/

                    //table71.SetBorderTop(new SolidBorder(1f));


                    container.Add(tableTop);
                    container.Add(table2);
                    container.Add(table);
                    container.Add(table9);
                    container.Add(table31);
                    container.Add(table41);
                    container.Add(table51);
                    container.Add(table61);
                    container.Add(table71);

                    /* document.Add(tableTop);
                     document.Add(table2);
                     document.Add(table);
                     document.Add(table9);
                     document.Add(table31);
                     document.Add(table41);
                     document.Add(table51);
                     document.Add(table61);
                     document.Add(table71);*/


                    //document.Add(new AreaBreak());



                    //document.Add(logo2);
                    document.Add(container);
                    /*Creating watermark*/
                    PdfCanvas canvas = new PdfCanvas(pdf.GetPage(1));

                    PdfFont font = PdfFontFactory.CreateFont(FontProgramFactory.CreateFont(StandardFonts.HELVETICA));
                    Paragraph paragraph = new Paragraph("ATF LABS")
                            .SetFont(font)
                            .SetFontColor(ColorConstants.BLACK)
                            .SetRotationAngle(120)
                            .SetWidth(1000)
                            .SetOpacity(0.15f)
                            .SetFontSize(50);

                    Canvas canvasWatermark = new Canvas(canvas, pdf.GetPage(1).GetPageSize())
                        .ShowTextAligned(paragraph, 280, 925, 1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                    document.Close();

                    //gs1.SetFillOpacity(0.5f);
                    //canvas.SetExtGState(gs1);

                    //pdf.Close();
                    //MessageBox.Show("Pdf Generated");
                    MessageBox.Show("Salary Slip is generated");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"I/O Exception: {ex.Message}");
                }
            
        }
        static string ConvertRoundedDoubleToWords(double number)
        {
            // Round the double to the nearest whole number
            long roundedNumber = (long)Math.Round(number);

            // Convert the rounded number to words
            string words = NumberToWords(roundedNumber);

            return words;
        }

        static string NumberToWords(long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "negative " + NumberToWords(-number);

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (!string.IsNullOrEmpty(words))
                    words += "and ";

                string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static int GetDays(string month, string year)
        {
            if (month == "January")
            {
                return 31;
            }
            else if (month == "February")
            {
                int febdays = int.Parse(year);
                if (febdays % 4 == 0 || febdays % 400 == 0)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            else if (month == "March")
            {
                return 31;
            }
            else if (month == "April")
            {
                return 30;
            }
            else if (month == "May")
            {
                return 31;
            }
            else if (month == "June")
            {
                return 30;
            }
            else if (month == "July")
            {
                return 31;
            }
            else if (month == "August")
            {
                return 31;
            }
            else if (month == "September")
            {
                return 30;
            }
            else if (month == "October")
            {
                return 31;
            }
            else if (month == "November")
            {
                return 30;
            }
            else
            {
                return 31;
            }

        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int attendancedays = GetDays(comboBoxMonth.Text, comboBoxYear.Text);
            textBoxAttendance.Text = attendancedays.ToString();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int attendancedays = GetDays(comboBoxMonth.Text, comboBoxYear.Text);
            textBoxAttendance.Text = attendancedays.ToString();
        }

    }
}