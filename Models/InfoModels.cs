namespace frontendblazor.Models;
using System.Collections.Generic;


public class Province
{
   public int code { get; set; }
   public string name { get; set; }
   public List<District> districts { get; set; }
}

public class District
{
   public int code { get; set; }
   public string name { get; set; }
   public List<Ward> wards { get; set; }
}

public class Ward
{
   public int code { get; set; }
   public string name { get; set; }
}
