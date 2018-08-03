using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBazar
{
	public abstract class EnumList
	{
		public enum ColorTypeEnum { modrá, červená, zelená, žlutá, hnědá, oranžová, šedá, bíla, černá }
		public enum FuelTypeEnum { electricity, benzine, oil, biofuel, gas }
		public enum MotorTypeEnum { electric, burner }
		public enum GearBoxTypeEnum { Automatická, Poloautomatická, Manuální, Variátor }
		public enum TypeCarEnum { sedan, liftback, hatchback, limuzína, kombi, MPV, SUV, crossover, terénní, pick_up, kabriolet, roadster, kupé }
	}

	public abstract class Base : EnumList
	{
		public ColorTypeEnum Color { get; set; }
		public string NameText { get; set; }
		public int MotorValueInCm { get; set; }
		public int MotorPowerInKW { get; set; }
		public FuelTypeEnum FuelType { get; set; }
		public MotorTypeEnum MotorType{ get; set; }
	}

	public class DataCar : Base
	{
		public GearBoxTypeEnum GearType { get; set; }
		public TypeCarEnum CarType { get; set; }
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
