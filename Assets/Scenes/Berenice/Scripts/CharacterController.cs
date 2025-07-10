using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float moveSpeed, playerHeight = 2;
    private float horizontalInput, verticalInput;
    public float gravityMultiplier;

    [SerializeField] private bool isGrounded;
    public bool canMove = true;

    [SerializeField] private LayerMask _whatIsGround;

    private Vector3 moveDirection, velocity = Vector3.zero;

    [SerializeField] private Rigidbody player;

    [SerializeField] private Transform orientation;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        player.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ControllerInputs();
        LimitVelocity();
        GroundCheck();
    }
    void ControllerInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + .2f, whatIsGround);
    }
    void Move()
    {
        if (canMove)
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            if (isGrounded)
            {
                player.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
            }
            else if (!isGrounded) player.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier, ForceMode.Force);
        }
    }
    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(player.linearVelocity.x, 0f, rb.velocity.z);
        if (vel.magnitude > moveSpeed)
        {
            Vector3 limitVel = vel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }


}

