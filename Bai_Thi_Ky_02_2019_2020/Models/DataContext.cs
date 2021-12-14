using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public class DataContext
    {
        public string ConnectionString { get; set; }//bien thanh vien
        public DataContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        //Cau 01 Insert diem cach ly

        public int sqlInsertDCL(Diemcachly diemcachly)
        {
            using (SqlConnection conn=GetConnection())
            {
                conn.Open();
                var str = @"insert into diemcachly values(@madcl,@tendcl,@diachi)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madcl", diemcachly.Madiemcachly);
                cmd.Parameters.AddWithValue("tendcl", diemcachly.Tendiemcachly);
                cmd.Parameters.AddWithValue("diachi", diemcachly.Diachi);
                return (cmd.ExecuteNonQuery()); 
            }
        }

        //Cau 02
        public List<Congnhan> sqlListCongNhan()
        {
            List<Congnhan> list = new List<Congnhan>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM CONGNHAN ";
                SqlCommand cmd = new SqlCommand(str, conn);
                

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Congnhan()
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gioitinh"]),
                            NamSinh = Convert.ToInt32(reader["namsinh"]),
                            NuocVe = reader["nuocve"].ToString(),
                            MaDiemCachLy = reader["madiemcachly"].ToString()

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        //Cau 3D List Cong Nhan
        public List<Congnhan> sqlListCongNhan(string MaCongNhan)
        {
            List<Congnhan> list = new List<Congnhan>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM CONGNHAN Where macongnhan=@macongnhan";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("macongnhan", MaCongNhan);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Congnhan()
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString(),
                            GioiTinh = Convert.ToBoolean(reader["gioitinh"]),
                            NamSinh = Convert.ToInt32(reader["namsinh"]),
                            NuocVe = reader["nuocve"].ToString(),
                            MaDiemCachLy = reader["madiemcachly"].ToString()

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }


        //
        public List<object> sqlListByTimeCongNhan(int sotc)
        {
            List<object> list = new  List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"select cn.macongnhan,namsinh,nuocve, count(*) AS SoTC
                                from congnhan cn join cn_tc on cn.macongnhan=cn_tc.macongnhan 
                                group by cn.macongnhan,namsinh,nuocve
                                having count(*) >= @SoTCInput";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("SoTCInput", sotc);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new
                        {
                            MaCongNhan=reader["macongnhan"].ToString(),
                            NamSinh = Convert.ToInt32(reader["namsinh"]),
                            NuocVe = reader["nuocve"].ToString(),
                            SoTC = Convert.ToInt32(reader["SoTC"])
                        });


                    }
                    reader.Close();

                }
                conn.Close();
            }
            return list;
        }

        //Cau 03
        //a) List diem cach ly
        public List<Diemcachly> sqlListDiemCachLy()
        {
            List<Diemcachly> list = new List<Diemcachly>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM Diemcachly";
                SqlCommand cmd = new SqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Diemcachly()
                        {
                            Madiemcachly = reader["Madiemcachly"].ToString(),
                            Tendiemcachly = reader["Tendiemcachly"].ToString(),
                            Diachi = reader["Diachi"].ToString()

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        //b)
        public List<object> sqlListCongNhanByDCL(string madcl)
        {
            List<object> list = new List<object>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"SELECT * FROM CONGNHAN WHERE MADIEMCACHLY=@madcl";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madcl", madcl);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new 
                        {
                            MaCongNhan = reader["MaCongNhan"].ToString(),
                            TenCongNhan = reader["TenCongNhan"].ToString()
                            
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        //c)
        public void  sqlDeleteCongNhan(string macongnhan)
        {
            
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = @"delete from congnhan where macongnhan=@macongnhan";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("macongnhan", macongnhan);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }

        


    }
}
