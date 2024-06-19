using IoCdotNet.Attributes;
using Npgsql;

namespace DesignPattern.Aplicacao.Repositorios.Implementacao
{
    [SingletonInstance]
    public class ConfigDB
    {
        private NpgsqlConnectionStringBuilder _stringBuilder;

        internal NpgsqlConnectionStringBuilder Get()
        {
            return _stringBuilder;
        }

        public void Set(string servidor, string usuario, string senha, int porta, string banco)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = servidor;
            sb.Username = usuario;
            sb.Port = porta;
            sb.Password = senha;
            sb.Database = banco;
            _stringBuilder = sb;
        }
    }
}
