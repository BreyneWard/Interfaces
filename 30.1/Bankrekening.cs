namespace _30._1_
{
    public class Bankrekening : InterfaceObject
    {
		private double  _rentevoet;

		public double  Rentevoet
		{
			get { return _rentevoet; }
			set { _rentevoet = value; }
		}

		private double _saldo;

		public double Saldo
		{
			get { return _saldo; }
			set { _saldo = value; }
		}

		public Bankrekening() { }
		public Bankrekening(double rentevoet, double saldo)
		{
			Rentevoet= rentevoet;
			Saldo= saldo;
		}
		public double Bereken()
		{
			return Saldo * (Rentevoet / 100);
		}

        public override string ToString()
        {
             return $"De interest van de rekening met saldo {this.Saldo} en rentevoet {this.Rentevoet} is {Bereken()}";
        }

    }
}
