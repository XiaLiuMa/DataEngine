using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEngine.Db.Entities;
using DataEngine.Db.IManaments;

namespace DataEngine.Db.Manaments
{
    public class SqlManament : BaseManament<SqlEntity, Guid>, ISqlManament
    {
        public SqlManament(BaseDBContext dbcontext) : base(dbcontext)
        {
        }

    }
}
