using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace SimpleFileOrganizer
{
    public partial class Form1 : Form
    {
        List<Filter> filters = new List<Filter>();
        string DirPath = "";
        string OutputDirPath = "";

        public Form1()
        {
            InitializeComponent();
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = edtDir.Text;
            DialogResult dres = dlg.ShowDialog();
            if (dres == System.Windows.Forms.DialogResult.OK)
            {
                edtDir.Text = dlg.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterEdit fe = new FilterEdit();
            DialogResult dr = fe.ShowDialog();
            if (fe.filter != null)
            {
                Filter f = fe.filter;
                filters.Add(f);

                string s = f.Action.ToString() + " [" + f.Extensions + "] " + " to \\" + f.TargetDir;
                listBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                filters.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (edtDir.Text != "" && edtOutputDir.Text != "")
            {
                // Start the download operation in the background.
                this.backgroundWorker1.RunWorkerAsync();

                // Disable the button for the duration of the download.
                this.button3.Enabled = false;
                pictureBox1.Visible = true;

                // Wait for the BackgroundWorker to finish the download.
                while (this.backgroundWorker1.IsBusy)
                {
                    // Keep UI messages moving, so the form remains 
                    // responsive during the asynchronous operation.
                    Application.DoEvents();
                }
                this.button3.Enabled = true;
                pictureBox1.Visible = false;
            }
            else
                MessageBox.Show("Choose directory!");
        }
        List<string> extentions = new List<string>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Sorter worker = new Sorter();
            //worker.Scan(filters, edtDir.Text, edtOutputDir.Text);
            Thread.Sleep(1000);
            DirPath = edtDir.Text;
            OutputDirPath = edtOutputDir.Text;            
            foreach (Filter f in filters)
            {
                string[] exts = f.Extensions.ToUpper().Trim().Replace(".","").Split(';');
                foreach (string ext in exts)
                    if (!extentions.Contains(ext))
                        extentions.Add(ext);
            }
            for (int i = 0; i < extentions.Count;i++ )
                extentions[i] = "." + extentions[i];
            ScanDir(DirPath);
        }

        private void backgroundWorker1_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                toolStripStatusLabel1.Text = "Finished!";
            }
            else
            {
                MessageBox.Show(
                    "Failed to sort files",
                    "App failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = edtOutputDir.Text;
            DialogResult dres = dlg.ShowDialog();
            if (dres == System.Windows.Forms.DialogResult.OK)
            {
                edtOutputDir.Text = dlg.SelectedPath;
            }
        }
        void ScanDir(string DirPath)
        {
            if (backgroundWorker1.CancellationPending) return;
            toolStripStatusLabel1.Text = DirPath;
            DirectoryInfo dir = new DirectoryInfo(DirPath);
            List<FileInfo> files = dir.GetFiles().ToList();

            files = files.Where(x => extentions.Contains(x.Extension.ToUpper())).ToList();
            
            foreach (FileInfo file in files)
            {
                if (backgroundWorker1.CancellationPending) return;
                ProcessFile(file);
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo di in dirs)
            {
                if (backgroundWorker1.CancellationPending) return;
                ScanDir(di.FullName);
            }
        }
        void ProcessFile(FileInfo file)
        {            
            foreach (Filter f in filters)
            {
                string[] exts = f.Extensions.ToUpper().Trim().Replace(".","").Split(';');
                string fileext= file.Extension.ToUpper().Replace(".","");
                
                if (exts.Contains(fileext))
                {
                    string targetdir = OutputDirPath + "\\" + f.TargetDir;
                    if (!Directory.Exists(targetdir))
                    {
                        Directory.CreateDirectory(targetdir);
                    }
                    Uri SourceDirectoryURI = new Uri(DirPath);
                    Uri FileDirectoryURI = new Uri(file.FullName);
                    string RelativePath = file.FullName.Replace(DirPath + @"\", "");
                    //string RelativePath = SourceDirectoryURI.MakeRelativeUri(FileDirectoryURI).ToString();
                    RelativePath = RelativePath.Replace(@"\", " - ");
                    RelativePath = RelativePath.Replace(@"/", " - ");

                    string newfile = targetdir + "\\" + RelativePath;

                    if (f.Action == RuleAction.Copy)
                    {
                        // copy file                                               
                        File.Copy(file.FullName, newfile, true);
                    }
                    else
                    {
                        // move file                                               
                        if (File.Exists(newfile))
                            File.Delete(newfile);
                        File.Move(file.FullName, newfile);
                    }
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string CurrDir = Directory.GetCurrentDirectory();
            edtDir.Text = CurrDir;
            edtOutputDir.Text = CurrDir;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                toolStripStatusLabel1.Text = "Closing...";
                Thread.Sleep(2000);
            }
        }
        
        private void edtDir_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show(edtDir.Text, edtDir);
        }

        private void edtOutputDir_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show(edtOutputDir.Text, edtOutputDir);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("Start file's organizing", button3);
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }               
    }
}
