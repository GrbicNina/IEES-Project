//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FTN {
    using System;
    using FTN;
    
    
    /// The parts of a power system that are physical devices, electronic or mechanical.
    public class Equipment : PowerSystemResource {
        
        /// The single instance of equipment represents multiple pieces of equipment that have been modeled together as an aggregate.  Examples would be power transformers or sychronous machines operating in parallel modeled as a single aggregate power transformer or aggregate synchronous machine.  This is not to be used to indicate equipment that is part of a group of interdependent equipment produced by a network production program.
        private System.Boolean? cim_aggregate;
        
        private const bool isAggregateMandatory = false;
        
        private const string _aggregatePrefix = "cim";
        
        /// If true, the equipment is normally in service.
        private System.Boolean? cim_normallyInService;
        
        private const bool isNormallyInServiceMandatory = false;
        
        private const string _normallyInServicePrefix = "cim";
        
        public virtual bool Aggregate {
            get {
                return this.cim_aggregate.GetValueOrDefault();
            }
            set {
                this.cim_aggregate = value;
            }
        }
        
        public virtual bool AggregateHasValue {
            get {
                return this.cim_aggregate != null;
            }
        }
        
        public static bool IsAggregateMandatory {
            get {
                return isAggregateMandatory;
            }
        }
        
        public static string AggregatePrefix {
            get {
                return _aggregatePrefix;
            }
        }
        
        public virtual bool NormallyInService {
            get {
                return this.cim_normallyInService.GetValueOrDefault();
            }
            set {
                this.cim_normallyInService = value;
            }
        }
        
        public virtual bool NormallyInServiceHasValue {
            get {
                return this.cim_normallyInService != null;
            }
        }
        
        public static bool IsNormallyInServiceMandatory {
            get {
                return isNormallyInServiceMandatory;
            }
        }
        
        public static string NormallyInServicePrefix {
            get {
                return _normallyInServicePrefix;
            }
        }
    }
}
