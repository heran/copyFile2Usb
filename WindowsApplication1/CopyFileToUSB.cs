using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace WindowsApplication1
{
    class CopyFileToUSB
    {
        int FILES_COUNT=0;
        string CopyInfo;
        DriveInfo USBinfo;
       // bool can_PraBar=false ;
        string[] SourcePaths;
        public int FilesCount = 0;
        public filesCount_paths doFilesCount;
        public delegate void StepProgressBar(); 
        //public  StepProgressBar addStepProB; 
        public delegate void Ini_ProGrBar(int min, int max); 
        //public Ini_ProGrBar ini_FatherProGrBar;
        public delegate void show_CopyInfo(string info);
        public delegate void parent_lab_showInfo(string message);
        public parent_lab_showInfo parent_lab_showinfo;
        public show_CopyInfo Show_CopyInfo;
        /// <summary>
        /// 构造文件复制对像
        /// </summary>
        /// <param name="listview">用以获取文件路径列表视图</param>
        /// <param name="USBboot">要复制的目标盘</param>
        public CopyFileToUSB(string[] SourcePaths, string USBboot)
        {
            doFilesCount = new filesCount_paths(SourcePaths);
            this.SourcePaths = SourcePaths;
            USBinfo = new DriveInfo(USBboot.Substring(0, 1));
            CopyInfo = "【" + USBinfo.Name + "盘_" + USBinfo.VolumeLabel + "】"; 
        }
        /// <summary>
        /// FielName，要复制文件名,若目标文件己存在，则覆盖
        /// </summary>
        public void Copy()
        {

            FILES_COUNT = 0;
            if (USBinfo.IsReady == true)
                if (SourcePaths == null)
                {
                    return;
                }
                else
                {
                    FILES_COUNT = doFilesCount.FilesCountPaths();
                    if (FILES_COUNT == 0) return;
                    Show_CopyInfo(CopyInfo + "正在复制....");
                    parent_lab_showinfo(CopyInfo + "  \n正在复制....");
                    foreach (string FileName in SourcePaths)
                    {
                        try
                        {
                            if (File.Exists(FileName))
                            {
                                File.Copy(FileName, USBinfo.RootDirectory.ToString() + geteTrueName(FileName), true);
                               //addStepProB();
                            }
                            else
                                FileCopy(FileName, USBinfo.RootDirectory.ToString() + FileName.Substring(FileName.LastIndexOf('\\') + 1));
                        }
                        catch
                        {
                            Show_CopyInfo(CopyInfo + "复制失败.failure");
                            parent_lab_showinfo(CopyInfo + "  \n  复制失败. 请手动重试!");
                            return;
                        }
                    }
                    Show_CopyInfo(CopyInfo + "复制完成.ok");
                    parent_lab_showinfo(CopyInfo + "  \n  复制完成. 可以弹出此设备!");

                }
        }
        /// <summary>
        /// 得到文件实名（不含路径）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string geteTrueName(string path)
        {
            return path.Substring((path.LastIndexOf('\\') + 1));
        }
        private void FileCopy(string srcdir, string destdir)
        {
            DirectoryInfo dir;
            FileInfo[] files;
            DirectoryInfo[] dirs;
            string tmppath;
            if (!Directory.Exists(destdir))
            {
                Directory.CreateDirectory(destdir);
            }
            dir = new DirectoryInfo(srcdir);
            if (!dir.Exists)
            {
                throw new ArgumentException("source  dir doesn't  exist  ->  " + srcdir);
            }
            files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                tmppath = Path.Combine(destdir, file.Name);
                file.CopyTo(tmppath, true);
                //addStepProB();
            }
            files = null;
            dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                tmppath = Path.Combine(destdir, subdir.Name);
                FileCopy(subdir.FullName, tmppath);
                //addStepProB();
            }
            dirs = null;
            dir = null;
        }   
        
    }
}

