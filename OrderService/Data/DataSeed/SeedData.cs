using OrderService.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Data.DataSeed
{
    public class SeedData
    {
        public static void Seed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            applicationDbContext.Database.Migrate();

            if (!applicationDbContext.MarketingAreas.Any())
            {
                var marketingArea = new List<MarketingArea> {
                    new MarketingArea
					{
                        AreaCode = "A001",
                        AreaDescription= "Area Sumatera",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new MarketingArea
					{
						AreaCode = "A002",
						AreaDescription= "Area Jabodetabek",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new MarketingArea
					{
						AreaCode = "A003",
						AreaDescription= "Area Jawa, Bali dan Indonesia Timur",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
				};

                applicationDbContext.AddRange(marketingArea);
                applicationDbContext.SaveChanges();
            }

			if (!applicationDbContext.Stores.Any())
			{
				var stores = new List<Store> {
					new Store
					{
						StoreCode = "S00001",
						StoreDescription= "Medan",
						Address = "Jl Semeru",
						Phone = "123456",
						MarketingAreaId = applicationDbContext!.MarketingAreas!.FirstOrDefault(x => x.AreaCode == "A001")!.Id,
						MarketingAreaCode = "A001",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new Store
					{
						StoreCode = "S00002",
						StoreDescription= "Palembang",
						Address = "Jl Gajah",
						Phone = "123456",
						MarketingAreaId = applicationDbContext!.MarketingAreas!.FirstOrDefault(x => x.AreaCode == "A001")!.Id,
						MarketingAreaCode = "A001",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new Store
					{
						StoreCode = "S00003",
						StoreDescription= "Jakarta",
						Address = "Jl Sudirman",
						Phone = "123456",
						MarketingAreaId = applicationDbContext!.MarketingAreas!.FirstOrDefault(x => x.AreaCode == "A002")!.Id,
						MarketingAreaCode = "A002",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new Store
					{
						StoreCode = "S00004",
						StoreDescription= "Surabaya",
						Address = "Jl Sudirman",
						Phone = "123456",
						MarketingAreaId = applicationDbContext!.MarketingAreas!.FirstOrDefault(x => x.AreaCode == "A003")!.Id,
						MarketingAreaCode = "A003",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new Store
					{
						StoreCode = "S00005",
						StoreDescription= "Bali",
						Address = "Jl Dewa",
						Phone = "123456",
						MarketingAreaId = applicationDbContext!.MarketingAreas!.FirstOrDefault(x => x.AreaCode == "A003")!.Id,
						MarketingAreaCode = "A003",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
				};

				applicationDbContext.AddRange(stores);
				applicationDbContext.SaveChanges();
			}

			if (!applicationDbContext.ProductSpareparts.Any())
			{
				var productSpareparts = new List<ProductSparepart> {
					new ProductSparepart
					{
						ProductCode = "P00001",
						ProductDescription= "Pencil",
						ProductType = "PRO",
						ProductBrand = "Brand1",
						UOM = "PCS",
						COGS = 500,
						StoreId = applicationDbContext!.Stores!.FirstOrDefault(x => x.StoreCode == "S00001")!.Id,
						StoreCode = "S00001",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new ProductSparepart
					{
						ProductCode = "P00002",
						ProductDescription= "Table",
						ProductType = "PRO",
						ProductBrand = "Brand2",
						UOM = "PCS",
						COGS = 50000,
						StoreId = applicationDbContext!.Stores!.FirstOrDefault(x => x.StoreCode == "S00001")!.Id,
						StoreCode = "S00001",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new ProductSparepart
					{
						ProductCode = "P00003",
						ProductDescription= "Bolt",
						ProductType = "SPA",
						ProductBrand = "Brand3",
						UOM = "Box",
						COGS = 9000,
						StoreId = applicationDbContext!.Stores!.FirstOrDefault(x => x.StoreCode == "S00002")!.Id,
						StoreCode = "S00002",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new ProductSparepart
					{
						ProductCode = "P00004",
						ProductDescription= "Shock Breaker",
						ProductType = "SPA",
						ProductBrand = "Brand4",
						UOM = "PCS",
						COGS = 1200000,
						StoreId = applicationDbContext!.Stores!.FirstOrDefault(x => x.StoreCode == "S00003")!.Id,
						StoreCode = "S00003",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					},
					new ProductSparepart
					{
						ProductCode = "P00005",
						ProductDescription= "Tire",
						ProductType = "SPA",
						ProductBrand = "Brand5",
						UOM = "PCS",
						COGS = 700000,
						StoreId = applicationDbContext!.Stores!.FirstOrDefault(x => x.StoreCode == "S00003")!.Id,
						StoreCode = "S00003",
						CreatedAt = DateTimeOffset.UtcNow,
						CreatedBy = "Admin",
						UpdatedAt = DateTimeOffset.UtcNow,
						UpdatedBy = "Admin"
					}
				};

				applicationDbContext.AddRange(productSpareparts);
				applicationDbContext.SaveChanges();
			}


		}

    }
}
