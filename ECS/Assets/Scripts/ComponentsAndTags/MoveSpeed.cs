using Unity.Entities;
namespace TMG.SpaceShooter
{
    [GenerateAuthoringComponent]
    public struct MoveSpeed: IComponentData
    {
        public float Value;
    }
}