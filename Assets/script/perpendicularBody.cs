using UnityEngine;
using System.Collections;

public class perpendicularBody : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rigidbody;

    void Start () {

    }

    // Update is called once per frame
    void Update() {

        //transform.up.Set(-rigidbody.rotation.x, 0, -rigidbody.rotation.z);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        //transform.rotation(rigidbody.rotation.x, 0, rigidbody.rotation.z);
        //transform.eulerAngles.Set(0,transform.eulerAngles.y,0);
        
        //Debug.Log(transform.eulerAngles.z);
    }
}
