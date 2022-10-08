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
using DevExpress.XtraCharts;

namespace FirstDxpTest
{
    public partial class ChartControl : DevExpress.XtraEditors.XtraForm
    {
        public ChartControl()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            Series s1 = this.chartControl1.Series[0];
            Series s2 = this.chartControl1.Series[1];
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root; database=grid;Charset=utf8;"))
            {
                string sql1 = "select stuClass,sum(stuTotal) as total from tb_student where stuClass='一班' group by stuClass";
                MySqlDataAdapter mda = new MySqlDataAdapter(sql1, con);//实例化adapter对象
                DataSet ds = new DataSet();//创建一个临时虚拟数据库，映射Mysql数据库
                mda.Fill(ds);
                s1.DataSource = ds.Tables[0];
                s1.ArgumentDataMember = "stuClass";//横坐标
                s1.ValueDataMembers[0] = "total";//纵坐标
                s1.LegendTextPattern = "一班";//图例说明

                string sql2 = "select stuClass,sum(stuTotal) as total from tb_student where stuClass='二班' group by stuClass";
                MySqlDataAdapter mda2 = new MySqlDataAdapter(sql2, con);//实例化adapter对象
                DataSet ds2 = new DataSet();//创建一个临时虚拟数据库，映射Mysql数据库
                mda2.Fill(ds2);
                s2.DataSource = ds2.Tables[0];
                s2.ArgumentDataMember = "stuClass";//横坐标
                s2.ValueDataMembers[0] = "total";//纵坐标
                s2.LegendTextPattern = "二班";//图例说明

            }
        }
    }
}