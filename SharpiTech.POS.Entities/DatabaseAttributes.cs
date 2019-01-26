using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class DatabaseColumnAttribute : Attribute
    {
        public string ColumnName { get;}

        public DatabaseColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
    }
}
