using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace MD5_Hash_Changer
{
    public partial class MainForm : Form
    {
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
            this.dgvMD5.Rows.Clear();
            labelItem.Text = "0";
            labelTotalItem.Text = "0";
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (object obj in this.dgvMD5.SelectedCells)
            {
                DataGridViewCell dataGridViewCell = (DataGridViewCell)obj;
                bool selected = dataGridViewCell.Selected;
                if (selected)
                {
                    this.dgvMD5.Rows.RemoveAt(dataGridViewCell.RowIndex);
                }
            }
            labelItem.Text = "0";
            labelTotalItem.Text = dgvMD5.RowCount.ToString();
        }

        private void btnStartMD5_Click(object sender, EventArgs e)
        {
            int totalFiles = dgvMD5.RowCount;
            string[] fileNames = new string[totalFiles];
            for (int i = 0; i < dgvMD5.RowCount; i++)
            {
                fileNames[i] = dgvMD5.Rows[i].Cells[0].Value.ToString();
            }
            labelItem.Text = "0";
            labelTotalItem.Text = totalFiles.ToString();
            progressBarStatus.Value = 0;
            progressBarStatus.Maximum = totalFiles;
            Thread t = new Thread(() => changeMD5(fileNames));
            t.IsBackground = true;
            t.Start();
        }

        private void changeMD5(string[] fileNames)
        {
            Random random = new Random();
            for (int i = 0; i < fileNames.Length; i++)
            {
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
                        this.dgvMD5.Rows[i].Cells[3].Value = "EMPTY";
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
    }
}