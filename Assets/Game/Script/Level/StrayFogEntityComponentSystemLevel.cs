using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;
/// <summary>
/// EntityComponentSystem关卡
/// </summary>
[AddComponentMenu("Game/ExampleLevel/StrayFogEntityComponentSystemLevel")]
public class StrayFogEntityComponentSystemLevel : AbsLevel
{
    /// <summary>
    /// 玩家实体
    /// </summary>
    [AliasTooltip("玩家实体")]
    public GameObject playerEntity;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        StrayFogGamePools.gameManager.Initialization(() =>
        {
            StrayFogGamePools.uiWindowManager.AfterToggleScene(() =>
            {                
                CreatingEntity();
            });            
        });
    }

    /// <summary>
    /// CreatingEntity
    /// </summary>
    void CreatingEntity()
    {
        EntityManager manager = World.Active.CreateManager<EntityManager>();
        EntityArchetype archetype = manager.CreateArchetype();

        //NativeArray<Entity> arrEntity = new NativeArray<Entity>(64, Allocator.Persistent);
        //manager.Instantiate(playerEntity, arrEntity);
        //arrEntity.Dispose();
        //EntityCommandBuffer       
        
        //JobComponentSystem

        //IComponentData
        //ISharedComponentData
        //ISystemStateComponentData
        //ISharedSystemStateComponentData

        Entity entity = manager.Instantiate(playerEntity);
        manager.AddComponent(entity, ComponentType.Create<ECSComponent>());
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    private void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }
}
