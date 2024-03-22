using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    public string correctGemOrder = "BlueRedGreen";
    public string enteredGemOrder = "";

    private int _amountOfGems = 3;
    private int _amountOfSelectedGems = 0;

    public Animator boxAnimator;

    public List<Gem> _gems = new List<Gem>();

    public UnityEvent gameIsWon;


    public void GemSelect(Gem selectedGem)
    {
        if (!selectedGem.isSelected)
        {
            selectedGem.isSelected = true;
            enteredGemOrder += selectedGem.gemColor;
            _amountOfSelectedGems++;
            selectedGem.ChangeEmission(true);
        }
        
        if (_amountOfSelectedGems == _amountOfGems)
        {
            CheckGemOrder();
        }
    }

    public void CheckGemOrder()
    {
        if(enteredGemOrder == correctGemOrder)
        {
            CompleteGame();
        } else
        {
            ResetGame();
        }
    }

    void CompleteGame()
    {
        boxAnimator.SetTrigger("Open");
        gameIsWon.Invoke();
    }

    void ResetGame()
    {
        _amountOfSelectedGems = 0;
        enteredGemOrder = "";
        foreach (Gem gem in _gems)
        {
            gem.isSelected = false;
            gem.ChangeEmission(false);
        }
    }
}

