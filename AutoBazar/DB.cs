namespace AutoBazar
{
    public abstract class EnumList
    {
        public enum ColorTypeEnum { Modrá, Červená, Zelená, Žlutá, Hnědá, Oranžová, Šedá, Bíla, Černá }
        public enum FuelTypeEnum { Elektřina, Benzín, Nafta, BioPlyn }
        public enum MotorTypeEnum { Elektrický, Spalovací }
        public enum GearBoxTypeEnum { Automatická, Poloautomatická, Manuální, Variátor }
        public enum TypeCarEnum { Sedan, Liftback, Hatchback, Limuzína, Kombi, MPV, SUV, Crossover, Rerénní, PickUp, Kabriolet, Roadster, Kupé }
        public enum TypeBusEnum { Mikrobus, Minibus, Midibus, Standardní, Patrové, Třinápravové, Kloubové }
        public enum TypeCargoCarEnum { Valník, ProPřepravuKontejneru, Dodávka, Skříň, PickUp }
    }

    public abstract class Base : EnumList
    {
        public ColorTypeEnum Color { get; set; }
        public string NameText { get; set; }
        public int MotorValueInCm { get; set; }
        public int MotorPowerInKW { get; set; }
        public FuelTypeEnum FuelType { get; set; }
        public MotorTypeEnum MotorType { get; set; }
    }

    public class DataCar : Base
    {
        public GearBoxTypeEnum GearType { get; set; }
        public TypeCarEnum CarType { get; set; }
    }

    public class DataCargoCar : DataCar
    {
        public int LoadCapacity { get; set; }
        public TypeCargoCarEnum CargoCarType { get; set; }
    }

    public class DataBus : DataCargoCar
    {
        public int Capacity { get; set; }
        public TypeBusEnum BusType { get; set; }
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
