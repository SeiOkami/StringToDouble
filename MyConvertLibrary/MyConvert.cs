namespace MyConvertLibrary
{
    public static class MyConvert
    {

        public static double StringToDouble(string str)
        {
            double result = 0;

            char[] fractionalChr = { ',', '.' };
            char[] ignoredChr = { ' ', '_', '\'' };
            char[] polaritiesChr = { '+', '-' };

            Dictionary<char, byte> numbers = new(){
                {'0',0}, {'1',1}, {'2',2}, {'3',3}, {'4',4}, {'5',5}, {'6',6}, {'7',7}, {'8',8}, {'9',9}
            };
            byte thisNumber;

            char positiveChr = '+';

            bool? thisPolarity = null;

            bool thisFractional = false;
            
            int lengthFractional = 0;
            ulong fractionalPart = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (Array.IndexOf(ignoredChr, c) >= 0)
                    continue;
                else if (thisPolarity == null && Array.IndexOf(polaritiesChr, c) >= 0)
                    thisPolarity = (c == positiveChr);
                else if (!thisFractional && Array.IndexOf(fractionalChr, c) >= 0)
                    thisFractional = true;
                else if (numbers.TryGetValue(c, out thisNumber))
                {
                    if (thisFractional)
                    {
                        fractionalPart = (fractionalPart * 10) + thisNumber;
                        lengthFractional++;
                    }
                    else if (thisNumber == 0 && result == 0)
                        continue;
                    else
                        result = result * 10 + thisNumber;
                }
                else
                    throw new Exception($"Unexpected character {c} at position {i}");
            }

            if (thisFractional)
            {
                result += (double)(fractionalPart / Math.Pow(10, lengthFractional));
            }

            if (thisPolarity == false)
                result *= -1;

            return result;

        }

    }
}