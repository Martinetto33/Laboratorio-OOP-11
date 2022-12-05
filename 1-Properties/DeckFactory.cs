namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        /*Usiamo dei campi d'appoggio speciali privati per le proprietà che non usano getter e setter predefiniti.
        
        Come descritto nelle slide, le proprietà non vanno viste come campi bensì come piccole classi che contengono
        un solo campo, un getter e un setter. Tuttavia i nomi delle proprietà sono preceduti dal tipo del campo interno,
        es: string[] Seeds vuol dire che la proprietà Seeds contiene un campo di tipo string[]

        Usiamo i campi privati (in questo caso) perché vogliamo manipolare l'input passato alle proprietà, ossia
        non usaimo get e set implementati di default. In tal caso sono comodi i campi privati perché li si può
        manipolare a piacimento.
        */
        private IList<string> _seeds;
        private IList<string> _names;
        public string[] Seeds 
        {
            get => _seeds.ToArray();
            set
            {
                _seeds = value;
            }
        }
        public string[] Names 
        {
            get => _names.ToArray();
            set
            {
                _names = value;
            }
        }

        // TODO improve
        public int GetDeckSize()
        {
            return Names.Length * Seeds.Length;
        }

        /// TODO improve
        public ISet<Card> GetDeck()
        {
            if (Names == null || Seeds == null)
            {
                throw new InvalidOperationException();
            }

            return new HashSet<Card>(Enumerable
                .Range(0, Names.Length)
                .SelectMany(i => Enumerable
                    .Repeat(i, Seeds.Length)
                    .Zip(
                        Enumerable.Range(0, Seeds.Length),
                        (n, s) => Tuple.Create(Names[n], Seeds[s], n)))
                .Select(tuple => new Card(tuple))
                .ToList());
        }
    }
}
