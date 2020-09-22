using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HRKJ.DAL;
using HRKJ.Model;
namespace HRKJ.BLL
{
    public class RolesService
    {
        RolesManager rm = new RolesManager();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public int AddRoles(Roles roles)
        {
            return rm.AddRoles(roles);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public int EditRoles(Roles roles)
        {
            return rm.EditRoles(roles);
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int PutTrash(Guid id)
        {
            return rm.PutTrash(id);
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RemoveRoles(Guid id)
        {
            return rm.RemoveRoles(id);
        }

        /// <summary>
        /// 批量放入回收站
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int PutTrashList(string idList)
        {
            return rm.PutTrashList(idList);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public int RemoveRolesList(string idList)
        {
            return rm.RemoveRolesList(idList);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<Roles> GetAll()
        {
            return rm.GetAll();
        }
        /// <summary>
        /// 按照id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Roles GetRolesById(Guid id)
        {
            return rm.GetRolesById(id);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<Roles> GetRolesByTitle(string title)
        {
            return rm.GetRolesByTitle(title);
        }

        /// <summary>
        /// 判断这个名称是否存在
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsExists(string title)
        {
            return rm.IsExists(title);
        }

    }
}