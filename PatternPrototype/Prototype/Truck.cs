namespace Prototype
{
    /// <summary>
    /// Класс Truck, представляющий грузовик.
    /// Наследуется от Vehicle и реализует метод клонирования.
    /// </summary>
    public class Truck : Vehicle
    {
        private readonly int _payloadCapacity;

        /// <summary>
        /// Инициализирует новый экземпляр класса Truck.
        /// </summary>
        /// <param name="brand">Марка грузовика.</param>
        /// <param name="model">Модель грузовика.</param>
        /// <param name="maxSpeed">Максимальная скорость грузовика.</param>
        /// <param name="payloadCapacity">Грузоподъемность грузовика.</param>
        /// <exception cref="ArgumentOutOfRangeException">Если грузоподъемность меньше 0.</exception>
        public Truck(string brand, string model, int maxSpeed, int payloadCapacity)
            : base(brand, model, maxSpeed)
        {
            if (payloadCapacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(payloadCapacity), "Payload capacity must be greater than 0");

            _payloadCapacity = payloadCapacity;
        }

        /// <summary>
        /// Метод клонирования объекта Truck.
        /// </summary>
        /// <returns>Новый объект Truck, который является клоном текущего.</returns>
        public override Vehicle Clone()
        {
            return new Truck(_brand, _model, _maxSpeed, _payloadCapacity);
        }

        /// <summary>
        /// Возвращает строковое представление объекта Truck.
        /// </summary>
        /// <returns>Строка, содержащая информацию о марке, модели, максимальной скорости и грузоподъемности.</returns>
        public override string ToString()
        {
            return base.ToString() + $", Truck (Payload capacity: {_payloadCapacity} kg)";
        }
    }
}
