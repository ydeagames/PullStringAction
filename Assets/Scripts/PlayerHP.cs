using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float maxHp = 100;
    public float hp = 100;
    public float jumpHpDrain = 1;
    public AudioSource jumpSound;
    public AudioClip deathSound;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, hp / maxHp);

        jumpSound.pitch = Mathf.Lerp(1, 2, hp / maxHp);
    }

    public void Jump()
    {
        hp -= jumpHpDrain;

        // ƒWƒƒƒ“ƒv‰¹
        jumpSound.Play();

        if (hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Heal()
    {
        hp = maxHp;
    }
}
