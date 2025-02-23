using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform TreadsTransform;
    [Header("Settings")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float turningRate = 30f;

    private Vector2 previousMovementInput;

    public override void OnNetworkSpawn()
    {
        if(!IsOwner) return;
        inputReader.MoveEvent += HandleMovement;
    }
    public override void OnNetworkDespawn()
    {
        if (!IsOwner) return;
        inputReader.MoveEvent -= HandleMovement;
    }
    void Update()
    {
        if (!IsOwner) return;
        float zRotation = previousMovementInput.x*-turningRate*Time.deltaTime;
        TreadsTransform.Rotate(0f, 0f,zRotation);
    }
    private void FixedUpdate()
    {
        if (!IsOwner) return;
        rb.linearVelocity=TreadsTransform.up*previousMovementInput.y*speed;
    }
    private void HandleMovement(Vector2 moveInput)
    {
        previousMovementInput = moveInput;
    }

}
