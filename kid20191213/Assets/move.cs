using UnityEngine;

public class move : MonoBehaviour {
[Header("移動速度"),Range(0,2000)]
public float speed = 1.5f;
[Header("血量"),Range(100,1000)]
public float hp = 100;

public GameObject bullet;
public AudioClip soundFire;
public Transform point;

private Animator ani;
private Rigidbody2D r2d;	
private AudioSource aud;

public float speeBullet = 1000;
private void Start(){
	ani = GetComponent<Animator>();
	r2d = GetComponent<Rigidbody2D>();
	aud = GetComponent<AudioSource>();
}

private  void FixedUpdate()
{
	Move();
}

private void Update(){
	Fire();
}





private void Move(){
    float h = Input.GetAxisRaw("Horizontal");
	r2d.AddForce(new Vector2(speed*h,0));
	if (h !=0) transform.localScale = new Vector3(h, 1 , 1);
	
}

private void Fire(){

	if (Input.GetKeyDown(KeyCode.Mouse0))
	{
	    aud.PlayOneShot(soundFire);
		GameObject temp = Instantiate(bullet, point.position, Quaternion.identity);
		temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(speeBullet * transform.localScale.x, 0));
			
	}
}













}
