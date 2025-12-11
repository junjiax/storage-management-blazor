using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;
	public sealed record CustomerRequest(
		 string Name,
		 string Phone,
		 string Email,
		string Address
   );

public class CustomerInfo
{
   public string Name { get; set; } = "";
   public string Phone { get; set; } = "";
   public string Email { get; set; } = "";
   public string Address { get; set; } = "";
}

public sealed record CustomerResponse(
		int CustomerId,
		string Name,
		string Phone,
		string Email,
		string Address,
		DateTime CreatedAt
	);
