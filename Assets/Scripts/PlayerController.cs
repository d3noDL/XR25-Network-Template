using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    private Vector3 _movementInput;
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private Color _playerColor = Color.white;

    private void Awake()
    {
        _rigidbody = transform.GetComponentInChildren<Rigidbody>();
        _renderer = transform.GetComponentInChildren<Renderer>();
    }

    private void Start()
    {
        _playerColor = Random.ColorHSV(0.5f, 1f, 0.5f, 1f, 0.5f, 1f, 1f, 1f);
        _renderer.material.color = _playerColor;
    }

    private void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        _movementInput = new Vector3(hInput, 0, vInput);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_movementInput * _movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

}
