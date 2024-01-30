using System;
using System.Collections.Generic;

namespace Sale_system.MODEL;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameCompleted { get; set; }

    public string? Email { get; set; }

    public int? IdRol { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegister { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
