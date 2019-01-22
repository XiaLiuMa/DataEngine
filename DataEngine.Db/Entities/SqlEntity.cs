using System;
using System.Collections.Generic;
using System.Text;

namespace DataEngine.Db.Entities
{
    public class SqlEntity : BaseEntity
    {
        /// <summary>
        /// SQL语句名称
        /// </summary>
        public string SqlName { get; set; }

        /// <summary>
        /// SQL语句
        /// </summary>
        public string SqlText { get; set; }
    }
}
