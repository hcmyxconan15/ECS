using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace TMG.SpaceShooter
{
    [UpdateAfter(typeof(GetPlayerInputSystem))]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial class MovePlayerShipSystem : SystemBase
    {
        protected override void OnUpdate()
        {
             new MovePlayerShipJob()
            {
                DealtaTime = Time.DeltaTime

            }.ScheduleParallel();
        }
        [BurstCompile]
        public partial struct MovePlayerShipJob : IJobEntity
        {
            public float DealtaTime;
            private void Execute(ref Translation translation, in PlayerMoveInput playerMoveInput, in MoveSpeed moveSpeed)
            {
                float3 currentMovement = playerMoveInput.Value * moveSpeed.Value * DealtaTime;
                translation.Value += currentMovement;
            }
        }
    }
}