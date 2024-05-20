using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClienteWcfService.ModelCliente;
using System.Collections;

namespace ClienteWcfService
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        public string strcon = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;

        public SqlDataAdapter GetData(int value)
        {
            // get conection 
            SqlDataAdapter adapt;

            // tratei minha conection, tive que instalar algumas dependencias.
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strcon))
                {
                    sqlCon.Open();
                    DataTable tabela = new DataTable();

                    adapt = new SqlDataAdapter("select * from Funcionarios", sqlCon);
                    adapt.Fill(tabela);


                    return adapt;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public IEnumerable<string> readEmpresa()
        {
            List<string> _Empresas = new List<string>();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strcon))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("select * from Empresas", sqlCon);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows == true)
                    {
                        while (dr.Read())
                        {
                            _Empresas.Add(dr[1].ToString());
                        }
                    }
                    sqlCon.Close();
                    return _Empresas;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
