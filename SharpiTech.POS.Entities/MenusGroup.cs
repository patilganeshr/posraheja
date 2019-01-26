using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class MenusGroup : BaseEntity
    {
        [DatabaseColumn("menu_group_id")]
        public Int32 MenuGroupId { get; set; }

        [DatabaseColumn("menu_group")]
        public string GroupName { get; set; }
    }
}
