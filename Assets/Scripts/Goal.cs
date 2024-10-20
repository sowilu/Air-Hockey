using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioClip clip;

    private AudioSource audioSource;
    private int score;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puk"))
        {
            audioSource.PlayOneShot(clip);
            scoreText.text = (++score).ToString("D2");

            collision.transform.position = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
