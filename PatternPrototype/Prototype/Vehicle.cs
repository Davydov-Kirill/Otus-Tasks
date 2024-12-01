namespace Prototype
{
    /// <summary>
    /// Абстрактный класс Vehicle, представляющий транспортное средство.
    /// Реализует интерфейс IMyCloneable и предоставляет возможность клонирования объектов.
    /// </summary>
    public abstract class Vehicle : IMyCloneable<Vehicle>, ICloneable
    {
        protected readonly string _brand;
        protected readonly string _model;
        protected readonly int _maxSpeed;

        /// <summary>
        /// Инициализирует новый экземпляр класса Vehicle.
        /// </summary>
        /// <param name="brand">Марка транспортного средства.</param>
        /// <param name="model">Модель транспортного средства.</param>
        /// <param name="maxSpeed">Максимальная скорость транспортного средства.</param>
        /// <exception cref="ArgumentNullException">Если марка или модель являются пустыми или null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Если максимальная скорость меньше 0.</exception>
        public Vehicle(string brand, string model, int maxSpeed)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentNullException("Brand cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(model)) 
                throw new ArgumentNullException("Model cannot be null or empty.");
            if (maxSpeed <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSpeed), "Max speed must be greater than 0.");

            _brand = brand;
            _model = model;
            _maxSpeed = maxSpeed;
        }

        /// <summary>
        /// Метод клонирования объекта используя интерфейс ICloneable
        /// </summary>
        /// <returns>Новый объект типа Vehicle, который является клоном текущего.</returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Метод клонирования объекта используя интерфейс IMyCloneable.
        /// </summary>
        /// <returns>Новый объект типа Vehicle, который является клоном текущего.</returns>
        public abstract Vehicle Clone();

        /// <summary>
        /// Возвращает строковое представление объекта Vehicle.
        /// </summary>
        /// <returns>Строка, содержащая информацию о марки, модели и максимальной скорости.</returns>
        public override string ToString()
        {
            return $"Vehicle (Brand: {_brand}, Model: {_model}, Max Speed: {_maxSpeed} km/h)";
        }
    }
}
