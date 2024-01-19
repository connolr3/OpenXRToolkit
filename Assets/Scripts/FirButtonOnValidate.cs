using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FirButtonOnValidate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public Transform SpawnPoint;
    public float fireSpeed=20;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //add an event when we validate. trigger fire bullet
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
      //  arg.interactor : you can get some useful infromation from here, we dont need it tho
      GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position=SpawnPoint.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * fireSpeed;//instead of changing the transform of this object, we are actaully manually afecting the physics, by changign the forward velocty of the object
        Destroy(spawnBullet, 5);//destroy after 5 seconds so we don't have a bullet overload
    }
}
