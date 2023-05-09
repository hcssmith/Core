
namespace Core.Library.Types
{
  public abstract class DefaultTypeBuilder
  {
    public static T? CreateDefault<T>() where T : class
    {
      T? type = (T?)Activator.CreateInstance<T>();

      if (type is null) return null;

      return type switch {
        Integer => (dynamic) new Integer(Integer.DefaultValue),
        Bool => (dynamic) new Bool(Bool.DefaultValue),
        Fraction => (dynamic) new Fraction(Fraction.DefaultValue),
        Letter => (dynamic) new Letter(Letter.DefaultValue),
        Location => (dynamic) new Location(Location.DefaultValue),
        Text => (dynamic) new Text(Text.DefaultValue),
        _ => type,
      };
    }
  }
}
