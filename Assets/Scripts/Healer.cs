using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    public AudioClip waterSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hp = collision.gameObject.GetComponent<PlayerHP>();
        if (hp != null)
        {
            hp.Heal();

            // ??????
            AudioSource.PlayClipAtPoint(waterSound, transform.position);
        }
    }
}
