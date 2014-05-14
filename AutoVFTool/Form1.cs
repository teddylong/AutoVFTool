using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoVFTool.VFService;
using System.Xml;
using System.IO;
using System.Collections;
using System.Threading;

namespace AutoVFTool
{
    public partial class Form1 : Form
    {   
        Dictionary<int, string> copypastePool = new Dictionary<int, string>();
        List<string> allTemplatePool = new List<string>();
        PSPServiceClient client = new PSPServiceClient();

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label6.Text = "";
            label8.Text = "";
            label19.Text = "";
            comboBox1.SelectedIndex = 0;
            LoadingLabel.Visible = false;
        }
        // Login In
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            LoadingLabel.Visible = true;
            Thread thread = new Thread(new ThreadStart(LoginIn));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        public void LoginIn()
        {
            VFUserInfo userInfo = client.LoginStatus();
            this.label1.Invoke((Action)delegate() { this.label1.Text = "Welcome: " + userInfo.UserName; });
            DocumentListInfo docInfo = client.GetDocumentList(0);

            for (int i = 0; i < docInfo.Count; i++)
            {
                TreeNode node = new TreeNode(docInfo[i].DocumentTitle);
                node.Tag = docInfo[i].DocumentID;
                this.treeView1.Invoke((Action)delegate() { treeView1.Nodes.Add(node); });
                int secondDocID = docInfo[i].DocumentID;
                DocumentListInfo secondDocInfo = client.GetDocumentList(secondDocID);

                for (int j = 0; j < secondDocInfo.Count; j++)
                {
                    TreeNode secondNode = new TreeNode(secondDocInfo[j].DocumentTitle);
                    secondNode.Tag = secondDocInfo[j].DocumentID;
                    this.treeView1.Invoke((Action)delegate() { node.Nodes.Add(secondNode); });   
                }
            }
            this.LoadingLabel.Invoke((Action)delegate() { this.LoadingLabel.Visible = false; });
        }

