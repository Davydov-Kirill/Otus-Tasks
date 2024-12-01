namespace Prototype
{
    /// <summary>
    /// Интерфейс IMyCloneable, определяющий метод клонирования.
    /// </summary>
    /// <typeparam name="T">Тип, который реализует данный интерфейс.</typeparam>
    public interface IMyCloneable<T>
    {
        T Clone();
    }
}
