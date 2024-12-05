namespace DelegatesEvents
{
    public static class CollectionExtension
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null or empty");

            return collection.Aggregate((max, current) => convertToNumber(current) > convertToNumber(max) ? current : max);
        }
    }
}