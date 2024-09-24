using ASP_MVC_01.Models;

namespace ASP_MVC_01.Services {
    public class ProductService : List<ProductModel>{
        public ProductService(){
            this.AddRange(new ProductModel[]{
                new ProductModel() {Id = 1, Name = "IphoneX", Price = 1000},
                new ProductModel() {Id = 2, Name = "XiaoMi", Price = 500},
                new ProductModel() {Id = 3, Name = "Oppo", Price = 100},
                new ProductModel() {Id = 4, Name = "Nokia22", Price = 5000},
            });
        }

    }
}