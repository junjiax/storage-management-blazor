namespace frontendblazor.Models;


public class SimpleReportResponse
{
   public decimal TotalRevenue { get; set; }
   public int TotalOrders { get; set; }
   public int NewCustomers { get; set; }
   public double GrowthRate { get; set; }
}

public class SimpleReportRequest
{
   public string StartDate { get; set; }
   public string EndDate { get; set; }
}

public class MonthlyRevenueData
{
   public int Month { get; set; }
   public decimal Revenue { get; set; }
   public int Orders { get; set; }
}
public class ROByMothResponse
{
   public int Year { get; set; }
   public List<MonthlyRevenueData>? MonthlyRevenues { get; set; }
}


public class RatioByCategoryData
{
   public string Type { get; set; } = string.Empty;
   public decimal Value { get; set; }
}

public class RatioPByCResponse
{
   public List<RatioByCategoryData>? Ratios { get; set; }
}