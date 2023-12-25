using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public float currentHealth, maxHealth;
    public float currentCalory, maxCalory;
    public float currentFreezing, maxFreezing;

    float distanceTravelled = 0;
    Vector3 lastposition;
    public GameObject playerBody;
    public bool isPlayerNearToFire=false;
    
    
    public static PlayerState instance { get; set; }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;    
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    /*

    //ate�ten uzak biyerde donma
    IEnumerator increaseCurrentFreezing()
    {   
        while(!isPlayerNearToFire && currentFreezing<100)
        {
            Debug.Log("d�sarda g�t�n  donuyor");
            currentFreezing += 0.01f;
            yield return new WaitForSeconds(2);
        }
    }

    //ate� ba�� �s�nma
    IEnumerator decreaseCurrentFreezing()
    {
        while (isPlayerNearToFire)
        {
            //ate�in ba��nda her saniye donmay� azalt
            currentFreezing -= 0.01f;
            Debug.Log("ate�in yan�nda �s�n�l�yor");
            yield return new WaitForSeconds(3);
        }
    }


    //donarsa veya a� akl�rsa can azaltma s�reyle
    IEnumerator decreaseCurrentHealth()
    {
        while ((currentFreezing>=100 || currentCalory <= 0) && currentHealth>0)
        {
            //her 3 saniyede can azalt
            currentHealth -= 0.001f;
            yield return new WaitForSeconds(4);
        }
    }

    */
    


    // Update is called once per frame
    void Update()
    {
        if((currentFreezing >= 100 || currentCalory <= 0) && currentHealth > 0)
        {
            //StartCoroutine(decreaseCurrentHealth());
            currentHealth -= 0.0003f;

        }

        if (isPlayerNearToFire && currentFreezing >0) //ISINMA 
        {
            //StartCoroutine(decreaseCurrentFreezing());
            
            currentFreezing -= 0.007f;


        }
        else //donma
        {
            //StartCoroutine(increaseCurrentFreezing());
            if(currentFreezing < 100) { currentFreezing += 0.001f; }
            

        }


        if(currentHealth<=0)
        {
            Debug.Log("�ld�nnnnn");
            string currentSceneName = SceneManager.GetActiveScene().name;
            // Aktif sahneyi tekrar y�kle
            SceneManager.LoadScene(currentSceneName);
        }


        //y�r�meye ba�l� enerji azaltma
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastposition);
        lastposition = playerBody.transform.position;
        
        if (currentCalory>0 && distanceTravelled > 5)
        {
            distanceTravelled = 0;
            currentCalory -= 1;
            if(currentCalory<0) { currentCalory = 0; }
        }

        
       


    }

    
    public void increaseCurrentHealt(float health)
    {
        this.currentHealth += health;
    }

    public void decreaseCurrentHealt(float health)
    {
        this.currentHealth -= health;
    }


    
    

    public void increaseCurrentCalory(float calory)
    {
        this.currentCalory += calory;
    }

    public void decreaseCurrentCalory(float calory)
    {
        this.currentCalory -= calory;
    }


}
