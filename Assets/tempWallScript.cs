using UnityEngine;

public class tempWallScript : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 40 * Mathf.Sin(Time.time) * Time.fixedDeltaTime, gameObject.transform.position.z);
    }
}
