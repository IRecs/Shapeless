using Data;
using Services.Input;
using UnityEngine;

namespace PlayerFolder
{
    [RequireComponent(typeof(CharacterController))]
    public class MoverPlayer : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private Animator _animator;
        private CharacterController _characterController;

        private IInputService _inputService;
        private Camera _camera;
        [SerializeField]private AudioSource _audioSource;

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
                _animator.SetFloat("Speed", 1);
                if(!_audioSource.isPlaying)
                    _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
                _animator.SetFloat("Speed", 0);
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }

        public void Warp(Vector3 to)
        {
            _characterController.enabled = false;
            transform.localPosition =  to;
            _characterController.enabled = true;
        }
    }
}
