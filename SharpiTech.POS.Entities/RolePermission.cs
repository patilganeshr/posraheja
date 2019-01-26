using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class RolePermission : BaseEntity
    {
        [DatabaseColumn("role_permission_id")]
        public Int32? RolePermissionId { get; set; }

        [DatabaseColumn("role_id")]
        public Int32? RoleId { get; set; }

        [DatabaseColumn("menu_group_id")]
        public Int32? MenuGroupId { get; set; }

        [DatabaseColumn("menu_id")]
        public Int32? MenuId { get; set; }

        [DatabaseColumn("add_permission")]
        public bool? AddPermission { get; set; }

        [DatabaseColumn("view_permission")]
        public bool? ViewPermission { get; set; }

        [DatabaseColumn("edit_permission")]
        public bool? EditPermission { get; set; }

        [DatabaseColumn("delete_permission")]
        public bool? DeletePermission { get; set; }

    }
}
