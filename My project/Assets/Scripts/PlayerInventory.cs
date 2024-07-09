using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    
    public float bandageHealing = 40f;

    public int bandages = 0;
    public int adrenalineInjections = 0;
    public int tickets = 0;
    public bool usedAdrenaline=false;

    public Text bandagesText;
    public Text adrenalineInjectionsText;
    public GameObject ticketsText;

    void Start()
    {
        ticketsText.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            UseAdrenalineShot();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            UseBandages();
        }
        UpdateUI();
       
    }

    public void AddBandage(int count = 1)
    {
        bandages += count;
        UpdateUI();
    }

    public void AddAdrenalineInjection(int count = 1)
    {
        adrenalineInjections += count;
        UpdateUI();
    }

    public void AddTicket(int count = 1)
    {
        tickets += count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (bandagesText != null)
        {
            bandagesText.text = "X"+ bandages.ToString();
        }

        if (adrenalineInjectionsText != null)
        {
            adrenalineInjectionsText.text = "X"+adrenalineInjections.ToString();
        }

        if (ticketsText != null && tickets> 0)
        {
            ticketsText.SetActive(true);
        }
    }

    private void UseAdrenalineShot()
    {
        if(adrenalineInjections>0)
        {
            adrenalineInjections--;
            usedAdrenaline = true;
        }
        UpdateUI();
    }


    private void UseBandages()
    {
        if (bandages > 0)
        {
            bandages--;
            PlayerHealth health = GetComponentInChildren<PlayerHealth>();
            if (health != null)
            {
                health.Heal(bandageHealing);
            }
        }
        UpdateUI();
    }
    
}