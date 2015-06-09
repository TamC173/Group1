using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawningEnemies : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SpawnEnemies();
    }

    public float xOff = 1;
    public float yOff = 1;
    [ContextMenu("Populate")]
    void SpawnEnemies()
    {
        //Vector3 xOffset = new Vector3(8, -4, 0);
        //Vector3 yOffset = new Vector3(-5, 5.5f, -3);

        float originX = transform.position.x;
        float originY = transform.position.y;
        float originZ = transform.position.z;
        int cRow = 0;
        int cCol = 0;
        float newX, newY;
        for (int i = 0; i < numberOfEnemies; i++)
        {

            cCol = i % numberOfColumns;
            //set his position...
            //first dude is special...
            if (cCol == 0) //hit the end go down
            {            
                if(i > 0)
                    cRow++; 
            } 
            newX = xOff * cCol ;
            newY = yOff * cRow ;
            Vector3 newPos = new Vector3(newX, newY, originZ);


            //make a dude...
            GameObject dude = Instantiate(enemyPrefab) as GameObject;
            dude.name = "UFO_" + "[" + " " + newX.ToString() + " " + newY.ToString() + "]";
            dude.transform.SetParent(transform);
            dude.transform.localPosition = newPos;
            _enemies.Add(dude);
        }


    }

    [ContextMenu("UnPopulate")]
    void DeSpawn()
    {
        foreach (GameObject go in _enemies)
        {
            DestroyImmediate(go);
        }

        _enemies.Clear();
        _enemies = new List<GameObject>();

    }

    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public int numberOfColumns;
    private bool gameOver;
    public List<GameObject> _enemies;

    //public Rigidbody EnemyBulletPrefab;
}
