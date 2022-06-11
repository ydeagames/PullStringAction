using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public float maxHp = 100;
    public float hp = 100;
    public float jumpHpDrain = 1;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, hp / maxHp);
    }

    public void Jump()
    {
        hp -= jumpHpDrain;

        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Heal()
    {
        hp = maxHp;
    }
}