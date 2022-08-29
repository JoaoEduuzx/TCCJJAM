using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MovimentoPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;

    public Text municao;

    public int quantMunicao;

    public Text por;

    public int quantPor;

    public float vidaInicial;

    public float vidaAtual;

    public float percVida;

    public Image barraVida;

    public Animator Anim;

    public bool Run;


    void Start()
    {
        vidaAtual = vidaInicial;
        Anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * Time.deltaTime * moveSpeed);

        if (moveInput.x != 0 || moveInput.y != 0)
        {

            Run = true;
            
        }
        else
        {
            Run = false;
        
        }

        if(moveInput.y > 0)
        {
            Anim.SetLayerWeight(1, 1);
            Anim.SetLayerWeight(2, 0);
        }
        if (moveInput.y < 0)
        {
            Anim.SetLayerWeight(1, 0);
            Anim.SetLayerWeight(2, 0);
        }
        if (moveInput.x >0)
        {
            Anim.SetLayerWeight(1, 0);
            Anim.SetLayerWeight(2, 1);
        }

        percentualVida();

        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        Anim.SetBool("Run", Run);
    }

    public void percentualVida()
    {
        percVida = vidaAtual / vidaInicial;


        barraVida.fillAmount = percVida;



    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "inimigo")
        {
            vidaAtual -= 0.2f;

            if(vidaAtual == 0)
            {
                print("Fim de jogo");
            }
        }

    
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "municao")
        {
            Destroy(collision.gameObject);

            quantMunicao += 1;

            municao.text = quantMunicao.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pocao")
        {
            Destroy(collision.gameObject);

            quantPor += 1;

            por.text = quantPor.ToString();
        }
    }


}
