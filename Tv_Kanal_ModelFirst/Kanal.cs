//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tv_Kanal_ModelFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kanal
    {
        public Kanal()
        {
            this.Yayin = new HashSet<Yayin>();
        }
    
        public int KanalID { get; set; }
        public string KanalAdi { get; set; }
        public decimal Ciro { get; set; }
        public string Adres { get; set; }
        public decimal Reyting { get; set; }
    
        public virtual ICollection<Yayin> Yayin { get; set; }
    }
}
