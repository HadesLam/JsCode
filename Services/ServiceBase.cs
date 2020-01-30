using EntityFramework.Audit;
using H.Entity;
using H.Model;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Services
{
    public class ServiceBase
    {
        #region 字段
        private bool _useNoLazyNoProxyContext;
        #endregion

        public ServiceBase()
        {
            DbInit();

            var auditConfiguration = AuditConfiguration.Default;
            auditConfiguration.IncludeRelationships = true;
            auditConfiguration.LoadRelationships = true;
            auditConfiguration.DefaultAuditable = true;
        }

        #region 属性
        protected Entities Context
        {
            get
            {
                if (_useNoLazyNoProxyContext)
                    return this.NoLazyNoProxyContext;

                var name = string.Format("CallContextName:{0}", this.GetHashCode());

                var entities = CallContext.GetData(name) as Entities;

                if (entities == null)
                {
                    entities = new EntitiesLocator();
                    CallContext.SetData(name, entities);
                }
                return entities;
            }
        }

        /// <summary>
        /// 没有延迟加载，没有代理的上下文
        /// </summary>
        protected Entities NoLazyNoProxyContext
        {
            get
            {
                var name = string.Format("NoLazyNoProxyContext:{0}", this.GetHashCode());

                var entities = CallContext.GetData(name) as Entities;

                if (entities == null)
                {
                    entities = new EntitiesLocator();
                    entities.Configuration.LazyLoadingEnabled = false;
                    entities.Configuration.ProxyCreationEnabled = false;
                    CallContext.SetData(name, entities);
                }
                return entities;
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void DbInit()
        {
            Entities mydb = new Entities();
            mydb.Database.CreateIfNotExists();
        }
        /// <summary>
        /// 更新数据实体Attach
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="data"></param>
        protected void UpdateData<TEntity>(TEntity data) where TEntity : BaseModel
        {
            var dbentry = Context.Entry<TEntity>(data);
            if (dbentry.State == System.Data.Entity.EntityState.Detached)
            {
                var set = Context.Set<TEntity>();
                TEntity aroot = set.SingleOrDefault(p => p.Id == data.Id);

                //如果已经被上下文追踪
                if (aroot != null)
                {
                    var attachedEntry = Context.Entry(aroot);
                    attachedEntry.CurrentValues.SetValues(data);
                }
                else //如果不在当前上下文追踪
                {
                    dbentry.State = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                dbentry.State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Dispose()
        {
        }
        #endregion
    }
}