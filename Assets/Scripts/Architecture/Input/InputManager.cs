using UnityEngine;

namespace Architecture
{
    public class InputManager : SingletonMono<InputManager>
    {
        private GameControls _controls;

        public GameControls AppControls => _controls;

        protected override void Awake()
        {
            base.Awake();
            _controls = new GameControls();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        /*public Vector2 MoveInput => _controls.Player.Move.ReadValue<Vector2>();

        public Vector2 LookInput => _controls.Player.Look.ReadValue<Vector2>();

        public bool JumpTriggered => _controls.Player.Jump.WasPressedThisFrame();

        public bool AttackTriggered => _controls.Player.Attack.WasPressedThisFrame();

        public bool IsAttacking => _controls.Player.Attack.IsPressed();

        public bool IsSprinting => _controls.Player.Sprint.IsPressed();

        public bool InteractTriggered => _controls.Player.Interact.WasPressedThisFrame();

        public bool IsCrouching => _controls.Player.Crouch.IsPressed();

        public bool UICancelTriggered => _controls.UI.Cancel.WasPressedThisFrame();*/
    }
}