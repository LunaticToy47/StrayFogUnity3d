using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 绘制遮罩【Shader版】
/// 依赖项
/// 1.UIGraphicMaskShader.shader
/// </summary>
[AddComponentMenu("StrayFog/Game/UI/GraphicMask/Shader")]
public class UIGraphicMaskShader : AbsUIGraphicMask
{
    #region OnPopulateMesh
    /// <summary>
    /// 空图
    /// </summary>
    Texture2D mTextureClear = null;
    /// <summary>
    /// 当前最大图数量
    /// </summary>
    readonly int mMaxTextureNum = 6;
    /// <summary>
    /// Fill the vertex buffer data.
    /// </summary>
    /// <param name="_vh">顶点Helper</param>
    protected override void OnPopulateMesh(VertexHelper _vh)
    {
        OnClearRemoveMask();
        if (graphicMasks != null && graphicMasks.Count > 0)
        {
            Rect sceneRect = this.GraphicLocalRectForVertexHelper();
            switch (graphicClassify)
            {
                case enGraphicMaskClassify.Scene:
                    OnFillScene(sceneRect, graphicMasks);
                    break;
                case enGraphicMaskClassify.Mask:
                    OnFillMask(sceneRect, graphicMasks);
                    break;
                case enGraphicMaskClassify.ExceptMask:
                    OnFillExceptMask(sceneRect, graphicMasks);
                    break;
            }
        }
        base.OnPopulateMesh(_vh);
    }
    #endregion

    #region OnFillScene 全屏填充
    /// <summary>
    /// 全屏填充
    /// </summary>
    /// <param name="_sceneRect">屏幕矩形</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillScene(Rect _sceneRect, List<AbsUIGuideGraphic> _masks)
    {
        OnFillExceptMask(_sceneRect, _masks);
    }
    #endregion

    #region OnFillMask 仅填充遮罩
    //x=>u最小值，z=>u最大值 ，y=>v最小值，y=>v最大值
    //v
    //|     xw---------zw
    //|       |               |
    //|     xy----------zy
    //------------------------u
    static readonly Vector4 uvDefault = new Vector4(0, 0, 1, 1);
    /// <summary>
    /// 仅填充遮罩
    /// </summary>
    /// <param name="_sceneRect">屏幕矩形</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillMask(Rect _sceneRect, List<AbsUIGuideGraphic> _masks)
    {
        OnFillExceptMask(_sceneRect, _masks);
    }
    #endregion

