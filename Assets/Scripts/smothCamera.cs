using UnityEngine;

public class smothCamera : MonoBehaviour {
    public Transform target;
    public float smothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 diseredPosition = target.position + offset;
        Vector3 smothedPosition = Vector3.Lerp(transform.position, diseredPosition, smothSpeed);
        transform.position = smothedPosition;
    }

}
