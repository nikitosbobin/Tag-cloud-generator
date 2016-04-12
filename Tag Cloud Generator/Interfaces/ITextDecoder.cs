namespace Tag_Cloud_Generator.Interfaces
{
    interface ITextDecoder
    {
        string[] TextLines { get; set; }
        string[] GetDecodedText();
    }
}
