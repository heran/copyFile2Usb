using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace WindowsApplication1
{
    class filesCount_paths
    {
        string[] paths;
        public filesCount_paths(string[] Paths)
        {
            paths = Paths;
        }

        /// <summary>
        /// 从路径字符串数组中获取所有文件的总数
        /// </summary>
        /// <returns></returns>
        public int FilesCountPaths()
        {
            int filesCount = 0;
            foreach (string path in paths)
            {
                if (File.Exists(path))
                    filesCount++;
                else
                    filesCount +=AFolderCount(path);

            }
            return filesCount;
        }
        /// <summary>
        /// 获取一个文件夹里面的文件数。
        /// </summary>
        /// <param name="aFolder"></param>
        /// <returns></returns>
        public int AFolderCount(string aFolder)
        {
            int count = 0;
            string[] files = System.IO.Directory.GetFiles(aFolder);
            count = files.Length;
            string[] directorys = System.IO.Directory.GetDirectories(aFolder);
            foreach (string dir in directorys)
            {
                count +=1+ AFolderCount(dir);//除了根文件夹不算做文件外，其他都要算，因为复制所需，也不知道具体为什么？
            }
            return count;
        }
    }
}
