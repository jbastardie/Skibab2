using UnityEngine;
using System.Collections;

public class perpendicularBody : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rigidbody;
    public GameObject snowboarder;
    Animator animationObj;

    void Start () {
        animationObj = snowboarder.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        //transform.up.Set(-rigidbody.rotation.x, 0, -rigidbody.rotation.z);
        transform.rotation = Quaternion.Euler(0, rigidbody.transform.eulerAngles.y+40, 0);
        //transform.rotation(rigidbody.rotation.x, 0, rigidbody.rotation.z);
        //transform.eulerAngles.Set(0,transform.eulerAngles.y,0);

        //Debug.Log(transform.eulerAngles.z);

        if( 20 < Mathf.Abs(rigidbody.transform.eulerAngles.x)|| 10 < Mathf.Abs(rigidbody.transform.eulerAngles.z))
        {
            animationObj.enabled = false;
        }
        else
        {
            animationObj.enabled = true;
        }
    }
}