    #region OnFillExceptMask 除遮罩之外都填充
    /// <summary>
    /// 除遮罩之外都填充
    /// </summary>
    /// <param name="_sceneRect">屏幕矩形</param>
    /// <param name="_masks">绘制组</param>
    protected virtual void OnFillExceptMask(Rect _sceneRect, List<AbsUIGuideGraphic> _masks)
    {
        Sprite sprite = null;
        Image image = null;
        Vector4 spriteUVRatio = Vector4.zero;
        Vector4 spriteUV = Vector4.zero;
        Vector4 spriteUVClip = Vector4.zero;
        Vector4 spriteBorder = Vector4.zero;
        Vector4 rectUV = Vector4.zero;
        Vector4 sceneGraphicWh = Vector4.zero;
        Vector4 graphicRectSlicedBorder = Vector4.zero;
        Vector4 graphicUvSlicedBorderRatio = Vector4.zero;
        Vector2 rectMin = Vector2.zero;
        Vector2 rectMax = Vector2.zero;
        bool isGraphicSliced = false;
        sceneGraphicWh.x = _sceneRect.size.x;
        sceneGraphicWh.y = _sceneRect.size.y;
        Rect maskRect = new Rect();

        for (int i = 0; i < _masks.Count; i++)
        {
            spriteUV = uvDefault;
            spriteUVClip = uvDefault;
            spriteBorder = Vector4.zero;
            isGraphicSliced = false;
            maskRect = _masks[i].graphic.GraphicLocalRectForVertexHelper();
            sceneGraphicWh.z = maskRect.size.x;
            sceneGraphicWh.w = maskRect.size.y;
            rectMin = Rect.PointToNormalized(_sceneRect, maskRect.min);
            rectMax = Rect.PointToNormalized(_sceneRect, maskRect.max);
            rectUV.Set(rectMin.x, rectMin.y, rectMax.x, rectMax.y);

            if (!Geometry2DUtility.IsPointInRect(maskRect.min, _sceneRect))
            {
                if (rectMin.x == 0)
                {
                    spriteUVClip.x = Mathf.InverseLerp(maskRect.min.x, maskRect.max.x, _sceneRect.min.x);
                }
                if (rectMin.y == 0)
                {
                    spriteUVClip.y = Mathf.InverseLerp(maskRect.min.y, maskRect.max.y, _sceneRect.min.y);
                }
            }

            if (_masks[i].graphic is Image)
            {
                image = (Image)_masks[i].graphic;
                sprite = image.overrideSprite;
                if (sprite != null)
                {
                    spriteUV = UnityEngine.Sprites.DataUtility.GetOuterUV(sprite);
                    Texture2D texSrc = sprite.texture;
                    spriteUVRatio.x = sprite.rect.x / texSrc.width;
                    spriteUVRatio.y = sprite.rect.y / texSrc.height;
                    spriteUVRatio.z = sprite.rect.width / texSrc.width;
                    spriteUVRatio.w = sprite.rect.height / texSrc.height;

                    graphicRectSlicedBorder.x = sprite.border.x / _masks[i].graphic.GetPixelAdjustedRect().width * 0.5f;
                    graphicRectSlicedBorder.y = sprite.border.y / _masks[i].graphic.GetPixelAdjustedRect().height * 0.5f;
                    graphicRectSlicedBorder.z = sprite.border.z / _masks[i].graphic.GetPixelAdjustedRect().width * 0.5f;
                    graphicRectSlicedBorder.w = sprite.border.w / _masks[i].graphic.GetPixelAdjustedRect().height * 0.5f;
                    graphicRectSlicedBorder.z = 1 - graphicRectSlicedBorder.z;
                    graphicRectSlicedBorder.w = 1 - graphicRectSlicedBorder.w;

                    graphicUvSlicedBorderRatio.x = sprite.border.x / sprite.textureRect.width;
                    graphicUvSlicedBorderRatio.y = sprite.border.y / sprite.textureRect.height;
                    graphicUvSlicedBorderRatio.z = sprite.border.z / sprite.textureRect.width;
                    graphicUvSlicedBorderRatio.w = sprite.border.w / sprite.textureRect.height;
                }
                switch (image.type)
                {
                    case Image.Type.Sliced:
                    case Image.Type.Tiled:
                        isGraphicSliced = true;
                        break;
                }
            }
            material.SetTexture("_GraphicTex" + i, _masks[i].graphic.mainTexture);
            material.SetVector("_GraphicUvSlicedBorderRatio" + i, graphicUvSlicedBorderRatio);
            material.SetVector("_SceneGraphicWh" + i, sceneGraphicWh);
            material.SetVector("_GraphicUvRatio" + i, spriteUVRatio);
            material.SetVector("_GraphicUvMinMax" + i, spriteUV);
            material.SetVector("_GraphicUvMinMaxClip" + i, spriteUVClip);
            material.SetVector("_GraphicUvMaskForScene" + i, rectUV);
            material.SetInt("_isGraphicSliced" + i, isGraphicSliced ? 1 : 0);
            material.SetVector("_GraphicRectSlicedBorder" + i, graphicRectSlicedBorder);
        }
    }
    #endregion

    #region OnClearRemoveMask 清除已移除的遮罩
    /// <summary>
    /// 清除已移除的遮罩
    /// </summary>
    void OnClearRemoveMask()
    {
        if (mTextureClear == null)
        {
            mTextureClear = new Texture2D(1, 1, TextureFormat.ARGB32, false, false);
            mTextureClear.SetPixel(0, 0, Color.clear);
            mTextureClear.Apply();
        }
        //将已绘制的都清除
        for (int i = 0; i < mMaxTextureNum; i++)
        {
            material.SetTexture("_GraphicTex" + i, mTextureClear);
            material.SetVector("_GraphicUvSlicedBorderRatio" + i, Vector4.zero);
            material.SetVector("_SceneGraphicWh" + i, Vector4.zero);
            material.SetVector("_GraphicUvMinMax" + i, Vector4.zero);
            material.SetVector("_GraphicUvMinMaxClip" + i, Vector4.zero);
            material.SetVector("_GraphicUvMaskForScene" + i, Vector4.zero);
            material.SetInt("_isGraphicSliced" + i, 0);
            material.SetVector("_GraphicRectSlicedBorder" + i, Vector4.zero);
        }
        material.SetInt("_graphicMaskClassify", (int)graphicClassify);
        material.SetInt("_graphicSpriteFillClassify", (int)graphicSpriteFillClassify);
    }
    #endregion
}