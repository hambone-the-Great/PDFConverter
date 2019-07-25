using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PDFConverter
{
    public partial class progress : Form
    {
        Form1 oform;
        public string TargetDir;
        string[] Files;
        public int fileCount;
        //public bool subDirs;
        public int pdfCount;

        public progress(Form1 _form, string[] _files, string _target)
        {
            InitializeComponent();
            oform = _form;
            Files = _files; 
            TargetDir = _target;
            //subDirs = _subDirs;
            this.AcceptButton = btnOk;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void progress_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            btnOk.Visible = false;            
        }

        private void ConvertToPdf(BackgroundWorker worker, DoWorkEventArgs e)
        {
           
            int totalCount = Files.Length;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    pdfCount = 0;

                    for (int i = 0; i < Files.Length; i++)
                    {
                        string file = Files[i];
                        string dir = Path.GetDirectoryName(file);
                        string name = Path.GetFileNameWithoutExtension(file);
                        string ext = Path.GetExtension(file);
                        if (ext == ".xps" || ext == ".oxps") //we're triple checking the extension here.....necessary??
                        {                            
                            string pdfFile = dir + "\\" + name + ".pdf";

                            if (!File.Exists(pdfFile))
                            {
                                PdfSharp.Xps.XpsConverter.Convert(file, pdfFile, 0);
                                pdfCount++;
                            }

                            int percentComplete = (int)((float)(i + 1) / totalCount * 100);
                            worker.ReportProgress(percentComplete);                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //MessageBox.Show("Done! " + files.Length + " files converted to PDF in " + TargetDir);         

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            ConvertToPdf(worker, e);
        }

        private void progress_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            fileCount = Files.Length;
            progressBar1.Minimum = 1;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
            progressBar1.Maximum = fileCount;

            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
            lblPercentComplete.Text = (e.ProgressPercentage.ToString() + "%");            

            if (e.ProgressPercentage == 100)
            {
                progressBar1.Value = progressBar1.Maximum;
                lblMsg.Text = "Done! " + Environment.NewLine + fileCount + " files reviewed. " + Environment.NewLine + pdfCount + " files converted to PDF in " + TargetDir;
                lblMsg.Visible = true;
                btnOk.Visible = true;                
            }            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            this.Close();

            oform.DeleteOriginals(Files);

        }

        private void CloseItDown()
        {
            var proc = new ProcessStartInfo();
            proc.FileName = TargetDir;
            proc.Verb = "open";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc);            
            oform.ClearAll();
            oform.Activate();
            oform.BringToFront();
        }

        private void progress_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseItDown();
        }
    }
}
