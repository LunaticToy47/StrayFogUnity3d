using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// FMS状态机映射
/// </summary>
public sealed class FMSMachineMaping
{	
	#region MachineForLayer映射
	/// <summary>
	/// MachineForLayer映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mMachineForLayerMaping = new Dictionary<int, List<int>>() {
		{ enFMSMachine.Base_Layer,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_Appear,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_Attack,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_CutOff,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_MaxSkill,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_Move,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSMachine.Base_Layer_Skill,new List<int> { enFMSLayer.Base_Layer_index0, } },
	};
	#endregion
	#region LayerForMachine映射
	/// <summary>
	/// LayerForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForMachineMaping = new Dictionary<int, List<int>>() {
		{ enFMSLayer.Base_Layer_index0,new List<int> { enFMSMachine.Base_Layer,enFMSMachine.Base_Layer_Attack,enFMSMachine.Base_Layer_Skill,enFMSMachine.Base_Layer_CutOff,enFMSMachine.Base_Layer_Move,enFMSMachine.Base_Layer_MaxSkill,enFMSMachine.Base_Layer_Appear, } },
	};
	#endregion
	#region StateForLayer映射
	/// <summary>
	/// StateForLayer映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForLayerMaping = new Dictionary<int, List<int>>() {
		{ enFMSState.Base_Layer_Attack_Attack1_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Attack_Attack1_2,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Attack_Attack2_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Attack_Attack2_2,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Attack_Attack3_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_CutOff_Die,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Move_Idle,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Move_Run,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Move_RunSample,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Skill_skill1_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Skill_skill1_2,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Skill_skill1_3,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Skill_skill2_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
		{ enFMSState.Base_Layer_Skill_skill3_1,new List<int> { enFMSLayer.Base_Layer_index0, } },
	};
	#endregion
	#region LayerForState映射
	/// <summary>
	/// LayerForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForStateMaping = new Dictionary<int, List<int>>() {
		{ enFMSLayer.Base_Layer_index0,new List<int> { enFMSState.Base_Layer_Attack_Attack1_2,enFMSState.Base_Layer_Attack_Attack2_2,enFMSState.Base_Layer_Attack_Attack3_1,enFMSState.Base_Layer_Attack_Attack1_1,enFMSState.Base_Layer_Attack_Attack2_1,enFMSState.Base_Layer_Skill_skill3_1,enFMSState.Base_Layer_Skill_skill2_1,enFMSState.Base_Layer_Skill_skill1_3,enFMSState.Base_Layer_Skill_skill1_1,enFMSState.Base_Layer_Skill_skill1_2,enFMSState.Base_Layer_CutOff_Die,enFMSState.Base_Layer_Move_Idle,enFMSState.Base_Layer_Move_Run,enFMSState.Base_Layer_Move_RunSample, } },
	};
	#endregion
	#region StateForMachine映射
	/// <summary>
	/// StateForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForMachineMaping = new Dictionary<int, List<int>>() {
		{ enFMSState.Base_Layer_Attack_Attack1_1,new List<int> { enFMSMachine.Base_Layer_Attack,} },
		{ enFMSState.Base_Layer_Attack_Attack1_2,new List<int> { enFMSMachine.Base_Layer_Attack,} },
		{ enFMSState.Base_Layer_Attack_Attack2_1,new List<int> { enFMSMachine.Base_Layer_Attack,} },
		{ enFMSState.Base_Layer_Attack_Attack2_2,new List<int> { enFMSMachine.Base_Layer_Attack,} },
		{ enFMSState.Base_Layer_Attack_Attack3_1,new List<int> { enFMSMachine.Base_Layer_Attack,} },
		{ enFMSState.Base_Layer_CutOff_Die,new List<int> { enFMSMachine.Base_Layer_CutOff,} },
		{ enFMSState.Base_Layer_Move_Idle,new List<int> { enFMSMachine.Base_Layer_Move,} },
		{ enFMSState.Base_Layer_Move_Run,new List<int> { enFMSMachine.Base_Layer_Move,} },
		{ enFMSState.Base_Layer_Move_RunSample,new List<int> { enFMSMachine.Base_Layer_Move,} },
		{ enFMSState.Base_Layer_Skill_skill1_1,new List<int> { enFMSMachine.Base_Layer_Skill,} },
		{ enFMSState.Base_Layer_Skill_skill1_2,new List<int> { enFMSMachine.Base_Layer_Skill,} },
		{ enFMSState.Base_Layer_Skill_skill1_3,new List<int> { enFMSMachine.Base_Layer_Skill,} },
		{ enFMSState.Base_Layer_Skill_skill2_1,new List<int> { enFMSMachine.Base_Layer_Skill,} },
		{ enFMSState.Base_Layer_Skill_skill3_1,new List<int> { enFMSMachine.Base_Layer_Skill,} },
	};
	#endregion
	#region MachineForState映射
	/// <summary>
	/// MachineForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mMachineForStateMaping = new Dictionary<int, List<int>>() {
		{ enFMSMachine.Base_Layer,new List<int> { } },
		{ enFMSMachine.Base_Layer_Appear,new List<int> { } },
		{ enFMSMachine.Base_Layer_Attack,new List<int> { enFMSState.Base_Layer_Attack_Attack1_2,enFMSState.Base_Layer_Attack_Attack2_2,enFMSState.Base_Layer_Attack_Attack3_1,enFMSState.Base_Layer_Attack_Attack1_1,enFMSState.Base_Layer_Attack_Attack2_1,} },
		{ enFMSMachine.Base_Layer_CutOff,new List<int> { enFMSState.Base_Layer_CutOff_Die,} },
		{ enFMSMachine.Base_Layer_MaxSkill,new List<int> { } },
		{ enFMSMachine.Base_Layer_Move,new List<int> { enFMSState.Base_Layer_Move_Idle,enFMSState.Base_Layer_Move_Run,enFMSState.Base_Layer_Move_RunSample,} },
		{ enFMSMachine.Base_Layer_Skill,new List<int> { enFMSState.Base_Layer_Skill_skill3_1,enFMSState.Base_Layer_Skill_skill2_1,enFMSState.Base_Layer_Skill_skill1_3,enFMSState.Base_Layer_Skill_skill1_1,enFMSState.Base_Layer_Skill_skill1_2,} },
	};
	#endregion
	#region IsMachine 是否是指定状态机
	/// <summary>
	/// 是否是指定状态机
	/// </summary>
	/// <param name="_animator">阿凡达</param>
	/// <param name="_machineNameHash">状态机NameHash值</param>
	/// <returns>true:是,false:否</returns>
	public static bool IsMachine(Animator _animator, int _machineNameHash)
	{
		bool result = false;
		if (mMachineForLayerMaping.ContainsKey(_machineNameHash))
		{
			if (mMachineForLayerMaping[_machineNameHash].Count > 0)
			{
				AnimatorStateInfo info;
				foreach (int layer in mMachineForLayerMaping[_machineNameHash])
				{
					info = _animator.GetCurrentAnimatorStateInfo(layer);
					if (mStateForMachineMaping.ContainsKey(info.shortNameHash))
					{
						foreach (int machineNameHash in mStateForMachineMaping[info.shortNameHash])
						{
							result |= _machineNameHash == machineNameHash;
							if (result)
							{
								break;
							}
						}
					}
					if (result)
					{
						break;
					}                    
				}
			}
		}
		return result;
	}
	#endregion
	#region IsState 是否是指定状态
	/// <summary>
	/// 是否是指定状态
	/// </summary>
	/// <param name="_animator">阿凡达</param>
	/// <param name="_stateNameHash">状态NameHash值</param>
	/// <returns>true:是,false:否</returns>
	public static bool IsState(Animator _animator,int _stateNameHash)
	{
		bool result = false;
		if (mStateForLayerMaping.ContainsKey(_stateNameHash))
		{
			if (mStateForLayerMaping[_stateNameHash].Count > 0)
			{
				AnimatorStateInfo info;
				foreach (int layer in mStateForLayerMaping[_stateNameHash])
				{
					info = _animator.GetCurrentAnimatorStateInfo(layer);
					result |= _stateNameHash == info.shortNameHash;
					if (result)
					{
						break;
					}
				}
			}
		}
		return result;
	}
	#endregion
}
#region enFMSLayer
/// <summary>
/// Layer层级
/// </summary>
public static class enFMSLayer
{
	/// <summary>
	/// Base Layer_index0
	/// </summary>
	[AliasTooltip("Base Layer_index0")]
	public const int Base_Layer_index0 = 0;
}
#endregion
#region enFMSMachine
/// <summary>
/// 状态机
/// </summary>
public static class enFMSMachine
{
	/// <summary>
	/// Base Layer
	/// </summary>
	[AliasTooltip("Base Layer")]
	public const int Base_Layer = 2132919814;
	/// <summary>
	/// Base Layer.Appear
	/// </summary>
	[AliasTooltip("Base Layer.Appear")]
	public const int Base_Layer_Appear = 1810299478;
	/// <summary>
	/// Base Layer.Attack
	/// </summary>
	[AliasTooltip("Base Layer.Attack")]
	public const int Base_Layer_Attack = -1066058642;
	/// <summary>
	/// Base Layer.CutOff
	/// </summary>
	[AliasTooltip("Base Layer.CutOff")]
	public const int Base_Layer_CutOff = 771977433;
	/// <summary>
	/// Base Layer.MaxSkill
	/// </summary>
	[AliasTooltip("Base Layer.MaxSkill")]
	public const int Base_Layer_MaxSkill = 768335021;
	/// <summary>
	/// Base Layer.Move
	/// </summary>
	[AliasTooltip("Base Layer.Move")]
	public const int Base_Layer_Move = -693355825;
	/// <summary>
	/// Base Layer.Skill
	/// </summary>
	[AliasTooltip("Base Layer.Skill")]
	public const int Base_Layer_Skill = 668503037;
}
#endregion
#region enFMSState
/// <summary>
/// 状态
/// </summary>
public static class enFMSState
{
	/// <summary>
	/// Base Layer.Attack.Attack1_1
	/// </summary>
	[AliasTooltip("Base Layer.Attack.Attack1_1")]
	public const int Base_Layer_Attack_Attack1_1 = -1621456835;
	/// <summary>
	/// Base Layer.Attack.Attack1_2
	/// </summary>
	[AliasTooltip("Base Layer.Attack.Attack1_2")]
	public const int Base_Layer_Attack_Attack1_2 = 106158471;
	/// <summary>
	/// Base Layer.Attack.Attack2_1
	/// </summary>
	[AliasTooltip("Base Layer.Attack.Attack2_1")]
	public const int Base_Layer_Attack_Attack2_1 = -1659095452;
	/// <summary>
	/// Base Layer.Attack.Attack2_2
	/// </summary>
	[AliasTooltip("Base Layer.Attack.Attack2_2")]
	public const int Base_Layer_Attack_Attack2_2 = 68511710;
	/// <summary>
	/// Base Layer.Attack.Attack3_1
	/// </summary>
	[AliasTooltip("Base Layer.Attack.Attack3_1")]
	public const int Base_Layer_Attack_Attack3_1 = -1663148973;
	/// <summary>
	/// Base Layer.CutOff.Die
	/// </summary>
	[AliasTooltip("Base Layer.CutOff.Die")]
	public const int Base_Layer_CutOff_Die = -150360828;
	/// <summary>
	/// Base Layer.Move.Idle
	/// </summary>
	[AliasTooltip("Base Layer.Move.Idle")]
	public const int Base_Layer_Move_Idle = -910840152;
	/// <summary>
	/// Base Layer.Move.Run
	/// </summary>
	[AliasTooltip("Base Layer.Move.Run")]
	public const int Base_Layer_Move_Run = 457199773;
	/// <summary>
	/// Base Layer.Move.RunSample
	/// </summary>
	[AliasTooltip("Base Layer.Move.RunSample")]
	public const int Base_Layer_Move_RunSample = -466899697;
	/// <summary>
	/// Base Layer.Skill.skill1_1
	/// </summary>
	[AliasTooltip("Base Layer.Skill.skill1_1")]
	public const int Base_Layer_Skill_skill1_1 = -1743932620;
	/// <summary>
	/// Base Layer.Skill.skill1_2
	/// </summary>
	[AliasTooltip("Base Layer.Skill.skill1_2")]
	public const int Base_Layer_Skill_skill1_2 = 17097358;
	/// <summary>
	/// Base Layer.Skill.skill1_3
	/// </summary>
	[AliasTooltip("Base Layer.Skill.skill1_3")]
	public const int Base_Layer_Skill_skill1_3 = 1979961880;
	/// <summary>
	/// Base Layer.Skill.skill2_1
	/// </summary>
	[AliasTooltip("Base Layer.Skill.skill2_1")]
	public const int Base_Layer_Skill_skill2_1 = -1706357395;
	/// <summary>
	/// Base Layer.Skill.skill3_1
	/// </summary>
	[AliasTooltip("Base Layer.Skill.skill3_1")]
	public const int Base_Layer_Skill_skill3_1 = -1685493926;
}
#endregion
#region enFMSParameter
/// <summary>
/// FMS参数
/// </summary>
public static class enFMSParameter
{
	/// <summary>
	/// exitAction_Trigger
	/// </summary>
	public const int exitAction_Trigger = -1189175008;
	/// <summary>
	/// sampleNormalizedTime_Float
	/// </summary>
	public const int sampleNormalizedTime_Float = 1709776050;
}
#endregion
