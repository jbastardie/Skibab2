using UnityEngine;
using System.Collections;

public class customMoveController : MonoBehaviour
{

    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _moveForce;

    [SerializeField]
    private float _geometricDrag;

    [SerializeField]
    private float _linearDrag;

    [SerializeField]
    private float _maxVelocity;

    public float rotateSpeed = 3.0F;

    void Start()
    {
        if (_rigidbody == null)
            _rigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        var direction = (Vector3.forward * Input.GetAxis("Vertical")).normalized;
        direction = direction.normalized;
        transform.Rotate(0, Input.GetAxis("Horizontal") *rotateSpeed, 0);
        var speeddelta = _transform.rotation
            * (direction
                * _moveForce);
        var speed = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

        _rigidbody.AddForce((speed - speed.normalized * _linearDrag) * _geometricDrag - speed, ForceMode.VelocityChange);

        speed -= speed.normalized * _linearDrag;
        speed *= _geometricDrag;

        if (speed.magnitude > _maxVelocity)
        {
            _rigidbody.AddForce(Vector3.ClampMagnitude((speed + speeddelta * Time.deltaTime), speed.magnitude) - speed, ForceMode.VelocityChange);
        }
        else
        {
            _rigidbody.AddForce(Vector3.ClampMagnitude((speed + speeddelta * Time.deltaTime), _maxVelocity) - speed, ForceMode.VelocityChange);
        }
    }
}