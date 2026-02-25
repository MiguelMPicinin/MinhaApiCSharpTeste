using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private static readonly List<Produto> _produtos = new();

    [HttpGet]
    public IActionResult Get() => Ok(_produtos);

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) 
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        produto.Id = _produtos.Count + 1;
        _produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produtoAtualizado)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return NotFound();

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            return NotFound();

        _produtos.Remove(produto);
        return NoContent();
    }
}