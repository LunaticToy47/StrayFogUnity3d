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
		{ (int)enFMSMachine.Appear,new List<int> { 0, } },
		{ (int)enFMSMachine.Attack,new List<int> { 0, } },
		{ (int)enFMSMachine.Base_Layer,new List<int> { 0, } },
		{ (int)enFMSMachine.CutOff,new List<int> { 0, } },
		{ (int)enFMSMachine.MaxSkill,new List<int> { 0, } },
		{ (int)enFMSMachine.Move,new List<int> { 0, } },
		{ (int)enFMSMachine.Skill,new List<int> { 0, } },
	};
	#endregion
	#region LayerForMachine映射
	/// <summary>
	/// LayerForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForMachineMaping = new Dictionary<int, List<int>>() {
		{ 0,new List<int> { (int)enFMSMachine.Base_Layer,(int)enFMSMachine.Attack,(int)enFMSMachine.Skill,(int)enFMSMachine.CutOff,(int)enFMSMachine.Move,(int)enFMSMachine.MaxSkill,(int)enFMSMachine.Appear, } },
	};
	#endregion
	#region StateForLayer映射
	/// <summary>
	/// StateForLayer映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForLayerMaping = new Dictionary<int, List<int>>() {
		{ (int)enFMSState.Attack1_1,new List<int> { 0, } },
		{ (int)enFMSState.Attack1_2,new List<int> { 0, } },
		{ (int)enFMSState.Attack2_1,new List<int> { 0, } },
		{ (int)enFMSState.Attack2_2,new List<int> { 0, } },
		{ (int)enFMSState.Attack3_1,new List<int> { 0, } },
		{ (int)enFMSState.Die,new List<int> { 0, } },
		{ (int)enFMSState.Idle,new List<int> { 0, } },
		{ (int)enFMSState.Run,new List<int> { 0, } },
		{ (int)enFMSState.RunSample,new List<int> { 0, } },
		{ (int)enFMSState.skill1_1,new List<int> { 0, } },
		{ (int)enFMSState.skill1_2,new List<int> { 0, } },
		{ (int)enFMSState.skill1_3,new List<int> { 0, } },
		{ (int)enFMSState.skill2_1,new List<int> { 0, } },
		{ (int)enFMSState.skill3_1,new List<int> { 0, } },
	};
	#endregion
	#region LayerForState映射
	/// <summary>
	/// LayerForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mLayerForStateMaping = new Dictionary<int, List<int>>() {
		{ 0,new List<int> { (int)enFMSState.Attack1_2,(int)enFMSState.Attack2_2,(int)enFMSState.Attack3_1,(int)enFMSState.Attack1_1,(int)enFMSState.Attack2_1,(int)enFMSState.skill3_1,(int)enFMSState.skill2_1,(int)enFMSState.skill1_3,(int)enFMSState.skill1_1,(int)enFMSState.skill1_2,(int)enFMSState.Die,(int)enFMSState.Idle,(int)enFMSState.Run,(int)enFMSState.RunSample, } },
	};
	#endregion
	#region StateForMachine映射
	/// <summary>
	/// StateForMachine映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mStateForMachineMaping = new Dictionary<int, List<int>>() {
		{ (int)enFMSState.Attack1_1,new List<int> { (int)enFMSMachine.Attack,} },
		{ (int)enFMSState.Attack1_2,new List<int> { (int)enFMSMachine.Attack,} },
		{ (int)enFMSState.Attack2_1,new List<int> { (int)enFMSMachine.Attack,} },
		{ (int)enFMSState.Attack2_2,new List<int> { (int)enFMSMachine.Attack,} },
		{ (int)enFMSState.Attack3_1,new List<int> { (int)enFMSMachine.Attack,} },
		{ (int)enFMSState.Die,new List<int> { (int)enFMSMachine.CutOff,} },
		{ (int)enFMSState.Idle,new List<int> { (int)enFMSMachine.Move,} },
		{ (int)enFMSState.Run,new List<int> { (int)enFMSMachine.Move,} },
		{ (int)enFMSState.RunSample,new List<int> { (int)enFMSMachine.Move,} },
		{ (int)enFMSState.skill1_1,new List<int> { (int)enFMSMachine.Skill,} },
		{ (int)enFMSState.skill1_2,new List<int> { (int)enFMSMachine.Skill,} },
		{ (int)enFMSState.skill1_3,new List<int> { (int)enFMSMachine.Skill,} },
		{ (int)enFMSState.skill2_1,new List<int> { (int)enFMSMachine.Skill,} },
		{ (int)enFMSState.skill3_1,new List<int> { (int)enFMSMachine.Skill,} },
	};
	#endregion
	#region MachineForState映射
	/// <summary>
	/// MachineForState映射
	/// </summary>
	readonly static Dictionary<int, List<int>> mMachineForStateMaping = new Dictionary<int, List<int>>() {
		{ (int)enFMSMachine.Appear,new List<int> { } },
		{ (int)enFMSMachine.Attack,new List<int> { (int)enFMSState.Attack1_2,(int)enFMSState.Attack2_2,(int)enFMSState.Attack3_1,(int)enFMSState.Attack1_1,(int)enFMSState.Attack2_1,} },
		{ (int)enFMSMachine.Base_Layer,new List<int> { } },
		{ (int)enFMSMachine.CutOff,new List<int> { (int)enFMSState.Die,} },
		{ (int)enFMSMachine.MaxSkill,new List<int> { } },
		{ (int)enFMSMachine.Move,new List<int> { (int)enFMSState.Idle,(int)enFMSState.Run,(int)enFMSState.RunSample,} },
		{ (int)enFMSMachine.Skill,new List<int> { (int)enFMSState.skill3_1,(int)enFMSState.skill2_1,(int)enFMSState.skill1_3,(int)enFMSState.skill1_1,(int)enFMSState.skill1_2,} },
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
                AnimatorStateInfo next;
                foreach (int layer in mStateForLayerMaping[_stateNameHash])
				{
					info = _animator.GetCurrentAnimatorStateInfo(layer);
                    next = _animator.GetNextAnimatorStateInfo(layer);
                    result |= _stateNameHash == info.shortNameHash || _stateNameHash == next.shortNameHash;
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
    public const int Appear = -1415179385;
	/// <summary>
	/// Attack
	/// </summary>
	[AliasTooltip("Attack")]
	public const int Attack = -1829219820;
    /// <summary>
    /// Base Layer
    /// </summary>
    [AliasTooltip("Base Layer")]
    public const int Base_Layer = -1383819056;
    /// <summary>
    /// CutOff
    /// </summary>
    [AliasTooltip("CutOff")]

    public const int CutOff = 2039771337;
    /// <summary>
    /// MaxSkill
    /// </summary>
    [AliasTooltip("MaxSkill")]

    public const int MaxSkill = 384028137;
    /// <summary>
    /// Move
    /// </summary>
    [AliasTooltip("Move")]

    public const int Move = 2055856572;
    /// <summary>
    /// Skill
    /// </summary>
    [AliasTooltip("Skill")]

    public const int Skill = 909255867;
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
