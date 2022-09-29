namespace Doulex.Text
{
    /// <summary>
    /// The style of casing
    /// </summary>
    public enum CasingStyle
    {
        /// <summary>
        /// No casing
        /// </summary>
        None,

        /// <summary>
        /// The sentence casing, where the first letter of the first word is capitalized and use space to separate words
        /// eg: Hello world
        /// </summary>
        Sentence,

        /// <summary>
        /// The camel casing, where the first letter of each word is capitalized except the first word
        /// eg: helloWorld
        /// </summary>
        Camel,

        /// <summary>
        /// The pascal casing, where the first letter of each word is capitalized
        /// eg: HelloWorld
        /// </summary>
        Pascal,

        /// <summary>
        /// The lower casing, where all letters are lower case, and use underline to separate words
        /// eg: hello_world
        /// </summary>
        Snake,

        /// <summary>
        /// The lower casing, where all letters are lower case, and use dash to separate words
        /// eg: hello-world
        /// </summary>
        Kebab
    }
}
