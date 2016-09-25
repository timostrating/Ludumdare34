using UnityEngine;

public class Player2DInput : MonoBehaviour {

    private Player2D player;



	private void Awake () {
        player = gameObject.GetComponent<Player2D>();
	}

    private void FixedUpdate () {
        if(Input.GetButton("Jump"))
            player.Jump();

        if (Input.GetButtonDown("Shoot"))
            player.Shoot();
    }
}
