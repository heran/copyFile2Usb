namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除选中项DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送文件到sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbEnUSB = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbInOutUSB = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbCopySta = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.删除选中项DToolStripMenuItem,
            this.发送文件到sToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "粘帖文件集(&P)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 删除选中项DToolStripMenuItem
            // 
            this.删除选中项DToolStripMenuItem.Name = "删除选中项DToolStripMenuItem";
            this.删除选中项DToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.删除选中项DToolStripMenuItem.Text = "删除选中文件(&D)";
            this.删除选中项DToolStripMenuItem.Click += new System.EventHandler(this.删除选中项DToolStripMenuItem_Click);
            // 
            // 发送文件到sToolStripMenuItem
            // 
            this.发送文件到sToolStripMenuItem.Name = "发送文件到sToolStripMenuItem";
            this.发送文件到sToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.发送文件到sToolStripMenuItem.Text = "发送文件到(&S)→";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "若要弹出操作窗口，请单击此图标！";
            this.notifyIcon1.BalloonTipTitle = "U盘复制机器人";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "U盘复制机器人";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(113, 26);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbEnUSB);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(6, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 103);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "可用U盘";
            // 
            // lbEnUSB
            // 
            this.lbEnUSB.BackColor = System.Drawing.Color.White;
            this.lbEnUSB.Location = new System.Drawing.Point(7, 14);
            this.lbEnUSB.Name = "lbEnUSB";
            this.lbEnUSB.Size = new System.Drawing.Size(240, 83);
            this.lbEnUSB.TabIndex = 0;
            this.lbEnUSB.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbInOutUSB);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(6, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 93);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "USB接口状态";
            // 
            // lbInOutUSB
            // 
            this.lbInOutUSB.BackColor = System.Drawing.Color.White;
            this.lbInOutUSB.FormattingEnabled = true;
            this.lbInOutUSB.HorizontalScrollbar = true;
            this.lbInOutUSB.ItemHeight = 14;
            this.lbInOutUSB.Location = new System.Drawing.Point(7, 14);
            this.lbInOutUSB.Name = "lbInOutUSB";
            this.lbInOutUSB.Size = new System.Drawing.Size(240, 74);
            this.lbInOutUSB.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbCopySta);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 219);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 164);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "复制状态";
            // 
            // lbCopySta
            // 
            this.lbCopySta.BackColor = System.Drawing.Color.White;
            this.lbCopySta.FormattingEnabled = true;
            this.lbCopySta.HorizontalScrollbar = true;
            this.lbCopySta.ItemHeight = 14;
            this.lbCopySta.Location = new System.Drawing.Point(7, 14);
            this.lbCopySta.Name = "lbCopySta";
            this.lbCopySta.Size = new System.Drawing.Size(240, 144);
            this.lbCopySta.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(531, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 389);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton7,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MaximumSize = new System.Drawing.Size(1000, 40);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(500, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 40);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton5.Text = "打开";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton1.Text = "导入";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton2.Text = "追加";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton3.Text = "删除";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton4.Text = "清空";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton7.Text = "退出";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(95, 37);
            this.toolStripButton6.Text = "关于";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(531, 422);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(265, 66);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "复制信息提示：";
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Control;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(0, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(531, 450);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "U盘复制机器人";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除选中项DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送文件到sToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbInOutUSB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbCopySta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lbEnUSB;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}

