#if !NET7_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Marks a type or member as having <c>required</c> members. The compiler emits it for every
    ///     <c>required</c> property and refuses to compile one when the attribute cannot be found, so
    ///     the pre-.NET 7 target frameworks need their own copy.
    /// </summary>
    [global::System.AttributeUsage(global::System.AttributeTargets.Class | global::System.AttributeTargets.Struct |
                                   global::System.AttributeTargets.Field | global::System.AttributeTargets.Property,
        AllowMultiple = false, Inherited = false)]
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal sealed class RequiredMemberAttribute : global::System.Attribute
    {
    }

    /// <summary>
    ///     Tells a compiler that it must understand the named feature to consume the annotated member.
    ///     Emitted alongside <see cref="RequiredMemberAttribute" />, so it is required for the same reason.
    /// </summary>
    [global::System.AttributeUsage(global::System.AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal sealed class CompilerFeatureRequiredAttribute : global::System.Attribute
    {
        public CompilerFeatureRequiredAttribute(string featureName)
        {
            FeatureName = featureName;
        }

        public string FeatureName { get; }

        public bool IsOptional { get; set; }

        public const string RefStructs = nameof(RefStructs);

        public const string RequiredMembers = nameof(RequiredMembers);
    }
}

namespace System.Diagnostics.CodeAnalysis
{
    /// <summary>
    ///     States that a constructor sets every <c>required</c> member, which lets callers use that
    ///     constructor without an object initializer.
    /// </summary>
    [global::System.AttributeUsage(global::System.AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal sealed class SetsRequiredMembersAttribute : global::System.Attribute
    {
    }
}
#endif
