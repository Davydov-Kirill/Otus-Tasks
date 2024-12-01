namespace Prototype
{
    /// <summary>
    /// Класс ElectricCar, представляющий электрический автомобиль.
    /// Наследуется от Car и реализует метод клонирования.
    /// </summary>
    public class ElectricCar : Car
    {
        private readonly int _batteryCapacity;

        /// <summary>
        /// Инициализирует новый экземпляр класса ElectricCar.
        /// </summary>
        /// <param name="brand">Марка электрического автомобиля.</param>
        /// <param name="model">Модель электрического автомобиля.</param>
        /// <param name="maxSpeed">Максимальная скорость электрического автомобиля.</param>
        /// <param name="numberOfDoors">Число дверей.</param>
        /// <param name="fuelType">Тип топлива (обычно электрический).</param>
        /// <param name="batteryCapacity">Емкость батареи.</param>
        /// <exception cref="ArgumentOutOfRangeException">Если емкость батареи меньше 0.</exception>
        public ElectricCar(string brand, string model, int maxSpeed, int numberOfDoors, FuelType fuelType, int batteryCapacity)
            : base(brand, model, maxSpeed, numberOfDoors, fuelType)
        {
            if (batteryCapacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(batteryCapacity), "Battery capacity must be greater than 0.");

            _batteryCapacity = batteryCapacity;
        }

        /// <summary>
        /// Метод клонирования объекта ElectricCar.
        /// </summary>
        /// <returns>Новый объект ElectricCar, который является клоном текущего.</returns>
        public override Vehicle Clone()
        {
            return new ElectricCar(_brand, _model, _maxSpeed, _numberOfDoors, _fuelType, _batteryCapacity);
        }

        /// <summary>
        /// Возвращает строковое представление объекта ElectricCar.
        /// </summary>
        /// <returns>Строка, содержащая информацию о марке, модели, максимальной скорости, числе дверей и емкости батареи.</returns>
        public override string ToString()
        {
            return base.ToString() + $", Electric  car (Battery capacity: {_batteryCapacity} kWh)";
        }
    }
}
