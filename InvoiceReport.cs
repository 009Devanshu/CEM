using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace CEM
{
    public partial class InvoiceReport : DevExpress.XtraReports.UI.XtraReport
    {
        
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public void InitData(string your_company,string client_name,string your_gst,string your_lut,string your_cin,string your_email
                        ,string ClientCompany,string ClientAddress,string ClientGST,double amount,string cgsttextvalue,string sgsttextvalue,string igsttextvalue,string CGSTText,string SGSTText,string IGSTText,
                        string AccountName,string AccountNumber,string IFSC,string SWIFT,string BankName,string BankAddress)
        {
            pMyCompany.Value = your_company;
            pClientName.Value = client_name;
            pYourGST.Value = your_gst;
            pYourCIN.Value = your_cin;
            pYourLUT.Value = your_lut;
            pYourEmail.Value = your_email;
            pClientCompanyName.Value = ClientCompany;
            pCompanyAddress.Value = ClientAddress;
            pClientGST.Value = ClientGST;
            pTotalAmount.Value = amount;
            pCGST.Value = cgsttextvalue;
            pSGST.Value = sgsttextvalue;
            pIGST.Value = igsttextvalue;
            pCGSTText.Value = CGSTText;
            pSGSTText.Value = SGSTText;
            pIGSTText.Value = IGSTText;
            pAccountName.Value = AccountName;
            pAccountNumber.Value = AccountNumber;
            pIFSC.Value = IFSC;
            pSWIFT.Value = SWIFT;
            pBankName.Value = BankName;
            pBankAddress.Value = BankAddress;

        }
    }
}
