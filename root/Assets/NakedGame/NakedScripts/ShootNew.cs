using UnityEngine;
using System.Collections;

public class ShootNew : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 25f;
    private int ammo = 10;
    public float maxAmmo = 10f;
    public GUIText ammoText;
	public Timer _timer;


 
    // Update is called once per frame
    void Update()
    {
        
		if (Input.GetButtonUp("Fire1") && ammo > 0) // fires cannon, checks if cannon has fired
        {

          	GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			clone.transform.SetParent(gameObject.transform);


			clone.GetComponent<Rigidbody>().AddForce(transform.forward * speed); //shoots bullets of gun's facing position
			clone.transform.SetParent(null);

           //clone.transform = transform.TransformDirection(0, 0, speed);
            ammo --;


            Destroy(clone.gameObject, 5);
			ParticleSystem particle = GetComponent<ParticleSystem>();
			particle.Play();
            
            particle.enableEmission = true;
			ammoText.text = "Ammo: " + ammo + "/" + maxAmmo; // prints ammo counter to screen
		
		}

		if (ammo == 0 || _timer.timerDone == true ) // if ammo is 0 or timer is done, load GameOver scene
		{
			Application.LoadLevel("NakedEnd"); // loads the GameOver Scene 
		}
		
	}
	
}