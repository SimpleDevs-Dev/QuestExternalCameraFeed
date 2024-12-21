using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authorizer : MonoBehaviour
{
    GameObject suspendedObject;

    private void Start() {
        suspendedObject = new GameObject();
        suspendedObject.SetActive(true);
    }
}
