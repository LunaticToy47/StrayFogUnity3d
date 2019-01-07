using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// UIWindowSetting实体
/// </summary>
public partial class Table_UIWindowSetting: AbsSQLiteEntity
{
	/// <summary>
    /// PK键组
    /// </summary>
    public override object[] pks { get { return new List<object>() { id,}.ToArray(); } }

	
	/// <summary>
	/// 窗口id
	/// </summary>
	public int id { get; private set; }
	/// <summary>
	/// 窗口名称
	/// </summary>
	public string name { get; private set; }
	/// <summary>
	/// 文件夹id
	/// </summary>
	public int folderId { get; private set; }
	/// <summary>
	/// 文件id
	/// </summary>
	public int fileId { get; private set; }
	/// <summary>
	/// 画布绘制模式
	/// </summary>
	public int renderMode { get; private set; }
	/// <summary>
	/// 窗口Layer
	/// </summary>
	public int layer { get; private set; }
	/// <summary>
	/// 窗口打开模式
	/// </summary>
	public int openMode { get; private set; }
	/// <summary>
	/// 窗口关闭模式
	/// </summary>
	public int closeMode { get; private set; }
	/// <summary>
	/// 是否忽略打开关闭模式
	/// </summary>
	public bool isIgnoreOpenCloseMode { get; private set; }
	/// <summary>
	/// 是否是不可自动恢复序列窗口
	/// </summary>
	public bool isNotAutoRestoreSequenceWindow { get; private set; }
	/// <summary>
	/// 是否是不可销毁实例
	/// </summary>
	public bool isDonotDestroyInstance { get; private set; }
	/// <summary>
	/// 是否立即显示
	/// </summary>
	public bool isImmediateDisplay { get; private set; }
	/// <summary>
	/// 跳转场景时是否手动关闭
	/// </summary>
	public bool isManualCloseWhenGotoScene { get; private set; }
	/// <summary>
	/// 是否是引导窗口
	/// </summary>
	public bool isGuideWindow { get; private set; }
}