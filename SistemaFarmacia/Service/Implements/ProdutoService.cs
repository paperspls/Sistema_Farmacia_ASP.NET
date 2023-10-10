using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.Data;
using SistemaFarmacia.Model;
using SistemaFarmacia.Service;

namespace SistemaFarmacia.Service.Implements
{
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var ProdutoUpdate = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);

                return ProdutoUpdate;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produtos = await _context.Produtos
               .Include(p => p.Categoria)
               .Where(p => p.Nome.Contains(nome)).ToListAsync();
            return Produtos;
        }

        public async Task<Produto?> Create(Produto Produto)
        {
            if (Produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(Produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;
            }
            Produto.Categoria = Produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == Produto.Categoria.Id) : null;

            await _context.Produtos.AddAsync(Produto);
            await _context.SaveChangesAsync();

            return Produto;
        }

        public async Task<Produto?> Update(Produto Produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(Produto.Id);

            if (ProdutoUpdate is null)
                return null;

            Produto.Categoria = Produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == Produto.Categoria.Id) : null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(Produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Produto;
        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }


    }
}