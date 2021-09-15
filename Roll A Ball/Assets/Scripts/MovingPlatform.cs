using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    [SerializeField]
    Transform platform;

    [SerializeField]
    Transform startTransform;

    [SerializeField]
    Transform endTransform;

    void onDrawGizmos()
    {
        Gizmos.DrawWireCube(startTransform.position, platform.localScale);
    }


		
	}

