using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace frontendblazor.Models;
	public sealed class CustomerRequest(
		[property: JsonPropertyName("name")] string Name,
		[property: JsonPropertyName("phone")] string Phone,
		[property: JsonPropertyName("email")] string Email,
		[property: JsonPropertyName("address")] string Address
	);
	public sealed class CustomerResponse(
		int CustomerId,
		string Name,
		string Phone,
		string Email,
		string Address,
		DateTime CreatedAt
	);
