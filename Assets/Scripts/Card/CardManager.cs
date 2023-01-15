using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// For managing card in the battle scene
public class CardManager : SingletonMonoBehaviour<CardManager>
{
    private const int listBufferSize = 64;

    private List<int> listRemaining = new List<int>(listBufferSize);
    private List<int> listDiscarded = new List<int>(listBufferSize);

    private int activeSizeRemaining = 0;
    private int activeSizeDiscarded = 0;

    private int drawIndex = 0;

    public void Initialize()
    {
        for (int i = 0; i < listBufferSize; ++i)
        {
            listRemaining.Add(0);
            listDiscarded.Add(0);
        }
    }

    public void OnBattleStart()
    {
        // Clean everything before doing initialize
        for (int i = 0; i < listBufferSize; ++i)
        {
            listRemaining[i] = 0;
            listDiscarded[i] = 0;
        }

        // TODO : Get every card id's from the deck manager

        // Randomize the card order in the battle deck
        ShuffleCard();

        // TODO : Setup everything for the battle scene
    }

    public int DrawCard()
    {
        int ret = listRemaining[drawIndex++];

        // when every card is drew from the remaining deck, the deck will be reset and shuffle
        if (drawIndex >= activeSizeRemaining)
        {
            drawIndex = 0;
            ShuffleCard();
        }

        return ret;
    }

    private void ShuffleCard()
    {
        Assert.IsTrue(activeSizeRemaining > 0 && activeSizeRemaining <= listBufferSize);

        List<int> activeList = new List<int>();
        List<int> randomList = new List<int>();

        int randomCount = 0;

        // Using a new list to shuffle the cards
        for (int i = 0; i < activeSizeRemaining; ++i)
        {
            activeList.Add(listRemaining[i]);
            randomList.Add(0);
        }

        // Randomize the original order active list
        while (activeList.Count > 0)
        {
            int randomTarget = Random.Range(0, activeList.Count);

            randomList[randomCount] = activeList[randomTarget];
            activeList.RemoveAt(randomTarget);

            randomCount++;
        }

        // Just to make sure the number are the same
        Assert.IsTrue(randomCount == activeSizeRemaining);

        // Pass the randomized list to the main list
        for (int i = 0; i < activeSizeRemaining; ++i)
        {
            listRemaining[i] = randomList[i];
        }
    }
}
