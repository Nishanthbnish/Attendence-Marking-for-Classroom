//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMC2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedback
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public string msg { get; set; }
        public Nullable<int> Session_Id { get; set; }
    
        public virtual session_Details session_Details { get; set; }
    }
}