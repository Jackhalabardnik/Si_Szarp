namespace api
{
    public class Censor
    {
        /// <summary>
        /// Lista słów, które mają zostać ocenzurowane w tekście
        /// </summary>
        public List<string> Blacklist { get; set; } = new List<string>();

        /// <summary>
        /// Funkcja cenzurująca pojedyncze słowo.
        /// 
        /// Słowa, które znajdują się na liście <see cref="Blacklist"/> mają zostać zamienione
        /// na pierwszą literę oraz taką liczbę gwiazdek, ile miało oryginalne słowo,
        /// np. "bomba" na "b****"
        /// </summary>
        /// <param name="word">Słowo nieocenzurowane</param>
        /// <returns>Słowo ocenzurowane</returns>
        public string CensorWord(string word)
        {
            var test_word = word.ToLower();
            if (Blacklist.Contains(test_word))
            {
                var asterixs = new String('*', word.Length-1);
                return word.First() + asterixs;
            }
            return word;
        }

        /// <summary>
        /// Funkcja cenzurująca cały tekst, który możę się składać z wielu słów.
        /// 
        /// Można zignorować znaki przestankowe (,."?! itp.) oraz nadmiarowe spacje w środku tekstu.
        /// </summary>
        /// <param name="text">Tekst nieocenzurowany</param>
        /// <returns>Tekst ocenzurowany</returns>
        public string CensorText(string text)
        {
            var words = text.Split(' ');
            var result = "";
            foreach (var word in words)
            {
                result += CensorWord(word) + " ";
            }
            result = result.TrimEnd();
            return result;
        }
    }
}
