using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiService.Data
{
  
  public class AppUser 
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public string State { get; set; }
    
  }
}