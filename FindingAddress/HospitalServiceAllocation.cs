//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindingAddress
{
    using System;
    using System.Collections.Generic;
    
    public partial class HospitalServiceAllocation
    {
        public int Id { get; set; }
        public Nullable<int> HospitalId { get; set; }
        public Nullable<int> ServiceId { get; set; }
    
        public virtual tblHospitalService tblHospitalService { get; set; }
        public virtual tblHospital tblHospital { get; set; }
    }
}
