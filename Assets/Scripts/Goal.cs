using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    public bool isPlayer1 = true;

    public AudioClip clip;

    private int player1 = 0;
    private int player2 = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puk"))
        {
            if (isPlayer1)
            { 
                 player1Text.text = (++player1).ToString("D2");
            }
            else
            {
               player2Text.text = (++player2).ToString("D2");
            }
        }
        audioSource.PlayOneShot(clip);
        collision.transform.position = Vector3.zero;
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
