using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCam : MonoBehaviour
{

    public Transform camTarget;
    public float pLerp = .01f;
    public float rLerp = .02f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);

    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ThirdCam : MonoBehaviour
//{
//    [SerializeField]
//    private Transform camTarget;
//    private float pLerp = .01f;
//    private Vector3 camPos;

//    private void Start()
//    {
//        camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2f);
//    }

//    void Update()
//    {
//        transform.position = Vector3.Lerp(camPos, camTarget.position, pLerp);
//    }
//}
