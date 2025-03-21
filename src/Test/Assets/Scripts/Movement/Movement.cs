using System;
using Events;
using Providers;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float sens = 2f;
    
    private InputActions _inputActions;
    private Camera _camera;
    
    private float xRotation = 0f;

    private static ILoadConfigs _loadConfigs;
    private static IEventService _eventService;

    private float _speed;

    private void Awake()
    {
        _inputActions = new InputActions();
        _camera = Camera.main;

        _loadConfigs = new LoadConfigs();
        _speed = _loadConfigs.GetPlayerConfig().Speed;

        _eventService = EventService.Instance;
        _eventService.OnUIButton += OnUpdate;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMovement()
    {
        var movement = _inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = transform.right * movement.x + transform.forward * movement.y;
        transform.position += move * _speed * Time.deltaTime;
    }

    private void OnRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens;
        float mouseY = Input.GetAxis("Mouse Y") * sens;
        
        transform.Rotate(Vector3.up * mouseX);
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void FixedUpdate()
    {
        OnMovement();
        OnRotate();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void OnUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _speed = _loadConfigs.GetPlayerConfig().Speed;
    }
}
