using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEngine.Db.Entities;
using DataEngine.Db.IManaments;

namespace DataEngine.Db.Manaments
{
    public class ScheduleManament : BaseManament<ScheduleEntity, Guid>, IScheduleManament
    {
        public ScheduleManament(BaseDBContext dbcontext) : base(dbcontext)
        {
        }
    }
}
