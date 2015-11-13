using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700GiyeonKimICAs05
{
   public class Players
    {
        
       DeckofCards playerDeck = new DeckofCards();
       public List<Cards> hand = new List<Cards>();


       public void GenerateHand() // Generate the players hands of cards
       {
           for (int i = 0; i < 5; i++)
           {
               Cards c = playerDeck.Random();
               hand.Add(c);
               playerDeck.deck.Remove(c);
           }
           
           
       }
       
       public Combination CardCombo(Combination cardcombo)
       {
           cardcombo = Combination.None;
           return cardcombo;
       }       
    }
 }

