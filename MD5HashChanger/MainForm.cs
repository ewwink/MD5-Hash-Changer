using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace MD5_Hash_Changer
{
    public partial class MainForm : Form
    {
        public int currentRowIndex = 0;
        public bool running = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Multiselect = true;
            bool flag = selectFile.ShowDialog() == DialogResult.OK;
            if (flag)
            {
                int totalFiles = selectFile.FileNames.Length;
                labelItem.Text = "0";
                labelTotalItem.Text = totalFiles.ToString();
                progressBarStatus.Value = 0;
                progressBarStatus.Maximum = totalFiles;
                Thread t = new Thread(() => checkMD5(selectFile.FileNames));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            dgvMD5.Rows.Clear();
            labelItem.Text = "0";
            labelTotalItem.Text = "0";
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMD5.SelectedRows)
            {
                dgvMD5.Rows.RemoveAt(row.Index);
            }
            dgvMD5.ClearSelection();
            labelItem.Text = "0";
            labelTotalItem.Text = dgvMD5.RowCount.ToString();
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
            int totalFiles = dgvMD5.RowCount;
            string[] fileNames = new string[totalFiles];
            for (int i = 0; i < totalFiles; i++)
            {
                fileNames[i] = dgvMD5.Rows[i].Cells[0].Value.ToString();
            }
            labelItem.Text = "0";
            labelTotalItem.Text = totalFiles.ToString();
            progressBarStatus.Value = 0;
            progressBarStatus.Maximum = totalFiles;
            btnStartMD5.Enabled = false;
            btnStartMD5.Text = "Stop Change MD5";
            Thread t = new Thread(() => changeMD5(fileNames));
            t.IsBackground = true;
            t.Start();
        }

        private void changeMD5(string[] fileNames)
        {
            Random random = new Random();
            Thread.Sleep(1000);
            this.Invoke((MethodInvoker)delegate()
            {
                this.btnStartMD5.Enabled = true;
            });

            for (int i = 0; i < fileNames.Length; i++)
            {
                if (!running)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        this.btnStartMD5.Text = "Start Change MD5";
                        running = false;
                    });
                    break;
                }
                int num = random.Next(2, 7);
                byte[] array = new byte[num];
                for (int j = 0; j < num; j++)
                {
                    array[j] = (byte)0;
                }
                bool flag = new FileInfo(fileNames[i]).Length == 0L;
                if (flag)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        this.dgvMD5.Rows[i].Cells[3].Value = "Empty";
                    });
                }
                else
                {
                    using (FileStream fileStream = new FileStream(fileNames[i], FileMode.Append))
                    {
                        fileStream.Write(array, 0, array.Length);
                    }
                    using (MD5 md = MD5.Create())
                    {
                        using (FileStream fileStream2 = File.OpenRead(fileNames[i]))
                        {
                            string value = BitConverter.ToString(md.ComputeHash(fileStream2)).Replace("-", "");
                            this.Invoke((MethodInvoker)delegate()
                            {
                                bool flag2 = this.dgvMD5.Rows[i].Cells[2].Value.ToString() != "";
                                if (flag2)
                                {
                                    this.dgvMD5.Rows[i].Cells[1].Value = this.dgvMD5.Rows[i].Cells[2].Value;
                                }
                                this.labelItem.Text = (i + 1).ToString();
                                this.progressBarStatus.Value = i + 1;
                                this.dgvMD5.Rows[i].Cells[2].Value = value;
                                this.dgvMD5.Rows[i].Cells[3].Value = "OK";
                            });
                        }
                    }
                }
            }
            this.Invoke((MethodInvoker)delegate()
            {
                this.btnStartMD5.Text = "Start Change MD5";
                running = false;
            });
        }

        private void checkMD5(string[] fileNames)
        {
            int index = 0;
            foreach (string name in fileNames)
            {
                string md5hash = "";
                using (MD5 md = MD5.Create())
                {
                    using (FileStream fileStream = File.OpenRead(name))
                    {
                        md5hash = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "");
                    }
                }
                this.Invoke((MethodInvoker)delegate()
                {
                    index++;
                    this.labelItem.Text = index.ToString();
                    this.progressBarStatus.Value = index;
                    this.dgvMD5.Rows.Add(new object[] { name, md5hash, "", "idle" });
                    this.dgvMD5.Rows[0].Selected = false;
                });
            }
        }

        private void contextMenuCopyRow_Click(object sender, EventArgs e)
        {
            string rowData = "";
            for (int i = 0; i < dgvMD5.RowCount; i++)
            {
                var rows = dgvMD5.Rows[i];
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
                for (int i = 0; i < dgvMD5.RowCount; i++)
                {
                    var rows = dgvMD5.Rows[i];
                    rowData += string.Format("{0},{1},{2}\r\n", rows.Cells[0].Value, rows.Cells[1].Value, rows.Cells[2].Value);
                }
                File.WriteAllText(savefile.FileName, rowData);
            }
        }

        private void contextMenuOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(dgvMD5.Rows[currentRowIndex].Cells[0].Value.ToString());
            }
            catch { }
        }

        private void dgvMD5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentRowIndex = dgvMD5.HitTest(e.X, e.Y).RowIndex;
                if (currentRowIndex > -1 && dgvMD5.Rows[currentRowIndex].Selected)
                {
                    contextMenuCopyRow.Enabled = true;
                    contextMenuOpenFile.Enabled = true;
                    contextMenudgvMD5.Show(dgvMD5, new Point(e.X, e.Y));
                }
                else if (dgvMD5.RowCount > 0)
                {
                    contextMenuCopyRow.Enabled = false;
                    contextMenuOpenFile.Enabled = false;
                    contextMenudgvMD5.Show(dgvMD5, new Point(e.X, e.Y));
                }
            }
        }
    }
}