using Microsoft.EntityFrameworkCore;
using ZStore_BLL.DTO;
using ZStore_BLL.Models;
using Type = ZStore_BLL.Models.Type;

namespace ZStore_DAL.DAO
{
    internal class ProductDAO
    {
        //Singleton
        private static ProductDAO instance = null;
        public static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }


        //----------------------------------------- Method ----------------------------------------- 
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            try
            {
                using var context = new ZStore_SampleContext();
                var productList = await context.Products
                                        .Include(p => p.Category)
                                        .Include(p => p.Collection)
                                        .Include(p => p.SubCategoryId)
                                        .Include(p => p.Type)
                                        .Include(p => p.Vendor)
                                        .Select(p => new ProductDTO
                                        {   
                                            ProductId = p.ProductId,
                                            CategoryId = p.CategoryId,
                                            CollectionId = p.CollectionId,
                                            SubCategoryId = p.SubCategoryId,
                                            TypeId = p.TypeId,
                                            VendorId = p.VendorId,
                                            Title = p.Title,
                                            MetaTitle = p.MetaTitle,
                                            Content = p.Content,
                                            Image = p.Image,
                                            Images = p.Images,
                                            Slug = p.Slug,
                                            Sku = p.Sku,
                                            ViewTime = p.ViewTime,
                                            Status = p.Status,
                                            CreatedAt = p.CreatedAt,
                                            UpdatedAt = p.UpdatedAt,


                                            Category = new CategoryDTO
                                            {
                                                CategoryId = p.Category.CategoryId,
                                                ParentCategoryId = p.Category.ParentCategoryId,
                                                Title = p.Category.Title,
                                                Slug = p.Category.Slug,
                                                Sku = p.Category.Sku,
                                            },

                                            Collection = new CollectionDTO
                                            {
                                                CollectionId = p.Collection.CollectionId
                                            },

                                            SubCategory = new CategoryDTO
                                            {
                                                CategoryId = p.SubCategory.CategoryId
                                            },

                                            Type = new TypeDTO
                                            {
                                                TypeId = p.Type.TypeId
                                            },

                                            Vendor = new VendorDTO
                                            {
                                                VendorId = p.Vendor.VendorId,
                                                Title = p.Vendor.Title,
                                            }

                                        })
                                        .ToListAsync();
                return productList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error get product list.", ex);
            }
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                var product = await context.Products.FindAsync(id);
                if (product == null) throw new Exception();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error get product by id.", ex);
            }
        }

        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product object cannot be null.");
                }

                using var context = new ZStore_SampleContext();
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return product.ProductId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding product.", ex);
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new ArgumentNullException(nameof(product), "Product object cannot be null.");
                }

                using var context = new ZStore_SampleContext();
                context.Products.Update(product);
                await context.SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating product.", ex);
            }
        }
        public async Task DeleteProductAsync(int id)
        {
            try
            {
                using var context = new ZStore_SampleContext();
                var product = context.Products.FirstOrDefault(p => p.ProductId == id);

                if (product != null)
                {
                    context.Products.Remove(product);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product with id {id}.", ex);
            }
        }

    }
}
