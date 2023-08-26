using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;

namespace ProductsAPIBANCO.ProductsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsControllers : ControllerBase {

    [HttpGet]
    [Route("/")]
    public IActionResult GetProducts([FromServices] ProductDbContext db) {
        var bank = db.Products!.ToList();
        return Ok(bank);
    }

    [HttpGet]
    [Route("/{id}")]
    public IActionResult GetProduct([FromServices] ProductDbContext db,
                       [FromRoute] int id) {
        var bank =  db.Products!.FirstOrDefault(b => b.ProductId == id);
        return Ok(bank);
    }

    [HttpPost]
    [Route("/")]
    public IActionResult AddProduct([FromServices] ProductDbContext db,
                                      [FromBody] Product product) {
        db.Products!.Add(product);
        db.SaveChanges();
        return Created($"/{product.ProductId}", product);
    }

    [HttpPut]
    [Route("/{id:int}")]
    public IActionResult UpdateProduct([FromServices] ProductDbContext db,
                                     [FromRoute] int id,
                                     [FromBody] Product product) {

        var bank = db.Products!.FirstOrDefault(b => b.ProductId == id);
        if (bank == null) {
            return NotFound();
        }
        
        bank.Name = product.Name;
        bank.Price = product.Price;
        bank.Quantity = product.Quantity;

        db.Products!.Update(bank);
        db.SaveChanges();
        
        return Ok(bank);
    }
    
    [HttpDelete]
    [Route("/{id:int}")]
    public IActionResult DeleteProduct([FromServices] ProductDbContext db,
                                        [FromRoute] int id) {
        var bank = db.Products!.FirstOrDefault(b => b.ProductId == id);
        if (bank == null) {
            return NotFound();
        }

        db.Products!.Remove(bank);
        db.SaveChanges();
        
        return Ok(bank);
    }
}