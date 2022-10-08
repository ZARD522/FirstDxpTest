using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FirstDxpTest
{
    class Dao
    {

        public void Login()
        {
            string str = "server=127.0.0.1;port=3306;user=root;password=root; database=bookdb;Charset=utf8;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306
            //第一步：创建数据库对象
            MySqlConnection con = new MySqlConnection(str);//创建数据库对象

            //第二步：打开数据库连接
            con.Open();

            //第三步：创建执行脚本类对象
            string sql = $"select * from userinfo where userid='{1}' and userpwd='{123456}'";
            MySqlCommand cmd = new MySqlCommand(sql,con);

            //第四步：执行脚本,返回数据库游标对象
            MySqlDataReader reader = cmd.ExecuteReader();// 读取操作
            //int result = cmd.ExecuteNonQuery();//执行增、删、改操作   返回受影响的行数

            //第五步：释放资源
            reader.Close();
            con.Close();
        }

        public void Register()
        {

        }

    }
}
