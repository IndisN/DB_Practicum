//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBPracticum
{
    using System;
    using System.Collections.Generic;
    
    public partial class Relation
    {
        public System.Guid Id { get; set; }
        public string Type { get; set; }
        public System.Guid UserId1 { get; set; }
        public System.Guid UserId2 { get; set; }
    
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
