namespace LocadoraFilmesApi.Service.Infrastructure.Queries
{
    public class QueryLocacao
    {
        public const string GetLocacoes = @"
        SELECT 
			l.*,
			c.Nome AS NomeCliente,
            f.Titulo AS TituloFilme
		FROM Locacao l
		INNER JOIN Filme f ON l.Id_Filme = f.Id
		INNER JOIN Cliente c ON l.Id_Cliente = c.Id";
    }
}