        // Mouse left click event in Page panel
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                LoadingLabel.Visible = true;
                Thread thread = new Thread(new ThreadStart(TreeViewClickAfterSelect));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        public void TreeViewClickAfterSelect()
        {
            TreeNode node = null;
            treeView1.Invoke((Action)delegate() { node = treeView1.SelectedNode; });
            if (node != null)
            {
                if (node.Parent != null)
                {
                    int docID = int.Parse(node.Tag.ToString());
                    DocumentInfo doc = client.GetDocument(docID);           
                    if (doc != null )
                    {
                        if (doc.DocumentType == DocumentType.Page)
                        {
                            ContentListInfo con = client.GetContentList(docID, 1, 100, "");
                            this.listView1.Invoke((Action)delegate() { listView1.Items.Clear();});
                            
                            for (int i = 0; i < con.Count; i++)
                            {  
                                ListViewItem item = new ListViewItem();
                                item.SubItems.Add(con[i].ContentTitle);
                                item.SubItems[0].Text = con[i].ContentID.ToString();
                                listView1.Invoke((Action)delegate() { listView1.Items.Add(item); });   
                            }                               
                        }
                        else
                        {
                            DocumentListInfo docInfo = client.GetDocumentList(docID);
                            if (node.Nodes.Count != docInfo.Count)
                            {
                                treeView1.Invoke((Action)delegate() { node.Nodes.Clear(); }); 
                                for (int i = 0; i < docInfo.Count; i++)
                                {
                                    TreeNode secNode = new TreeNode(docInfo[i].DocumentTitle);
                                    secNode.Tag = docInfo[i].DocumentID;
                                    treeView1.Invoke((Action)delegate() { node.Nodes.Add(secNode); });    
                                }
                            }   
                        }
                        displayDocumentInfo(node.Tag.ToString());
                        this.LoadingLabel.Invoke((Action)delegate() { this.LoadingLabel.Visible = false; });
                    }
                }
            }    
        }
        // Display the document information when click the page
        public void displayDocumentInfo(string docID)
        {
            DocumentInfo doc = client.GetDocument(int.Parse(docID));
            label6.Invoke((Action)delegate() { label6.Text = doc.DocumentID.ToString(); });
            label8.Invoke((Action)delegate() { label8.Text = doc.DocumentType.ToString(); });
            label19.Invoke((Action)delegate() { label19.Text = doc.DocumentTitle; });    
        }
        // Copy Page and the content inside main method
        public int CopyPageAndContent(int PageDocumentID,int TargetFolderID)
        {
            int count = 0;
            DocumentInfo PageDoc = client.GetDocument(PageDocumentID);
            DocumentInfo TargetDoc = client.GetDocument(TargetFolderID);
            int projectID = TargetDoc.ProjectID;
            
            PageDoc.ProjectID = projectID;
            PageDoc.ParentDocumentID = TargetFolderID;

            DocumentInfo toPublish = client.AddDocument(PageDoc);
            client.PublishPage(toPublish.DocumentID);
            if (toPublish != null)
            {
                count++;
            }
            ContentListInfo conList = client.GetContentList(PageDocumentID, 1, 100, "");
            if (conList.Count > 0)
            {
                for (int i = 0; i < conList.Count; i++)
                {
                    int newContentID = CopyContentToPage(conList[i].ContentID, toPublish.DocumentID);
                    if (newContentID != 0)
                    {
                        count++;
                    }
                }
                return count;
            }
            else
            {
                return 0;
            }
        }
        // Copy One Folder and all documents inside it
        public int CopyFolderAndPageAndContent(int folderID, int TargetFolderID)
        {
            DocumentInfo FolderDoc = client.GetDocument(folderID);
            DocumentInfo TargetDoc = client.GetDocument(TargetFolderID);
            int count = 0;
            int projectID = TargetDoc.ProjectID;
            
            FolderDoc.ProjectID = projectID;
            FolderDoc.ParentDocumentID = TargetFolderID;
            DocumentInfo NewFolderDoc = client.AddDocument(FolderDoc);

            DocumentListInfo folderDetail = client.GetDocumentList(folderID);
            if (folderDetail.Count > 0)
            {
                for (int i = 0; i < folderDetail.Count; i++)
                {
                    if (folderDetail[i].DocumentType == DocumentType.Folder)
                    {
                        int eachcount = CopyFolderAndPageAndContent(folderDetail[i].DocumentID, NewFolderDoc.DocumentID);
                        count = count + eachcount;
                    }
                    else if (folderDetail[i].DocumentType == DocumentType.Page)
                    {
                        int eachcount = CopyPageAndContent(folderDetail[i].DocumentID, NewFolderDoc.DocumentID);
                        count = count + eachcount;
                    }
                }
                return count;
            }
            else
            {
                return 0;
            }
        }
        // Copy Content To Page main method
        public int CopyContentToPage(int contentID, int pageID)
        {
            ContentInfo con = client.GetContent(contentID);
            DocumentInfo doc = client.GetDocument(pageID);
            int projectID = doc.ProjectID;
            string input = con.ContentInput;

            ContentInfo xx = new ContentInfo()
            {
                ContentTitle = "Copy of " + con.ContentTitle,
                DocumentID = pageID,
                ContentInput = input,
                ProjectID = projectID
            };

            ContentInfo con2 = client.AddContent(xx);
            client.PublishContent(con2.ContentID);


            if (con2 != null)
            {
                return con2.ContentID;
            }
            else
            {
                return 0;
            }
        }
        // Mouse right click event in Page panel
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                LoadingLabel.Visible = true;
                Thread thread = new Thread(new ParameterizedThreadStart(TreeViewMouseDown));
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start(CurrentNode); 
            }
        }

        public void TreeViewMouseDown(object Node)
        {
            TreeNode CurrentNode = (TreeNode)Node;
            if (CurrentNode.Parent != null)
            {
                treeView1.ContextMenuStrip = contextMenuStrip1;
                treeView1.Invoke((Action)delegate() { treeView1.SelectedNode = CurrentNode; });

                int docID = int.Parse(CurrentNode.Tag.ToString());
                DocumentInfo doc = client.GetDocument(docID);
                if (doc.DocumentType == DocumentType.Page)
                {
                    ContentListInfo con = client.GetContentList(docID, 1, 100, "");
                    listView1.Invoke((Action)delegate() { listView1.Items.Clear(); });
                    for (int i = 0; i < con.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(con[i].ContentTitle);
                        item.SubItems[0].Text = con[i].ContentID.ToString();
                        listView1.Invoke((Action)delegate() { listView1.Items.Add(item); });
                    }
                }
                else
                {
                    listView1.Invoke((Action)delegate() { listView1.Items.Clear(); });
                    DocumentListInfo docInfo = client.GetDocumentList(docID);
                    if (CurrentNode.Nodes.Count != docInfo.Count)
                    {
                        CurrentNode.Nodes.Clear();
                        for (int i = 0; i < docInfo.Count; i++)
                        {
                            TreeNode secNode = new TreeNode(docInfo[i].DocumentTitle);
                            secNode.Tag = docInfo[i].DocumentID;
                            treeView1.Invoke((Action)delegate() { CurrentNode.Nodes.Add(secNode); });
                        }
                    }
                }
                displayDocumentInfo(CurrentNode.Tag.ToString());
            }
            else
            {
                treeView1.ContextMenuStrip = null;
            }
            this.LoadingLabel.Invoke((Action)delegate() { this.LoadingLabel.Visible = false; });
        }
        // Mouse right click event in Content panel 
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listView1.GetItemAt(e.X,e.Y);
                if (item == null || item.Text == null)
                {
                    listView1.ContextMenuStrip = null;
                }
                else
                {
                    listView1.ContextMenuStrip = contextMenuStrip2;
                }     
            }
        }
        // Support method for Change Muti pages, to get the muti-documentID
        public List<int> GetSomeID(string SomeID)
        {
            try
            {
                List<int> someID = new List<int>();
                string[] temp = SomeID.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i] != "")
                    {
                        someID.Add(int.Parse(temp[i]));
                    }
                }
                return someID;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        // Change Content Template for many pages
        public void MutiChangeContentTemplate(List<int> list)
        {
            string filename;
            int count = 0;
            openFileDialog1.Filter = "Spec Files(*.xslt;*.xml)|*.xslt;*.xml";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                for (int i = 0; i < list.Count; i++)
                {
                    DocumentInfo doc = client.GetDocument(list[i]);
                    doc.DocumentDescription = File.ReadAllText(filename);
                    client.EditDocument(doc);
                    doc.DocumentLastPublished = DateTime.Now;
                    Uri x = client.PublishPage(list[i]);
                    if (x != null)
                    {
                        count++;
                    }
                }
                MessageBox.Show(count + " Contents changed!");
            }
        }
        // Change Content XSLT for many pages
        public void MutiChangeContentXSLT(List<int> list)
        {
            string filename;
            int count = 0;
            openFileDialog1.Filter = "Spec Files(*.xslt;*.xml)|*.xslt;*.xml";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                for (int i = 0; i < list.Count; i++)
                {
                    DocumentInfo doc = client.GetDocument(list[i]);
                    doc.DocumentXSLT = File.ReadAllText(filename);
                    client.EditDocument(doc);
                    doc.DocumentLastPublished = DateTime.Now;
                    Uri x = client.PublishPage(list[i]);
                    if (x != null)
                    {
                        count++;
                    }
                }
                MessageBox.Show(count + " Contents changed!");
            }
        }
        // Change Page XSLT for many pages
        public void MutiChangePageXSLT(List<int> list)
        {
            string filename;
            int count = 0;
            openFileDialog1.Filter = "Spec Files(*.xslt;*.xml)|*.xslt;*.xml";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                for (int i = 0; i < list.Count; i++)
                {
                    DocumentInfo doc = client.GetDocument(list[i]);
                    doc.DocumentExtension = File.ReadAllText(filename);
                    client.EditDocument(doc);
                    doc.DocumentLastPublished = DateTime.Now;
                    Uri x = client.PublishPage(list[i]);
                    if (x != null)
                    {
                        count++;
                    }
                }
                MessageBox.Show(count + " Contents changed!");
            }
        }
        // Change Content Template & Content XSLT & Page XSLT base method
        public void ChangeThree(int docID, string keyword)
        {
            string filename;
            openFileDialog1.Filter = "Spec Files(*.xslt;*.xml)|*.xslt;*.xml";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                DocumentInfo doc = client.GetDocument(docID);
                if (keyword == "Content Template")
                {
                    doc.DocumentDescription = File.ReadAllText(filename);
                }
                if (keyword == "Content XSLT")
                {
                    doc.DocumentXSLT = File.ReadAllText(filename);
                }
                if (keyword == "Page XSLT")
                {
                    doc.DocumentExtension = File.ReadAllText(filename);
                }
                client.EditDocument(doc);
                doc.DocumentLastPublished = DateTime.Now;
                Uri x = client.PublishPage(docID);
                if (x != null)
                {
                    MessageBox.Show("Changed!");
                }
                else
                {
                    MessageBox.Show("Failed!");
                }
            }
        }
        // Create Folder Function
        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = treeView1.SelectedNode.Tag.ToString();
            ToCreateFolder tcf = new ToCreateFolder();
            if (tcf.ShowDialog() == DialogResult.OK)
            {
                string FolderName = tcf.TextBoxMsg;
                if (FolderName != "" && FolderName !=String.Empty)
                {
                    int ParentID = int.Parse(tag);
                    DocumentInfo parentDoc = client.GetDocument(ParentID);
                    int ProjectID = parentDoc.ProjectID;

                    DocumentInfo doc = new DocumentInfo();
                    doc.ParentDocumentID = ParentID;
                    doc.DocumentTitle = FolderName;
                    doc.DocumentType = DocumentType.Folder;
                    doc.ProjectID = ProjectID;
                    DocumentInfo ToPublish = client.AddDocument(doc);

                    if (ToPublish.DocumentID.ToString() != null && ToPublish.DocumentID.ToString() != "")
                    {
                        MessageBox.Show("New Folder Cretaed: " + ToPublish.DocumentTitle + " (ID: " + ToPublish.DocumentID.ToString() + ")");
                    }
                }
                else
                {
                    MessageBox.Show("Need Folder Name and ParentID!");
                }
            }
        }
        // Copy page or folder
        private void pagefolderCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = treeView1.SelectedNode.Tag.ToString();
            DocumentInfo doc = client.GetDocument(int.Parse(tag));
            string docType = doc.DocumentType.ToString();
            copypastePool.Clear();
            copypastePool.Add(int.Parse(tag), docType);
            MessageBox.Show("One Item Selected:" + "\n"  + "\n" + "Document ID: " + tag + "\n" + "Document Type: " + doc.DocumentType + "\n" + "Document Title: " + doc.DocumentTitle);
        }
        // Paste Page or folder
        private void pagefolderPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadingLabel.Visible = true;
            Thread thread = new Thread(new ThreadStart(PastePageOrFolder));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        // Support for pagefolderPasteToolStripMenuItem_Click method
        public void PastePageOrFolder()
        {
            string tag = string.Empty;
            treeView1.Invoke((Action)delegate() { tag = treeView1.SelectedNode.Tag.ToString(); });

            if (copypastePool.Count == 0)
            {
                MessageBox.Show("Paste what?");
            }
            else
            {
                DocumentInfo doc = client.GetDocument(int.Parse(tag));
                int count = 0;
                int totalCount = 0;

                foreach (var item in copypastePool)
                {
                    if (item.Value == "Content" && doc.DocumentType == DocumentType.Folder)
                    {
                        MessageBox.Show("The content can not be copied to folder");
                        break;
                    }
                    if (item.Value == "Page" && doc.DocumentType == DocumentType.Page)
                    {
                        MessageBox.Show("The page can not be copied to another page");
                        break;
                    }
                    if (item.Value == "Folder" && doc.DocumentType == DocumentType.Page)
                    {
                        MessageBox.Show("The folder can not be copied to page");
                        break;
                    }
                    if (item.Value == "Content" && doc.DocumentType == DocumentType.Page)
                    {
                        int newContentID = CopyContentToPage(item.Key, doc.DocumentID);
                        if (newContentID != 0)
                        {
                            count++;
                        }
                    }
                    if (item.Value == "Folder" && doc.DocumentType == DocumentType.Folder)
                    {
                        totalCount = CopyFolderAndPageAndContent(item.Key, doc.DocumentID);
                    }
                    if (item.Value == "Page" && doc.DocumentType == DocumentType.Folder)
                    {
                        totalCount = CopyPageAndContent(item.Key, doc.DocumentID);
                    }
                }
                if (count == 0 && totalCount != 0)
                {
                    MessageBox.Show(totalCount + " item pasted");
                }
                if (count != 0 && totalCount == 0)
                {
                    MessageBox.Show(count + " item pasted");
                }
                if (count == 0 && totalCount == 0)
                {
                    MessageBox.Show("0 item pasted");
                }
            }
            this.LoadingLabel.Invoke((Action)delegate() { this.LoadingLabel.Visible = false; });
        }

        // Copy Contents
        private void contentCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemCollection = listView1.SelectedItems;
            if (itemCollection.Count > 0)
            {
                copypastePool.Clear();
                foreach (ListViewItem item in itemCollection)
                {
                    copypastePool.Add(int.Parse(item.SubItems[0].Text), "Content");
                }
            }
            MessageBox.Show(copypastePool.Count + " items Selected");
        }

        // View Content Template
        private void viewContentTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = treeView1.SelectedNode.Tag.ToString();
            DocumentInfo doc = client.GetDocument(int.Parse(tag));
            if (doc == null || doc.DocumentType != DocumentType.Page)
            {
                MessageBox.Show("This file has NO Content Template");
            }
            else
            {
                string ContentTemplate = doc.DocumentDescription;
                MessageBox.Show(ContentTemplate);
            }
        }

        // Change Content Template
        private void changeContentTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docID = int.Parse(treeView1.SelectedNode.Tag.ToString());
            DocumentInfo doc = client.GetDocument(docID);
            if (doc.DocumentType == DocumentType.Page)
            {
                ChangeThree(docID, "Content Template");
            }
            else
            {
                MessageBox.Show("Please select one page, this is folder");
            }
        }

        // View Content XSLT
        private void viewContentXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = treeView1.SelectedNode.Tag.ToString();
            DocumentInfo doc = client.GetDocument(int.Parse(tag));
            if (doc == null || doc.DocumentType != DocumentType.Page)
            {
                MessageBox.Show("This file has NO Content XSLT");
            }
            else
            {
                string ContentXSLT = doc.DocumentXSLT;
                MessageBox.Show(ContentXSLT);
            }
        }

        // Change Content XSLT
        private void changeContentXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docID = int.Parse(treeView1.SelectedNode.Tag.ToString());
            DocumentInfo doc = client.GetDocument(docID);
            if (doc.DocumentType == DocumentType.Page)
            {
                ChangeThree(docID, "Content XSLT");
            }
            else
            {
                MessageBox.Show("Please select one page, this is folder");
            }
        }

        // View Page XSLT
        private void viewPageXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tag = treeView1.SelectedNode.Tag.ToString();
            DocumentInfo doc = client.GetDocument(int.Parse(tag));
            if (doc == null || doc.DocumentType != DocumentType.Page)
            {
                MessageBox.Show("This file has NO Page XSLT");
            }
            else
            {
                string PageXSLT = doc.DocumentExtension;
                MessageBox.Show(PageXSLT);
            }
        }

        // Change Page XSLT
        private void changePageXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docID = int.Parse(treeView1.SelectedNode.Tag.ToString());
            DocumentInfo doc = client.GetDocument(docID);
            if (doc.DocumentType == DocumentType.Page)
            {
                ChangeThree(docID, "Page XSLT");
            }
            else
            {
                MessageBox.Show("Please select one page, this is folder");
            }
        }

        // Copy All Template & XSLT
        private void copyAllTemplateXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docID = int.Parse(treeView1.SelectedNode.Tag.ToString());
            DocumentInfo doc = client.GetDocument(docID);
            if (doc.DocumentType == DocumentType.Page)
            {
                allTemplatePool.Clear();
                allTemplatePool.Add(doc.DocumentDescription);
                allTemplatePool.Add(doc.DocumentXSLT);
                allTemplatePool.Add(doc.DocumentExtension);
                if (allTemplatePool.Count == 3)
                {
                    MessageBox.Show("Content Template, Content XSLT, Page XSLT copied");
                }
            }
            else
            {
                MessageBox.Show("This document has NO template & XSLT");
            }
        }

        // Past All Template & XSLT 
        private void pasteAllTemplateXSLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allTemplatePool.Count == 3)
            {
                int docID = int.Parse(treeView1.SelectedNode.Tag.ToString());
                DocumentInfo doc = client.GetDocument(docID);
                if (doc.DocumentType == DocumentType.Page)
                {
                    doc.DocumentDescription = allTemplatePool[0];
                    doc.DocumentXSLT = allTemplatePool[1];
                    doc.DocumentExtension = allTemplatePool[2];
                    client.EditDocument(doc);
                    doc.DocumentLastPublished = DateTime.Now;
                    Uri x = client.PublishPage(docID);
                    if (x != null)
                    {
                        MessageBox.Show("Changed!");
                    }
                    else
                    {
                        MessageBox.Show("Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("This document has NO template");
                }
            }
            else
            {
                MessageBox.Show("Paste What?");
            }
        }

        // the Btn of Change muti pages
        private void ChangeMutiBtn_Click(object sender, EventArgs e)
        {
            List<int> xx = GetSomeID(textBox7.Text);
            if (xx != null && xx.Count != 0)
            {
                string selectText = comboBox1.SelectedItem.ToString();
                if (selectText.Contains("Content Template"))
                {
                    MutiChangeContentTemplate(xx);
                }
                if (selectText.Contains("Content XSLT"))
                {
                    MutiChangeContentXSLT(xx);
                }
                if (selectText.Contains("Page XSLT"))
                {
                    MutiChangePageXSLT(xx);
                }
            }
            else
            {
                MessageBox.Show("There is No Content need to Change");
            }
        }

        

               
    }
}
