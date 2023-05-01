namespace Core.Library.Types {
    public abstract class TypeBase<TOuter, TPrimative> 
        where TPrimative : notnull
        where TOuter : TypeBase<TOuter, TPrimative>  
    {
        private TPrimative _value;
        public TPrimative Value {
            get => _value;
            set => _value = value;
        }
        protected TPrimative? incrAmount;
        public TypeBase(TPrimative value)
        {
            _value = value;
        }

        public void SetIncrAmount(TPrimative incrementAmmount) => incrAmount = incrementAmmount;
        public abstract TOuter _Incr();
        public abstract TOuter _Decr();
        public bool IsNull() => _value == null;
        public bool In(params TOuter[] list)
        {
            foreach(TOuter item in list)
            {
                if (item == this) return true;
            }
            return false;
        }

        public override string? ToString() => _value.ToString();

        public override int GetHashCode() => _value.GetHashCode();
        public override bool Equals(object? obj) => base.Equals(obj);

        public static bool operator <(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => Comparer<TPrimative>.Default.Compare(lhs._value, rhs._value) < 0;
        public static bool operator >(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => !(lhs<rhs);
        public static bool operator >=(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (lhs>rhs) || (lhs==rhs);
        public static bool operator <=(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (lhs<rhs) || (lhs==rhs);
        public static bool operator ==(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => lhs.Equals(rhs);
        public static bool operator !=(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => !(lhs==rhs);
        public static TOuter operator +(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (dynamic) lhs._value + rhs._value;
        public static TOuter operator -(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (dynamic) lhs._value - rhs._value;
        public static TOuter operator *(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (dynamic) lhs._value * rhs._value;
        public static TOuter operator /(TypeBase<TOuter, TPrimative> lhs, TypeBase<TOuter, TPrimative> rhs) => (dynamic) lhs._value / rhs._value;
        public static TOuter operator ++(TypeBase<TOuter, TPrimative> obj) => obj._Incr();
        public static TOuter operator --(TypeBase<TOuter, TPrimative> obj) => obj._Decr();

    }
}