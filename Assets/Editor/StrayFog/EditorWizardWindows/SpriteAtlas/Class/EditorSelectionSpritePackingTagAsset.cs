#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// SpritePackingTag选择资源
/// </summary>
public class EditorSelectionSpritePackingTagAsset : EditorSelectionAsset
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pathOrGuid">路径或guid</param>
    public EditorSelectionSpritePackingTagAsset(string _pathOrGuid) : base(_pathOrGuid)
    {
        spritePackingTag = string.Empty;
        if (isFile)
        {
            AssetImporter imp = AssetImporter.GetAtPath(path);
            if (imp is TextureImporter)
            {
                mTextureImporter = (TextureImporter)imp;
                spritePackingTag = directory.Replace(@"/", "_").ToUpper();
            }
        }
    }

    /// <summary>
    /// 图集Tag
    /// </summary>
    public string spritePackingTag { get; private set; }
    /// <summary>
    /// 图片资源导入器
    /// </summary>
    TextureImporter mTextureImporter = null;
    /// <summary>
    /// 保存精灵图集标签
    /// </summary>
    public void SaveSpritePackingTag()
    {
        OnSaveSpritePackingTag(false);
    }
    /// <summary>
    /// 清除精灵图集标签
    /// </summary>
    public void ClearSpritePackingTag()
    {
        OnSaveSpritePackingTag(true);
    }
    /// <summary>
    /// 修改精灵图集标签
    /// </summary>
    /// <param name="_isClear">是否清除</param>
    void OnSaveSpritePackingTag(bool _isClear)
    {
        bool isSetTag = true;
        if (_isClear)
        {
            if (mTextureImporter != null)
            {
                isSetTag = !string.IsNullOrEmpty(mTextureImporter.spritePackingTag);
            }            
            spritePackingTag = string.Empty;
        }
        else
        {
            isSetTag = !string.IsNullOrEmpty(spritePackingTag);
        }

        if (mTextureImporter != null && isFile && isSetTag)
        {           
            mTextureImporter.spritePackingTag = spritePackingTag;
            //EditorUtility.SetDirty(mTextureImporter);
            mTextureImporter.SaveAndReimport();
        }
    }
}
#endif