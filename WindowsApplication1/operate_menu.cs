using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsApplication1
{
    class operate_menu
    {
        public ImageList imagelist;
        public ListView listview;
        public operate_menu(ListView listview,ImageList  imagelist)
        {
            this.listview = listview;
            this.imagelist = imagelist;
        }
        public void Delete()
        {
            foreach (ListViewItem item in listview.SelectedItems)
                listview.Items.Remove(item);
        }
        public void Append()
        {
            string[] file_names;
            OpenFileDialog openFiles = new OpenFileDialog();
            openFiles.CheckFileExists = true;
            openFiles.CheckPathExists = true;
            openFiles.SupportMultiDottedExtensions = true;
            openFiles.RestoreDirectory = true;
            openFiles.Multiselect = true;
            openFiles.Title = "追加...[可以选下多个文件]=U盘复制机器人1.0.0.1=";
            openFiles.ShowDialog();
            file_names = openFiles.FileNames;
            if (file_names != null)
                showFiles(file_names, listview.Items.Count );
 
        }
        public void Import(string initDir)
        {
            Clear();
            string[] file_names;
            OpenFileDialog openFiles = new OpenFileDialog();
            openFiles.CheckFileExists = true;
            openFiles.CheckPathExists = true;
            openFiles.SupportMultiDottedExtensions=true;
            openFiles.InitialDirectory = initDir;
            openFiles.Multiselect = true;
            openFiles.RestoreDirectory = true;
            openFiles.Title = "导入...[可以选下多个文件]=U盘复制机器人1.0.0.1=";
            openFiles.ShowDialog();
            file_names = openFiles.FileNames;
            if (file_names != null)
                showFiles(file_names,imagelist.Images.Count );

        }
        public void Clear()
        {
           listview.Items.Clear();
           imagelist.Images.Clear();
 
        }
        public  void showFiles(string[] instr,int start)
        {
            int NextStartIndex = start;
            string[] str = instr ;
            foreach (string ss in str)
            {
                if (File.Exists(ss))
                    imagelist.Images.Add(Icon.ExtractAssociatedIcon(ss));
                else
                    imagelist.Images.Add(Bitmap.FromFile(@"D:\\folder.ico"));
            }
            if(listview.LargeImageList==null)
                  listview.LargeImageList = imagelist;
            foreach (string s in str)
            {
                ListViewItem listviewitem = new ListViewItem(s.Substring(s.LastIndexOf('\\')+1), NextStartIndex);
                listviewitem.Tag = s;
                ++NextStartIndex;
                listview.Items.Add(listviewitem);
            }
        }
    }
}
