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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //LoginForm lg = new LoginForm();
            this.Close();//关闭当前窗体
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string str = "server=127.0.0.1;port=3306;user=root;password=root; database=grid;Charset=utf8;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306
            //第一步：创建数据库对象
            MySqlConnection con = new MySqlConnection(str);//创建数据库对象

            //第二步：打开数据库连接
            con.Open();

            ////第三步：创建执行脚本类对象
            //string sql = $"select * from userinfo where userid='{textEdit1.Text}' and userpwd='{textEdit2.Text}'";
            //MySqlCommand cmd = new MySqlCommand(sql, con);

            ////第四步：执行脚本,返回数据库游标对象
            //MySqlDataReader reader = cmd.ExecuteReader();//读取操作
            ////int result = cmd.ExecuteNonQuery();//执行增、删、改操作   返回受影响的行数

            if (checkEdit1.Checked==true)
            {
                //con.Open();
                string sql = $"select * from userinfo where userid='{textEdit1.Text}' and userpwd='{textEdit2.Text}' and roleid !='1'";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                //第四步：执行脚本,返回数据库游标对象
                MySqlDataReader reader = cmd.ExecuteReader();//读取操作
                if (reader.Read())
                {
                    //LoginForm lg = new LoginForm();
                    string username = textEdit1.Text.ToString();//获取用户名称
                    XtraMessageBox.Show("欢迎用户" + username + "登录", "提示");

                    //GridView gv = new GridView();
                    Ribbon rb = new Ribbon();
                    this.Hide();
                    //gv.ShowDialog();
                    rb.ShowDialog();
                    this.Show();

                }
                else
                {
                    XtraMessageBox.Show("用户名或密码错误","提示");
                }
                reader.Close();
                con.Close();

            }

            if (checkEdit2.Checked == true)
            {
                //con.Open();
                //string sql = "select * from userinfo where roleid='1'";
                string sql = $"select * from userinfo where userid='{textEdit1.Text}' and userpwd='{textEdit2.Text}' and roleid='1'";
               
                MySqlCommand cmd = new MySqlCommand(sql, con);


                //第四步：执行脚本,返回数据库游标对象
                //MySqlDataReader reader = cmd.ExecuteReader();//读取操作

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);// 实例化adapter对象
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataRow row = ds.Tables[0].Rows[0];

                string userid = row[0].ToString();
                string username = row[1].ToString();
                string userpwd = row[2].ToString();

                if (textEdit1.Text==userid && textEdit2.Text==userpwd)
                {
                    //LoginForm lg = new LoginForm();
                    /*
                     /*DataSet使用范式
                    1利用连接字符串创建连接对象con
                    ⒉根据具体的需求写ssQL，总是写select语句，通过where限定**
                    3利用con ssQL创建adaptero
                    4利用adapter来构造一个sqlCommandBuilder对象scb。
                    5实例化DataSet ds
                    6利用adapter的Fill方法对ds进行填充
                    7根据不同操作要求进行增删改查操作。其中删改查要取得相应的数据，增不需要数据
                    1)增:利用drow = set.Tables[0]. NewRow()获取行结构，然后逐字段赋值
                     drow[index字段名]=
                     drow添加到指定表格的Bows集合中
                    2）删tables[0].Rows[0].Delete(
                    3)改drow= tables[0].Rows[0] : drow[index字段名]=xx4)查根据数据的多少，循环或单条处理。
                    8利用adapter的Update方法将ds更新数据库注意:操作的表必须要设置主键。
                    */

                    //string sql1 =$"select username form userinfo where userid='{textEdit1.Text}'";//获取管理员名称
                    //MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    //MySqlDataAdapter adapter = new MySqlDataAdapter(sql1, con);
                    //DataSet ds = new DataSet();
                    //adapter.Fill(ds);

                    XtraMessageBox.Show("欢迎管理员"+username+"登录", "提示");

                    //GridView gv = new GridView();
                    Ribbon rb = new Ribbon();
                    this.Hide();
                    //gv.ShowDialog();
                    rb.ShowDialog();
                    this.Show();
                }
                else
                {
                    XtraMessageBox.Show("用户名或密码错误", "提示");
                }


                //第五步：释放资源
                //reader.Close();
                con.Close();
            }
        }
    }
}