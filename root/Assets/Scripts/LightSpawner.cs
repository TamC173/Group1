using UnityEngine;
using System.Collections;

public class LightSpawner : MonoBehaviour 
{

    public GameObject light;
    [SerializeField]
    private bool usingPrefab = false;

	// Use this for initialization
	void Start () 
    {
        Spawn();
	}
    

    private int xBounds = 200;
    private int zBounds = 200;
    private int yBounds = 100;  

	void Spawn() 
    {       
        int x = Random.Range(0, xBounds);
        int y = Random.Range(yBounds, 200);
        int z = Random.Range(0, zBounds);
       
        Vector3 randomPosition = new Vector3(x, y, z);

        if (usingPrefab)
        {

            GameObject lightsSpawned = new GameObject();
            lightsSpawned.name = "Light";
            GameObject thing = Instantiate(light, randomPosition, Quaternion.identity) as GameObject;
            thing.transform.parent = lightsSpawned.transform;
        }
        else
            light.transform.position = randomPosition;     
       
    }   
}
