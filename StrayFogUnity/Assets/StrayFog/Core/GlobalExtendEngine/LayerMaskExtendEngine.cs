using UnityEngine;
/// <summary>
/// LayerMask扩展
/// </summary>
public static class LayerMaskExtendEngine
{
    /// <summary>
    /// LayerMask是否包含指定Layer
    /// </summary>
    /// <param name="_self">LayerMask</param>
    /// <param name="_layer">layer</param>
    /// <returns>true:包含,false:不包含</returns>
    public static bool IsContains(this LayerMask _self,int _layer)
    {
        int value = 1 << _layer;
        return (_self.value & value) == value;
    }
}
