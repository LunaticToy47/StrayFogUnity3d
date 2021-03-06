﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// Skill关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleSkillLevel")]
public class ExampleSkillLevel : AbsLevel
{
    /// <summary>
    /// 状态映射
    /// </summary>
    Dictionary<string, int> mFMSStateMaping = typeof(enFMSState).NameToValueForConstField();
    /// <summary>
    /// 参数映射
    /// </summary>
    Dictionary<string, int> mFMSParameterMaping = typeof(enFMSParameter).NameToValueForConstField();
    /// <summary>
    /// 英雄状态机
    /// </summary>
    FMSMachine mFMSMachine = null;
    /// <summary>
    /// State滚动视图位置
    /// </summary>
    Vector2 mStateScrollViewPosition = Vector2.zero;
    /// <summary>
    /// Parameter滚动视图位置
    /// </summary>
    Vector2 mParameterScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 采样归一化时间
    /// </summary>
    float mSampleNormalizedTime = 0;
    /// <summary>
    /// 自动采样
    /// </summary>
    bool mAutoSample = true;
    /// <summary>
    /// OnRunAwake
    /// </summary>
    protected override void OnRunAwake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {
                coroutine.StartCoroutine(LoadCharacter());
            });            
        });
    }

    /// <summary>
    /// 加载角色
    /// </summary>
    /// <returns>异步</returns>
    IEnumerator LoadCharacter()
    {
        yield return new WaitForSeconds(1);        
        Stopwatch watch = new Stopwatch();
        watch.Start();
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(enAssetDiskMapingFile.f_pf_hero_1002_prefab, enAssetDiskMapingFolder.Assets_Example_AssetBundles_Prefabs_Character,
            (output) =>
            {
                output.Instantiate<GameObject>((result) =>
                {
                    GameObject hero = (GameObject)result.asset;
                    Stopwatch w = (Stopwatch)result.input.extraParameter[0];
                    w.Stop();
                    UnityEngine.Debug.Log(w.Elapsed + "=>" + hero.gameObject);

                    Animator animator = hero.GetComponent<Animator>();
                    mFMSMachine = hero.GetComponent<FMSMachine>();
                    if (mFMSMachine == null)
                    {
                        mFMSMachine = hero.AddDynamicComponent<FMSMachine>();
                    }
                    mFMSMachine.SetAnimator(animator);
                    mFMSMachine.gameObject.transform.position = new Vector3(-7, 0, -3);
                    mFMSMachine.gameObject.transform.eulerAngles = Vector3.up * 90;
                });
            }, watch);
    }

    /// <summary>
    /// OnRunGUI
    /// </summary>
    protected override void OnRunGUI()
    {
        if (mFMSMachine != null)
        {
            GUILayout.BeginVertical();

            mStateScrollViewPosition = GUILayout.BeginScrollView(mStateScrollViewPosition);
            GUILayout.BeginHorizontal();
            foreach (KeyValuePair<string, int> key in mFMSStateMaping)
            {
                if (GUILayout.Button(key.Key))
                {
                    mFMSMachine.CrossFade(key.Value);
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();

            mParameterScrollViewPosition = GUILayout.BeginScrollView(mParameterScrollViewPosition);
            GUILayout.BeginHorizontal();
            foreach (KeyValuePair<string, int> key in mFMSParameterMaping)
            {
                if (GUILayout.Button(key.Key.ToString()))
                {
                    switch (key.Value)
                    {
                        case enFMSParameter.exitAction_Trigger:
                            mFMSMachine.SetTrigger(key.Value, true);
                            break;
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();

            if (mFMSMachine.IsState(enFMSState.Base_Layer_Move_RunSample))
            {
                GUILayout.BeginHorizontal();
                mAutoSample = GUILayout.Toggle(mAutoSample, "Auto Sample");
                mSampleNormalizedTime = GUILayout.HorizontalSlider(mSampleNormalizedTime, 0, 1);
                mFMSMachine.SetFloat(enFMSParameter.sampleNormalizedTime_Float, mSampleNormalizedTime);
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }
        }
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
        StrayFogGamePools.eventHandlerManager.DrawLevelSelectButtonOnGUI();
    }
    protected override void OnRunUpdate()
    {
        if (mAutoSample)
        {
            mSampleNormalizedTime += deltaTime;
            mSampleNormalizedTime -= Mathf.FloorToInt(mSampleNormalizedTime);
            //UnityEngine.Debug.Log(mFMSMachine.animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
}
