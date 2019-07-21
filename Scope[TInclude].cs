namespace Platform.Helpers
{
    public class Scope<TInclude> : Scope
    {
        public Scope()
            : this(false, false)
        {
        }

        public Scope(bool autoInclude = false, bool autoExplore = false)
            : base(autoInclude, autoExplore) => Include<TInclude>();
    }
}
