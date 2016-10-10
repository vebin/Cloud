using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Abp.Domain.Entities;
using Cloud.Framework.Dapper;
using Dapper;

namespace Cloud.Dapper.Framework
{
    public class OracleRepositories<TEntity> : DapperRepositoriesBase<TEntity> where TEntity : Entity
    {
        public override T ConnectionExcute<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection conn = new SqlConnection(OraclePersistentConfigurage.MasterConnectionString))
            {
                return func(conn);
            }
        }
        public string TableName { get; set; }

        #region Query

        public override List<TEntity> GetList(string where, object parament = null, string field = "*")
        {
            return ConnectionExcute(x => x.Query<TEntity>($"select {field} from [" + TableName + "] " + where, parament).ToList());
        }

        public override TEntity Get(int id)
        {
            return ConnectionExcute(x => x.Query<TEntity>("select top 1 * from [" + TableName + "] where id = " + id).FirstOrDefault());
        }

        public override TEntity FirstOrDefault(string where, object parament = null, string field = "*")
        {
            return ConnectionExcute(x => x.Query<TEntity>($" select top 1 {field} from [" + TableName + "] " + where, parament).FirstOrDefault());
        }

        #endregion

        #region CUD

        public override TEntity Insert(TEntity entity)
        {
            List<string> list;
            var parament = GetParament(entity, out list);
            var sql = $"INSERT INTO [{TableName}] ({string.Join(",", list)}) VALUES (@{string.Join(",@", list)});SELECT @@IDENTITY";
            entity.Id = ConnectionExcute(x => x.ExecuteScalar<int>(sql, parament));
            return entity;
        } 

        public override TEntity Update(TEntity entity)
        {
            List<string> list;
            var parament = GetParament(entity, out list);
            var agg = list.Aggregate(new StringBuilder(), (x, y) =>
            {
                x.Append(y);
                x.Append("=@");
                x.Append(y);
                x.Append(",");
                return x;
            });
            var sql = $"UPDATE [{TableName}] SET {agg.ToString().TrimEnd(',')} WHERE ID = {entity.Id}";
            ConnectionExcute(x => x.Execute(sql, parament));
            return entity;
        } 

        public override void Delete(IEnumerable<TEntity> entities)
        {
            var sql = $"delete from [{ TableName }] where id in @Id";
            var list = entities.Select(x => x.Id);
            ConnectionExcute(x => x.Execute(sql, new { Id = list }));
        }

        public override void Delete(int id)
        {
            ConnectionExcute(x => x.Execute($"delete from [{TableName}] where id = {id}"));
        }

        public override void Delete(string where, object parament = null)
        {
            var sql = $"delete from [{ TableName }] {where}";
            ConnectionExcute(x => x.Execute(sql, parament));
        }

        public override int Count()
        {
            return ConnectionExcute(x => x.ExecuteScalar<int>("SELECT COUNT(1) FROM [" + TableName + "]"));
        }

        #endregion

        #region Agg
        public override int Count(string where, object parament = null)
        {
            return ConnectionExcute(x => x.ExecuteScalar<int>("SELECT COUNT(1) FROM [" + TableName + "] " + where, parament));
        } 
         
        #endregion

        #region Helper

        public List<string> GetFieNameArray<T>()
        {
            return (from node in typeof(T).GetProperties() where node.Name.ToLower() != "id" select node.Name).ToList();
        }

        //根据对象获取DynamicParament  
        public DynamicParameters GetParament<T>(T t, out List<string> list)
        {
            list = new List<string>();
            var parament = new DynamicParameters();
            foreach (var node in typeof(T).GetProperties())
            {
                if (node.Name.ToLower() == "id" || node.GetValue(t) == null) continue;
                if (node.Name == "CreateTime")
                    node.SetValue(t, DateTime.Now);
                list.Add(node.Name);
                parament.Add("@" + node.Name, node.GetValue(t));
            }
            return parament;
        }

        #endregion 


    }
}