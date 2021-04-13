using UnityEngine;

public class Spell_Inventory : MonoBehaviour
{
   // public int spell_equipped = 0;
    
    void onEnable()
    {
        Debug.Log("Spell Change Initialized");
        //changeSpell();
    }

    void update()
    {
        
    }

  /*  public void changeSpell(int spell_equipped)
    {
        Debug.Log("In changeSpell Method");
        int i = 0;
        foreach (Transform spell in transform)
        {
            if (i == spell_equipped)
                spell.gameObject.SetActive(true);
            else
                spell.gameObject.SetActive(false);
            i++;
        }
    }*/
}
