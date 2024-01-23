using UnityEngine;
using Photon.Pun;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>(); 
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ChangeFaceDirection();
    }
    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;
    }
    private void ChangeFaceDirection()
    {
        if (view.IsMine)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, -180f, transform.rotation.y);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.y);
            }
        }  
    }
}