//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gestionDesParc
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_SELL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_SELL()
        {
            this.TB_BILL = new HashSet<TB_BILL>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDClient { get; set; }
        public string ClientName { get; set; }
        public string PaymentState { get; set; }
        public Nullable<double> Payment { get; set; }
        public Nullable<double> Debt { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_BILL> TB_BILL { get; set; }
    }
}
