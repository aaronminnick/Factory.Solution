using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      Licenses = new HashSet<EngineerMachine> {};
    }
    public int EngineerId {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string FullName 
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }
    public virtual ICollection<EngineerMachine> Licenses {get;}
  }
}