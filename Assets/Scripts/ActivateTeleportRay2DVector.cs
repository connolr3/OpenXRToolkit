using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class ActivateTeleportRay2DVector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<Vector2>()[1] > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<Vector2>()[1] > 0.1f);
    }
}

