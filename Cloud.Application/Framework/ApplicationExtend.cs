using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.UI;
using Cloud.Framework.Dapper;

namespace Cloud.Framework
{
    /// <summary>
    /// Jyf新建的根据生成器的扩展方法
    /// </summary>
    public static class ApplicationExtend
    {


        #region 数据库分页

        /// <summary>
        /// 分页自定义类型返回条目
        /// </summary>
        /// <returns></returns>
        public static PageEntity<TType> ToPaging<TType>(
            this IDapperRepositories dapperRepositorie,
            string sql,
            IPageIndex page,
            bool isReturnCount,
            string translate = "*",
            string orderBy = "Id",
            object parament = null)
        {
            return dapperRepositorie.Pagination<TType>(sql, page.CurrentIndex, page.PageSize, isReturnCount, translate, orderBy, parament);
        }

        /// <summary>
        /// 分页默认仓储类型返回条目
        /// </summary>
        /// <returns></returns>
        public static PageEntity<TModelType> ToPaging<TModelType>(
            this IDapperRepositories<TModelType> dapperRepositorie,
            string sql,
            IPageIndex page,
            bool isReturnCount,
            string translate = "*",
            string orderBy = "Id desc",
            object parament = null) where TModelType : IEntity
        {
            return dapperRepositorie.Pagination<TModelType>(sql, page.CurrentIndex, page.PageSize, isReturnCount, translate, orderBy, parament);
        }


        /// <summary>
        /// 分页自定义类型不返回条目
        /// </summary>
        /// <returns></returns>
        public static List<TType> ToPaging<TType>(
            this IDapperRepositories dapperRepositorie,
            string sql,
            IPageIndex page,
            string translate = "*",
            string orderBy = "Id desc",
            object parament = null
            )
        {
            return dapperRepositorie.Pagination<TType>(sql, page.CurrentIndex, page.PageSize, translate, orderBy, parament);
        }

        /// <summary>
        /// 分页默认仓储类型不返回条目
        /// </summary>
        /// <returns></returns>
        public static List<TModelType> ToPaging<TModelType>(
            this IDapperRepositories<TModelType> dapperRepositorie,
            string sql,
            IPageIndex page,
            string translate = "*",
            string orderBy = "Id desc",
            object parament = null) where TModelType : IEntity
        {
            return dapperRepositorie.Pagination<TModelType>(sql, page.CurrentIndex, page.PageSize, translate, orderBy, parament);
        }


        #endregion

        #region 缓存分页

        /// <summary>
        /// 缓存分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageList"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToPaging<T>(this IEnumerable<T> pageList, IPageIndex page) //where T : IPageIndex
        {
            var start = page.CurrentIndex - 1 == 0 ? 0 : (page.CurrentIndex - 1) * page.PageSize;
            var enumerable = pageList as T[] ?? pageList.ToArray();
            return start >= enumerable.Length ? new List<T>() : enumerable.Skip(start).Take(page.PageSize);
        }

        /// <summary>
        /// IQueryable 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageList"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IQueryable<T> ToPaging<T>(this IQueryable<T> pageList, IPageIndex page) where T : IEntity
        {
            var start = page.CurrentIndex - 1 == 0 ? 0 : (page.CurrentIndex - 1) * page.PageSize;
            return pageList.OrderBy(x => x.Id).Skip(start).Take(page.PageSize);
        }

        #endregion


        public static List<T> ToList<T>(this IEnumerable<object> input)
        {
            return input.Select(node => (T)node).ToList();
        }

        public static void Exception(this object obj, string exception)
        {
            throw new UserFriendlyException(exception);
        }
    }
}