using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.LoadModel
{
    public class SeasonDayTypeSchedule : RegularIntervalSchedule
    {
        private long dayType = 0;
        private long season = 0;

        public SeasonDayTypeSchedule(long globalId) : base(globalId)
        {
        }

        public long DayType { get => dayType; set => dayType = value; }
        public long Season { get => season; set => season = value; }

        public override bool Equals(object obj)
        {
            if(base.Equals(obj))
            {
                SeasonDayTypeSchedule x = (SeasonDayTypeSchedule)obj;
                return ((x.dayType == this.dayType) && (x.season == this.season));
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

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SEASONDAYTYPESCH_DAYTYPE:
                case ModelCode.SEASONDAYTYPESCH_SEASON:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SEASONDAYTYPESCH_DAYTYPE:
                    property.SetValue(dayType);
                    break;

                case ModelCode.SEASONDAYTYPESCH_SEASON:
                    property.SetValue(season);
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
                case ModelCode.SEASONDAYTYPESCH_DAYTYPE:
                    dayType = property.AsReference();
                    break;

                case ModelCode.SEASONDAYTYPESCH_SEASON:
                    season = property.AsReference();
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
            if (dayType != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SEASONDAYTYPESCH_DAYTYPE] = new List<long>();
                references[ModelCode.SEASONDAYTYPESCH_DAYTYPE].Add(dayType);
            }
            base.GetReferences(references, refType);

            if (season != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SEASONDAYTYPESCH_SEASON] = new List<long>();
                references[ModelCode.SEASONDAYTYPESCH_SEASON].Add(season);
            }

            base.GetReferences(references, refType);
        }

        #endregion IReference implementation		
    }
}
