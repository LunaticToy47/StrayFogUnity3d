using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Transforms;
/// <summary>
/// EntityComponentSystem关卡
/// </summary>
[AddComponentMenu("StrayFog/Game/Example/Level/ExampleEntityComponentSystemLevel")]
public class ExampleEntityComponentSystemLevel : AbsLevel
{
    /// <summary>
    /// 玩家实体
    /// </summary>
    [AliasTooltip("玩家实体")]
    public GameObject playerEntity;

    /// <summary>
    /// OnAwake
    /// </summary>
    protected override void OnAwake()
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
        //EntityManager manager = World.Active.CreateManager<EntityManager>();
        //EntityArchetype archetype = manager.CreateArchetype();

        //NativeArray<Entity> arrEntity = new NativeArray<Entity>(64, Allocator.Persistent);
        //manager.Instantiate(playerEntity, arrEntity);
        //arrEntity.Dispose();
        //EntityCommandBuffer       
        
        //JobComponentSystem

        //IComponentData
        //ISharedComponentData
        //ISystemStateComponentData
        //ISharedSystemStateComponentData

        //Entity entity = manager.Instantiate(playerEntity);
        //manager.AddComponent(entity, ComponentType.Create<ExampleECSComponent>());
    }

    /// <summary>
    /// OnGUI
    /// </summary>
    protected override void OnGUI()
    {
        StrayFogGamePools.sceneManager.DrawLevelSelectButtonOnGUI();
    }
}
