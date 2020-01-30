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
		{ enFMSMachine.Appear,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.Attack,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.Base_Layer,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.CutOff,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.MaxSkill,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.Move,new List<int> { enFMSLayer.layer0, } },
		{ enFMSMachine.Skill,new List<int> { enFMSLayer.layer0, } },
	};
	#endregion
	#region LayerForMachine映射
	/// <summary>
	/// LayerForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForMachineMaping = new Dictionary<int, List<int>>() {
		{ enFMSLayer.layer0,new List<int> { enFMSMachine.Base_Layer,enFMSMachine.Attack,enFMSMachine.Skill,enFMSMachine.CutOff,enFMSMachine.Move,enFMSMachine.MaxSkill,enFMSMachine.Appear, } },
	};
	#endregion
	#region StateForLayer映射
	/// <summary>
	/// StateForLayer映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForLayerMaping = new Dictionary<int, List<int>>() {
		{ enFMSState.Attack1_1,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Attack1_2,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Attack2_1,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Attack2_2,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Attack3_1,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Die,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Idle,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.Run,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.RunSample,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.skill1_1,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.skill1_2,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.skill1_3,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.skill2_1,new List<int> { enFMSLayer.layer0, } },
		{ enFMSState.skill3_1,new List<int> { enFMSLayer.layer0, } },
	};
	#endregion
	#region LayerForState映射
	/// <summary>
	/// LayerForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForStateMaping = new Dictionary<int, List<int>>() {
		{ enFMSLayer.layer0,new List<int> { enFMSState.Attack1_2,enFMSState.Attack2_2,enFMSState.Attack3_1,enFMSState.Attack1_1,enFMSState.Attack2_1,enFMSState.skill3_1,enFMSState.skill2_1,enFMSState.skill1_3,enFMSState.skill1_1,enFMSState.skill1_2,enFMSState.Die,enFMSState.Idle,enFMSState.Run,enFMSState.RunSample, } },
	};
	#endregion
	#region StateForMachine映射
	/// <summary>
	/// StateForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForMachineMaping = new Dictionary<int, List<int>>() {
		{ enFMSState.Attack1_1,new List<int> { enFMSMachine.Attack,} },
		{ enFMSState.Attack1_2,new List<int> { enFMSMachine.Attack,} },
		{ enFMSState.Attack2_1,new List<int> { enFMSMachine.Attack,} },
		{ enFMSState.Attack2_2,new List<int> { enFMSMachine.Attack,} },
		{ enFMSState.Attack3_1,new List<int> { enFMSMachine.Attack,} },
		{ enFMSState.Die,new List<int> { enFMSMachine.CutOff,} },
		{ enFMSState.Idle,new List<int> { enFMSMachine.Move,} },
		{ enFMSState.Run,new List<int> { enFMSMachine.Move,} },
		{ enFMSState.RunSample,new List<int> { enFMSMachine.Move,} },
		{ enFMSState.skill1_1,new List<int> { enFMSMachine.Skill,} },
		{ enFMSState.skill1_2,new List<int> { enFMSMachine.Skill,} },
		{ enFMSState.skill1_3,new List<int> { enFMSMachine.Skill,} },
		{ enFMSState.skill2_1,new List<int> { enFMSMachine.Skill,} },
		{ enFMSState.skill3_1,new List<int> { enFMSMachine.Skill,} },
	};
	#endregion
	#region MachineForState映射
	/// <summary>
	/// MachineForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mMachineForStateMaping = new Dictionary<int, List<int>>() {
		{ enFMSMachine.Appear,new List<int> { } },
		{ enFMSMachine.Attack,new List<int> { enFMSState.Attack1_2,enFMSState.Attack2_2,enFMSState.Attack3_1,enFMSState.Attack1_1,enFMSState.Attack2_1,} },
		{ enFMSMachine.Base_Layer,new List<int> { } },
		{ enFMSMachine.CutOff,new List<int> { enFMSState.Die,} },
		{ enFMSMachine.MaxSkill,new List<int> { } },
		{ enFMSMachine.Move,new List<int> { enFMSState.Idle,enFMSState.Run,enFMSState.RunSample,} },
		{ enFMSMachine.Skill,new List<int> { enFMSState.skill3_1,enFMSState.skill2_1,enFMSState.skill1_3,enFMSState.skill1_1,enFMSState.skill1_2,} },
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
	/// layer0
	/// </summary>
	[AliasTooltip("layer0")]
	public const int layer0 = 0;
}
#endregion
#region enFMSMachine
/// <summary>
/// 状态机
/// </summary>
public static class enFMSMachine
{
	/// <summary>
	/// Appear
	/// </summary>
	[AliasTooltip("Appear")]
	public const int Appear = 37004531;
	/// <summary>
	/// Attack
	/// </summary>
	[AliasTooltip("Attack")]
	public const int Attack = -1608400166;
	/// <summary>
	/// Base Layer
	/// </summary>
	[AliasTooltip("Base Layer")]
	public const int Base_Layer = 2132919814;
	/// <summary>
	/// CutOff
	/// </summary>
	[AliasTooltip("CutOff")]
	public const int CutOff = 665510285;
	/// <summary>
	/// MaxSkill
	/// </summary>
	[AliasTooltip("MaxSkill")]
	public const int MaxSkill = 1993193975;
	/// <summary>
	/// Move
	/// </summary>
	[AliasTooltip("Move")]
	public const int Move = -863935284;
	/// <summary>
	/// Skill
	/// </summary>
	[AliasTooltip("Skill")]
	public const int Skill = 17973819;
}
#endregion
#region enFMSState
/// <summary>
/// 状态
/// </summary>
public static class enFMSState
{
	/// <summary>
	/// Attack1_1
	/// </summary>
	[AliasTooltip("Attack1_1")]
	public const int Attack1_1 = -1483470882;
	/// <summary>
	/// Attack1_2
	/// </summary>
	[AliasTooltip("Attack1_2")]
	public const int Attack1_2 = 1050498660;
	/// <summary>
	/// Attack2_1
	/// </summary>
	[AliasTooltip("Attack2_1")]
	public const int Attack2_1 = -1512916601;
	/// <summary>
	/// Attack2_2
	/// </summary>
	[AliasTooltip("Attack2_2")]
	public const int Attack2_2 = 1021044797;
	/// <summary>
	/// Attack3_1
	/// </summary>
	[AliasTooltip("Attack3_1")]
	public const int Attack3_1 = -1542401104;
	/// <summary>
	/// Die
	/// </summary>
	[AliasTooltip("Die")]
	public const int Die = 20298039;
	/// <summary>
	/// Idle
	/// </summary>
	[AliasTooltip("Idle")]
	public const int Idle = 2081823275;
	/// <summary>
	/// Run
	/// </summary>
	[AliasTooltip("Run")]
	public const int Run = 1748754976;
	/// <summary>
	/// RunSample
	/// </summary>
	[AliasTooltip("RunSample")]
	public const int RunSample = -1024391356;
	/// <summary>
	/// skill1_1
	/// </summary>
	[AliasTooltip("skill1_1")]
	public const int skill1_1 = -2049895578;
	/// <summary>
	/// skill1_2
	/// </summary>
	[AliasTooltip("skill1_2")]
	public const int skill1_2 = 483934940;
	/// <summary>
	/// skill1_3
	/// </summary>
	[AliasTooltip("skill1_3")]
	public const int skill1_3 = 1809805898;
	/// <summary>
	/// skill2_1
	/// </summary>
	[AliasTooltip("skill2_1")]
	public const int skill2_1 = -2020102849;
	/// <summary>
	/// skill3_1
	/// </summary>
	[AliasTooltip("skill3_1")]
	public const int skill3_1 = -2041198840;
}
#endregion
#region enFMSParameter
/// <summary>
/// FMS参数
/// </summary>
public static class enFMSParameter
{
	/// <summary>
	/// exitAction
	/// </summary>
	public const int exitAction = -1189175008;
	/// <summary>
	/// sampleNormalizedTime
	/// </summary>
	public const int sampleNormalizedTime = 1709776050;
}
#endregion
