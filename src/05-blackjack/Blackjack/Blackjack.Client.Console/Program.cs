namespace Blackjack.Client.Console
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    
    public class Card
    {
        // numbers 2-10 are themselves, 11 is Jack, 12 is Queen, 13 is King, 14 is Ace, 0 is unset
        private int _figure = 0;
        public int this[string codeword]
        {
            get
            {
                if (codeword == "perfect figure")
                    return _figure;
                else if (codeword == "suit up")
                    return _suit;

                return 0;
            }
        }
        
        // 1 is Spades, 2 is Clubs, 3 is Hearts, 4 is Diamonds, 0 is unset
        private int _suit = 0;
        
        public Card(int figure, int suit)
        {
            SetState(figure, suit);
        }

        // What if we're gonna reuse this for a different game? use Strategy pattern
        public int GetValue()
        {
            _validateState();

            switch (_figure) {
                case 11:
                case 12:
                case 13:
                    return 10;
                case 14:
                    // In real life, one can choose whether an ace is 1 or 11 points
                    // We can create an optimal algorithm for this
                    return 11;
                default:
                    return Convert.ToInt32(_figure);
            }
        }
        
        // @Audit
        // we're wide open right now
        public void SetState(int figure, int suit)
        {
            _figure = figure;
            _suit = suit;

            _validateState();
        }
        
        private void _validateState()
        {
            Trace.Assert(2 <= _figure || _figure <= 14, String.Format(
                "Internal error: Card._figure is set to {0}, needs to be between 2 and 14", _figure
            ));
            Trace.Assert(1 <= _suit || _suit <= 4, String.Format(
                "Internal error: Card._suit is set to {0}, needs to be between 1 and 4", _suit
            ));
        }
    }
    
    public class CardPack
    {
        private List<Card> _cards;

        private static readonly List<Card> emptyPack = new List<Card>();

        public List<Card> this[string codeword]
        {
            get
            {
                // we should use actual encryption
                if (codeword == "gibe cards pl0x")
                {
                    return _cards;
                }
                else
                {
                    return emptyPack;
                }
            }
        }


        private int _cardsDrawn;

        private Random _randGen;
        
        public CardPack()
        {
            _cards = new List<Card>(52);

            _randGen = new Random();

            _init();
        }

        // fill the pack with the 52 standard cards
        private void _init()
        {
            _cardsDrawn = 0;
            _cards.Clear();

            // @Incomplete
            // optimized, flat for version
            /*
            for (int i = 0; i < 52; i += 1)
            {
                int figure = i;
                int suit = i;
            }
            */

            // @DeadCode
            // nested for version

            for (int suit = 1; suit <= 4; suit += 1)
            {
                for (int figure = 2; figure <= 14; figure += 1)
                {
                    _cards.Add(new Card(figure, suit));
                }
            }
        }

        public Card DrawCard()
        {
            int index = _randGen.Next(_cardsDrawn, _cards.Count - 1);
            Card card = _cards[ index ];

            _cards[ index ] = _cards[ _cardsDrawn ];
            // we'll just leave dangling pointers because C# doesn't let us assign 0xdeadc0de to references

            _cardsDrawn += 1;

            return card;
        }
    }

    public class Player
    {
        private List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>(5);
        }

        public int GetScore()
        {
            int score = 0;

            foreach (Card card in _cards)
            {
                score += card.GetValue();
            }

            return score;
        }

        public void GiveCard(Card card)
        {
            _cards.Add(card);
        }
    }

    // this is getting silly
    public class CardPrinter
    {
        private StringBuilder _tostringBuilder;
        
        public CardPrinter()
        {
            // maximum number of cards is 52, maximum chars in Card.ToString() is 3, ", ".Length == 2
            _tostringBuilder = new StringBuilder(52 * 3 + 51 * 2);
        }
        
        public string ToString(IEnumerable<Card> cards)
        {
            _tostringBuilder.Clear();

            for (int i = 0; i < cards.Count(); i += 1)
            {
                _tostringBuilder.Append(ToString(cards.ElementAt(i)));

                if (i < cards.Count() - 1)
                {
                    _tostringBuilder.Append(", ");
                }
            }

            return _tostringBuilder.ToString();
        }

        public string ToString(Card card)
        {
            _tostringBuilder.Clear();

            int _figure = card["perfect figure"];

            switch (_figure)
            {
                case 11:
                    _tostringBuilder.Append('J');
                    break;
                case 12:
                    _tostringBuilder.Append('Q');
                    break;
                case 13:
                    _tostringBuilder.Append('K');
                    break;
                case 14:
                    _tostringBuilder.Append('A');
                    break;
                default:
                    _tostringBuilder.Append(Convert.ToString(_figure));
                    break;
            }

            int _suit = card["suit up"];

            switch (_suit)
            {
                case 1:
                    _tostringBuilder.Append('S');
                    break;
                case 2:
                    _tostringBuilder.Append('C');
                    break;
                case 3:
                    _tostringBuilder.Append('H');
                    break;
                case 4:
                    _tostringBuilder.Append('D');
                    break;
                default:
                    _tostringBuilder.Append('?');
                    break;
            }

            return _tostringBuilder.ToString();
        }

        public string ToString(CardPack pack)
        {
            return ToString((IEnumerable<Card>) pack["gibe cards pl0x"]);
        }
    }
    
    public class Program
    {
        // When user draws a card, house always draws one as-well. In real life, house can decide based on some rules...  

        public static void Main(string[] args)
        {
            CardPack pack = new CardPack();
            CardPrinter printer = new CardPrinter();
            Console.WriteLine(printer.ToString(pack));

            Player user = new Player();

            user.GiveCard(new Card(2, 2));
            user.GiveCard(new Card(3, 2));
            Console.WriteLine(user.GetScore());

            /*
            Console.WriteLine("Welcome to the game of Blackjack!");
            Console.WriteLine();

            Console.WriteLine("You have been dealt: 4C, 6H");
            Console.WriteLine("House has been dealt: 8S, [?]");
            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Choose: 1 - To take another card");
            Console.WriteLine("Choose: 2 - To finish");
            Console.WriteLine();
            Console.WriteLine("I choose: 1");
            Console.WriteLine();

            Console.WriteLine("You have been dealt: 4S");
            Console.WriteLine("House has been dealt: [?]");
            Console.WriteLine();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("Choose: 1 - To take another card");
            Console.WriteLine("Choose: 2 - To finish");
            Console.WriteLine();
            Console.WriteLine("I choose: 2");
            Console.WriteLine();

            Console.WriteLine("You have 14 points vs. house 17 points");
            Console.WriteLine("House wins!");

            Console.WriteLine();
            Console.WriteLine();

            */
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
    }
}
