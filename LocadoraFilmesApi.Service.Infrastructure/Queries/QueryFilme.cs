namespace LocadoraFilmesApi.Service.Infrastructure.Queries
{
    public class QueryFilme
    {
        public const string GetNuncaAlugados = @"
            SELECT f.*
            FROM filme f
            LEFT JOIN locacao l ON f.Id = l.Id_Filme
            WHERE l.Id_Filme IS NULL; ";

        public const string GetTop5Alugados = @"
            SELECT f.*
            FROM filme f
            LEFT JOIN locacao l ON f.Id = l.Id_Filme
            WHERE YEAR(NOW()) = YEAR(l.DataLocacao)
            GROUP BY l.Id_Filme, f.Titulo
            ORDER BY COUNT(f.Id) DESC
            LIMIT 5;";

        public const string GetTop3MenosAlugados = @"
            SELECT f.*
            FROM filme f
            LEFT JOIN locacao l ON f.Id = l.Id_Filme
            WHERE YEAR(NOW()) = YEAR(l.DataLocacao)
            GROUP BY l.Id_Filme, f.Titulo
            ORDER BY COUNT(f.Id) ASC
            LIMIT 3;";
    }
}
