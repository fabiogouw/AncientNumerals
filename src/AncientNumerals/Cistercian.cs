using System.Text;

namespace AncientNumerals
{
    public class Cistercian
    {
        private static IEnumerable<NumberPattern> _units = NumberPattern.GetAll()
            .Where(p => p.Number >= 1 && p.Number <= 9);
        private static IEnumerable<NumberPattern> _dozens = NumberPattern.GetAll()
            .Where(p => p.Number >= 10 && p.Number <= 90);
        private static IEnumerable<NumberPattern> _hundreds = NumberPattern.GetAll()
            .Where(p => p.Number >= 100 && p.Number <= 900);
        private static IEnumerable<NumberPattern> _thousends = NumberPattern.GetAll()
            .Where(p => p.Number >= 1000 && p.Number <= 9000);

        private int _value;

        public static Cistercian Parse(string numeral)
        {
            int value = 0;
            var matrix = NumberPattern.ToMatrix(numeral);
            foreach (var unit in _units)
            {
                if (unit.Contains(matrix))
                {
                    value += unit.Number;
                    break;
                }
            }
            foreach (var dozen in _dozens)
            {
                if (dozen.Contains(matrix))
                {
                    value += dozen.Number;
                    break;
                }
            }
            foreach (var hundred in _hundreds)
            {
                if (hundred.Contains(matrix))
                {
                    value += hundred.Number;
                    break;
                }
            }
            foreach (var thousend in _thousends)
            {
                if (thousend.Contains(matrix))
                {
                    value += thousend.Number;
                    break;
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
            var matrix = NumberPattern.GetFor(0).Apply(NumberPattern.CreateEmptyMatrix());
            foreach(int numberPart in GetNumberParts(_value))
            {
                matrix = NumberPattern.GetFor(numberPart).Apply(matrix);
            }
            var sb = new StringBuilder();
            for(int x = 0; x < NumberPattern.NUM_LINES; x++)
            {
                for(int y = 0; y < NumberPattern.NUM_COLUMNS; y++)
                {
                    sb.Append(matrix[x,y]);
                }
                if(x < NumberPattern.NUM_LINES)
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
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