using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	Vector3 movement,lookPoint;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	public CNAbstractController MovementJoystick;
    void Awake()
	{

		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();

	}
	void FixedUpdate()
	{
	//	float h = Input.GetAxisRaw("Horizontal");
	//	float v = Input.GetAxisRaw("Vertical");

		var movement = new Vector3(MovementJoystick.GetAxis("Horizontal"),0f,MovementJoystick.GetAxis("Vertical"));
		float h = movement.x;
		float v = movement.z;
		
		Move(h,v);
		if(h != 0 && v != 0)
		 Turning(h,v);
		Animating(h, v);
	}

	void Move(float h , float v)
	{
		movement.Set(h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;   //normalize means "set vector3 as unit vector"

		playerRigidbody.MovePosition (transform.position + movement);

	}
	void Turning(float h , float v)
	{

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if(Physics.Raycast (camRay,out floorHit,camRayLength,floorMask))
	    {
			Vector3 playerToMouse = floorHit.point - transform.position;


			lookPoint.Set(h,0,v);
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(lookPoint);
			//Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

			playerRigidbody.MoveRotation(newRotation);



		}

	}
	void Animating (float h,float v)
	{
		bool walking = h !=0f || v !=0f;
		anim.SetBool("IsWalking",walking);
	}
}
