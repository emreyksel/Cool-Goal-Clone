using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCreator : MonoBehaviour
{
    public Animator animPlayer;
    public Camera cam;
    public List<GameObject> route = new List<GameObject>();
    public Transform center;
    public GameObject routeSphere;    
    private Vector2 startSwipe;
    private Vector2 endSwipe;
    private Vector2 swipe;
    private int routeSphereCount = 17;
    private bool isFire = false;

    private void Awake()
    {
        for (int i = 0; i < routeSphereCount; i++)
        {
            GameObject clone = Instantiate(routeSphere,center);
            clone.SetActive(false);
            route.Add(clone);
            route[i].transform.position = new Vector3(0, 1, -4.5f + i * 1.5f);
        }
    }

    private void Update()
    {
        if (isFire)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startSwipe = cam.ScreenToViewportPoint(Input.mousePosition);

            for (int i = 1; i < route.Count; i++)
            {
                route[i].SetActive(true);
            }
        }

        if (Input.GetMouseButton(0))
        {
            endSwipe = cam.ScreenToViewportPoint(Input.mousePosition);
            swipe = endSwipe - startSwipe;
            swipe.y = 0;
            swipe.x = Mathf.Clamp(swipe.x, -0.55f, 0.55f);
            CreateRoute();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            for (int i = 1; i < route.Count; i++)
            {
                route[i].SetActive(false);
            }

            animPlayer.SetTrigger("Shoot");
            isFire = true;
        }
    }

    private void CreateRoute()
    {
        route[8].transform.position = (Vector3)swipe * 12 + new Vector3(0, 1, route[8].transform.position.z); // ortanca eleman
        route[16].transform.position = new Vector3(route[8].transform.position.x / 2, 1, route[16].transform.position.z);
        int index1 = 1;
        int index2 = 15;

        for (int i = 7; i > 0; i--) // toptan ortanca elemana kadarki yay
        {
            float positionX = route[8].transform.position.x;
            float extra = positionX - (i * i * positionX / 64);
            route[index1].transform.position = new Vector3(extra, 1, route[index1].transform.position.z);
            index1++;
        }

        for (int i = 7; i > 0; i--) // kaleden ortanca elemana kadarki yay
        {
            float positionX = route[8].transform.position.x * 0.5f;
            float extra = positionX - (i * i * positionX / 64);
            route[index2].transform.position = new Vector3(extra + positionX, 1, route[index2].transform.position.z);
            index2--;
        }
    }
}
