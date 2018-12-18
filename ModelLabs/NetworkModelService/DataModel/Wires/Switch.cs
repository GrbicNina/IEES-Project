using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Switch : ConductingEquipment
    {
        private bool normalOpen;
        private float ratedCurrent;
        private bool retained;
        private int switchOnCount;
        private DateTime switchOnDate;
        private List<long> switchSchedules = new List<long>();

        public Switch(long globalId) : base(globalId)
        {
        }

        public bool NormalOpen { get => normalOpen; set => normalOpen = value; }
        public float RatedCurrent { get => ratedCurrent; set => ratedCurrent = value; }
        public bool Retained { get => retained; set => retained = value; }
        public int SwitchOnCount { get => switchOnCount; set => switchOnCount = value; }
        public DateTime SwitchOnDate { get => switchOnDate; set => switchOnDate = value; }
        public List<long> SwitchSchedules { get => switchSchedules; set => switchSchedules = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Switch s = (Switch)obj;
                return ((s.normalOpen == this.normalOpen) && (s.ratedCurrent == this.ratedCurrent) && (s.retained == this.retained)
                    && (s.switchOnCount == this.switchOnCount) && (s.SwitchOnDate == this.SwitchOnDate)
                    && (CompareHelper.CompareLists(s.switchSchedules, this.switchSchedules, true)));
            }else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.SWITCH_NORMALOPEN:
                case ModelCode.SWITCH_RATEDCURR:
                case ModelCode.SWITCH_RETAINED:
                case ModelCode.SWITCH_SWONCOUNT:
                case ModelCode.SWITCH_SWONDATE:
                case ModelCode.SWITCH_SWITCHSCHEDULES:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.SWITCH_NORMALOPEN:
                    property.SetValue(normalOpen);
                    break;

                case ModelCode.SWITCH_RATEDCURR:
                    property.SetValue(ratedCurrent);
                    break;

                case ModelCode.SWITCH_RETAINED:
                    property.SetValue(retained);
                    break;

                case ModelCode.SWITCH_SWONCOUNT:
                    property.SetValue(switchOnCount);
                    break;

                case ModelCode.SWITCH_SWONDATE:
                    property.SetValue(switchOnDate);
                    break;

                case ModelCode.SWITCH_SWITCHSCHEDULES:
                    property.SetValue(switchSchedules);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.SWITCH_NORMALOPEN:
                    normalOpen = property.AsBool();
                    break;

                case ModelCode.SWITCH_RATEDCURR:
                    ratedCurrent = property.AsFloat();
                    break;

                case ModelCode.SWITCH_RETAINED:
                    retained = property.AsBool();
                    break;

                case ModelCode.SWITCH_SWONCOUNT:
                    switchOnCount = property.AsInt();
                    break;

                case ModelCode.SWITCH_SWONDATE:
                    switchOnDate  = property.AsDateTime();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return switchSchedules.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {

            if (switchSchedules != null && switchSchedules.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.SEASON_SEASONDTS] = switchSchedules.GetRange(0, switchSchedules.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCHSCHEDULE_SWITCH:
                    switchSchedules.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SWITCHSCHEDULE_SWITCH:

                    if (switchSchedules.Contains(globalId))
                    {
                        switchSchedules.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}
