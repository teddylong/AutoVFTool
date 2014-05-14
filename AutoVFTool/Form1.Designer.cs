namespace AutoVFTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pagefolderCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagefolderPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContentTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeContentTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContentXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeContentXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPageXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePageXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllTemplateXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAllTemplateXSLTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ChangeMutiBtn = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ContentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContentTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contentCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(231, 9);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(94, 30);
            this.LoginBtn.TabIndex = 0;
            this.LoginBtn.Text = "Log In";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(225, 657);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagefolderCopyToolStripMenuItem,
            this.pagefolderPasteToolStripMenuItem,
            this.createFolderToolStripMenuItem,
            this.contentTemplateToolStripMenuItem,
            this.contentXSLTToolStripMenuItem,
            this.pageXSLTToolStripMenuItem,
            this.copyAllTemplateXSLTToolStripMenuItem,
            this.pasteAllTemplateXSLTToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 180);
            // 
            // pagefolderCopyToolStripMenuItem
            // 
            this.pagefolderCopyToolStripMenuItem.Name = "pagefolderCopyToolStripMenuItem";
            this.pagefolderCopyToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pagefolderCopyToolStripMenuItem.Text = "Copy";
            this.pagefolderCopyToolStripMenuItem.Click += new System.EventHandler(this.pagefolderCopyToolStripMenuItem_Click);
            // 
            // pagefolderPasteToolStripMenuItem
            // 
            this.pagefolderPasteToolStripMenuItem.Name = "pagefolderPasteToolStripMenuItem";
            this.pagefolderPasteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pagefolderPasteToolStripMenuItem.Text = "Paste";
            this.pagefolderPasteToolStripMenuItem.Click += new System.EventHandler(this.pagefolderPasteToolStripMenuItem_Click);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.createFolderToolStripMenuItem.Text = "Create Folder";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.createFolderToolStripMenuItem_Click);
            // 
            // contentTemplateToolStripMenuItem
            // 
            this.contentTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContentTemplateToolStripMenuItem,
            this.changeContentTemplateToolStripMenuItem});
            this.contentTemplateToolStripMenuItem.Name = "contentTemplateToolStripMenuItem";
            this.contentTemplateToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.contentTemplateToolStripMenuItem.Text = "Content Template";
            // 
            // viewContentTemplateToolStripMenuItem
            // 
            this.viewContentTemplateToolStripMenuItem.Name = "viewContentTemplateToolStripMenuItem";
            this.viewContentTemplateToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.viewContentTemplateToolStripMenuItem.Text = "View";
            this.viewContentTemplateToolStripMenuItem.Click += new System.EventHandler(this.viewContentTemplateToolStripMenuItem_Click);
            // 
            // changeContentTemplateToolStripMenuItem
            // 
            this.changeContentTemplateToolStripMenuItem.Name = "changeContentTemplateToolStripMenuItem";
            this.changeContentTemplateToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changeContentTemplateToolStripMenuItem.Text = "Change";
            this.changeContentTemplateToolStripMenuItem.Click += new System.EventHandler(this.changeContentTemplateToolStripMenuItem_Click);
            // 
            // contentXSLTToolStripMenuItem
            // 
            this.contentXSLTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContentXSLTToolStripMenuItem,
            this.changeContentXSLTToolStripMenuItem});
            this.contentXSLTToolStripMenuItem.Name = "contentXSLTToolStripMenuItem";
            this.contentXSLTToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.contentXSLTToolStripMenuItem.Text = "Content XSLT";
            // 
            // viewContentXSLTToolStripMenuItem
            // 
            this.viewContentXSLTToolStripMenuItem.Name = "viewContentXSLTToolStripMenuItem";
            this.viewContentXSLTToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.viewContentXSLTToolStripMenuItem.Text = "View";
            this.viewContentXSLTToolStripMenuItem.Click += new System.EventHandler(this.viewContentXSLTToolStripMenuItem_Click);
            // 
            // changeContentXSLTToolStripMenuItem
            // 
            this.changeContentXSLTToolStripMenuItem.Name = "changeContentXSLTToolStripMenuItem";
            this.changeContentXSLTToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changeContentXSLTToolStripMenuItem.Text = "Change";
            this.changeContentXSLTToolStripMenuItem.Click += new System.EventHandler(this.changeContentXSLTToolStripMenuItem_Click);
            // 
            // pageXSLTToolStripMenuItem
            // 
            this.pageXSLTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPageXSLTToolStripMenuItem,
            this.changePageXSLTToolStripMenuItem});
            this.pageXSLTToolStripMenuItem.Name = "pageXSLTToolStripMenuItem";
            this.pageXSLTToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pageXSLTToolStripMenuItem.Text = "Page XSLT";
            // 
            // viewPageXSLTToolStripMenuItem
            // 
            this.viewPageXSLTToolStripMenuItem.Name = "viewPageXSLTToolStripMenuItem";
            this.viewPageXSLTToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.viewPageXSLTToolStripMenuItem.Text = "View";
            this.viewPageXSLTToolStripMenuItem.Click += new System.EventHandler(this.viewPageXSLTToolStripMenuItem_Click);
            // 
            // changePageXSLTToolStripMenuItem
            // 
            this.changePageXSLTToolStripMenuItem.Name = "changePageXSLTToolStripMenuItem";
            this.changePageXSLTToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.changePageXSLTToolStripMenuItem.Text = "Change";
            this.changePageXSLTToolStripMenuItem.Click += new System.EventHandler(this.changePageXSLTToolStripMenuItem_Click);
            // 
            // copyAllTemplateXSLTToolStripMenuItem
            // 
            this.copyAllTemplateXSLTToolStripMenuItem.Name = "copyAllTemplateXSLTToolStripMenuItem";
            this.copyAllTemplateXSLTToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.copyAllTemplateXSLTToolStripMenuItem.Text = "Copy All TemplateXSLT";
            this.copyAllTemplateXSLTToolStripMenuItem.Click += new System.EventHandler(this.copyAllTemplateXSLTToolStripMenuItem_Click);
            // 
            // pasteAllTemplateXSLTToolStripMenuItem
            // 
            this.pasteAllTemplateXSLTToolStripMenuItem.Name = "pasteAllTemplateXSLTToolStripMenuItem";
            this.pasteAllTemplateXSLTToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pasteAllTemplateXSLTToolStripMenuItem.Text = "Paste All TemplateXSLT";
            this.pasteAllTemplateXSLTToolStripMenuItem.Click += new System.EventHandler(this.pasteAllTemplateXSLTToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(11, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Document ID: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.ChangeMutiBtn);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(231, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 334);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Document Info";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(120, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 17);
            this.label19.TabIndex = 38;
            this.label19.Text = "label19";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(11, 61);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 17);
            this.label18.TabIndex = 37;
            this.label18.Text = "Document Title: ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Content Template",
            "Content XSLT",
            "Page XSLT"});
            this.comboBox1.Location = new System.Drawing.Point(129, 131);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 25);
            this.comboBox1.TabIndex = 23;
            // 
            // ChangeMutiBtn
            // 
            this.ChangeMutiBtn.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChangeMutiBtn.Location = new System.Drawing.Point(265, 131);
            this.ChangeMutiBtn.Name = "ChangeMutiBtn";
            this.ChangeMutiBtn.Size = new System.Drawing.Size(66, 23);
            this.ChangeMutiBtn.TabIndex = 22;
            this.ChangeMutiBtn.Text = "Change";
            this.ChangeMutiBtn.UseVisualStyleBackColor = true;
            this.ChangeMutiBtn.Click += new System.EventHandler(this.ChangeMutiBtn_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(14, 133);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(109, 23);
            this.textBox7.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(11, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type: ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContentID,
            this.ContentTitle});
            this.listView1.ContextMenuStrip = this.contextMenuStrip2;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(231, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(374, 247);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // ContentID
            // 
            this.ContentID.Text = "ContentID";
            this.ContentID.Width = 70;
            // 
            // ContentTitle
            // 
            this.ContentTitle.Text = "Content Title";
            this.ContentTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ContentTitle.Width = 300;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentCopyToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(103, 26);
            // 
            // contentCopyToolStripMenuItem
            // 
            this.contentCopyToolStripMenuItem.Name = "contentCopyToolStripMenuItem";
            this.contentCopyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.contentCopyToolStripMenuItem.Text = "Copy";
            this.contentCopyToolStripMenuItem.Click += new System.EventHandler(this.contentCopyToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Image = ((System.Drawing.Image)(resources.GetObject("LoadingLabel.Image")));
            this.LoadingLabel.Location = new System.Drawing.Point(329, 40);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(120, 17);
            this.LoadingLabel.TabIndex = 7;
            this.LoadingLabel.Text = "                            ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 662);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBtn);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "AutoVFTool";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ContentID;
        private System.Windows.Forms.ColumnHeader ContentTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pagefolderCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagefolderPasteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button ChangeMutiBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem contentCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContentTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeContentTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContentXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeContentXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPageXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePageXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllTemplateXSLTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAllTemplateXSLTToolStripMenuItem;
        private System.Windows.Forms.Label LoadingLabel;
    }
}

