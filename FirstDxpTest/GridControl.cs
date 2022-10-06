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
    public partial class GridControl : DevExpress.XtraEditors.XtraForm
    {
        public GridControl()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            using (MySqlConnection con=new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root; database=grid;Charset=utf8;"))
            {
                string sql = "select *from tb_student";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql,con);//实例化adapter对象
                DataSet ds = new DataSet();//创建一个临时虚拟数据库，映射Mysql数据库
                mda.Fill(ds);
                this.gridControl1.DataSource = ds.Tables[0];
            }
        }
    }
}