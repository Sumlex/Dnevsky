using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoveableGround : MonoBehaviour
{
    public GameObject platform;

    public float movespeed;
    public Transform currentPoint;

    public Transform[] points;

    public int pointSelection;

    public void Start()
    {
        currentPoint = points[pointSelection];
    }

    public void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * movespeed);

        if (platform.transform.position == currentPoint.position)
        {
            pointSelection++;

               if (pointSelection == points.Length)
                    {
                        pointSelection = 0;
                    }

                currentPoint = points[pointSelection];
        }
    }
}