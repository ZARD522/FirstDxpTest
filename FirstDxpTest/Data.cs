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
using MySql.Data.MySqlClient;

namespace FirstDxpTest
{
    public partial class Data : DevExpress.XtraEditors.XtraForm
    {
        public Data()
        {
            InitializeComponent();
        }

        public DataTable GetDataTable()
        {
            String str = "server=127.0.0.1;port=3306;user=root;password=root; database=grid;Charset=utf8;";
            string sql = "select userid,username,roleid,userstate from UserInfo";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql,str);//实例化adapter对象
            DataTable dt = new DataTable();//建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
            mda.Fill(dt);//Fill()方法可以将查询到的数据，填充到虚拟数据库的数据表中

            return dt;
        }
        //窗体加载时，显示数据库中获取的数据
        private void Data_Load(object sender, EventArgs e)
        {
            this.gridControl1.DataSource = GetDataTable();
        }
    }
}