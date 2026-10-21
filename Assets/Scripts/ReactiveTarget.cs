using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private static readonly WaitForSeconds _waitForSeconds1_5 = new(1.5f);

    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(0, 0, -75);
        yield return _waitForSeconds1_5;
        Destroy(this.gameObject);
    }
}
