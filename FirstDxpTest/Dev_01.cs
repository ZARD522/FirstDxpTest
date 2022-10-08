using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FirstDxpTest
{
    public partial class Dev_01 : DevExpress.XtraEditors.XtraForm
    {
        public Dev_01()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();//实例化此类可以设置弹出一个文件对话框
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.buttonEdit1.Text = ofd.FileName;
            }

        }
        //注册点击事件
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string account = this.textEdit1.Text;
            string pwd = this.textEdit2.Text;

        }
    }
}