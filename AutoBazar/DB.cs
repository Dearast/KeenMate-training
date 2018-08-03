using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBazar
{
	public abstract partial class Base
	{
		public enum ColorType { modrá, červená, zelená, žlutá, hnědá, oranžová, šedá, bíla, černá }
		public string ColorString { get; set; }
		public string NameText { get; set; }
		public int MotorValueInCm { get; set; }
		public int MotorPowerInKW { get; set; }
		public enum FuelType { electricity, benzine, oil, biofuel, gas }
		public string FuelTypeString { get; set; }
		public enum MotorType { electric, burner }
		public string MotorTypeString { get; set; }
	}

	public class DataCar : Base
	{
		public enum GearBoxType { Automatická, Poloautomatická, Manuální, Variátor }
		public string GearBoxString { get; set; }
		public GearBoxType GearType { get; set; }
		public enum TypeCar { sedan, liftback, hatchback, limuzína, kombi, MPV, SUV, crossover, terénní, pick_up, kabriolet, roadster, kupé }
		public string TypeCarString { get; set; }
		public TypeCar CarType { get; set; }
	}

	public class DataCargoCar : DataCar
	{
		public int LoadCapacity { get; set; }
	}

	public class DataBus : DataCargoCar
	{
		public int Capacity { get; set; }
	}

	public class DataMotorcykle : Base
	{

	}

	public class DataBike
	{
		public int Type { get; set; }
		public int Color { get; set; }
		public string Text { get; set; }
	}

	public class DataBikecykleWithMotor : Base
	{

	}
}
