using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class BasicIntervalSchedule : IdentifiedObject
    {
        private DateTime startTime;
        private float value1Multiplier;
        private float value1Unit;
        private float value2Multiplier;
        private float value2Unit;

        public BasicIntervalSchedule(long globalId) : base(globalId)
        {
        }

        public float Value1Multiplier { get => value1Multiplier; set => value1Multiplier = value; }
        public float Value1Unit { get => value1Unit; set => value1Unit = value; }
        public float Value2Multiplier { get => value2Multiplier; set => value2Multiplier = value; }
        public float Value2Unit { get => value2Unit; set => value2Unit = value; }

        public override bool Equals(object obj)
        {
            if(Object.ReferenceEquals(obj, null))
            {
                return false;
            }else
            {
                BasicIntervalSchedule bs = (BasicIntervalSchedule)obj;
                return ((bs.startTime == this.startTime) && (bs.value1Multiplier == this.value1Multiplier) &&
                    (bs.value1Unit == this.value1Unit) && (bs.value2Multiplier == this.value2Multiplier) && (bs.value2Unit == this.value2Unit));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.BASICINTS_STARTTIME:
                case ModelCode.BASICINTS_VAL1MUL:
                case ModelCode.BASICINTS_VAL1UNIT:
                case ModelCode.BASICINTS_VAL2MUL:
                case ModelCode.BASICINTS_VAL2UNIT:
                    return true;
                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.BASICINTS_STARTTIME:
                    property.SetValue(startTime);
                    break;

                case ModelCode.BASICINTS_VAL1MUL:
                    property.SetValue(value1Multiplier);
                    break;
                case ModelCode.BASICINTS_VAL1UNIT:
                    property.SetValue(Value1Unit);
                    break;
                case ModelCode.BASICINTS_VAL2MUL:
                    property.SetValue(value2Multiplier);
                    break;
                case ModelCode.BASICINTS_VAL2UNIT:
                    property.SetValue(value2Unit);
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
                case ModelCode.BASICINTS_STARTTIME:
                    startTime = property.AsDateTime();
                    break;
                case ModelCode.BASICINTS_VAL1MUL:
                    value1Multiplier = property.AsFloat();
                    break;
                case ModelCode.BASICINTS_VAL1UNIT:
                    value1Unit = property.AsFloat();
                    break;
                case ModelCode.BASICINTS_VAL2MUL:
                    value2Multiplier = property.AsFloat();
                    break;
                case ModelCode.BASICINTS_VAL2UNIT:
                    value2Unit = property.AsFloat();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation
    }
}
