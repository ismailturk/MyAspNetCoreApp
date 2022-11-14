namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new(){Id = 1, Name = "Kalem1", Price = 20, Stock = 10 },
            new(){Id = 2, Name = "Kalem2", Price = 30, Stock = 10 },
            new(){Id = 3, Name = "Kalem3", Price = 40, Stock = 10 },
            new(){Id = 4, Name = "Kalem4", Price = 50, Stock = 10 },
            };
       

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product addProduct)=>_products.Add(addProduct);

        public void Remove(int id)
        {
            var hasProduct= _products.FirstOrDefault(p=>p.Id==id);  

            if(hasProduct==null)
            {
                throw new Exception($"Bu idye sahip{id} urun bulunmamaktadır");
            }
            _products.Remove(hasProduct);   
        }


        public void Update(Product updateProduct)
        {
            var hasProduct =_products.FirstOrDefault(p=>p.Id==updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu idye sahip{updateProduct.Id} urun bulunmamaktadır");
            }
            hasProduct.Name= updateProduct.Name;
            hasProduct.Price= updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;


            var index = _products.FindIndex(p=>p.Id==updateProduct.Id);
            _products[index] = hasProduct;

        }

    }
}
