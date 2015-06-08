using UnityEngine;
using System.Collections;

public class GnEClouds : MonoBehaviour
{
    //Prefabs
    public GameObject goodPrefab;
    public GameObject badPrefab;
    
    float timeToDie = 2.0f;

    float startTime = 0.0f;

    public int numberOfGood;
    public int numberOfBad;

    private Vector3 initialPos;
    public int min, max;
    public float life;
    public float speed = 7.0f;

    enum CLOUDTYPE
    {
        baddie,
        goodie,
    }

    void OnEnable()
    {
        timeToDie = life + Time.timeSinceLevelLoad;
        PlaceCloud(CLOUDTYPE.baddie);
        PlaceCloud(CLOUDTYPE.goodie);
    }

    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goodcloud" || collision.gameObject.tag == "evilcloud")
        {
            print("CLOUDS TOUCHING");
        }
    }
 
    //Instantiates the clouds 
    void PlaceCloud(CLOUDTYPE type)
    {  
        switch (type)
        {
            case CLOUDTYPE.baddie:
                GameObject badCloudParent = new GameObject("bcParent");
                for (int i = 0; i < numberOfBad; i++)
                {
                    badCloudParent.transform.parent = this.gameObject.transform;
                    GameObject badCloud = Instantiate(badPrefab, GeneratedPosition(), Quaternion.AngleAxis(180, Vector3.up)) as GameObject;
                    badCloud.transform.tag = "evilcloud";
                    BoxCollider e_bc = (BoxCollider)badCloud.gameObject.AddComponent(typeof(BoxCollider));
                    if (e_bc != null)
                    {
                        e_bc.center = new Vector3(0.35f, -0.007f, -0.2f);
                        e_bc.size = new Vector3(0.8f, 0.5f, 0.65f);
                    }
                    e_bc.isTrigger = true;
                    badCloud.transform.parent = badCloudParent.transform;
                }
                //do baddy stuff
                break;

            case CLOUDTYPE.goodie: 
                GameObject goodCloudParent = new GameObject("gcParent");
                for (int i = 0; i < numberOfGood; i++)
                {
                    goodCloudParent.transform.parent = this.gameObject.transform;
                    GameObject goodCloud = Instantiate(goodPrefab,GeneratedPosition(), Quaternion.AngleAxis(180, Vector3.up)) as GameObject;
                    goodCloud.transform.tag = "goodcloud";
                    BoxCollider g_bc = (BoxCollider)goodCloud.gameObject.AddComponent(typeof(BoxCollider));
                    if (g_bc != null)
                    {
                        g_bc.center = new Vector3(-0.2f, 0.055f, 0.2f);
                        g_bc.size = new Vector3(1.1f, 0.5f, 0.7f);
                    }
                    g_bc.isTrigger = true;
                    goodCloud.transform.parent = goodCloudParent.transform;
                }
                //do goody stuff
                break;
        }

    }

    //Randomize location
    Vector3 GeneratedPosition()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(-75, max);
        y = UnityEngine.Random.Range(0, -175);
        z = UnityEngine.Random.Range(min, max);
       return new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        //Moves the clouds in an upward position
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        this.transform.Translate(Vector3.right * Time.deltaTime);
        
        //Reset clouds position if they are past their lifetime
        if (startTime > timeToDie)
        {
            startTime = 0.0f;
            //Reset clouds in random positions at the original starting point
            Vector3 RandomPos = new Vector3(Random.Range(-7.0f, 7.0f), 0, Random.Range(-7.0f, 7.0f));
            transform.position = initialPos + RandomPos;
            
        }
    }
}