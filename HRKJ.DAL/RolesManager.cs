using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using HRKJ.Model;

namespace HRKJ.DAL
{
    public class RolesManager
    {
        public int AddRoles(Roles roles)
        {
            string sql = "insert into Roles(Roles_Id,Roles_Title,Roles_DeleteId,Roles_CreateTime,Roles_UpdateTime) "+
                         "values(@Roles_Id,@Roles_Title,@Roles_DeleteId,@Roles_CreateTime,@Roles_UpdateTime)";

            //SqlParameter[] param =
            //{
            //    new SqlParameter("@Roles_Id",SqlDbType.UniqueIdentifier){ Value = roles.Id }, 
            //    new SqlParameter("@Roles_Title",SqlDbType.VarChar,255){ Value = roles.Roles_Title}, 
            //    new SqlParameter("@Roles_DeleteId",SqlDbType.Int,4){ Value = roles.DeleteId },
            //    new SqlParameter("@Roles_CreateTime",SqlDbType.DateTime,8){ Value = roles.CreateTime},
            //    new SqlParameter("@Roles_UpdateTime",SqlDbType.DateTime,8){ Value = roles.UpdateTime}
            //};

            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Id",roles.Id),
                new SqlParameter("@Roles_Title",roles.Roles_Title),
                new SqlParameter("@Roles_DeleteId",roles.DeleteId),
                new SqlParameter("@Roles_CreateTime",roles.CreateTime),
                new SqlParameter("@Roles_UpdateTime",roles.UpdateTime)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        public int EditRoles(Roles roles)
        {
            string sql = "update Roles set Roles_Title = @Roles_Title , Roles_UpdateTime = @Roles_UpdateTime where Roles_Id = @Roles_Id";

            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Title",roles.Roles_Title),
                new SqlParameter("@Roles_UpdateTime",roles.UpdateTime),
                new SqlParameter("@Roles_Id",roles.Id)
            };

            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int PutTrash(Guid id)
        {
            string sql = "update Roles set Roles_DeleteId = 0 where Roles_Id = @Roles_Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Id",id) 
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveRoles(Guid id)
        {
            string sql = "delete from Roles where Roles_DeleteId = 0 and Roles_Id = @Roles_Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Id",id)
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 批量放入回收站
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int PutTrashList(string idList)
        {
            string sql = "update Roles set Roles_DeleteId = 0 where Roles_Id in ("+idList+")";
            
            return SqlHelper.ExecuteNonQuery(sql, null);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int RemoveRolesList(string idList)
        {
            string sql = "delete from Roles where Roles_Id in (" + idList + ")";

            return SqlHelper.ExecuteNonQuery(sql, null);
        }

        public List<Roles> GetAll()
        {
            string sql = "select * from Roles where Roles_DeleteId = 1 order by Roles_UpdateTime desc";

            var data = SqlHelper.Query(sql, null);

            List<Roles> list = FillData(data);
            return list;

        }

        public Roles GetRolesById(Guid id)
        {
            string sql = "select * from Roles where Roles_DeleteId = 1 and Roles_Id = @Roles_Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Id",id)
            };

            var dt = SqlHelper.Query(sql, param);

           // var data = FillData(dt).Count > 0 ? FillData(dt)[0] : new Roles();
           var data = FillData(dt).FirstOrDefault();
           return data;
        }

        public List<Roles> GetRolesByTitle(string title)
        {
            string sql = "select * from Roles where Roles_DeleteId = 1 and Roles_Title like '%" + title + "%'";
            var dt = SqlHelper.Query(sql, null);
            return FillData(dt);
        }

        /// <summary>
        /// 判断这个名称是否存在
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsExists(string title)
        {
            string sql = "select * from Roles where Roles_Delete = 1 and Roles_Title = @Roles_Title";
            SqlParameter[] param =
            {
                new SqlParameter("@Roles_Title",title) 
            };
            var dt = SqlHelper.Query(sql, param);
            return FillData(dt).Any(); //判断集合当中是否存在数据 ,有数据返回true , 没数据返回false
        }


        public List<Roles> FillData(DataTable dt)
        {
            var list = new List<Roles>();

            foreach (DataRow dr in dt.Rows)
            {
                var item = new Roles
                {
                    Id = Guid.Parse(dr["Roles_Id"].ToString()),
                    Roles_Title = dr["Roles_Title"].ToString(),
                    DeleteId =  int.Parse(dr["Roles_DeleteId"].ToString()),
                    UpdateTime = DateTime.Parse(dr["Roles_UpdateTime"].ToString())
                };
                list.Add(item);
            }
            return list;
        }
    }
}