//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Morning.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    
        public virtual ICollection<Orders> Orders { get; set; }
    }
}