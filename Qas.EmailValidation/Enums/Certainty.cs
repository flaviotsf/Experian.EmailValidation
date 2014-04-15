namespace Qas.EmailValidation.Enums
{
    /// <summary>
    ///     All possible return certainties from the QAS API
    /// </summary>
    public enum Certainty
    {
        Verified,
        Undeliverable,
        Unreachable,
        Illegitimate,
        Disposable,
        Unknown
    }
}