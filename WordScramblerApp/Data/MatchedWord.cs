namespace WordScramblerApp.Data
{
    struct MatchedWord
    {
        public string ScrambleWord { get; set; }
        public string Word { get; internal set; }
    }
}
