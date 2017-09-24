using NumberToWordConverter.Repository.Interfaces;
using System;
using System.Globalization;

namespace NumberToWordConverter.Repository.Classes
{
    /// <summary>
    /// ConvertRepository
    /// </summary>
    public class ConvertRepository : IConvertRepository
    {
        /// <summary>
        /// Convert Curreny in Words
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ConvertCurrenyWords(decimal input)
        {
            return ChangeToWords(input);
        }

        #region Private Methods
        
        /// <summary>
        /// Change to Words Function
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ChangeToWords(decimal input)
        {
            string numb = Convert.ToString(input, CultureInfo.InvariantCulture);
            string val = "", wholeNo = numb;
            string andStr = "and", pointStr = "";
            string endStr = "Only";
            string currencyName = "Dollars";
            string currencyPoints = "Cents";
            bool showPoints = false;
            try
            {
                var decimalPlace = numb.IndexOf(".", StringComparison.Ordinal); if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    var dPoints = numb.Substring(decimalPlace + 1);
                    showPoints = (Convert.ToInt32(dPoints) > 0);
                    if (showPoints)
                    {
                        pointStr = ChangeNumbertoWords(dPoints);
                    }
                }
                val = !showPoints ? String.Format("{0} {1} {2}", ChangeNumbertoWords(wholeNo).Trim(), currencyName, endStr) : String.Format("{0} {1} {2}{3} {4} {5}", ChangeNumbertoWords(wholeNo).Trim(), currencyName, andStr, pointStr, currencyPoints, endStr);
            }
            catch (Exception)
            {

            }
            return val;
        }

        /// <summary>
        /// Change Number to Words
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string</returns>
        private string ChangeNumbertoWords(string number)
        {
            string word = "";
            try
            {
                var isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {
                    //test for zero or digit zero in a nuemric
                    var beginsZero = number.StartsWith("0");//tests for 0XX
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    string place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = Ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = Tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        word = ChangeNumbertoWords(number.Substring(0, pos)) + place + ChangeNumbertoWords(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch {; }
            return word.Trim();
        }

        /// <summary>
        /// Convert to Tens
        /// </summary>
        /// <param name="digit"></param>
        /// <returns>string</returns>
        private string Tens(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = null; switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = Tens(digit.Substring(0, 1) + "0") + " " + Ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }

        /// <summary>
        /// Convert to Ones
        /// </summary>
        /// <param name="digit"></param>
        /// <returns>string</returns>
        private string Ones(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        #endregion
    }
}