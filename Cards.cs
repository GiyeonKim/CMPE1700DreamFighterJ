using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700GiyeonKimICAs05
{

    public enum Combination
    {
        // this is the combination for the cards hand rule
        None,
        Pair,
        TwoPair,
        ThreeofaKind,
        Straight,
        Flush,
        FullHouse,
        FourofaKind,
        StraightFlush,
        RoyalFlush,
    }

    public enum Suit
    {
        // suit of the cards
        Diamonds,
        Clubs,
        Hearts,
        Spades
    }
    public enum Faces
    {
        // faces of the cards
        Two = 2,
        Three = 3,
        Four = 4,
        Five= 5,
        Six = 6 ,
        Seven = 7,
        Eight =8,
        Nine = 9,
       Ten  ,
        Jack,
        Queen,
        King,
        Ace
    }
    
    public struct Cards
    {
        
        public Suit Suits;
        public Faces Face;
       
        public Cards(Suit S, Faces F)
        {
            Suits = S;
            Face = F;
        }



        public override string ToString()
        {
            return Face + " of " + Suits;
        }


    }
    

}
