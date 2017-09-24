namespace NumberToWordConverter.Repository.Interfaces
{
    /// <summary>
    /// IConvertRepository
    /// </summary>
    public interface IConvertRepository
    {
        /// <summary>
        /// Convert Currency in Words
        /// </summary>
        /// <param name="input"></param>
        /// <returns>decimal</returns>
        string ConvertCurrenyWords(decimal input);
    }
}
