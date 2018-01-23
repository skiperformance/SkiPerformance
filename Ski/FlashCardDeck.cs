namespace Ski
{
    public class FlashCard
    {
        // Return the math problem string:
        public string Title { get; set; }
    }

    public class FlashCardDeck
    {

        // Built-in flash card problems/answers (could be replaced with a database)
        static FlashCard[] builtInFlashCards = {
            new FlashCard { Title = "DATA" },
            new FlashCard { Title = "MAP" },
            new FlashCard { Title = "CHARTS" } };

        // Array of flash cards that make up the flash card deck:
        private FlashCard[] flashCards;

        // Create an instance copy using the built-in flash cards:
        public FlashCardDeck() { flashCards = builtInFlashCards; }

        // Indexer (read only) for accessing a flash card:
        public FlashCard this[int i] { get { return flashCards[i]; } }

        // Returns the number of flash cards in the deck:
        public int NumCards { get { return flashCards.Length; } }
    }
}