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
    
    public partial class tblLocation
    {
        public tblLocation()
        {
            this.tblDoctors = new HashSet<tblDoctor>();
            this.tblFlats = new HashSet<tblFlat>();
            this.tblLawyers = new HashSet<tblLawyer>();
            this.tblMesses = new HashSet<tblMess>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual tblCity tblCity { get; set; }
        public virtual ICollection<tblDoctor> tblDoctors { get; set; }
        public virtual ICollection<tblFlat> tblFlats { get; set; }
        public virtual ICollection<tblLawyer> tblLawyers { get; set; }
        public virtual ICollection<tblMess> tblMesses { get; set; }
    }
}
