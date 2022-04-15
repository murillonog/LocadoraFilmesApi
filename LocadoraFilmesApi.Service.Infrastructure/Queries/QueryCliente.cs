namespace LocadoraFilmesApi.Service.Infrastructure.Queries
{
    public class QueryCliente
    {
        public const string GetClientesAtrasados = @"
			SELECT c.*
            FROM cliente c
            INNER JOIN locacao l ON c.Id = l.Id_Cliente
            INNER JOIN filme f ON f.Id = l.Id_Filme
            WHERE l.DataDevolucao IS NULL AND 
                ((f.Lancamento = 1 AND DATEDIFF(now(),l.DataLocacao) > 2) OR 
	            (f.Lancamento = 0 AND DATEDIFF(now(),l.DataLocacao) > 3));";

        public const string GetSegundoClienteMaisAlugou = @"
            SELECT c.*
            FROM cliente c
            INNER JOIN locacao l ON c.Id = l.Id_Cliente
            GROUP BY l.Id_Cliente
            ORDER BY COUNT(c.Id) DESC
            LIMIT 1,1; ";
    }
}
