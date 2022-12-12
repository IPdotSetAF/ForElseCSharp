namespace ForElse
{
    public static class CSharpExtensions
    {
        /// <summary>
        /// Example:
        /// 
        /// Enumerable.ForeachElse(item =>
        /// {
        ///     //Foreach body
        ///     return true;
        /// },
        /// delegate
        /// {
        ///     //Else body
        /// });
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">Foreach body</param>
        /// <param name="else">Else body</param>
        public static void ForeachElse<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> action, Action @else)
        {
            foreach (var item in source)
            {
                if (!action(item))
                    return;
            }
            @else();
        }

        /// <summary>
        /// Example:
        /// 
        /// ForElse<int>(delegate { return 0;}, i => i< 10, i => i++, i =>
        /// {
        ///     //For body
        ///     return true;
        /// },
        /// delegate
        /// {
        ///     //Else body
        /// });
        /// </summary>
        /// <typeparam name="TCounter">Counter type</typeparam>
        /// <param name="init">Initialize counter</param>
        /// <param name="condition">Check condition</param>
        /// <param name="count">Do count</param>
        /// <param name="action">For body (return false if you want to break)</param>
        /// <param name="else">Else body (Else runs when there where no break)</param>
        public static void ForElse<TCounter>(Func<TCounter> init, Func<TCounter, bool> condition, Func<TCounter, TCounter> count, Func<TCounter, bool> action, Action @else)
        {
            for (TCounter counter = init(); condition(counter); counter = count(counter))
            {
                if (!action(counter))
                    return;
            }
            @else();
        }
    }
}
