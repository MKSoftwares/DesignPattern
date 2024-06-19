using DesignPattern.Aplicacao.Dominios;
using DesignPattern.Extensoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using System.Data;
using System.Text.RegularExpressions;

namespace DesignPattern.Aplicacao.Repositorios.Implementacao
{
    public class Contexto : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        public Contexto()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
#if DEBUG

            Configura("zeus", "postgres", "2291755", 5432, "designpattern_teste");
#endif
        }

        public void Save()
        {
            SaveChanges();
        }

        public void InitializeDatabase()
        {
            Seed();
        }

        private void Seed()
        {

        }

        // Será usado pelo DAPPER
        public IDbConnection GetDbConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.HasDefaultSchema("public");

            ToLowerObjecteNames(modelBuilder);

            modelBuilder.Ignore<Notificacao>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

            Seed();
        }

        private static void ToLowerObjecteNames(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                var tableNme = ToSnakeCase(entity.GetTableName());
                entity.SetTableName(tableNme);

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    var columnName = ToSnakeCase(property.GetColumnName());
                    property.SetColumnName(columnName);
                }

                foreach (var key in entity.GetKeys())
                {
                    var keyName = ToSnakeCase(key.GetName());
                    key.SetName(keyName);
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    var keyName = ToSnakeCase(key.GetConstraintName());
                    key.SetConstraintName(keyName);
                }

                foreach (var index in entity.GetIndexes())
                {
                    var indexName = ToSnakeCase(index.GetDatabaseName());
                    index.SetDatabaseName(indexName);
                }
            }
        }

        private static string ToSnakeCase(string data)
            => string.IsNullOrWhiteSpace(data)
            ? data
            : Regex.Replace(
                data,
                @"([a-z0-9])([A-Z])",
                "$1_$2",
                RegexOptions.Compiled,
                TimeSpan.FromSeconds(1)).ToLower();

        private static string ConnectionString;
        internal void Configura(string servidor, string usuario, string senha, int porta, string banco)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = servidor;
            sb.Username = usuario;
            sb.Port = porta;
            sb.Password = senha;
            sb.Database = banco;
            ConnectionString = sb.ToString();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(ConnectionString);
        }

        public void ApplyPendingMigrations()
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }


    }
}
