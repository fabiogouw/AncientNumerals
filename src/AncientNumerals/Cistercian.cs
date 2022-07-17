using System.Text;

namespace AncientNumerals
{
    public class Cistercian
    {
        private static IEnumerable<NumberPattern> _units = NumberPattern.GetAll()
            .Where(p => p.Number >= 1 && p.Number <= 9);
        private static IEnumerable<NumberPattern> _tens = NumberPattern.GetAll()
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
                if (unit.CanApply(matrix))
                {
                    value += unit.Number;
                    break;
                }
            }
            foreach (var ten in _tens)
            {
                if (ten.CanApply(matrix))
                {
                    value += ten.Number;
                    break;
                }
            }
            foreach (var hundred in _hundreds)
            {
                if (hundred.CanApply(matrix))
                {
                    value += hundred.Number;
                    break;
                }
            }
            foreach (var thousend in _thousends)
            {
                if (thousend.CanApply(matrix))
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
            var matrix = ApplyPattern(NumberPattern.GetFor(0), NumberPattern.CreateEmptyMatrix());
            if(_value > 0)
            {
                matrix = ApplyPattern(NumberPattern.GetFor(_value % 10), NumberPattern.CreateEmptyMatrix());
            }
            if (_value > 10)
            {
                matrix = ApplyPattern(NumberPattern.GetFor(_value % 100), NumberPattern.CreateEmptyMatrix());
            }
            if (_value > 100)
            {
                matrix = ApplyPattern(NumberPattern.GetFor(_value % 1000), NumberPattern.CreateEmptyMatrix());
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

        private char[,] ApplyPattern(NumberPattern pattern, char[,] matrix)
        {
            return matrix;
        }

        public int Value
        {
            get { return _value; }
        }
    }
}