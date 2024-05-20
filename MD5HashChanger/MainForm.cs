/*
 * 
 * Source code: https://github.com/ewwink/MD5-Hash-Changer 
 * 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5_Hash_Changer
{
    public partial class MainForm : Form
    {
        public int currentRowIndex = 0;
        public int totalFiles = 0;
        public bool running = false;
        public int[] randomByteLength = { 1, 7 };

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dataGridFileMD5.Rows.Clear();
            totalFiles = 0;
            labelItem.Text = "0";
            labelTotalItem.Text = "0";
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            totalFiles -= dataGridFileMD5.SelectedRows.Count;
            foreach (DataGridViewRow row in dataGridFileMD5.SelectedRows)
            {
                dataGridFileMD5.Rows.RemoveAt(row.Index);
            }
            dataGridFileMD5.ClearSelection();
            labelItem.Text = "0";
            labelTotalItem.Text = dataGridFileMD5.RowCount.ToString();
        }
        private void Additem(Dictionary<string, int> filesToCheck)
        {
            Thread threading = new Thread(() =>
            {
                int index = 0;
                int maxThread = filesToCheck.Count > Environment.ProcessorCount ? Environment.ProcessorCount : filesToCheck.Count;
                Parallel.ForEach(filesToCheck, new ParallelOptions { MaxDegreeOfParallelism = maxThread }, item =>
                {
                    string md5hash = GetMD5Hash(item.Key);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.labelItem.Text = index.ToString();
                        this.progressBarStatus.Value = index;
                        this.dataGridFileMD5.Rows[item.Value].SetValues(new object[] { item.Key, md5hash, "", "idle" });
                        this.dataGridFileMD5.Rows[0].Selected = false;
                    });
                });
                //threading.Abort();
            })
            {
                IsBackground = true
            };
            threading.Start();
        }
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog selectFile = new OpenFileDialog())
            {
                selectFile.Multiselect = true;
                bool flag = selectFile.ShowDialog() == DialogResult.OK;
                if (flag)
                {
                    totalFiles += selectFile.FileNames.Length;
                    labelItem.Text = "0";
                    labelTotalItem.Text = totalFiles.ToString();
                    progressBarStatus.Value = 0;
                    progressBarStatus.Maximum = totalFiles;
                    var filesToCheck = new Dictionary<string, int>();
                    foreach (string filename in selectFile.FileNames)
                    {
                        int rowIndex = this.dataGridFileMD5.Rows.Add(new object[] { filename, "Processing...", "", "idle" });
                        filesToCheck[filename] = rowIndex;
                    }
                    Additem(filesToCheck);
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderPicker();
            if (fbd.ShowDialog(this.Handle) == true)
            {
                var filesToCheck = new Dictionary<string, int>();
                foreach (string filename in Directory.GetFiles(fbd.ResultPath))
                {
                    int rowIndex = this.dataGridFileMD5.Rows.Add(new object[] { filename, "Processing...", "", "idle" });
                    filesToCheck[filename] = rowIndex;
                }
                Additem(filesToCheck);
            }
        }

        private void btnStartMD5_Click(object sender, EventArgs e)
        {
            if (btnStartMD5.Text == "Stop Change MD5")
            {
                btnStartMD5.Text = "Start Change MD5";
                running = false;
                return;
            }
            running = true;
            totalFiles = dataGridFileMD5.RowCount;
            string[] fileNames = new string[totalFiles];
            for (int i = 0; i < totalFiles; i++)
            {
                fileNames[i] = dataGridFileMD5.Rows[i].Cells[0].Value.ToString();
            }
            labelItem.Text = "0";
            labelTotalItem.Text = totalFiles.ToString();
            progressBarStatus.Value = 0;
            progressBarStatus.Maximum = totalFiles;
            btnStartMD5.Enabled = false;
            btnStartMD5.Text = "Stop Change MD5";
            Thread t = new Thread(() => ChangeMD5(fileNames))
            {
                IsBackground = true
            };
            t.Start();
        }

        private void ChangeMD5(string[] fileNames)
        {
            Random random = new Random();
            this.Invoke((MethodInvoker)delegate ()
            {
                this.btnStartMD5.Enabled = true;
            });
            int currentProgress = 0;
            Parallel.For(0, fileNames.Length, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, (index, state) =>
             {
                 if (!running)
                 {
                     this.Invoke((MethodInvoker)delegate ()
                     {
                         this.btnStartMD5.Text = "Start Change MD5";
                         running = false;
                     });
                     state.Break();
                 }
                 int byteLength = random.Next(randomByteLength[0], randomByteLength[1]);
                 byte[] extraByte = new byte[byteLength];
                 for (int j = 0; j < byteLength; j++)
                 {
                     extraByte[j] = (byte)0;
                 }
                 long fileSize = new FileInfo(fileNames[index]).Length;
                 if (fileSize == 0L)
                 {
                     this.Invoke((MethodInvoker)delegate ()
                     {
                         this.dataGridFileMD5.Rows[index].Cells[3].Value = "Empty";
                     });
                 }
                 else
                 {
                     using (FileStream fileStream = new FileStream(fileNames[index], FileMode.Append))
                     {
                         fileStream.Write(extraByte, 0, extraByte.Length);
                     }
                     string md5hash = GetMD5Hash(fileNames[index]);
                     this.Invoke((MethodInvoker)delegate ()
                     {
                         bool flag2 = this.dataGridFileMD5.Rows[index].Cells[2].Value.ToString() != "";
                         if (flag2)
                         {
                             this.dataGridFileMD5.Rows[index].Cells[1].Value = this.dataGridFileMD5.Rows[index].Cells[2].Value;
                         }
                         currentProgress++;
                         this.labelItem.Text = (currentProgress).ToString();
                         this.progressBarStatus.Value = currentProgress;
                         this.dataGridFileMD5.Rows[index].Cells[2].Value = md5hash;
                         this.dataGridFileMD5.Rows[index].Cells[3].Value = "OK";
                     });
                 }
             });
            this.Invoke((MethodInvoker)delegate ()
            {
                this.btnStartMD5.Text = "Start Change MD5";
                running = false;
            });
        }

        private string GetMD5Hash(string fileName)
        {
            string md5hash = "";
            long fileSize = new FileInfo(fileName).Length;
            int bufferSize = fileSize > 1048576L ? 1048576 : 4096;
            byte[] buffer;
            byte[] oldBuffer;
            int bytesRead;
            int oldBytesRead;
            long size;
            long totalBytesRead = 0;
            using (HashAlgorithm hashAlgorithm = MD5.Create())
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
                {
                    //md5hash = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "");
                    size = fileStream.Length;

                    buffer = new byte[bufferSize];

                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    totalBytesRead += bytesRead;

                    do
                    {
                        oldBytesRead = bytesRead;
                        oldBuffer = buffer;

                        buffer = new byte[bufferSize];
                        bytesRead = fileStream.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        if (bytesRead == 0)
                        {
                            hashAlgorithm.TransformFinalBlock(oldBuffer, 0, oldBytesRead);
                        }
                        else
                        {
                            hashAlgorithm.TransformBlock(oldBuffer, 0, oldBytesRead, oldBuffer, 0);
                        }

                    } while (bytesRead != 0);

                    md5hash = BitConverter.ToString(hashAlgorithm.Hash).Replace("-", "");

                }
            }
            return md5hash;
        }


        private void contextMenuCopyRow_Click(object sender, EventArgs e)
        {
            string rowData = "";
            for (int i = 0; i < dataGridFileMD5.RowCount; i++)
            {
                var rows = dataGridFileMD5.Rows[i];
                if (rows.Selected)
                {
                    rowData += string.Format("{0}\t{1}\t{2}\r\n", rows.Cells[0].Value, rows.Cells[1].Value, rows.Cells[2].Value);
                }
            }
            Clipboard.SetText(rowData);
        }

        private void contextMenuExportToCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string rowData = "";
                for (int i = 0; i < dataGridFileMD5.RowCount; i++)
                {
                    var rows = dataGridFileMD5.Rows[i];
                    rowData += string.Format("{0},{1},{2}\r\n", rows.Cells[0].Value, rows.Cells[1].Value, rows.Cells[2].Value);
                }
                File.WriteAllText(savefile.FileName, rowData);
            }
        }

        private void contextMenuOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(dataGridFileMD5.Rows[currentRowIndex].Cells[0].Value.ToString());
            }
            catch { }
        }

        private void dgvMD5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentRowIndex = dataGridFileMD5.HitTest(e.X, e.Y).RowIndex;
                if (currentRowIndex > -1 && dataGridFileMD5.Rows[currentRowIndex].Selected)
                {
                    contextMenuCopyRows.Enabled = true;
                    contextMenuDeleteRows.Enabled = true;
                    contextMenuOpenFile.Enabled = true;
                    contextMenudgvMD5.Show(dataGridFileMD5, new Point(e.X, e.Y));
                }
                else if (dataGridFileMD5.RowCount > 0)
                {
                    contextMenuCopyRows.Enabled = false;
                    contextMenuDeleteRows.Enabled = false;
                    contextMenuOpenFile.Enabled = false;
                    contextMenudgvMD5.Show(dataGridFileMD5, new Point(e.X, e.Y));
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            totalFiles += files.Length;
            var filesToCheck = new Dictionary<string, int>();
            foreach (string filename in files)
            {
                int rowIndex = dataGridFileMD5.Rows.Add(new object[] { filename, "checking", "", "idle" });
                filesToCheck[filename] = rowIndex;
                //System.Diagnostics.Debug.WriteLine(filename + ":" + rowIndex.ToString());
            }
            Additem(filesToCheck);
        }

        private void dataGridFileMD5_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == (char)Keys.Delete)
            {
                foreach (DataGridViewRow row in dataGridFileMD5.SelectedRows)
                {
                    dataGridFileMD5.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void deleteSelectedRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridFileMD5.SelectedRows)
            {
                dataGridFileMD5.Rows.RemoveAt(row.Index);
            }
        }
    }
}