using UnityEngine;

public class WallRenderer : MonoBehaviour
{
    public GameObject Parent1;
    public GameObject Parent2;

    private void Start()
    {
        float distance = GetDistance(Parent1.transform.position, Parent2.transform.position);
        float angle = (Parent1.transform.position.x - Parent2.transform.position.x) / distance;
        transform.rotation = new Quaternion(0, 360 - Mathf.Asin(angle), 0, 0);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * (distance - 0.5f));

        if(transform.localScale.x < 1)
            GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void Update()
    {
        transform.position = FindPosition(Parent1.transform.position, Parent2.transform.position);
    }

    private Vector3 FindPosition(Vector3 positioin1, Vector3 positioin2)
    {
        float x = (positioin1.x + positioin2.x) / 2;
        float y = (positioin1.y + positioin2.y) / 2;
        float z = (positioin1.z + positioin2.z) / 2;

        return new Vector3(x, y, z);
    }

    private float GetDistance(Vector3 target1, Vector3 target2)
    {
        return Mathf.Sqrt(
            Mathf.Pow(target1.x - target2.x, 2) +
            Mathf.Pow(target1.y - target2.y, 2) +
            Mathf.Pow(target1.z - target2.z, 2));
    }
}
