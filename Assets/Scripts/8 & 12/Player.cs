using UnityEngine;

public class Player : Unit, IMovable, IDamagable

{

    public float moveSpeed = 5f;

    public float rotationSpeed = 100f;

    public override void Move()

    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position += transform.forward * moveSpeed * Time.deltaTime * verticalInput;

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

    }

}

