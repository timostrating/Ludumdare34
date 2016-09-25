using UnityEngine;

public class Player2D : MonoBehaviour {

    [SerializeField] private float jumpForce = 200f;
    [SerializeField] private float waterForce = 100f;
    public float groundedRadius = .1f;

    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private Transform bulletSpawnpoint;
    [SerializeField] private GameObject bulletPrefab;


    private Transform groundCheck;
    private bool canJump;

    private Animator anim;
    private Rigidbody2D playerRigidbody2D;
    private Transform myTransform;



    private void Awake () {
        myTransform = transform;
        groundCheck = transform.Find("GroundCheck");
        playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate () {

        if (myTransform.position.y < 0) {
            playerRigidbody2D.AddForce(new Vector2(0f, waterForce));
            canJump = true;
        }

        else {
            canJump = false;
        }




        //anim.SetBool("Ground", grounded);
        //anim.SetFloat("vSpeed", playerRigidbody2D.velocity.y);
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, groundedRadius);
    }

    public void Jump() {
        Debug.Log("jump");
        if (canJump) {
            playerRigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void Shoot () {
        Debug.Log("Shoot");
        Instantiate(bulletPrefab, bulletSpawnpoint.position, Quaternion.identity);
    }
}
