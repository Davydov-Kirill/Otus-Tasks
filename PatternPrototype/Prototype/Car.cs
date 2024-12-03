namespace Prototype
{
    /// <summary>
    /// Класс Car, представляющий легковой автомобиль.
    /// Наследуется от Vehicle и реализует метод клонирования.
    /// </summary>
    public class Car : Vehicle
    {
        protected readonly int _numberOfDoors;
        protected readonly FuelType _fuelType;

        /// <summary>
        /// Инициализирует новый экземпляр класса Car.
        /// </summary>
        /// <param name="brand">Марка автомобиля.</param>
        /// <param name="model">Модель автомобиля.</param>
        /// <param name="maxSpeed">Максимальная скорость автомобиля.</param>
        /// <param name="numberOfDoors">Число дверей.</param>
        /// <param name="fuelType">Тип топлива автомобиля.</param>
        /// <exception cref="ArgumentOutOfRangeException">Если число дверей меньше или равно 0.</exception>
        public Car(string brand, string model, int maxSpeed, int numberOfDoors, FuelType fuelType)
            : base(brand, model, maxSpeed)
        {
            if (numberOfDoors <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfDoors), "Number of doors must be greater than 0.");

            _numberOfDoors = numberOfDoors;
            _fuelType = fuelType;
        }

        /// <summary>
        /// Метод клонирования объекта Car.
        /// </summary>
        /// <returns>Новый объект Car, который является клоном текущего.</returns>
        public override Vehicle Clone()
        {
            return new Car(_brand, _model, _maxSpeed, _numberOfDoors, _fuelType);
        }

        /// <summary>
        /// Возвращает строковое представление объекта Car.
        /// </summary>
        /// <returns>Строка, содержащая информацию о марке, модели, максимальной скорости, числе дверей и типе топлива.</returns>
        public override string ToString()
        {
            return base.ToString() + $", Car (Number of doors: {_numberOfDoors}, Fuel type: {_fuelType})";
        }
    }
}
