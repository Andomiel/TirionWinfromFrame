using Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IBaseDAL<T>where T : BaseEntity
    {
        #region 查询
        /// <summary>
        /// 根据id查询数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int id);
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        List<T> FindAll();


        #endregion
        #region 增加
        /// <summary>
        /// 增加-事务
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Add(DbTransaction dbTransaction, T t);
        bool Add(T t);

        #endregion
        #region 修改
        /// <summary>
        /// 根据id更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);
        #endregion
        #region 删除
        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        #endregion
    }
}
