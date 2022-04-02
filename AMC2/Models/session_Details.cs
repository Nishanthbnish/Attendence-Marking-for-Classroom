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
    using System.ComponentModel.DataAnnotations;
    
    public partial class session_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public session_Details()
        {
            this.enrolls = new HashSet<enroll>();
            this.Feedbacks = new HashSet<Feedback>();
            this.trainerregs = new HashSet<trainerreg>();
        }

        [Required]
        public int Session_Id { get; set; }
        [StringLength(100,MinimumLength=5)]
        [Required ]
        public string Session_Des { get; set; }
        [Required]
        public Nullable<int> Skill_Id { get; set; }
        [Required]
        public Nullable<System.DateTime> Session_Date { get; set; }
        [Required]
        public Nullable<System.TimeSpan> Session_Time { get; set; }
        [Required]
        public Nullable<int> Available_Slots { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enroll> enrolls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual skillset skillset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainerreg> trainerregs { get; set; }
    }
}
