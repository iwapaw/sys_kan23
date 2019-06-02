using FluentNHibernate.Mapping;
using Kanban.Data.Entities;

namespace Kanban.Data.SqlServer.Mapping
{
	public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {
        protected VersionedClassMap()
        {
            Version(x => x.Version)
                .Column("ts")
                .CustomSqlType("Rowversion")
                .Generated.Always()
                .UnsavedValue("null");
        }
    }
}
