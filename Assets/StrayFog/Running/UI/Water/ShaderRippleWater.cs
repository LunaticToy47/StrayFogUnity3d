using UnityEngine;
/// <summary>
/// ShaderRippleWater
/// </summary>
[AddComponentMenu("Game/Shader/Water/RippleWater")]
[RequireComponent(typeof(Renderer))]
public class ShaderRippleWater : MonoBehaviour
{
    /// <summary>
    /// Base(RGB) Texture2D
    /// </summary>
    [AliasTooltip("Base(RGB) Texture2D")]
    public Texture2D baseTexture;
    /// <summary>
    /// Base(RGB) Tiling
    /// </summary>
    [AliasTooltip("Base(RGB) Tiling")]
    public Vector2 baseTiling = Vector2.one;
    /// <summary>
    /// Base(RGB) Offset
    /// </summary>
    [AliasTooltip("Base(RGB) Offset")]
    public Vector2 baseOffset;

    /// <summary>
    /// Wave Noise Texture2D
    /// </summary>
    [AliasTooltip("Wave Noise Texture2D")]
    public Texture2D waveNoiseTexture;
    /// <summary>
    /// Wave Noise Tiling
    /// </summary>
    [AliasTooltip("Wave Noise Tiling")]
    public Vector2 waveNoiseTiling = Vector2.one;
    /// <summary>
    /// Wave Noise Offset
    /// </summary>
    [AliasTooltip("Wave Noise Offset")]
    public Vector2 waveNoiseOffset;
    /// <summary>
    /// Tint
    /// </summary>
    [AliasTooltip("Tint")]
    public Color tint = Color.white;
    /// <summary>
    /// Indentity
    /// </summary>
    [AliasTooltip("Indentity(水波扭曲强度)")]
    public float indentity = 0.1f;
    /// <summary>
    /// WaveSpeedX
    /// </summary>
    [AliasTooltip("WaveSpeedX(噪波贴图延X方向的移动速度)")]
    public float waveSpeedX = 0.08f;
    /// <summary>
    /// WaveSpeedY
    /// </summary>
    [AliasTooltip("WaveSpeedY(噪波贴图延Y方向的移动速度)")]
    public float waveSpeedY = 0.04f;
    /// <summary>
    /// AlphaFadeIn
    /// </summary>
    [AliasTooltip("AlphaFadeIn(水波的淡入位置)")]
    public float alphaFadeIn = 0.0f;
    /// <summary>
    /// AlphaFadeOut
    /// </summary>
    [AliasTooltip("AlphaFadeOut(水波的淡出位置)")]
    public float alphaFadeOut = 1.0f;
    /// <summary>
    /// TwistFadeIn
    /// </summary>
    [AliasTooltip("TwistFadeIn(扭曲的淡入位置)")]
    public float twistFadeIn = 1.0f;
    /// <summary>
    /// TwistFadeOut
    /// </summary>
    [AliasTooltip("TwistFadeOut(扭曲的淡出位置)")]
    public float twistFadeOut = 1.0f;
    /// <summary>
    /// TwistFadeInIndentity
    /// </summary>
    [AliasTooltip("TwistFadeInIndentity(扭曲的淡入强度)")]
    public float twistFadeInIndentity = 0.02f;
    /// <summary>
    /// TwistFadeOutIndentity
    /// </summary>
    [AliasTooltip("TwistFadeOutIndentity(扭曲的淡出强度)")]
    public float twistFadeOutIndentity = 0.01f;

    /// <summary>
    /// Renderer
    /// </summary>
    Renderer mRenderer;
    /// <summary>
    /// 材质
    /// </summary>
    Material mMaterial;
    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        mRenderer = GetComponent<Renderer>();
        mMaterial = mRenderer.material;
    }

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        mMaterial.SetTexture("_MainTex", baseTexture);
        mMaterial.SetTextureScale("_MainTex", baseTiling);
        mMaterial.SetTextureOffset("_MainTex", baseOffset);

        mMaterial.SetTexture("_NoiseTex", waveNoiseTexture);
        mMaterial.SetTextureScale("_NoiseTex", waveNoiseTiling);
        mMaterial.SetTextureOffset("_NoiseTex", waveNoiseOffset);

        mMaterial.SetColor("_Color", tint);
        mMaterial.SetFloat("_Indentity", indentity);

        mMaterial.SetFloat("_WaveSpeedX", waveSpeedX);
        mMaterial.SetFloat("_WaveSpeedY", waveSpeedY);

        mMaterial.SetFloat("_AlphaFadeIn", alphaFadeIn);
        mMaterial.SetFloat("_AlphaFadeOut", alphaFadeOut);
        mMaterial.SetFloat("_TwistFadeIn", twistFadeIn);
        mMaterial.SetFloat("_TwistFadeOut", twistFadeOut);
        mMaterial.SetFloat("_TwistFadeInIndentity", twistFadeInIndentity);
        mMaterial.SetFloat("_TwistFadeOutIndentity", twistFadeOutIndentity);
    }
}
