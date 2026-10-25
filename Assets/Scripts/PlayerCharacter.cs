using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;

    private void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
