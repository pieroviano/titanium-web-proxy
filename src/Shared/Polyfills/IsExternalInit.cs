#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Marker the compiler requires to emit an <c>init</c>-only setter or a positional record.
    ///     The BCL only ships it from .NET 5 onwards, so the legacy target frameworks need their own
    ///     copy; it is never referenced at run time, only matched by name during compilation.
    /// </summary>
    /// <remarks>
    ///     Linked into every project that targets a pre-.NET 5 framework. Declaring it twice in the
    ///     same assembly is an error, so link it once per project, never from a shared project that
    ///     is itself compiled in.
    /// </remarks>
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal static class IsExternalInit
    {
    }
}
#endif
