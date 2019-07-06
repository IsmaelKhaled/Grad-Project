using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour // For the collision detection to work, there needs to be colliders on all walls
{
    public Transform target;
    public GameObject player;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 2f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(1))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f; //getaxis gives float negative values for right rotations and positive for left
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f; 
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
           // Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            float di = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax); // use scroll wheel to change distance from target
            distance = Mathf.Lerp(distance, di, (di - distance / 10));
            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit)) // check for obstructions in the view and move the camera closer to target if obstructions found
            {
                //casts a line from target to camera, if any target is hit then the camera moves closer to target exactly 1 unit behind the obstacle
                Debug.Log("Current distance = " + distance + ", Hit Distance = " + hit.distance);
                distance = Mathf.Lerp(distance,hit.distance - 1f, 3f * Time.deltaTime); //1 is the distance I want the camera to be from the object after moving,..
                //.. 3 is the speed the camera closes in into the target when it detects an object in the way, both can be edited
            }

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;

            //brake the camera after moving so it doesn't keep on moving, basically damping
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}

