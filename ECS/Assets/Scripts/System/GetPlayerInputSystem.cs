using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;

namespace TMG.SpaceShooter
{
    public partial  class GetPlayerInputSystem: SystemBase
    {
        private PlayerInputKeys _playerInputKeys;
        protected override void OnStartRunning()
        {
            _playerInputKeys = GetSingleton<PlayerInputKeys>();
        }

        protected override void OnUpdate()
        {
            PlayerMoveInput newPlayerInput = GetPlayerMoveInput();
            SetSingleton(newPlayerInput);
        }

        private PlayerMoveInput GetPlayerMoveInput()
        {
            float horizontalMovement = 0f;
            if (Input.GetKey(_playerInputKeys.RightKey))
            {
                horizontalMovement = 1f;
            }
            else if (Input.GetKey(_playerInputKeys.LeftKey))
            {
                horizontalMovement = -1f;
            }

            float verticalMovement = 0f;

            if (Input.GetKey(_playerInputKeys.UpKey))
            {
                verticalMovement = 1f;
            }
            else if(Input.GetKey(_playerInputKeys.DownKey))
            {
                verticalMovement = -1f;
            }

            var playerMoveInput = new float3()
            {
                x = horizontalMovement,
                y = 0,
                z = verticalMovement

            };
            if (math.lengthsq(playerMoveInput) > 1f)
            {
                playerMoveInput = math.normalize(playerMoveInput);
            }

            return new PlayerMoveInput()
            {
                Value = playerMoveInput
            };
        }
    }
}