
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
/// <summary>
/// FMS关卡
/// </summary>
[AddComponentMenu("Game/StrayFogFMSLevel")]
public class StrayFogFMSLevel : AbsLevel
{
    /// <summary>
    /// 状态映射
    /// </summary>
    Dictionary<string, int> mFMSStateMaping = typeof(enFMSState).NameToValue();
    /// <summary>
    /// 参数映射
    /// </summary>
    Dictionary<enFMSParameter, int> mFMSParameterMaping = typeof(enFMSParameter).EnumToValue<enFMSParameter>();
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
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StartCoroutine(LoadCharacter());
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
        StrayFogGamePools.assetBundleManager.LoadAssetInMemory(enAssetDiskMapingFile.f_pf_hero_1002_prefab, enAssetDiskMapingFolder.Assets_Game_AssetBundles_Prefabs_Character,
            (result) =>
            {
                result.Instantiate<GameObject>((rst,args)=> {
                    GameObject hero = rst;
                    Stopwatch w = (Stopwatch)args[0];
                    w.Stop();
                    UnityEngine.Debug.Log(w.Elapsed + "=>" + hero.gameObject);

                    Animator animator = hero.GetComponent<Animator>();
                    mFMSMachine = hero.GetComponent<FMSMachine>();
                    if (mFMSMachine == null)
                    {
                        mFMSMachine = hero.AddComponent<FMSMachine>();
                    }
                    mFMSMachine.SetAnimator(animator);
                    mFMSMachine.transform.position = Vector3.back * 7;
                    mFMSMachine.transform.eulerAngles = Vector3.up * 180;
                }, result.extraParameter);
                
            }, watch);
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
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
                if (mFMSMachine.IsState(key.Value))
                {
                    UnityEngine.Debug.Log(string.Format("Current State 【{0}】", (enFMSState)key.Value));
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();

            mParameterScrollViewPosition = GUILayout.BeginScrollView(mParameterScrollViewPosition);
            GUILayout.BeginHorizontal();
            foreach (KeyValuePair<enFMSParameter, int> key in mFMSParameterMaping)
            {
                if (GUILayout.Button(key.Key.ToString()))
                {
                    switch (key.Key)
                    {
                        case enFMSParameter.exitAction:
                            mFMSMachine.SetTrigger(key.Key, true);
                            break;
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();

            if (mFMSMachine.IsState(enFMSState.RunSample))
            {
                GUILayout.BeginHorizontal();
                mAutoSample = GUILayout.Toggle(mAutoSample,"Auto Sample");
                mSampleNormalizedTime = GUILayout.HorizontalSlider(mSampleNormalizedTime, 0, 1);
                mFMSMachine.SetFloat(enFMSParameter.sampleNormalizedTime, mSampleNormalizedTime);
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }            
        }
    }

    private void Update()
    {
        if (mAutoSample)
        {
            mSampleNormalizedTime += deltaTime;
        }
    }
}
