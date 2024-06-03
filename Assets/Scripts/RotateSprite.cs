
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    [SerializeField] float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotSpeed));
    }
}
