using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sale_system.MODEL;
using Sale_system.MODEL.DAL.DBContext;





/*using Sale_system.DAL.DBContext;*/
using Sale_System.DAL.Repositories;
using Sale_System.DAL.Repositories.Contract;



namespace Sale_System.DAL.Repositories
{
    public class Sale_Repository : GenerictRepository<Sale>, ISaleRepository
    {
        private readonly DbSalesContext _salesContext;

        public Sale_Repository(DbSalesContext salesContext): base(salesContext)
        {
            _salesContext=salesContext;
        }

        public async Task<Sale> Register(Sale model)
        {
            Sale saleGeneric = new Sale();

            using (var transaction = _salesContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (Saledetail dv in model.Saledetails)
                    {
                        Product productFind = _salesContext.Products.Where(p => p.IdPproduct == dv.IdProduct).First();
                        productFind.Stock = productFind.Stock - dv.Amount;

                        _salesContext.Products.Update(productFind);
                    }
                    await _salesContext.SaveChangesAsync();

                    Documentsale correlative = _salesContext.Documentsales.First();

                    correlative.LastDocument = correlative.LastDocument + 1;

                    correlative.DateRegister = DateTime.Now;
                    _salesContext.Documentsales.Update(correlative);

                    await _salesContext.SaveChangesAsync();

                    int AmountDigites = 4;

                    string zero = string.Concat(Enumerable.Repeat("0", AmountDigites));
                    string SaleNumber = zero + correlative.LastDocument.ToString();

                    SaleNumber = SaleNumber.Substring(SaleNumber.Length - AmountDigites, AmountDigites);

                    model.Documentsale =int.Parse(SaleNumber);

                    await _salesContext.Sales.AddAsync(model);

                    await _salesContext.SaveChangesAsync();

                    saleGeneric = model;

                    transaction.Commit();

                    
                }
                catch
                {

                    transaction.Rollback();
                    throw;

                }
                return saleGeneric;
            }
        }
    }
}
