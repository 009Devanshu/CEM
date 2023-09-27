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
using iText.Kernel.Events;

namespace CEM
{
    public partial class Invoice_Form : DevExpress.XtraEditors.XtraForm
    {
        string client_name;
        string client_company;
        string client_address;
        string client_gst;
        string initial_gst_number;
        string client_country;
       

        //converting amout,cgst,igst,sgst into string
        string amountstring;
        string IGSTstring;
        string CGSTstring;
        string SGSTstring;

        string your_company;
        string your_gst;
        string your_lut;
        string your_cin;
        string your_email;

        //Fields for Bank Details
        string AccountName;
        string AccountNumber;
        string IFSC;
        string SWIFT;
        string BankName;
        string BankAddress;
        int using_invoice_num;
        int invoice_number;


        //DataSource Fiels
        string path = System.Configuration.ConfigurationManager.
                        ConnectionStrings["mydb"].ConnectionString;
        private SqlConnection conn;
        SqlCommand cmd;
       
        public Invoice_Form()
        {
            InitializeComponent();
            conn = new SqlConnection(path);
           
        }

        private void Invoice_Form_Load(object sender, EventArgs e)
        {

            string load_invoice_number;

            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();

                string query = "select name from company";



                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming YourColumnName is of type string
                            string columnValue = reader["name"].ToString();
                            comboBoxCompany.Items.Add(columnValue);
                        }
                    }
                }
            }
            comboBoxCompany.SelectedIndex = 0;
            comboBank.SelectedIndex = 0;
            comboCurrency.SelectedIndex = 0;
            comboEmail.SelectedIndex = 0;

           

            txtamount.Text = "0";
            txtitemname.Text = "Software Developer";
            

            //Filling Text Fields for client
            ClientDetails f= Application.OpenForms["ClientDetails"] as ClientDetails;
            client_name =  ((ClientDetails)f).client_name;
            client_company =  ((ClientDetails)f).company_name;
            client_address=((ClientDetails)f).client_address;
            //load_invoice_number = ((ClientDetails)f).invoice_number;
            client_gst = ((ClientDetails)f).client_gst;
            client_country = ((ClientDetails)f).client_country;
          
            
            initial_gst_number = client_gst.Substring(0, 2);
            

            if (initial_gst_number == "09")
            {
                rbtnwithinstate.Checked = true;
            }
            else if(initial_gst_number!="09" && client_country != "India")
            {
                rbtnigstforeign.Checked = true;    
            }
            else
            {
                rbtninterstate.Checked = true;
            }
           
            client_country  = ((ClientDetails)f).client_country;
            //txtinvoicenumber.Text= (int.Parse(load_invoice_number) + 1).ToString();

           
          

            client_gst = ((ClientDetails)f).client_gst;

            dateTimePicker1.Format = DateTimePickerFormat.Short;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                    }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string path = System.Configuration.ConfigurationManager.
                                ConnectionStrings["mydb"].ConnectionString;


            

             using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();

                string query = "update client set invoice_number=" + int.Parse(txtinvoicenumber.Text) + " where name='" + client_name + "'";

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                connection.Close();
            }


           

           

            string YourCompanyName=comboBoxCompany.Text;

            using (SqlConnection connection = new SqlConnection(path))
            {
                connection.Open();

                string query = "select gst,lut,cin from company where name='"+YourCompanyName+"'" ;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming YourColumnName is of type string
                            your_gst = reader["gst"].ToString();
                            your_lut = reader["lut"].ToString();
                            your_cin = reader["cin"].ToString();
                        }
                    }
                }


            }


           
           
            DateTime InvoiceDate = DateTime.Parse(dateTimePicker1.Text);
           
            double Subtotoal = double.Parse(txtenteramount.Text);

            double CGST= (Subtotoal * 9) / 100;
            double SGST = (Subtotoal * 9) / 100;
            double IGST = (Subtotoal * 18) / 100;
            double total = 0;
            if (rbtnwithinstate.Checked == true)
            {
                total = Subtotoal + SGST + CGST;
            }
            else if (rbtninterstate.Checked == true)
            {
                total = Subtotoal + IGST;
            }
            else if (rbtnigstforeign.Checked == true)
            {
                total = Subtotoal + IGST;
            }
            string AccountName = "";
            string AccountNumber = "5063700002797";
            string IFSC = "YESB0000050";
            string SWIFT = "YESBINBBXXX";
            string BankName = "Yes Bank Ltd";
            string BankAddress = "Sanjay Place, Agra";



            //Changing format of DateTime(DateOfJoining)
            string originalDate = InvoiceDate.ToString(); // Assuming DateOfJoining is a DateTime object
            DateTime dt = DateTime.ParseExact(originalDate, "dd-MMM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            string reformattedDate = dt.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
            
            
            
            //Creating pdf with iText7 library
            //string client_name =  txtclient.Text;

            var folderPath = $"C:\\InvoiceReports\\{client_name}_SalarySlips";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF File";

            saveFileDialog.InitialDirectory = folderPath; // Set the initial directory to your created folder

            saveFileDialog.FileName = $"{client_name}_invoice_.pdf";

            string CompanyLogoImagepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "painted-logo3.png");
            iText.Layout.Element.Image  CompanyLogo= new iText.Layout.Element.Image(ImageDataFactory.Create(CompanyLogoImagepath));
            CompanyLogo.SetHeight(30);
            CompanyLogo.SetWidth(120);
            //CompanyLogo.SetFixedPosition(430, 780);

            string IconImagepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "email-icon.png");
            iText.Layout.Element.Image icon = new iText.Layout.Element.Image(ImageDataFactory.Create(IconImagepath));
            icon.SetHeight(12);
            icon.SetWidth(12);
           

            string RupeesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "rupee.png");
            iText.Layout.Element.Image RupeeIcon = new iText.Layout.Element.Image(ImageDataFactory.Create(RupeesPath));
            RupeeIcon.SetHeight(9);
            RupeeIcon.SetWidth(12);

            string BankIconPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "bank.png");
            iText.Layout.Element.Image BankIcon = new iText.Layout.Element.Image(ImageDataFactory.Create(BankIconPath));
            BankIcon.SetHeight(20);
            BankIcon.SetWidth(20);
            

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont2 = PdfFontFactory.CreateFont(StandardFonts.COURIER);

            string fontPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "IndianRupee.ttf");
            PdfFont customFont = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

         

            Paragraph TotalParagraph=null;
            Paragraph SubtotalParagraph = null;
            Paragraph CGSTParagraph = null;
            Paragraph SGSTParagraph = null;
            Paragraph IGSTParagraph = null; 
            if (comboCurrency.SelectedIndex == 0)
            {
                TotalParagraph = new Paragraph().Add(new Text("\u20B9").SetFont(customFont)).Add(" " + total).SetTextAlignment(TextAlignment.LEFT);
                SubtotalParagraph = new Paragraph().Add(new Text("\u20B9").SetFont(customFont)).Add(" " + Subtotoal).SetTextAlignment(TextAlignment.LEFT);
                CGSTParagraph = new Paragraph().Add(new Text("\u20B9").SetFont(customFont)).Add(" " + CGST).SetTextAlignment(TextAlignment.LEFT);
                SGSTParagraph = new Paragraph().Add(new Text("\u20B9").SetFont(customFont)).Add(" " + SGST).SetTextAlignment(TextAlignment.LEFT);
                IGSTParagraph = new Paragraph().Add(new Text("\u20B9").SetFont(customFont)).Add(" " + IGST).SetTextAlignment(TextAlignment.LEFT);
            }
            if (comboCurrency.SelectedIndex == 1)
            {
                TotalParagraph = new Paragraph().Add(new Text("$")).Add(" " + total).SetTextAlignment(TextAlignment.LEFT);
                SubtotalParagraph = new Paragraph().Add(new Text("$")).Add(" " + Subtotoal).SetTextAlignment(TextAlignment.LEFT);
                CGSTParagraph = new Paragraph().Add(new Text("$")).Add(" " + CGST).SetTextAlignment(TextAlignment.LEFT);
                SGSTParagraph = new Paragraph().Add(new Text("$")).Add(" " + SGST).SetTextAlignment(TextAlignment.LEFT);
                IGSTParagraph = new Paragraph().Add(new Text("$")).Add(" " + IGST).SetTextAlignment(TextAlignment.LEFT);
            }

          

           

           
 


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfPath = saveFileDialog.FileName;

                try
                {

                    // Set a custom page width and height
                    float pageWidth = 595f; 
                    float pageHeight = 750f;


                    iText.Kernel.Pdf.PdfWriter write = new iText.Kernel.Pdf.PdfWriter(pdfPath);
                    PdfDocument pdf = new PdfDocument(write);

                    // Set the custom page size
                    pdf.GetDefaultPageSize().SetWidth(pageWidth);
                    pdf.GetDefaultPageSize().SetHeight(pageHeight);


                    iText.Layout.Document document = new iText.Layout.Document(pdf);
                   

                    document.SetLeftMargin(0);
                    
                   

                    float col11 = 300f;
                    float col12 = 300f;
                    float[] colWidth1 = { col11, col12 };
                    Table table1 = new Table(colWidth1)
                           
                        .SetWidth(100)
                        .SetMarginLeft(25)
                        .SetWidth(595);
                        

                    Cell cell11 = new Cell(1, 1)
                      
                        .SetFontSize(20)
                        .SetBold()
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph("TAX INVOICE"));
                    Cell cell12 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetPaddingLeft(120)
                      
                        .Add(CompanyLogo);

                    table1.AddCell(cell11);
                    table1.AddCell(cell12);

                    float col2 = 300f;
                    float[] colwidth2 = { col2, col2 };
                    Table table2 = new Table(colwidth2)
                        .SetBorder(Border.NO_BORDER)
                        .SetMarginLeft(25)
                        .SetMarginTop(14);
                    Cell cell21 = new Cell(1,2)
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph().SetFontSize(14).Add(YourCompanyName))
                        .Add(new Paragraph().SetFontSize(9).Add("Hari Parwat Crossing, Agra - UP, India").SetStrokeWidth(10f).SetStrokeColor(ColorConstants.BLUE));
                    table2.AddCell(cell21);


                    float col31 = 15f;
                    float col32 = 300f;
                    float[] colwidth3 = { col31, col32 };
                    Table table3 = new Table(colwidth3)
                        .SetMarginLeft(25);
                       
                    //.SetMarginTop(3);
                    Cell cell31 = new Cell(1, 2)
                        .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph().SetFontSize(8).Add("GST: " + your_gst))
                    .Add(new Paragraph().SetFontSize(8).Add("LUT: " + your_lut))
                    .Add(new Paragraph().SetFontSize(8).Add("CIN:  " + your_cin));

                    Cell cell32 = new Cell(1, 1)
                       
                        .SetBorder(Border.NO_BORDER)
                        .SetFontSize(9)
                        .SetPaddingRight(0)
                        .Add(icon);
                    Cell cell33 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetFontSize(9)
                        .SetPaddingTop(1)
                        .Add(new Paragraph("devanshu.official09@gmail.com"));
                    table3.AddCell(cell31);
                    table3.AddCell(cell32);
                    table3.AddCell(cell33);

                    iText.Kernel.Colors.Color customColor = new DeviceRgb(222, 238, 237);

                    float col41 = 495f;
                    float col42 = 100f;
                    float[] colwidth4 = { col41, col42 };
                    Table table4 = new Table(colwidth4)

                         .SetWidth(595)
                         .SetMarginTop(20)
                        .SetHeight(60)
                        .SetFontSize(8)
                        .SetBackgroundColor(customColor);

                    Cell cell41 = new Cell(1, 1)
                         .SetBorder(Border.NO_BORDER)
                        .SetPaddingLeft(25)
                        .SetPaddingTop(15)
                        .SetFontSize(9)
                        .Add(new Paragraph("Invoice No: "+"FY23-24/"+txtinvoicenumber.Text).SetFont(boldFont))
                        .Add(new Paragraph("Invoice Date: "+ reformattedDate).SetFont(boldFont));
                    Cell cell42 = new Cell(1,1)

                       
                       
                        .SetBorder(Border.NO_BORDER)
                        .SetPaddingTop(9)
                      
                        .SetTextAlignment(TextAlignment.LEFT)
                      
                      
                        .Add(new Paragraph().Add("AMOUNT").SetFontSize(12).SetFont(boldFont))
                          .Add(new Paragraph().Add(TotalParagraph).SetFontSize(11).SetFont(boldFont));
                    table4.AddCell(cell41);
                    table4.AddCell(cell42);

                    float col51 = 300f;
                    float col52 = 300f;
                    float[] colwidth5 = {col51,col52};
                    Table table5 = new Table(colwidth5)
                         .SetMarginTop(25);
                   
                    Cell cell51 = new Cell(1,2)
                         .SetPaddingLeft(25)
                        .SetBorder(Border.NO_BORDER)
                        .SetFont(boldFont)
                        .Add(new Paragraph().Add("BILL TO:"))
                        .Add(new Paragraph().Add("").SetFontSize(9).SetPaddingTop(6))
                        .Add(new Paragraph().Add("").SetFontSize(9))
                        .Add(new Paragraph().Add(""+", "+"").SetFontSize(9))
                        .Add(new Paragraph().Add("GST: "+client_gst).SetFontSize(9));
                    table5.AddCell(cell51);

                    float col61 = 300f;
                    float col62 = 300f;
                    float[] colwidth6 = { col61, col62 };
                    Table table6 = new Table(colwidth6)

                         .SetWidth(595)
                         .SetMarginTop(20)
                        .SetHeight(25)
                        .SetFontSize(8)
                        .SetBackgroundColor(customColor);

                    Cell cell61 = new Cell(1, 1)
                         .SetBorder(Border.NO_BORDER)
                        .SetPaddingLeft(25)
                        .SetPaddingTop(7)
                        .SetFontSize(9)
                        .Add(new Paragraph("ITEMS AND DESCRIPTION"));

                    
                    Cell cell62 = new Cell(1, 1)



                        .SetBorder(Border.NO_BORDER)
                        .SetPaddingTop(7)
                        .SetFontSize(9)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetPaddingRight(25)
                        .Add(new Paragraph().Add("AMOUNT").SetFontSize(10).SetPaddingRight(25).SetFont(boldFont));
                    table6.AddCell(cell61);
                    table6.AddCell(cell62);

                    float col71 = 200f;
                    float col72 = 195f;
                    float col73 = 106f;
                    float col74 = 94f;
                    float[] colwidth7 = { col71, col72, col73, col74 };
                    Table table7 = new Table(colwidth7)
                        .SetMarginTop(5)
                       
                         .SetWidth(595)
                       
                        .SetFontSize(8);


                    Cell cell71 = new Cell(1, 1)
                       
                        .SetBorder(Border.NO_BORDER)
                        .SetBorderBottom(new SolidBorder(0.5f))
                        .SetPaddingLeft(25)
                        .SetFontSize(10)
                        .Add(new Paragraph().Add(txtitemname.Text).SetStrokeWidth(2).SetStrokeColor(ColorConstants.BLACK))
                        .Add(new Paragraph().Add(txtdescription.Text).SetFontSize(8));

                    Cell cell72 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetBorderBottom(new SolidBorder(0.5f))
                        .SetPaddingLeft(25)
                        .SetFontSize(10);

                    Cell cell73 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetBorderBottom(new SolidBorder(0.5f))
                        .SetPaddingLeft(25)
                        .SetFontSize(10);
                        


                    Cell cell74 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetBorderBottom(new SolidBorder(0.5f))
                        
                        .SetFontSize(11)
                        .Add(SubtotalParagraph);
                    table7.AddCell(cell71);
                    table7.AddCell(cell72);
                    table7.AddCell(cell73);
                    table7.AddCell(cell74);

                    float col81 = 200f;
                    float col82 = 195f;
                    float col83 = 106f;
                    float col84 = 94f;
                    float[] colwidth8 = { col81, col82, col83, col84 };
                    Table table8 = new Table(colwidth8)
                         
                         .SetWidth(595)
                       
                        //.SetHeight(35)
                        .SetFontSize(8);
                       

                    Cell cell81 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                       
                        .SetPaddingLeft(25)
                        
                        .SetFontSize(9)
                        .Add(new Paragraph(""));

                    Cell cell82 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetPaddingTop(10)
                        .SetFontSize(10)
                        .SetTextAlignment(TextAlignment.LEFT);
                    Cell cell83 = null;
                    if (rbtninterstate.Checked == true)
                    {
                        cell83 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        
                        //.SetFontSize(10)
                        
                        .SetPaddingRight(25)
                        .Add(new Paragraph().Add("Subtotal          ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT))
                         .Add(new Paragraph().Add("IGST(18%)            ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT));
                    }
                    if (rbtnwithinstate.Checked == true)
                    {
                        cell83 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                      
                        //.SetFontSize(10)
                       
                        .SetPaddingRight(25)
                        .Add(new Paragraph().Add("Subtotal          ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT))
                        .Add(new Paragraph().Add("CGST(9%)          ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT))
                        .Add(new Paragraph().Add("SGST(9%)          ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT));


                    }
                    if (rbtnigstforeign.Checked == true)
                    {
                        cell83 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                      
                        //.SetFontSize(9)
                      
                        .SetPaddingRight(25)
                        .Add(new Paragraph().Add("Subtotal          ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT))
                         .Add(new Paragraph().Add("IGST(18%)            ").SetFontSize(9).SetPaddingRight(25).SetTextAlignment(TextAlignment.LEFT));

                    }

                    Cell cell84 =null;
                    if (rbtninterstate.Checked == true)
                    {
                        cell84 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                       
                        .SetFontSize(9)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPaddingRight(25)
                        .Add(SubtotalParagraph)
                         .Add(IGSTParagraph);
                    }

                    if (rbtnwithinstate.Checked == true)
                    {
                        cell84 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        
                        .SetFontSize(9)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPaddingRight(25)
                        .Add(SubtotalParagraph)
                         .Add(CGSTParagraph)
                        .Add(SGSTParagraph);
                     

                    }
                    if (rbtnigstforeign.Checked == true)
                    {
                        cell84 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        
                        .SetFontSize(9)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPaddingRight(25)
                        .Add(SubtotalParagraph)
                         .Add(IGSTParagraph);

                    }
                    table8.AddCell(cell81);
                    table8.AddCell(cell82);
                    table8.AddCell(cell83);
                    table8.AddCell(cell84);

                    float col91 = 200f;
                    float col92 = 195f;
                    float col93 = 106f;
                    float col94 = 94f;
                    float[] colwidth9 = { col91, col92, col93, col94 };
                    Table table9 = new Table(colwidth9)

                         .SetWidth(595)

                        //.SetHeight(35)
                        .SetFontSize(8);


                    Cell cell91 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetPaddingLeft(25)

                        .SetFontSize(9)
                        .Add(new Paragraph(""));

                    Cell cell92 = new Cell(1, 1)
                       .SetBorder(Border.NO_BORDER)
                       .SetPaddingLeft(25)

                       .SetFontSize(9)
                       .Add(new Paragraph(""));
                    Cell cell93 = new Cell(1, 1)
                       .SetBorder(Border.NO_BORDER)
                        .SetBorderTop(new SolidBorder(0.5f))
                     

                       .SetFontSize(11)
                       .Add(new Paragraph("Total")).SetTextAlignment(TextAlignment.LEFT);
                    Cell cell94 = new Cell(1, 1)



                        .SetBorder(Border.NO_BORDER)
                        .SetBorderTop(new SolidBorder(0.5f))
                        .SetFontSize(11)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetPaddingRight(25)
                       
                        .Add(TotalParagraph);
                    table9.AddCell(cell91);
                    table9.AddCell(cell92);
                    table9.AddCell(cell93);
                    table9.AddCell(cell94);

                    float col101 = 300f;
                    float col102 = 300f;
                    float[] colwidth10 = { col101, col102 };
                    Table table10 = new Table(colwidth5)
                         .SetMarginTop(40);

                    Cell cell101 = new Cell(1, 2)
                        
                        .SetBorder(Border.NO_BORDER)
                          .SetPaddingLeft(25)
                        .Add(BankIcon);

                  

                    Cell cell102 = new Cell(1, 2)
                        .SetBorder(Border.NO_BORDER)
                          .SetPaddingLeft(25)
                          //.SetFontColor(ColorConstants.DARK_GRAY)
                          .SetFontSize(9)
                          //.SetFontColor(ColorConstants.DARK_GRAY)
                          .SetFont(boldFont2)
                        .Add(new Paragraph().Add("Account Name    :"+AccountName))
                        .Add(new Paragraph().Add("Account Number  :"+AccountNumber)).SetPaddingTop(4)
                        .Add(new Paragraph().Add("IFSC Code       :"+IFSC)).SetPaddingTop(4)
                        .Add(new Paragraph().Add("SWIFT Code      :"+SWIFT)).SetPaddingTop(4)
                        .Add(new Paragraph().Add("Bank Name       :"+BankName)).SetPaddingTop(4)
                        .Add(new Paragraph().Add("Bank Address    :"+BankAddress)).SetPaddingTop(4);
                    table10.AddCell(cell101);
                    table10.AddCell(cell102);


                   



                    float col111 = 800f;
                    float col112 = 300f;
                    float[] colwidth11 = { col111,col112};
                    Table table11 = new Table(colwidth11)
                          .SetFixedPosition(0, 0, 595)
                         .SetWidth(595)
                         

                        .SetFontSize(8)
                        .SetBackgroundColor(customColor);

                    Cell cell111 = new Cell(1, 2)
                        .SetBorder(Border.NO_BORDER)
                        .SetHeight(13)                      
                        
                        .SetPaddingTop(7)
                        
                        .SetFontSize(13)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPaddingBottom(0)
                        .Add(new Paragraph().Add("*Thank you for your business*").SetFontSize(8));


                  

                    Cell cell112 = new Cell(1, 1)
                        .SetBorder(Border.NO_BORDER)
                        .SetHeight(20)
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.RIGHT)
                        .SetMarginBottom(0)
                        .Add(new Paragraph().Add("*This is a Computer generated invoice and does not require signature*").SetFontSize(7).SetFontColor(ColorConstants.DARK_GRAY));
                    Cell cell113 = new Cell(1, 1)
                       .SetBorder(Border.NO_BORDER)
                      
                        .SetMarginBottom(0f)
                       .SetFontSize(11)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph().Add("https://atf-labs.com").SetFontSize(7).SetFontColor(ColorConstants.BLUE));

                   
                   

                    table11.AddCell(cell111);
                    table11.AddCell(cell112);
                    table11.AddCell(cell113);

                    document.Add(table1);
                    document.Add(table2);
                    document.Add(table3);
                    document.Add(table4);
                    document.Add(table5);
                    document.Add(table6);
                    document.Add(table7);
                    document.Add(table8);
                    document.Add(table9);
                    document.Add(table10);
                    document.Add(table11);
                    document.Close();

                    MessageBox.Show("Pdf is created");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }










            /*amount =  double.Parse(txtamount.Text);
           
            if (rbtninterstate.Checked==true)
            {
                IGST = (amount * 18) / 100;

            }
            else if (rbtnwithinstate.Checked == true)
            {
                CGST = (amount * 9) / 100;
                SGST = (amount * 9) / 100;
            }
            amountstring = amount.ToString();
            IGSTstring = IGST.ToString();
            CGSTstring = CGST.ToString();
            SGSTstring = SGST.ToString();

            InvoiceReport invoiceReport = new InvoiceReport();
            if (rbtnCompany1.Checked == true)
            {
               
                using (SqlConnection conn = new SqlConnection(path))
                {
                    try
                    {
                        conn.Open();

                        // Check if there is a record with the same name
                        string query = "SELECT * FROM company INNER JOIN account ON company.company_id = account.accountId WHERE name = 'ATF Labs Private Limited'";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                your_gst = reader["gst"].ToString();
                               
                                your_lut = reader["lut"].ToString();
                                your_cin = reader["cin"].ToString();
                            }
                            else
                            {
                                // Handle the case where no records match the condition.
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., database connection error, query error)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }

                

                invoiceReport.Parameters["pMyCompany"].Value = "ATF LABS Pvt Ltd";
                your_company = invoiceReport.Parameters["pMyCompany"].Value.ToString();
                invoiceReport.Parameters["pYourGST"].Value=your_gst;
                //your_gst = invoiceReport.Parameters["pYourGST"].Value.ToString();
                
                //Getting Email
                invoiceReport.Parameters["pYourEmail"].Value = comboEmail.Text;
                your_email = invoiceReport.Parameters["pYourEmail"].Value.ToString();
            }
            if(rbtncompany2.Checked == true)
            {
                invoiceReport.Parameters["pMyCompany"].Value = "Alliance Techno Functionals";
                your_company = invoiceReport.Parameters["pMyCompany"].Value.ToString();
            }

           

            invoiceReport.Parameters["pClientName"].Value = txtclient.Text;
            invoiceReport.Parameters["pClientCompanyName"].Value = txtcompany.Text;
            invoiceReport.Parameters["pCompanyAddress"].Value = txtaddress.Text;

            invoiceReport.Parameters["pClientGST"].Value =client_gst;
            client_gst =invoiceReport.Parameters["pClientGST"].Value.ToString();

            invoiceReport.Parameters["pTotalAmount"].Value = amountstring;
            
            invoiceReport.Parameters["pCGST"].Value = CGSTstring;
            invoiceReport.Parameters["pSGST"].Value = SGSTstring;
            invoiceReport.Parameters["pIGST"].Value = IGSTstring;
            //client_gst =   invoiceReport.Parameters["pClientGST"].Value.ToString();
            if (CGST != 0)
            {
                invoiceReport.Parameters["pCGSTText"].Value = "CGST";
                CGSTText = invoiceReport.Parameters["pCGSTText"].Value.ToString();

                invoiceReport.Parameters["pIGSTText"].Value = "";
                IGSTText = invoiceReport.Parameters["pIGSTText"].Value.ToString();
                IGSTstring = "";
            }
            if(SGST != 0)
            {
                invoiceReport.Parameters["pSGSTText"].Value = "SGST";
                SGSTText = "SGST"; 
            }
            if (IGST != 0)
            {
                invoiceReport.Parameters["pIGSTText"].Value = "IGST";
                IGSTText = invoiceReport.Parameters["pIGSTText"].Value.ToString();

                invoiceReport.Parameters["pCGSTText"].Value = "";
                CGSTText = invoiceReport.Parameters["pCGSTText"].Value.ToString();
                CGSTstring = "";
                invoiceReport.Parameters["pSGSTText"].Value = "";
                SGSTText = invoiceReport.Parameters["pSGSTText"].Value.ToString();
                SGSTstring = "";
            }

            //Bank Details
            if (comboBank.Text == "HDFC Bank")
            {
                invoiceReport.Parameters["pAccountName"].Value = "ATF LABS PRIVATE LIMITED";
                invoiceReport.Parameters["pAccountNumber"].Value = "50200059520889";
                invoiceReport.Parameters["pIFSC"].Value = "HDFC0000121";
                invoiceReport.Parameters["pSWIFT"].Value = "HDFCINBBXXX";
                invoiceReport.Parameters["pBankName"].Value = "HDFC Bank";
                invoiceReport.Parameters["pBankAddress"].Value = "Sanjay Place,Agra-282002,UP,India";

                AccountName = "ATF LABS PRIVATE LIMITED";
                AccountNumber = "50200059520889";
                IFSC = "HDFC0000121";
                SWIFT = "HDFCINBBXXX";
                BankName = "HDFC Bank"; 
                BankAddress = "Sanjay Place,Agra-282002,UP,India";
            }

            if (comboBank.Text == "Yes Bank")
            {
                invoiceReport.Parameters["pAccountName"].Value = "ATF Labs Pvt Ltd";
                invoiceReport.Parameters["pAccountNumber"].Value = "5063700002797";
                invoiceReport.Parameters["pIFSC"].Value = "YESB0000050";
                invoiceReport.Parameters["pSWIFT"].Value = "YESBINBBXXX";
                invoiceReport.Parameters["pBankName"].Value = "Yes Bank Ltd.";
                invoiceReport.Parameters["pBankAddress"].Value = "Sanjay Place,Agra";

                AccountName = "ATF Labs Pvt Ltd";
                AccountNumber = "5063700002797";
                IFSC = "YESB0000050";
                SWIFT = "YESBINBBXXX";
                BankName = "Yes Bank Ltd.";
                BankAddress = "Sanjay Place,Agra";
            }

            InvoiceReport report = new InvoiceReport();
            PdfExportOptions pdfOptions = report.ExportOptions.Pdf;
            // Specify the pages to export.
            pdfOptions.PageRange = "1, 3-5";

            // Specify the quality of exported images.
            pdfOptions.ConvertImagesToJpeg = false;
            pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

            // Specify the PDF/A-compatibility.
            pdfOptions.PdfACompatibility = PdfACompatibility.PdfA3b;

            // Specify the document options.
            pdfOptions.DocumentOptions.Application = "Test Application";
            pdfOptions.DocumentOptions.Author = "DX Documentation Team";
            pdfOptions.DocumentOptions.Keywords = "DevExpress, Reporting, PDF";
            pdfOptions.DocumentOptions.Producer = Environment.UserName.ToString();
            pdfOptions.DocumentOptions.Subject = "Document Subject";
            pdfOptions.DocumentOptions.Title = "Document Title";

            IList<string> result = pdfOptions.Validate();

            if (result.Count > 0)
                Console.WriteLine(String.Join(Environment.NewLine, result));
            else
            {
                report.CreateDocument();
                if (ExportOptionsTool.EditExportOptions(pdfOptions, report.PrintingSystem)
                    == DialogResult.OK)
                {
                    report.ExportToPdf("C:\\Users\\devan\\Downloads\\result.pdf", pdfOptions);
                    // ...
                }
            }

           *//* using (Print print = new Print())
            {
                print.PrintInvoice(your_company,client_name, your_gst, your_lut, your_cin,your_email,client_company,client_address,client_gst,amount,CGSTstring,SGSTstring,IGSTstring,SGSTText,CGSTText,IGSTText,
                    AccountName,AccountNumber,IFSC,SWIFT,BankName,BankAddress);
                print.ShowDialog();
            }*/

        }

        private void rbtnCompany1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbtnoutsideno_CheckedChanged(object sender, EventArgs e)
        {
            
              
           
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}