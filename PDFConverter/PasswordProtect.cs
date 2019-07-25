using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp;
using System.IO;

namespace PDFConverter
{
    public partial class PasswordProtect : Form
    {
        public PasswordProtect()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(PasswordProtect_DragEnter);
            this.DragDrop += new DragEventHandler(PasswordProtect_DragDrop);

            txtPassword1.Enabled = false;
            txtPassword2.Enabled = false;
            btnSubmit.Enabled = false;
            this.AcceptButton = btnSubmit; 

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string file = txtSelected.Text;

                if (!string.IsNullOrEmpty(file))
                {

                    PdfSharp.Pdf.PdfDocument doc = PdfSharp.Pdf.IO.PdfReader.Open(file);

                    PdfSharp.Pdf.Security.PdfSecuritySettings securitySettings = doc.SecuritySettings;

                    if (txtPassword1.Text == txtPassword2.Text)
                    {
                        // Setting one of the passwords automatically sets the security level to 
                        // PdfDocumentSecurityLevel.Encrypted128Bit.
                        securitySettings.UserPassword = txtPassword1.Text;
                        securitySettings.OwnerPassword = txtPassword2.Text;

                        //Don't use 40 bit encryption unless needed for compatibility reasons
                        //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

                        // Restrict some rights.
                        securitySettings.PermitAccessibilityExtractContent = false;
                        securitySettings.PermitAnnotations = false;
                        securitySettings.PermitAssembleDocument = false;
                        securitySettings.PermitExtractContent = false;
                        securitySettings.PermitFormsFill = true;
                        securitySettings.PermitFullQualityPrint = false;
                        securitySettings.PermitModifyDocument = true;
                        securitySettings.PermitPrint = false;

                        // Save the document...
                        doc.Save(file);

                        MessageBox.Show("Password set successfully. Please don't forget your password. This file cannot be opened without the password.");

                        clearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Passwords don't match. No changes have been saved.");
                        clearPasswordBoxes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void clearTextBoxes()
        {
            txtSelected.Text = "";
            txtPassword1.Text = "";
            txtPassword2.Text = "";
            txtPassword1.Enabled = false;
            txtPassword2.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void clearPasswordBoxes()
        {
            txtPassword1.Text = "";
            txtPassword2.Text = "";
        }

        private void PasswordProtect_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void PasswordProtect_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string file = files[0];

            if (!string.IsNullOrEmpty(file))
            {
                if (file.Contains(".pdf"))
                {
                    txtSelected.Text = file;
                    txtPassword1.Enabled = true;
                    txtPassword2.Enabled = true;
                    btnSubmit.Enabled = true;
                    txtPassword1.Focus();                    
                }
                else
                {
                    MessageBox.Show("Only PDF Files please.");
                }
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files (*.pdf)|*.pdf";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSelected.Text = ofd.FileName;
                if (!string.IsNullOrEmpty(txtSelected.Text))
                {
                    txtPassword1.Enabled = true;
                    txtPassword2.Enabled = true;
                    btnSubmit.Enabled = true;
                    txtPassword1.Focus();
                }
            }

        }


    }
}
