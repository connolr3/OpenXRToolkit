using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;


//youtube video avatar rigging for VR: A step by step guide (1/2)
//https://www.youtube.com/watch?v=RaDSUd6GSjs

//helper class instead of avatar controller,
[System.Serializable]// show in editor
public class MapTransforms {
    //variables
    public Transform vrTarget;
    public Transform ikTarget;

    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void VRMapping() {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);//TransformPoint changes from local to global
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
        //Quaternion.Euler: Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis; applied in that order.
    }
}


//avatar controller
public class AvatarController : MonoBehaviour
{
    //set up transform for each element of vr: head and 2 hands
    [SerializeField] private MapTransforms head;
    [SerializeField] private MapTransforms leftHand;
    [SerializeField] private MapTransforms rightHand;
    //we will interpolate turning of head to make snmooth
    [SerializeField] private float turnSmoothness;
    [SerializeField] Transform ikHead;
    [SerializeField] Vector3 headBodyOffset;

    //we use lateupdate as update gave issues with jumpiness/jiggeriness
    private void LateUpdate()
    {
        transform.position = ikHead.position + headBodyOffset;
        //lerp is used to smooth the rotation
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(ikHead.forward, Vector3.up).normalized,Time.deltaTime*turnSmoothness);//normalised to give magnitude of 1
        //on y plane only.
        head.VRMapping();
        leftHand.VRMapping();
        rightHand.VRMapping();
    }
}
