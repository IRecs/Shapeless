using Data;
using Services.Input;
using UnityEngine;

namespace PlayerFolder
{
    [RequireComponent(typeof(CharacterController))]
    public class MoverPlayer : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private CharacterController _characterController;

        private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _inputService = new StandaloneInputService();
        }

        private void Start() =>
            _camera = Camera.main;

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        private void Warp(Vector3Data to)
        {
            _characterController.enabled = false;
            transform.position = to.AsUnityVector().AddY(_characterController.height);
            _characterController.enabled = true;
        }
    }
}
