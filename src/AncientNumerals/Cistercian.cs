using System.Text;

namespace AncientNumerals
{
    public class Cistercian
    {
        private static Dictionary<int, IEnumerable<NumberPattern>> _quadrantWithPatterns = new()
        {
            { 1, NumberPattern.GetAll().Where(p => p.Number >= 1 && p.Number <= 9) },
            { 10, NumberPattern.GetAll().Where(p => p.Number >= 10 && p.Number <= 90) },
            { 100, NumberPattern.GetAll().Where(p => p.Number >= 100 && p.Number <= 900) },
            { 1000, NumberPattern.GetAll().Where(p => p.Number >= 1000 && p.Number <= 9000) }
        };

        private int _value;

        public static Cistercian Parse(string numeral)
        {
            int value = 0;
            var matrix = NumberPattern.ToMatrix(numeral.Trim());
            foreach (var quadrant in _quadrantWithPatterns)
            {
                foreach (var pattern in quadrant.Value)
                {
                    if (pattern.Contains(matrix))
                    {
                        value += pattern.Number;
                        break;
                    }
                }
            }
            var cistercian = new Cistercian(value);
            return cistercian;
        }

        public Cistercian(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            var matrix = NumberPattern.GetEmpty().FillInto(NumberPattern.CreateEmptyMatrix());
            foreach(int numberPart in GetNumberParts(_value))
            {
                matrix = NumberPattern.GetFor(numberPart)
                    .FillInto(matrix);
            }
            var sb = new StringBuilder();
            for(int line = 0; line < NumberPattern.NUM_LINES; line++)
            {
                for(int column = 0; column < NumberPattern.NUM_COLUMNS; column++)
                {
                    sb.Append(matrix[line,column]);
                }
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        private int[] GetNumberParts(int number)
        {
            var result = new int[4];
            for(int i = 0; i < 4; i++)
            {
                int currentNumberPart = number % (int)Math.Pow(10, i + 1);
                int previousNumberPart = number % (int)Math.Pow(10, i);
                result[i] = currentNumberPart - previousNumberPart;
            }
            return result.Where(x => x > 0).ToArray();
        }

        public int Value
        {
            get { return _value; }
        }
    }
}