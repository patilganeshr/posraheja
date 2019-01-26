using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Menu : BaseEntity
    {
        [DatabaseColumn("menu_id")]
        public Int32? MenuId { get; set; }

        [DatabaseColumn("menu_group_id")]
        public Int32? MenuGroupId { get; set; }

        [DatabaseColumn("menu_name")]
        public string MenuName { get; set; }

        [DatabaseColumn("page_link")]
        public string PageLink { get; set; }

        [DatabaseColumn("menu_sequence")]
        public decimal? MenuSequence { get; set; }

        [DatabaseColumn("menu_group_name")]
        public string MenuGroupName { get; set; }

        [DatabaseColumn("menu_icon")]
        public string MenuIcon { get; set; }
    }
}
