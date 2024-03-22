using UnityEngine;
using System.Collections.Generic;

public class BoxManager : MonoBehaviour
{
    public string correctGemOrder = "BlueRedGreen";
    public string enteredGemOrder = "";

    private int _amountOfGems = 3;
    private int _currentGem = 0;

    public Animator boxAnimator;

    public List<Gem> _gems = new List<Gem>();


    public void GemSelect(Gem selectedGem)
    {
        if (!selectedGem.isSelected)
        {
            selectedGem.isSelected = true;
            enteredGemOrder += selectedGem.gemColor;
            _currentGem++;
            selectedGem.ChangeEmission(true);
            print("Gem selected, Entered order:" + enteredGemOrder);
        }
        
        if (_amountOfGems == _currentGem)
        {
            CheckGemOrder();
        }
    }

    public void CheckGemOrder()
    {
        if(enteredGemOrder == correctGemOrder)
        {
            print("Correct order, Entered order: " + enteredGemOrder);
            boxAnimator.SetTrigger("Open");
        } else
        {
            print("Wrong order, Entered order: " + enteredGemOrder);
            _currentGem = 0;
            enteredGemOrder = "";
            foreach(Gem gem in _gems)
            {
                gem.isSelected = false;
                gem.ChangeEmission(false);
            }
        }
    }
}

