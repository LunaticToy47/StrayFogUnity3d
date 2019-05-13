using Unity.Entities;
/// <summary>
/// ECSComponent【IComponentData】
/// </summary>
public struct ECSComponent : IComponentData {
}

/*
[System.Serializable]
public struct RenderMesh : ISharedComponentData
{
    public Mesh mesh;
    public Material material;

    public ShadowCastingMode castShadows;
    public bool receiveShadows;
}
*/

/*
 var transform = group.transform[index]; // Read

transform.heading = playerInput.move; // Modify
transform.position += deltaTime * playerInput.move * settings.playerMoveSpeed;

group.transform[index] = transform; // Write
*/
