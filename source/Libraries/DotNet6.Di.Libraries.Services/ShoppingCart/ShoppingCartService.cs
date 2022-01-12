﻿using DotNet6.Di.Libraries.Services.ShoppingCart.Models;
using DotNet6.Di.Libraries.Services.Storage;

namespace DotNet6.Di.Libraries.Services.ShoppingCart
{
    /// <summary>
    /// Used for shopping cart methods.
    /// </summary>
    public class ShoppingCartService : IShoppingCartService
    {
        /// <summary>
        /// A private reference to the storage service from the IoC container.
        /// </summary>
        private readonly IStorageService _storageService;

        /// <summary>
        /// Unique Id of the shopping cart.
        /// </summary>
        private Guid? Id { get; set; }

        /// <summary>
        /// Constructs a product service.
        /// </summary>
        /// <param name="storageService">A reference to the storage service from the IoC container.</param>
        public ShoppingCartService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /// <summary>
        /// Sets the unique id of the shopping cart and adds it to the storage.
        /// </summary>
        /// <param name="id">Unique id of the shopping cart.</param>
        public void SetId(Guid id)
        {
            Id = id;
            _storageService.AddShoppingCart(id);
        }

        /// <summary>
        /// Gets the shopping cart model.
        /// </summary>
        /// <returns>The shopping cart as a <see cref="ShoppingCartModel"/> type.</returns>
        /// <exception cref="Exception">Returns an exception if the shopping cart cannot be found.</exception>
        public ShoppingCartModel Get()
        {
            if (!Id.HasValue)
            {
                throw new Exception("The Id for the shopping cart has not been set.");
            }

            return _storageService.ShoppingCarts.First(sc => sc.Id == Id.Value);
        }
    }
}
