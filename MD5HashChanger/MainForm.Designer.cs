namespace MD5_Hash_Changer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.btnStartMD5 = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.dgvMD5 = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenudgvMD5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuCopyRow = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExportToCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.labelItem = new System.Windows.Forms.Label();
            this.labelTotalItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAction = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMD5)).BeginInit();
            this.contextMenudgvMD5.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFiles.Location = new System.Drawing.Point(8, 13);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(101, 35);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "Add Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // btnStartMD5
            // 
            this.btnStartMD5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMD5.Location = new System.Drawing.Point(115, 13);
            this.btnStartMD5.Name = "btnStartMD5";
            this.btnStartMD5.Size = new System.Drawing.Size(123, 35);
            this.btnStartMD5.TabIndex = 2;
            this.btnStartMD5.Text = "Start Change MD5";
            this.btnStartMD5.UseVisualStyleBackColor = true;
            this.btnStartMD5.Click += new System.EventHandler(this.btnStartMD5_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAll.Location = new System.Drawing.Point(403, 13);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(123, 35);
            this.btnRemoveAll.TabIndex = 3;
            this.btnRemoveAll.Text = "Remove All Files";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(244, 13);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(153, 35);
            this.btnRemoveSelected.TabIndex = 4;
            this.btnRemoveSelected.Text = "Remove Selected Files";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // dgvMD5
            // 
            this.dgvMD5.AllowUserToAddRows = false;
            this.dgvMD5.AllowUserToDeleteRows = false;
            this.dgvMD5.AllowUserToResizeRows = false;
            this.dgvMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMD5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMD5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMD5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.oldMD5,
            this.newMD5,
            this.status});
            this.dgvMD5.Location = new System.Drawing.Point(12, 12);
            this.dgvMD5.Name = "dgvMD5";
            this.dgvMD5.RowHeadersVisible = false;
            this.dgvMD5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMD5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMD5.Size = new System.Drawing.Size(814, 329);
            this.dgvMD5.TabIndex = 0;
            this.dgvMD5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvMD5_MouseClick);
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.FillWeight = 148.4587F;
            this.FileName.HeaderText = "File Name";
            this.FileName.MinimumWidth = 270;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // oldMD5
            // 
            this.oldMD5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.oldMD5.DefaultCellStyle = dataGridViewCellStyle2;
            this.oldMD5.FillWeight = 103.6357F;
            this.oldMD5.HeaderText = "Old MD5";
            this.oldMD5.MinimumWidth = 220;
            this.oldMD5.Name = "oldMD5";
            this.oldMD5.ReadOnly = true;
            this.oldMD5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.oldMD5.Width = 220;
            // 
            // newMD5
            // 
            this.newMD5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.newMD5.DefaultCellStyle = dataGridViewCellStyle3;
            this.newMD5.FillWeight = 110.9225F;
            this.newMD5.HeaderText = "New MD5";
            this.newMD5.MinimumWidth = 220;
            this.newMD5.Name = "newMD5";
            this.newMD5.ReadOnly = true;
            this.newMD5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.newMD5.Width = 220;
            // 
            // status
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle4;
            this.status.FillWeight = 36.9831F;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.status.Width = 75;
            // 
            // contextMenudgvMD5
            // 
            this.contextMenudgvMD5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuCopyRow,
            this.contextMenuExportToCSV,
            this.contextMenuOpenFile});
            this.contextMenudgvMD5.Name = "contextMenuDGVMD5";
            this.contextMenudgvMD5.Size = new System.Drawing.Size(176, 70);
            // 
            // contextMenuCopyRow
            // 
            this.contextMenuCopyRow.Name = "contextMenuCopyRow";
            this.contextMenuCopyRow.Size = new System.Drawing.Size(175, 22);
            this.contextMenuCopyRow.Text = "Copy Selected Row";
            this.contextMenuCopyRow.Click += new System.EventHandler(this.contextMenuCopyRow_Click);
            // 
            // contextMenuExportToCSV
            // 
            this.contextMenuExportToCSV.Name = "contextMenuExportToCSV";
            this.contextMenuExportToCSV.Size = new System.Drawing.Size(175, 22);
            this.contextMenuExportToCSV.Text = "Export All to .CSV";
            this.contextMenuExportToCSV.Click += new System.EventHandler(this.contextMenuExportToCSV_Click);
            // 
            // contextMenuOpenFile
            // 
            this.contextMenuOpenFile.Name = "contextMenuOpenFile";
            this.contextMenuOpenFile.Size = new System.Drawing.Size(175, 22);
            this.contextMenuOpenFile.Text = "Open File";
            this.contextMenuOpenFile.Click += new System.EventHandler(this.contextMenuOpenFile_Click);
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(532, 13);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(216, 35);
            this.progressBarStatus.TabIndex = 5;
            // 
            // labelItem
            // 
            this.labelItem.AutoSize = true;
            this.labelItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem.Location = new System.Drawing.Point(781, 13);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(17, 17);
            this.labelItem.TabIndex = 6;
            this.labelItem.Text = "0";
            // 
            // labelTotalItem
            // 
            this.labelTotalItem.AutoSize = true;
            this.labelTotalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalItem.Location = new System.Drawing.Point(782, 32);
            this.labelTotalItem.Name = "labelTotalItem";
            this.labelTotalItem.Size = new System.Drawing.Size(17, 17);
            this.labelTotalItem.TabIndex = 8;
            this.labelTotalItem.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(754, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(754, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "total:";
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnRemoveSelected);
            this.panelAction.Controls.Add(this.label2);
            this.panelAction.Controls.Add(this.btnAddFiles);
            this.panelAction.Controls.Add(this.label1);
            this.panelAction.Controls.Add(this.btnStartMD5);
            this.panelAction.Controls.Add(this.labelTotalItem);
            this.panelAction.Controls.Add(this.btnRemoveAll);
            this.panelAction.Controls.Add(this.labelItem);
            this.panelAction.Controls.Add(this.progressBarStatus);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAction.Location = new System.Drawing.Point(0, 342);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(835, 64);
            this.panelAction.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 406);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.dgvMD5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MD5 Hash Changer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMD5)).EndInit();
            this.contextMenudgvMD5.ResumeLayout(false);
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMD5;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.Label labelTotalItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.ContextMenuStrip contextMenudgvMD5;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopyRow;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldMD5;
        private System.Windows.Forms.DataGridViewTextBoxColumn newMD5;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExportToCSV;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnStartMD5;
        private System.Windows.Forms.Button btnAddFiles;
    }
}

