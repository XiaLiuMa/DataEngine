using System;
using DataEngine.Db.Entities;

namespace DataEngine.Db.IManaments
{
    public interface ISqlManament : IBaseManament<SqlEntity, Guid>
    {
    }
}
