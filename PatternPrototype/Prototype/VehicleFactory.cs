namespace Prototype
{
    /// <summary>
    /// Класс VehicleFactory для создания клонов объектов Vehicle.
    /// </summary>
    public class VehicleFactory
    {
        /// <summary>
        /// Создает клон указанного транспортного средства.
        /// </summary>
        /// <param name="vehicle">Транспортное средство, которое требуется клонировать.</param>
        /// <returns>Клонированное транспортное средство.</returns>
        /// <exception cref="ArgumentNullException">Если vehicle равен null.</exception>
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");

            return vehicle.Clone();
        }


        /// <summary> 
        /// Создает клон указанного транспортного средства используя для этого интерфейс ICloneable. 
        /// </summary> 
        /// <param name="vehicle">Транспортное средство, которое требуется клонировать.</param> 
        /// <returns>Клонированное транспортное средство.</returns> 
        /// <exception cref="ArgumentNullException">Если vehicle равен null.</exception>
        public Vehicle CreateVehicleUsingCloneable(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null.");

            ICloneable clonableVehicle = (ICloneable)vehicle;
            return (Vehicle)clonableVehicle.Clone();
        }
    }
}
