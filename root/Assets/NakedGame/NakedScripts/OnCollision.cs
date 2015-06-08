using UnityEngine;
using System.Collections;


public class OnCollision : MonoBehaviour {
	
	public int health = 4; //health of AI

	public GameObject shirt;
	public GameObject pants;
	public GameObject shoes;
	AudioSource audioSound;
	AudioSource audioSound2;

	void Start () 
	{
		audioSound = GetComponent<AudioSource> ();
		/*shirt.SetActive (false); // sets shirt, pants, and shoes to be turned off
		pants.SetActive (false);
		shoes.SetActive (false); */
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnCollisionEnter(Collision other)
	{


		print ("shot"); //checks if AI was shot
		if (other.gameObject.tag != "bullet")return;
			Destroy (other.gameObject);
			//Destroy ();
		print ("other tag is " + other.gameObject.tag);
		audioSound.Play ();

		health --;
		if (health <= 0) {
			Destroy (gameObject);
			Application.LoadLevel("NakedVictory"); //when AI's health reaches 0, load "NakedVictory" scene.
	}

		/*if (health == 3)
		{
			shirt.SetActive(true); //AI's health decreases to 3, set shirt to active
			//activate the shirt
		}
		if(health == 2)
		{
			pants.SetActive(true);//AI's health decreases to 2, set pants to active
			//activate the pants
		}
		if(health == 1)
		{
			shoes.SetActive(true);//AI's health decreases to 1, set shoes to active
			//activate the shoes
		}
*/

  }

}