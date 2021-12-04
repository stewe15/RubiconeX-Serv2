using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RubiconeX_Serv.DataAccsess.Core.Models
{
    [Table("UserRole")]
    public class UserRoleRto
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

    }
}
