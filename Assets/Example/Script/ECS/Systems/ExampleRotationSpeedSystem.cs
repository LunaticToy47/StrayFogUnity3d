using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
/// <summary>
/// ExampleRotationSpeedSystem
/// </summary>
public class ExampleRotationSpeedSystem : JobComponentSystem
{
    //[BurstCompile]
    //struct RotationSpeedRotation : IJobForEach<Rotation, RotationSpeed>
    //{
    //    public float dt;

    //    public void Execute(ref Rotation rotation, [ReadOnly]ref RotationSpeed speed)
    //    {
    //        rotation.value = math.mul(math.normalize(rotation.value), quaternion.axisAngle(math.up(), speed.speed * dt));
    //    }
    //}

    //// Any previously scheduled jobs reading/writing from Rotation or writing to RotationSpeed 
    //// will automatically be included in the inputDeps dependency.
    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    var job = new RotationSpeedRotation() { dt = Time.deltaTime };
    //    return job.Schedule(this, inputDeps);
    //}
}