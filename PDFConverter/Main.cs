using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;


namespace PDFConverter
{
    public partial class Main : Form
    {

        public string TargetDir;
        //PasswordProtect passwordProtector;

        public Main()
        {
            InitializeComponent();
            this.AcceptButton = btnConvertFiles;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.WordWrap = false;
            txtOutput.BackColor = System.Drawing.Color.White;
            btnDirSelect.Enabled = true;
            txtSelectedDir.Enabled = true;
        }

        private void btnDirSelect_Click(object sender, EventArgs e)
        {            
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.RootFolder = Environment.SpecialFolder.MyComputer;
            browser.ShowNewFolderButton = false;
            DialogResult result = browser.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(browser.SelectedPath))
            {
                txtSelectedDir.Text = browser.SelectedPath;
                TargetDir = browser.SelectedPath;
            }

            PreviewXpsFiles();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string[] xpsFiles = GetXpsFilesOnly(files);

            btnDirSelect.Enabled = false;
            txtSelectedDir.Enabled = false;
            ckBxSubDirs.Enabled = false; 
            PreviewXpsFiles(xpsFiles);
        }

        private string[] GetXpsFilesOnly(string[] files = null)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    List<string> list = new List<string>(files);

                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fi = new FileInfo(files[i]);

                        if (fi.Extension != ".xps" && fi.Extension != ".oxps")
                        {
                            list.Remove(files[i]);
                        }
                    }

                    return list.ToArray();
                }
            }

            return null; 
        }

        private void PreviewXpsFiles(string[] files = null)
        {
            try
            {
                txtOutput.Clear();
                if (files == null)
                {
                    if (!string.IsNullOrEmpty(TargetDir))
                    {
                        if (Directory.Exists(TargetDir))
                        {
                            if (ckBxSubDirs.Checked)
                            {
                                files = Directory.GetFiles(TargetDir, "*.*xps", SearchOption.AllDirectories);
                            }
                            else
                            {
                                files = Directory.GetFiles(TargetDir, "*.*xps", SearchOption.TopDirectoryOnly);
                            }
                        }
                    }                    
                }                

                string[] xpsFiles = GetXpsFilesOnly(files);

                if (xpsFiles != null)
                {
                    if (xpsFiles.Length > 0)
                    {
                        lblFileCount.Text = "File Count: " + xpsFiles.Length;

                        for (int i = 0; i < xpsFiles.Length; i++)
                        {
                            string file = xpsFiles[i];
                            string ext = Path.GetExtension(file);
                            if (ext == ".xps" || ext == ".oxps") //does it hurt to double check? ---well sometimes when you want to update it to include more file types you have to remember to update it in all places. 
                            {
                                txtOutput.AppendText(file);
                                if ((i + 1) < files.Length)
                                {
                                    txtOutput.AppendText(Environment.NewLine);
                                }
                            }
                        }
                    }
                }

                txtOutput.Text = Regex.Replace(txtOutput.Text, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConvertFiles_Click(object sender, EventArgs e)
        {

            txtOutput.Text = Regex.Replace(txtOutput.Text, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            string[] files = txtOutput.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (files.Length > 0)
            {

                if (string.IsNullOrEmpty(TargetDir))
                {
                    FileInfo file = new FileInfo(files[0]);
                    TargetDir = file.DirectoryName;
                }

                progress p = new progress(this, files, TargetDir);
                p.Show();

            }
            else
            {
                MessageBox.Show("No XPS files selected to convert to PDF.");
            }

        }

        public void ClearAll()
        {
            txtOutput.Clear();
            txtSelectedDir.Clear();
            ckBxSubDirs.Checked = false;            
            btnDirSelect.Enabled = true;
            txtSelectedDir.Enabled = true;
            ckBxSubDirs.Enabled = true;
            lblFileCount.Text = "File Count: 0";
        }

        public void DeleteOriginals(string[] files)
        {
            try
            {
                if (ckBxDeleteOrig.Checked)
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete the original files?", "Confirm Delete", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {

                        int failureCount = 0;
                        int successCount = 0;

                        for (int i = 0; i < files.Length; i++)
                        {
                            FileInfo file = new FileInfo(files[i]);
                            string targetFile = @"\\webscripta2\root\Deleted Faxes\" + file.Name;

                            if (!File.Exists(targetFile))
                            {
                                File.Move(files[i], targetFile);
                                successCount++;
                            }
                            else
                            {
                                failureCount++; 
                            }

                            if ((i + 1) == files.Length)
                            {
                                if (failureCount > 0)
                                {
                                    MessageBox.Show(successCount + " files deleted successfully." + Environment.NewLine + failureCount + " files were not deleted because they already exist in the deleted items folder. You can delete these files manually.");
                                }
                                else
                                {
                                    MessageBox.Show(successCount + " files deleted successfully.");
                                }
                                ckBxDeleteOrig.Checked = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckBxSubDirs_CheckedChanged(object sender, EventArgs e)
        {
            PreviewXpsFiles();
        }

        private void txtSelectedDir_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                TargetDir = txtSelectedDir.Text;
                PreviewXpsFiles();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void passwordProtectPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (passwordProtector == null)
            //{
            //    passwordProtector = new PasswordProtect();
            //    passwordProtector.Show();
            //}
            //else
            //{
            //    passwordProtector.BringToFront();
            //}
        }
    }
}
