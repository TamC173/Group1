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
        if (Input.GetButtonUp("Fire1") && ammo > 0)
        {

            GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			clone.transform.SetParent(gameObject.transform);


			clone.GetComponent<Rigidbody>().AddForce(0,20,speed);
			clone.transform.SetParent(null);

           //clone.transform = transform.TransformDirection(0, 0, speed);
            ammo --;


            Destroy(clone.gameObject, 5);
			ParticleSystem particle = GetComponent<ParticleSystem>();
			particle.Play();
            
            particle.enableEmission = true;
			ammoText.text = "Ammo: " + ammo + "/" + maxAmmo;
		
		}

		if (ammo == 0 || _timer.timerDone == true )
		{
			Application.LoadLevel("NakedEnd");
		}
		
	}
	
}