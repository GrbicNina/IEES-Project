using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class RegularTimePoint : IdentifiedObject
    {
        private int sequenceNumber;
        private float value1;
        private float value2;
        private long regularIntervalSchedule = 0;
        public RegularTimePoint(long globalId) : base(globalId)
        {
        }

        public int SequenceNumber { get => sequenceNumber; set => sequenceNumber = value; }
        public float Value1 { get => value1; set => value1 = value; }
        public float Value2 { get => value2; set => value2 = value; }
        public long RegularIntervalSchedule { get => regularIntervalSchedule; set => regularIntervalSchedule = value; }

        public override bool Equals(object x)
        {
            if(base.Equals(x))
            {
                RegularTimePoint rtp = (RegularTimePoint)x;
                return (rtp.sequenceNumber == this.sequenceNumber && rtp.value1 == this.value1 &&
                    rtp.value2 == this.value2 && rtp.regularIntervalSchedule == this.regularIntervalSchedule);
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
                case ModelCode.REGTIMEPOINT_SEQNUM:
                case ModelCode.REGTIMEPOINT_VALUE1:
                case ModelCode.REGTIMEPOINT_VALUE2:
                case ModelCode.REGTIMEPOINT_REGINTERS:

                    return true;
                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.REGTIMEPOINT_SEQNUM:
                    property.SetValue(sequenceNumber);
                    break;

                case ModelCode.REGTIMEPOINT_VALUE1:
                    property.SetValue(value1);
                    break;

                case ModelCode.REGTIMEPOINT_VALUE2:
                    property.SetValue(value2);
                    break;
                case ModelCode.REGTIMEPOINT_REGINTERS:
                    property.SetValue(regularIntervalSchedule);
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
                case ModelCode.REGTIMEPOINT_SEQNUM:
                    sequenceNumber = property.AsInt();
                    break;

                case ModelCode.REGTIMEPOINT_VALUE1:
                    value1 = property.AsFloat();
                    break;

                case ModelCode.REGTIMEPOINT_VALUE2:
                    value2 = property.AsFloat();
                    break;

                case ModelCode.REGTIMEPOINT_REGINTERS:
                    regularIntervalSchedule = property.AsLong();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation	

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regularIntervalSchedule != 0 && (refType != TypeOfReference.Reference || refType != TypeOfReference.Both))
            {
                references[ModelCode.REGTIMEPOINT_REGINTERS] = new List<long>();
                references[ModelCode.REGTIMEPOINT_REGINTERS].Add(regularIntervalSchedule);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation

    }
}
