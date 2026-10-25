using UnityEngine;
using UnityEngine.Timeline;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCharacter>(component: out _))
            Debug.Log("Player hit!");

        Destroy(this.gameObject);
    }
}
