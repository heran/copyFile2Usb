using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging ;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Resources;

namespace WindowsApplication1
{
    public struct volume_name
    {
        private string volume;
        private string name;
        public volume_name(string Volume, string Name)
        {
            volume = Volume;
            name = Name;
        }
        public string Volume
        {
            get 
            {
                return volume;
            }
            set
            {
                this.volume = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
    }
    public partial class Form1 : Form
    {
        //以下定义常量将十六进制的数据字符化（相当于定义宏），使用时方便理解
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        // 逻辑卷标
        public const int DBT_DEVTYP_VOLUME = 0x00000002;
        ImageList imagelist;
        ImageList USB;
        public string ID;
        public string Value;
        public List<volume_name> infoOldDisks=new List<volume_name>() ;
        public List<volume_name> infoNewDisks=new List<volume_name>() ;
        public DriveInfo[] oldDrives;
/////////////////////////////////////////////
        //public volume_name[] strDriveName;
        public string[] FilePath;
        public Thread thread;
        private  operate_menu Operate;
        //private bool  can_use_progressBar=true;
        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_VOLUME
        {
            public int dbcv_size;
            public int dbcv_devicetype;
            public int dbcv_reserved;
            public int dbcv_unitmask;
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        //**************************************************
                        case DBT_DEVICEARRIVAL://U盘有插入
                            Thread.Sleep(3);
                            RefreshDir();//更新在线U盘列表
                        　　int devType = Marshal.ReadInt32(m.LParam, 4);
                            if (devType == DBT_DEVTYP_VOLUME)//获取新U盘盘符
                            {
                                DEV_BROADCAST_VOLUME vol;
                                vol = (DEV_BROADCAST_VOLUME)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_VOLUME));
                                ID = vol.dbcv_unitmask.ToString("x");
                                IO(ID);
                            }
                            if (oldDrives != null && oldDrives[oldDrives.Length - 1].IsReady == true)
                            {
                                lbInOutUSB.Items.Add("U盘：【" + oldDrives[oldDrives.Length - 1].Name + "】已插入" + "(" + DateTime.Now.ToShortTimeString() + ")");
                                lbInOutUSB.SelectedIndex = lbInOutUSB.Items.Count - 1;
                                FilePath = getObjectPaths(listView1);
                                newThreadCopy(FilePath, Value, clear.Checked);
                            }
                            addUSBSubMenu();
                            break;
                        //***************************************************
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                            getLostUSB(lbInOutUSB);
                            RefreshDir();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("程序出现严重错误，需要关闭。", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            base.WndProc(ref m);
        }
        public void RefreshDir()
        {
            oldDrives = null;
            oldDrives = DriveInfo.GetDrives();
            showCanUSB(lbEnUSB, oldDrives);
            updateInfoUSBList(oldDrives, infoOldDisks);
        }
        public void updateInfoUSBList(DriveInfo[] Drives,List<volume_name> List_Conllection)
        {
            List<volume_name> list_conllection = List_Conllection;
            if(list_conllection!=null)
                list_conllection.Clear();
            DriveInfo[] dirves=Drives ;
            volume_name stru_VolNam; 
            foreach (DriveInfo d in dirves)
            {
                if (d.DriveType == DriveType.Removable && d.IsReady == true)
                {
                    stru_VolNam = new volume_name();
                    stru_VolNam.Name = d.RootDirectory.ToString();
                    stru_VolNam.Volume = d.VolumeLabel;
                    list_conllection.Add(stru_VolNam);
                }
            }
        }
        public void newThreadCopy(string[] file_path,string value, bool clear)
        {
            string Value= value;
            string[] File_Path = file_path;
            CopyFileToUSB COPY_THREAD = new CopyFileToUSB(File_Path, Value, clear);
            COPY_THREAD.Show_CopyInfo = new CopyFileToUSB.show_CopyInfo(Show_CopyInfo);
            COPY_THREAD.parent_lab_showinfo = new CopyFileToUSB.parent_lab_showInfo(lab_showInfo);
            thread = new Thread(new ThreadStart(COPY_THREAD.Copy));
            thread.Start();
        }
        /// <summary>
        /// 获取当前电脑上可用的U盘
        /// </summary>
        /// <param name="objDri"></param>
        /// <returns></returns>
        public DriveInfo[] getRemovableDisk(DriveInfo[] objDri)
        {
            DriveInfo[] result;
            if (objDri == null) return null;
            int start = -1;
            int end = -1;
            for (int i = 0; i < objDri.Length; i++)
            {
                if (objDri[i].DriveType == DriveType.Removable && oldDrives[i].IsReady == true)
                {
                    if (start == -1)
                    {
                        start = i;
                        end = start;
                    }
                    else
                        end++;
                }
            }
            if (start == -1)
                return null;
            else
            {
                result = new DriveInfo[end - start + 1];
                for (int j = start; j <= end; j++)
                    result[j] = objDri[j];
                return result;
            }

        }
        /// <summary>
        /// 图形化显示可用U盘
        /// </summary>
        /// <param name="listview"></param>
        /// <param name="hadUSB"></param>
        public void showCanUSB(ListView listview, DriveInfo[] hadUSB)
        {
            if (hadUSB == null) return;
            listview.Items.Clear();
            foreach (DriveInfo d in hadUSB)
            {
                if (d.DriveType == DriveType.Removable && d.IsReady == true)
                {
                    ListViewItem item = new ListViewItem(d.VolumeLabel + "(" + d.RootDirectory + ")",0);
                    listview.Items.Add(item);
                }
            
             }
        }
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            addUSBSubMenu();//添加右键子菜单
            toolStripMenuItem1.Enabled = false;          //右键菜单不可用
            删除选中项DToolStripMenuItem.Enabled = false;
            发送文件到sToolStripMenuItem.Enabled = false;
            imagelist = new ImageList();
            imagelist.ImageSize = new Size(32, 32);
            this.Operate = new operate_menu(this.listView1, this.imagelist);
            USB = new ImageList();
            USB.ImageSize=new Size(16,16);
            USB.Images.Add(Properties.Resources.Usb);
            this.lbEnUSB.LargeImageList = USB;
            RefreshDir();//检测可用U盘
            addUSBSubMenu();
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else e.Effect = DragDropEffects.None;

        }
        public void getLostUSB(ListBox listbox)
        {
            DriveInfo[] newDrives;
            newDrives = DriveInfo.GetDrives();
            updateInfoUSBList(newDrives, infoNewDisks);
            foreach(volume_name old_Volume_Name in infoOldDisks)
            {
                int count=0;
                foreach (volume_name new_Volume_Name in infoNewDisks)
                { 
                    if(old_Volume_Name.Name==new_Volume_Name.Name)
                        break;
                    else
                        count++;
                }
                if(count==infoNewDisks.Count)
                 {
                    string lostUSB="U盘：【";
                    lostUSB +=old_Volume_Name.Name+"_"+old_Volume_Name.Volume +"】已拔出" + "(" + DateTime.Now.ToShortTimeString() + ")" ;
                    listbox.Items.Add(lostUSB);
                    listbox.SelectedIndex = listbox.Items.Count - 1;

                }
           }
        }
        /// <summary>
        /// 向LISTVIEW里面添加文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="NextStartIndex"></param>
        public void add_FilePath(string[] str,int NextStartIndex)
        {
            if (str == null)
                return;
            foreach (string ss in str)
            {
                if (File.Exists(ss))
                    imagelist.Images.Add(Icon.ExtractAssociatedIcon(ss));
                else
                    imagelist.Images.Add(Properties.Resources.folder);
            }
            if(listView1.LargeImageList==null)
                  listView1.LargeImageList = imagelist;
            foreach (string s in str)
            {
                ListViewItem listviewitem = new ListViewItem(showName(s), NextStartIndex);
                listviewitem.Tag = s;
                ++NextStartIndex;
                listView1.Items.Add(listviewitem);
            }
 
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] str;
            int NextStartIndex = imagelist.Images.Count;
            str = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            add_FilePath(str, NextStartIndex);
        }
        private string[] getObjectPaths(ListView listview)
        {
            string[] filepath;
            filepath = new string[listview.Items.Count];
            for (int i = 0; i < listview.Items.Count; i++)
                filepath[i] = listview.Items[i].Tag.ToString();
            return filepath;
        }
        private string[] get_selObjectPaths(ListView listview)
        {
            string[] filepath;
            int index=0;
            if (listview.SelectedItems.Count == 0)
                return null;
            filepath = new string[listview.SelectedItems.Count];
            foreach (ListViewItem lsItem in listview.SelectedItems)
            {
                filepath[index] = lsItem.Tag.ToString();
                index++;
 
            }
            return filepath;
 
        }
        /// <summary>
        /// 显示文件名，不是PATH
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string showName(string str)
        {
            string resurlt;
            resurlt = str.Substring(str.LastIndexOf('\\') + 1);
            return resurlt;
        }
        private void 删除选中项DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
                listView1.Items.Remove(item);
            //listView1.SelectedItems.Clear()???;
        }
        /// <summary>
        /// 选中文件集发生改变时，右键菜单相应的调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items["删除选中项DToolStripMenuItem"] .Enabled = false ;
                contextMenuStrip1.Items["发送文件到sToolStripMenuItem"] .Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items["删除选中项DToolStripMenuItem"].Enabled = true;
                contextMenuStrip1.Items["发送文件到sToolStripMenuItem"].Enabled = true;
            }

        }
        /// <summary>
        /// 获得逻辑盘符，形如：X:
        /// </summary>
        /// <param name="ff"></param>
        /// <returns></returns>
        public string IO(string ff)
        {
            switch (ff)
            {
                case "1":
                    Value = "A:";
                    break;
                case "2":
                    Value = "B:";
                    break;
                case "4":
                    Value = "C:";
                    break;
                case "8":
                    Value = "D:";
                    break;
                case "10":
                    Value = "E:";
                    break;
                case "20":
                    Value = "F:";
                    break;
                case "40":
                    Value = "G:";
                    break;
                case "80":
                    Value = "H:";
                    break;
                case "100":
                    Value = "I:";
                    break;
                case "200":
                    Value = "J:";
                    break;
                case "400":
                    Value = "K:";
                    break;
                case "800":
                    Value = "L:";
                    break;
                case "1000":
                    Value = "M:";
                    break;
                case "2000":
                    Value = "N:";
                    break;
                case "4000":
                    Value = "O:";
                    break;
                case "8000":
                    Value = "P:";
                    break;
                case "10000":
                    Value = "Q:";
                    break;
                case "20000":
                    Value = "R:";
                    break;
                case "40000":
                    Value = "S:";
                    break;
                case "80000":
                    Value = "T:";
                    break;
                case "100000":
                    Value = "U:";
                    break;
                case "200000":
                    Value = "V:";
                    break;
                case "400000":
                    Value = "W:";
                    break;
                case "800000":
                    Value = "X:";
                    break;
                case "1000000":
                    Value = "Y:";
                    break;
                case "2000000":
                    Value = "Z:";
                    break;
                default: break;
            }
            return Value;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.Text = "文件复制机器人";
                this.notifyIcon1.ShowBalloonTip(3000);

            }
        }

        /// <summary>
        /// 单击工具条中导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.Value != null)
                Operate.Import(Value + "\\");
            else
                Operate.Import("D:\\");
        }
        /// <summary>
        /// 单击工具条中追加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Operate.Append();
        }
        /// <summary>
        /// 单击工具条中删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Operate.Delete();
        }
        /// <summary>
        /// 单击工具条中清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Operate.Clear();
        }
        /// <summary>
        /// 能过粘贴导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int NextStartIndex = imagelist.Images.Count;
            StringCollection  str= Clipboard.GetFileDropList();
            foreach (string ss in str)
            {
                if (File.Exists(ss))
                    imagelist.Images.Add(Icon.ExtractAssociatedIcon(ss));
                else
                    imagelist.Images.Add(Properties.Resources.folder);
            }
            listView1.LargeImageList = imagelist;
            foreach (string s in str)
            {
                ListViewItem listviewitem = new ListViewItem(showName(s), NextStartIndex);
                listviewitem.Tag = s;
                ++NextStartIndex;
                listView1.Items.Add(listviewitem);
            }

        }
        /// <summary>
        /// 添加、或更新子菜单中可用U盘集
        /// </summary>
        public void addUSBSubMenu()
        {
            //将之前子菜单项全部清空，防止重复
            ((ToolStripDropDownItem)(contextMenuStrip1.Items["发送文件到sToolStripMenuItem"])).DropDownItems.Clear();
            if (oldDrives == null)
                 return;
            for (int i = 0; i < oldDrives.Length; i++)
            {
                if (oldDrives[i].IsReady)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(oldDrives[i].VolumeLabel + "|" + oldDrives[i].Name + ":");
                    menuItem.Click += new EventHandler(on_clickSubMenu);
                    ((ToolStripDropDownItem)(contextMenuStrip1.Items["发送文件到sToolStripMenuItem"])).DropDownItems.Add(menuItem);

                }
            }
        }
        /// <summary>
        /// 单击发送到具体盘事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void on_clickSubMenu(object sender, EventArgs e)
        {
            string USB_Root;
            string[] Drives;
            ToolStripItem item = sender as ToolStripItem;
            USB_Root=item.Text.Substring(item.Text.LastIndexOf('|')+1);
            if ((Drives = get_selObjectPaths(listView1)) != null)
                newThreadCopy(Drives, USB_Root.Substring(0,2), clear.Checked);
            
        }
        public delegate void ProGrBar();
        public delegate void Ini_ProGrBar(int min,int max);
        public delegate void show_CopyInfo(string info);
        public void Show_CopyInfo(string info)
        {
            if (this.InvokeRequired)
            {
                show_CopyInfo Show = new show_CopyInfo(Show_CopyInfo);
                this.Invoke(Show,new string[] {info});
            }
            else
            {
                lbCopySta.Items.Add(info as object);
                lbCopySta.SelectedIndex = lbCopySta.Items.Count - 1;
            }
 
        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)//当鼠标单击右键时事件
        {
            if (e.Button == MouseButtons.Left)
                return;
            if (Clipboard.GetFileDropList().Count  == 0)
                contextMenuStrip1.Items["toolStripMenuItem1"].Enabled = false;
            else
                contextMenuStrip1.Items["toolStripMenuItem1"].Enabled = true;

        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string path;
            FolderBrowserDialog folder_browser = new FolderBrowserDialog();
            folder_browser.Description = "\n请选择要复制的文件夹:";
            folder_browser.ShowDialog();
            path = folder_browser.SelectedPath;
            if (path == "")
                return;
            imagelist.Images.Add(Properties.Resources.folder);
            if(listView1.LargeImageList==null)
               listView1.LargeImageList =imagelist;
            ListViewItem listviewitem = new ListViewItem(path.Substring(path.LastIndexOf('\\')+1),imagelist.Images.Count-1);
            listviewitem.Tag = path;
            listView1.Items.Add(listviewitem);
        }
        public delegate void LABEL_SHowInfo(string message);
        public void lab_showInfo(string message)
        {
            if (this.InvokeRequired)
            {
                LABEL_SHowInfo showinfo=new LABEL_SHowInfo(lab_showInfo);
                this.Invoke(showinfo, new string[] { message });
            }
            else 
            {
                label1.Text=message;
 
            }
        }
        
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;

                this.WindowState = FormWindowState.Normal;

                this.notifyIcon1.Visible = false;
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}