using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMannager : MonoBehaviour
{

    public GameObject menuPr;
    public GameObject menuGO;

    public GameObject piedra1;
    public GameObject piedra2;
    public float velocidad=2;
    public GameObject col;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> cols;
    public List<GameObject> obs;
    // Start is called before the first frame update
    void Start()
    {
        //Crear mapa
        for(int i=0; i<21; i++)
        {
           cols.Add(Instantiate(col, new Vector2(-10+i,-3),Quaternion.identity));
        }

        //Crear piedras
        obs.Add(Instantiate(piedra1,new Vector2(14,-2),Quaternion.identity));
        obs.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {

        if(start==false)
        {
               if(Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver==true)
        {
            menuGO.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }

        if (start == true && gameOver== false)
        {
            menuPr.SetActive(false);

            //textura
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            //Mover mapa

            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }

                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mover obstaculos

            for (int i = 0; i < obs.Count; i++)
            {
                if (obs[i].transform.position.x <= -10)
                {
                    float random = Random.Range(11, 18);
                    obs[i].transform.position = new Vector3(random, -2, 0);
                }

                obs[i].transform.position = obs[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
