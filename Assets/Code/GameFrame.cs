using UnityEngine;

public class GameFrame : MonoBehaviour
{
    public float Speed = 1f;
    public Transform Target;

    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0f, 0f);
        if (Target != null)
            transform.position = new Vector3(Target.position.x, 0f, 0f);
    }
}
