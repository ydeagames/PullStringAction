using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftPlatform : MonoBehaviour
{
    Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassThrough()
    {
        _collider.isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _collider.isTrigger = false;
    }
}
