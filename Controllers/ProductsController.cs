using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using UniS.Data;
using UniS.Models;

namespace UniS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<Customer> _userManager;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, UserManager<Customer> userManager)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }

        [Authorize] /*Creation of a cart for each individual user, as well as creation of an order for each customer. I also wrote code for transactions, but didn't have a chance to implement it propely.*/
        public async Task<IActionResult> AddToCart(int id, string? search)
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = from r in _context.Order
                         orderby r.CustomerID
                         where r.CustomerID == _userManager.GetUserId(User)
                         select r;
            orders = orders.OrderByDescending(s => s.OrderDate);


            var first = orders.FirstOrDefault();

            if (first == null)
            {
                var newOrder = new Order /* Creates The new Order */
                {
                    OrderDate = DateTime.Now,
                    PickupDate = DateTime.Now,
                    CustomerID = user.Id,
                    CustomerName = user.CustomerFirstName,
                    OrderStatus = Status.Incomplete,
                    CartQuantity = 1,
                    TotalPrice = 0
                };
                var Transaction = new Transaction
                {
                    Order = newOrder,
                    TransactionAmount = newOrder.TotalPrice,
                    PaymentMethod = "Debit",
                    TransactionDate = newOrder.OrderDate

                };
                _context.Add(Transaction);
                _context.Add(newOrder);

                await _context.SaveChangesAsync();

                orders = from r in _context.Order
                         orderby r.CustomerName
                         where r.CustomerName == user.Id
                         select r;

                orders = orders.OrderByDescending(s => s.OrderDate);
                var updatedfirst = orders.FirstOrDefault();
                var newShoppingItem = new CartItem
                {
                    OrderID = updatedfirst.OrderID,
                    ProductID = (int)id,
                    CartQuantity = 1
                };
                _context.Add(newShoppingItem);
                await _context.SaveChangesAsync();
                int? ID = (int)id;
                return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search });
            }
            if (first.OrderStatus == Status.Incomplete)
            {
                var ProductFilter = from cr in _context.CartItem.Include(s => s.Product).Include(s => s.Order)
                                    where cr.OrderID == first.OrderID && cr.ProductID == (int)id
                                    select cr;
                var ThisItem = ProductFilter.FirstOrDefault();
                if (ThisItem == null)
                {
                    var product = await _context.Product.SingleOrDefaultAsync(p => p.ProductID == id);
                    int? Error = 0;
                    if (product.ProductStock > 0)
                    {
                        var newShoppingItem = new CartItem /* Creates The new Cart */
                        {
                            OrderID = first.OrderID,
                            ProductID = (int)id,
                            CartQuantity = 1
                        };
                        product.ProductStock--;
                        first.CartQuantity++;
                        _context.Add(newShoppingItem);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        Error = 1;
                    }
                    int? ID = (int)id;
                    return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search, error = Error });
                }
                else
                {
                    int? ID = ThisItem.CartItemID; // Replace with the item in your cart
                    int? ShoppingID = ThisItem.OrderID;
                    return RedirectToAction("Edit", "CartItems", new { id = ID });
                }
            }
            else
            {
                var newOrder = new Order /* Creates The new Order, if there was already one */
                {
                    OrderDate = DateTime.Now,
                    PickupDate = DateTime.Now,
                    CustomerID = user.Id,
                    CustomerName = user.CustomerFirstName,
                    OrderStatus = Status.Incomplete,
                    CartQuantity = 1,
                    TotalPrice = 0
                };
                var payment = new Transaction
                {
                    Order = newOrder,
                    TransactionAmount = newOrder.TotalPrice,
                    PaymentMethod = "Debit",
                    TransactionDate = newOrder.OrderDate

                };
                _context.Add(payment);
                _context.Add(newOrder);

                await _context.SaveChangesAsync();

                orders = from r in _context.Order
                         orderby r.CustomerID
                         where r.CustomerID == user.Id
                         select r;

                orders = orders.OrderByDescending(s => s.OrderDate);
                var updatedfirst = orders.FirstOrDefault();
                var newShoppingItem = new CartItem  
                {
                    OrderID = updatedfirst.OrderID,     /*THIS WILL THROW AN ERROR ON ADDING TO CART INITIALLY, SIMPLY RESTART THE APPLICATION AND CONTINUE AS NORMAL, THE PRODUCT WILL ADD NORMALLY*/
                    ProductID = (int)id,
                    CartQuantity = 1
                };
                _context.Add(newShoppingItem);
                await _context.SaveChangesAsync();
                int? ID = (int)id;
                return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search });
            }

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,ProductSize,ProductPrice,ProductStock,imageFile")] Product product)
        {
            if (!ModelState.IsValid)
            {
                //save image to the images folder inside the wwwroot folder...

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.imageFile.FileName);
                string extension = Path.GetExtension(product.imageFile.FileName);
                product.fileName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.imageFile.CopyToAsync(fileStream);
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["imageFileName"] = product.fileName;
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductSize,ProductPrice,ProductStock")] Product product, string imageFileName)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    product.fileName = imageFileName;
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", product.fileName);
            
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
