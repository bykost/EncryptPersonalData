using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApplication1.DataProtection
{
    //public class SqlXmlRepository : IXmlRepository
    //{
    //    private const string TableName = "\"XmlKeys\"";
    //    private readonly Func<IDbConnection> _connectionFactory;

    //    public SqlXmlRepository(Func<IDbConnection> connectionFactory)
    //    {
    //        _connectionFactory = connectionFactory;
    //    }

    //    public IReadOnlyCollection<XElement> GetAllElements()
    //    {
    //        using (var conn = Connection)
    //        {
    //            return conn.Query<XmlKey>($"select * from {TableName}")
    //                .Select(x => XElement.Parse(x.Xml))
    //                .ToList();
    //        }
    //    }

    //    public void StoreElement(XElement element, string friendlyName)
    //    {
    //        var key = new XmlKey
    //        {
    //            Xml = element.ToString(SaveOptions.DisableFormatting)
    //        };
    //        using (var conn = Connection)
    //        {
    //            return conn.ExecuteScalar<Guid>($"INSERT into {TableName}(Xml) values (@Xml) returning Id", key);
    //        }
    //    }

    //    private IDbConnection Connection
    //    {
    //        get
    //        {
    //            var conn = _connectionFactory();
    //            conn.Open();
    //            return conn;
    //        }
    //    }
    //}
}
