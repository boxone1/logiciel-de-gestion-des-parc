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
    
    public partial class TB_BILL
    {
        public int ID { get; set; }
        public Nullable<int> IDSell { get; set; }
        public Nullable<int> IDClient { get; set; }
        public string ClientName { get; set; }
        public string Article { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Unity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> PriceAfterDiscount { get; set; }
    
        public virtual TB_SELL TB_SELL { get; set; }
    }
}
