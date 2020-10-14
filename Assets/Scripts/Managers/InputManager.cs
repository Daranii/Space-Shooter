using Controls;
using Entities;
using Helper;
using UnityEngine;

namespace Managers
{
    public class InputManager : BehaviourSingleton<InputManager>
    {
        [SerializeField] private Player player;
        
        private Inputs _inputs;
        private float _horizontalDeadzone = ControlValues.DefaultHorizontalDeadzone;
        private float _verticalDeadzone = ControlValues.DefaultVerticalDeadzone;

        protected override void Init()
        {
            _inputs = new Inputs();
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }

        private void OnDisable()
        {
            _inputs.Disable();
        }

        // private void Start()
        // {
        //     PlayerInputSetup();
        //     UiInputSetup();
        // }

        private void Update()
        {
            var movement = _inputs.Primary.Movement.ReadValue<Vector2>();
            
            if (movement.x > _horizontalDeadzone || movement.x < -_horizontalDeadzone 
               || movement.y > _verticalDeadzone || movement.y < -_verticalDeadzone) 
                player.Move(movement);
            
            if (_inputs.Primary.Fire.ReadValue<float>() > 0.5)
                player.Fire();
        }

        private void PlayerInputSetup()
        {
            
        }

        private void UiInputSetup()
        {
            
        }
    }
}
