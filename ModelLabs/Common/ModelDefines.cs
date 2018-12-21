using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

		DAYTYPE 							= 0x0001,
        SEASON                              = 0x0002,
        REGTIMEPOINT                        = 0x0003,
        BREAKER                             = 0x0004,
        RECLOSER                            = 0x0005,
        LOADBREAKSWITCH                     = 0x0006,
        SWITCHSCHEDULE                      = 0x0007,
	}


    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		IDOBJ_ALIASNAME					    = 0x1000000000000207,
		IDOBJ_MRID							= 0x1000000000000307,
		IDOBJ_NAME							= 0x1000000000000407,	

        DAYTYPE                             = 0x1100000000010000,
        DAYTYPE_SEASONDTS                   = 0x1100000000010119,

        SEASON                              = 0x1200000000020000,
        SEASON_ENDDATE                      = 0x1200000000020108,
        SEASON_STARTDATE                    = 0x1200000000020208,
        SEASON_SEASONDTS                    = 0x1200000000020319,

        REGTIMEPOINT                        = 0x1300000000030000,
        REGTIMEPOINT_SEQNUM                 = 0x1300000000030103,
        REGTIMEPOINT_VALUE1                 = 0x1300000000030205,
        REGTIMEPOINT_VALUE2                 = 0x1300000000030305,
        REGTIMEPOINT_REGINTERS              = 0x1300000000030409,

        PSR									= 0x1400000000000000,

		EQUIPMENT							= 0x1410000000000000,
		EQUIPMENT_AGGREGATE				    = 0x1410000000000101,
        EQUIPMENT_NORMALINSERVICE           = 0x1410000000000201,		

		CONDEQ								= 0x1411000000000000,

		SWITCH                              = 0x1411100000000000,
        SWITCH_NORMALOPEN                   = 0x1411100000000101,
        SWITCH_RATEDCURR                    = 0x1411100000000205,
        SWITCH_RETAINED                     = 0x1411100000000301,
        SWITCH_SWONCOUNT                    = 0x1411100000000403,
        SWITCH_SWONDATE                     = 0x1411100000000508,
        SWITCH_SWITCHSCHEDULES              = 0x1411100000000619,

        PROTECTEDSWITCH                     = 0x1411110000000000,
        PROTECTEDSWITCH_BREAKCAP            = 0x1411110000000105,

        BREAKER                             = 0x1411111000040000,
        BREAKER_INTRANTIME                  = 0x1411111000040105,

        RECLOSER                            = 0x1411112000050000,

        LOADBREAKSWITCH                     = 0x1411113000060000,

        BASICINTS                           = 0x1500000000000000,
        BASICINTS_STARTTIME                 = 0x1500000000000108,
        BASICINTS_VAL1MUL                   = 0x150000000000020a,
        BASICINTS_VAL1UNIT                  = 0x150000000000030a,
        BASICINTS_VAL2MUL                   = 0x150000000000040a,
        BASICINTS_VAL2UNIT                  = 0x150000000000050a,

        REGULARINTERVALSCH                  = 0x1510000000000000,
        REGULARINTERVALSCH_TIMEPOINTS       = 0x1510000000000119,

        SEASONDAYTYPESCH                    = 0x1511000000000000,
        SEASONDAYTYPESCH_DAYTYPE            = 0x1511000000000109,
        SEASONDAYTYPESCH_SEASON             = 0x1511000000000209,

        SWITCHSCHEDULE                      = 0x1511100000070000,
        SWITCHSCHEDULE_SWITCH               = 0x1511100000070109,

    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


